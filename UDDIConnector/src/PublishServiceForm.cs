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
using Microsoft.Uddi.TModels;

namespace UDDIConnector {

    /// <summary>
    ///   Fereastra folosita pentru publicarea unui nou serviciu.
    /// </summary>
    public partial class PublishServiceForm : Form {

        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;

        /// <summary>
        ///   Lista tuturor ontologiilor de pe serverul UDDI.
        /// </summary>
        private List<OntInfo> ontologyList;

        public PublishServiceForm(UddiConnection uddiConnection) {

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

                cbxOntology.Items.Add("None");
                
                cbxOntology.SelectedIndex = 0;
                
                SearchOntology searchOntology = new SearchOntology(uddiConnection);
               
                ontologyList = searchOntology.search();

                if (ontologyList != null) {

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
        ///   Publica serviciul cu informatiile specificate in campurile corespunzatoare (daca nu exista deja).
        /// </summary>
        public void performPublish() {

            String businessName = txbBusinessName.Text.Trim();
            String serviceName  = txbServiceName.Text.Trim();
            String accessPoint  = txbAccessPoint.Text.Trim();

            if (businessName == String.Empty || serviceName == String.Empty || accessPoint == String.Empty) {
                
                MessageBox.Show("All values must be set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {

                FindBusiness findBusiness = new FindBusiness(businessName);
  
                findBusiness.FindQualifiers.Add(FindQualifier.ExactNameMatch);
               
                BusinessList businessList = findBusiness.Send(uddiConnection);

                if (0 == businessList.BusinessInfos.Count) {

                    BusinessEntity newBusinessEntity   = new BusinessEntity(businessName);

                    BusinessService newBusinessService = new BusinessService(serviceName);
                   
                    newBusinessEntity.BusinessServices.Add(newBusinessService);

                    BindingTemplate newBindingTemplate = new BindingTemplate();

                    newBindingTemplate.AccessPoint.Text    = accessPoint;
                    newBindingTemplate.AccessPoint.UrlType = UrlType.Http;

                    selectOntologyForNewBindingTemplate(newBindingTemplate);

                    newBusinessService.BindingTemplates.Add(newBindingTemplate);

                    SaveBusiness saveNewBusiness = new SaveBusiness(newBusinessEntity);

                    saveNewBusiness.Send(uddiConnection);
                }
                else {

                    MessageBox.Show("Business already exists");

                    GetBusinessDetail getBusinessDetail = new GetBusinessDetail(businessList.BusinessInfos[0].BusinessKey);

                    BusinessDetail businessDetail    = getBusinessDetail.Send(uddiConnection);

                    BusinessEntity oldBusinessEntity = businessDetail.BusinessEntities[0];
                    
                    FindService findService = new FindService(serviceName);

                    findService.FindQualifiers.Add(FindQualifier.ExactNameMatch);

                    findService.BusinessKey = businessDetail.BusinessEntities[0].BusinessKey;
                  
                    ServiceList serviceList = findService.Send(uddiConnection);

                    if (0 == serviceList.ServiceInfos.Count) {

                        BusinessService newBusinessService     = new BusinessService(serviceName);
                       
                        oldBusinessEntity.BusinessServices.Add(newBusinessService);
                        
                        BindingTemplate newBindingTemplate     = new BindingTemplate();

                        newBindingTemplate.AccessPoint.Text    = accessPoint;
                        newBindingTemplate.AccessPoint.UrlType = UrlType.Http;

                        selectOntologyForNewBindingTemplate(newBindingTemplate);

                        newBusinessService.BindingTemplates.Add(newBindingTemplate);

                        SaveBusiness saveOldBusiness = new SaveBusiness(oldBusinessEntity);

                        saveOldBusiness.Send(uddiConnection);
                    }
                    else {

                        MessageBox.Show("Service already exists");

                        GetServiceDetail getServiceDetail  = new GetServiceDetail(serviceList.ServiceInfos[0].ServiceKey);

                        ServiceDetail serviceDetail        = getServiceDetail.Send(uddiConnection);

                        BusinessService oldBusinessService = serviceDetail.BusinessServices[0];

                        foreach (BindingTemplate bindingTemplate in oldBusinessService.BindingTemplates) {

                            if (bindingTemplate.AccessPoint.Text == accessPoint) {
                                
                                MessageBox.Show("Binding already exists");
                                return;
                            }
                        }

                        BindingTemplate newBindingTemplate     = new BindingTemplate();

                        newBindingTemplate.AccessPoint.Text    = accessPoint;
                        newBindingTemplate.AccessPoint.UrlType = UrlType.Http;

                        selectOntologyForNewBindingTemplate(newBindingTemplate);
                        
                        oldBusinessService.BindingTemplates.Add(newBindingTemplate);

                        SaveService saveOldService = new SaveService(oldBusinessService);

                        saveOldService.Send(uddiConnection);
                    }
                }

                MessageBox.Show("Publish successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UddiException e) {

                MessageBox.Show("Uddi error: "+ e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e){

                MessageBox.Show("General exception: " + e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///   Stabileste ontologia (daca este specificata) pentru serviciul ce urmeza a fi publicat.
        /// </summary>
        /// <param name="newBindingTemplate">Serviciul (accessPoint) ce urmeaza a fi publicat.</param>
        private void selectOntologyForNewBindingTemplate(BindingTemplate newBindingTemplate) {

            if( cbxOntology.SelectedIndex > 0 ) {
         
                TModelInstanceInfo tModelInstanceInfo = new TModelInstanceInfo();
                tModelInstanceInfo.TModelKey = ((List < OntInfo >)cbxOntology.Tag)[cbxOntology.SelectedIndex - 1].tModelKey;

                newBindingTemplate.TModelInstanceInfos.Add(tModelInstanceInfo);
            }
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru golirea campurilor folosite pentru completarea informatiilor.
        ///   Goleste campurile folosite pentru completarea informatiilor.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e) {

            txbBusinessName.Clear();
            txbServiceName.Clear();
            txbAccessPoint.Clear();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru publicarea unui serviciu cu informatiile specificate in campurile corespunzatoare.
        ///   Publica serviciul (daca nu exista deja).
        /// </summary>
        private void btnPublish_Click(object sender, EventArgs e) {

            performPublish();
        }
    }
}
