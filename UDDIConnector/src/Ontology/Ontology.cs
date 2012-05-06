using System.Collections.Generic;
using System.Xml;

namespace UddiConnector.Ontology
{

    /// <summary>
    ///   Clasă ce abstractizează o funcţionalitate. Imutabilă.
    /// </summary>
    public sealed class Ontology
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

        private Properties _properties;

        /// <summary>
        ///   Proprietăţile funcţionalităţii.
        /// </summary>
        public Property[] properties
        {

            get
            {

                return this._properties == null ? null : this._properties.properties;
            }
        }

        /// <summary>
        ///   Numărul de proprietăţi ale funcţionalităţii.
        /// </summary>
        public int propertiesCount
        {

            get
            {

                return this._properties == null ? -1 : this._properties.propertiesCount;
            }
        }

        /// <param name="name">Numele funcţionalităţii</param>
        public Ontology(string name)
        {

            this.name = name;
            this.key = null;
            this.url = null;

            this._properties = null;
        }


        /// <param name="name">Numele funcţionalităţii</param>
        /// <param name="properties">Proprietăţile funcţionalităţii</param>
        public Ontology(string name, Properties properties) : this(name)
        {
            this.key = null;
            this.url = null;

            this._properties = properties;
        }

        /// <param name="name">Numele funcţionalităţii</param>
        /// <param name="key">Cheia funcţionalităţii pe serverul UDDI.</param>
        /// <param name="url">URL-ul fisierului XML al funcţionalităţii.</param>
        /// <param name="properties">Proprietăţile funcţionalităţii</param>
        public Ontology(string name, string key, string url, Properties properties) : this(name, properties)
        {
            this.key = key;
            this.url = url;
        }

        /// <param name="name">Numele funcţionalităţii</param>
        /// <param name="serializedProperties">Proprietăţile funcţionalităţii sub formă serializată</param>
        //public Ontology(string name, string[] serializedProperties)
        //{

        //    this.name = name;
        //    this.key = null;
        //    this.url = null;

        //    this._properties = new Properties();

        //    if (serializedProperties != null)
        //    {

        //        for (int i = 0; i < serializedProperties.Length; ++i)
        //        {

        //            if (serializedProperties[i].Length > 0)
        //            {

        //                this._properties.AddProperty(new Property(  (serializedProperties[i]);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        ///   Returnează o proprietate a funcţionalităţii după nume.
        /// </summary>
        /// <param name="propertyName">Numele proprietăţii căutate</param>
        /// <returns>Proprietatea căutatp sau null dacă nu este găsită</returns>
        public Property getProperty(string propertyName)
        {

            return this._properties.GetProperty(propertyName);
        }

        /// <summary>
        /// Writes Ontology to XML
        /// </summary>
        public void WriteToXML(string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            string ontologyFilePath = path + this.name + ".xml";

            using (XmlWriter writer = XmlWriter.Create(ontologyFilePath))
            {
                writer.WriteStartDocument();

                #region Ontology

                writer.WriteStartElement("ontology");

                #region Functionality

                writer.WriteStartElement("functionality");
                writer.WriteAttributeString("name", this.name);

                //Write all properties
                foreach (Property property in _properties.properties)
                {
                    #region Property

                    writer.WriteStartElement("property");

                    writer.WriteAttributeString("name", property.name);
                    writer.WriteAttributeString("start", property.start.ToString());
                    writer.WriteAttributeString("end", property.end.ToString());

                    foreach (Term term in property.Terms)
                    {
                        #region Term

                        writer.WriteStartElement("term");

                        writer.WriteAttributeString("name", term.name);
                        writer.WriteAttributeString("start", term.start.ToString());
                        writer.WriteAttributeString("left", term.left.ToString());
                        writer.WriteAttributeString("right", term.right.ToString());
                        writer.WriteAttributeString("end", term.end.ToString());

                        //Term End
                        writer.WriteEndElement();

                        #endregion
                    }

                    //Property End
                    writer.WriteEndElement();

                    #endregion
                }

                //Functionality End
                writer.WriteEndElement();

                #endregion

                //Ontology End
                writer.WriteEndElement();
                #endregion

                writer.WriteEndDocument();
            }
        }

        public override string ToString()
        {

            return this.name;
        }
    }
}
