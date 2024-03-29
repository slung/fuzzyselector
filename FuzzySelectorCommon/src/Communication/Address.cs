namespace FuzzySelector.Common.Communication {

    /// <summary>
    ///   Structură reprezetând o adresă. Imutabilă.
    /// </summary>
    public struct Address {

        /// <summary>
        ///   IP-ul adresei.
        /// </summary>
        public readonly string ip;

        /// <summary>
        ///   Portul utilizat.
        /// </summary>
        public readonly int port;

        /// <param name="ip">IP-ul adresei.</param>
        /// <param name="port">Portul utilizat.</param>
        public Address(string ip, int port) {

            this.ip = ip;
            this.port = port;
        }
    }
}