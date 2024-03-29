using System;
using System.Windows.Forms;

using FuzzySelector.Common.Communication;
using FuzzySelector.Common.Ontology;

using FunctionalityFindingService.resx;
using System.Threading;
using System.Collections.Generic;

namespace FuzzySelector.FunctionalityFindingService
{

    /// <summary>
    ///   Fereastra procesului serviciului de găsire a funcţionalităţilor.
    /// </summary>
    public partial class FunctionalityFindingServiceForm : Form
    {

        /// <summary>
        ///   Serviciul de găsire a funcţionalităţilor ataşat.
        /// </summary>
        private FunctionalityFindingService functionalityFindingService;

        /// <summary>
        ///   Date esentiale despre functionalitati.
        /// </summary>
        private string[] functionalitiesData;

        /// <param name="functionalityFindingService">Serviciul de găsire a funcţionalităţilor ataşat</param>
        public FunctionalityFindingServiceForm(FunctionalityFindingService functionalityFindingService)
        {

            InitializeComponent();

            this.functionalityFindingService = functionalityFindingService;
            this.functionalitiesData = null;

            this.Bounds = FunctionalityFindingServiceSettings.Default.BOUNDS;

            this.nudPort.Value = FunctionalityFindingServiceSettings.Default.LISTENING_PORT;
            this.nudPortDOS.Value = FunctionalityFindingServiceSettings.Default.DOS_PORT;
            this.txtAdressDOS.Text = FunctionalityFindingServiceSettings.Default.DOS_IP;
            this.txtAdressUDDI.Text = FunctionalityFindingServiceSettings.Default.UDDI;

            this.splitContainerMain.SplitterDistance = FunctionalityFindingServiceSettings.Default.SEPARATOR_SERVICES_PROPERTIES;

            this.cboFilterFunctionality.Items.Add("None");
            this.cboFilterFunctionality.SelectedIndex = 0;
            this.cboFilterFunctionality.Enabled = false;

            //this.btnListen_Click(null, null);
        }

        /// <summary>
        ///   Indică schimbarea filtrului de funcţionalităţi.
        ///   Se aplică filtrul pe serviciile existente şi se reîmprospătează fereastra.
        /// </summary>
        private void cboFilterFunctionality_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if (functionalitiesData != null)
            {

                this.lbServices.Items.Clear();
                this.lbProperties.Items.Clear();

                this.lbServices.Items.AddRange(this.functionalityFindingService.getServices(this.cboFilterFunctionality.Text));
            }
        }

