using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Uddi;
using Microsoft.Uddi.Businesses;
using Microsoft.Uddi.Services;

namespace UDDIConnector {

    /// <summary>
    ///   Fereastra folosita pentru cautarea de servicii.
    /// </summary>
    public partial class SearchServiceForm : Form {

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;

        /// <summary>
        ///   Lista tuturor ontologiilor de pe serverul UDDI.
        /// </summary>
        private List<OntInfo> ontologyList;

        /// <summary>
        ///   Atributele esentiale ale ontolgiilor pe baza carora se face cautarea.
        /// </summary>        
        private String[] ontologyAttributes;

        /// <summary>
        ///   Elementul selectat din lista cu servicii.
        /// </summary>
        private ListViewItem selectedItem;
      
        public SearchServiceForm(UddiConnection uddiConnection) {

            InitializeComponent();

            this.uddiConnection = uddiConnection;

            searchOntologies();
        }

        /// <summary>
        ///   Cauta toate ontologiile de pe serverul UDDI.
        ///   Stocheaza toate ontologiile in lista ontologiilor.
        ///   Adauga ontologiile in combo-box.
        /// </summary>
        private void searchOntologies() {

            try {

                cbxOntology.Items.Add("No ontologies defined");
               
                cbxOntology.SelectedIndex = 0;
                
                chkUseOntology.Checked = false;
                
                chkUseOntology.Enabled = false;

                SearchOntology searchOntology = new SearchOntology(uddiConnection);
                
                ontologyList = searchOntology.search();

                if (ontologyList != null) {
                        
                    cbxOntology.Items.Clear();

                    cbxOntology.Items.Add("All");

                    cbxOntology.SelectedIndex = 0;

                    chkUseOntology.Checked = true;
                    chkUseOntology.Enabled = true;

                    cbxOntology.Tag = ontologyList;

                    foreach (OntInfo ontInfo in ontologyList) {

                        cbxOntology.Items.Add(ontInfo.ontologyName);
                     }
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
        ///   Cauta servicii pe baza informatiilor specificate in campurile corespunzatoare.
        ///   Completeaza lista de servicii cu rezultatele cautarii.
        /// </summary>
        private void performSearch() {

            string serviceName  = txbServiceName.Text.Trim();
            string businessName = txbBusinessName.Text.Trim();

            if (businessName == String.Empty && serviceName == String.Empty) {

                MessageBox.Show("Business and Service name are not set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (businessName != String.Empty && serviceName == String.Empty) {

                MessageBox.Show("If Business name is set Service name must also be set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {

                listView.Items.Clear();

                SearchService searchService    = new SearchService(uddiConnection, businessName, serviceName, ontologyAttributes, chkCaseSensitive.Checked, chkExactMatch.Checked);

                List<List<WSInfo>> serviceList = searchService.search();

                if (serviceList == null) {

                    MessageBox.Show("No matches were found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (List<WSInfo> listItem in serviceList) {

                    foreach (WSInfo wsInfo in listItem) {
                 
                        ListViewItem item = new ListViewItem(wsInfo.owner);

                        item.SubItems.Add(wsInfo.businessName);
                        item.SubItems.Add(wsInfo.serviceName);
                        item.SubItems.Add(wsInfo.ontologyName);
                        item.SubItems.Add(wsInfo.accessPoint);

                        item.Tag = wsInfo;

                        listView.Items.Add(item);
                    }
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
        ///     Sterge un domeniu de grupuri de servicii de pe serverul UDDI.
        /// </summary>
        /// <param name="businessKey">Cheia BusinessEntity-ului folosit pentru stocarea domeniului de grupuri de servicii pe serverul UDDI.</param>
        /// <returns>Raport al stergerii domeniului de grupuri de servicii (BusinessEntity-ului) de pe serverul UDDI.</returns>
        private DispositionReport performDeleteBusiness(string businessKey) {
          
            DeleteBusiness deleteBusiness       = new DeleteBusiness(businessKey);
            
            DispositionReport dispositionReport = deleteBusiness.Send(uddiConnection);
            
            return dispositionReport;
        }

        /// <summary>
        ///     Sterge un grup de servicii de pe serverul UDDI.
        /// </summary>
        /// <param name="serviceKey">Cheia BusinessService-ului folosit pentru stocarea grupului de servicii pe serverul UDDI.</param>
        /// <returns>Raport al stergerii grupului de servicii (BusinessService-ului) de pe serverul UDDI.</returns>
        private DispositionReport performDeleteService(string serviceKey) {

            DeleteService deleteService         = new DeleteService(serviceKey);
           
            DispositionReport dispositionReport = deleteService.Send(uddiConnection);
           
            return dispositionReport;
        }

        /// <summary>
        ///     Sterge un serviciu de pe serverul UDDI.
        /// </summary>
        /// <param name="bindingKey">Cheia BindingTemplate-ului folosit pentru stocarea serviciului pe serverul UDDI.</param>
        /// <returns>Raport al stergerii serviciului (BindingTemplate-ului) de pe serverul UDDI.</returns>
        private DispositionReport performDeleteBinding(string bindingKey) {
      
            DeleteBinding deleteBinding         = new DeleteBinding(bindingKey);
            
            DispositionReport dispositionReport = deleteBinding.Send(uddiConnection);
            
            return dispositionReport;
        }

        /// <summary>
        ///     Sterge un anumit domeniu de grupuri de servicii atat din lista cu servicii cat si de pe serverul UDDI.
        /// </summary>
        private void deleteBusiness() {

            if (listView.SelectedItems.Count > 0) {

                try {
                    
                    selectedItem = listView.SelectedItems[0];
                    
                    String businessKey = ((WSInfo)selectedItem.Tag).businessKey;
                    
                    DispositionReport dispositionReport = performDeleteBusiness(businessKey);
                    
                    MessageBox.Show(dispositionReport.Results[0].ErrInfo.ErrCode);

                    foreach (ListViewItem listViewItem in listView.Items) {

                        if (((WSInfo)listViewItem.Tag).businessKey == businessKey) {

                            listView.Items.Remove(listViewItem);
                        }
                    }
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
        ///     Sterge un anumit grup de servicii atat din lista cu servicii cat si de pe serverul UDDI.
        /// </summary>
        private void deleteService() {
       
            if (listView.SelectedItems.Count > 0) {
 
                try {

                    selectedItem = listView.SelectedItems[0];
                    
                    String serviceKey = ((WSInfo)selectedItem.Tag).serviceKey;
                    
                    DispositionReport dispositionReport = performDeleteService(serviceKey);                   
                    
                    MessageBox.Show(dispositionReport.Results[0].ErrInfo.ErrCode);

                    foreach (ListViewItem listViewItem in listView.Items) {

                        if (((WSInfo)listViewItem.Tag).serviceKey == serviceKey) {

                            listView.Items.Remove(listViewItem);
                        }
                    }
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
        ///     Sterge un anumit serviciu atat din lista cu servicii cat si de pe serverul UDDI.
        /// </summary>
        private void deleteBinding() {

            if (listView.SelectedItems.Count > 0) {

                try {

                    selectedItem = listView.SelectedItems[0];
                    
                    String bindingKey = ((WSInfo)selectedItem.Tag).bindingKey;
                   
                    DispositionReport dispositionReport = performDeleteBinding(bindingKey);
                    
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
        ///   Modifica URL-ului unui anumit serviciu din lista cu servicii.
        ///   Deschide o fereastra pentru completarea noii valori.
        /// </summary>
        private void updateBinding() {  
            
            if (listView.SelectedItems.Count > 0) {

                try {  

                    selectedItem  = listView.SelectedItems[0];

                    WSInfo wsInfo = (WSInfo)selectedItem.Tag;

                    UpdateForm updateForm    = new UpdateForm(selectedItem.SubItems[4].Text);

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
        ///   Modifica valoarea pe serverul UDDI si in lista de servicii.
        /// </summary>
        void updateForm_ValueUpdated(object sender, ValueUpdateEventArgs e) {

                GetBindingDetail getBindingDetail = new GetBindingDetail(((WSInfo)selectedItem.Tag).bindingKey);
                
                BindingDetail bindingDetail       = getBindingDetail.Send(uddiConnection);

                BindingTemplate bindingTemplate   = bindingDetail.BindingTemplates[0];

                bindingTemplate.AccessPoint.Text  = e.NewValue;

                SaveBinding saveBinding = new SaveBinding(bindingTemplate);

                saveBinding.Send(uddiConnection);

                selectedItem.SubItems[4].Text    = e.NewValue;
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru cautarea de servicii pe baza informatiilor specificate in campurile corespunzatoare.
        ///   In functie de optiunile legate de ontologie construieste lista atributelor esentiale cirespunzatoare (necesara pentru cautarea de servicii).
        /// </summary>
        private void searchButton_Click(object sender, EventArgs e) {
            
            if (chkUseOntology.Checked == true) {
                
                int index = cbxOntology.SelectedIndex;

                if (index == 0) {

                    int count = cbxOntology.Items.Count - 1;

                    ontologyAttributes = new String[2*count];

                    for (int i = 0; i < count; ++i) {

                        ontologyAttributes[2*i]   = ((List<OntInfo>)cbxOntology.Tag)[i].tModelKey;
                        ontologyAttributes[2*i+1] = ((List<OntInfo>)cbxOntology.Tag)[i].ontologyName;
                    }
                   
                    performSearch();
                }
                else {

                    ontologyAttributes = new String[2];

                    ontologyAttributes[0] = ((List<OntInfo>)cbxOntology.Tag)[index - 1].tModelKey;
                    ontologyAttributes[1] = ((List<OntInfo>)cbxOntology.Tag)[index - 1].ontologyName;

                    performSearch();
                }    
            }
            else {

                ontologyAttributes = null;

                performSearch();
            } 
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru stergerea unui anumit domeniu de grupuri de servicii.
        /// </summary>
        private void deleteBusiness_Click(object sender, EventArgs e){

            deleteBusiness();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru stergerea unui anumit grup de servicii.
        /// </summary>
        private void deleteService_Click(object sender, EventArgs e) {

            deleteService();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru stergerea unui anumit serviciu.
        /// </summary>
        private void deleteBinding_Click(object sender, EventArgs e) {

            deleteBinding();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru modificarea URL-ului corespunzator unui anumit serviciu.
        /// </summary>
        private void updateBinding_Click(object sender, EventArgs e) {

            updateBinding();
        }
    }
}
