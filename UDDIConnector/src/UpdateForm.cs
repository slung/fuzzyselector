using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UDDIConnector {

    /// <summary>
    ///   Fereastra in care se o noua valoare.
    /// </summary>
    public partial class UpdateForm : Form {

        // <summary>
        ///  Tipul callback-ului folosit după ce un noua valoare a fost specificata.
        /// </summary>
        public delegate void ValueUpdateHandler(object sender, ValueUpdateEventArgs e);

        /// <summary>
        ///  Callback-ului folosit după ce un noua valoare a fost specificata.
        /// </summary>
        public event ValueUpdateHandler valueUpdated;

        /// <summary>
        ///  Valoarea ce urmeaza a fi modificata.
        /// </summary>
        private string value;
        
        public UpdateForm(string value) {

            InitializeComponent();

            this.value = value;

            txbNewValue.Text = value;
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru confirmarea noii valori.
        ///   Preia informatia completata, apeleaza callback-ul specificat si inchide fereastra.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e) {

            string newValue = txbNewValue.Text.Trim();
            
            if (newValue == String.Empty ) {

                MessageBox.Show("New value must be set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ( value == newValue ) {

                MessageBox.Show("Value is the same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            ValueUpdateEventArgs args = new ValueUpdateEventArgs(newValue);

            valueUpdated(this, args);

            this.Dispose();
        }
    }

    /// <summary>
    ///   Clasa folosita pentru stocarea/trimiterea noilor informatii specificate in UpdateForm .
    /// </summary>
    public class ValueUpdateEventArgs : EventArgs {

        /// <summary>
        ///   Noua valoare specificata in UpdateForm. 
        /// </summary>
        private string newValue;
   
        public ValueUpdateEventArgs(string newValue) {

            this.newValue = newValue;
        }

        public string NewValue { 
            
            get { 
                
                return newValue;
            } 
        }
    }
}