        /// <summary>
        ///   Indică alegerea unui serviciu din listă.
        ///   Se populează lista de proprietăţi cu proprietăţile corespunzătoare serviciului ales.
        /// </summary>
        private void lbServices_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            this.lbProperties.Items.Clear();
            this.lbProperties.Items.AddRange(this.functionalityFindingService.getPrintableProperties(this.lbServices.SelectedItem as Service));
        }

        /// <summary>
        ///   Indică schimbarea portului de ascultare.
        ///   Salvează noul port în setări.
        /// </summary>
        private void nudPort_ValueChanged(object sender, EventArgs e)
        {

            FunctionalityFindingServiceSettings.Default.LISTENING_PORT = (int)this.nudPort.Value;
            FunctionalityFindingServiceSettings.Default.Save();
        }

        /// <summary>
        ///   Indică schimbarea unei componente a adresei serviciului de ontologia domeniului.
        ///   Anunţă serviciul de noua adresă.
        /// </summary>
        private void adressDOS_Changed(object sender, EventArgs e)
        {

            FunctionalityFindingServiceSettings.Default.DOS_IP = this.txtAdressDOS.Text;
            FunctionalityFindingServiceSettings.Default.DOS_PORT = (int)this.nudPortDOS.Value;
            FunctionalityFindingServiceSettings.Default.Save();

            this.functionalityFindingService.domainOntologyServiceAddress = new Address(this.txtAdressDOS.Text, (int)this.nudPortDOS.Value);
        }

        private void txtAdressUDDI_TextChanged(object sender, EventArgs e)
        {

            FunctionalityFindingServiceSettings.Default.UDDI = this.txtAdressUDDI.Text;
            FunctionalityFindingServiceSettings.Default.Save();
        }

        /// <summary>
        ///   Indică apăsarea butonului de pornire/oprire a serviciului.
        ///   Porneşte sau opreşte ascultarea după mesaje pe portul indicat.
        /// </summary>
        private void btnListen_Click(object sender, System.EventArgs e)
        {

            if (this.functionalityFindingService.listener.isListening)
            {

                this.functionalityFindingService.listener.stopListening();
                this.btnListen.Text = this.mnuStartService.Text = "Start Service";
                this.nudPort.Enabled = true;
            }
            else
            {

                this.nudPort.Enabled = false;
                this.btnListen.Text = this.mnuStartService.Text = "Stop Service";
                this.functionalityFindingService.listener.startListening((int)this.nudPort.Value);
            }
        }

        /// <summary>
        /// Ia toate functionalitatile existente de la DOS 
        /// </summary>
        private void btnUpdateFunc_Click(object sender, EventArgs e)
        {

            this.lbServices.Items.Clear();
            this.lbProperties.Items.Clear();

            functionalitiesData = functionalityFindingService.getFunctionalitiesData();

            if (functionalitiesData != null)
            {

                if (functionalitiesData.Length > 0)
                {

                    this.cboFilterFunctionality.Items.Clear();
                    this.cboFilterFunctionality.Items.Add("All");
                    this.cboFilterFunctionality.SelectedIndex = 0;
                    this.cboFilterFunctionality.Enabled = true;

                    for (int i = 1; i < functionalitiesData.Length; i = i + 3)
                    {

                        this.cboFilterFunctionality.Items.Add(functionalitiesData[i]);
                    }
                }
            }
            else
            {

                this.cboFilterFunctionality.Items.Clear();
                this.cboFilterFunctionality.Items.Add("None");
                this.cboFilterFunctionality.SelectedIndex = 0;
                this.cboFilterFunctionality.Enabled = false;

                if (this.functionalityFindingService.lastError != null)
                {

                    MessageBox.Show(this.functionalityFindingService.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Ia toate serviciile existente pe UDDI si le salveaza pe FFS
        /// </summary>
        private void btnUpdateServ_Click(object sender, EventArgs e)
        {

            this.lbServices.Items.Clear();
            this.lbProperties.Items.Clear();

            this.functionalityFindingService.updateServices(this.txtAdressUDDI.Text, functionalitiesData);

            if (this.functionalityFindingService.lastError != null)
            {

                MessageBox.Show(this.functionalityFindingService.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                this.lbServices.Items.AddRange(this.functionalityFindingService.getServices("All"));

                this.cboFilterFunctionality.SelectedIndex = 0;
            }
        }

        /// <summary>
        ///   Indică redimensionarea ferestrei, minimizarea acesteia sau revenirea din sistem tray.
        ///   Face schimbările vizuale necesare.
        /// </summary>
        private void FunctionalityFindingServiceForm_Resize(object sender, System.EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {

                FunctionalityFindingServiceSettings.Default.BOUNDS = this.RestoreBounds;
                FunctionalityFindingServiceSettings.Default.Save();
                this.notifyIcon.Visible = true;
                this.Hide();
            }
            else
            {

                if (this.WindowState == FormWindowState.Normal)
                {

                    this.notifyIcon.Visible = false;
                    this.ShowInTaskbar = true;
                }
            }
        }

        /// <summary>
        ///   Indică un click dublu pe pictograma din sistem tray.
        ///   Revine în modul normal de afişare din modul sistem tray.
        /// </summary>
        private void notifyIcon_DoubleClick(object sender, System.EventArgs e)
        {

            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        ///   Indică apăsarea meniului de închidere a procesului în modul sistem tray.
        ///   Inchide procesul.
        /// </summary>
        private void mnuEndProgram_Click(object sender, System.EventArgs e)
        {

            this.Close();
        }

        /// <summary>
        ///   Indică încărcarea vizuală a ferestrei.
        ///   Afişează pictograma în sistem tray (se porneşte minimizat) şi activează handler-ul pentru redimensionarea ferestrei.
        /// </summary>
        private void FunctionalityFindingServiceForm_Load(object sender, System.EventArgs e)
        {

            this.notifyIcon.Visible = true;
            this.Resize += new System.EventHandler(this.FunctionalityFindingServiceForm_Resize);
        }

        /// <summary>
        ///   Indică închiderea ferestrei.
        ///   Opreşte serviciul de ascultare dacă este pornit şi salvează poziţia şi dimensiunile acesteia.
        /// </summary>
        private void FunctionalityFindingServiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.functionalityFindingService.listener.stopListening();
            this.notifyIcon.Visible = false;

            if (this.WindowState == FormWindowState.Normal)
            {

                FunctionalityFindingServiceSettings.Default.BOUNDS = this.Bounds;
            }

            FunctionalityFindingServiceSettings.Default.SEPARATOR_SERVICES_PROPERTIES = this.splitContainerMain.SplitterDistance;
            FunctionalityFindingServiceSettings.Default.Save();
        }
    }
}