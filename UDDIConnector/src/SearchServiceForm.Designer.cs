namespace UDDIConnector {

    partial class SearchServiceForm {

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
            this.chkUseOntology = new System.Windows.Forms.CheckBox();
            this.cbxOntology = new System.Windows.Forms.ComboBox();
            this.lblOntology = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.labelServiceName = new System.Windows.Forms.Label();
            this.chkExactMatch = new System.Windows.Forms.CheckBox();
            this.txbBusinessName = new System.Windows.Forms.TextBox();
            this.labelBusinessName = new System.Windows.Forms.Label();
            this.txbServiceName = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateAccessPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAccessPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBusinessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSearch.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.chkUseOntology);
            this.groupBoxSearch.Controls.Add(this.cbxOntology);
            this.groupBoxSearch.Controls.Add(this.lblOntology);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.chkCaseSensitive);
            this.groupBoxSearch.Controls.Add(this.labelServiceName);
            this.groupBoxSearch.Controls.Add(this.chkExactMatch);
            this.groupBoxSearch.Controls.Add(this.txbBusinessName);
            this.groupBoxSearch.Controls.Add(this.labelBusinessName);
            this.groupBoxSearch.Controls.Add(this.txbServiceName);
            this.groupBoxSearch.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(344, 262);
            this.groupBoxSearch.TabIndex = 3;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search parameters";
            // 
            // chkUseOntology
            // 
            this.chkUseOntology.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUseOntology.Location = new System.Drawing.Point(9, 187);
            this.chkUseOntology.Name = "chkUseOntology";
            this.chkUseOntology.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkUseOntology.Size = new System.Drawing.Size(109, 17);
            this.chkUseOntology.TabIndex = 6;
            this.chkUseOntology.Text = "Use ontology";
            // 
            // cbxOntology
            // 
            this.cbxOntology.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOntology.FormattingEnabled = true;
            this.cbxOntology.Location = new System.Drawing.Point(126, 151);
            this.cbxOntology.Name = "cbxOntology";
            this.cbxOntology.Size = new System.Drawing.Size(203, 21);
            this.cbxOntology.TabIndex = 5;
            // 
            // lblOntology
            // 
            this.lblOntology.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOntology.Location = new System.Drawing.Point(9, 154);
            this.lblOntology.Name = "lblOntology";
            this.lblOntology.Size = new System.Drawing.Size(136, 13);
            this.lblOntology.TabIndex = 22;
            this.lblOntology.Text = "Ontology :";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(9, 224);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCaseSensitive.Location = new System.Drawing.Point(9, 87);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(95, 23);
            this.chkCaseSensitive.TabIndex = 3;
            this.chkCaseSensitive.Text = "Case sensitive";
            // 
            // labelServiceName
            // 
            this.labelServiceName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelServiceName.Location = new System.Drawing.Point(6, 55);
            this.labelServiceName.Name = "labelServiceName";
            this.labelServiceName.Size = new System.Drawing.Size(115, 16);
            this.labelServiceName.TabIndex = 21;
            this.labelServiceName.Text = "Service name :";
            // 
            // chkExactMatch
            // 
            this.chkExactMatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkExactMatch.Location = new System.Drawing.Point(9, 116);
            this.chkExactMatch.Name = "chkExactMatch";
            this.chkExactMatch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkExactMatch.Size = new System.Drawing.Size(109, 17);
            this.chkExactMatch.TabIndex = 4;
            this.chkExactMatch.Text = "Exact match";
            // 
            // txbBusinessName
            // 
            this.txbBusinessName.Location = new System.Drawing.Point(126, 21);
            this.txbBusinessName.Name = "txbBusinessName";
            this.txbBusinessName.Size = new System.Drawing.Size(203, 20);
            this.txbBusinessName.TabIndex = 1;
            // 
            // labelBusinessName
            // 
            this.labelBusinessName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelBusinessName.Location = new System.Drawing.Point(6, 24);
            this.labelBusinessName.Name = "labelBusinessName";
            this.labelBusinessName.Size = new System.Drawing.Size(136, 13);
            this.labelBusinessName.TabIndex = 17;
            this.labelBusinessName.Text = "Business name :";
            // 
            // txbServiceName
            // 
            this.txbServiceName.Location = new System.Drawing.Point(126, 51);
            this.txbServiceName.Name = "txbServiceName";
            this.txbServiceName.Size = new System.Drawing.Size(203, 20);
            this.txbServiceName.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.CausesValidation = false;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader3});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(382, 12);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(483, 262);
            this.listView.TabIndex = 8;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Owner";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Business Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Service Name";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ontology";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Access Point";
            this.columnHeader3.Width = 330;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateAccessPointToolStripMenuItem,
            this.deleteAccessPointToolStripMenuItem,
            this.deleteServiceToolStripMenuItem,
            this.deleteBusinessToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(184, 92);
            // 
            // updateAccessPointToolStripMenuItem
            // 
            this.updateAccessPointToolStripMenuItem.Name = "updateAccessPointToolStripMenuItem";
            this.updateAccessPointToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.updateAccessPointToolStripMenuItem.Text = "Update Access Point";
            this.updateAccessPointToolStripMenuItem.Click += new System.EventHandler(this.updateBinding_Click);
            // 
            // deleteAccessPointToolStripMenuItem
            // 
            this.deleteAccessPointToolStripMenuItem.Name = "deleteAccessPointToolStripMenuItem";
            this.deleteAccessPointToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.deleteAccessPointToolStripMenuItem.Text = "Delete Access Point";
            this.deleteAccessPointToolStripMenuItem.Click += new System.EventHandler(this.deleteBinding_Click);
            // 
            // deleteServiceToolStripMenuItem
            // 
            this.deleteServiceToolStripMenuItem.Name = "deleteServiceToolStripMenuItem";
            this.deleteServiceToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.deleteServiceToolStripMenuItem.Text = "Delete Service";
            this.deleteServiceToolStripMenuItem.Click += new System.EventHandler(this.deleteService_Click);
            // 
            // deleteBusinessToolStripMenuItem
            // 
            this.deleteBusinessToolStripMenuItem.Name = "deleteBusinessToolStripMenuItem";
            this.deleteBusinessToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.deleteBusinessToolStripMenuItem.Text = "Delete Business";
            this.deleteBusinessToolStripMenuItem.Click += new System.EventHandler(this.deleteBusiness_Click);
            // 
            // SearchServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 286);
            this.Controls.Add(this.groupBoxSearch);
            this.Controls.Add(this.listView);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(900, 320);
            this.Name = "SearchServiceForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Service";
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.Label labelServiceName;
        private System.Windows.Forms.CheckBox chkExactMatch;
        private System.Windows.Forms.TextBox txbBusinessName;
        private System.Windows.Forms.Label labelBusinessName;
        private System.Windows.Forms.TextBox txbServiceName;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteAccessPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAccessPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBusinessToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbxOntology;
        private System.Windows.Forms.Label lblOntology;
        private System.Windows.Forms.CheckBox chkUseOntology;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

