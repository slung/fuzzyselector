using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Microsoft.Uddi;

namespace UDDIConnector {

    /// <summary>
    ///   Clasa prin care se stabilesc informatiile privind conexiunea la serverul UDDI.
    /// </summary>
    class Connection {

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection = null;

        /// <summary>
        ///   Returneaza informatii privind conexiunea la serverul UDDI - obtinute prin completarea unui ConnectionForm.
        /// </summary>
        /// <returns>Returneaza informatii privind conexiunea la serverul UDDI</returns>
        public UddiConnection getUddiConnection() {

            ConnectionForm connectionForm;

            if (uddiConnection != null) {

                connectionForm = new ConnectionForm(uddiConnection);
            }
            else {

                connectionForm = new ConnectionForm();
            }

            connectionForm.connectionUpdated += new ConnectionForm.ConnectionUpdateHandler(connectionForm_ConnectionUpdated); 
           
            connectionForm.ShowDialog();

            return uddiConnection;
        }

        /// <summary>
        ///   Callback-ul apelat după completarea unui ConnectionForm.
        ///   Stocheaza informatiile privind conexiunea la serverul UDDI.
        /// </summary>
        private void connectionForm_ConnectionUpdated(object sender, ConnectionUpdateEventArgs e) {

            uddiConnection = new UddiConnection();

            uddiConnection.InquireUrl = e.InquireURL;
            uddiConnection.PublishUrl = e.PublishURL;
            uddiConnection.Username   = e.Username;
            uddiConnection.Password   = e.Password;

            uddiConnection.AuthenticationMode = AuthenticationMode.UddiAuthentication;
        }
    }
}
