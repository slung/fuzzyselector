using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Microsoft.Uddi;
using Microsoft.Uddi.Businesses;
using Microsoft.Uddi.Services;
using Microsoft.Uddi.TModels;

namespace UDDIConnector {

    /// <summary>
    ///   Structura reprezetand informatiile corespunzatoarei unei ontologii.Imutabilă.
    /// </summary>
    public struct OntInfo {

        /// <summary>
        ///   Owner-ul/Cine a publicat ontologia pe serverul UDDI.
        /// </summary>
        public readonly string owner;

        /// <summary>
        ///   Cheia tModel-ului folosit pentru stocarea ontologiei pe serverul UDDI.
        /// </summary>
        public readonly string tModelKey;
       
        /// <summary>
        ///   Numele ontologiei.
        /// </summary>
        public readonly string ontologyName;

        /// <summary>
        ///   URL-ul unde se gaseste documentul XML ce descrie ontologia.
        /// </summary>
        public readonly string ontologyURL;

        public OntInfo(string owner, string tModelKey, string ontologyName, string ontologyURL) {

            this.owner        = owner;
            this.tModelKey    = tModelKey;
            this.ontologyName = ontologyName;
            this.ontologyURL  = ontologyURL;
        }
    }

    /// <summary>
    ///   Clasa ce cuprinde activitatea de cautare de ontolgii pe serverul UDDI.
    /// </summary>
    public class SearchOntology {

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;

        /// <summary>
        ///   Numele ontologiei cautate.
        /// </summary>
        private string ontologyName;

        /// <summary>
        ///   Optiunea de a face o cautare de tip caseSensitive.
        /// </summary>
        private Boolean caseSensitive;

        /// <summary>
        ///   Optiunea de a face o cautare de tip exactMatch.
        /// </summary>
        private Boolean exactMatch;

        public SearchOntology(UddiConnection uddiConnection, String ontologyName, Boolean caseSensitive, Boolean exactMatch) {

            this.uddiConnection = uddiConnection;
         
            this.ontologyName   = ontologyName;
            this.caseSensitive  = caseSensitive;
            this.exactMatch     = exactMatch;
        }

        public SearchOntology(UddiConnection uddiConnection) {

            this.uddiConnection = uddiConnection;
            
            this.ontologyName   = "%";
            this.caseSensitive  = false;
            this.exactMatch     = false;
        }
        /// <summary>
        ///   Cauta ontologii pe baza informatiilor specificate.
        /// </summary>
        /// <returns>Lista cu informatii despre ontologiile (tModel-uri) care respecta criteriile specificate</returns>
        public List<OntInfo> search() {

            FindTModel findTModel = new FindTModel(ontologyName);

            // uuid:a035a07c-f362-44dd-8f95-e2b134bf43b4  == uddi-org:general_keywords key
            KeyedReference categoryOntology = new KeyedReference("uuid:a035a07c-f362-44dd-8f95-e2b134bf43b4", "ontology", "QoS");
            
            findTModel.CategoryBag.Add(categoryOntology);

            if (exactMatch) {

                findTModel.FindQualifiers.Add(FindQualifier.ExactNameMatch);
            }

            if (caseSensitive) {

                findTModel.FindQualifiers.Add(FindQualifier.CaseSensitiveMatch);
            }

            TModelList tModelList = findTModel.Send(uddiConnection);

            if (0 == tModelList.TModelInfos.Count) {

                return null;
            }

            List<OntInfo> list = new List<OntInfo>();

            OntInfo ontInfo;

            foreach (TModelInfo tModelInfo in tModelList.TModelInfos) {

                GetTModelDetail getTModelDetail = new GetTModelDetail(tModelInfo.TModelKey);
                
                TModelDetail tModelDetail       = getTModelDetail.Send(uddiConnection);

                TModel  tModel = tModelDetail.TModels[0];
              
                ontInfo = new OntInfo(tModel.AuthorizedName, tModel.TModelKey, tModel.Name.Text, tModel.OverviewDoc.OverviewUrl); 
              
                list.Add(ontInfo);
            }
           
            return list;
        }
    }
}
