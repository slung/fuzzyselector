using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Uddi;
using Microsoft.Uddi.TModels;

namespace UDDIConnector {

    /// <summary>
    ///   Fereastra folosita pentru publicarea unei noi ontologii.
    /// </summary>
    public partial class PublishOntologyForm : Form {

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;
     
        public PublishOntologyForm(UddiConnection uddiConnection) {

            InitializeComponent();

            this.uddiConnection = uddiConnection;
       }

        /// <summary>
        ///   Publica ontologie cu numele si URL-ul specificat in campurile corespunzatoare (daca nu exista deja).
        /// </summary>
        private void performPublish() {
      
            String ontologyName = txbOntologyName.Text.Trim();
            String ontologyURL  = txbOntologyURL.Text.Trim();
          
            if (ontologyName == String.Empty || ontologyURL == String.Empty) {

                MessageBox.Show("All values must be set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {

                FindTModel findTModel = new FindTModel(ontologyName);

                // uuid:a035a07c-f362-44dd-8f95-e2b134bf43b4  == uddi-org:general_keywords key
                KeyedReference categoryOntology = new KeyedReference("uuid:a035a07c-f362-44dd-8f95-e2b134bf43b4", "ontology", "QoS");
                
                findTModel.CategoryBag.Add(categoryOntology);

                findTModel.FindQualifiers.Add(FindQualifier.ExactNameMatch);
               
                TModelList tModelList = findTModel.Send(uddiConnection);

                if (0 == tModelList.TModelInfos.Count) {

                    TModel ontologyTModel = new TModel(ontologyName);
                  
                    ontologyTModel.CategoryBag.Add(categoryOntology);
                 
                    ontologyTModel.OverviewDoc.OverviewUrl = ontologyURL;

                    SaveTModel saveOntologyTModel = new SaveTModel(ontologyTModel);

                    saveOntologyTModel.Send(uddiConnection);

                    MessageBox.Show("Publish successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {

                    MessageBox.Show("Ontology already exists");
                }
            }
            catch (UddiException e) {

                MessageBox.Show("Uddi error: "+ e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e){

                MessageBox.Show("General exception: " + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
       }

        /// <summary>
        ///   Indică apăsarea butonului pentru golirea campurilor folosite pentru completarea informatiilor.
        ///   Goleste campurile folosite pentru completarea informatiilor.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e) {

            txbOntologyName.Clear();
            txbOntologyURL.Clear();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru publicarea unei ontologii cu numele si URL-ul specificat in campurile corespunzatoare.
        ///   Publica ontologia (daca nu exista deja).
        /// </summary>
        private void btnPublish_Click(object sender, EventArgs e) {

            performPublish();
        }
    }
}
