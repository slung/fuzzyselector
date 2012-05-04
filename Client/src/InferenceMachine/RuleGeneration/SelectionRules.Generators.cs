using System;
using System.Collections.Generic;

using FuzzySelector.Common.Ontology;

using Client.resx;

namespace FuzzySelector.Client.InferenceMachine.RuleGeneration {
   
    /// <summary>
    ///   Partea din clasă ce se ocupă cu generări de reguli și ontologii.
    /// </summary>
    public partial class SelectionRules : InferenceMachine {
       
        /// <summary>
        ///   Atribut auxiliar pentru algoritmul de backtracking ce generează regulile. Se va transforma în premise pentru o regulă.
        /// </summary>
        private int[] requirements;

        /// <summary>
        ///   Atribut auxiliar pentru algoritmul de backtracking ce generează regulile. Reține deviația minimă pentru scalare la final.
        /// </summary>
        private double minDecision;

        /// <summary>
        ///   Atribut auxiliar pentru algoritmul de backtracking ce generează regulile. Reține deviația maximă pentru scalare la final.
        /// </summary>
        private double maxDecision;

        /// <summary>
        ///   Generează prin backtracking toate combinațiile posibile de premise și calculează valorile concluziilor generând reguli.
        /// </summary>
        /// <param name="currentOffset">Numărul premisei care se iterează momentan</param>
        /// <param name="maxDecision">Deviația maximă a unei concluzii de la Acceptare Puternică obținută momentan</param>
        /// <param name="aux">Obiect intern ce va păstra o formă internă a regulilor până la finalizarea backtraking-ului. Se inițializează cu null</param>
        /// <returns>Deviația maximă a unei concluzii de la Acceptare Puternică finală</returns>
        private List<Rule> bktCombinations(int currentOffset, object aux) {
           
            bool firstCall = aux == null;
           
            if (firstCall || !(aux is Dictionary<int[], double>)) {
               
                aux = new Dictionary<int[], double>();
                this.minDecision = 0;
                this.maxDecision = 0;
            }

            if (currentOffset >= this._requirementOntologies.Count) {

                int[] newRequirements = new int[this.requirements.Length];
              
                double deviation = 0.0;

                for (int i = 0; i < this.requirements.Length; ++i) {
                    
                    newRequirements[i] = this.requirements[i];
                    deviation += this.requirementImportances[i] * Math.Abs(this._exactlyLocations[i] - this.requirements[i]);
                }

                this.minDecision = Math.Min(deviation, this.minDecision);
                this.maxDecision = Math.Max(deviation, this.maxDecision);

                ((Dictionary<int[], double>)aux).Add(newRequirements, deviation);
            } 
            else {

                for (this.requirements[currentOffset] = 0; this.requirements[currentOffset] < this._requirementOntologies[currentOffset].termsCount; ++this.requirements[currentOffset]) {
                    
                    this.bktCombinations(currentOffset + 1, aux);
                }
            }

            if (firstCall) {

                if (this.minDecision == this.maxDecision) {

                    ++this.maxDecision;
                }

                Dictionary<int[], double> dictionary = (Dictionary<int[], double>)aux;
                List<Rule> result = new List<Rule>(dictionary.Keys.Count);

                foreach (int[] premises in dictionary.Keys) {

                    result.Add(new Rule(premises, (int)Math.Round((dictionary[premises] - this.minDecision) * (ClientSettings.Default.RULE_GENERATION_NUMBER_OF_OUTCOMES - 1) / (this.maxDecision - this.minDecision))));
                }

                return result;
            } 
            else {

                return null;
            }
        }

