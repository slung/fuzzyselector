namespace FuzzySelector.SmartSpammer
{

    partial class SmartSpammerForm {

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

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartSpammerForm));
            this.cboFunctionality = new System.Windows.Forms.ComboBox();
            this.btnSpam = new System.Windows.Forms.Button();
            this.tcProperties = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelFunctionality = new System.Windows.Forms.Panel();
            this.pnlFuzzyValue = new System.Windows.Forms.Panel();
            this.cboFuzzyValue = new System.Windows.Forms.ComboBox();
            this.pnlFuzzyPercent = new System.Windows.Forms.Panel();
            this.nudFuzzyPercent = new System.Windows.Forms.NumericUpDown();
            this.pnlCrispValue = new System.Windows.Forms.Panel();
            this.txtCrispValue = new System.Windows.Forms.TextBox();
            this.pnlCrispPercent = new System.Windows.Forms.Panel();
            this.nudCrispPercent = new System.Windows.Forms.NumericUpDown();
            this.cboFuzzyValuePrefix = new System.Windows.Forms.ComboBox();
            this.cboCrispValuePrefix = new System.Windows.Forms.ComboBox();
            this.scValues = new System.Windows.Forms.SplitContainer();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblImportance = new System.Windows.Forms.Label();
            this.btnPreviewShape = new System.Windows.Forms.Button();
            this.rbSpecifiedCustom = new System.Windows.Forms.RadioButton();
            this.lblMinMax = new System.Windows.Forms.Label();
            this.rbSpecifiedFuzzy = new System.Windows.Forms.RadioButton();
            this.rbSpecifiedCrisp = new System.Windows.Forms.RadioButton();
            this.rbNotSpecified = new System.Windows.Forms.RadioButton();
            this.tbImportance = new System.Windows.Forms.TrackBar();
            this.lblFunctionality = new System.Windows.Forms.Label();
            this.btnFunctionalities = new System.Windows.Forms.Button();
            this.scAddresses = new System.Windows.Forms.SplitContainer();
            this.gbDOS = new System.Windows.Forms.GroupBox();
            this.lblPortDOS = new System.Windows.Forms.Label();
            this.txtAdressDOS = new System.Windows.Forms.TextBox();
            this.lblAdressDOS = new System.Windows.Forms.Label();
            this.nudPortDOS = new System.Windows.Forms.NumericUpDown();
            this.gbFFS = new System.Windows.Forms.GroupBox();
            this.lblPortFFS = new System.Windows.Forms.Label();
            this.txtAdressFFS = new System.Windows.Forms.TextBox();
            this.lblAdressFFS = new System.Windows.Forms.Label();
            this.nudPortFFS = new System.Windows.Forms.NumericUpDown();
            this.spamGroupBox = new System.Windows.Forms.GroupBox();
            this.radBtnManualTesting = new System.Windows.Forms.RadioButton();
            this.radBtnAutoTesting = new System.Windows.Forms.RadioButton();
            this.nudNoReq = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudLoadLevel = new System.Windows.Forms.NumericUpDown();
            this.nrFireLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvTestConfigs = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeTestConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTestConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTestConfigurationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveTestConfig = new System.Windows.Forms.Button();
            this.btnLoadTestConfig = new System.Windows.Forms.Button();
            this.btnAddTestConfig = new System.Windows.Forms.Button();
            this.btnClearTestConfig = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tcProperties.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelFunctionality.SuspendLayout();
            this.pnlFuzzyValue.SuspendLayout();
            this.pnlFuzzyPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFuzzyPercent)).BeginInit();
            this.pnlCrispValue.SuspendLayout();
            this.pnlCrispPercent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrispPercent)).BeginInit();
            this.scValues.Panel1.SuspendLayout();
            this.scValues.Panel2.SuspendLayout();
            this.scValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbImportance)).BeginInit();
            this.scAddresses.Panel1.SuspendLayout();
            this.scAddresses.Panel2.SuspendLayout();
            this.scAddresses.SuspendLayout();
            this.gbDOS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortDOS)).BeginInit();
            this.gbFFS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortFFS)).BeginInit();
            this.spamGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoadLevel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboFunctionality
            // 
            this.cboFunctionality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFunctionality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFunctionality.FormattingEnabled = true;
            this.cboFunctionality.Location = new System.Drawing.Point(82, 84);
            this.cboFunctionality.Name = "cboFunctionality";
            this.cboFunctionality.Size = new System.Drawing.Size(422, 21);
            this.cboFunctionality.TabIndex = 0;
            this.cboFunctionality.Visible = false;
            this.cboFunctionality.SelectedIndexChanged += new System.EventHandler(this.cboFunctionality_SelectedIndexChanged);
            // 
            // btnSpam
            // 
            this.btnSpam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpam.Location = new System.Drawing.Point(10, 507);
            this.btnSpam.Name = "btnSpam";
            this.btnSpam.Size = new System.Drawing.Size(100, 70);
            this.btnSpam.TabIndex = 23;
            this.btnSpam.Text = "Spam";
            this.btnSpam.UseVisualStyleBackColor = true;
            this.btnSpam.Click += new System.EventHandler(this.btnSpam_Click);
            this.btnSpam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterPressed);
            // 
            // tcProperties
            // 
            this.tcProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcProperties.Controls.Add(this.tabPage1);
            this.tcProperties.Location = new System.Drawing.Point(0, 121);
            this.tcProperties.Name = "tcProperties";
            this.tcProperties.SelectedIndex = 0;
            this.tcProperties.Size = new System.Drawing.Size(763, 205);
            this.tcProperties.TabIndex = 24;
            this.tcProperties.SelectedIndexChanged += new System.EventHandler(this.tcProperties_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelFunctionality);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 179);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Choose a functionality ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelFunctionality
            // 
            this.panelFunctionality.BackColor = System.Drawing.Color.White;
            this.panelFunctionality.Controls.Add(this.pnlFuzzyValue);
            this.panelFunctionality.Controls.Add(this.pnlCrispValue);
            this.panelFunctionality.Controls.Add(this.cboFuzzyValuePrefix);
            this.panelFunctionality.Controls.Add(this.cboCrispValuePrefix);
            this.panelFunctionality.Controls.Add(this.scValues);
            this.panelFunctionality.Controls.Add(this.lblImportance);
            this.panelFunctionality.Controls.Add(this.btnPreviewShape);
            this.panelFunctionality.Controls.Add(this.rbSpecifiedCustom);
            this.panelFunctionality.Controls.Add(this.lblMinMax);
            this.panelFunctionality.Controls.Add(this.rbSpecifiedFuzzy);
            this.panelFunctionality.Controls.Add(this.rbSpecifiedCrisp);
            this.panelFunctionality.Controls.Add(this.rbNotSpecified);
            this.panelFunctionality.Controls.Add(this.tbImportance);
            this.panelFunctionality.Location = new System.Drawing.Point(3, 1);
            this.panelFunctionality.Name = "panelFunctionality";
            this.panelFunctionality.Size = new System.Drawing.Size(749, 177);
            this.panelFunctionality.TabIndex = 1;
            this.panelFunctionality.Visible = false;
            // 
            // pnlFuzzyValue
            // 
            this.pnlFuzzyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFuzzyValue.Controls.Add(this.cboFuzzyValue);
            this.pnlFuzzyValue.Controls.Add(this.pnlFuzzyPercent);
            this.pnlFuzzyValue.Location = new System.Drawing.Point(227, 97);
            this.pnlFuzzyValue.Name = "pnlFuzzyValue";
            this.pnlFuzzyValue.Size = new System.Drawing.Size(522, 21);
            this.pnlFuzzyValue.TabIndex = 41;
            // 
            // cboFuzzyValue
            // 
            this.cboFuzzyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboFuzzyValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuzzyValue.Enabled = false;
            this.cboFuzzyValue.FormattingEnabled = true;
            this.cboFuzzyValue.Location = new System.Drawing.Point(36, 0);
            this.cboFuzzyValue.Name = "cboFuzzyValue";
            this.cboFuzzyValue.Size = new System.Drawing.Size(486, 21);
            this.cboFuzzyValue.TabIndex = 41;
            this.cboFuzzyValue.SelectedIndexChanged += new System.EventHandler(this.cboFuzzyValue_SelectedIndexChanged);
            // 
            // pnlFuzzyPercent
            // 
            this.pnlFuzzyPercent.Controls.Add(this.nudFuzzyPercent);
            this.pnlFuzzyPercent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFuzzyPercent.Location = new System.Drawing.Point(0, 0);
            this.pnlFuzzyPercent.Name = "pnlFuzzyPercent";
            this.pnlFuzzyPercent.Size = new System.Drawing.Size(36, 21);
            this.pnlFuzzyPercent.TabIndex = 40;
            this.pnlFuzzyPercent.Visible = false;
            // 
            // nudFuzzyPercent
            // 
            this.nudFuzzyPercent.Enabled = false;
            this.nudFuzzyPercent.Location = new System.Drawing.Point(0, 0);
            this.nudFuzzyPercent.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudFuzzyPercent.Name = "nudFuzzyPercent";
            this.nudFuzzyPercent.Size = new System.Drawing.Size(32, 20);
            this.nudFuzzyPercent.TabIndex = 39;
            this.nudFuzzyPercent.ValueChanged += new System.EventHandler(this.nudFuzzyPercent_ValueChanged);
            // 
            // pnlCrispValue
            // 
            this.pnlCrispValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCrispValue.Controls.Add(this.txtCrispValue);
            this.pnlCrispValue.Controls.Add(this.pnlCrispPercent);
            this.pnlCrispValue.Location = new System.Drawing.Point(227, 70);
            this.pnlCrispValue.Name = "pnlCrispValue";
            this.pnlCrispValue.Size = new System.Drawing.Size(522, 21);
            this.pnlCrispValue.TabIndex = 40;
            // 
            // txtCrispValue
            // 
            this.txtCrispValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCrispValue.Enabled = false;
            this.txtCrispValue.Location = new System.Drawing.Point(36, 0);
            this.txtCrispValue.Name = "txtCrispValue";
            this.txtCrispValue.Size = new System.Drawing.Size(486, 20);
            this.txtCrispValue.TabIndex = 29;
            this.txtCrispValue.Leave += new System.EventHandler(this.txtCrispValue_Leave);
            // 
            // pnlCrispPercent
            // 
            this.pnlCrispPercent.Controls.Add(this.nudCrispPercent);
            this.pnlCrispPercent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCrispPercent.Location = new System.Drawing.Point(0, 0);
            this.pnlCrispPercent.Name = "pnlCrispPercent";
            this.pnlCrispPercent.Size = new System.Drawing.Size(36, 21);
            this.pnlCrispPercent.TabIndex = 28;
            this.pnlCrispPercent.Visible = false;
            // 
            // nudCrispPercent
            // 
            this.nudCrispPercent.Enabled = false;
            this.nudCrispPercent.Location = new System.Drawing.Point(0, 0);
            this.nudCrispPercent.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudCrispPercent.Name = "nudCrispPercent";
            this.nudCrispPercent.Size = new System.Drawing.Size(32, 20);
            this.nudCrispPercent.TabIndex = 25;
            this.nudCrispPercent.ValueChanged += new System.EventHandler(this.nudCrispPercent_ValueChanged);
            // 
            // cboFuzzyValuePrefix
            // 
            this.cboFuzzyValuePrefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuzzyValuePrefix.Enabled = false;
            this.cboFuzzyValuePrefix.FormattingEnabled = true;
            this.cboFuzzyValuePrefix.Items.AddRange(new object[] {
            "Exactly",
            "At least",
            "At least about (%)",
            "At most",
            "At most about (%)",
            "About (%)"});
            this.cboFuzzyValuePrefix.Location = new System.Drawing.Point(98, 97);
            this.cboFuzzyValuePrefix.Name = "cboFuzzyValuePrefix";
            this.cboFuzzyValuePrefix.Size = new System.Drawing.Size(123, 21);
            this.cboFuzzyValuePrefix.TabIndex = 30;
            this.cboFuzzyValuePrefix.SelectedIndexChanged += new System.EventHandler(this.cboFuzzyValuePrefix_SelectedIndexChanged);
            // 
            // cboCrispValuePrefix
            // 
            this.cboCrispValuePrefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCrispValuePrefix.Enabled = false;
            this.cboCrispValuePrefix.FormattingEnabled = true;
            this.cboCrispValuePrefix.Items.AddRange(new object[] {
            "Exactly",
            "At least",
            "At least about (%)",
            "At most",
            "At most about (%)",
            "About (%)"});
            this.cboCrispValuePrefix.Location = new System.Drawing.Point(98, 70);
            this.cboCrispValuePrefix.Name = "cboCrispValuePrefix";
            this.cboCrispValuePrefix.Size = new System.Drawing.Size(123, 21);
            this.cboCrispValuePrefix.TabIndex = 29;
            this.cboCrispValuePrefix.SelectedIndexChanged += new System.EventHandler(this.cboCrispValuePrefix_SelectedIndexChanged);
            // 
            // scValues
            // 
            this.scValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scValues.IsSplitterFixed = true;
            this.scValues.Location = new System.Drawing.Point(98, 124);
            this.scValues.Name = "scValues";
            // 
            // scValues.Panel1
            // 
            this.scValues.Panel1.Controls.Add(this.txtLeft);
            this.scValues.Panel1.Controls.Add(this.txtStart);
            this.scValues.Panel1.Controls.Add(this.lblLeft);
            this.scValues.Panel1.Controls.Add(this.lblStart);
            // 
            // scValues.Panel2
            // 
            this.scValues.Panel2.Controls.Add(this.txtRight);
            this.scValues.Panel2.Controls.Add(this.txtEnd);
            this.scValues.Panel2.Controls.Add(this.lblRight);
            this.scValues.Panel2.Controls.Add(this.lblEnd);
            this.scValues.Size = new System.Drawing.Size(651, 46);
            this.scValues.SplitterDistance = 313;
            this.scValues.TabIndex = 26;
            // 
            // txtLeft
            // 
            this.txtLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeft.Enabled = false;
            this.txtLeft.Location = new System.Drawing.Point(50, 26);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(199, 20);
            this.txtLeft.TabIndex = 25;
            this.txtLeft.Leave += new System.EventHandler(this.txtLeft_Leave);
            // 
            // txtStart
            // 
            this.txtStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStart.Enabled = false;
            this.txtStart.Location = new System.Drawing.Point(50, 0);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(199, 20);
            this.txtStart.TabIndex = 24;
            this.txtStart.Leave += new System.EventHandler(this.txtStart_Leave);
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(3, 29);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(28, 13);
            this.lblLeft.TabIndex = 29;
            this.lblLeft.Text = "Left:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(3, 3);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(32, 13);
            this.lblStart.TabIndex = 27;
            this.lblStart.Text = "Start:";
            // 
            // txtRight
            // 
            this.txtRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRight.Enabled = false;
            this.txtRight.Location = new System.Drawing.Point(51, 26);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(371, 20);
            this.txtRight.TabIndex = 32;
            this.txtRight.Leave += new System.EventHandler(this.txtRight_Leave);
            // 
            // txtEnd
            // 
            this.txtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnd.Enabled = false;
            this.txtEnd.Location = new System.Drawing.Point(51, 0);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(371, 20);
            this.txtEnd.TabIndex = 33;
            this.txtEnd.Leave += new System.EventHandler(this.txtEnd_Leave);
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(3, 29);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(35, 13);
            this.lblRight.TabIndex = 35;
            this.lblRight.Text = "Right:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(3, 3);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(29, 13);
            this.lblEnd.TabIndex = 34;
            this.lblEnd.Text = "End:";
            // 
            // lblImportance
            // 
            this.lblImportance.AutoSize = true;
            this.lblImportance.Location = new System.Drawing.Point(0, 8);
            this.lblImportance.Name = "lblImportance";
            this.lblImportance.Size = new System.Drawing.Size(112, 26);
            this.lblImportance.TabIndex = 25;
            this.lblImportance.Text = "The importance of this\r\nproperty is: Average";
            // 
            // btnPreviewShape
            // 
            this.btnPreviewShape.Location = new System.Drawing.Point(0, 147);
            this.btnPreviewShape.Name = "btnPreviewShape";
            this.btnPreviewShape.Size = new System.Drawing.Size(95, 23);
            this.btnPreviewShape.TabIndex = 19;
            this.btnPreviewShape.Text = "Preview shape";
            this.btnPreviewShape.UseVisualStyleBackColor = true;
            this.btnPreviewShape.Click += new System.EventHandler(this.btnPreviewShape_Click);
            // 
            // rbSpecifiedCustom
            // 
            this.rbSpecifiedCustom.AutoSize = true;
            this.rbSpecifiedCustom.Location = new System.Drawing.Point(0, 125);
            this.rbSpecifiedCustom.Name = "rbSpecifiedCustom";
            this.rbSpecifiedCustom.Size = new System.Drawing.Size(60, 17);
            this.rbSpecifiedCustom.TabIndex = 8;
            this.rbSpecifiedCustom.TabStop = true;
            this.rbSpecifiedCustom.Text = "Custom";
            this.rbSpecifiedCustom.UseVisualStyleBackColor = true;
            this.rbSpecifiedCustom.CheckedChanged += new System.EventHandler(this.rbSpecified_CheckedChanged);
            // 
            // lblMinMax
            // 
            this.lblMinMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinMax.Location = new System.Drawing.Point(95, 46);
            this.lblMinMax.Name = "lblMinMax";
            this.lblMinMax.Size = new System.Drawing.Size(651, 13);
            this.lblMinMax.TabIndex = 7;
            // 
            // rbSpecifiedFuzzy
            // 
            this.rbSpecifiedFuzzy.AutoSize = true;
            this.rbSpecifiedFuzzy.Location = new System.Drawing.Point(0, 98);
            this.rbSpecifiedFuzzy.Name = "rbSpecifiedFuzzy";
            this.rbSpecifiedFuzzy.Size = new System.Drawing.Size(82, 17);
            this.rbSpecifiedFuzzy.TabIndex = 4;
            this.rbSpecifiedFuzzy.TabStop = true;
            this.rbSpecifiedFuzzy.Text = "Fuzzy Value";
            this.rbSpecifiedFuzzy.UseVisualStyleBackColor = true;
            this.rbSpecifiedFuzzy.CheckedChanged += new System.EventHandler(this.rbSpecified_CheckedChanged);
            // 
            // rbSpecifiedCrisp
            // 
            this.rbSpecifiedCrisp.AutoSize = true;
            this.rbSpecifiedCrisp.Location = new System.Drawing.Point(0, 71);
            this.rbSpecifiedCrisp.Name = "rbSpecifiedCrisp";
            this.rbSpecifiedCrisp.Size = new System.Drawing.Size(78, 17);
            this.rbSpecifiedCrisp.TabIndex = 3;
            this.rbSpecifiedCrisp.TabStop = true;
            this.rbSpecifiedCrisp.Text = "Crisp Value";
            this.rbSpecifiedCrisp.UseVisualStyleBackColor = true;
            this.rbSpecifiedCrisp.CheckedChanged += new System.EventHandler(this.rbSpecified_CheckedChanged);
            // 
            // rbNotSpecified
            // 
            this.rbNotSpecified.AutoSize = true;
            this.rbNotSpecified.Location = new System.Drawing.Point(0, 44);
            this.rbNotSpecified.Name = "rbNotSpecified";
            this.rbNotSpecified.Size = new System.Drawing.Size(89, 17);
            this.rbNotSpecified.TabIndex = 2;
            this.rbNotSpecified.TabStop = true;
            this.rbNotSpecified.Text = "Not Specified";
            this.rbNotSpecified.UseVisualStyleBackColor = true;
            this.rbNotSpecified.CheckedChanged += new System.EventHandler(this.rbSpecified_CheckedChanged);
            // 
            // tbImportance
            // 
            this.tbImportance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbImportance.BackColor = System.Drawing.Color.White;
            this.tbImportance.LargeChange = 1;
            this.tbImportance.Location = new System.Drawing.Point(147, 3);
            this.tbImportance.Maximum = 9;
            this.tbImportance.Minimum = 1;
            this.tbImportance.Name = "tbImportance";
            this.tbImportance.Size = new System.Drawing.Size(602, 42);
            this.tbImportance.TabIndex = 24;
            this.tbImportance.Value = 5;
            this.tbImportance.ValueChanged += new System.EventHandler(this.tbImportance_ValueChanged);
            // 
            // lblFunctionality
            // 
            this.lblFunctionality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFunctionality.AutoSize = true;
            this.lblFunctionality.Location = new System.Drawing.Point(4, 89);
            this.lblFunctionality.Name = "lblFunctionality";
            this.lblFunctionality.Size = new System.Drawing.Size(72, 13);
            this.lblFunctionality.TabIndex = 29;
            this.lblFunctionality.Text = "Functionality :";
            this.lblFunctionality.Visible = false;
            // 
            // btnFunctionalities
            // 
            this.btnFunctionalities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFunctionalities.Location = new System.Drawing.Point(2, 84);
            this.btnFunctionalities.Name = "btnFunctionalities";
            this.btnFunctionalities.Size = new System.Drawing.Size(502, 23);
            this.btnFunctionalities.TabIndex = 30;
            this.btnFunctionalities.Text = "Click to make a test configuration";
            this.btnFunctionalities.UseVisualStyleBackColor = true;
            this.btnFunctionalities.Click += new System.EventHandler(this.btnFunctionalities_Click);
            // 
            // scAddresses
            // 
            this.scAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scAddresses.IsSplitterFixed = true;
            this.scAddresses.Location = new System.Drawing.Point(0, 0);
            this.scAddresses.Name = "scAddresses";
            // 
            // scAddresses.Panel1
            // 
            this.scAddresses.Panel1.Controls.Add(this.gbDOS);
            // 
            // scAddresses.Panel2
            // 
            this.scAddresses.Panel2.Controls.Add(this.gbFFS);
            this.scAddresses.Size = new System.Drawing.Size(504, 78);
            this.scAddresses.SplitterDistance = 241;
            this.scAddresses.TabIndex = 31;
            // 
            // gbDOS
            // 
            this.gbDOS.Controls.Add(this.lblPortDOS);
            this.gbDOS.Controls.Add(this.txtAdressDOS);
            this.gbDOS.Controls.Add(this.lblAdressDOS);
            this.gbDOS.Controls.Add(this.nudPortDOS);
            this.gbDOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDOS.Location = new System.Drawing.Point(0, 0);
            this.gbDOS.Name = "gbDOS";
            this.gbDOS.Size = new System.Drawing.Size(241, 78);
            this.gbDOS.TabIndex = 22;
            this.gbDOS.TabStop = false;
            this.gbDOS.Text = "Domain Ontology Service";
            // 
            // lblPortDOS
            // 
            this.lblPortDOS.AutoSize = true;
            this.lblPortDOS.Location = new System.Drawing.Point(7, 44);
            this.lblPortDOS.Name = "lblPortDOS";
            this.lblPortDOS.Size = new System.Drawing.Size(72, 13);
            this.lblPortDOS.TabIndex = 30;
            this.lblPortDOS.Text = "Port Number :";
            // 
            // txtAdressDOS
            // 
            this.txtAdressDOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdressDOS.Location = new System.Drawing.Point(58, 21);
            this.txtAdressDOS.Name = "txtAdressDOS";
            this.txtAdressDOS.Size = new System.Drawing.Size(172, 20);
            this.txtAdressDOS.TabIndex = 29;
            this.txtAdressDOS.Text = "localhost";
            this.txtAdressDOS.TextChanged += new System.EventHandler(this.adressDOS_Changed);
            // 
            // lblAdressDOS
            // 
            this.lblAdressDOS.AutoSize = true;
            this.lblAdressDOS.Location = new System.Drawing.Point(7, 24);
            this.lblAdressDOS.Name = "lblAdressDOS";
            this.lblAdressDOS.Size = new System.Drawing.Size(51, 13);
            this.lblAdressDOS.TabIndex = 28;
            this.lblAdressDOS.Text = "Address :";
            // 
            // nudPortDOS
            // 
            this.nudPortDOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPortDOS.Location = new System.Drawing.Point(90, 42);
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
            this.nudPortDOS.Size = new System.Drawing.Size(140, 20);
            this.nudPortDOS.TabIndex = 17;
            this.nudPortDOS.Value = new decimal(new int[] {
            9900,
            0,
            0,
            0});
            this.nudPortDOS.ValueChanged += new System.EventHandler(this.adressDOS_Changed);
            // 
            // gbFFS
            // 
            this.gbFFS.Controls.Add(this.lblPortFFS);
            this.gbFFS.Controls.Add(this.txtAdressFFS);
            this.gbFFS.Controls.Add(this.lblAdressFFS);
            this.gbFFS.Controls.Add(this.nudPortFFS);
            this.gbFFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFFS.Location = new System.Drawing.Point(0, 0);
            this.gbFFS.Name = "gbFFS";
            this.gbFFS.Size = new System.Drawing.Size(259, 78);
            this.gbFFS.TabIndex = 23;
            this.gbFFS.TabStop = false;
            this.gbFFS.Text = "Functionality Finding Service";
            // 
            // lblPortFFS
            // 
            this.lblPortFFS.AutoSize = true;
            this.lblPortFFS.Location = new System.Drawing.Point(9, 44);
            this.lblPortFFS.Name = "lblPortFFS";
            this.lblPortFFS.Size = new System.Drawing.Size(72, 13);
            this.lblPortFFS.TabIndex = 30;
            this.lblPortFFS.Text = "Port Number :";
            // 
            // txtAdressFFS
            // 
            this.txtAdressFFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdressFFS.Location = new System.Drawing.Point(60, 21);
            this.txtAdressFFS.Name = "txtAdressFFS";
            this.txtAdressFFS.Size = new System.Drawing.Size(190, 20);
            this.txtAdressFFS.TabIndex = 29;
            this.txtAdressFFS.Text = "localhost";
            this.txtAdressFFS.TextChanged += new System.EventHandler(this.adressFFS_Changed);
            // 
            // lblAdressFFS
            // 
            this.lblAdressFFS.AutoSize = true;
            this.lblAdressFFS.Location = new System.Drawing.Point(9, 24);
            this.lblAdressFFS.Name = "lblAdressFFS";
            this.lblAdressFFS.Size = new System.Drawing.Size(51, 13);
            this.lblAdressFFS.TabIndex = 28;
            this.lblAdressFFS.Text = "Address :";
            // 
            // nudPortFFS
            // 
            this.nudPortFFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPortFFS.Location = new System.Drawing.Point(92, 42);
            this.nudPortFFS.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPortFFS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPortFFS.Name = "nudPortFFS";
            this.nudPortFFS.Size = new System.Drawing.Size(158, 20);
            this.nudPortFFS.TabIndex = 17;
            this.nudPortFFS.Value = new decimal(new int[] {
            9910,
            0,
            0,
            0});
            this.nudPortFFS.ValueChanged += new System.EventHandler(this.adressFFS_Changed);
            // 
            // spamGroupBox
            // 
            this.spamGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spamGroupBox.Controls.Add(this.radBtnManualTesting);
            this.spamGroupBox.Controls.Add(this.radBtnAutoTesting);
            this.spamGroupBox.Controls.Add(this.nudNoReq);
            this.spamGroupBox.Controls.Add(this.label1);
            this.spamGroupBox.Controls.Add(this.nudLoadLevel);
            this.spamGroupBox.Controls.Add(this.nrFireLabel);
            this.spamGroupBox.Location = new System.Drawing.Point(508, 0);
            this.spamGroupBox.Name = "spamGroupBox";
            this.spamGroupBox.Size = new System.Drawing.Size(255, 107);
            this.spamGroupBox.TabIndex = 32;
            this.spamGroupBox.TabStop = false;
            this.spamGroupBox.Text = "Spam Details";
            // 
            // radBtnManualTesting
            // 
            this.radBtnManualTesting.AutoSize = true;
            this.radBtnManualTesting.Location = new System.Drawing.Point(147, 85);
            this.radBtnManualTesting.Name = "radBtnManualTesting";
            this.radBtnManualTesting.Size = new System.Drawing.Size(98, 17);
            this.radBtnManualTesting.TabIndex = 6;
            this.radBtnManualTesting.TabStop = true;
            this.radBtnManualTesting.Text = "Manual Testing";
            this.toolTip2.SetToolTip(this.radBtnManualTesting, "Enables manual testing. Requires manual selection of test configuration from the " +
                    "bottom list.");
            this.radBtnManualTesting.UseVisualStyleBackColor = true;
            // 
            // radBtnAutoTesting
            // 
            this.radBtnAutoTesting.AutoSize = true;
            this.radBtnAutoTesting.Location = new System.Drawing.Point(9, 84);
            this.radBtnAutoTesting.Name = "radBtnAutoTesting";
            this.radBtnAutoTesting.Size = new System.Drawing.Size(110, 17);
            this.radBtnAutoTesting.TabIndex = 5;
            this.radBtnAutoTesting.TabStop = true;
            this.radBtnAutoTesting.Text = "Automatic Testing";
            this.toolTip1.SetToolTip(this.radBtnAutoTesting, "Enables automatic testing. Requires loading a test configuration using the \"Load " +
                    "Test Configuration\" button below");
            this.radBtnAutoTesting.UseVisualStyleBackColor = true;
            // 
            // nudNoReq
            // 
            this.nudNoReq.Enabled = false;
            this.nudNoReq.Location = new System.Drawing.Point(213, 47);
            this.nudNoReq.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudNoReq.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNoReq.Name = "nudNoReq";
            this.nudNoReq.Size = new System.Drawing.Size(38, 20);
            this.nudNoReq.TabIndex = 4;
            this.nudNoReq.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "No. of requests after load level achieved:";
            // 
            // nudLoadLevel
            // 
            this.nudLoadLevel.Enabled = false;
            this.nudLoadLevel.Location = new System.Drawing.Point(111, 19);
            this.nudLoadLevel.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLoadLevel.Name = "nudLoadLevel";
            this.nudLoadLevel.Size = new System.Drawing.Size(140, 20);
            this.nudLoadLevel.TabIndex = 2;
            this.nudLoadLevel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLoadLevel.ValueChanged += new System.EventHandler(this.spamParameters_Changed);
            // 
            // nrFireLabel
            // 
            this.nrFireLabel.AutoSize = true;
            this.nrFireLabel.Location = new System.Drawing.Point(6, 21);
            this.nrFireLabel.Name = "nrFireLabel";
            this.nrFireLabel.Size = new System.Drawing.Size(99, 13);
            this.nrFireLabel.TabIndex = 0;
            this.nrFireLabel.Text = "Minimum load level:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvTestConfigs);
            this.groupBox1.Location = new System.Drawing.Point(0, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 158);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Configurations";
            // 
            // lvTestConfigs
            // 
            this.lvTestConfigs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvTestConfigs.ContextMenuStrip = this.contextMenuStrip;
            this.lvTestConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTestConfigs.FullRowSelect = true;
            this.lvTestConfigs.GridLines = true;
            this.lvTestConfigs.HideSelection = false;
            this.lvTestConfigs.Location = new System.Drawing.Point(3, 16);
            this.lvTestConfigs.MultiSelect = false;
            this.lvTestConfigs.Name = "lvTestConfigs";
            this.lvTestConfigs.Size = new System.Drawing.Size(757, 139);
            this.lvTestConfigs.TabIndex = 0;
            this.lvTestConfigs.UseCompatibleStateImageBehavior = false;
            this.lvTestConfigs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Functionality Name";
            this.columnHeader1.Width = 115;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Request Shapes";
            this.columnHeader2.Width = 449;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Min. Server Load";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "No. of Requests";
            this.columnHeader4.Width = 89;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeTestConfigurationToolStripMenuItem,
            this.updateTestConfigurationToolStripMenuItem,
            this.viewTestConfigurationDetailsToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(224, 70);
            // 
            // removeTestConfigurationToolStripMenuItem
            // 
            this.removeTestConfigurationToolStripMenuItem.Name = "removeTestConfigurationToolStripMenuItem";
            this.removeTestConfigurationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.removeTestConfigurationToolStripMenuItem.Text = "Remove Test Configuration";
            this.removeTestConfigurationToolStripMenuItem.Click += new System.EventHandler(this.removeTestConfigurationToolStripMenuItem_Click);
            // 
            // updateTestConfigurationToolStripMenuItem
            // 
            this.updateTestConfigurationToolStripMenuItem.Name = "updateTestConfigurationToolStripMenuItem";
            this.updateTestConfigurationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.updateTestConfigurationToolStripMenuItem.Text = "Update Test Configuration";
            // 
            // viewTestConfigurationDetailsToolStripMenuItem
            // 
            this.viewTestConfigurationDetailsToolStripMenuItem.Name = "viewTestConfigurationDetailsToolStripMenuItem";
            this.viewTestConfigurationDetailsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.viewTestConfigurationDetailsToolStripMenuItem.Text = "View Test Configuration Details";
            this.viewTestConfigurationDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewTestConfigurationDetailsToolStripMenuItem_Click);
            // 
            // btnSaveTestConfig
            // 
            this.btnSaveTestConfig.Location = new System.Drawing.Point(337, 507);
            this.btnSaveTestConfig.Name = "btnSaveTestConfig";
            this.btnSaveTestConfig.Size = new System.Drawing.Size(100, 70);
            this.btnSaveTestConfig.TabIndex = 35;
            this.btnSaveTestConfig.Text = "Save Test Configuration";
            this.btnSaveTestConfig.UseVisualStyleBackColor = true;
            this.btnSaveTestConfig.Click += new System.EventHandler(this.btnSaveTestConfig_Click);
            // 
            // btnLoadTestConfig
            // 
            this.btnLoadTestConfig.Location = new System.Drawing.Point(508, 507);
            this.btnLoadTestConfig.Name = "btnLoadTestConfig";
            this.btnLoadTestConfig.Size = new System.Drawing.Size(100, 70);
            this.btnLoadTestConfig.TabIndex = 36;
            this.btnLoadTestConfig.Text = "Load Test Configuration";
            this.btnLoadTestConfig.UseVisualStyleBackColor = true;
            this.btnLoadTestConfig.Click += new System.EventHandler(this.btnLoadTestConfig_Click);
            // 
            // btnAddTestConfig
            // 
            this.btnAddTestConfig.Location = new System.Drawing.Point(170, 507);
            this.btnAddTestConfig.Name = "btnAddTestConfig";
            this.btnAddTestConfig.Size = new System.Drawing.Size(100, 70);
            this.btnAddTestConfig.TabIndex = 37;
            this.btnAddTestConfig.Text = "Add Test Configuration";
            this.btnAddTestConfig.UseVisualStyleBackColor = true;
            this.btnAddTestConfig.Click += new System.EventHandler(this.btnAddTestConfig_Click);
            // 
            // btnClearTestConfig
            // 
            this.btnClearTestConfig.Location = new System.Drawing.Point(656, 507);
            this.btnClearTestConfig.Name = "btnClearTestConfig";
            this.btnClearTestConfig.Size = new System.Drawing.Size(100, 70);
            this.btnClearTestConfig.TabIndex = 38;
            this.btnClearTestConfig.Text = "Clear Test Configuration";
            this.btnClearTestConfig.UseVisualStyleBackColor = true;
            this.btnClearTestConfig.Click += new System.EventHandler(this.btnClearTestConfig_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // SmartSpammerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 586);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.spamGroupBox);
            this.Controls.Add(this.cboFunctionality);
            this.Controls.Add(this.btnAddTestConfig);
            this.Controls.Add(this.scAddresses);
            this.Controls.Add(this.btnSaveTestConfig);
            this.Controls.Add(this.btnLoadTestConfig);
            this.Controls.Add(this.btnClearTestConfig);
            this.Controls.Add(this.lblFunctionality);
            this.Controls.Add(this.tcProperties);
            this.Controls.Add(this.btnFunctionalities);
            this.Controls.Add(this.btnSpam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimumSize = new System.Drawing.Size(765, 613);
            this.Name = "SmartSpammerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Smart Spammer with IM on Client";
            this.tcProperties.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelFunctionality.ResumeLayout(false);
            this.panelFunctionality.PerformLayout();
            this.pnlFuzzyValue.ResumeLayout(false);
            this.pnlFuzzyPercent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudFuzzyPercent)).EndInit();
            this.pnlCrispValue.ResumeLayout(false);
            this.pnlCrispValue.PerformLayout();
            this.pnlCrispPercent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCrispPercent)).EndInit();
            this.scValues.Panel1.ResumeLayout(false);
            this.scValues.Panel1.PerformLayout();
            this.scValues.Panel2.ResumeLayout(false);
            this.scValues.Panel2.PerformLayout();
            this.scValues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbImportance)).EndInit();
            this.scAddresses.Panel1.ResumeLayout(false);
            this.scAddresses.Panel2.ResumeLayout(false);
            this.scAddresses.ResumeLayout(false);
            this.gbDOS.ResumeLayout(false);
            this.gbDOS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortDOS)).EndInit();
            this.gbFFS.ResumeLayout(false);
            this.gbFFS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPortFFS)).EndInit();
            this.spamGroupBox.ResumeLayout(false);
            this.spamGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoadLevel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFunctionality;
        private System.Windows.Forms.Button btnSpam;
        private System.Windows.Forms.TabControl tcProperties;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelFunctionality;
        private System.Windows.Forms.Label lblFunctionality;
        private System.Windows.Forms.Button btnFunctionalities;
        private System.Windows.Forms.RadioButton rbSpecifiedFuzzy;
        private System.Windows.Forms.RadioButton rbSpecifiedCrisp;
        private System.Windows.Forms.RadioButton rbNotSpecified;
        private System.Windows.Forms.Label lblMinMax;
        private System.Windows.Forms.RadioButton rbSpecifiedCustom;
        private System.Windows.Forms.Button btnPreviewShape;
        private System.Windows.Forms.Label lblImportance;
        private System.Windows.Forms.TrackBar tbImportance;
        private System.Windows.Forms.SplitContainer scAddresses;
        private System.Windows.Forms.GroupBox gbDOS;
        private System.Windows.Forms.Label lblPortDOS;
        private System.Windows.Forms.TextBox txtAdressDOS;
        private System.Windows.Forms.Label lblAdressDOS;
        private System.Windows.Forms.NumericUpDown nudPortDOS;
        private System.Windows.Forms.GroupBox gbFFS;
        private System.Windows.Forms.Label lblPortFFS;
        private System.Windows.Forms.TextBox txtAdressFFS;
        private System.Windows.Forms.Label lblAdressFFS;
        private System.Windows.Forms.NumericUpDown nudPortFFS;
        private System.Windows.Forms.SplitContainer scValues;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Panel pnlFuzzyValue;
        private System.Windows.Forms.ComboBox cboFuzzyValue;
        private System.Windows.Forms.Panel pnlFuzzyPercent;
        private System.Windows.Forms.NumericUpDown nudFuzzyPercent;
        private System.Windows.Forms.Panel pnlCrispValue;
        private System.Windows.Forms.TextBox txtCrispValue;
        private System.Windows.Forms.Panel pnlCrispPercent;
        private System.Windows.Forms.NumericUpDown nudCrispPercent;
        private System.Windows.Forms.ComboBox cboFuzzyValuePrefix;
        private System.Windows.Forms.ComboBox cboCrispValuePrefix;
        private System.Windows.Forms.GroupBox spamGroupBox;
        private System.Windows.Forms.NumericUpDown nudLoadLevel;
        private System.Windows.Forms.Label nrFireLabel;
        private System.Windows.Forms.NumericUpDown nudNoReq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvTestConfigs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnSaveTestConfig;
        private System.Windows.Forms.Button btnLoadTestConfig;
        private System.Windows.Forms.Button btnAddTestConfig;
        private System.Windows.Forms.Button btnClearTestConfig;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeTestConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTestConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTestConfigurationDetailsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RadioButton radBtnManualTesting;
        private System.Windows.Forms.RadioButton radBtnAutoTesting;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}