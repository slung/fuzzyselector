using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Microsoft.Uddi;
using Microsoft.Uddi.TModels;
using Microsoft.Uddi.Businesses;
using Microsoft.Uddi.Services;

namespace UDDIConnector {

    /// <summary>
    ///   Structura reprezetand informatiile corespunzatoarei unui serviciu.Imutabilă.
    /// </summary>
    public struct WSInfo {

        /// <summary>
        ///   Owner-ul/Cine a publicat serviciul pe serverul UDDI.
        /// </summary>
        public readonly String owner;

        /// <summary>
        ///   Cheia BusinessEntity-ului folosit pentru stocarea pe serverul UDDI a domeniului de grupuri de servicii in care se gaseste serviciul.
        /// </summary>
        public readonly String businessKey;
        
        /// <summary>
        ///   Numele BusinessEntity-ului folosit pentru stocarea pe serverul UDDI a domeniului de grupuri de servicii in care se gaseste serviciul.
        /// </summary>
        public readonly String businessName;

        /// <summary>
        ///   Cheia BusinessService-ului folosit pentru stocarea pe serverul UDDI a grupului de servicii in care se gaseste serviciul.
        /// </summary>
        public readonly String serviceKey;
        
        /// <summary>
        ///   Numele BusinessService-ului folosit pentru stocarea pe serverul UDDI a grupului de servicii in care se gaseste serviciul.
        /// </summary>
        public readonly String serviceName;

        /// <summary>
        ///   Cheia BindingTemplate-ului folosit pentru stocarea serviciului pe serverul UDDI.
        /// </summary>
        public readonly String bindingKey;

        /// <summary>
        ///   Locatia terviciului.
        /// </summary>
        public readonly String accessPoint;

        /// <summary>
        ///   Numele ontologiei serviciului.
        /// </summary>
        public readonly String ontologyName;

        public WSInfo (string owner, string businessKey, string businessName, string serviceKey, string serviceName, string bindingKey, string accessPoint, string ontologyName) {

            this.owner         = owner;
            this.businessKey   = businessKey;
            this.businessName  = businessName;
            this.serviceKey    = serviceKey;
            this.serviceName   = serviceName;
            this.bindingKey    = bindingKey;
            this.accessPoint   = accessPoint;
            this.ontologyName  = ontologyName;
        }
    }

    /// <summary>
    ///   Clasa ce cuprinde activitatea de cautare de servicii pe serverul UDDI.
    /// </summary>
    public class SearchService {

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;

        /// <summary>
        ///   Numele BusinessEntity-ului cautat.
        /// </summary>
        private String businessName;
        
        /// <summary>
        ///   Numele BusinessService-ului cautat.
        /// </summary>
        private String serviceName;

        /// <summary>
        ///   Optiunea de a face o cautare de tip caseSensitive.
        /// </summary>
        private Boolean caseSensitive;

        /// <summary>
        ///   Optiunea de a face o cautare de tip exactMatch.
        /// </summary>
        private Boolean exactMatch;

        /// <summary>
        ///   Atributele esentiale ale ontolgiilor pe baza carora se face cautarea.
        /// </summary>   
        private String[] ontologyAttributes;

        public SearchService(UddiConnection uddiConnection, String businessName, String serviceName, String[] ontologyAttributes, Boolean caseSensitive, Boolean exactMatch) {

            this.uddiConnection     = uddiConnection;
            this.businessName       = businessName;
            this.serviceName        = serviceName;
            this.ontologyAttributes = ontologyAttributes;
            this.caseSensitive      = caseSensitive;
            this.exactMatch         = exactMatch;
        }

        /// <summary>
        ///   Cauta servicii pe baza informatiilor specificate.
        /// </summary>
        /// <returns>Liste cu liste de informatii despre serviciile (BindingTemplate-uri) care respecta criteriile specificate</returns>
        public List<List<WSInfo>> search() {

            if (businessName != String.Empty) {

                return findBusinesses();
            }
            else {

                List<WSInfo> list = findServices(String.Empty);

                if (list != null) {

                    List<List<WSInfo>> serviceList = new List<List<WSInfo>>();
                    
                    serviceList.Add(list);
                    
                    return serviceList;
                }
                else {

                    return null;
                }
            }
        }