        /// <summary>
        ///   Construiește ontologia deciziilor regulilor.
        /// </summary>
        private void constructDecisionOntology() {

            this._decisionOntology = new List<DecisionShape>();

            int outcomes = (this.numberOfOutcomes + 1) / 2;

            List<Term> auxTerms = new List<Term>();

            for (int i = 0; i < outcomes; ++i) {

                auxTerms.Insert(0, new Term(this.resourceManager.GetString(SelectionRules.outcomePrefixes[outcomes - 1][i]).Replace("*", "Reject"), 0, 0, 0, 0));
            }

            outcomes = this.numberOfOutcomes / 2;

            for (int i = 0; i < outcomes; ++i) {
               
                auxTerms.Insert(i, new Term(this.resourceManager.GetString(SelectionRules.outcomePrefixes[outcomes - 1][i]).Replace("*", "Accept"), 0, 0, 0, 0));
            }

            outcomes = auxTerms.Count;

            if (outcomes > 0) {

                double largeGap = (double)1 / (outcomes + 1);
                double smallGap = largeGap / (outcomes - 1);
                
                double location = 0;
                
                auxTerms[auxTerms.Count - 1] = new Term(auxTerms[auxTerms.Count - 1].name, 0, 0, auxTerms[auxTerms.Count - 1].right, auxTerms[auxTerms.Count - 1].end);
               
                for (int i = auxTerms.Count - 1; i > 0; --i) {

                    location += largeGap;
                    
                    auxTerms[i - 1] = new Term(auxTerms[i - 1].name, location, location + smallGap, auxTerms[i - 1].right, auxTerms[i - 1].end);
                    auxTerms[i] = new Term(auxTerms[i].name, auxTerms[i].start, auxTerms[i].left, location, location + smallGap);
                    
                    location += smallGap;
                    
                    this._decisionOntology.Insert(0, new DecisionShape(auxTerms[i], 0, 1));
                }

                auxTerms[0] = new Term(auxTerms[0].name, auxTerms[0].start, auxTerms[0].left, 1, 1);
               
                this._decisionOntology.Insert(0, new DecisionShape(auxTerms[0], 0, 1));
            }
        }

