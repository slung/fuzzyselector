using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Microsoft.Uddi;
using UDDIConnector.resx;

namespace UDDIConnector {

    /// <summary>
    ///   Fereastra in care se modifica informatiile privind onexiunea la serverul UDDI.
    /// </summary>
    public partial class ConnectionForm : Form {

        /// <summary>
        ///  Tipul callback-ului folosit după ce un informatiile au fost modificate.
        /// </summary>
        public delegate void ConnectionUpdateHandler(object sender, ConnectionUpdateEventArgs e);

        /// <summary>
        ///  Callback-ului folosit după ce un informatiile au fost modificate.
        /// </summary>
        public event ConnectionUpdateHandler connectionUpdated;

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;
   
        public ConnectionForm() {

            InitializeComponent();

            this.uddiConnection = null;
        }

        public ConnectionForm(UddiConnection uddiConnection) {
            
            InitializeComponent();

            this.uddiConnection = uddiConnection;

            txbInquireURL.Text  = uddiConnection.InquireUrl;
            txbPublishURL.Text  = uddiConnection.PublishUrl;
            txbUsername.Text    = uddiConnection.Username;
            txbPassword.Text    = uddiConnection.Password;
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru incarcarea ultimelor informatii folosite privind conexiunea la serverul UDDI.
        ///   Incarca ultimele informatii folosite privind conexiunea la serverul UDDI (daca acestea exista salvate).
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e) {

            txbInquireURL.Text = UDDIConnectorSettings.Default.Inquire;
            txbPublishURL.Text = UDDIConnectorSettings.Default.Publish;
            txbUsername.Text   = UDDIConnectorSettings.Default.Username;
            txbPassword.Text   = UDDIConnectorSettings.Default.Password;
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru salvarea informatiilor folosite privind conexiunea la serverul UDDI.
        ///   Salveaza ultimele informatii folosite privind conexiunea la serverul UDDI (daca acestea exista salvate).
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e) {

            UDDIConnectorSettings.Default.Inquire  = txbInquireURL.Text;
            UDDIConnectorSettings.Default.Publish  = txbPublishURL.Text;
            UDDIConnectorSettings.Default.Username = txbUsername.Text;
            UDDIConnectorSettings.Default.Password = txbPassword.Text;

            UDDIConnectorSettings.Default.Save();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru golirea campurilor folosite pentru completarea informatiilor privind conexiunea la serverul UDDI.
        ///   Goleste campurile folosite pentru completarea informatiilor privind conexiunea la serverul UDDI.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e) {

            txbInquireURL.Clear();
            txbPublishURL.Clear();
            txbUsername.Clear();
            txbPassword.Clear();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru confirmarea/stocarea informatiilor folosite privind conexiunea la serverul UDDI.
        ///   Preia informatiile din campurile corespunzatoare (verifica daca sunt completate/diferite de valorile initiale), apeleaza callback-ul specificat si inchide fereastra.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e) {

            string inquireURL = txbInquireURL.Text.Trim();
            string publishURL = txbPublishURL.Text.Trim();
            string username   = txbUsername.Text.Trim();
            string password   = txbPassword.Text.Trim();

            if (inquireURL == String.Empty || publishURL == String.Empty || username == String.Empty || password == String.Empty) {
               
                MessageBox.Show("All values must be set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (uddiConnection != null  && inquireURL == uddiConnection.InquireUrl && publishURL == uddiConnection.PublishUrl && username == uddiConnection.Username && password == uddiConnection.Password) {
                
                MessageBox.Show("All values are the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            ConnectionUpdateEventArgs args = new ConnectionUpdateEventArgs(inquireURL, publishURL, username, password);

            connectionUpdated(this, args);

            this.Dispose();
        }
    }

    /// <summary>
    ///   Clasa folosita pentru stocarea/trimiterea informatiilor privind conexiunea la serverul UDDi din ConnectionForm in Connection .
    /// </summary>
    public class ConnectionUpdateEventArgs : EventArgs {

        /// <summary>
        ///   URL-ul folosit pentru cautari.
        /// </summary>
        private string inquireURL;

        /// <summary>
        ///   URL-ul folosit pentru publicari.
        /// </summary>
        private string publishURL;

        /// <summary>
        ///   Username-ul folosit pentru publicari.
        /// </summary>
        private string username;

        /// <summary>
        ///   Parola-ul pentru username-ul respectiv.
        /// </summary>
        private string password;

        public ConnectionUpdateEventArgs(string inquireURL, string publishURL,string username, string password) {

            this.inquireURL = inquireURL;
            this.publishURL = publishURL;
            this.username   = username;
            this.password   = password;
        }

        public string InquireURL { 
            
            get { 
                
                return inquireURL; 
            }
        }

        public string PublishURL { 
            
            get { 
            
                return publishURL; 
            } 
        }
        
        public string Username { 
            
            get { 
                
                return username; 
            }
        }

        public string Password { 
            
            get { 
                
                return password; 
            }
        }
    }
}
