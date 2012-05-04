using System.Collections;
using System.Collections.Generic;

namespace FuzzySelector.Common.Ontology {

    /// <summary>
    ///   Clasă ce abstractizează un serviciu. Imutabilă.
    /// </summary>
    public sealed class Service {

        /// <summary>
        ///   Numele serviciului.
        /// </summary>
        public readonly string name;     
        
        /// <summary>
        ///   Locatia serviciului.
        /// </summary>
        public readonly string accessPoint;

        /// <summary>
        ///   Funcţionalitatea implementată de serviciu.
        /// </summary>
        public readonly Functionality functionality;

        /// <summary>
        ///   Numele funcţionalităţii implementate de serviciu.
        /// </summary>
        public readonly string functionalityName;

        /// <summary>
        ///   Valorile pentru proprietăţile funcţionalităţii.
        /// </summary>
        private Hashtable values;
        
        /// <param name="name">Numele serviciului</param>
        /// <param name="accessPoint">Locatia serviciului</param>
        /// <param name="functionality">Funcţionalitatea implementată de serviciu</param>
        private Service(string name, string accessPoint, Functionality functionality) {

            this.name = name;
            this.accessPoint = accessPoint;

            this.functionality = functionality;
            this.functionalityName = functionality.name;
            
            this.values = new Hashtable();

            foreach (Property property in this.functionality.properties) {

                this.values.Add(property, double.NaN);
            }
        }

        /// <param name="name">Numele serviciului</param>
        /// <param name="accessPoint">Locatia serviciului</param>
        /// <param name="functionalityName">Numele funcţionalităţii implementate de serviciu</param>
        /// <param name="propertyNames">Numele proprietăţilor funcţionalităţii</param>
        /// <param name="propertyValues">Valorile pentru proprietăţile funcţionalităţii</param>
        public Service(string name, string accessPoint, string functionalityName, List<string> propertyNames, List<object> propertyValues) {
           
            this.name = name;
            this.accessPoint = accessPoint;
            
            this.functionality = null;
            this.functionalityName = functionalityName;
      
            this.values = new Hashtable();

            int max = propertyNames.Count < propertyValues.Count ? propertyNames.Count : propertyValues.Count;
           
            for (int i = 0; i < max; ++i) {

                this.values.Add(propertyNames[i],propertyValues[i] is string || propertyValues[i] is double ? propertyValues[i] : double.NaN);
            }
        }

        /// <summary>
        ///   Adaugă ontologia unei funcţionalităţi pentru care momentan se cunoaşte doar numele.
        /// </summary>
        /// <param name="ontology">Ontologia care sa fie adaugată</param>
        /// <returns>Un serviciu cu ontologia adăugată</returns>
        public Service addActualOntology(Functionality ontology) {

            if (this.functionality != null) {

                return this;
            }

            Service result = new Service(this.name,this.accessPoint, ontology);
          
            foreach (Property property in ontology.properties) {

                if (this.values.ContainsKey(property.name)) {

                    if (this.values[property.name] is double) {

                        result.values[property] = this.values[property.name];
                    } 
                    else {

                        if (this.values[property.name] is string) {

                            Term term = property.getTerm(this.values[property.name] as string);

                            if (term != null) {

                                result.values[property] = term;
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///   Indică dacă valoarea pentru o proprietate este fuzzy sau crisp.
        /// </summary>
        /// <param name="property">Proprietatea pentru care se caută valoarea</param>
        /// <returns>True pentru valori fuzzy şi False pentru valori crisp</returns>
        public bool isFuzzy(Property property) {

            return this.values.ContainsKey(property) && (this.values[property] is Term);
        }

        /// <summary>
        ///   Returnează termenul fuzzy al unei proprietăţi.
        /// </summary>
        /// <param name="property">Proprietatea pentru care se caută valoarea</param>
        /// <returns>Termenul fuzzy al valorii sau null dacă valoarea este crisp sau dacă nu există proprietatea</returns>
        public Term getFuzzyValue(Property property) {

            return this.values.ContainsKey(property) ? this.values[property] as Term : null;
        }

        /// <summary>
        ///   Returnează valoarea crisp a unei proprietăţi.
        /// </summary>
        /// <param name="property">Proprietatea pentru care se caută valoarea</param>
        /// <returns>Valoarea crisp a proprietăţii sau NaN dacă valoarea este fuzzy sau dacă nu există proprietatea</returns>
        public double getCrispValue(Property property) {

            if (!this.values.ContainsKey(property)) {

                return double.NaN;
            }

            return this.values[property] is double ? (double)this.values[property] : double.NaN;
        }

        /// <summary>
        ///   Apelată pentru servicii la care nu se cunoaşte încă ontologia (functionality este null).
        /// </summary>
        /// <returns>Numele, valorile şi tipul fiecărei proprietăţi sub formă de string.</returns>
        public string[] getAllNamesAndValues() {

            List<string> result = new List<string>();

            foreach (string name in this.values.Keys) {

                if (this.values[name] is string) {

                    result.Add(name + " [fuzzy:" + (this.values[name] as string) + "]");
                } 
                else {

                    if (this.values[name] is double) {

                        result.Add(name + " [crisp:" + ((double)this.values[name]) + "]");
                    }
                }
            }

            return result.ToArray();
        }

        /// <summary>
        ///   Apelată pentru servicii la care nu se cunoaşte încă ontologia (functionality este null).
        /// </summary>
        /// <returns>Numele serviciului,acces point-ul,numele,valorile şi tipul fiecărei proprietăţi sub formă de string.</returns>
        public List<string> getAllNameAccessPointNamesAndValues() {

            List<string> result = new List<string>();
            
            result.Add(this.name);
            result.Add(this.accessPoint);

            foreach (string name in this.values.Keys) {

                if (this.values[name] is string) {
        
                    result.Add(name);
                    result.Add("fuzzy");
                    result.Add(this.values[name].ToString());
                } 
                else {

                    if (this.values[name] is double) {

                        result.Add(name);
                        result.Add("crisp");
                        result.Add(this.values[name].ToString());
                    }
                }
            }

            return result;
        }

        public override string ToString() {

            return "(" + this.functionalityName + ")" + this.name;
        }
    }
}
