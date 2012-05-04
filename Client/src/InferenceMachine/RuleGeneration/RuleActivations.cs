using System;
using System.Collections.Generic;

namespace FuzzySelector.Client.InferenceMachine.RuleGeneration {
   
    /// <summary>
    ///   Clasă abstractă de calculare a numărului și intensității activării regulilor și concluziilor.
    /// </summary>
    public abstract class RuleActivations {
        
        /// <summary>
        ///   Formele deciziilor finale.
        /// </summary>
        protected DecisionShape[] ruleDecisions;

        /// <summary>
        ///   Centrul de greutate minim al formelor.
        /// </summary>
        private double minCenterOfMass = double.PositiveInfinity;

        /// <summary>
        ///   Centrul de greutate maxim al formelor.
        /// </summary>
        private double maxCenterOfMass = double.NegativeInfinity;

        /// <param name="decisionOntology">Ontologia deciziei sub forma unei liste de forme ale concluziilor</param>
        public RuleActivations(List<DecisionShape> decisionOntology) {
            
            this.ruleDecisions = new DecisionShape[decisionOntology.Count];
            
            for (int i = 0; i < this.ruleDecisions.Length; ++i) {

                this.ruleDecisions[i] = decisionOntology[i].clone();

                this.minCenterOfMass = Math.Min(this.minCenterOfMass, this.ruleDecisions[i].centerOfGravity);
                this.maxCenterOfMass = Math.Max(this.maxCenterOfMass, this.ruleDecisions[i].centerOfGravity);
            }
        }

        /// <summary>
        ///   Tratează activarea unei reguli. Metodă virtuală care oferă doar o funcționalitate minimală la care poate fi adăugat în subclase.
        /// </summary>
        /// <param name="ruleDecisionNumber">Numărul deciziei care a fost activată</param>
        /// <param name="activationLevel">Nivelul de activare al deciziei</param>
        public virtual void activate(int ruleDecisionNumber, double activationLevel) {
            
            this.ruleDecisions[ruleDecisionNumber].incrementActivationCount();
        }

        /// <summary>
        ///   Returnează nivelul de activare al unei decizii. Abstractă - implementată obligatoriu în subclase.
        /// </summary>
        /// <param name="ruleDecisionNumber">Numărul deciziei</param>
        /// <returns>Nivelul de activare al deciziei</returns>
        public abstract double getActivationLevel(int ruleDecisionNumber);

        /// <summary>
        ///   Defuzzifică în valoarea finală crisp.
        /// </summary>
        /// <param name="unscaled">Parametru de ieșire, reprezintă valoarea defuzzificată înainte de scalare la intervalul [0, 1]</param>
        /// <returns>Valoarea crisp scalată la intervalul 0, 1</returns>
        private double deFuzzyfy(out double unscaled) {

            double totalWeight = 0;
            double totalX      = 0;

            for (int i = 0; i < this.ruleDecisions.Length; ++i) {

                double curentWeight = this.getActivationLevel(i) * this.ruleDecisions[i].activationCount;
              
                totalX      += this.ruleDecisions[i].centerOfGravity * curentWeight;
               
                totalWeight += curentWeight;
            }

            if (totalWeight > 0) {

                unscaled = totalX / totalWeight;

                if (this.minCenterOfMass == this.maxCenterOfMass) {

                    return this.minCenterOfMass;
                }
                else {

                    return (unscaled - this.minCenterOfMass) / (this.maxCenterOfMass - this.minCenterOfMass);
                }
            } 
            else {

                unscaled = 0;

                return 0;
            }
        }

        /// <summary>
        ///   Calculează rezultatul final după defuzzificare (și anumite subrezultate relevante).
        /// </summary>
        /// <returns>Rezultatele în format CSV</returns>
        public string toCSVFormat()
        {

            double unscaled;

            string result = "," + this.deFuzzyfy(out unscaled) + ",";

            return result;
        }

        public override string ToString() {

            string result = "";
           
            for (int i = 0; i < this.ruleDecisions.Length; ++i) {

                result += this.ruleDecisions[i].ToString() + " and has an activation level of " + this.getActivationLevel(i) + ";\r\n";
            }

            double unscaled;

            return result + "Defuzzyfied it ammounts to " + this.deFuzzyfy(out unscaled) + " out of 1 (" + unscaled + " unscaled);";
        }
    }
}