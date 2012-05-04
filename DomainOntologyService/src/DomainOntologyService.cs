using System;

using System.Collections.Generic;
using System.Resources;
using FuzzySelector.Common.Communication;
using FuzzySelector.Common.Ontology;
using FuzzySelector.Common.XML;

using Microsoft.Uddi;
using Microsoft.Uddi.TModels;

namespace FuzzySelector.DomainOntologyService {

    /// <summary>
    ///   Clasa serviciului ontologiei domeniului. Asigură funcţionalităţi de actualizare a BD şi returnează entităţi din ea.
    /// </summary>
    public class DomainOntologyService {

        private List<Functionality> _functionalities;

        private string _lastError;

        /// <summary>
        ///   Ultima eroare produsă la accesarea unui serviciu.
        /// </summary>
        public string lastError
        {

            get
            {

                return this._lastError;
            }
        }

        /// <summary>
        ///   Toate ontologiile cunoscute.
        /// </summary>
        public Functionality[] functionalities {

            get {

                return this._functionalities.ToArray();
            }
        }

        /// <summary>
        ///   Listener-ul dupa conexiuni şi cereri pe socket.
        /// </summary>
        public readonly Listener listener; 
        
        public DomainOntologyService() {

            this._functionalities = new List<Functionality>();

            this.listener = new Listener(new DomainOntologyServiceTransformer(this));
        }

        /// <summary>
        ///   Returnează o ontologie, in mod serializat, pe baza numelui cunoscut.
        /// </summary>
        /// <param name="functionalityName">Numele ontologiei căutate</param>
        /// <returns>Ontologia căutată sub forma proprietăţilor ce o compun. Null dacă nu există ontologia</returns>
        public string[] getSerializedOntology(string functionalityName) {

            foreach (Functionality functionality in this._functionalities) {
                
                if (functionality.name == functionalityName) {

                    string[] result = new string[functionality.propertiesCount];

                    for (int i = 0; i < result.Length; ++i) {

                        result[i] = functionality.properties[i].serialize();
                    }

                    return result;
                }
            }

            return null;
        }

        /// <summary>
        ///   Returnează cheia, numele si url-ul tuturor funcţionalităţilor cunoscute.
        /// </summary>
        /// <returns>Cheia, numele si url-ul tuturor funcţionalităţilor cunoscute.</returns>
        public string[] getAllFunctionalities()
        {

            string[] result = new string[this._functionalities.Count * 3];

            for (int i = 0; i < this._functionalities.Count; ++i)
            {

                result[3 * i] = this._functionalities[i].key;
                result[3 * i + 1] = this._functionalities[i].name;
                result[3 * i + 2] = this._functionalities[i].url;
            }

            return result;
        }

        /// <summary>
        ///   Reinnoieste toate functionalitatile.
        /// </summary>
        public void updateFunctionalities(string UDDIAddress)
        {

            this._functionalities = new List<Functionality>();

            try
            {

                UddiConnection uddiConnection = new UddiConnection(UDDIAddress);

                FindTModel findTModel = new FindTModel();

                // uuid:a035a07c-f362-44dd-8f95-e2b134bf43b4  == uddi-org:general_keywords key
                KeyedReference categoryOntology = new KeyedReference("uuid:a035a07c-f362-44dd-8f95-e2b134bf43b4", "ontology", "QoS");

                findTModel.CategoryBag.Add(categoryOntology);

                TModelList tModelList = findTModel.Send(uddiConnection);

                foreach (TModelInfo tModelInfo in tModelList.TModelInfos)
                {

                    // Provide the unique tModel key.
                    GetTModelDetail getTModelDetail = new GetTModelDetail(tModelInfo.TModelKey);

                    // Send the GetTModelDetail request over the connection.
                    TModelDetail tModelDetail = getTModelDetail.Send(uddiConnection);

                    this.addFunctionalityFromXml(tModelDetail.TModels[0].TModelKey, tModelDetail.TModels[0].OverviewDoc.OverviewUrl);
                }

                this._lastError = null;
            }
            catch (UddiException e)
            {

                this._lastError = "Uddi error: " + e.Message;
            }
            catch (Exception e)
            {

                this._lastError = "General exception: " + e.Message;
            }
        }

        /// <summary>
        ///   Extrage funcţionalitatea dintr-un fişier xml şi o adaugă la cele cunoscute.
        /// </summary>
        /// <param name="key">Cheia functionalitatii pe serverul UDDI</param>
        /// <param name="url">URL-ul fiserului xml ce contine functionalitatea</param>
        public void addFunctionalityFromXml(string key, string url)
        {

            XMLElement root = XMLParser.parse(url);

            if (root != null)
            {

                if (root.containsElements("functionality"))
                {

                    XMLElement functionality = root.getElements("functionality")[0];

                    if (functionality.containsAttribute("name"))
                    {

                        string functionalityName = functionality.getAttribute("name");

                        foreach (Functionality knownFunctionality in this._functionalities)
                        {

                            if (knownFunctionality.name == functionalityName)
                            {

                                return;
                            }
                        }

                        if (functionality.containsElements("property"))
                        {

                            List<Property> functionalityProperties = new List<Property>();

                            List<XMLElement> properties = functionality.getElements("property");

                            foreach (XMLElement property in properties)
                            {

                                if (property.containsAttribute("name"))
                                {

                                    string propertyName = property.getAttribute("name");

                                    double propertyStart, propertyEnd;

                                    if (property.containsAttribute("start") && property.containsAttribute("end"))
                                    {

                                        if (double.TryParse(property.getAttribute("start"), out propertyStart) && double.TryParse(property.getAttribute("end"), out propertyEnd))
                                        {

                                            if (property.containsElements("term"))
                                            {

                                                List<Term> propertyTerms = new List<Term>();

                                                List<XMLElement> terms = property.getElements("term");

                                                foreach (XMLElement term in terms)
                                                {

                                                    if (term.containsAttribute("name") && term.containsAttribute("start") && term.containsAttribute("left") && term.containsAttribute("right") && term.containsAttribute("end"))
                                                    {

                                                        Term auxTerm = new Term(term.getAttribute("name"), term.getAttribute("start"), term.getAttribute("left"), term.getAttribute("right"), term.getAttribute("end"));

                                                        if (!auxTerm.failedAParse)
                                                        {

                                                            propertyTerms.Add(auxTerm);
                                                        }
                                                        else
                                                        {

                                                            return;
                                                        }
                                                    }
                                                    else
                                                    {

                                                        return;
                                                    }
                                                }

                                                functionalityProperties.Add(new Property(propertyName, propertyStart, propertyEnd, propertyTerms));
                                            }
                                            else
                                            {

                                                return;
                                            }
                                        }
                                        else
                                        {

                                            return;
                                        }
                                    }
                                    else
                                    {

                                        return;
                                    }
                                }
                                else
                                {

                                    return;
                                }
                            }

                            this._functionalities.Add(new Functionality(functionalityName, key, url, functionalityProperties));
                        }
                    }
                }
            }
        }

    }
}
