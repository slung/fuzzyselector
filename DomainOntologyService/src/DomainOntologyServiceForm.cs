using System;
using System.Windows.Forms;

using FuzzySelector.Common.GraphicVisualizer;
using FuzzySelector.Common.Ontology;

using DomainOntologyService.resx;

namespace FuzzySelector.DomainOntologyService {

    /// <summary>
    ///   Fereastra procesului serviciului ontologiei domeniului.
    /// </summary>
    public partial class DomainOntologyServiceForm : Form {

        /// <summary>
        ///   Serviciul ontologiei domeniului ataşat.
        /// </summary>
        private DomainOntologyService domainOntologyService;

        /// <summary>
        ///   Fereastra de vizualizare a termenilor.
        /// </summary>
        private Visualizer visualizer = null;

        /// <param name="domainOntologyService">Serviciul ontologiei domeniului ataşat.</param>
        public DomainOntologyServiceForm(DomainOntologyService domainOntologyService) {

            InitializeComponent();

            this.domainOntologyService = domainOntologyService;
            this.visualizer = null;

            this.nudPort.Value = DomainOntologyServiceSettings.Default.LISTENING_PORT;
            this.Bounds        = DomainOntologyServiceSettings.Default.BOUNDS;
            this.splitContainerTop.SplitterDistance    = DomainOntologyServiceSettings.Default.SEPARATOR_FUNCTIONALITIES_PROPERTIES;
            this.splitContainerBottom.SplitterDistance = DomainOntologyServiceSettings.Default.SEPARATOR_PROPERTIES_TERMS;
        
            //this.lbFunctionality.Items.AddRange(this.domainOntologyService.functionalities);

            //this.btnListen_Click(null, null);
        }

        /// <summary>
        ///   Indică selectarea altei funcţionalităţi oferite.
        ///   Afişează proprietăţile funcţionalităţii selectate.
        /// </summary>
        private void lbFunctionality_SelectedIndexChanged(object sender, EventArgs e) {

            if (this.lbFunctionality.SelectedIndex >= 0) {

                this.lbProperties.Items.Clear();
                this.lbTerms.Items.Clear();

                this.lbProperties.Items.AddRange((this.lbFunctionality.SelectedItem as Functionality).properties);
            }
        }

        /// <summary>
        ///   Indică selectarea altei proprietăţi a funcţionalităţii selectate.
        ///   Afişează termenii proprietăţii selectate şi încarcă fereastra de vizualizare a termenilor.
        /// </summary>
        private void lbProperties_SelectedIndexChanged(object sender, EventArgs e) {

            if (this.lbProperties.SelectedIndex >= 0) {

                this.lbTerms.Items.Clear();
     
                Property property = this.lbProperties.SelectedItem as Property;
               
                this.lbTerms.Items.AddRange(property.terms);
           
                if (this.visualizer != null) {

                    this.visualizer.closeMe();
                }

                this.visualizer = new Visualizer(property.name, -1, this.Height, this.Left + this.Width, this.Top, null);
                this.visualizer.addProperty(property, System.Drawing.Color.Green, System.Drawing.Color.Blue, true);
            }
        }

