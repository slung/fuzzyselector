namespace UDDIConnector {

    partial class PublishServiceForm {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelBusinessName = new System.Windows.Forms.Label();
            this.txbBusinessName = new System.Windows.Forms.TextBox();
            this.groupBoxBusiness = new System.Windows.Forms.GroupBox();
            this.labelServiceName = new System.Windows.Forms.Label();
            this.txbServiceName = new System.Windows.Forms.TextBox();
            this.groupBoxService = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.groupBoxBinding = new System.Windows.Forms.GroupBox();
            this.cbxOntology = new System.Windows.Forms.ComboBox();
            this.lblOntology = new System.Windows.Forms.Label();
            this.txbAccessPoint = new System.Windows.Forms.TextBox();
            this.lblAccessPoint = new System.Windows.Forms.Label();
            this.groupBoxBusiness.SuspendLayout();
            this.groupBoxService.SuspendLayout();
            this.groupBoxBinding.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBusinessName
            // 
            this.labelBusinessName.AutoSize = true;
            this.labelBusinessName.Location = new System.Drawing.Point(6, 23);
            this.labelBusinessName.Name = "labelBusinessName";
            this.labelBusinessName.Size = new System.Drawing.Size(41, 13);
            this.labelBusinessName.TabIndex = 4;
            this.labelBusinessName.Text = "Name :";
            // 
            // txbBusinessName
            // 
            this.txbBusinessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbBusinessName.Location = new System.Drawing.Point(87, 20);
            this.txbBusinessName.Name = "txbBusinessName";
            this.txbBusinessName.Size = new System.Drawing.Size(323, 20);
            this.txbBusinessName.TabIndex = 1;
            // 
            // groupBoxBusiness
            // 
            this.groupBoxBusiness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBusiness.Controls.Add(this.txbBusinessName);
            this.groupBoxBusiness.Controls.Add(this.labelBusinessName);
            this.groupBoxBusiness.Location = new System.Drawing.Point(11, 12);
            this.groupBoxBusiness.Name = "groupBoxBusiness";
            this.groupBoxBusiness.Size = new System.Drawing.Size(424, 57);
            this.groupBoxBusiness.TabIndex = 1;
            this.groupBoxBusiness.TabStop = false;
            this.groupBoxBusiness.Text = "Business";
            // 
            // labelServiceName
            // 
            this.labelServiceName.AutoSize = true;
            this.labelServiceName.Location = new System.Drawing.Point(6, 24);
            this.labelServiceName.Name = "labelServiceName";
            this.labelServiceName.Size = new System.Drawing.Size(41, 13);
            this.labelServiceName.TabIndex = 4;
            this.labelServiceName.Text = "Name :";
            // 
            // txbServiceName
            // 
            this.txbServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbServiceName.Location = new System.Drawing.Point(87, 21);
            this.txbServiceName.Name = "txbServiceName";
            this.txbServiceName.Size = new System.Drawing.Size(323, 20);
            this.txbServiceName.TabIndex = 2;
            // 
            // groupBoxService
            // 
            this.groupBoxService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxService.Controls.Add(this.txbServiceName);
            this.groupBoxService.Controls.Add(this.labelServiceName);
            this.groupBoxService.Location = new System.Drawing.Point(11, 82);
            this.groupBoxService.Name = "groupBoxService";
            this.groupBoxService.Size = new System.Drawing.Size(424, 57);
            this.groupBoxService.TabIndex = 2;
            this.groupBoxService.TabStop = false;
            this.groupBoxService.Text = "Service";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(20, 281);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(62, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(98, 281);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(52, 23);
            this.btnPublish.TabIndex = 5;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // groupBoxBinding
            // 
            this.groupBoxBinding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBinding.Controls.Add(this.cbxOntology);
            this.groupBoxBinding.Controls.Add(this.lblOntology);
            this.groupBoxBinding.Controls.Add(this.txbAccessPoint);
            this.groupBoxBinding.Controls.Add(this.lblAccessPoint);
            this.groupBoxBinding.Location = new System.Drawing.Point(12, 151);
            this.groupBoxBinding.Name = "groupBoxBinding";
            this.groupBoxBinding.Size = new System.Drawing.Size(424, 114);
            this.groupBoxBinding.TabIndex = 3;
            this.groupBoxBinding.TabStop = false;
            this.groupBoxBinding.Text = "Binding";
            // 
            // cbxOntology
            // 
            this.cbxOntology.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxOntology.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOntology.FormattingEnabled = true;
            this.cbxOntology.Location = new System.Drawing.Point(87, 68);
            this.cbxOntology.Name = "cbxOntology";
            this.cbxOntology.Size = new System.Drawing.Size(322, 21);
            this.cbxOntology.TabIndex = 4;
            // 
            // lblOntology
            // 
            this.lblOntology.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOntology.Location = new System.Drawing.Point(6, 71);
            this.lblOntology.Name = "lblOntology";
            this.lblOntology.Size = new System.Drawing.Size(136, 13);
            this.lblOntology.TabIndex = 24;
            this.lblOntology.Text = "Ontology :";
            // 
            // txbAccessPoint
            // 
            this.txbAccessPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAccessPoint.Location = new System.Drawing.Point(87, 25);
            this.txbAccessPoint.Name = "txbAccessPoint";
            this.txbAccessPoint.Size = new System.Drawing.Size(322, 20);
            this.txbAccessPoint.TabIndex = 3;
            // 
            // lblAccessPoint
            // 
            this.lblAccessPoint.AutoSize = true;
            this.lblAccessPoint.Location = new System.Drawing.Point(6, 28);
            this.lblAccessPoint.Name = "lblAccessPoint";
            this.lblAccessPoint.Size = new System.Drawing.Size(75, 13);
            this.lblAccessPoint.TabIndex = 7;
            this.lblAccessPoint.Text = "Access Point :";
            // 
            // PublishServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 311);
            this.Controls.Add(this.groupBoxBinding);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBoxService);
            this.Controls.Add(this.groupBoxBusiness);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 345);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(455, 345);
            this.Name = "PublishServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publish Service";
            this.groupBoxBusiness.ResumeLayout(false);
            this.groupBoxBusiness.PerformLayout();
            this.groupBoxService.ResumeLayout(false);
            this.groupBoxService.PerformLayout();
            this.groupBoxBinding.ResumeLayout(false);
            this.groupBoxBinding.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBusinessName;
        private System.Windows.Forms.TextBox txbBusinessName;
        private System.Windows.Forms.GroupBox groupBoxBusiness;
        private System.Windows.Forms.Label labelServiceName;
        private System.Windows.Forms.TextBox txbServiceName;
        private System.Windows.Forms.GroupBox groupBoxService;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.GroupBox groupBoxBinding;
        private System.Windows.Forms.TextBox txbAccessPoint;
        private System.Windows.Forms.Label lblAccessPoint;
        private System.Windows.Forms.ComboBox cbxOntology;
        private System.Windows.Forms.Label lblOntology;
    }
}