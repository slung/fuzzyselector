using System;
using System.Collections.Generic;

namespace FuzzySelector.Common.Ontology {

    /// <summary>
    ///   Clasă ce abstractizează o proprietate. Imutabilă.
    /// </summary>
    public sealed class Property {

        /// <summary>
        ///   Numele proprietăţii.
        /// </summary>
        public readonly string name;

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

        /// <param name="name">Numele proprietăţii</param>
        /// <param name="start">Începutul domeniului de validitate a proprietăţii</param>
        /// <param name="end">Sfârşitul domeniului de validitate a proprietăţii</param>
        /// <param name="terms">Termenii proprietăţii</param>
        public Property(string name, double start, double end, List<Term> terms) {

            this.name = name;

            this.start = start;
            this.end = end;
            
            this._terms = new List<Term>(terms);
        }

        /// <param name="serialized">Un obiect de tip Property serializat</param>
        public Property(string serialized) {

            string[] aux = serialized.Split(new char[] { '\n' }, StringSplitOptions.None);
           
            if (aux == null) {
             
                return;
            }
           
            this.name = aux.Length > 0 ? aux[0] : null;
            
            try {

                this.start = double.Parse(aux[1]);
            }
            catch (Exception) {
                
                this.start = double.NegativeInfinity;
            }
           
            try {

                this.end = double.Parse(aux[2]);
            } 
            catch (Exception) {
                
                this.end = double.PositiveInfinity;
            }

            this._terms = new List<Term>();
           
            for (int i = 3; i < aux.Length; i += 5) {
                
                try {
                    
                    Term term = new Term(aux[i], aux[i + 1], aux[i + 2], aux[i + 3], aux[i + 4]);
                    
                    this._terms.Add(term);
                } 
                catch (Exception) {
                
                }
            }
        }

        /// <summary>
        ///   Serializează obiectul Property pentru a putea fi trimis prin socket-uri.
        /// </summary>
        /// <returns>Obiectul serializat sub formă de string</returns>
        public string serialize() {

            string result = this.name + "\n" + this.start.ToString() + "\n" + this.end.ToString();

            foreach (Term term in this._terms) {

                result += "\n" + term.name + "\n" + term.start + "\n" + term.left + "\n" + term.right + "\n" + term.end;
            }

            return result;
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
