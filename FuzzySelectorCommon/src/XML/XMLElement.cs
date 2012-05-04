using System.Collections.Generic;

namespace FuzzySelector.Common.XML {

    /// <summary>
    ///   Clasă ce abstractizează un element XML.
    /// </summary>
    public class XMLElement {

        /// <summary>
        ///   Dicţionar cu atributele elementului în format nume, valoare.
        /// </summary>
        private Dictionary<string, string> attributes = new Dictionary<string, string>();

        /// <summary>
        ///   Dicţionar cu subelementele elementului în format nume, listă de subelemente.
        /// </summary>
        private Dictionary<string, List<XMLElement>> elements = new Dictionary<string, List<XMLElement>>();

        /// <summary>
        ///   Verifică dacă elementul curent conţine subelemente cu un anumit nume.
        /// </summary>
        /// <param name="name">Numele subelelementelor căutate</param>
        public bool containsElements(string name) {

            return this.elements.ContainsKey(name);
        }
        
        /// <summary>
        ///   Returnează toate subelementele cu un anumit nume.
        /// </summary>
        /// <param name="name">Numele subelementelor</param>
        public List<XMLElement> getElements(string name) {

            return this.elements[name] as List<XMLElement>;
        }

        /// <summary>
        ///   Adaugă un nou subelement. Nu face nimic dacă există deja.
        /// </summary>
        /// <param name="name">Numele subelementului de adăugat</param>
        /// <param name="element">Elementul propriu zis</param>
        public void addElement(string name, XMLElement element) {

            List<XMLElement> list;

            if (containsElements(name)) {

                list = getElements(name);
            } 
            else {

                list = new List<XMLElement>();

                this.elements.Add(name, list);
            }

            if (!list.Contains(element)) {
                
                list.Add(element);
            }
        }

        /// <summary>
        ///   Verifică dacă elementul curent conţine un anumit atribut.
        /// </summary>
        /// <param name="name">Numele atributului căutat</param>
        public bool containsAttribute(string name) {
            
            return this.attributes.ContainsKey(name);
        }

        /// <summary>
        ///   Returnează valoarea unui atribut.
        /// </summary>
        /// <param name="name">Numele atributului</param>
        public string getAttribute(string name) {
          
            return this.attributes[name] as string;
        }
        
        /// <summary>
        ///   Adaugă un atribut nou elementului sau înlocuieşte valoarea veche dacă există deja.
        /// </summary>
        /// <param name="name">Numele atributului</param>
        /// <param name="value">Valoarea atributului</param>
        public void addAttribute(string name, string value) {
            
            if (containsAttribute(name)) {

                this.attributes[name] = value;
            } 
            else {

                this.attributes.Add(name, value);
            }
        }
    }
}