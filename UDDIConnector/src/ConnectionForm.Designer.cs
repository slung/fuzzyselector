namespace UDDIConnector {

    partial class ConnectionForm {

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
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txbPublishURL = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblPublishURL = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.txbInquireURL = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.lblInquireURL = new System.Windows.Forms.Label();
            this.btnOK1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxConnection.Controls.Add(this.btnSave);
            this.groupBoxConnection.Controls.Add(this.txbPublishURL);
            this.groupBoxConnection.Controls.Add(this.btnClear);
            this.groupBoxConnection.Controls.Add(this.btnLoad);
            this.groupBoxConnection.Controls.Add(this.lblPublishURL);
            this.groupBoxConnection.Controls.Add(this.txbPassword);
            this.groupBoxConnection.Controls.Add(this.txbUsername);
            this.groupBoxConnection.Controls.Add(this.txbInquireURL);
            this.groupBoxConnection.Controls.Add(this.labelPassword);
            this.groupBoxConnection.Controls.Add(this.labelUsername);
            this.groupBoxConnection.Controls.Add(this.lblInquireURL);
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(401, 180);
            this.groupBoxConnection.TabIndex = 0;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection info";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(189, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbPublishURL
            // 
            this.txbPublishURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPublishURL.Location = new System.Drawing.Point(91, 52);
            this.txbPublishURL.Name = "txbPublishURL";
            this.txbPublishURL.Size = new System.Drawing.Size(285, 20);
            this.txbPublishURL.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(243, 141);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(51, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(127, 141);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(53, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblPublishURL
            // 
            this.lblPublishURL.AutoSize = true;
            this.lblPublishURL.Location = new System.Drawing.Point(16, 55);
            this.lblPublishURL.Name = "lblPublishURL";
            this.lblPublishURL.Size = new System.Drawing.Size(69, 13);
            this.lblPublishURL.TabIndex = 8;
            this.lblPublishURL.Text = "Publish URL:";
            // 
            // txbPassword
            // 
            this.txbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPassword.Location = new System.Drawing.Point(91, 104);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(285, 20);
            this.txbPassword.TabIndex = 4;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // txbUsername
            // 
            this.txbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbUsername.Location = new System.Drawing.Point(91, 78);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(285, 20);
            this.txbUsername.TabIndex = 3;
            // 
            // txbInquireURL
            // 
            this.txbInquireURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txbInquireURL.Location = new System.Drawing.Point(91, 26);
            this.txbInquireURL.Name = "txbInquireURL";
            this.txbInquireURL.Size = new System.Drawing.Size(285, 20);
            this.txbInquireURL.TabIndex = 1;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(16, 107);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(16, 81);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username:";
            // 
            // lblInquireURL
            // 
            this.lblInquireURL.AutoSize = true;
            this.lblInquireURL.Location = new System.Drawing.Point(16, 29);
            this.lblInquireURL.Name = "lblInquireURL";
            this.lblInquireURL.Size = new System.Drawing.Size(67, 13);
            this.lblInquireURL.TabIndex = 0;
            this.lblInquireURL.Text = "Inquire URL:";
            // 
            // btnOK1
            // 
            this.btnOK1.Location = new System.Drawing.Point(201, 209);
            this.btnOK1.Name = "btnOK1";
            this.btnOK1.Size = new System.Drawing.Size(48, 23);
            this.btnOK1.TabIndex = 9;
            this.btnOK1.Text = "OK";
            this.btnOK1.UseVisualStyleBackColor = true;
            this.btnOK1.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(139, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(53, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 241);
            this.Controls.Add(this.btnOK1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBoxConnection);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 275);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(435, 275);
            this.Name = "ConnectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDDI Connection";
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label lblInquireURL;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.TextBox txbInquireURL;
        private System.Windows.Forms.Button btnOK1;
        private System.Windows.Forms.TextBox txbPublishURL;
        private System.Windows.Forms.Label lblPublishURL;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
    }
}