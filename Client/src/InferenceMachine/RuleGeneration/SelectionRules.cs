using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

using FuzzySelector.Common.Ontology;

using Client.resx;

namespace FuzzySelector.Client.InferenceMachine.RuleGeneration {

    /// <summary>
    ///   Mașina de inferență pentru algoritmul cu reguli fuzzy.
    /// </summary>
    public partial class SelectionRules : InferenceMachine {

        /// <summary>
        ///   Structură ce reprezintă o regulă.
        /// </summary>
        private struct Rule {

            public readonly int[] requirements;
            public readonly int decision;

            public Rule(int[] requirements, int decision) {

                this.requirements = requirements;
                this.decision = decision;
            }
        }

        /// <summary>
        ///   Manager tabele lingvistice.
        /// </summary>
        public readonly ResourceManager resourceManager = new ResourceManager("Client.resx.ClientStrings", System.Reflection.Assembly.GetExecutingAssembly());

        /// <summary>
        ///   Șiruri de caractere reprezentând prefixe pentru numele deciziilor.
        /// </summary>
        private static readonly string[][] outcomePrefixes = new string[][] { new string[] { "STRONG" }, new string[] { "STRONG", "WEAK" }, new string[] { "VERY_STRONG", "STRONG", "WEAK" }, new string[] { "VERY_STRONG", "STRONG", "WEAK", "VERY_WEAK" } };

        /// <summary>
        ///   Șiruri de caractere reprezentând prefixe pentru numele vecinilor generați.
        /// </summary>
        private static readonly string[][] prefixes = new string[][] { new string[] { "NEAR" }, new string[] { "NEAR", "FAR" }, new string[] { "VERY_CLOSE", "NEAR", "FAR" }, new string[] { "VERY_CLOSE", "NEAR", "FAR", "VERY_FAR" }, new string[] { "VERY_CLOSE", "NEAR", "QUITE_FAR", "FAR", "VERY_FAR" }, new string[] { "VERY_CLOSE", "QUITE_CLOSE", "NEAR", "QUITE_FAR", "FAR", "VERY_FAR" } };

        /// <summary>
        ///   Ontologiile construite ale cererilor și vecinilor acestora.
        /// </summary>
        private List<Property> _requirementOntologies = new List<Property>();

        /// <summary>
        ///   Locațiile în cadrul ontologiilor cererilor unde se găsește termenul identic cu cererea.
        /// </summary>
        private List<int> _exactlyLocations = new List<int>();

        /// <summary>
        ///   Importanțele cererilor.
        /// </summary>
        private List<double> requirementImportances = new List<double>();

        /// <summary>
        ///   Ontologiile concluziilor.
        /// </summary>
        private List<DecisionShape> _decisionOntology;

        /// <summary>
        ///   Regulile.
        /// </summary>
        private List<Rule> rules = new List<Rule>();

        /// <summary>
        ///   Numărul de decizii posibile.
        /// </summary>
        private int numberOfOutcomes;

        public Property[] requirementOntologies {

            get {

                return this._requirementOntologies.ToArray();
            }
        }

        public int[] exactlyLocations {

            get {

                return this._exactlyLocations.ToArray();
            }
        }

        /// <summary>
        ///   Returnează ontologia deciziilor.
        /// </summary>
        public Property decisionOntology {
           
            get {

                List<Term> terms = new List<Term>();
               
                foreach (DecisionShape decisionShape in this._decisionOntology) {

                    terms.Add(decisionShape.shape);
                }

                return new Property("Decision", 0, 1, terms);
            }
        }

