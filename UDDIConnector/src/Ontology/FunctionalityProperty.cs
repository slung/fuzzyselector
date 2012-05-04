using System;
using System.Collections.Generic;

namespace UddiConnector.Ontology
{

    /// <summary>
    ///   Clasă ce abstractizează o proprietate. Imutabilă.
    /// </summary>
    public sealed class FunctionalityProperty : OntologyProperty {

        /// <summary>
        ///   Începutul domeniului de validitate a proprietăţii.
        /// </summary>
        public readonly double start;

        /// <summary>
        ///   Sfârşitul domeniului de validitate a proprietăţii.
        /// </summary>
        public readonly double end;

        private List<Term> _terms;

        /// <summary>
        ///   Termenii proprietăţii.
        /// </summary>
        public Term[] terms {

            get {

                return this._terms == null ? null : this._terms.ToArray();
            }
        }

        /// <summary>
        ///   Numărul de termeni ai proprietăţii.
        /// </summary>
        public int termsCount {

            get {

                return this._terms == null ? -1 : this._terms.Count;
            }
        }

        public FunctionalityProperty(string name, CompositionMethod compositionMethod ,double start, double end, List<Term> terms)
           : base(name, compositionMethod)
        {

            this.start = start;
            this.end = end;

            this._terms = new List<Term>(terms);
        }

        /// <summary>
        ///   Returnează un termen al proprietăţii după nume.
        /// </summary>
        /// <param name="termName">Numele termenului căutat</param>
        /// <returns>Termenul căutat sau null dacă nu este găsit</returns>
        public Term getTerm(string termName) {

            foreach (Term term in this.terms) {

                if (term.name == termName) {
                
                    return term;
                }
            }

            return null;
        }

        public override string ToString() {

            return this.name + " [" + this.start + " - " + this.end + "]";
        }
    }
}
