namespace UddiConnector.Ontology
{

    /// <summary>
    ///   Clasă ce abstractizează un termen fuzzy. Imutabilă.
    /// </summary>
    public sealed class Term
    {

        /// <summary>
        ///   Numele termenului.
        /// </summary>
        public readonly string name;

        // Cele 4 coordonatel ale unui termen.
        public readonly double start;       //  1      left---right
        public readonly double left;        //  |      /         \
        public readonly double right;       //  |     /           \
        public readonly double end;         //  0--start----------end------  

        /// <summary>
        ///   Indică dacă un camp start, left, right sau end nu a putut fi parsat din string în double.
        /// </summary>
        public readonly bool failedAParse = false;

        public Term(string name, string start, string left, string right, string end)
        {

            this.name = name;

            this.failedAParse |= !double.TryParse(start, out this.start);
            this.failedAParse |= !double.TryParse(left, out this.left);
            this.failedAParse |= !double.TryParse(right, out this.right);
            this.failedAParse |= !double.TryParse(end, out this.end);
        }

        public Term(string name, double start, double left, double right, double end)
        {

            this.name = name;

            this.start = start;
            this.left = left;
            this.right = right;
            this.end = end;
        }

        /// <summary>
        ///   Returnează un termen pornind de la cel actual, dar care respectă limitele de domeniu impuse de o anumită proprietate.
        /// </summary>
        /// <param name="property">Proprietatea a cărui domeniu trebuie respectat.</param>
        /// <returns>Termenul nou ce respectă limitele.</returns>
        public Term getCompliant(FunctionalityProperty property)
        {

            if (property == null || double.IsNaN(property.start) || double.IsNaN(property.end) || double.IsNaN(this.start) || double.IsNaN(this.left) || double.IsNaN(this.right) || double.IsNaN(this.end))
            {

                return null;
            }

            double start, left, right, end;

            if (property.start > property.end)
            {

                start = this.start > property.start ? property.start : this.start;
                left = this.left > start ? start : this.left;
                right = this.right > left ? left : this.right;
                end = this.end > right ? right : this.end;

                end = end < property.end ? property.end : end;
                right = right < end ? end : right;
                left = left < right ? right : left;
                start = start < left ? left : start;
            }
            else
            {

                start = this.start < property.start ? property.start : this.start;
                left = this.left < start ? start : this.left;
                right = this.right < left ? left : this.right;
                end = this.end < right ? right : this.end;

                end = end > property.end ? property.end : end;
                right = right > end ? end : right;
                left = left > right ? right : left;
                start = start > left ? left : start;
            }

            return new Term(this.name, start, left, right, end);
        }

        /// <summary>
        ///   Returnează o copie identică a obiectului actual.
        /// </summary>
        /// <returns>Un termen identic cu cel actual</returns>
        public Term clone()
        {

            return new Term(this.name, this.start, this.left, this.right, this.end);
        }

        public override bool Equals(object obj)
        {

            if (obj is Term)
            {

                Term term = (Term)obj;

                return term.name == this.name && term.start == this.start && term.left == this.left && term.right == this.right && term.end == this.end;
            }
            else
            {

                return false;
            }
        }

        public override int GetHashCode()
        {

            return base.GetHashCode();
        }

        public override string ToString()
        {

            return this.name + " [" + this.start + ", " + this.left + ", " + this.right + ", " + this.end + "]";
        }
    }
}
