using System;
using System.Collections.Generic;

using FuzzySelector.Common.Ontology;

namespace FuzzySelector.SmartSpammer.InferenceMachine.MulticriteriaDecision {

    /// <summary>
    ///   Mașina de inferență pentru algoritmul cu decizii multicriteriu.
    /// </summary>
    class MulticriteriaDecisionMaker : InferenceMachine {

        /// <summary>
        ///   Asociere între termenii cererilor și importanțele acestora
        /// </summary>
        private Dictionary<Term, double> requestImportances = new Dictionary<Term,double>();

        /// <param name="originalOntology">Ontologia funcționalității la care cererea se referă</param>
        /// <param name="requestShapes">Formele cererilor</param>
        public MulticriteriaDecisionMaker(Functionality originalOntology, RequestShape[] requestShapes) {

            foreach (RequestShape requestShape in requestShapes) {

                foreach (Property property in originalOntology.properties) {

                    if (property.name == requestShape.shape.name) {

                        Term term = requestShape.shape.clone();

                        this.requestImportances.Add(term, InferenceMachine.calculateImportance(requestShape.importance));

                        break;
                    }
                }
            }
        }

        /// <summary>
        ///   Aplică inferența pe un anumit serviciu și returnează răspunsul în format CSV.
        /// </summary>
        /// <param name="service">Serviciul pentru care se aplică inferența</param>
        /// <returns>Rezultatul inferenței în format CSV - fiecare rând conține valoarea finală</returns>
        public override string applyToServiceInCSVFormat(Service service) {

            return service.accessPoint + "," + service.name + "," + Math.Round(this.calculateValue(service), 12).ToString("0.############");
        }

        /// <summary>
        ///   Calculează valoarea aplicării algoritmului de decizii multicriteriu pe un anumit serviciu.
        /// </summary>
        /// <param name="service">Serviciul pe care se aplică algoritmul</param>
        /// <returns>Media ponderată a intersecțiilor cererilor cu proprietățile serviciului. Ponderile sunt importanțele cererilor.</returns>
        private double calculateValue(Service service) {
           
            double sum = 0.0;
            double weightSum = 0.0;

            foreach (Term term in this.requestImportances.Keys) {

                Property property = service.functionality.getProperty(term.name);

                if (property != null) {

                    double intersection = InferenceMachine.intersect(service, property, term) * this.requestImportances[term];
                   
                    if (!double.IsNaN(intersection)) {

                        sum += intersection;

                        weightSum += this.requestImportances[term];
                    }
                }
            }

            return sum / weightSum;
        }
    }
}