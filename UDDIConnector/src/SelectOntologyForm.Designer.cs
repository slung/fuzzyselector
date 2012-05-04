namespace UDDIConnector {

    partial class SelectOntologyForm {

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
            this.lblNewValue = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbxOntologies = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblNewValue
            // 
            this.lblNewValue.AutoSize = true;
            this.lblNewValue.Location = new System.Drawing.Point(12, 9);
            this.lblNewValue.Name = "lblNewValue";
            this.lblNewValue.Size = new System.Drawing.Size(55, 13);
            this.lblNewValue.TabIndex = 0;
            this.lblNewValue.Text = "Ontology :";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(47, 79);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbxOntologies
            // 
            this.cbxOntologies.FormattingEnabled = true;
            this.cbxOntologies.Location = new System.Drawing.Point(7, 35);
            this.cbxOntologies.Name = "cbxOntologies";
            this.cbxOntologies.Size = new System.Drawing.Size(159, 21);
            this.cbxOntologies.TabIndex = 3;
            // 
            // SelectOntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 116);
            this.Controls.Add(this.cbxOntologies);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblNewValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectOntologyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Ontology";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxOntologies;
    }
}