        /// <summary>
        ///   Construiește ontologia unei premise a regulilor prin adăugarea de vecini formelor cererilor.
        /// </summary>
        /// <param name="requestedShape">Forma cererii pentru care se construiește ontologia</param>
        /// <param name="domainStart">Începutul intervalului în care proprietatea poate lua valori și deci până unde se pot întinde vecinii</param>
        /// <param name="domainEnd">Sfârșitul intervalului în care proprietatea poate lua valori și deci până unde se pot întinde vecinii</param>
        /// <param name="exactlyLocation">Parametru de ieșire - indică ce termen din proprietate este cel identic cu cererea inițială</param>
        /// <returns>Ontologia premisei</returns>
        private Property constructRequirementOntology(RequestShape requestedShape, double domainStart, double domainEnd, out int exactlyLocation) {

            int numberOfNeighborsGeneratedOnEachSide = ClientSettings.Default.RULE_GENERATION_NUMBER_OF_NEIGHBOURS_ON_EACH_SIDE;
           
            numberOfNeighborsGeneratedOnEachSide = numberOfNeighborsGeneratedOnEachSide <= 1 ? 1 : numberOfNeighborsGeneratedOnEachSide >= 6 ? 6 : numberOfNeighborsGeneratedOnEachSide;
          
            List<Term> resultTerms = new List<Term>();
            
            double addLength = 0;

            if (ClientSettings.Default.RULE_GENERATION_FORCE_NEIGHBOURS) {
               
                addLength = (requestedShape.shape.start - domainStart) / numberOfNeighborsGeneratedOnEachSide;
            } 
            else {

                addLength = (requestedShape.shape.end - requestedShape.shape.start) / 4;
                
                if (double.IsInfinity(addLength) || double.IsNaN(addLength)) {

                    addLength = (requestedShape.shape.right - requestedShape.shape.left) / 2;
                    addLength = double.IsInfinity(addLength) || double.IsNaN(addLength) ? requestedShape.shape.left - requestedShape.shape.start : addLength;
                    addLength = double.IsInfinity(addLength) || double.IsNaN(addLength) ? requestedShape.shape.end - requestedShape.shape.right : addLength;
                }
            }

            double nowValue = requestedShape.shape.start - addLength;

            List<double> marginalValues = new List<double>();

            for (int i = 0; i < numberOfNeighborsGeneratedOnEachSide - 1 && ((addLength > 0 && nowValue > domainStart) || (addLength < 0 && nowValue < domainStart)); ++i) {
               
                marginalValues.Add(nowValue);

                nowValue -= addLength;
            }

            if (requestedShape.shape.left != domainStart && (!ClientSettings.Default.RULE_GENERATION_FORCE_NEIGHBOURS || addLength != 0)) {
               
                marginalValues.Add(domainStart);
            }

            Term previewsTerm = requestedShape.shape;
         
            for (int i = 0; i < marginalValues.Count; ++i) {
               
                double auxStart = 0;
                double auxLeft  = 0;
                double auxRight = 0;
                double auxEnd   = 0;

                auxEnd   = previewsTerm.left;
                auxRight = previewsTerm.start;
                auxStart = marginalValues[i];
                auxLeft  = auxStart + (auxEnd - auxRight) / 2;

                if ((addLength > 0 && auxLeft < auxStart) || (addLength < 0 && auxLeft > auxStart)) {

                    auxLeft = auxStart;
                } 
                else {

                    if ((addLength > 0 && auxLeft > auxRight) || (addLength < 0 && auxLeft < auxRight)) {
                    
                        auxLeft = auxRight;
                    }
                }

                Term auxTerm = new Term(this.resourceManager.GetString(prefixes[marginalValues.Count - 1][i]).Replace("*", "Left"), auxStart, auxLeft, auxRight, auxEnd);
               
                resultTerms.Insert(0, auxTerm);

                previewsTerm = auxTerm;
            }

            if (resultTerms.Count > 0) {

                Term auxTerm = resultTerms[0];
                
                resultTerms[0] = new Term(auxTerm.name, auxTerm.start, auxTerm.start, auxTerm.right, auxTerm.end);
            }

            exactlyLocation = resultTerms.Count;
            resultTerms.Add(new Term("Exactly", requestedShape.shape.start, requestedShape.shape.left, requestedShape.shape.right, requestedShape.shape.end));

            if (ClientSettings.Default.RULE_GENERATION_FORCE_NEIGHBOURS) {
               
                addLength = (domainEnd - requestedShape.shape.end) / numberOfNeighborsGeneratedOnEachSide;
            }

            nowValue = requestedShape.shape.end + addLength;
            marginalValues = new List<double>();
          
            for (int i = 0; i < numberOfNeighborsGeneratedOnEachSide - 1 && ((addLength > 0 && nowValue < domainEnd) || (addLength < 0 && nowValue > domainEnd)); ++i) {
               
                marginalValues.Add(nowValue);
                nowValue += addLength;
            }

            if (requestedShape.shape.right != domainEnd && (!ClientSettings.Default.RULE_GENERATION_FORCE_NEIGHBOURS || addLength != 0)) {
               
                marginalValues.Add(domainEnd);
            }

            previewsTerm = requestedShape.shape;
           
            for (int i = 0; i < marginalValues.Count; ++i) {
                
                double auxStart = 0;
                double auxLeft = 0;
                double auxRight = 0;
                double auxEnd = 0;

                auxStart = previewsTerm.right;
                auxLeft  = previewsTerm.end;
                auxEnd   = marginalValues[i];
                auxRight = auxEnd - (auxLeft - auxStart) / 2;

                if ((addLength > 0 && auxRight > auxEnd) || (addLength < 0 && auxRight < auxEnd)) {
                  
                    auxRight = auxEnd;
                } 
                else {
                    
                    if ((addLength > 0 && auxRight < auxLeft) || (addLength < 0 && auxRight > auxLeft)) {
                    
                        auxRight = auxLeft;
                    }
                }

                Term auxTerm = new Term(this.resourceManager.GetString(prefixes[marginalValues.Count - 1][i]).Replace("*", "Right"), auxStart, auxLeft, auxRight, auxEnd);
               
                resultTerms.Add(auxTerm);
              
                previewsTerm = auxTerm;
            }

            if (resultTerms.Count > 0) {

                Term auxTerm = resultTerms[resultTerms.Count - 1];
               
                resultTerms[resultTerms.Count - 1] = new Term(auxTerm.name, auxTerm.start, auxTerm.left, auxTerm.end, auxTerm.end);
            }

            return new Property(requestedShape.shape.name, domainStart, domainEnd, resultTerms);
        }
    }
}