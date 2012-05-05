namespace UDDIConnector
{
    partial class CreateOntologyForm
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
            this.tbOntologyName = new System.Windows.Forms.TextBox();
            this.lbAvailableProperties = new System.Windows.Forms.ListBox();
            this.lbSelectedProperties = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOneIn = new System.Windows.Forms.Button();
            this.btnOneOut = new System.Windows.Forms.Button();
            this.btnAllIn = new System.Windows.Forms.Button();
            this.btnAllOut = new System.Windows.Forms.Button();
            this.btnCreatePublish = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.dgvTerms = new System.Windows.Forms.DataGridView();
            this.btnSaveProperty = new System.Windows.Forms.Button();
            this.tbOntologyEnd = new System.Windows.Forms.TextBox();
            this.tbOntologyStart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbTerms = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerms)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tbOntologyName
            // 
            this.tbOntologyName.Location = new System.Drawing.Point(57, 10);
            this.tbOntologyName.Name = "tbOntologyName";
            this.tbOntologyName.Size = new System.Drawing.Size(209, 20);
            this.tbOntologyName.TabIndex = 1;
            this.tbOntologyName.TextChanged += new System.EventHandler(this.tbOntologyName_TextChanged);
            // 
            // lbAvailableProperties
            // 
            this.lbAvailableProperties.FormattingEnabled = true;
            this.lbAvailableProperties.Location = new System.Drawing.Point(29, 43);
            this.lbAvailableProperties.Name = "lbAvailableProperties";
            this.lbAvailableProperties.Size = new System.Drawing.Size(209, 121);
            this.lbAvailableProperties.Sorted = true;
            this.lbAvailableProperties.TabIndex = 2;
            this.lbAvailableProperties.SelectedIndexChanged += new System.EventHandler(this.lbAvailableProperties_SelectedIndexChanged);
            // 
            // lbSelectedProperties
            // 
            this.lbSelectedProperties.FormattingEnabled = true;
            this.lbSelectedProperties.Location = new System.Drawing.Point(336, 43);
            this.lbSelectedProperties.Name = "lbSelectedProperties";
            this.lbSelectedProperties.Size = new System.Drawing.Size(220, 121);
            this.lbSelectedProperties.Sorted = true;
            this.lbSelectedProperties.TabIndex = 3;
            this.lbSelectedProperties.SelectedIndexChanged += new System.EventHandler(this.lbSelectedProperties_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Available properties";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Selected properties";
            // 
            // btnOneIn
            // 
            this.btnOneIn.Location = new System.Drawing.Point(267, 43);
            this.btnOneIn.Name = "btnOneIn";
            this.btnOneIn.Size = new System.Drawing.Size(39, 23);
            this.btnOneIn.TabIndex = 6;
            this.btnOneIn.Text = ">";
            this.btnOneIn.UseVisualStyleBackColor = true;
            this.btnOneIn.Click += new System.EventHandler(this.btnOneIn_Click);
            // 
            // btnOneOut
            // 
            this.btnOneOut.Location = new System.Drawing.Point(267, 72);
            this.btnOneOut.Name = "btnOneOut";
            this.btnOneOut.Size = new System.Drawing.Size(39, 23);
            this.btnOneOut.TabIndex = 7;
            this.btnOneOut.Text = "<";
            this.btnOneOut.UseVisualStyleBackColor = true;
            this.btnOneOut.Click += new System.EventHandler(this.btnOneOut_Click);
            // 
            // btnAllIn
            // 
            this.btnAllIn.Location = new System.Drawing.Point(267, 101);
            this.btnAllIn.Name = "btnAllIn";
            this.btnAllIn.Size = new System.Drawing.Size(39, 23);
            this.btnAllIn.TabIndex = 8;
            this.btnAllIn.Text = ">>";
            this.btnAllIn.UseVisualStyleBackColor = true;
            this.btnAllIn.Click += new System.EventHandler(this.btnAllIn_Click);
            // 
            // btnAllOut
            // 
            this.btnAllOut.Location = new System.Drawing.Point(267, 141);
            this.btnAllOut.Name = "btnAllOut";
            this.btnAllOut.Size = new System.Drawing.Size(39, 23);
            this.btnAllOut.TabIndex = 9;
            this.btnAllOut.Text = "<<";
            this.btnAllOut.UseVisualStyleBackColor = true;
            this.btnAllOut.Click += new System.EventHandler(this.btnAllOut_Click);
            // 
            // btnCreatePublish
            // 
            this.btnCreatePublish.Enabled = false;
            this.btnCreatePublish.Location = new System.Drawing.Point(502, 520);
            this.btnCreatePublish.Name = "btnCreatePublish";
            this.btnCreatePublish.Size = new System.Drawing.Size(112, 24);
            this.btnCreatePublish.TabIndex = 11;
            this.btnCreatePublish.Text = "Create + Publish";
            this.btnCreatePublish.UseVisualStyleBackColor = true;
            this.btnCreatePublish.Click += new System.EventHandler(this.btnCreatePublish_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAvailableProperties);
            this.groupBox1.Controls.Add(this.lbSelectedProperties);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAllOut);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAllIn);
            this.groupBox1.Controls.Add(this.btnOneIn);
            this.groupBox1.Controls.Add(this.btnOneOut);
            this.groupBox1.Location = new System.Drawing.Point(28, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 183);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.dgvTerms);
            this.gbDetails.Controls.Add(this.btnSaveProperty);
            this.gbDetails.Controls.Add(this.tbOntologyEnd);
            this.gbDetails.Controls.Add(this.tbOntologyStart);
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.gbTerms);
            this.gbDetails.Enabled = false;
            this.gbDetails.Location = new System.Drawing.Point(28, 237);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(586, 253);
            this.gbDetails.TabIndex = 13;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Details";
            // 
            // dgvTerms
            // 
            this.dgvTerms.AllowUserToAddRows = false;
            this.dgvTerms.AllowUserToDeleteRows = false;
            this.dgvTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerms.Location = new System.Drawing.Point(24, 87);
            this.dgvTerms.Name = "dgvTerms";
            this.dgvTerms.Size = new System.Drawing.Size(536, 122);
            this.dgvTerms.TabIndex = 0;
            // 
            // btnSaveProperty
            // 
            this.btnSaveProperty.Enabled = false;
            this.btnSaveProperty.Location = new System.Drawing.Point(491, 224);
            this.btnSaveProperty.Name = "btnSaveProperty";
            this.btnSaveProperty.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProperty.TabIndex = 29;
            this.btnSaveProperty.Text = "Save";
            this.btnSaveProperty.UseVisualStyleBackColor = true;
            this.btnSaveProperty.Click += new System.EventHandler(this.btnSaveProperty_Click);
            // 
            // tbOntologyEnd
            // 
            this.tbOntologyEnd.Location = new System.Drawing.Point(368, 23);
            this.tbOntologyEnd.Name = "tbOntologyEnd";
            this.tbOntologyEnd.Size = new System.Drawing.Size(188, 20);
            this.tbOntologyEnd.TabIndex = 4;
            this.tbOntologyEnd.TextChanged += new System.EventHandler(this.tbOntologyEnd_TextChanged);
            // 
            // tbOntologyStart
            // 
            this.tbOntologyStart.Location = new System.Drawing.Point(64, 23);
            this.tbOntologyStart.Name = "tbOntologyStart";
            this.tbOntologyStart.Size = new System.Drawing.Size(174, 20);
            this.tbOntologyStart.TabIndex = 3;
            this.tbOntologyStart.TextChanged += new System.EventHandler(this.tbOntologyStart_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "End:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Start:";
            // 
            // gbTerms
            // 
            this.gbTerms.Location = new System.Drawing.Point(18, 59);
            this.gbTerms.Name = "gbTerms";
            this.gbTerms.Size = new System.Drawing.Size(548, 159);
            this.gbTerms.TabIndex = 0;
            this.gbTerms.TabStop = false;
            this.gbTerms.Text = "Terms";
            // 
            // CreateOntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 556);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreatePublish);
            this.Controls.Add(this.tbOntologyName);
            this.Controls.Add(this.label1);
            this.Name = "CreateOntologyForm";
            this.Text = "Create Ontology";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOntologyName;
        private System.Windows.Forms.ListBox lbAvailableProperties;
        private System.Windows.Forms.ListBox lbSelectedProperties;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOneIn;
        private System.Windows.Forms.Button btnOneOut;
        private System.Windows.Forms.Button btnAllIn;
        private System.Windows.Forms.Button btnAllOut;
        private System.Windows.Forms.Button btnCreatePublish;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.TextBox tbOntologyEnd;
        private System.Windows.Forms.TextBox tbOntologyStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveProperty;
        private System.Windows.Forms.GroupBox gbTerms;
        private System.Windows.Forms.DataGridView dgvTerms;
    }
}