namespace FuzzySelector.DomainOntologyService {

    partial class DomainOntologyServiceForm {

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DomainOntologyServiceForm));
            this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuStartService = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEndProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnUpdateOnt = new System.Windows.Forms.Button();
            this.gbPort = new System.Windows.Forms.GroupBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.splitContainerBottom = new System.Windows.Forms.SplitContainer();
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.lbProperties = new System.Windows.Forms.ListBox();
            this.gbTerms = new System.Windows.Forms.GroupBox();
            this.lbTerms = new System.Windows.Forms.ListBox();
            this.gbFunctionalities = new System.Windows.Forms.GroupBox();
            this.lbFunctionality = new System.Windows.Forms.ListBox();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdressUDDI = new System.Windows.Forms.TextBox();
            this.trayContextMenuStrip.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.gbPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.splitContainerBottom.Panel1.SuspendLayout();
            this.splitContainerBottom.Panel2.SuspendLayout();
            this.splitContainerBottom.SuspendLayout();
            this.gbProperties.SuspendLayout();
            this.gbTerms.SuspendLayout();
            this.gbFunctionalities.SuspendLayout();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayContextMenuStrip
            // 
            this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStartService,
            this.mnuSeparator1,
            this.mnuRestore,
            this.mnuSeparator2,
            this.mnuEndProgram});
            this.trayContextMenuStrip.Name = "trayContextMenuStrip";
            this.trayContextMenuStrip.Size = new System.Drawing.Size(190, 82);
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
            this.mnuRestore.Text = "Show Known &Ontologies";
            this.mnuRestore.Click += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // mnuSeparator2
            // 
            this.mnuSeparator2.Name = "mnuSeparator2";
            this.mnuSeparator2.Size = new System.Drawing.Size(186, 6);
            // 
            // mnuEndProgram
            // 
            this.mnuEndProgram.Name = "mnuEndProgram";
            this.mnuEndProgram.Size = new System.Drawing.Size(189, 22);
            this.mnuEndProgram.Text = "&End Program";
            this.mnuEndProgram.Click += new System.EventHandler(this.mnuEndProgram_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Domain Ontology Service";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.groupBox1);
            this.pnlTop.Controls.Add(this.btnUpdateOnt);
            this.pnlTop.Controls.Add(this.gbPort);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(283, 150);
            this.pnlTop.TabIndex = 25;
            // 
            // btnUpdateOnt
            // 
            this.btnUpdateOnt.Location = new System.Drawing.Point(3, 121);
            this.btnUpdateOnt.Name = "btnUpdateOnt";
            this.btnUpdateOnt.Size = new System.Drawing.Size(271, 23);
            this.btnUpdateOnt.TabIndex = 22;
            this.btnUpdateOnt.Text = "Update Ontologies";
            this.btnUpdateOnt.UseVisualStyleBackColor = true;
            this.btnUpdateOnt.Click += new System.EventHandler(this.btnUpdateOnt_Click);
            // 
            // gbPort
            // 
            this.gbPort.Controls.Add(this.btnListen);
            this.gbPort.Controls.Add(this.nudPort);
            this.gbPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPort.Location = new System.Drawing.Point(0, 0);
            this.gbPort.Name = "gbPort";
            this.gbPort.Size = new System.Drawing.Size(283, 48);
            this.gbPort.TabIndex = 21;
            this.gbPort.TabStop = false;
            this.gbPort.Text = "Listening Port";
            // 
            // btnListen
            // 
            this.btnListen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListen.Location = new System.Drawing.Point(180, 19);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(97, 23);
            this.btnListen.TabIndex = 18;
            this.btnListen.Text = "&Start Service";
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
            this.nudPort.Size = new System.Drawing.Size(171, 20);
            this.nudPort.TabIndex = 17;
            this.nudPort.Value = new decimal(new int[] {
            9900,
            0,
            0,
            0});
            this.nudPort.ValueChanged += new System.EventHandler(this.nudPort_ValueChanged);
            // 
            // splitContainerBottom
            // 
            this.splitContainerBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBottom.Name = "splitContainerBottom";
            this.splitContainerBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBottom.Panel1
            // 
            this.splitContainerBottom.Panel1.Controls.Add(this.gbProperties);
            // 
            // splitContainerBottom.Panel2
            // 
            this.splitContainerBottom.Panel2.Controls.Add(this.gbTerms);
            this.splitContainerBottom.Size = new System.Drawing.Size(283, 205);
            this.splitContainerBottom.SplitterDistance = 102;
            this.splitContainerBottom.TabIndex = 0;
            // 
            // gbProperties
            // 
            this.gbProperties.BackColor = System.Drawing.SystemColors.Control;
            this.gbProperties.Controls.Add(this.lbProperties);
            this.gbProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProperties.Location = new System.Drawing.Point(0, 0);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(283, 102);
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
            this.lbProperties.Size = new System.Drawing.Size(277, 82);
            this.lbProperties.TabIndex = 23;
            this.lbProperties.SelectedIndexChanged += new System.EventHandler(this.lbProperties_SelectedIndexChanged);
            // 
            // gbTerms
            // 
            this.gbTerms.BackColor = System.Drawing.SystemColors.Control;
            this.gbTerms.Controls.Add(this.lbTerms);
            this.gbTerms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTerms.Location = new System.Drawing.Point(0, 0);
            this.gbTerms.Name = "gbTerms";
            this.gbTerms.Size = new System.Drawing.Size(283, 99);
            this.gbTerms.TabIndex = 24;
            this.gbTerms.TabStop = false;
            this.gbTerms.Text = "Terms";
            // 
            // lbTerms
            // 
            this.lbTerms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTerms.FormattingEnabled = true;
            this.lbTerms.HorizontalScrollbar = true;
            this.lbTerms.Location = new System.Drawing.Point(3, 16);
            this.lbTerms.Name = "lbTerms";
            this.lbTerms.Size = new System.Drawing.Size(277, 69);
            this.lbTerms.TabIndex = 23;
            this.lbTerms.SelectedIndexChanged += new System.EventHandler(this.lbTerms_SelectedIndexChanged);
            // 
            // gbFunctionalities
            // 
            this.gbFunctionalities.BackColor = System.Drawing.SystemColors.Control;
            this.gbFunctionalities.Controls.Add(this.lbFunctionality);
            this.gbFunctionalities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFunctionalities.Location = new System.Drawing.Point(0, 0);
            this.gbFunctionalities.Name = "gbFunctionalities";
            this.gbFunctionalities.Size = new System.Drawing.Size(283, 102);
            this.gbFunctionalities.TabIndex = 22;
            this.gbFunctionalities.TabStop = false;
            this.gbFunctionalities.Text = "Functionalities";
            // 
            // lbFunctionality
            // 
            this.lbFunctionality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFunctionality.FormattingEnabled = true;
            this.lbFunctionality.HorizontalScrollbar = true;
            this.lbFunctionality.Location = new System.Drawing.Point(3, 16);
            this.lbFunctionality.Name = "lbFunctionality";
            this.lbFunctionality.Size = new System.Drawing.Size(277, 82);
            this.lbFunctionality.TabIndex = 23;
            this.lbFunctionality.SelectedIndexChanged += new System.EventHandler(this.lbFunctionality_SelectedIndexChanged);
            // 
            // splitContainerTop
            // 
            this.splitContainerTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(186)))), ((int)(((byte)(197)))));
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop.Name = "splitContainerTop";
            this.splitContainerTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTop.Panel1
            // 
            this.splitContainerTop.Panel1.Controls.Add(this.gbFunctionalities);
            // 
            // splitContainerTop.Panel2
            // 
            this.splitContainerTop.Panel2.Controls.Add(this.splitContainerBottom);
            this.splitContainerTop.Size = new System.Drawing.Size(283, 311);
            this.splitContainerTop.SplitterDistance = 102;
            this.splitContainerTop.TabIndex = 24;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.splitContainerTop);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 150);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(283, 311);
            this.pnlBottom.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtAdressUDDI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 61);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UDDI Connection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address:";
            // 
            // txtAdressUDDI
            // 
            this.txtAdressUDDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdressUDDI.Location = new System.Drawing.Point(57, 26);
            this.txtAdressUDDI.Name = "txtAdressUDDI";
            this.txtAdressUDDI.Size = new System.Drawing.Size(220, 20);
            this.txtAdressUDDI.TabIndex = 1;
            this.txtAdressUDDI.Text = "http://193.226.12.174/uddi/inquire.asmx";
            // 
            // DomainOntologyServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 461);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 350);
            this.Name = "DomainOntologyServiceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Domain Ontology Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.DomainOntologyServiceForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DomainOntologyServiceForm_Close);
            this.trayContextMenuStrip.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.gbPort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.splitContainerBottom.Panel1.ResumeLayout(false);
            this.splitContainerBottom.Panel2.ResumeLayout(false);
            this.splitContainerBottom.ResumeLayout(false);
            this.gbProperties.ResumeLayout(false);
            this.gbTerms.ResumeLayout(false);
            this.gbFunctionalities.ResumeLayout(false);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel2.ResumeLayout(false);
            this.splitContainerTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;

        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Button btnListen;

        private System.Windows.Forms.GroupBox gbPort;

        private System.Windows.Forms.NotifyIcon notifyIcon;

        private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuStartService;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuEndProgram;

        private System.Windows.Forms.ToolStripSeparator mnuSeparator1;
        private System.Windows.Forms.ToolStripSeparator mnuSeparator2;
        private System.Windows.Forms.Button btnUpdateOnt;
        private System.Windows.Forms.SplitContainer splitContainerBottom;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.ListBox lbProperties;
        private System.Windows.Forms.GroupBox gbTerms;
        private System.Windows.Forms.ListBox lbTerms;
        private System.Windows.Forms.GroupBox gbFunctionalities;
        private System.Windows.Forms.ListBox lbFunctionality;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAdressUDDI;
        private System.Windows.Forms.Label label1;


    }
}