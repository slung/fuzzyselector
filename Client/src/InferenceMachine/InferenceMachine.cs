using System;

using FuzzySelector.Common.Ontology;

using Client.resx;

namespace FuzzySelector.Client.InferenceMachine {

    /// <summary>
    ///   Clasa abstractă pentru mașini de inferență.
    /// </summary>
    public abstract class InferenceMachine {

        /// <summary>
        ///   Aplică inferența pe un anumit serviciu și returnează răspunsul în format CSV.
        /// </summary>
        /// <param name="service">Serviciul pentru care se aplică inferența</param>
        /// <returns>Rezultatul inferenței în format CSV - un singur rând ce ar trebui să conțină măcar o coloană cu o valoare numerică pentru sortarea serviciilor</returns>
        public abstract string applyToServiceInCSVFormat(Service service);

        /// <summary>
        ///   Calculează importanțe pornind de la o valoare de bază și funcția și parametrii salvați în setări.
        /// </summary>
        /// <param name="baseImportance">Valoarea de bază</param>
        /// <returns>Valoarea după ce se aplică funcția din setări</returns>
        public static double calculateImportance(int baseImportance) {

            baseImportance = Math.Max(1, Math.Min(100, baseImportance));

            double a = Math.Abs(ClientSettings.Default.IMPORTANCE_A);
            double b = Math.Abs(ClientSettings.Default.IMPORTANCE_B);
            double c = ClientSettings.Default.IMPORTANCE_C;

            switch (ClientSettings.Default.IMPORTANCE_FUNCTION) {

                case (int)ImportanceParsingFunction.highPolinomial:

                    return a * Math.Pow(baseImportance, b) + c;
    
                case (int)ImportanceParsingFunction.exponential:

                    return a * Math.Exp(b * baseImportance) + c;
    
                case (int)ImportanceParsingFunction.logarithmic:

                    return a * Math.Log((b + 1) * baseImportance) + c;
                
                default:

                    return (double)baseImportance;
            }
        }

        /// <summary>
        ///   Intersecție de segmente cu condiția ca ordonatele să fie între 0 și 1.
        /// </summary>
        /// <param name="ax1">Abscisa punctului 1 a liniei A</param>
        /// <param name="ax2">Abscisa punctului 2 a liniei A</param>
        /// <param name="ay1">Ordonata punctului 1 a liniei A</param>
        /// <param name="ay2">Ordonata punctului 2 a liniei A</param>
        /// <param name="bx1">Abscisa punctului 1 a liniei B</param>
        /// <param name="bx2">Abscisa punctului 2 a liniei B</param>
        /// <param name="by1">Ordonata punctului 1 a liniei B</param>
        /// <param name="by2">Ordonata punctului 2 a liniei B</param>
        /// <returns>Ordonata intersecției</returns>
        private static double intersectLinesY(double ax1, double ax2, double ay1, double ay2, double bx1, double bx2, double by1, double by2) {
          
            double m1 = (ay2 - ay1) / (ax2 - ax1);
            double m2 = (by2 - by1) / (bx2 - bx1);

            double n1 = ay1 - m1 * ax1;
            double n2 = by1 - m2 * bx1;

            double x = 0.0, y = 0.0;

            if (ax1 == ax2 && bx1 == bx2) {  // ambele linii sunt verticale
                
                return ax1 == bx1 ? 1.0 : 0.0;
            } 
            else {
                
                if (ax1 == ax2) {  // una din linii este verticală
                    
                    x = ax1;
                    y = m2 * x + n2;
                } 
                else { 
                    
                    if (bx1 == bx2) {  // cealalta linie este verticală
                        
                        x = bx1;
                        y = m1 * x + n1;
                    } 
                    else {
                        
                        if (m1 == m2) {  // linii paralele neverticale
                            
                            y = ax1 == bx1 || ax1 == bx2 || ax2 == bx1 || ax2 == bx2 ? Math.Max(1, Math.Max(Math.Max(ay1, ay2), Math.Max(by1, by2))) : 0.0;
                        } 
                        else {   // nici o linie nu este verticală sau paralelă
                                
                            x = (n2 - n1) / (m1 - m2);
                            y = m1 * x + n1;
                        }
                    }
                }
            }
            
            if (y < 0.0 || y > 1.0) {  // intersecția este sub sau peste segment (se știe că termenii fuzzy au y între 0 și 1 deci nu mai testăm)
                
                return 0.0;
            } 
            else {
                
                if (x < Math.Min(ax1, ax2) || x > Math.Max(ax1, ax2) || x < Math.Min(bx1, bx2) || x > Math.Max(bx1, bx2)) {
                
                    return 0.0;
                } 
                else {
                
                    return y;
                }
            }
        }

