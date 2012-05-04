using System.Collections.Generic;

namespace UddiConnector.Ontology
{

    /// <summary>
    ///   Clasă ce abstractizează o funcţionalitate. Imutabilă.
    /// </summary>
    public sealed class Properties
    {

        private List<Property> _properties;

        /// <summary>
        ///   Proprietăţile funcţionalităţii.
        /// </summary>
        public Property[] properties
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

        public Properties()
        {
            this._properties = new List<Property>();
        }

        public Properties(List<Property> properties)
        {
            this._properties = new List<Property>(properties);
        }

        public void AddProperty(Property property)
        {
            this._properties.Add(property);
        }


        /// <summary>
        ///   Returnează o proprietate a funcţionalităţii după nume.
        /// </summary>
        /// <param name="propertyName">Numele proprietăţii căutate</param>
        /// <returns>Proprietatea căutatp sau null dacă nu este găsită</returns>
        public Property getProperty(string propertyName)
        {

            foreach (Property property in this._properties)
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
