using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

using FuzzySelector.Common.Communication;
using FuzzySelector.Common.Ontology;

using FuzzySelector.Client.InferenceMachine;
using FuzzySelector.Client.InferenceMachine.MulticriteriaDecision;
using FuzzySelector.Client.InferenceMachine.RuleGeneration;

using Client.resx;

namespace FuzzySelector.Client {

    /// <summary>
    ///   Clasa client. Asigură toate funcţionalităţile necesare obţinerii ontologiilor, şi rezultatelor unor cereri de servicii.
    /// </summary>
    public class Client {

        /// <summary>
        ///   Manager tabele lingvistice.
        /// </summary>
        public readonly ResourceManager resourceManager = new ResourceManager("Client.resx.ClientStrings", System.Reflection.Assembly.GetExecutingAssembly());

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
        public Client(Address domainOntologyServiceAddress, Address functionalityFindingServiceAddress) {
            
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
        ///   Interoghează serviciul de găsire a funcţionalităţii pentru a găsii toate serviciile care au o 
        ///   anumita functionalitate si aplica pe acestea algoritmul selectat (FRI sau MCDM).
        /// </summary>
        /// <param name="functionalityName">Numele funcţionalităţii pe care serviciile căutate trebuie să o ofere.</param>
        /// <param name="requestShapes">Formele căutate ale proprietăţilor funcţionalităţii.</param>
        /// <returns>Serviciile găsite.</returns>
        public string[] findServices(Functionality functionality, RequestShape[] reqShapes) {

            try {

                List<RequestShape> reqShp = new List<RequestShape>();
 
                foreach (RequestShape requestShape in reqShapes) {

                    if (requestShape != null) {

                        reqShp.Add(requestShape);
                    }
                }

                if(reqShp.Count == 0) {

                    this._lastError = "No request shapes specified";

                    return null;
                }

                RequestShape[] requestShapes = reqShp.ToArray();

                Message answer = new Message("findServices", new string[1] { functionality.name }).deliverAndWaitFeedback(this._functionalityFindingServiceAddress);

                if (answer != null) {

                    if (answer.request.Equals("receiveServices")) {

                        this._lastError = null;
                        
                        List<Service> servicesProvidingRequestedFunctionality = new List<Service>();

                        int increment = 3* functionality.propertiesCount + 2;

                        string[] parameters = answer.parameters; 

                        for(int i = 0;i<answer.numberOfParameters;i=i+increment) {

                            string name = null;
                            string accessPoint = null;

                            List<string> propertyNames  = new List<string>();
                            List<object> propertyValues = new List<object>();

                            int j = i;
                            int end = i + increment;
                            
                            while(j < end) {
                            
                                if (j % increment == 0) {

                                    name = parameters[j];
                                    j++;
                                }
                                else {
                                    
                                    if (j % increment == 1) {

                                        accessPoint = parameters[j];
                                        j++;
                                    }
                                    else {

                                        propertyNames.Add(answer.parameters[j]);

                                        if (parameters[j+1] == "fuzzy") {
                                            
                                            propertyValues.Add(parameters[j+2]);
                                          
                                        } 
                                        else {

                                            if (parameters[j+1] == "crisp") {
                                            
                                                propertyValues.Add(double.Parse(parameters[j+2])); 
                                            } 
                                        }

                                        j=j+3;
                                    }
                                }
                            }

                            servicesProvidingRequestedFunctionality.Add(new Service(name, accessPoint, functionality.name, propertyNames, propertyValues));
                        }

                        List<Service> completeServices = new List<Service>();

                        foreach(Service service in servicesProvidingRequestedFunctionality) {
                                
                            completeServices.Add(service.addActualOntology(functionality));
                        }

                        InferenceMachine.InferenceMachine inferenceMachine = null;

                        switch (ClientSettings.Default.INFERENCE_ALGORITHM) {

                            case (int)InferenceAlgorithms.multicriteriaDecisionMaking:

                                inferenceMachine = new MulticriteriaDecisionMaker(functionality, requestShapes);

                                break;

                            default:

                                inferenceMachine = new SelectionRules(functionality, requestShapes);

                                break;
                        }

                        string[] result = new string[completeServices.Count];

                        for (int i = 0; i < completeServices.Count; ++i) {

                            result[i] = inferenceMachine.applyToServiceInCSVFormat(completeServices[i]);
                        }

                        return result;
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
    }
}