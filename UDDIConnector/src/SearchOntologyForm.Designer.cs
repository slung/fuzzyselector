namespace UDDIConnector {

    partial class SearchOntologyForm {

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
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.chkExactMatch = new System.Windows.Forms.CheckBox();
            this.txbOntologyName = new System.Windows.Forms.TextBox();
            this.lblOntologyName = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteOntologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSearch.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.chkCaseSensitive);
            this.groupBoxSearch.Controls.Add(this.chkExactMatch);
            this.groupBoxSearch.Controls.Add(this.txbOntologyName);
            this.groupBoxSearch.Controls.Add(this.lblOntologyName);
            this.groupBoxSearch.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(305, 158);
            this.groupBoxSearch.TabIndex = 8;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search parameters";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(9, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCaseSensitive.Location = new System.Drawing.Point(9, 51);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(112, 32);
            this.chkCaseSensitive.TabIndex = 2;
            this.chkCaseSensitive.Text = "Case sensitive";
            // 
            // chkExactMatch
            // 
            this.chkExactMatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkExactMatch.Location = new System.Drawing.Point(9, 89);
            this.chkExactMatch.Name = "chkExactMatch";
            this.chkExactMatch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkExactMatch.Size = new System.Drawing.Size(109, 17);
            this.chkExactMatch.TabIndex = 3;
            this.chkExactMatch.Text = "Exact match";
            // 
            // txbOntologyName
            // 
            this.txbOntologyName.Location = new System.Drawing.Point(107, 21);
            this.txbOntologyName.Name = "txbOntologyName";
            this.txbOntologyName.Size = new System.Drawing.Size(184, 20);
            this.txbOntologyName.TabIndex = 1;
            // 
            // lblOntologyName
            // 
            this.lblOntologyName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOntologyName.Location = new System.Drawing.Point(6, 24);
            this.lblOntologyName.Name = "lblOntologyName";
            this.lblOntologyName.Size = new System.Drawing.Size(136, 13);
            this.lblOntologyName.TabIndex = 17;
            this.lblOntologyName.Text = "Ontology name :";
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.CausesValidation = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(341, 12);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(504, 158);
            this.listView.TabIndex = 5;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Owner";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ontology Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "URL";
            this.columnHeader2.Width = 300;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteOntologyToolStripMenuItem,
            this.updateURLToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(164, 48);
            // 
            // deleteOntologyToolStripMenuItem
            // 
            this.deleteOntologyToolStripMenuItem.Name = "deleteOntologyToolStripMenuItem";
            this.deleteOntologyToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deleteOntologyToolStripMenuItem.Text = "Delete Ontology";
            this.deleteOntologyToolStripMenuItem.Click += new System.EventHandler(this.deleteOntology_Click);
            // 
            // updateURLToolStripMenuItem
            // 
            this.updateURLToolStripMenuItem.Name = "updateURLToolStripMenuItem";
            this.updateURLToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.updateURLToolStripMenuItem.Text = "Update URL";
            this.updateURLToolStripMenuItem.Click += new System.EventHandler(this.updateURL_Click);
            // 
            // SearchOntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 181);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.listView);
            this.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.MinimumSize = new System.Drawing.Size(865, 215);
            this.Name = "SearchOntologyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Ontology";
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.CheckBox chkExactMatch;
        private System.Windows.Forms.TextBox txbOntologyName;
        private System.Windows.Forms.Label lblOntologyName;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteOntologyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateURLToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}