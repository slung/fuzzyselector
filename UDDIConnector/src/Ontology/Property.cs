using System;
using System.Collections.Generic;

namespace UddiConnector.Ontology
{

    /// <summary>
    ///   Clasă ce abstractizează o proprietate. Imutabilă.
    /// </summary>
    public sealed class Property
    {
        public enum CompositionMethod
        {
            STATISTICAL,
            CUMULATIVE,
            AVERAGE
        };

        public readonly string name;
        public readonly CompositionMethod compositionMethod;

        /// <summary>
        ///   Începutul domeniului de validitate a proprietăţii.
        /// </summary>
        public double start;

        /// <summary>
        ///   Sfârşitul domeniului de validitate a proprietăţii.
        /// </summary>
        public double end;

        private List<Term> terms;


        public List<Term> Terms
        {
            get
            {
                return terms;
            }
        }
        /// <summary>
        ///   Termenii proprietăţii.
        /// </summary>
        //public Term[] Terms
        //{

        //    get
        //    {

        //        return this.terms == null ? null : this.terms.ToArray();
        //    }
        //}

        /// <summary>
        ///   Numărul de termeni ai proprietăţii.
        /// </summary>
        public int termsCount
        {
            get
            {

                return this.terms == null ? -1 : this.terms.Count;
            }
        }

        public Property(string name, CompositionMethod compositionMethod, List<Term> terms)
        {
            this.name = name;
            this.compositionMethod = compositionMethod;
            this.terms = new List<Term>(terms);
        }

        public Property(string name, CompositionMethod compositionMethod, double start, double end, List<Term> terms)
            : this(name, compositionMethod, terms)
        {
            this.start = start;
            this.end = end;
        }

        /// <summary>
        ///   Returnează un termen al proprietăţii după nume.
        /// </summary>
        /// <param name="termName">Numele termenului căutat</param>
        /// <returns>Termenul căutat sau null dacă nu este găsit</returns>
        public Term getTerm(string termName)
        {

            foreach (Term term in this.Terms)
            {

                if (term.name == termName)
                {

                    return term;
                }
            }

            return null;
        }

        public static CompositionMethod GetCompositionMethodFromString(string compositionMethodString)
        {
            switch (compositionMethodString.ToLowerInvariant())
            {
                case "statistical":
                    {
                        return CompositionMethod.STATISTICAL;
                    }
                case "cumulative":
                    {
                        return CompositionMethod.CUMULATIVE;
                    }
                case "average":
                    {
                        return CompositionMethod.AVERAGE;
                    }
                default:
                    {
                        return CompositionMethod.CUMULATIVE;
                    }
            }
        }

        public override string ToString()
        {
            if (this.start != 0 && this.end != 0)
                return this.name + " [" + this.start + " - " + this.end + "]";
            else
                return this.name;        
        }
    }
}
