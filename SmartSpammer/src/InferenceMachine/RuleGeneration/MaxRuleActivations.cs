using System.Collections.Generic;

namespace FuzzySelector.SmartSpammer.InferenceMachine.RuleGeneration {
    
    /// <summary>
    ///   Implementarea unei clase RuleActivations după algoritmul care consideră nivelul maxim de activare pentru reguli.
    /// </summary>
    public class MaxRuleActivations : RuleActivations {
      
        /// <param name="decisionOntology">Ontologia deciziei sub forma unei liste de forme ale concluziilor</param>
        public MaxRuleActivations(List<DecisionShape> decisionOntology)
          
            : base(decisionOntology) {
          
            for (int i = 0; i < this.ruleDecisions.Length; ++i) {

                this.ruleDecisions[i].activationLevel = double.NegativeInfinity;
            }
        }

        /// <summary>
        ///   Tratează activarea unei reguli. Se ia în considerare activarea maximă
        /// </summary>
        /// <param name="ruleDecisionNumber">Numărul deciziei care a fost activată</param>
        /// <param name="activationLevel">Nivelul de activare al deciziei</param>
        public override void activate(int ruleDecisionNumber, double activationLevel) {
          
            base.activate(ruleDecisionNumber, activationLevel);
           
            if (activationLevel > this.ruleDecisions[ruleDecisionNumber].activationLevel) {

                this.ruleDecisions[ruleDecisionNumber].activationLevel = activationLevel;
            }
        }

        /// <summary>
        ///   Returnează nivelul de activare al unei decizii.
        /// </summary>
        /// <param name="ruleDecisionNumber">Numărul deciziei</param>
        /// <returns>Nivelul de activare al deciziei</returns>
        public override double getActivationLevel(int ruleDecisionNumber) {

            return double.IsNegativeInfinity(this.ruleDecisions[ruleDecisionNumber].activationLevel) ? 0 : this.ruleDecisions[ruleDecisionNumber].activationLevel;
        }
    }
}
