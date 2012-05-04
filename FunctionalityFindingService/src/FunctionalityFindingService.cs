using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Collections;

using FuzzySelector.Common.Communication;
using FuzzySelector.Common.Ontology;
using FuzzySelector.Common.XML;

using Microsoft.Uddi;
using Microsoft.Uddi.TModels;
using Microsoft.Uddi.Services;

using FunctionalityFindingService.resx;

namespace FuzzySelector.FunctionalityFindingService {

    /// <summary>
    ///   Clasa serviciului de găsire a funcționalității. Asigură funcţionalităţi de actualizare a BD returnează entităţi din ea.
    ///   Lucrează cu mașina de inferență pentru a da răspunsuri la cereri.
    /// </summary>
    public class FunctionalityFindingService {

        /// <summary>
        ///   Manager tabele lingvistice.
        /// </summary>
        public readonly ResourceManager resourceManager = new ResourceManager("FunctionalityFindingService.resx.FunctionalityFindingServiceStrings", System.Reflection.Assembly.GetExecutingAssembly());

        /// <summary>
        ///   Lista serviciilor cunoscute.
        /// </summary>
        private Hashtable services;

        /// <summary>
        /// Vector de metode delegate 'sendAsyncRequest' pentru trimiterea de cereri catre FFS.
        /// </summary>
        private SendAsyncRequest[] threads = null;

        /// <summary>
        /// Vector care contine rezultatele apelarii metodei delegate 'sendAsyncRequest'.
        /// </summary>
        private IAsyncResult[] startThreads = null;

        private int _minLoadLevel = -1;

        /// <summary>
        /// Nivelul minim de incarcare al FFS folosit in testarea de catre SmartSpammer.
        /// </summary>
        private int minLoadLevel
        {
            get
            {
                return this._minLoadLevel;
            }

            set
            {
                _minLoadLevel = value;
            }
        }

        private Address _localFunctionalityFindingServiceAddress;

        /// <summary>
        /// Adresa proprie a FFS. Utilizata in testarea de catre SmartSpammer.
        /// </summary>
        public Address localFunctionalityFindingServiceAddress
        {
            set
            {
                this._localFunctionalityFindingServiceAddress = value;
            }
        }


        private Address _domainOntologyServiceAddress;

        /// <summary>
        ///   Adresa serviciului de ontologia domeniului.
        /// </summary>
        public Address domainOntologyServiceAddress { 

            set { 
                
                this._domainOntologyServiceAddress = value; 
            } 
        }

        private string _lastError;

        /// <summary>
        ///   Ultima eroare produsă la accesarea unui serviciu.
        /// </summary>
        public string lastError { 
            
            get { 

                return this._lastError; 
            } 
        }

        /// <summary>
        ///   Listener-ul dupa conexiuni şi cereri pe socket.
        /// </summary>
        public readonly Listener listener;

        public FunctionalityFindingService() {

            this._domainOntologyServiceAddress = new Address(FunctionalityFindingServiceSettings.Default.DOS_IP, FunctionalityFindingServiceSettings.Default.DOS_PORT);

            this._localFunctionalityFindingServiceAddress = new Address(FunctionalityFindingServiceSettings.Default.FFS_IP, FunctionalityFindingServiceSettings.Default.LISTENING_PORT);

            this.services = new Hashtable();

            this.listener = new Listener(new FunctionalityFindingServiceTransformer(this));
        }

        /// <summary>
        ///   Găseşte toate funcţionalităţile cunoscute serviciului de ontologia domeniului.
        /// </summary>
        /// <returns>Numele funcţionalităţilor sub forma unui vector</returns>
        public string[] getFunctionalityNames() {
            
            try {
                
                Message answer = new Message("getFunctionalities", null).deliverAndWaitFeedback(this._domainOntologyServiceAddress);
               
                if (answer != null) {

                    if (answer.request.Equals("receiveFunctionalities")) {

                        string[] functionalityNames = new string[answer.numberOfParameters];

                        for (int i = 0; i < functionalityNames.Length; ++i) {

                            functionalityNames[i] = answer.getParameter(i);
                        }

                        this._lastError = null;

                        return functionalityNames;
                    } 
                    else if (answer.request.Equals("ERROR") && answer.numberOfParameters > 0) {

                        this._lastError = string.Join("\n", answer.parameters);

                        return null;
                    }
                }

                this._lastError = resourceManager.GetString("ERROR_NO_RESPONSE");

                return null;

            } 
            catch (Exception e) {

                this._lastError = e.Message;

                return null;
            }
        }

