using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FuzzySelector.Common.Communication {

    public class Replyer {

        /// <summary>
        ///   Transformatorul de cereri în răspuns.
        /// </summary>
        private ITransformer iTransformer;

        /// <summary>
        ///   Monitor pentru starea firului de execuţie de rezolvare a cererilor.
        /// </summary>
        //private ManualResetEvent tcpClientConnected;

        /// <param name="iTransformer">Transformatorul de cereri în răspuns</param>
        /// <param name="port">Portul pe care se ascultă</param>
        public Replyer(ITransformer iTransformer, int port) {

            this.iTransformer = iTransformer;
            
            TcpListener tcpl = new TcpListener(IPAddress.Any, port);
            
            tcpl.Start();

            while (true) {

                try {

                    while (!tcpl.Pending()) {
                     
                        Thread.Sleep(1000);
                    }
                    
                    TcpClient client = tcpl.AcceptTcpClient();

                    ThreadPool.QueueUserWorkItem(receiveTransformAndSendFeedback, client);
                } 
                catch (ThreadAbortException) {

                    tcpl.Stop();
                    
                    return;
                }
            }
        }

        /// <summary>
        ///   Preia cererea serializată de pe socket şi o trimite spre transformare în răspuns transformatorului ataşat.
        ///   Serializează răspunsul şi il trimite înapoi prin acelaşi stream pe care a venit cererea, după care închide stream-ul.
        /// </summary>
        /// <param name="ar">Rezultatul operaţiei asincrone de acceptarea a unui client TCP</param>
        private void receiveTransformAndSendFeedback(Object obj) {

            TcpClient client = (TcpClient)obj;

            NetworkStream netStream = client.GetStream();

            byte[] answer = this.iTransformer.answer(new Message(netStream), ((IPEndPoint)client.Client.RemoteEndPoint).Address).serialize();
           
            if (answer != null) {

                netStream.Write(answer, 0, answer.Length);
                netStream.Flush();
                netStream.Close(10000);
            }

            client.Close();
        }
    }
}
