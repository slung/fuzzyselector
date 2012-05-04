using System;
using System.Resources;

using FuzzySelector.Common.Ontology;

namespace FuzzySelector.SmartSpammer.InferenceMachine.RuleGeneration {
   
    /// <summary>
    ///   Clasă ce abstractizează o decizie în inferența cu reguli.
    /// </summary>
    public class DecisionShape {
      
        /// <summary>
        ///   Forma fuzzy a deciziei.
        /// </summary>
        public readonly Term shape;

        /// <summary>
        ///   Centrul de greutate al formei fuzzy a deciziei
        /// </summary>
        public readonly double centerOfGravity; 
        
        private double _activationLevel;
        private int _activationCount;

        /// <summary>
        ///   Nivelul de activare al deciziei.
        /// </summary>
        public double activationLevel { 
            
            get { 
                
                return this._activationLevel; 
            } 
            
            set { 
                
                this._activationLevel = value; 
            }
        }

        /// <summary>
        ///   Numărul de activări ale deciziei.
        /// </summary>
        public int activationCount { 
            
            get { 
                
                return this._activationCount; 
            }
        }

        /// <param name="term">Forma fuzzy a deciziei</param>
        /// <param name="scaleStart">Începutul scării de scalare a formei</param>
        /// <param name="scaleEnd">Sfârșitul scării de scalare a formei</param>
        public DecisionShape(Term term, double scaleStart, double scaleEnd) {
          
            double aux;
           
            if (scaleStart > scaleEnd) {
              
                aux = scaleStart;
                scaleStart = scaleEnd;
                scaleEnd = aux;
            }

            aux = scaleEnd > scaleStart ? scaleEnd - scaleStart : 1;
           
            this.shape = new Term(term.name, (term.start - scaleStart) / aux, (term.left - scaleStart) / aux, (term.right - scaleStart) / aux, (term.end - scaleStart) / aux);
          
            this._activationLevel = 0;
            this._activationCount = 0;
           
            this.centerOfGravity  = this.centerOfMass();
        }

        /// <summary>
        ///   Crește numărul de activări al deciziei.
        /// </summary>
        public void incrementActivationCount() {

            ++this._activationCount;
        }

        /// <summary>
        ///   Calculează centrul de greutate al deciziei.
        /// </summary>
        /// <returns>Centrul de greutate al trapezului formei deciziei</returns>
        private double centerOfMass() {

            // calculăm ariile componentelor trapezului
            double triangle1Surface = Math.Abs(this.shape.left  - this.shape.start) / 2;
            double squareSurface    = Math.Abs(this.shape.right - this.shape.left);
            double triangle2Surface = Math.Abs(this.shape.end   - this.shape.right) / 2;
            
            double total = triangle1Surface + squareSurface + triangle2Surface;
           
            if (total == 0) { // atunci toate punctele formei au aceeași abscisă

                return this.shape.left;
            } 
            else {

                return ((this.shape.start + this.shape.left + this.shape.left) / 3 * triangle1Surface + (this.shape.left + this.shape.right) / 2 * squareSurface + (this.shape.right + this.shape.right + this.shape.end) / 3 * triangle2Surface) / total;
            }
        }

        public override string ToString() {

            return this.shape.name + " " + "activated" + " " + this.activationCount + " time(s)";
        }

        /// <summary>
        ///   Constructor privat folosit pentru operații de clonare.
        /// </summary>
        private DecisionShape(Term shape, double activationLevel, int activationCount) {

            this.shape = shape.clone();

            this._activationLevel = activationLevel;
            this._activationCount = activationCount;

            this.centerOfGravity  = this.centerOfMass();
        }

        /// <summary>
        ///   Returnează un obiect DecisionShape cu aceleași proprietăți ca și cel curent.
        /// </summary>
        /// <returns>O clonă a obiectului curent</returns>
        public DecisionShape clone() {

            return new DecisionShape(this.shape, this.activationLevel, this.activationCount);
        }
    }
}
