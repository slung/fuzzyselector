using System.Net;
using FuzzySelector.Common.Communication;

namespace FuzzySelector.DomainOntologyService {

    /// <summary>
    ///   Clasa transformer a serviciului ontologiei domeniului.
    ///   Se ocupa de transformarea mesajelor cerere in mesaje raspuns.
    /// </summary>
    public class DomainOntologyServiceTransformer : ITransformer {

        /// <summary>
        ///   Serviciul ontologiei domeniului ataşat.
        /// </summary>
        private DomainOntologyService domainOntologyService;

        /// <param name="domainOntologyService">Serviciul ontologiei domeniului ataşat</param>
        public DomainOntologyServiceTransformer(DomainOntologyService domainOntologyService) {

            this.domainOntologyService = domainOntologyService;
        }

        /// <summary>
        ///   Funcţia efectivă de transformare a mesajelor cerere în mesaje raspuns folosind serviciul ataşat.
        ///   Realizează interpretarea tipului cererii şi determină acţiunile necesare pentru a afla răspunsul.
        /// </summary>
        /// <param name="message">Cererea</param>
        /// <param name="from">Adresa de unde provine cererea</param>
        /// <returns>Raspunsul la cerere</returns>
        public Message answer(Message message, IPAddress from) {

            if (message.request.Equals("getFunctionalities")) {

                return new Message("receiveFunctionalities", this.domainOntologyService.getAllFunctionalities());
            } 
            else {

                if (message.request.Equals("getOntology")) {

                    if (message.numberOfParameters == 1) {

                        string[] ontology = this.domainOntologyService.getSerializedOntology(message.getParameter(0));
                       
                        if (ontology != null) {

                            return new Message("receiveOntology", ontology);
                        } 
                        else {

                            return new Message("ERROR", new string[2] { "Unknown functionality", message.getParameter(0) });
                        }
                    } 
                    else {

                        return new Message("ERROR", new string[2] { "Missing parameter", "Functionality" });
                    }
                } 
                else {

                    return new Message("ERROR", new string[2] { "Unknown request", message.request });
                }
            }
        }
    }
}
