namespace UDDIConnector {

    partial class ProviderForm {

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
            this.btnPublishService = new System.Windows.Forms.Button();
            this.btnSearchOntology = new System.Windows.Forms.Button();
            this.btnPublishOntology = new System.Windows.Forms.Button();
            this.btnSearchService = new System.Windows.Forms.Button();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.gbPublish = new System.Windows.Forms.GroupBox();
            this.btnCreateOntology = new System.Windows.Forms.Button();
            this.btnUDDIConnection = new System.Windows.Forms.Button();
            this.gbCreate = new System.Windows.Forms.GroupBox();
            this.gbCompose = new System.Windows.Forms.GroupBox();
            this.btnComposeOntologies = new System.Windows.Forms.Button();
            this.gbActions.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.gbPublish.SuspendLayout();
            this.gbCreate.SuspendLayout();
            this.gbCompose.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPublishService
            // 
            this.btnPublishService.Location = new System.Drawing.Point(18, 30);
            this.btnPublishService.Name = "btnPublishService";
            this.btnPublishService.Size = new System.Drawing.Size(109, 23);
            this.btnPublishService.TabIndex = 2;
            this.btnPublishService.Text = "Publish Service";
            this.btnPublishService.UseVisualStyleBackColor = true;
            this.btnPublishService.Click += new System.EventHandler(this.btnPublishService_Click);
            // 
            // btnSearchOntology
            // 
            this.btnSearchOntology.Location = new System.Drawing.Point(21, 70);
            this.btnSearchOntology.Name = "btnSearchOntology";
            this.btnSearchOntology.Size = new System.Drawing.Size(101, 23);
            this.btnSearchOntology.TabIndex = 5;
            this.btnSearchOntology.Text = "Search Ontology";
            this.btnSearchOntology.UseVisualStyleBackColor = true;
            this.btnSearchOntology.Click += new System.EventHandler(this.btnSearchOntology_Click);
            // 
            // btnPublishOntology
            // 
            this.btnPublishOntology.Location = new System.Drawing.Point(18, 70);
            this.btnPublishOntology.Name = "btnPublishOntology";
            this.btnPublishOntology.Size = new System.Drawing.Size(109, 23);
            this.btnPublishOntology.TabIndex = 3;
            this.btnPublishOntology.Text = "Publish Ontology";
            this.btnPublishOntology.UseVisualStyleBackColor = true;
            this.btnPublishOntology.Click += new System.EventHandler(this.btnPublishOntology_Click);
            // 
            // btnSearchService
            // 
            this.btnSearchService.Location = new System.Drawing.Point(21, 30);
            this.btnSearchService.Name = "btnSearchService";
            this.btnSearchService.Size = new System.Drawing.Size(101, 23);
            this.btnSearchService.TabIndex = 4;
            this.btnSearchService.Text = "Search Service";
            this.btnSearchService.UseVisualStyleBackColor = true;
            this.btnSearchService.Click += new System.EventHandler(this.btnSearchService_Click);
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.gbCompose);
            this.gbActions.Controls.Add(this.gbCreate);
            this.gbActions.Controls.Add(this.gbPublish);
            this.gbActions.Controls.Add(this.gbSearch);
            this.gbActions.Location = new System.Drawing.Point(12, 51);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(670, 169);
            this.gbActions.TabIndex = 16;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Actions";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnSearchService);
            this.gbSearch.Controls.Add(this.btnSearchOntology);
            this.gbSearch.Location = new System.Drawing.Point(509, 30);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(146, 119);
            this.gbSearch.TabIndex = 17;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // gbPublish
            // 
            this.gbPublish.Controls.Add(this.btnPublishService);
            this.gbPublish.Controls.Add(this.btnPublishOntology);
            this.gbPublish.Location = new System.Drawing.Point(176, 30);
            this.gbPublish.Name = "gbPublish";
            this.gbPublish.Size = new System.Drawing.Size(146, 119);
            this.gbPublish.TabIndex = 16;
            this.gbPublish.TabStop = false;
            this.gbPublish.Text = "Publish";
            // 
            // btnCreateOntology
            // 
            this.btnCreateOntology.Location = new System.Drawing.Point(20, 30);
            this.btnCreateOntology.Name = "btnCreateOntology";
            this.btnCreateOntology.Size = new System.Drawing.Size(109, 23);
            this.btnCreateOntology.TabIndex = 4;
            this.btnCreateOntology.Text = "Create Ontology";
            this.btnCreateOntology.UseVisualStyleBackColor = true;
            this.btnCreateOntology.Click += new System.EventHandler(this.btnCreateOntology_Click);
            // 
            // btnUDDIConnection
            // 
            this.btnUDDIConnection.Location = new System.Drawing.Point(12, 14);
            this.btnUDDIConnection.Name = "btnUDDIConnection";
            this.btnUDDIConnection.Size = new System.Drawing.Size(670, 23);
            this.btnUDDIConnection.TabIndex = 1;
            this.btnUDDIConnection.Text = "UDDI Connection";
            this.btnUDDIConnection.UseVisualStyleBackColor = true;
            this.btnUDDIConnection.Click += new System.EventHandler(this.btnUDDIConnection_Click);
            // 
            // gbCreate
            // 
            this.gbCreate.Controls.Add(this.btnCreateOntology);
            this.gbCreate.Location = new System.Drawing.Point(15, 30);
            this.gbCreate.Name = "gbCreate";
            this.gbCreate.Size = new System.Drawing.Size(146, 119);
            this.gbCreate.TabIndex = 18;
            this.gbCreate.TabStop = false;
            this.gbCreate.Text = "Create";
            // 
            // gbCompose
            // 
            this.gbCompose.Controls.Add(this.btnComposeOntologies);
            this.gbCompose.Location = new System.Drawing.Point(337, 30);
            this.gbCompose.Name = "gbCompose";
            this.gbCompose.Size = new System.Drawing.Size(157, 119);
            this.gbCompose.TabIndex = 19;
            this.gbCompose.TabStop = false;
            this.gbCompose.Text = "Compose";
            // 
            // btnComposeOntologies
            // 
            this.btnComposeOntologies.Location = new System.Drawing.Point(18, 30);
            this.btnComposeOntologies.Name = "btnComposeOntologies";
            this.btnComposeOntologies.Size = new System.Drawing.Size(120, 23);
            this.btnComposeOntologies.TabIndex = 0;
            this.btnComposeOntologies.Text = "Compose Ontologies";
            this.btnComposeOntologies.UseVisualStyleBackColor = true;
            this.btnComposeOntologies.Click += new System.EventHandler(this.btnComposeOntologies_Click);
            // 
            // ProviderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 232);
            this.Controls.Add(this.btnUDDIConnection);
            this.Controls.Add(this.gbActions);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(708, 270);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(385, 270);
            this.Name = "ProviderForm";
            this.Text = "Service Provider";
            this.gbActions.ResumeLayout(false);
            this.gbSearch.ResumeLayout(false);
            this.gbPublish.ResumeLayout(false);
            this.gbCreate.ResumeLayout(false);
            this.gbCompose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPublishService;
        private System.Windows.Forms.Button btnSearchOntology;
        private System.Windows.Forms.Button btnPublishOntology;
        private System.Windows.Forms.Button btnSearchService;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.GroupBox gbPublish;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnUDDIConnection;
        private System.Windows.Forms.Button btnCreateOntology;
        private System.Windows.Forms.GroupBox gbCompose;
        private System.Windows.Forms.Button btnComposeOntologies;
        private System.Windows.Forms.GroupBox gbCreate;
    }
}