        /// <summary>
        ///   Returnează toate proprietățile unui serviciu într-o formă afișabilă.
        /// </summary>
        /// <param name="service">Serviciul a cărui proprietăți se caută</param>
        /// <returns>Proprietățile, fiecare sub formă de string lizibil</returns>
        public string[] getPrintableProperties(Service service) {

            try {

                if (service.functionality != null) {

                    Property[] properties = service.functionality.properties;

                    string[] result = new string[properties.Length];

                    for (int i = 0; i < result.Length; ++i) {

                        result[i] = properties[i].name + " [" + (service.isFuzzy(properties[i]) ? "fuzzy:" + service.getFuzzyValue(properties[i]).name : "crisp:" + service.getCrispValue(properties[i])) + "]";
                    }

                    return result;

                } 
                else {

                    return service.getAllNamesAndValues();
                }
            } 
            catch (Exception) {

                return new string[0];
            }
        }

        /// <summary>
        ///   Returnează toate serviciile cunoscute care au o anumită funcționalitate.
        /// </summary>
        /// <param name="filter">Funcționalitatea pe care trebuie să o aibă serviciile sau string-ul lingvistic ALL pentru toate</param>
        /// <returns>Serviciile care se încadrează</returns>
        public Service[] getServices(string functionalityName) {

            List<Service> result = new List<Service>();; 

            if (functionalityName != "All") {
                
               if(services.ContainsKey(functionalityName)) {
           
                    result = (List<Service>)services[functionalityName];
               }
            }
            else {
                
                foreach (List<Service> list in services.Values) {

                    foreach (Service service in list) {

                        result.Add(service);
                    }                   
                }
            }

            return result.ToArray();
        }

        /// <summary>
        ///   Interoghează serviciul de ontologia domeniului pentru a găsi ontologia unei anumite funcţionalităţi.
        /// </summary>
        /// <param name="functionalityName">Numele funcţionalitășii pentru care se caută o ontologie</param>
        /// <returns>Ontologia funcţionalităţii</returns>
        private Functionality getOntology(string functionalityName) {
           
            try {

                Message answer = new Message("getOntology", new string[1] { functionalityName }).deliverAndWaitFeedback(this._domainOntologyServiceAddress);
               
                if (answer != null) {

                    if (answer.request.Equals("receiveOntology")) {

                        this._lastError = null;

                        return new Functionality(functionalityName, answer.parameters);
                    } 
                    else {

                        if (answer.request.Equals("ERROR") && answer.numberOfParameters > 0) {

                            this._lastError = this.resourceManager.GetString("ERROR_DOS_ERROR") + "\n" + string.Join("\n", answer.parameters);
                            
                            return null;
                        } 
                   }
                }

                this._lastError = this.resourceManager.GetString("ERROR_DOS_NO_RESPONSE");

                return null;

            } 
            catch (Exception e) {

                this._lastError = this.resourceManager.GetString("ERROR_DOS_ERROR") + "\n" + e.Message;

                return null;
            }
        }

        /// <summary>
        /// Metoda de tip 'delegate' (delegat) pentru trimiterea de cereri FFS-ului (sie insusi) pentru ducerea 
        /// incarcarii FFS-ului la 'minLoadLevel' in cadrul testarii
        /// </summary>
        /// <param name="functionalityName">Numele functionalitatii din cadrul cererii catre FFS</param>
        /// <param name="requestShapes">Detaliile cererii</param>
        private delegate void SendAsyncRequest(string functionalityName, RequestShape[] requestShapes);

        private void sendAsyncRequest(string functionalityName, RequestShape[] requestShapes)
        {


            List<string> messParams = new List<string>();

            messParams.Add(functionalityName);

            foreach (RequestShape requestShape in requestShapes)
            {

                if (requestShape != null)
                {

                    messParams.Add(requestShape.serialize());
                }
            }

            try
            {

                string[] parameters = messParams.ToArray();

                Message answer = new Message("findServices", parameters).deliverAndWaitFeedback(this._localFunctionalityFindingServiceAddress);

            }
            catch (Exception e)
            {

                this._lastError = e.Message;

            }

        }

