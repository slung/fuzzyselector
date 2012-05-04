using System.Collections.Generic;

namespace UddiConnector.Ontology
{

    /// <summary>
    ///   Clasă ce abstractizează o funcţionalitate. Imutabilă.
    /// </summary>
    public sealed class OntologyProperties
    {

        private List<OntologyProperty> _properties;

        /// <summary>
        ///   Proprietăţile funcţionalităţii.
        /// </summary>
        public OntologyProperty[] properties
        {
            get
            {
                return this._properties == null ? null : this._properties.ToArray();
            }
        }

        /// <summary>
        ///   Numărul de proprietăţi ale funcţionalităţii.
        /// </summary>
        public int propertiesCount
        {
            get
            {
                return this._properties == null ? -1 : this._properties.Count;
            }
        }

        public OntologyProperties()
        {
            this._properties = new List<OntologyProperty>();
        }

        public OntologyProperties(List<OntologyProperty> properties)
        {
            this._properties = new List<OntologyProperty>(properties);
        }

        public void AddProperty(OntologyProperty property)
        {
            this._properties.Add(property);
        }


        /// <summary>
        ///   Returnează o proprietate a funcţionalităţii după nume.
        /// </summary>
        /// <param name="propertyName">Numele proprietăţii căutate</param>
        /// <returns>Proprietatea căutatp sau null dacă nu este găsită</returns>
        public OntologyProperty getProperty(string propertyName)
        {

            foreach (OntologyProperty property in this._properties)
            {

                if (property.name == propertyName)
                {

                    return property;
                }
            }

            return null;
        }
    }
}
