using System.Xml;
using System;

namespace FuzzySelector.Common.XML {

    /// <summary>
    ///   Parser general de fişiere XML
    /// </summary>
    public static class XMLParser {

        /// <summary>
        ///   Parser recursiv de elemente XML.
        /// </summary>
        /// <param name="reader">Cititorul secvenţial care a deschis fişierul XML</param>
        /// <returns>Elementul XML parsat care conţine toate atributele şi subelementele sale</returns>
        private static XMLElement readCurrentElement(XmlTextReader reader) {

            if (!reader.IsStartElement()) {

                return null;
            }

            bool hasChildren = !reader.IsEmptyElement;
            
            XMLElement result = new XMLElement();

            for (int i = 0; i < reader.AttributeCount; ++i) {

                reader.MoveToAttribute(i);
                result.addAttribute(reader.Name, reader.Value);
            }

            if (hasChildren) {

                while (reader.Read() && reader.NodeType != XmlNodeType.EndElement) {

                    if (reader.IsStartElement()) {

                        result.addElement(reader.Name, readCurrentElement(reader));
                    }
                }
            }

            reader.Read();

            return result;
        }

        /// <summary>
        ///   Parsează un fişier XML.
        /// </summary>
        /// <param name="parh">Calea către fişierul XML</param>
        /// <returns>Elementul XML rădăcină parsat care conţine toate atributele şi subelementele sale</returns>
        public static XMLElement parse(string path) {

            try {
                
                XmlTextReader reader = new XmlTextReader(path);
                
                while (reader.Read() && !reader.IsStartElement());
                
                return readCurrentElement(reader);
            } 
            catch (Exception) {

                return null;
            }
        }
    }
}