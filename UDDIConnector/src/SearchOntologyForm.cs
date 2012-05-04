using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Uddi;
using Microsoft.Uddi.Businesses;
using Microsoft.Uddi.Services;
using Microsoft.Uddi.TModels;

namespace UDDIConnector {

    /// <summary>
    ///   Fereastra folosita pentru cautarea de ontologii.
    /// </summary>
    public partial class SearchOntologyForm : Form {

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;

        /// <summary>
        ///   Elementul selectat din lista cu ontologii.
        /// </summary>
        private ListViewItem selectedItem;

        public SearchOntologyForm(UddiConnection uddiConnection) {

            InitializeComponent();

            this.uddiConnection = uddiConnection;
        }

        /// <summary>
        ///   Cauta ontologii pe baza informatiilor specificate in campurile corespunzatoare.
        ///   Completeaza lista de ontologii cu rezultatele cautarii.
        /// </summary>
        public void performSearch() {

            string ontologyName = txbOntologyName.Text.Trim();

            if (ontologyName == String.Empty) {

                MessageBox.Show("Ontology name is not set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {

                listView.Items.Clear();

                SearchOntology searchOntology = new SearchOntology(uddiConnection, ontologyName, chkCaseSensitive.Checked, chkExactMatch.Checked);

                List<OntInfo> ontologyList = searchOntology.search();

                if (ontologyList == null) {

                    MessageBox.Show("No matches were found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (OntInfo ontInfo in ontologyList) {

                    ListViewItem item = new ListViewItem(ontInfo.owner);

                    item.SubItems.Add(ontInfo.ontologyName);
                    item.SubItems.Add(ontInfo.ontologyURL);
                    
                    item.Tag = ontInfo;

                    listView.Items.Add(item);
                }
            }
            catch (UddiException e) {

                MessageBox.Show("Uddi error: " + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e) {

                MessageBox.Show("General exception: " + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///     Sterge o ontologie de pe serverul UDDI.
        /// </summary>
        /// <param name="tModelKey">Cheia tModel-ului folosit pentru stocarea ontologiei pe serverul UDDI.</param>
        /// <returns>Raport al stergerii ontologiei (tModel-ului) de pe serverul UDDI.</returns>
        private DispositionReport performDeleteOntology(string tModelKey) {

            DeleteTModel deleteTModel            = new DeleteTModel(tModelKey);
           
            DispositionReport dispositionReport = deleteTModel.Send(uddiConnection);
            
            return dispositionReport;
        }

        /// <summary>
        ///     Sterge o ontologie din lista cu ontologii cat si de pe serverul UDDI.
        /// </summary>
        private void deleteOntology() {

            if (listView.SelectedItems.Count > 0) {
               
                try {

                    selectedItem = listView.SelectedItems[0];

                    String tModelKey = ((OntInfo)selectedItem.Tag).tModelKey;
                    
                    DispositionReport dispositionReport = performDeleteOntology(tModelKey);                   
                    
                    MessageBox.Show(dispositionReport.Results[0].ErrInfo.ErrCode);
                    
                    listView.Items.Remove(selectedItem);
                }
                catch (UddiException e) {

                    MessageBox.Show("UDDI error: " + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception e) {

                    MessageBox.Show("General exception:" + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///   Modifica URL-ului unei ontologii din lista cu ontologii.
        ///   Deschide o fereastra pentru completarea noii valori.
        /// </summary>
        private void updateURL() {

            if(listView.SelectedItems.Count > 0 ) {

                try {

                    selectedItem = listView.SelectedItems[0];

                    UpdateForm updateForm    = new UpdateForm(selectedItem.SubItems[2].Text);

                    updateForm.valueUpdated += new UpdateForm.ValueUpdateHandler(updateForm_ValueUpdated);

                    updateForm.ShowDialog();
                }
                catch (UddiException e) {

                    MessageBox.Show("Uddi error: " + e.Message,"Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception e) {

                    MessageBox.Show("General exception: " + e.Message,"Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///   Callback-ul apelat după completarea noii valori in UpdateForm.
        ///   Modifica valoarea pe serverul UDDI si in lista de ontologii.
        /// </summary>
        void updateForm_ValueUpdated(object sender, ValueUpdateEventArgs e) {
           
            GetTModelDetail getTModelDetail = new GetTModelDetail(((OntInfo)selectedItem.Tag).tModelKey);
            TModelDetail tModelDetail       = getTModelDetail.Send(uddiConnection);

            TModel tModel = tModelDetail.TModels[0];

            tModel.OverviewDoc.OverviewUrl  = e.NewValue;

            SaveTModel saveTModel = new SaveTModel(tModel);

            saveTModel.Send(uddiConnection);

            selectedItem.SubItems[2].Text  = e.NewValue;
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru cautarea de ontologii pe baza informatiilor specificate in campurile corespunzatoare.
        /// </summary>
        private void searchButton_Click(object sender, EventArgs e) {

            performSearch();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru stergerea unei ontologii din lista cu ontologii.
        /// </summary>
        private void deleteOntology_Click(object sender, EventArgs e) {

            deleteOntology();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru modificarea URL-ului unei ontologii din lista cu ontologii.
        /// </summary>
        private void updateURL_Click(object sender, EventArgs e) {

            updateURL();
        }
    }
}
