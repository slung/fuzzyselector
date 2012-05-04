using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Uddi;

namespace UDDIConnector {

    public partial class SelectOntologyForm : Form {

        public delegate void PassTmodelKey(string value);

        public PassTmodelKey passTmodelKey;
        
        public SelectOntologyForm(List<OntInfo> ontologyList) {

            InitializeComponent();

            cbxOntologies.Tag=ontologyList;

            cbxOntologies.Items.Add("none");

            foreach (OntInfo ontInfo in ontologyList) {
                cbxOntologies.Items.Add(ontInfo.ontologyName);
            }

            cbxOntologies.SelectedIndex = 0;
        }
     
        private void btnOK_Click(object sender, EventArgs e) {
            
            int index = cbxOntologies.SelectedIndex;
            
            if (index == 0) {
                passTmodelKey(String.Empty);
            }
            else {
                passTmodelKey(((List<OntInfo>)cbxOntologies.Tag)[index-1].tModelKey);
            }
        }
    }
}