        /// <summary>
        ///   Găsește valoarea intersecției unui termen fuzzy cu valoarea unei proprietăți a unui serviciu (ce poate fi fuzzy sau crisp).
        /// </summary>
        /// <param name="service">Serviciul de care aparține proprietatea</param>
        /// <param name="property">Proprietatea a cărei valoare se va folosi pentru intersecție</param>
        /// <param name="shape">Termenul care se intersectează cu valoarea proprietății</param>
        /// <returns>Valoarea intersecției celor 2 termeni</returns>
        public static double intersect(Service service, Property property, Term shape) {
           
            try {
                
                bool isLowerBetter = shape.start > shape.end || property.start > property.end;
                
                double start2 = isLowerBetter ? shape.end : shape.start;
                double left2 = isLowerBetter ? shape.right : shape.left;
                double right2 = isLowerBetter ? shape.left : shape.right;
                double end2 = isLowerBetter ? shape.start : shape.end;

                if (service.isFuzzy(property)) {

                    Term term = service.getFuzzyValue(property);

                    if (term == null) {
                        
                        return double.NaN;
                    }
                    
                    double result = intersectLinesY(term.start, term.left, 0.0, 1.0, start2, left2, 0.0, 1.0);
                    
                    result = Math.Max(result, intersectLinesY(term.left, term.right, 1.0, 1.0, start2, left2, 0.0, 1.0));
                    result = Math.Max(result, intersectLinesY(term.right, term.end, 1.0, 0.0, start2, left2, 0.0, 1.0));

                    result = Math.Max(result, intersectLinesY(term.start, term.left, 0.0, 1.0, left2, right2, 1.0, 1.0));
                    result = Math.Max(result, intersectLinesY(term.left, term.right, 1.0, 1.0, left2, right2, 1.0, 1.0));
                    result = Math.Max(result, intersectLinesY(term.right, term.end, 1.0, 0.0, left2, right2, 1.0, 1.0));

                    result = Math.Max(result, intersectLinesY(term.start, term.left, 0.0, 1.0, right2, end2, 1.0, 0.0));
                    result = Math.Max(result, intersectLinesY(term.left, term.right, 1.0, 1.0, right2, end2, 1.0, 0.0));
                    
                    return Math.Max(result, intersectLinesY(term.right, term.end, 1.0, 0.0, right2, end2, 1.0, 0.0));

                } 
                else {
                    
                    double crispValue = service.getCrispValue(property);
                   
                    if (double.IsNaN(crispValue)) {
                        
                        return double.NaN;
                    }

                    if (crispValue > start2 && crispValue < left2) {
                        
                        return (crispValue - start2) / (left2 - start2);
                    } 
                    else {
                        
                        if (crispValue >= left2 && crispValue <= right2) {
                            
                            return 1.0;
                        }
                        else {
                            
                            if (crispValue > right2 && crispValue < end2) {
                                
                                return (crispValue - end2) / (right2 - end2);
                            } 
                            else {
                                
                                return 0.0;
                            }
                        }
                    }
                }
            } 
            catch (Exception) {

                return double.NaN;
            }
        }
    }
}
