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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbTerms = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbOntologyStart = new System.Windows.Forms.TextBox();
            this.tbOntologyEnd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTermName0 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTermStart0 = new System.Windows.Forms.TextBox();
            this.tbTermLeft0 = new System.Windows.Forms.TextBox();
            this.tbTermRight0 = new System.Windows.Forms.TextBox();
            this.tbTermEnd0 = new System.Windows.Forms.TextBox();
            this.tbTermEnd1 = new System.Windows.Forms.TextBox();
            this.tbTermRight1 = new System.Windows.Forms.TextBox();
            this.tbTermLeft1 = new System.Windows.Forms.TextBox();
            this.tbTermStart1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbTermName1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbTermEnd2 = new System.Windows.Forms.TextBox();
            this.tbTermRight2 = new System.Windows.Forms.TextBox();
            this.tbTermLeft2 = new System.Windows.Forms.TextBox();
            this.tbTermStart2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbTermName2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbTerms.SuspendLayout();
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
            // 
            // lbAvailableProperties
            // 
            this.lbAvailableProperties.FormattingEnabled = true;
            this.lbAvailableProperties.Location = new System.Drawing.Point(29, 43);
            this.lbAvailableProperties.Name = "lbAvailableProperties";
            this.lbAvailableProperties.Size = new System.Drawing.Size(209, 121);
            this.lbAvailableProperties.Sorted = true;
            this.lbAvailableProperties.TabIndex = 2;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(502, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "Create + Publish";
            this.button1.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbOntologyEnd);
            this.groupBox2.Controls.Add(this.tbOntologyStart);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.gbTerms);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(28, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 214);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // gbTerms
            // 
            this.gbTerms.Controls.Add(this.tbTermEnd2);
            this.gbTerms.Controls.Add(this.tbTermRight2);
            this.gbTerms.Controls.Add(this.tbTermLeft2);
            this.gbTerms.Controls.Add(this.tbTermStart2);
            this.gbTerms.Controls.Add(this.label16);
            this.gbTerms.Controls.Add(this.label17);
            this.gbTerms.Controls.Add(this.label18);
            this.gbTerms.Controls.Add(this.label19);
            this.gbTerms.Controls.Add(this.tbTermName2);
            this.gbTerms.Controls.Add(this.label20);
            this.gbTerms.Controls.Add(this.tbTermEnd1);
            this.gbTerms.Controls.Add(this.tbTermRight1);
            this.gbTerms.Controls.Add(this.tbTermLeft1);
            this.gbTerms.Controls.Add(this.tbTermStart1);
            this.gbTerms.Controls.Add(this.label11);
            this.gbTerms.Controls.Add(this.label12);
            this.gbTerms.Controls.Add(this.label13);
            this.gbTerms.Controls.Add(this.label14);
            this.gbTerms.Controls.Add(this.tbTermName1);
            this.gbTerms.Controls.Add(this.label15);
            this.gbTerms.Controls.Add(this.tbTermEnd0);
            this.gbTerms.Controls.Add(this.tbTermRight0);
            this.gbTerms.Controls.Add(this.tbTermLeft0);
            this.gbTerms.Controls.Add(this.tbTermStart0);
            this.gbTerms.Controls.Add(this.label10);
            this.gbTerms.Controls.Add(this.label9);
            this.gbTerms.Controls.Add(this.label8);
            this.gbTerms.Controls.Add(this.label7);
            this.gbTerms.Controls.Add(this.tbTermName0);
            this.gbTerms.Controls.Add(this.label6);
            this.gbTerms.Location = new System.Drawing.Point(18, 59);
            this.gbTerms.Name = "gbTerms";
            this.gbTerms.Size = new System.Drawing.Size(548, 138);
            this.gbTerms.TabIndex = 0;
            this.gbTerms.TabStop = false;
            this.gbTerms.Text = "Terms";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "End:";
            // 
            // tbOntologyStart
            // 
            this.tbOntologyStart.Location = new System.Drawing.Point(64, 23);
            this.tbOntologyStart.Name = "tbOntologyStart";
            this.tbOntologyStart.Size = new System.Drawing.Size(174, 20);
            this.tbOntologyStart.TabIndex = 3;
            // 
            // tbOntologyEnd
            // 
            this.tbOntologyEnd.Location = new System.Drawing.Point(368, 23);
            this.tbOntologyEnd.Name = "tbOntologyEnd";
            this.tbOntologyEnd.Size = new System.Drawing.Size(188, 20);
            this.tbOntologyEnd.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name:";
            // 
            // tbTermName0
            // 
            this.tbTermName0.Location = new System.Drawing.Point(52, 25);
            this.tbTermName0.Name = "tbTermName0";
            this.tbTermName0.ReadOnly = true;
            this.tbTermName0.Size = new System.Drawing.Size(100, 20);
            this.tbTermName0.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Start:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(438, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "End:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(249, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Left:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(337, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Right:";
            // 
            // tbTermStart0
            // 
            this.tbTermStart0.Location = new System.Drawing.Point(189, 25);
            this.tbTermStart0.Name = "tbTermStart0";
            this.tbTermStart0.Size = new System.Drawing.Size(54, 20);
            this.tbTermStart0.TabIndex = 5;
            // 
            // tbTermLeft0
            // 
            this.tbTermLeft0.Location = new System.Drawing.Point(277, 25);
            this.tbTermLeft0.Name = "tbTermLeft0";
            this.tbTermLeft0.Size = new System.Drawing.Size(54, 20);
            this.tbTermLeft0.TabIndex = 6;
            // 
            // tbTermRight0
            // 
            this.tbTermRight0.Location = new System.Drawing.Point(378, 25);
            this.tbTermRight0.Name = "tbTermRight0";
            this.tbTermRight0.Size = new System.Drawing.Size(54, 20);
            this.tbTermRight0.TabIndex = 7;
            // 
            // tbTermEnd0
            // 
            this.tbTermEnd0.Location = new System.Drawing.Point(473, 25);
            this.tbTermEnd0.Name = "tbTermEnd0";
            this.tbTermEnd0.Size = new System.Drawing.Size(54, 20);
            this.tbTermEnd0.TabIndex = 8;
            // 
            // tbTermEnd1
            // 
            this.tbTermEnd1.Location = new System.Drawing.Point(473, 66);
            this.tbTermEnd1.Name = "tbTermEnd1";
            this.tbTermEnd1.Size = new System.Drawing.Size(54, 20);
            this.tbTermEnd1.TabIndex = 18;
            // 
            // tbTermRight1
            // 
            this.tbTermRight1.Location = new System.Drawing.Point(378, 66);
            this.tbTermRight1.Name = "tbTermRight1";
            this.tbTermRight1.Size = new System.Drawing.Size(54, 20);
            this.tbTermRight1.TabIndex = 17;
            // 
            // tbTermLeft1
            // 
            this.tbTermLeft1.Location = new System.Drawing.Point(277, 66);
            this.tbTermLeft1.Name = "tbTermLeft1";
            this.tbTermLeft1.Size = new System.Drawing.Size(54, 20);
            this.tbTermLeft1.TabIndex = 16;
            // 
            // tbTermStart1
            // 
            this.tbTermStart1.Location = new System.Drawing.Point(189, 66);
            this.tbTermStart1.Name = "tbTermStart1";
            this.tbTermStart1.Size = new System.Drawing.Size(54, 20);
            this.tbTermStart1.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(337, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Right:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(249, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Left:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(438, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "End:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(158, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Start:";
            // 
            // tbTermName1
            // 
            this.tbTermName1.Location = new System.Drawing.Point(52, 66);
            this.tbTermName1.Name = "tbTermName1";
            this.tbTermName1.ReadOnly = true;
            this.tbTermName1.Size = new System.Drawing.Size(100, 20);
            this.tbTermName1.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Name:";
            // 
            // tbTermEnd2
            // 
            this.tbTermEnd2.Location = new System.Drawing.Point(473, 102);
            this.tbTermEnd2.Name = "tbTermEnd2";
            this.tbTermEnd2.Size = new System.Drawing.Size(54, 20);
            this.tbTermEnd2.TabIndex = 28;
            // 
            // tbTermRight2
            // 
            this.tbTermRight2.Location = new System.Drawing.Point(378, 102);
            this.tbTermRight2.Name = "tbTermRight2";
            this.tbTermRight2.Size = new System.Drawing.Size(54, 20);
            this.tbTermRight2.TabIndex = 27;
            // 
            // tbTermLeft2
            // 
            this.tbTermLeft2.Location = new System.Drawing.Point(277, 102);
            this.tbTermLeft2.Name = "tbTermLeft2";
            this.tbTermLeft2.Size = new System.Drawing.Size(54, 20);
            this.tbTermLeft2.TabIndex = 26;
            // 
            // tbTermStart2
            // 
            this.tbTermStart2.Location = new System.Drawing.Point(189, 102);
            this.tbTermStart2.Name = "tbTermStart2";
            this.tbTermStart2.Size = new System.Drawing.Size(54, 20);
            this.tbTermStart2.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(337, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Right:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(249, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Left:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(438, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "End:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(158, 105);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Start:";
            // 
            // tbTermName2
            // 
            this.tbTermName2.Location = new System.Drawing.Point(52, 102);
            this.tbTermName2.Name = "tbTermName2";
            this.tbTermName2.ReadOnly = true;
            this.tbTermName2.Size = new System.Drawing.Size(100, 20);
            this.tbTermName2.TabIndex = 20;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 105);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "Name:";
            // 
            // CreateOntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 511);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbOntologyName);
            this.Controls.Add(this.label1);
            this.Name = "CreateOntologyForm";
            this.Text = "Create Ontology";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbTerms.ResumeLayout(false);
            this.gbTerms.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbOntologyEnd;
        private System.Windows.Forms.TextBox tbOntologyStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbTerms;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTermEnd0;
        private System.Windows.Forms.TextBox tbTermRight0;
        private System.Windows.Forms.TextBox tbTermLeft0;
        private System.Windows.Forms.TextBox tbTermStart0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTermName0;
        private System.Windows.Forms.TextBox tbTermEnd2;
        private System.Windows.Forms.TextBox tbTermRight2;
        private System.Windows.Forms.TextBox tbTermLeft2;
        private System.Windows.Forms.TextBox tbTermStart2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbTermName2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbTermEnd1;
        private System.Windows.Forms.TextBox tbTermRight1;
        private System.Windows.Forms.TextBox tbTermLeft1;
        private System.Windows.Forms.TextBox tbTermStart1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbTermName1;
        private System.Windows.Forms.Label label15;
    }
}