        /// <summary>
        ///   Indică selectarea altui termen a proprietăţii selectate.
        ///   Împrospătează fereastra de vizualizare termenilor dacă este deschisă.
        /// </summary>
        private void lbTerms_SelectedIndexChanged(object sender, EventArgs e) {

            if (this.lbTerms.SelectedIndex >= 0) {

                if (this.visualizer != null) {

                    Property property = this.lbProperties.SelectedItem as Property;
                    
                    if (property != null) {
                        
                        Term term = this.lbTerms.SelectedItem as Term;
                        
                        foreach (Term propertyTerm in property.terms) {

                            this.visualizer.changeTermAxis(propertyTerm, propertyTerm != term);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Indică schimbarea portului de ascultare.
        ///   Salvează noul port în setări.
        /// </summary>
        private void nudPort_ValueChanged(object sender, EventArgs e) {

            DomainOntologyServiceSettings.Default.LISTENING_PORT = (int)this.nudPort.Value;
            DomainOntologyServiceSettings.Default.Save();
        }

        /// <summary>
        ///   Indică apăsarea butonului de pornire/oprire a serviciului.
        ///   Porneşte sau opreşte ascultarea după mesaje pe portul indicat.
        /// </summary>
        private void btnListen_Click(object sender, EventArgs e) {

            if (this.domainOntologyService.listener.isListening) {

                this.domainOntologyService.listener.stopListening();
                this.btnListen.Text  = this.mnuStartService.Text = "Start Service";
                this.nudPort.Enabled = true;
            } 
            else {

                this.nudPort.Enabled = false;
                this.btnListen.Text  = this.mnuStartService.Text = "Stop Service";
                this.domainOntologyService.listener.startListening((int)this.nudPort.Value);
            }
        }

        /// <summary>
        ///   Indică redimensionarea ferestrei, minimizarea acesteia sau revenirea din sistem tray.
        ///   Face schimbările vizuale necesare.
        /// </summary>
        private void DomainOntologyServiceForm_Resize(object sender, EventArgs e) {

            if (this.WindowState == FormWindowState.Minimized) {

                DomainOntologyServiceSettings.Default.BOUNDS = this.RestoreBounds;
                DomainOntologyServiceSettings.Default.Save();

                this.notifyIcon.Visible = true;
                this.Hide();
            } 
            else {

                if (this.WindowState == FormWindowState.Normal) {

                    this.notifyIcon.Visible = false;
                    this.ShowInTaskbar = true;
                }
            }
        }

        /// <summary>
        ///   Indică un click dublu pe pictograma din sistem tray.
        ///   Revine în modul normal de afişare din modul sistem tray.
        /// </summary>
        private void notifyIcon_DoubleClick(object sender, EventArgs e) {

            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        ///   Indică apăsarea meniului de închidere a procesului în modul sistem tray.
        ///   Inchide procesul.
        /// </summary>
        private void mnuEndProgram_Click(object sender, EventArgs e) {

            this.Close();
        }

        /// <summary>
        ///   Indică încărcarea vizuală a ferestrei.
        ///   Afişează pictograma în sistem tray (se porneşte minimizat) şi activează handler-ul pentru redimensionarea ferestrei.
        /// </summary>
        private void DomainOntologyServiceForm_Load(object sender, EventArgs e) {

            this.notifyIcon.Visible = true;
            this.Resize += new System.EventHandler(this.DomainOntologyServiceForm_Resize);
        }

        /// <summary>
        ///   Indică închiderea ferestrei.
        ///   Opreşte serviciul de ascultare dacă este pornit şi salvează poziţia şi dimensiunile acesteia.
        /// </summary>
        private void DomainOntologyServiceForm_Close(object sender, FormClosingEventArgs e) {
           
            this.domainOntologyService.listener.stopListening();
            this.notifyIcon.Visible = false;
           
            if (this.WindowState == FormWindowState.Normal) {

                DomainOntologyServiceSettings.Default.BOUNDS = this.Bounds;
            }

            DomainOntologyServiceSettings.Default.SEPARATOR_FUNCTIONALITIES_PROPERTIES = this.splitContainerTop.SplitterDistance;
            DomainOntologyServiceSettings.Default.SEPARATOR_PROPERTIES_TERMS = this.splitContainerBottom.SplitterDistance;
            DomainOntologyServiceSettings.Default.Save();
        }

        ///    <summary>
        ///   Indică apăsarea butonului de reinnoire a ontologiilor.
        ///   Reinnoieste ontlogiile.
        /// </summary>
        private void btnUpdateOnt_Click(object sender, EventArgs e)
        {

            this.lbFunctionality.Items.Clear();
            this.lbProperties.Items.Clear();
            this.lbTerms.Items.Clear();

            if (this.visualizer != null)
            {

                this.visualizer.closeMe();
                this.visualizer = null;
            }

            this.domainOntologyService.updateFunctionalities(this.txtAdressUDDI.Text);

            if (this.domainOntologyService.lastError != null)
            {

                MessageBox.Show(this.domainOntologyService.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                this.lbFunctionality.Items.AddRange(this.domainOntologyService.functionalities);
            }
        }
    }
}