using System.Globalization;
using System.Net;
using System.Resources;
using FuzzySelector.Common.Communication;
using FuzzySelector.Common.Ontology;

namespace FuzzySelector.FunctionalityFindingService {

    /// <summary>
    ///   Clasa transformer a serviciului de găsire a funcționalităților.
    ///   Se ocupa de transformarea mesajelor cerere in mesaje raspuns.
    /// </summary>
    public class FunctionalityFindingServiceTransformer : ITransformer {

        /// <summary>
        ///   Serviciul de găsire a funcționalităților ataşat.
        /// </summary>
        private FunctionalityFindingService functionalityFindingService;

        /// <param name="functionalityFindingService">Serviciul de găsire a funcționalităților ataşat</param>
        public FunctionalityFindingServiceTransformer(FunctionalityFindingService functionalityFindingService) {
           
            this.functionalityFindingService = functionalityFindingService;
        }

        /// <summary>
        ///   Funcţia efectivă de transformare a mesajelor cerere în mesaje raspuns folosind serviciul ataşat.
        ///   Realizează interpretarea tipului cererii şi determină acţiunile necesare pentru a afla răspunsul.
        /// </summary>
        /// <param name="message">Cererea</param>
        /// <param name="from">Adresa de unde provine cererea</param>
        /// <returns>Raspunsul la cerere</returns>
        public Message answer(Message message, IPAddress from) {

            if (message.request.Equals("findServices")) {

                if (message.numberOfParameters == 1) {
                   
                    string[] services = this.functionalityFindingService.findServices(message.getParameter(0));
                   
                    if (services != null) {

                        return new Message("receiveServices", services);
                    } 
                    else {

                        return new Message("ERROR", new string[1] { this.functionalityFindingService.lastError });
                    }
                } 
                else {

                    return new Message("ERROR", new string[2] { "Missing parameter", "Please send functionality name, followed by request shapes in proper format." });
                }
            }
            else
                if (message.request.Equals("setServerLoadLevel"))
                {

                    if (message.numberOfParameters > 1)
                    {

                        RequestShape[] requestShapes = new RequestShape[message.numberOfParameters - 2];

                        for (int i = 2; i < message.numberOfParameters; ++i)
                        {

                            requestShapes[i - 2] = new RequestShape(message.getParameter(i));
                        }

                        string[] serverLoadLevel = new string[1];

                        serverLoadLevel[0] = this.functionalityFindingService.setServerLoadLevel(int.Parse(message.getParameter(0)), message.getParameter(1), requestShapes);

                        if (serverLoadLevel != null)
                        {
                            return new Message("receiveServerLoad", serverLoadLevel);
                        }
                        else
                        {

                            return new Message("ERROR", new string[1] { this.functionalityFindingService.lastError });
                        }
                    }
                    else
                    {

                        return new Message("ERROR", new string[2] { "Missing parameter", "Please send functionality name, followed by request shapes in proper format." });
                    }
                }
            else {

                return new Message("ERROR", new string[2] { "Unknown request", message.request });
            }
        }
    }
}
