using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace FuzzySelector.Common.Communication {

    /// <summary>
    ///   Clasă ce abstractizează un mesaj generic.
    /// </summary>
    public class Message {

        /// <summary>
        ///   Numărul maxim de reîncercări de completare a citirii stream-ului socket-ului.
        /// </summary>
        private const int MAX_STREAM_READ_TRIES = 10;

        /// <summary>
        ///   Cererea din mesaj.
        /// </summary>
        public readonly string request;

        /// <summary>
        ///   Parametrii mesajului sub o formă serializată.
        /// </summary>
        private string[] _parameters;

        /// <summary>
        ///   Numărul de parametrii ai mesajului.
        /// </summary>
        public int numberOfParameters {

            get {

                return this._parameters == null ? -1 : this._parameters.Length;
            }
        }

        /// <summary>
        ///   Copie după parametrii mesajului.
        /// </summary>
        public string[] parameters {

            get {

                if (this._parameters != null) {
                        
                    string[] result = new string[this._parameters.Length];

                    for (int i = 0; i < this._parameters.Length; ++i) {
                    
                        result[i] = this._parameters[i];
                    }

                    return result;
                } 
                else {

                    return null;
                }
            }
        }

        /// <param name="request">Cererea din mesaj</param>
        /// <param name="parameters">Parametrii mesajului sub o formă serializată</param>
        public Message(string request, string[] parameters) {

            this.request = request;

            if (parameters != null) {

                this._parameters = new string[parameters.Length];

                for (int i = 0; i < this._parameters.Length; ++i) {

                    this._parameters[i] = parameters[i];
                }
            } 
            else {

                this._parameters = null;
            }
        }

        /// <param name="fromStream">Obiect serializat de tip mesaj</param>
        public Message(Stream fromStream) {

            try {
                
                string[] msg = Encoding.UTF8.GetString(readStream(fromStream)).Split(new char[] { '\n' }, 2, StringSplitOptions.None);
                
                this._parameters = msg[1].Split(new char[] { '\n' }, StringSplitOptions.None);

                for (int i = 0; i < _parameters.Length; ++i) {

                    this._parameters[i] =this. _parameters[i].Replace("\r\r", "\n");
                }

                this.request = msg[0].Replace("\r\r", "\n");
            } 
            catch (Exception) {
            
            }
        }

        /// <summary>
        ///   Returnează un parametru al mesajului.
        /// </summary>
        /// <param name="index">Indexul parametrului căutat</param>
        /// <returns>Parametrul căutat sau null dacă nu există</returns>
        public string getParameter(int index) {
            
            if (index >= 0 && index < this._parameters.Length) {
                
                return this._parameters[index];
            } 
            else {

                return null;
            }
        }

        /// <summary>
        ///   Metodă auxiliară ce realizează citirea stream-ului, verifică dimensiunea corectă şi scoate octeţii referitori la dimensiune.
        /// </summary>
        /// <param name="stream">Stream-ul din care se citeşte</param>
        /// <returns>Şirul de octeţi trimişi fără primii 4 referitori la lungime sau null dacă a intervenit o eroare</returns>
        private static byte[] readStream(Stream stream) {
          
            int size = 0;

            for (int i = 0; i < 4; ++i) {

                int byteRead = stream.ReadByte();

                if (byteRead == -1) {

                    return null;
                } 
                else {

                    size = size * 256 + (byte)byteRead;
                }
            }

            byte[] result = new byte[size];
           
            int retries = 0;
            size = 0;

            while (size < result.Length) {

                int bytesRead = stream.Read(result, size, result.Length - size);
                
                size += bytesRead;
                
                if (bytesRead == 0) {

                    ++retries;
                    
                    if (retries > MAX_STREAM_READ_TRIES && size < result.Length) {
                    
                        return null;
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///   Serializează mesajul sub forma unui şir de octeţi.
        /// </summary>
        /// <returns>Şirul de octeţi reprezentând mesajul, primii 4 sunt lungimea restului şirului</returns>
        public byte[] serialize() {

            string[] parameters = this._parameters == null ? null : new string[this._parameters.Length];

            if (parameters != null) {

                for (int i = 0; i < parameters.Length; ++i) {
                    
                    parameters[i] = this._parameters[i] == null ? null : this._parameters[i].Replace("\n", "\r\r");
                }
            }

            string mess = this.request.Replace("\n", "\r\r") + "\n" + (parameters == null ? "" : String.Join("\n", parameters));
           
            byte[] text = Encoding.UTF8.GetBytes(mess);

            byte[] result = new byte[4 + text.Length];

            int lenWord1 = text.Length / 65536;
            int lenWord2 = text.Length % 65536;

            result[0] = (byte)(lenWord1 / 256);
            result[1] = (byte)(lenWord1 % 256);
            result[2] = (byte)(lenWord2 / 256);
            result[3] = (byte)(lenWord2 % 256);

            // copiem text-ul dupa primii 4 octeţi care menţionează lungimea
            System.Buffer.BlockCopy(text, 0, result, 4, text.Length);  

            return result;
        }

        /// <summary>
        ///   Trimite mesajul către adresa menţionată şi returnează răspunsul.
        /// </summary>
        /// <param name="to">Adresa spre care să trimită mesajul</param>
        /// <returns>Mesajul răspuns primit înapoi</returns>
        public Message deliverAndWaitFeedback(Address to) {
           
            try {
                
                byte[] stream = this.serialize();
                
                NetworkStream netStream = new TcpClient(to.ip, to.port).GetStream();
                
                netStream.Write(stream, 0, stream.Length);
                
                netStream.Flush();

                Message answer = new Message(netStream);
               
                netStream.Close();
                
                return answer;
            } 
            catch (Exception) {

                return null;
            }
        }
    }
}