using System.Collections.Generic;

namespace FuzzySelector.Client.InferenceMachine.RuleGeneration {
    
    /// <summary>
    ///   Implementarea unei clase RuleActivations după algoritmul care consideră nivelul mediu de activare pentru reguli.
    /// </summary>
    public class MedRuleActivations : RuleActivations {
        
        /// <param name="decisionOntology">Ontologia deciziei sub forma unei liste de forme ale concluziilor</param>
        public MedRuleActivations(List<DecisionShape> decisionOntology)
            
            : base(decisionOntology) {
        }

        /// <summary>
        ///   Tratează activarea unei reguli. Se calculează totalul activărilor pentru a putea avea acces la activarea medie.
        /// </summary>
        /// <param name="ruleDecisionNumber">Numărul deciziei care a fost activată</param>
        /// <param name="activationLevel">Nivelul de activare al deciziei</param>
        public override void activate(int ruleDecisionNumber, double activationLevel) {
            
            base.activate(ruleDecisionNumber, activationLevel);
            
            this.ruleDecisions[ruleDecisionNumber].activationLevel += activationLevel;
        }

        /// <summary>
        ///   Returnează nivelul de activare al unei decizii calculând activarea medie.
        /// </summary>
        /// <param name="ruleDecisionNumber">Numărul deciziei</param>
        /// <returns>Nivelul de activare al deciziei</returns>
        public override double getActivationLevel(int ruleDecisionNumber) {

            return this.ruleDecisions[ruleDecisionNumber].activationCount > 0 ? this.ruleDecisions[ruleDecisionNumber].activationLevel / this.ruleDecisions[ruleDecisionNumber].activationCount : 0;
        }
    }
}