        /// <summary>
        /// Asteapta terminarea rezolvarii cererilor anterioare inainte de a duce nivelul de incarcare a FFS-ului
        /// la noul nivelul indicat de 'minLoadLevel'
        /// </summary>
        private void killPreviousThreads()
        {
            if (this.threads != null && this.startThreads != null)
            {
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i].EndInvoke(startThreads[i]);
                }
            }
        }

        /// <summary>
        /// Metoda apelata in cadrul testarii realizate prin intermediul SmartSpammer pentru a seta nivelul de
        /// incarcare al FFS-ului inainte de trimiterea cererilor de tip client a caror timp de rezolvare este
        /// masurat
        /// </summary>
        /// <param name="minLoadLevel">Nivelul minim de incarcare al FFS</param>
        /// <param name="functionalityName">Numele functionalitatii din cadrul cererii de tip client</param>
        /// <param name="requestShapes">Detaliile cererii</param>
        /// <returns>'True' dupa atingerea nivelului de incarcare de catre FFS</returns>
        public string setServerLoadLevel(int minLoadLevel, string functionalityName, RequestShape[] requestShapes)
        {

            killPreviousThreads();

            this._minLoadLevel = minLoadLevel;

            threads = new SendAsyncRequest[minLoadLevel];
            startThreads = new IAsyncResult[minLoadLevel];

            for (int i = 0; i < _minLoadLevel; i++)
            {
                threads[i] = sendAsyncRequest;
            }

            for (int i = 0; i < _minLoadLevel; i++)
            {
                startThreads[i] = threads[i].BeginInvoke(functionalityName, requestShapes, null, null);
            }

            return "true";

        }

        /// <summary>
        ///   Găseşte toate funcţionalităţile cunoscute serviciului de ontologia domeniului.
        /// </summary>
        /// <returns>Numele funcţionalităţilor sub forma unui vector</returns>
        public string[] getFunctionalitiesData()
        {

            try
            {

                Message answer = new Message("getFunctionalities", null).deliverAndWaitFeedback(this._domainOntologyServiceAddress);

                if (answer != null)
                {

                    if (answer.request.Equals("noFunctionalities"))
                    {

                        this._lastError = "There are no functionalities.";

                        return null;
                    }
                    else
                    {

                        if (answer.request.Equals("receiveFunctionalities"))
                        {

                            this._lastError = null;

                            string[] functionalitesData = new string[answer.numberOfParameters];

                            for (int i = 0; i < functionalitesData.Length; ++i)
                            {

                                functionalitesData[i] = answer.getParameter(i);
                            }

                            return functionalitesData;
                        }
                        else
                        {

                            if (answer.request.Equals("ERROR") && answer.numberOfParameters > 0)
                            {

                                this._lastError = string.Join("\n", answer.parameters);

                                return null;
                            }
                        }
                    }
                }

                this._lastError = "The Domain Ontology Service didn't respond.Please check that it is running and that you have the correct address and port set.";

                return null;

            }
            catch (Exception e)
            {

                this._lastError = e.Message;

                return null;
            }
        }

        /// <summary>
        ///   Găsește serviciile cu funcționalitatea cerută.
        ///   Returnează în câte un string răspunsul mașinii de inferență pentru fiecare serviciu.
        /// </summary>
        /// <param name="functionalityName">Numele funcționalității</param>
        /// <param name="requestShapes">Formele cererii</param>
        /// <returns>Nivelul de activare al regulilor și valoarea finală pentru fiecare serviciu in format CSV</returns>
        public string[] findServices(string functionalityName) {
           
            Functionality ontology = this.getOntology(functionalityName);
            
            if (ontology == null) {

                return null;
            }

            if(!services.ContainsKey(functionalityName)) {

                this._lastError = this.resourceManager.GetString("ERROR_NO_SERVICES_IN_DB");

                return null;
            }

            List<Service> servicesProvidingRequestedFunctionality = (List<Service>)services[functionalityName];
     
            List<string> result = new List<string>();
            
            for (int i = 0; i < servicesProvidingRequestedFunctionality.Count; ++i) {

                result.AddRange(servicesProvidingRequestedFunctionality[i].getAllNameAccessPointNamesAndValues());
            }

            return result.ToArray();
        }


        /// <summary>
        ///     Adauga un nou serviciu folosindu-se de adnotarile semantice si datele prezente in ontologie.
        /// </summary>
        /// <param name="serviceName">Numele serviciului</param> 
        /// <param name="accessPoint">Locatia serviciului</param>
        /// <param name="functionalityName">Numele functionalitatii implementate</param>
        /// <param name="ontologyPath">Calea catre documentul xml ce descrie ontologia</param>
        /// <param name="annotationPath">Calea catre documentul xml ce contine adnotarile semantice ale serviciului</param>
        public void addSpecificService(string serviceName, string accessPoint, string functionalityName, string ontologyPath, string annotationPath) {

            XMLElement ontology = XMLParser.parse(ontologyPath);
           
            if (ontology != null) {

                if (ontology.containsElements("functionality")) {

                    XMLElement functionality = ontology.getElements("functionality")[0];
                
                    if(functionality.containsElements("property")) {

                        List<string> propertyNames  = new List<string>();
                        List<object> propertyValues = new List<object>();
                        
                        List<XMLElement> properties = functionality.getElements("property");

                        foreach (XMLElement property in properties) {

                            if (property.containsAttribute("name")) {

                                string propertyName = property.getAttribute("name");

                                if (property.containsAttribute("start")) {
                                
                                    try {
                                        
                                        double propertyValue = double.Parse(property.getAttribute("start"));
                                        
                                        propertyNames.Add(propertyName);
                                        propertyValues.Add(propertyValue);
                                    }
                                    catch (FormatException) {

                                        return;
                                    }
                                }
                                else {

                                    return;
                                }
                            }
                            else {

                                return;
                            }
                        } 

                        XMLElement service = XMLParser.parse(annotationPath);
                         
                        if (service != null) {
                        
                            if (service.containsElements("property")) {
                            
                                properties = service.getElements("property");

                                foreach (XMLElement property in properties) {

                                    if (property.containsAttribute("name") && (property.containsAttribute("fuzzy") || property.containsAttribute("crisp"))) {
                                      
                                        string propertyName = property.getAttribute("name");
                                       
                                        if (property.containsAttribute("crisp")) {

                                            try {

                                                double propertyValue = double.Parse(property.getAttribute("crisp"));
                                               
                                                int index = propertyNames.IndexOf(propertyName);

                                                if (index >= 0) {

                                                    propertyValues[index] = propertyValue;
                                                }
                                                else {

                                                    return;
                                                }
                                            }
                                            catch (FormatException) {

                                                return;
                                            }
                                        }
                                        else {
                                            
                                            if (property.containsAttribute("fuzzy")) {
                                                
                                                string propertyValue = property.getAttribute("fuzzy");

                                                int index = propertyNames.IndexOf(propertyName);

                                                if (index >= 0) {

                                                    propertyValues[index] = propertyValue;
                                                }
                                                else {

                                                    return;
                                                }
                                            }
                                        } 
                                    }
                                    else {

                                        return;
                                    }
                                }
                                
                                if (services.ContainsKey(functionalityName)) {

                                    ((List<Service>)services[functionalityName]).Add(new Service(serviceName, accessPoint, functionalityName, propertyNames, propertyValues));
                                }
                                else { 

                                    List<Service> list = new List<Service>();
                                    
                                    list.Add(new Service(serviceName, accessPoint, functionalityName, propertyNames, propertyValues));
                                    
                                    services.Add(functionalityName, list);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Face un update al serviciilor retinute.
        /// </summary>
        /// <param name="UDDIAddress">Adresa serverului UDDI (inquire)</param> 
        /// <param name="functionalitiesData">Informatii esentiale despre toate functionalitatile existente, pe baza carora se face cautarea de servicii.</param>
        public void updateServices(string UDDIAddress, string[] functionalitiesData)
        {

            if (functionalitiesData != null)
            {

                try
                {

                    this.services = new Hashtable();

                    UddiConnection uddiConnection = new UddiConnection(UDDIAddress);

                    FindService findService = new FindService("%");

                    ServiceList serviceList = findService.Send(uddiConnection);

                    foreach (ServiceInfo serviceInfo in serviceList.ServiceInfos)
                    {

                        GetServiceDetail getServiceDetail = new GetServiceDetail(serviceInfo.ServiceKey);

                        ServiceDetail serviceDetail = getServiceDetail.Send(uddiConnection);

                        foreach (BindingTemplate bindingTemplate in serviceDetail.BusinessServices[0].BindingTemplates)
                        {

                            Boolean stop = false;

                            for (int k = 0; k < functionalitiesData.Length && !stop; k = k + 3)
                            {

                                for (int j = 0; j < bindingTemplate.TModelInstanceInfos.Count && !stop; ++j)
                                {

                                    if (bindingTemplate.TModelInstanceInfos[j].TModelKey == functionalitiesData[k])
                                    {

                                        stop = true;

                                        string functionalityName = functionalitiesData[k + 1];

                                        string accessPoint = string.Empty;

                                        if (bindingTemplate.AccessPoint.Text.ToLower().EndsWith("asmx"))
                                        {

                                            accessPoint = bindingTemplate.AccessPoint.Text + "?wsdl";
                                        }

                                        if (bindingTemplate.AccessPoint.Text.ToLower().EndsWith("wsdl"))
                                        {

                                            accessPoint = bindingTemplate.AccessPoint.Text;
                                        }

                                        if (accessPoint != string.Empty)
                                        {

                                            XMLElement root = XMLParser.parse(accessPoint);

                                            if (root != null)
                                            {

                                                if (root.containsElements("wsdl:service"))
                                                {

                                                    XMLElement service = root.getElements("wsdl:service")[0];

                                                    if (service.containsAttribute("name"))
                                                    {

                                                        string serviceName = service.getAttribute("name");

                                                        string ontologyPath = functionalitiesData[k + 2];

                                                        if (service.containsAttribute("sawsdl:modelReference"))
                                                        {

                                                            string annotationPath = service.getAttribute("sawsdl:modelReference");

                                                            //specificAnnotationSAWSDL
                                                            this.addSpecificService(serviceName, accessPoint, functionalityName, ontologyPath, annotationPath);
                                                        }
                                                        else
                                                        {

                                                            //defaultAnnotationFromOntology
                                                            this.addDefaultService(serviceName, accessPoint, functionalityName, ontologyPath);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    this._lastError = null;
                }
                catch (UddiException e)
                {

                    this._lastError = "Uddi error: " + e.Message;
                }
                catch (Exception e)
                {

                    this._lastError = "General exception:" + e.Message;
                }
            }
            else
            {

                this._lastError = "There are no functionalities. Try a functionalities update.";
            }
        }

        /// <summary>
        ///     Adauga un nou serviciu folosindu-se doar de datele prezente in ontologie.
        /// </summary>
        /// <param name="serviceName">Numele serviciului</param> 
        /// <param name="accessPoint">Locatia serviciului</param>
        /// <param name="functionalityName">Numele functionalitatii implementate</param>
        /// <param name="ontologyPath">Calea catre documentul xml ce descrie ontologia</param> 
        public void addDefaultService(string serviceName, string accessPoint, string functionalityName, string ontologyPath) {

            XMLElement ontology = XMLParser.parse(ontologyPath);
           
            if (ontology != null) {

                if (ontology.containsElements("functionality")) {

                    XMLElement functionality = ontology.getElements("functionality")[0];
                
                    if(functionality.containsElements("property")) {

                        List<string> propertyNames  = new List<string>();
                        List<object> propertyValues = new List<object>();
                        
                        List<XMLElement> properties = functionality.getElements("property");

                        foreach (XMLElement property in properties) {

                            if (property.containsAttribute("name")) {

                                string propertyName = property.getAttribute("name");

                                if (property.containsAttribute("start")) {
                                
                                    try {
                                        
                                        double propertyValue = double.Parse(property.getAttribute("start"));
                                        
                                        propertyNames.Add(propertyName);
                                        propertyValues.Add(propertyValue);
                                    }
                                    catch (FormatException) {

                                        return;
                                    }
                                }
                                else {

                                    return;
                                }
                            }
                            else {

                                return;
                            }
                        }

                        if (services.ContainsKey(functionalityName)) {

                            ((List<Service>)services[functionalityName]).Add(new Service(serviceName, accessPoint, functionalityName, propertyNames, propertyValues));
                        }
                        else {

                            List<Service> list = new List<Service>();
                            
                            list.Add(new Service(serviceName, accessPoint, functionalityName, propertyNames, propertyValues));
                            
                            services.Add(functionalityName, list);
                        }
                    }
                }
            }
        }
    }
}