namespace UDDIConnector.src
{
    partial class OntologyCompositionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvParticpatingWebServices = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.WSDL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WSDL_URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticpatingWebServices)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add participating ontologies (web services):";
            // 
            // dgvParticpatingWebServices
            // 
            this.dgvParticpatingWebServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticpatingWebServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WSDL,
            this.WSDL_URL});
            this.dgvParticpatingWebServices.Location = new System.Drawing.Point(15, 39);
            this.dgvParticpatingWebServices.Name = "dgvParticpatingWebServices";
            this.dgvParticpatingWebServices.ReadOnly = true;
            this.dgvParticpatingWebServices.Size = new System.Drawing.Size(643, 150);
            this.dgvParticpatingWebServices.TabIndex = 1;
            this.dgvParticpatingWebServices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParticpatingWebServices_CellClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "XML files|*.xml";
            // 
            // WSDL
            // 
            this.WSDL.HeaderText = "Web Service Path";
            this.WSDL.Name = "WSDL";
            this.WSDL.ReadOnly = true;
            this.WSDL.Text = "File...";
            this.WSDL.ToolTipText = "Choose WSDL path of Web Service";
            this.WSDL.UseColumnTextForButtonValue = true;
            // 
            // WSDL_URL
            // 
            this.WSDL_URL.HeaderText = "WSDL URL";
            this.WSDL_URL.Name = "WSDL_URL";
            this.WSDL_URL.ReadOnly = true;
            this.WSDL_URL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WSDL_URL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WSDL_URL.Width = 500;
            // 
            // OntologyCompositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 468);
            this.Controls.Add(this.dgvParticpatingWebServices);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "OntologyCompositionForm";
            this.Text = "Ontology Composition";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticpatingWebServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvParticpatingWebServices;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewButtonColumn WSDL;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSDL_URL;
    }
}