using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Uddi;
using UDDIConnector.src;

namespace UDDIConnector {

    /// <summary>
    ///   Fereastra procesului provider.
    /// </summary>
    public partial class ProviderForm : Form {

        /// <summary>
        ///   Element prin care se stabilesc informatiile privind conexiunea la serverul UDDI.
        /// </summary>
        private Connection connection         = null;

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection = null;

        public ProviderForm() {

            InitializeComponent();

            connection = new Connection();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru modificarea informatiilor privind conexiunea la serverul UDDI.
        ///   Salveaza informatiile daca s-au facut modificari.
        /// </summary>
        private void btnUDDIConnection_Click(object sender, EventArgs e) {

            UddiConnection uddiConnection = connection.getUddiConnection();

            if (uddiConnection != null) {
                
                this.uddiConnection = uddiConnection;
            }
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru publicarea unui nou serviciu.
        ///   Deschide fereastra pentru publicarea unui nou serviciu (daca exista informatii privind conexiunea la serverul UDDI).
        /// </summary>
        private void btnPublishService_Click(object sender, EventArgs e) {

            if (uddiConnection == null) {

                MessageBox.Show("Missing UDDI Connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                PublishServiceForm publishServiceForm = new PublishServiceForm(uddiConnection);
                
                publishServiceForm.ShowDialog();
            }
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru publicarea unei noi ontologii.
        ///   Deschide fereastra pentru publicarea unei noi ontologii (daca exista informatii privind conexiunea la serverul UDDI).
        /// </summary>
        private void btnPublishOntology_Click(object sender, EventArgs e) {
           
            if (uddiConnection == null) {

                MessageBox.Show("Missing UDDI Connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                PublishOntologyForm publishOntologyForm = new PublishOntologyForm(uddiConnection);
               
                publishOntologyForm.ShowDialog();
            }
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru cautarea unui serviciu.
        ///   Deschide fereastra pentru cautarea unui serviciu (daca exista informatii privind conexiunea la serverul UDDI).
        /// </summary>
        private void btnSearchService_Click(object sender, EventArgs e) {

            if (uddiConnection == null) {

                MessageBox.Show("Missing UDDI Connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                
                SearchServiceForm searchServiceForm = new SearchServiceForm(uddiConnection);
                
                searchServiceForm.ShowDialog();
            }
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru cautarea unei ontologii.
        ///   Deschide fereastra pentru cautarea unei ontolo(daca exista informatii privind conexiunea la serverul UDDI).
        /// </summary>
        private void btnSearchOntology_Click(object sender, EventArgs e) {

            if (uddiConnection == null) {

                MessageBox.Show("Missing UDDI Connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                SearchOntologyForm searchOntologyForm = new SearchOntologyForm(uddiConnection);
                
                searchOntologyForm.ShowDialog();
            }
        }

        private void btnCreateOntology_Click(object sender, EventArgs e)
        {
            //if (uddiConnection == null) {

            //    MessageBox.Show("Missing UDDI Connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else {

                CreateOntologyForm createOntologyForm = new CreateOntologyForm(uddiConnection);
               
                createOntologyForm.ShowDialog();
            //}
        }

        private void btnComposeOntologies_Click(object sender, EventArgs e)
        {
            //if (uddiConnection == null) {

            //    MessageBox.Show("Missing UDDI Connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else {

            OntologyCompositionForm createOntologyForm = new OntologyCompositionForm(uddiConnection);

            createOntologyForm.ShowDialog();
            //}
        }       
    }
}
