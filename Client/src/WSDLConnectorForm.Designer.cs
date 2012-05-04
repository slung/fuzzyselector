namespace FuzzySelector.Client
{

    partial class WSDLConnectorForm
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInvoke = new System.Windows.Forms.TabPage();
            this.trvParameters = new System.Windows.Forms.TreeView();
            this.trvMethods = new System.Windows.Forms.TreeView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.lblMethods = new System.Windows.Forms.Label();
            this.btnInvoke = new System.Windows.Forms.Button();
            this.lblParameters = new System.Windows.Forms.Label();
            this.tabPageMessage = new System.Windows.Forms.TabPage();
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.grbWSDLAddress = new System.Windows.Forms.GroupBox();
            this.txbWSDLAddress = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageInvoke.SuspendLayout();
            this.tabPageMessage.SuspendLayout();
            this.grbWSDLAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInvoke);
            this.tabControl.Controls.Add(this.tabPageMessage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Location = new System.Drawing.Point(5, 62);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(642, 348);
            this.tabControl.TabIndex = 12;
            // 
            // tabPageInvoke
            // 
            this.tabPageInvoke.Controls.Add(this.trvParameters);
            this.tabPageInvoke.Controls.Add(this.trvMethods);
            this.tabPageInvoke.Controls.Add(this.progressBar);
            this.tabPageInvoke.Controls.Add(this.propertyGrid);
            this.tabPageInvoke.Controls.Add(this.lblMethods);
            this.tabPageInvoke.Controls.Add(this.btnInvoke);
            this.tabPageInvoke.Controls.Add(this.lblParameters);
            this.tabPageInvoke.Location = new System.Drawing.Point(4, 22);
            this.tabPageInvoke.Name = "tabPageInvoke";
            this.tabPageInvoke.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInvoke.Size = new System.Drawing.Size(634, 322);
            this.tabPageInvoke.TabIndex = 0;
            this.tabPageInvoke.Text = "Invoke";
            this.tabPageInvoke.UseVisualStyleBackColor = true;
            // 
            // trvParameters
            // 
            this.trvParameters.Location = new System.Drawing.Point(212, 27);
            this.trvParameters.Name = "trvParameters";
            this.trvParameters.Size = new System.Drawing.Size(196, 270);
            this.trvParameters.TabIndex = 39;
            this.trvParameters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvParameters_AfterSelect);
            // 
            // trvMethods
            // 
            this.trvMethods.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.trvMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.trvMethods.ItemHeight = 20;
            this.trvMethods.Location = new System.Drawing.Point(11, 27);
            this.trvMethods.Name = "trvMethods";
            this.trvMethods.Size = new System.Drawing.Size(181, 270);
            this.trvMethods.TabIndex = 38;
            this.trvMethods.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMethods_AfterSelect);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(423, 253);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(195, 19);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 34;
            this.progressBar.Visible = false;
            // 
            // propertyGrid
            // 
            this.propertyGrid.CausesValidation = false;
            this.propertyGrid.Location = new System.Drawing.Point(423, 27);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid.Size = new System.Drawing.Size(195, 162);
            this.propertyGrid.TabIndex = 33;
            // 
            // lblMethods
            // 
            this.lblMethods.AutoSize = true;
            this.lblMethods.Location = new System.Drawing.Point(8, 11);
            this.lblMethods.Name = "lblMethods";
            this.lblMethods.Size = new System.Drawing.Size(54, 13);
            this.lblMethods.TabIndex = 32;
            this.lblMethods.Text = "Methods :";
            // 
            // btnInvoke
            // 
            this.btnInvoke.Enabled = false;
            this.btnInvoke.Location = new System.Drawing.Point(423, 224);
            this.btnInvoke.Name = "btnInvoke";
            this.btnInvoke.Size = new System.Drawing.Size(195, 23);
            this.btnInvoke.TabIndex = 31;
            this.btnInvoke.Text = "Invoke";
            this.btnInvoke.UseVisualStyleBackColor = true;
            this.btnInvoke.Click += new System.EventHandler(this.btnInvoke_Click);
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Location = new System.Drawing.Point(209, 11);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(66, 13);
            this.lblParameters.TabIndex = 28;
            this.lblParameters.Text = "Parameters :";
            // 
            // tabPageMessage
            // 
            this.tabPageMessage.BackColor = System.Drawing.Color.Transparent;
            this.tabPageMessage.Controls.Add(this.txbMessage);
            this.tabPageMessage.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessage.Name = "tabPageMessage";
            this.tabPageMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMessage.Size = new System.Drawing.Size(634, 322);
            this.tabPageMessage.TabIndex = 1;
            this.tabPageMessage.Text = "Message";
            // 
            // txbMessage
            // 
            this.txbMessage.AllowDrop = true;
            this.txbMessage.BackColor = System.Drawing.Color.White;
            this.txbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbMessage.Location = new System.Drawing.Point(3, 3);
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.ReadOnly = true;
            this.txbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbMessage.Size = new System.Drawing.Size(628, 316);
            this.txbMessage.TabIndex = 0;
            // 
            // grbWSDLAddress
            // 
            this.grbWSDLAddress.Controls.Add(this.txbWSDLAddress);
            this.grbWSDLAddress.Controls.Add(this.btnGet);
            this.grbWSDLAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbWSDLAddress.Location = new System.Drawing.Point(5, 5);
            this.grbWSDLAddress.Name = "grbWSDLAddress";
            this.grbWSDLAddress.Size = new System.Drawing.Size(642, 49);
            this.grbWSDLAddress.TabIndex = 13;
            this.grbWSDLAddress.TabStop = false;
            this.grbWSDLAddress.Text = "WSDL Address";
            // 
            // txbWSDLAddress
            // 
            this.txbWSDLAddress.Location = new System.Drawing.Point(15, 19);
            this.txbWSDLAddress.Name = "txbWSDLAddress";
            this.txbWSDLAddress.Size = new System.Drawing.Size(394, 20);
            this.txbWSDLAddress.TabIndex = 1;
            this.txbWSDLAddress.TextChanged += new System.EventHandler(this.txbWSDLAddress_TextChanged);
            // 
            // btnGet
            // 
            this.btnGet.Enabled = false;
            this.btnGet.Location = new System.Drawing.Point(427, 19);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(195, 20);
            this.btnGet.TabIndex = 11;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // WSDLReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 415);
            this.Controls.Add(this.grbWSDLAddress);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.Name = "WSDLReaderForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WSDL Connector";
            this.tabControl.ResumeLayout(false);
            this.tabPageInvoke.ResumeLayout(false);
            this.tabPageInvoke.PerformLayout();
            this.tabPageMessage.ResumeLayout(false);
            this.tabPageMessage.PerformLayout();
            this.grbWSDLAddress.ResumeLayout(false);
            this.grbWSDLAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageInvoke;
        private System.Windows.Forms.Label lblMethods;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Button btnInvoke;
        private System.Windows.Forms.TabPage tabPageMessage;
        private System.Windows.Forms.TextBox txbMessage;
        private System.Windows.Forms.GroupBox grbWSDLAddress;
        private System.Windows.Forms.TextBox txbWSDLAddress;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TreeView trvParameters;
        private System.Windows.Forms.TreeView trvMethods;
    }
}