        /// <param name="originalOntology">Ontologia funcționalității la care cererea se referă</param>
        /// <param name="requestShapes">Formele cererilor</param>
        public SelectionRules(Functionality originalOntology, RequestShape[] requestShapes) {

            this.numberOfOutcomes = ClientSettings.Default.RULE_GENERATION_NUMBER_OF_OUTCOMES;
            
            foreach (RequestShape requestShape in requestShapes) {

                foreach (Property property in originalOntology.properties) {

                    if (property.name == requestShape.shape.name) {

                        int exactlyLocation;
                       
                        this._requirementOntologies.Add(this.constructRequirementOntology(requestShape, property.start, property.end, out exactlyLocation));
                        
                        this._exactlyLocations.Add(exactlyLocation);
                        
                        this.requirementImportances.Add(InferenceMachine.calculateImportance(requestShape.importance));
                       
                        break;
                    }
                }
            }

            this.requirements = new int[this._requirementOntologies.Count];
            this.rules = this.bktCombinations(0, null);

            this.constructDecisionOntology();
        }

        /// <summary>
        ///   Aplică inferența pe un anumit serviciu și returnează numărul și intensitatea activării regulilor și a concluziilor.
        /// </summary>
        /// <param name="service">Serviciul pentru care se aplică inferența</param>
        /// <returns>Rezultatul inferenței în sub forma unei subclase RuleActivations</returns>
        public RuleActivations applyToService(Service service) {
         
            RuleActivations result;
           
            switch (ClientSettings.Default.RULE_GENERATION_DECISION_ACTIVATION_ALGORITHM) {

                case (int)DecisionActivationAlgorithms.maximumDecisionActivationLevel:
                   
                    result = new MaxRuleActivations(this._decisionOntology);
                    break;

                default:
                   
                    result = new MedRuleActivations(this._decisionOntology);
                    break;
            }

            Property[] providedProperties = new Property[_requirementOntologies.Count];

            for (int i = 0; i < this._requirementOntologies.Count; ++i) {
               
                providedProperties[i] = service.functionality.getProperty(this._requirementOntologies[i].name);
            }

            foreach (Rule rule in this.rules) {
               
                double activationLevel = 0;
               
                double minActivationLevel = double.PositiveInfinity;
              
                for (int i = 0; i < this._requirementOntologies.Count; ++i) {

                    double intersection = providedProperties[i] == null ? 1 : InferenceMachine.intersect(service, providedProperties[i], this._requirementOntologies[i].terms[rule.requirements[i]]);
                   
                    if (intersection <= 0) {
                        activationLevel = -1;
                        break;
                    } 
                    else {
                        
                        if (!double.IsNaN(intersection)) {
                        
                            activationLevel += intersection;
                            minActivationLevel = Math.Min(intersection, minActivationLevel);
                        }
                    }
                }

                if (activationLevel > 0 && this._requirementOntologies.Count > 0) {

                    result.activate(rule.decision, ClientSettings.Default.RULE_GENERATION_RULE_ACTIVATION_ALGORITHM == (int)RuleActivationAlgorithms.minimumPropertyActivationLevel ? minActivationLevel : activationLevel / this._requirementOntologies.Count);
                }
            }

            return result;
        }

        /// <summary>
        ///   Construiește textul tipăribil pentru toate regulile.
        /// </summary>
        /// <returns>Regulile lizibile, cate o regulă per șir de caractere</returns>
        public string[] getPrintableRules() {

            string[] result = new string[this.rules.Count];
            
            for (int i = 0; i < this.rules.Count; ++i) {
              
                string auxRule = "If ";
               
                for (int j = 0; j < this._requirementOntologies.Count; ++j) {

                    if (j > 0) {

                        auxRule += " And ";
                    }

                    auxRule += this._requirementOntologies[j].name + " is " + this._requirementOntologies[j].terms[this.rules[i].requirements[j]].name;
                }

                auxRule += " then the Decision is " + this._decisionOntology[this.rules[i].decision].shape.name + ".";
               
                result[i] = auxRule;
            }

            return result;
        }

        /// <summary>
        ///   Aplică inferența pe un anumit serviciu și returnează răspunsul în format CSV.
        /// </summary>
        /// <param name="service">Serviciul pentru care se aplică inferența</param>
        /// <returns>Rezultatul inferenței în format CSV - fiecare rând conține valoarea finală dar și valorile și numărul de activari a tuturor deciziilor</returns>
        public override string applyToServiceInCSVFormat(Service service) {

            return service.name + this.applyToService(service).toCSVFormat() + service.accessPoint;
        }
    }
}