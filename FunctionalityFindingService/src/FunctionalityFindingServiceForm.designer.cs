namespace FuzzySelector.FunctionalityFindingService
{
    partial class FunctionalityFindingServiceForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionalityFindingServiceForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuStartService = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEndProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.groupBoxUDDI = new System.Windows.Forms.GroupBox();
            this.txtAdressUDDI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateServ = new System.Windows.Forms.Button();
            this.btnUpdateFunc = new System.Windows.Forms.Button();
            this.gbDOS = new System.Windows.Forms.GroupBox();
            this.lblPortDOS = new System.Windows.Forms.Label();
            this.txtAdressDOS = new System.Windows.Forms.TextBox();
            this.lblAdressDOS = new System.Windows.Forms.Label();
            this.nudPortDOS = new System.Windows.Forms.NumericUpDown();
            this.gbFilterFunctionality = new System.Windows.Forms.GroupBox();
            this.cboFilterFunctionality = new System.Windows.Forms.ComboBox();
            this.gbPort = new System.Windows.Forms.GroupBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.gbServices = new System.Windows.Forms.GroupBox();
            this.lbServices = new System.Windows.Forms.ListBox();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.lbProperties = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.trayContextMenuStrip.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.groupBoxUDDI.SuspendLayout();
            this.gbDOS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortDOS)).BeginInit();
            this.gbFilterFunctionality.SuspendLayout();
            this.gbPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.gbServices.SuspendLayout();
            this.gbProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Functionality Finding Service";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // trayContextMenuStrip
            // 
            this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartService,
            this.mnuSeparator1,
            this.mnuRestore,
            this.mnuSeparator2,
            this.mnuSettings,
            this.mnuSeparator3,
            this.mnuEndProgram});
            this.trayContextMenuStrip.Name = "trayContextMenuStrip";
            this.trayContextMenuStrip.Size = new System.Drawing.Size(190, 110);
            // 
            // mnuStartService
            // 
            this.mnuStartService.Name = "mnuStartService";
            this.mnuStartService.Size = new System.Drawing.Size(189, 22);
            this.mnuStartService.Text = "&Start Service";
            this.mnuStartService.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // mnuSeparator1
            // 
            this.mnuSeparator1.Name = "mnuSeparator1";
            this.mnuSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuRestore
            // 
            this.mnuRestore.Name = "mnuRestore";
            this.mnuRestore.Size = new System.Drawing.Size(189, 22);
            this.mnuRestore.Text = "Show Available Services";
            this.mnuRestore.Click += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // mnuSeparator2
            // 
            this.mnuSeparator2.Name = "mnuSeparator2";
            this.mnuSeparator2.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(189, 22);
            this.mnuSettings.Text = "&Change Settings";
            // 
            // mnuSeparator3
            // 
            this.mnuSeparator3.Name = "mnuSeparator3";
            this.mnuSeparator3.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuEndProgram
            // 
            this.mnuEndProgram.Name = "mnuEndProgram";
            this.mnuEndProgram.Size = new System.Drawing.Size(189, 22);
            this.mnuEndProgram.Text = "&End Program";
            this.mnuEndProgram.Click += new System.EventHandler(this.mnuEndProgram_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.groupBoxUDDI);
            this.pnlTop.Controls.Add(this.btnUpdateServ);
            this.pnlTop.Controls.Add(this.btnUpdateFunc);
            this.pnlTop.Controls.Add(this.gbDOS);
            this.pnlTop.Controls.Add(this.gbFilterFunctionality);
            this.pnlTop.Controls.Add(this.gbPort);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(300, 291);
            this.pnlTop.TabIndex = 26;
            // 
            // groupBoxUDDI
            // 
            this.groupBoxUDDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxUDDI.Controls.Add(this.txtAdressUDDI);
            this.groupBoxUDDI.Controls.Add(this.label1);
            this.groupBoxUDDI.Location = new System.Drawing.Point(0, 129);
            this.groupBoxUDDI.Name = "groupBoxUDDI";
            this.groupBoxUDDI.Size = new System.Drawing.Size(300, 48);
            this.groupBoxUDDI.TabIndex = 32;
            this.groupBoxUDDI.TabStop = false;
            this.groupBoxUDDI.Text = "UDDI Connection";
            // 
            // txtAdressUDDI
            // 
            this.txtAdressUDDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdressUDDI.Location = new System.Drawing.Point(57, 23);
            this.txtAdressUDDI.Name = "txtAdressUDDI";
            this.txtAdressUDDI.Size = new System.Drawing.Size(230, 20);
            this.txtAdressUDDI.TabIndex = 1;
            this.txtAdressUDDI.Text = "http://193.226.12.174/uddi/inquire.asmx";
            this.txtAdressUDDI.TextChanged += new System.EventHandler(this.txtAdressUDDI_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address:";
            // 
            // btnUpdateServ
            // 
            this.btnUpdateServ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateServ.Location = new System.Drawing.Point(12, 212);
            this.btnUpdateServ.Name = "btnUpdateServ";
            this.btnUpdateServ.Size = new System.Drawing.Size(275, 23);
            this.btnUpdateServ.TabIndex = 31;
            this.btnUpdateServ.Text = "Update Services";
            this.btnUpdateServ.UseVisualStyleBackColor = true;
            this.btnUpdateServ.Click += new System.EventHandler(this.btnUpdateServ_Click);
            // 
            // btnUpdateFunc
            // 
            this.btnUpdateFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateFunc.Location = new System.Drawing.Point(12, 183);
            this.btnUpdateFunc.Name = "btnUpdateFunc";
            this.btnUpdateFunc.Size = new System.Drawing.Size(275, 23);
            this.btnUpdateFunc.TabIndex = 29;
            this.btnUpdateFunc.Text = "Update Functionalities";
            this.btnUpdateFunc.UseVisualStyleBackColor = true;
            this.btnUpdateFunc.Click += new System.EventHandler(this.btnUpdateFunc_Click);
            // 
            // gbDOS
            // 
            this.gbDOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDOS.Controls.Add(this.lblPortDOS);
            this.gbDOS.Controls.Add(this.txtAdressDOS);
            this.gbDOS.Controls.Add(this.lblAdressDOS);
            this.gbDOS.Controls.Add(this.nudPortDOS);
            this.gbDOS.Location = new System.Drawing.Point(0, 48);
            this.gbDOS.Name = "gbDOS";
            this.gbDOS.Size = new System.Drawing.Size(300, 75);
            this.gbDOS.TabIndex = 28;
            this.gbDOS.TabStop = false;
            this.gbDOS.Text = "Domain Ontology Service";
            // 
            // lblPortDOS
            // 
            this.lblPortDOS.AutoSize = true;
            this.lblPortDOS.Location = new System.Drawing.Point(6, 47);
            this.lblPortDOS.Name = "lblPortDOS";
            this.lblPortDOS.Size = new System.Drawing.Size(72, 13);
            this.lblPortDOS.TabIndex = 30;
            this.lblPortDOS.Text = "Port Number :";
            // 
            // txtAdressDOS
            // 
            this.txtAdressDOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdressDOS.Location = new System.Drawing.Point(57, 19);
            this.txtAdressDOS.Name = "txtAdressDOS";
            this.txtAdressDOS.Size = new System.Drawing.Size(230, 20);
            this.txtAdressDOS.TabIndex = 29;
            this.txtAdressDOS.Text = "localhost";
            // 
            // lblAdressDOS
            // 
            this.lblAdressDOS.AutoSize = true;
            this.lblAdressDOS.Location = new System.Drawing.Point(6, 22);
            this.lblAdressDOS.Name = "lblAdressDOS";
            this.lblAdressDOS.Size = new System.Drawing.Size(45, 13);
            this.lblAdressDOS.TabIndex = 28;
            this.lblAdressDOS.Text = "Adress :";
            // 
            // nudPortDOS
            // 
            this.nudPortDOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPortDOS.Location = new System.Drawing.Point(84, 45);
            this.nudPortDOS.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPortDOS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPortDOS.Name = "nudPortDOS";
            this.nudPortDOS.Size = new System.Drawing.Size(203, 20);
            this.nudPortDOS.TabIndex = 17;
            this.nudPortDOS.Value = new decimal(new int[] {
            9900,
            0,
            0,
            0});
            // 
            // gbFilterFunctionality
            // 
            this.gbFilterFunctionality.Controls.Add(this.cboFilterFunctionality);
            this.gbFilterFunctionality.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbFilterFunctionality.Location = new System.Drawing.Point(0, 241);
            this.gbFilterFunctionality.Name = "gbFilterFunctionality";
            this.gbFilterFunctionality.Size = new System.Drawing.Size(300, 50);
            this.gbFilterFunctionality.TabIndex = 27;
            this.gbFilterFunctionality.TabStop = false;
            this.gbFilterFunctionality.Text = "Filter by Functionality ID";
            // 
            // cboFilterFunctionality
            // 
            this.cboFilterFunctionality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterFunctionality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterFunctionality.FormattingEnabled = true;
            this.cboFilterFunctionality.Location = new System.Drawing.Point(8, 19);
            this.cboFilterFunctionality.Name = "cboFilterFunctionality";
            this.cboFilterFunctionality.Size = new System.Drawing.Size(286, 21);
            this.cboFilterFunctionality.TabIndex = 0;
            this.cboFilterFunctionality.SelectedIndexChanged += new System.EventHandler(this.cboFilterFunctionality_SelectedIndexChanged);
            // 
            // gbPort
            // 
            this.gbPort.Controls.Add(this.btnListen);
            this.gbPort.Controls.Add(this.nudPort);
            this.gbPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPort.Location = new System.Drawing.Point(0, 0);
            this.gbPort.Name = "gbPort";
            this.gbPort.Size = new System.Drawing.Size(300, 48);
            this.gbPort.TabIndex = 26;
            this.gbPort.TabStop = false;
            this.gbPort.Text = "Listening Port";
            // 
            // btnListen
            // 
            this.btnListen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListen.Location = new System.Drawing.Point(187, 16);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(100, 23);
            this.btnListen.TabIndex = 18;
            this.btnListen.Text = "Start Service";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // nudPort
            // 
            this.nudPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPort.Location = new System.Drawing.Point(6, 19);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(175, 20);
            this.nudPort.TabIndex = 17;
            this.nudPort.Value = new decimal(new int[] {
            9910,
            0,
            0,
            0});
            this.nudPort.ValueChanged += new System.EventHandler(this.nudPort_ValueChanged);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(186)))), ((int)(((byte)(197)))));
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 291);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.gbServices);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.gbProperties);
            this.splitContainerMain.Size = new System.Drawing.Size(300, 360);
            this.splitContainerMain.SplitterDistance = 174;
            this.splitContainerMain.TabIndex = 27;
            // 
            // gbServices
            // 
            this.gbServices.BackColor = System.Drawing.SystemColors.Control;
            this.gbServices.Controls.Add(this.lbServices);
            this.gbServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbServices.Location = new System.Drawing.Point(0, 0);
            this.gbServices.Name = "gbServices";
            this.gbServices.Size = new System.Drawing.Size(300, 174);
            this.gbServices.TabIndex = 23;
            this.gbServices.TabStop = false;
            this.gbServices.Text = "Services";
            // 
            // lbServices
            // 
            this.lbServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbServices.FormattingEnabled = true;
            this.lbServices.HorizontalScrollbar = true;
            this.lbServices.Location = new System.Drawing.Point(3, 16);
            this.lbServices.Name = "lbServices";
            this.lbServices.Size = new System.Drawing.Size(294, 147);
            this.lbServices.TabIndex = 23;
            this.lbServices.SelectedIndexChanged += new System.EventHandler(this.lbServices_SelectedIndexChanged);
            // 
            // gbProperties
            // 
            this.gbProperties.BackColor = System.Drawing.SystemColors.Control;
            this.gbProperties.Controls.Add(this.lbProperties);
            this.gbProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProperties.Location = new System.Drawing.Point(0, 0);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(300, 182);
            this.gbProperties.TabIndex = 24;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "Properties";
            // 
            // lbProperties
            // 
            this.lbProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProperties.FormattingEnabled = true;
            this.lbProperties.HorizontalScrollbar = true;
            this.lbProperties.Location = new System.Drawing.Point(3, 16);
            this.lbProperties.Name = "lbProperties";
            this.lbProperties.Size = new System.Drawing.Size(294, 160);
            this.lbProperties.TabIndex = 23;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // FunctionalityFindingServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 651);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 500);
            this.Name = "FunctionalityFindingServiceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Functionality Finding Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.FunctionalityFindingServiceForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FunctionalityFindingServiceForm_FormClosing);
            this.Resize += new System.EventHandler(this.FunctionalityFindingServiceForm_Resize);
            this.trayContextMenuStrip.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.groupBoxUDDI.ResumeLayout(false);
            this.groupBoxUDDI.PerformLayout();
            this.gbDOS.ResumeLayout(false);
            this.gbDOS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortDOS)).EndInit();
            this.gbFilterFunctionality.ResumeLayout(false);
            this.gbPort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.gbServices.ResumeLayout(false);
            this.gbProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuStartService;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuEndProgram;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox gbDOS;
        private System.Windows.Forms.Label lblPortDOS;
        private System.Windows.Forms.TextBox txtAdressDOS;
        private System.Windows.Forms.Label lblAdressDOS;
        private System.Windows.Forms.NumericUpDown nudPortDOS;
        private System.Windows.Forms.GroupBox gbFilterFunctionality;
        private System.Windows.Forms.ComboBox cboFilterFunctionality;
        private System.Windows.Forms.GroupBox gbPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.GroupBox gbServices;
        private System.Windows.Forms.ListBox lbServices;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.ListBox lbProperties;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnUpdateServ;
        private System.Windows.Forms.Button btnUpdateFunc;
        private System.Windows.Forms.GroupBox groupBoxUDDI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdressUDDI;
    }
}