namespace UDDIConnector {

    partial class PublishOntologyForm {

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
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBoxTmodel = new System.Windows.Forms.GroupBox();
            this.txbOntologyURL = new System.Windows.Forms.TextBox();
            this.lblOntologyURL = new System.Windows.Forms.Label();
            this.txbOntologyName = new System.Windows.Forms.TextBox();
            this.lblOntologylName = new System.Windows.Forms.Label();
            this.groupBoxTmodel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(98, 117);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(52, 23);
            this.btnPublish.TabIndex = 3;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(21, 117);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(62, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBoxTmodel
            // 
            this.groupBoxTmodel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTmodel.Controls.Add(this.txbOntologyURL);
            this.groupBoxTmodel.Controls.Add(this.lblOntologyURL);
            this.groupBoxTmodel.Controls.Add(this.txbOntologyName);
            this.groupBoxTmodel.Controls.Add(this.lblOntologylName);
            this.groupBoxTmodel.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTmodel.Name = "groupBoxTmodel";
            this.groupBoxTmodel.Size = new System.Drawing.Size(487, 87);
            this.groupBoxTmodel.TabIndex = 1;
            this.groupBoxTmodel.TabStop = false;
            this.groupBoxTmodel.Text = "Ontology";
            // 
            // txbOntologyURL
            // 
            this.txbOntologyURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbOntologyURL.Location = new System.Drawing.Point(86, 53);
            this.txbOntologyURL.Name = "txbOntologyURL";
            this.txbOntologyURL.Size = new System.Drawing.Size(383, 20);
            this.txbOntologyURL.TabIndex = 2;
            // 
            // lblOntologyURL
            // 
            this.lblOntologyURL.AutoSize = true;
            this.lblOntologyURL.Location = new System.Drawing.Point(6, 56);
            this.lblOntologyURL.Name = "lblOntologyURL";
            this.lblOntologyURL.Size = new System.Drawing.Size(32, 13);
            this.lblOntologyURL.TabIndex = 7;
            this.lblOntologyURL.Text = "URL:";
            // 
            // txbOntologyName
            // 
            this.txbOntologyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbOntologyName.Location = new System.Drawing.Point(86, 21);
            this.txbOntologyName.Name = "txbOntologyName";
            this.txbOntologyName.Size = new System.Drawing.Size(226, 20);
            this.txbOntologyName.TabIndex = 1;
            // 
            // lblOntologylName
            // 
            this.lblOntologylName.AutoSize = true;
            this.lblOntologylName.Location = new System.Drawing.Point(6, 24);
            this.lblOntologylName.Name = "lblOntologylName";
            this.lblOntologylName.Size = new System.Drawing.Size(38, 13);
            this.lblOntologylName.TabIndex = 4;
            this.lblOntologylName.Text = "Name:";
            // 
            // PublishOntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 146);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBoxTmodel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 180);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(525, 180);
            this.Name = "PublishOntologyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publish Ontology";
            this.groupBoxTmodel.ResumeLayout(false);
            this.groupBoxTmodel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBoxTmodel;
        private System.Windows.Forms.TextBox txbOntologyURL;
        private System.Windows.Forms.Label lblOntologyURL;
        private System.Windows.Forms.TextBox txbOntologyName;
        private System.Windows.Forms.Label lblOntologylName;
    }
}