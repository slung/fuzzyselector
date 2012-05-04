using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

using FuzzySelector.Common.XML;
using FuzzySelector.Common.Communication;
using FuzzySelector.Common.Ontology;
using System.IO;
using SmartSpammer.resx;
using FuzzySelector.SmartSpammer.InferenceMachine;
using FuzzySelector.SmartSpammer.InferenceMachine.MulticriteriaDecision;
using FuzzySelector.SmartSpammer.InferenceMachine.RuleGeneration;

namespace FuzzySelector.SmartSpammer {

    /// <summary>
    ///   Clasa SmartSpammer. Asigură toate funcţionalităţile necesare obţinerii ontologiilor, şi a duratelor de timp necesare pentru raspunsul la unele cereri de servicii.
    /// </summary>
    public class SmartSpammer {

        /// <summary>
        ///   Manager tabele lingvistice.
        /// </summary>
        public readonly ResourceManager resourceManager = new ResourceManager("SmartSpammer.resx.SmartSpammerStrings", System.Reflection.Assembly.GetExecutingAssembly());

        private string _lastError;

        /// <summary>
        ///   Ultima eroare produsă la accesarea unui serviciu.
        /// </summary>
        public string lastError { 
            
            get {
                
                return this._lastError; 
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

        private Address _functionalityFindingServiceAddress;

        /// <summary>
        ///   Adresa serviciului de găsire a funcţionalităţii.
        /// </summary>
        public Address functionalityFindingServiceAddress { 
            
            set { 
                
                this._functionalityFindingServiceAddress = value; 
            } 
        }

        /// <param name="domainOntologyServiceAddress">Adresa serviciului de ontologia domeniului</param>
        /// <param name="functionalityFindingServiceAddress">Adresa serviciului de găsire a funcţionalităţii</param>
        public SmartSpammer(Address domainOntologyServiceAddress, Address functionalityFindingServiceAddress) {
            
            this._domainOntologyServiceAddress = domainOntologyServiceAddress;
            this._functionalityFindingServiceAddress = functionalityFindingServiceAddress;
        }


        /// <summary>
        ///   Găseşte toate funcţionalităţile cunoscute serviciului de ontologia domeniului.
        /// </summary>
        /// <returns>Funcţionalităţiile sub forma unui vector</returns>
        public Functionality[] getFunctionalities()
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

                            Functionality[] result = new Functionality[answer.numberOfParameters / 3];

                            for (int i = 0; i < answer.numberOfParameters; i = i + 3)
                            {

                                result[i / 3] = new Functionality(answer.getParameter(i + 1));
                            }

                            return result;
                        }
                        else
                        {

                            if (answer.request.Equals("ERROR") && answer.numberOfParameters > 0)
                            {

                                this._lastError = String.Join("\n", answer.parameters);

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
        ///   Interoghează serviciul de ontologia domeniului pentru a găsi ontologia unei anumite funcţionalităţi.
        /// </summary>
        /// <param name="functionality">Funcţionalitatea pentru care se caută o ontologie</param>
        /// <returns>Ontologia funcţionalităţii</returns>
        public Functionality getOntology(Functionality functionality) {
           
            try {
                
                Message answer = new Message("getOntology", new string[1] { functionality.name }).deliverAndWaitFeedback(this._domainOntologyServiceAddress);
                
                if (answer != null) {

                    if (answer.request.Equals("receiveOntology")) {

                        this._lastError = null;

                        return new Functionality(functionality.name, answer.parameters);
                    } 
                    else {

                        if (answer.request.Equals("ERROR") && answer.numberOfParameters > 0) {

                            this._lastError = string.Join("\n", answer.parameters);

                            return null;
                        }
                    }
                }

                this._lastError = this.resourceManager.GetString("ERROR_NO_RESPONSE_DOS");

                return null;
            } 
            catch (Exception e) {

                this._lastError = e.Message;

                return null;
            }
        }

        /// <summary>
        /// Metoda care seteaza nivelul de incarcare a FFS-ului.
        /// </summary>
        /// <param name="loadLevel">Nivelul de incarcare la care este setat FFS-ul</param>
        /// <param name="functionalityName">Numele functionalitatii pentru cererea care va fi folosita pentru atingerea
        /// nivelului de incarcare transmis</param>
        /// <param name="requestShapes">Detaliile cererii care va for fi folosite pentru atingerea
        /// nivelului de incarcare transmis</param>
        /// <returns></returns>
        public string setServerLoadLevel(int loadLevel, string functionalityName, RequestShape[] requestShapes)
        {
            List<string> messParams = new List<string>();

            messParams.Add(loadLevel.ToString());

            messParams.Add(functionalityName);
            
            foreach (RequestShape requestShape in requestShapes) {

                if (requestShape != null) {

                    messParams.Add(requestShape.serialize());
                }
            }

            try {

                string[] parameters = messParams.ToArray();

                Message answer = new Message("setServerLoadLevel", parameters).deliverAndWaitFeedback(this._functionalityFindingServiceAddress);
             
                              if (answer != null) {

                    if (answer.request.Equals("receiveServerLoad")) {

                        this._lastError = null;

                        return answer.parameters[0];
                    } 
                    else {

                        if (answer.request.Equals("ERROR") && answer.numberOfParameters > 0) {

                            this._lastError = string.Join("\n", answer.parameters);

                            return null;
                        }
                    }
                }

                this._lastError = this.resourceManager.GetString("ERROR_NO_RESPONSE_FFS");

                return null;
            } 
            catch (Exception e) {

                this._lastError = e.Message;

                return null;
            }
        }

        /// <summary>
        ///   Interoghează serviciul de găsire a funcţionalităţii pentru a găsii toate serviciile care corespund unei cereri.
        /// </summary>
        /// <param name="functionalityName">Numele funcţionalităţii pe care serviciile căutate trebuie să o ofere.</param>
        /// <param name="requestShapes">Formele căutate ale proprietăţilor funcţionalităţii.</param>
        /// <returns>Serviciile găsite.</returns>
        public string[] findServices(Functionality functionality, RequestShape[] reqShapes)
        {

            try
            {

                List<RequestShape> reqShp = new List<RequestShape>();

                foreach (RequestShape requestShape in reqShapes)
                {

                    if (requestShape != null)
                    {

                        reqShp.Add(requestShape);
                    }
                }

                if (reqShp.Count == 0)
                {

                    this._lastError = "No request shapes specified";

                    return null;
                }

                RequestShape[] requestShapes = reqShp.ToArray();

                Message answer = new Message("findServices", new string[1] { functionality.name }).deliverAndWaitFeedback(this._functionalityFindingServiceAddress);

                if (answer != null)
                {

                    if (answer.request.Equals("receiveServices"))
                    {

                        this._lastError = null;

                        List<Service> servicesProvidingRequestedFunctionality = new List<Service>();

                        int increment = 3 * functionality.propertiesCount + 2;

                        string[] parameters = answer.parameters;

                        for (int i = 0; i < answer.numberOfParameters; i = i + increment)
                        {

                            string name = null;
                            string accessPoint = null;

                            List<string> propertyNames = new List<string>();
                            List<object> propertyValues = new List<object>();

                            int j = i;
                            int end = i + increment;

                            while (j < end)
                            {

                                if (j % increment == 0)
                                {

                                    name = parameters[j];
                                    j++;
                                }
                                else
                                {

                                    if (j % increment == 1)
                                    {

                                        accessPoint = parameters[j];
                                        j++;
                                    }
                                    else
                                    {

                                        propertyNames.Add(answer.parameters[j]);

                                        if (parameters[j + 1] == "fuzzy")
                                        {

                                            propertyValues.Add(parameters[j + 2]);

                                        }
                                        else
                                        {

                                            if (parameters[j + 1] == "crisp")
                                            {

                                                propertyValues.Add(double.Parse(parameters[j + 2]));
                                            }
                                        }

                                        j = j + 3;
                                    }
                                }
                            }

                            servicesProvidingRequestedFunctionality.Add(new Service(name, accessPoint, functionality.name, propertyNames, propertyValues));
                        }

                        List<Service> completeServices = new List<Service>();

                        foreach (Service service in servicesProvidingRequestedFunctionality)
                        {

                            completeServices.Add(service.addActualOntology(functionality));
                        }

                        InferenceMachine.InferenceMachine inferenceMachine = null;

                        switch (SmartSpammerSettings.Default.INFERENCE_ALGORITHM)
                        {

                            case (int)InferenceAlgorithms.multicriteriaDecisionMaking:

                                inferenceMachine = new MulticriteriaDecisionMaker(functionality, requestShapes);

                                break;

                            default:

                                inferenceMachine = new SelectionRules(functionality, requestShapes);

                                break;
                        }

                        string[] result = new string[completeServices.Count];

                        for (int i = 0; i < completeServices.Count; ++i)
                        {

                            result[i] = inferenceMachine.applyToServiceInCSVFormat(completeServices[i]);
                        }

                        return result;
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

                this._lastError = this.resourceManager.GetString("ERROR_NO_RESPONSE_FFS");

                return null;
            }
            catch (Exception e)
            {

                this._lastError = e.Message;

                return null;
            }
        }

        /// <summary>
        /// Salveaza configuratiile de test in format XML, sub forma unui batch de configuratii de testare
        /// </summary>
        /// <param name="fileName">Numele fisierului care va contine configuratiile</param>
        /// <param name="functionalities">Vector care contine functionalitatea fiecarei configuratii de testare</param>
        /// <param name="requestsSerialized">Matrice care contine detaliile cererii fiecarei configuratii de testare</param>
        /// <param name="minLoads">Nivelul de incarcare la care trebuie sa fie FFS-ul specificat pt fiecare configuratie de testare</param>
        /// <param name="nrReqs">Numarul de cereri tip client adresate FFS-ului dupa atingerea nivelului de incarcare. Specificat
        /// pt fiecare configuratie de testare</param>
        public void saveTestConfigs(string fileName, string[] functionalities, string[][] requestsSerialized, string[] minLoads, string[] nrReqs)
        {

            string text = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<testConfigs xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"testConfigs.xsd\">\r\n";

            for (int i = 0; i < requestsSerialized.Length; ++i)
            {

                text += "\t<testConfig functionality=\"" + functionalities[i] + "\" minServerLoadLevel=\"" + minLoads[i] + "\" nrRequests=\"" + nrReqs[i] + "\">\r\n";

                string name, start, left, right, end, importance;

                for (int j = 0; j < requestsSerialized[i].Length; ++j)
                {

                        string[] aux = requestsSerialized[i][j].Split(new char[] { '\n' }, 6, StringSplitOptions.None);

                        name = aux[0];
                        start = aux[1];
                        left = aux[2];
                        right = aux[3];
                        end = aux[4];
                        importance = aux[5];

                        text += "\t\t<property name=\"" + name + "\" start=\"" + start + "\" left=\"" + left + "\" right=\"" + right + "\" end=\"" + end + "\" importance=\"" + importance + "\" />\r\n";

                    }
 

                    text += "\t</testConfig>\r\n";
                }

                text += "</testConfigs>";

                int.Parse("1");


            try
            {

                File.WriteAllText(fileName, text);
            }
            catch (Exception)
            {

                this._lastError = "There was an error trying to save the file ! Please make sure the file isn't opened by another program and that you have access to modify it.";
            }
        }

        /// <summary>
        ///   Încarcă din XML request-uri salvate de la o generare anterioară și deschide fereastra de vizualizare a metricilor obtinute.
        /// </summary>
        /// <param name="path">Calea către fișierul XML</param>
        /// <returns>Metricile serializate, fiecare string reprezentând o linie</returns>
        public List<string> loadTestConfigsFromXml(string path)
        {

            XMLElement root = XMLParser.parse(path);

            List<string> testConfigsParseResult = new List<string>();

            if (root != null)
            {

                if (root.containsElements("testConfig"))
                {

                    List<XMLElement> testConfigs = root.getElements("testConfig");

                    foreach (XMLElement testConfig in testConfigs)
                    {

                        if (testConfig.containsAttribute("functionality") && testConfig.containsAttribute("minServerLoadLevel") && testConfig.containsAttribute("nrRequests"))
                        {

                            testConfigsParseResult.Add(testConfig.getAttribute("functionality"));                          

                            if (testConfig.containsElements("property"))
                            {

                                List<XMLElement> properties = testConfig.getElements("property");

                                List<string> requestShapes = new List<string>();

                                foreach (XMLElement property in properties)
                                {
       
                                    if (property.containsAttribute("name") && property.containsAttribute("start") && property.containsAttribute("left") && property.containsAttribute("right") && property.containsAttribute("end") && property.containsAttribute("importance"))
                                    {
                                        requestShapes.Add(property.getAttribute("name"));
                                        requestShapes.Add(property.getAttribute("start"));
                                        requestShapes.Add(property.getAttribute("left"));
                                        requestShapes.Add(property.getAttribute("right"));
                                        requestShapes.Add(property.getAttribute("end"));
                                        requestShapes.Add(property.getAttribute("importance"));

                                    }
                                    else
                                    {

                                        this._lastError = "Property element does not contain all the required attributes !";
                                        return null;
                                    }
                                }

                                string[] arrayedRequestShapes = requestShapes.ToArray();
                                string serializedRequestShapes = "";


                                for (int i = 0; i < arrayedRequestShapes.Length-1; i++)
                                {
                                    serializedRequestShapes += arrayedRequestShapes[i] + "\n";
                                }

                                serializedRequestShapes += arrayedRequestShapes[arrayedRequestShapes.Length-1];  

                                testConfigsParseResult.Add(serializedRequestShapes);

                                testConfigsParseResult.Add(testConfig.getAttribute("minServerLoadLevel"));

                                testConfigsParseResult.Add(testConfig.getAttribute("nrRequests"));
                                
                            }
                            else
                            {

                                this._lastError = "Request element does not contain property elements !";
                                return null;
                            }
                        }
                        else
                        {

                            this._lastError = "Request element does not contain functionality attribute !";
                            return null;
                        }
                    }

                    this._lastError = null;

                    return testConfigsParseResult;
                }
                else
                {

                    this._lastError = "Root element requests does not contain request elements !";
                    return null;
                }
            }
            else
            {

                this._lastError = "Error parsing the file !";
                return null;
            }
        }
    }
}