        /// <summary>
        ///   Cauta servicii pe baza informatiilor specificate pornind de la BusinessEntity.
        /// </summary>
        /// <param name="businessKey">Cheia BusinessEntity-ului in care se face cautarea</param>
        private List<WSInfo> findServices(string businessKey) {

            FindService findService = new FindService(serviceName);

            if (businessKey != String.Empty) {

                findService.BusinessKey = businessKey;
            }

            if (exactMatch){

                findService.FindQualifiers.Add(FindQualifier.ExactNameMatch);
            }

            if (caseSensitive){

                findService.FindQualifiers.Add(FindQualifier.CaseSensitiveMatch);
            }
    
            ServiceList serviceList =  findService.Send(uddiConnection);
               
             if (0 == serviceList.ServiceInfos.Count) {

                return null;
             }
            
            List<WSInfo> list = new List<WSInfo>();

            exploreServices(list,serviceList);

             if (list.Count != 0) {

                return list;
            }
            else {

                return null;
            }  
        }

        /// <summary>
        ///   Cauta servicii pe baza informatiilor specificate - businessName.
        /// </summary>
        private List<List<WSInfo>> findBusinesses() {

            FindBusiness findBusiness = new FindBusiness(businessName);
 
            if (exactMatch) {

                findBusiness.FindQualifiers.Add(FindQualifier.ExactNameMatch);
            }

            if (caseSensitive) {

                findBusiness.FindQualifiers.Add(FindQualifier.CaseSensitiveMatch);
            }

            BusinessList businessList = findBusiness.Send(uddiConnection);

            if (0 == businessList.BusinessInfos.Count) {

                return null;
            }

            List<List<WSInfo>> serviceList = new List<List<WSInfo>>();
            
            foreach (BusinessInfo businessInfo in businessList.BusinessInfos) {

                List<WSInfo> list = findServices(businessInfo.BusinessKey);

                if (list != null) {
                    
                    serviceList.Add(list);
                } 
            }

            if (serviceList.Count != 0) {

                return serviceList;
            }
            else {

                return null;
            }  
        }

        /// <summary>
        ///   Cauta servicii pe baza informatiilor specificate pornind de la BusinessService.
        /// </summary>
        /// /// <param name="list">Lista cu informatii despre servicii, in care se fac adaugari</param>
        /// /// <param name="serviceList">Lista de grupuri de servicii</param>
        private void exploreServices(List<WSInfo> list, ServiceList serviceList) {

            WSInfo wsInfo;
            
            foreach (ServiceInfo serviceInfo in serviceList.ServiceInfos) {

                GetBusinessDetail getBusinessDetail = new GetBusinessDetail(serviceInfo.BusinessKey);
                BusinessDetail businessDetail       = getBusinessDetail.Send(uddiConnection);
                
                GetServiceDetail getServiceDetail = new GetServiceDetail(serviceInfo.ServiceKey);
                ServiceDetail serviceDetail       = getServiceDetail.Send(uddiConnection);

                foreach (BindingTemplate bindingTemplate in serviceDetail.BusinessServices[0].BindingTemplates) {
                 
                    if (ontologyAttributes != null  && bindingTemplate.TModelInstanceInfos.Count !=0 ) {

                        Boolean stop = false;
                        
                        for (int i=0;i < ontologyAttributes.Length && !stop; i = i+2) {

                            for(int j=0;j < bindingTemplate.TModelInstanceInfos.Count && !stop; ++j) {
                        
                                if(bindingTemplate.TModelInstanceInfos[j].TModelKey == ontologyAttributes[i]) {

                                    wsInfo = new WSInfo(businessDetail.BusinessEntities[0].AuthorizedName,
                                                         serviceInfo.BusinessKey,
                                                         businessDetail.BusinessEntities[0].Names[0].Text,
                                                         serviceInfo.ServiceKey,
                                                         serviceInfo.Names[0].Text,
                                                         bindingTemplate.BindingKey,
                                                         bindingTemplate.AccessPoint.Text,
                                                         ontologyAttributes[i + 1]);

                                    list.Add(wsInfo);

                                    stop = true;
                                }
                            }
                        }
                    }

                    if (ontologyAttributes == null) {

                        wsInfo = new WSInfo( businessDetail.BusinessEntities[0].AuthorizedName,
                                             serviceInfo.BusinessKey,
                                             businessDetail.BusinessEntities[0].Names[0].Text,
                                             serviceInfo.ServiceKey,
                                             serviceInfo.Names[0].Text,
                                             bindingTemplate.BindingKey,
                                             bindingTemplate.AccessPoint.Text,
                                             "");

                        list.Add(wsInfo);
                    }
                }
            }
        }
    }
}
