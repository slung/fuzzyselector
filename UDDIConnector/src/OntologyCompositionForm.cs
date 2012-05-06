using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Uddi;

namespace UDDIConnector.src
{
    public partial class OntologyCompositionForm : Form
    {
        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;

        public OntologyCompositionForm(UddiConnection uddiConnection)
        {
            this.uddiConnection = uddiConnection;

            InitializeComponent();
        }

        void btnFileDialog_click(object sender, EventArgs e)
        {
            int col = this.dgvParticpatingWebServices.CurrentCell.ColumnIndex;
            int row = this.dgvParticpatingWebServices.CurrentCell.RowIndex;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.dgvParticpatingWebServices[col + 1, row].Value = openFileDialog.FileName;
            }
        }

        private void dgvParticpatingWebServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                this.btnFileDialog_click(sender, e);
            }
        }
    }
}
