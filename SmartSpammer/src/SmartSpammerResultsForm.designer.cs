namespace FuzzySelector.SmartSpammer
{
    partial class SmartSpammerResultsForm
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
            this.resultRichTextBox = new System.Windows.Forms.RichTextBox();
            this.resultListView = new System.Windows.Forms.ListView();
            this.testConfigNumber = new System.Windows.Forms.ColumnHeader();
            this.runTimeSec = new System.Windows.Forms.ColumnHeader();
            this.runTimeMiliSec = new System.Windows.Forms.ColumnHeader();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resultRichTextBox
            // 
            this.resultRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultRichTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.resultRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.resultRichTextBox.MinimumSize = new System.Drawing.Size(300, 100);
            this.resultRichTextBox.Name = "resultRichTextBox";
            this.resultRichTextBox.ReadOnly = true;
            this.resultRichTextBox.Size = new System.Drawing.Size(436, 118);
            this.resultRichTextBox.TabIndex = 0;
            this.resultRichTextBox.Text = "";
            // 
            // resultListView
            // 
            this.resultListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultListView.CausesValidation = false;
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.testConfigNumber,
            this.runTimeSec,
            this.runTimeMiliSec});
            this.resultListView.FullRowSelect = true;
            this.resultListView.GridLines = true;
            this.resultListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.resultListView.Location = new System.Drawing.Point(0, 118);
            this.resultListView.MinimumSize = new System.Drawing.Size(300, 149);
            this.resultListView.MultiSelect = false;
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(436, 191);
            this.resultListView.TabIndex = 1;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            this.resultListView.SelectedIndexChanged += new System.EventHandler(this.resultListView_SelectedIndexChanged);
            // 
            // testConfigNumber
            // 
            this.testConfigNumber.Text = "Test No.";
            this.testConfigNumber.Width = 93;
            // 
            // runTimeSec
            // 
            this.runTimeSec.Text = "Run Time (seconds)";
            this.runTimeSec.Width = 151;
            // 
            // runTimeMiliSec
            // 
            this.runTimeMiliSec.Text = "Run Time (milliseconds)";
            this.runTimeMiliSec.Width = 192;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CSV (Comma delimited) (*.csv)|*.csv|Text (Tab delimited) (*.txt)|*.txt|All files " +
                "(*.*)|*.*";
            this.saveFileDialog.Title = "Save to File";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(0, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(436, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save to File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SmartSpammerResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 327);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.resultListView);
            this.Controls.Add(this.resultRichTextBox);
            this.MaximumSize = new System.Drawing.Size(444, 354);
            this.MinimumSize = new System.Drawing.Size(444, 354);
            this.Name = "SmartSpammerResultsForm";
            this.Text = "SmartSpammer Results Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox resultRichTextBox;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.ColumnHeader testConfigNumber;
        private System.Windows.Forms.ColumnHeader runTimeSec;
        private System.Windows.Forms.ColumnHeader runTimeMiliSec;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnSave;
    }
}