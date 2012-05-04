using System.Threading;

namespace FuzzySelector.Common.Communication {

    /// <summary>
    ///   Clasă ce oferă funcţionalităţile pentru ascultarea pe socket-uri. 
    ///   Lucrează cu clasele însărcinate să ofere şi răspunsurile.
    /// </summary>
    public class Listener {

        /// <summary>
        ///   Fir de execuţie separat care se ocupă cu ascultarea efectivă.
        /// </summary>
        private Thread listener = null;

        /// <summary>
        ///   Transformatorul de cereri în răspuns.
        /// </summary>
        private ITransformer iTransformer;

        /// <summary>
        ///   Indică dacă ascultarea pe socket este pornită.
        /// </summary>
        public bool isListening {

            get {

                return this.listener != null;
            }
        }

        /// <param name="iTransformer">Obiect ce implementează interfaţa ITransformer</param>
        public Listener(ITransformer iTransformer) {

            this.iTransformer = iTransformer;
        }

        /// <summary>
        ///   Destructorul, opreşte ascultarea pe socket.
        /// </summary>
        ~Listener() {

            this.stopListening();
        }

        /// <summary>
        ///   Opreşte ascultarea pe socket.
        /// </summary>
        public void stopListening() {
            
            if (this.listener != null) {

                this.listener.Abort();
                this.listener = null;
            }
        }

        /// <summary>
        ///   Porneşte ascultarea pe socket.
        /// </summary>
        /// <param name="port">Portul pe care se ascultă</param>
        public void startListening(int port) {

            this.stopListening();
            
            this.listener = new Thread(delegate() {
                
                new Replyer(this.iTransformer, port);
            });

            this.listener.Start();
        }
    }
}
