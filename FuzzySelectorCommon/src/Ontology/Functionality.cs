using System.Collections.Generic;

namespace FuzzySelector.Common.Ontology
{

    /// <summary>
    ///   Clasă ce abstractizează o funcţionalitate. Imutabilă.
    /// </summary>
    public sealed class Functionality
    {

        /// <summary>
        ///   Numele funcţionalităţii.
        /// </summary>
        public readonly string name;

        /// <summary>
        ///   Cheia funcţionalităţii pe serverul UDDI.
        /// </summary>
        public readonly string key;

        /// <summary>
        ///   URL-ul fisierului XML al funcţionalităţii.
        /// </summary>
        public readonly string url;

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

        /// <param name="name">Numele funcţionalităţii</param>
        public Functionality(string name)
        {

            this.name = name;
            this.key = null;
            this.url = null;

            this._properties = null;
        }


        /// <param name="name">Numele funcţionalităţii</param>
        /// <param name="properties">Proprietăţile funcţionalităţii</param>
        public Functionality(string name, List<Property> properties)
        {

            this.name = name;
            this.key = null;
            this.url = null;

            this._properties = new List<Property>(properties);
        }

        /// <param name="name">Numele funcţionalităţii</param>
        /// <param name="key">Cheia funcţionalităţii pe serverul UDDI.</param>
        /// <param name="url">URL-ul fisierului XML al funcţionalităţii.</param>
        /// <param name="properties">Proprietăţile funcţionalităţii</param>
        public Functionality(string name, string key, string url, List<Property> properties)
        {

            this.name = name;
            this.key = key;
            this.url = url;

            this._properties = new List<Property>(properties);
        }

        /// <param name="name">Numele funcţionalităţii</param>
        /// <param name="serializedProperties">Proprietăţile funcţionalităţii sub formă serializată</param>
        public Functionality(string name, string[] serializedProperties)
        {

            this.name = name;
            this.key = null;
            this.url = null;

            this._properties = new List<Property>();

            if (serializedProperties != null)
            {

                for (int i = 0; i < serializedProperties.Length; ++i)
                {

                    if (serializedProperties[i].Length > 0)
                    {

                        this._properties.Add(new Property(serializedProperties[i]));
                    }
                }
            }
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

        public override string ToString()
        {

            return this.name;
        }
    }
}
