using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

using FuzzySelector.Common.Communication;
using FuzzySelector.Common.GraphicVisualizer;
using FuzzySelector.Common.Ontology;

using Client.resx;

namespace FuzzySelector.Client
{

    /// <summary>
    ///   Fereastra procesului client.
    /// </summary>
    public partial class ClientForm : Form
    {

        /// <summary>
        ///   Clientul asociat ferestrei.
        /// </summary>
        private Client client;

        /// <summary>
        ///   Funcţionalitatea pentru care se încearcă crearea unei cereri.
        /// </summary>
        private Functionality currentFunctionality = null;

        /// <summary>
        ///   Tab-urile (proprietaţiile funcţionalităţii).
        /// </summary>
        private PropertyTabPageState[] propertyTabPageStates;

        /// <summary>
        ///   Fereastra de vizualizare a termenilor.
        /// </summary>
        private Visualizer visualizer = null;

        public ClientForm()
        {

            InitializeComponent();

            this.client = new Client(new Address(ClientSettings.Default.DOS_IP, ClientSettings.Default.DOS_PORT), new Address(ClientSettings.Default.FFS_IP, ClientSettings.Default.FFS_PORT));

            this.Bounds = ClientSettings.Default.BOUNDS;

            this.txtAdressDOS.Text = ClientSettings.Default.DOS_IP;
            this.nudPortDOS.Value = ClientSettings.Default.DOS_PORT;
            this.txtAdressFFS.Text = ClientSettings.Default.FFS_IP;
            this.nudPortFFS.Value = ClientSettings.Default.FFS_PORT;
        }

        /// <summary>
        ///   Reîmprospătează termenul cererii pentru proprietatea curentă în fereastră şi fereastra de vizualizare a termenilor.
        /// </summary>
        private void updateShape()
        {

            Term term = this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm;

            if (term == null)
            {

                this.txtStart.Text = this.txtEnd.Text = this.txtLeft.Text = this.txtRight.Text = "";
            }
            else
            {

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm = term = term.getCompliant(this.currentFunctionality.properties[this.tcProperties.SelectedIndex]);

                if (term == null)
                {

                    this.updateShape();

                    return;
                }

                this.txtStart.Text = term.start.ToString();
                this.txtEnd.Text = term.end.ToString();
                this.txtLeft.Text = term.left.ToString();
                this.txtRight.Text = term.right.ToString();
            }

            if (this.visualizer != null)
            {

                this.visualizer.removeTerm("Request");

                if (term != null)
                {

                    term = new Term("Request", term.start, term.left, term.right, term.end);

                    this.visualizer.addTerm(term, System.Drawing.Color.FromArgb(200, System.Drawing.Color.Red), false, true, this.visualUpdateShape);
                }
            }
        }

        /// <summary>
        ///   Indică o modificare a termenului cererii pentru proprietatea curentă produsă din fereastra de vizualizare a termenilor.
        ///   Reîmprospătează interfaţa ferestrei.
        /// </summary>
        /// <param name="newTerm">Forma termenului dupa schimbare</param>
        private void visualUpdateShape(Term newTerm)
        {

            this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm = newTerm;

            this.updateShape();
        }

        /// <summary>
        ///   Indică apasarea butonului de gasire a funcţionalităţiilor.
        ///   Cere clientului să returneze funcţionalităţile şi reîmprospătează interfaţa ferestrei.
        /// </summary>
        private void btnFunctionalities_Click(object sender, EventArgs e)
        {

            this.btnFunctionalities.Enabled = false;

            Functionality[] functionalities = this.client.getFunctionalities();

            if (functionalities != null)
            {

                this.btnFunctionalities.Visible = false;

                this.lblFunctionality.Visible = this.cboFunctionality.Visible = this.btnFind.Visible = true;

                this.cboFunctionality.Items.AddRange(functionalities);
            }
            else
            {

                if (this.client.lastError != null)
                {

                    MessageBox.Show(this.client.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.btnFunctionalities.Enabled = true;
            }
        }

        /// <summary>
        ///   Indică alegerea unei noi funcţionalităţi.
        ///   Cere clientului să returneze proprietăţile şi reîmprospătează interfaţa.
        /// </summary>
        private void cboFunctionality_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.visualizer != null)
            {

                this.visualizer.closeMe();
            }

            this.btnFind.Enabled = this.tcProperties.Enabled = false;

            if (this.cboFunctionality.SelectedIndex == -1)
            {

                this.tcProperties.TabPages[0].Text = "Choose a functionality first !";

                return;
            }

            this.cboFunctionality.Enabled = false;

            this.currentFunctionality = this.client.getOntology(this.cboFunctionality.SelectedItem as Functionality);

            if (this.currentFunctionality == null)
            {

                if (this.client.lastError != null)
                {

                    MessageBox.Show(this.client.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.cboFunctionality.SelectedIndex = -1;
                this.cboFunctionality.Enabled = true;

                return;
            }

            this.propertyTabPageStates = new PropertyTabPageState[this.currentFunctionality.propertiesCount];

            for (int i = 0; i < this.currentFunctionality.propertiesCount; ++i)
            {

                this.propertyTabPageStates[i] = new PropertyTabPageState(this);
            }

            this.tcProperties.SelectedIndex = 0;

            while (this.tcProperties.TabCount > 1)
            {

                this.tcProperties.TabPages.RemoveAt(1);
            }

            if (this.currentFunctionality != null)
            {

                if (this.currentFunctionality.propertiesCount == 0)
                {

                    this.tcProperties.TabPages[0].Text = "This functionality has no properties !";
                    this.panelFunctionality.Visible = false;
                }
                else
                {

                    this.tcProperties.TabPages[0].Text = this.currentFunctionality.properties[0].name;
                    this.panelFunctionality.Visible = true;
                }

                for (int i = 1; i < this.currentFunctionality.propertiesCount; ++i)
                {

                    TabPage tabPage = new TabPage();

                    tabPage.Padding = this.tcProperties.TabPages[0].Padding;
                    tabPage.UseVisualStyleBackColor = true;

                    this.tcProperties.TabPages.Add(tabPage);
                    this.tcProperties.TabPages[i].Text = this.currentFunctionality.properties[i].name;
                }

                this.tcProperties_SelectedIndexChanged(null, null);

                this.btnFind.Enabled = this.cboFunctionality.Enabled = this.tcProperties.Enabled = true;
            }
            else
            {

                this.tcProperties.TabPages[0].Text = "Choose a functionality first !";

                this.panelFunctionality.Visible = false;

                this.cboFunctionality.SelectedIndex = -1;
            }
        }

        /// <summary>
        ///   Indică alegerea altei proprietăţi a funcţionalităţii curente.
        ///   Reîmprospătează interfaţa.
        /// </summary>
        private void tcProperties_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (currentFunctionality == null || currentFunctionality.propertiesCount == 0)
            {

                return;
            }

            if (this.visualizer != null)
            {

                this.visualizer.closeMe();
            }

            this.tcProperties.TabPages[this.tcProperties.SelectedIndex].Controls.Add(this.panelFunctionality);

            Property property = currentFunctionality.properties[this.tcProperties.SelectedIndex];

            lblMinMax.Text = "Min = " + property.start.ToString() + "; " + "Max = " + property.end.ToString();

            this.cboFuzzyValue.Items.Clear();
            this.cboFuzzyValue.Items.AddRange(property.terms);

            this.propertyTabPageStates[this.tcProperties.SelectedIndex].applyState();

            this.updateShape();
        }

        /// <summary>
        ///   Indică schimbarea tipului cererii pentru proprietatea curentă.
        ///   Recalculează forma termenului cererii.
        /// </summary>
        private void rbSpecified_CheckedChanged(object sender, EventArgs e)
        {

            if (((RadioButton)sender).Checked)
            {

                Property property = this.currentFunctionality.properties[this.tcProperties.SelectedIndex];

                this.txtCrispValue.Enabled = this.cboCrispValuePrefix.Enabled = this.nudCrispPercent.Enabled = this.rbSpecifiedCrisp.Checked;
                this.cboFuzzyValue.Enabled = this.cboFuzzyValuePrefix.Enabled = this.nudFuzzyPercent.Enabled = this.rbSpecifiedFuzzy.Checked;
                this.txtStart.Enabled = this.txtEnd.Enabled = this.txtLeft.Enabled = this.txtRight.Enabled = this.rbSpecifiedCustom.Checked;

                this.tbImportance.Enabled = !this.rbNotSpecified.Checked;

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].selectedRadioButton = this.rbNotSpecified.Checked ? Constants.RADIO_BUTTONS.NOT_SPECIFIED : this.rbSpecifiedCrisp.Checked ? Constants.RADIO_BUTTONS.CRISP_VALUE : this.rbSpecifiedFuzzy.Checked ? Constants.RADIO_BUTTONS.FUZZY_VALUE : Constants.RADIO_BUTTONS.CUSTOM;

                if (this.rbNotSpecified.Checked)
                {

                    this.tbImportance.Value = PropertyTabPageState.MEDIUM_IMPORTANCE;

                    this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm = null;

                    this.updateShape();
                }
                else
                {

                    if (this.rbSpecifiedCrisp.Checked)
                    {

                        this.txtCrispValue_Leave(null, null);
                    }
                    else
                    {

                        if (this.rbSpecifiedFuzzy.Checked)
                        {

                            this.cboFuzzyValue_SelectedIndexChanged(null, null);
                        }
                        else
                        {

                            this.updateShape();
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Indică schimbarea prefixului pentru o cerere de tip fuzzy.
        ///   Recalculează forma termenului cererii.
        /// </summary>
        private void cboFuzzyValuePrefix_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.pnlFuzzyPercent.Visible = this.cboFuzzyValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_LEAST_ABOUT || this.cboFuzzyValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_MOST_ABOUT || this.cboFuzzyValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.ABOUT;

            if (this.cboFuzzyValuePrefix.Enabled)
            {

                PropertyTabPageState propertyTabPageState = this.propertyTabPageStates[this.tcProperties.SelectedIndex];

                propertyTabPageState.fuzzyPrefix = (Constants.VALUE_PREFIXES)this.cboFuzzyValuePrefix.SelectedIndex;

                propertyTabPageState.reconstructTerm(this.currentFunctionality.properties[this.tcProperties.SelectedIndex]);

                this.updateShape();
            }
        }

        /// <summary>
        ///   Indică schimbarea procentului pentru estimări aproximative pentru o cerere de tip fuzzy.
        ///   Anunţă schimbarea tipului cererii.
        /// </summary>
        private void nudFuzzyPercent_ValueChanged(object sender, EventArgs e)
        {

            if (this.nudFuzzyPercent.Enabled)
            {

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].fuzzyAboutPercentage = (int)this.nudFuzzyPercent.Value;

                this.cboFuzzyValue_SelectedIndexChanged(null, null);
            }
        }

        /// <summary>
        ///   Indică schimbarea termenului fuzzy din ontologie de la care porneşte calcularea termenului cererii.
        ///   Recalculează forma termenului cererii.
        /// </summary>
        private void cboFuzzyValue_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cboFuzzyValue.Enabled)
            {

                PropertyTabPageState propertyTabPageState = this.propertyTabPageStates[this.tcProperties.SelectedIndex];

                propertyTabPageState.fuzzyIndex = this.cboFuzzyValue.SelectedIndex;

                propertyTabPageState.reconstructTerm(this.currentFunctionality.properties[this.tcProperties.SelectedIndex]);

                this.updateShape();
            }
        }

        /// <summary>
        ///   Indică schimbarea prefixului pentru o cerere de tip crisp.
        ///   Recalculează forma termenului cererii.
        /// </summary>
        private void cboCrispValuePrefix_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.pnlCrispPercent.Visible = this.cboCrispValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_LEAST_ABOUT || this.cboCrispValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_MOST_ABOUT || this.cboCrispValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.ABOUT;

            if (this.cboCrispValuePrefix.Enabled)
            {

                PropertyTabPageState propertyTabPageState = this.propertyTabPageStates[this.tcProperties.SelectedIndex];

                propertyTabPageState.crispPrefix = (Constants.VALUE_PREFIXES)this.cboCrispValuePrefix.SelectedIndex;

                propertyTabPageState.reconstructTerm(this.currentFunctionality.properties[this.tcProperties.SelectedIndex]);

                this.updateShape();
            }
        }

        /// <summary>
        ///   Indică schimbarea procentului pentru estimări aproximative pentru o cerere de tip crisp.
        ///   Anunţă schimbarea tipului cererii.
        /// </summary>
        private void nudCrispPercent_ValueChanged(object sender, EventArgs e)
        {

            if (this.nudCrispPercent.Enabled)
            {

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].crispAboutPercentage = (int)nudCrispPercent.Value;

                this.txtCrispValue_Leave(null, null);
            }
        }

        /// <summary>
        ///   Indică încheierea introducerii de text în căsuţa pentru valori crisp.
        ///   Validează corectitudinea intrării şi recalculează forma termenului cererii.
        /// </summary>
        private void txtCrispValue_Leave(object sender, EventArgs e)
        {

            PropertyTabPageState propertyTabPageState = this.propertyTabPageStates[this.tcProperties.SelectedIndex];

            double newValue;

            if (double.TryParse(this.txtCrispValue.Text, out newValue))
            {

                propertyTabPageState.crispValue = newValue;
            }
            else
            {

                this.txtCrispValue.Text = propertyTabPageState.crispValue.ToString();
            }

            propertyTabPageState.reconstructTerm(this.currentFunctionality.properties[this.tcProperties.SelectedIndex]);

            this.updateShape();
        }

        /// <summary>
        ///   Indică încheierea introducerii de text în căsuţa pentru valoarea de început la cereri personalizate.
        ///   Validează corectitudinea intrării şi recalculează forma termenului cererii.
        /// </summary>
        private void txtStart_Leave(object sender, EventArgs e)
        {

            Term term = this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm;

            double newValue;

            if (double.TryParse(this.txtStart.Text, out newValue))
            {

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm = new Term(term.name, newValue, term.left, term.right, term.end);
            }

            this.updateShape();
        }

        /// <summary>
        ///   Indică încheierea introducerii de text în căsuţa pentru valoarea de sfârşit la cereri personalizate.
        ///   Validează corectitudinea intrării şi recalculează forma termenului cererii.
        /// </summary>
        private void txtEnd_Leave(object sender, EventArgs e)
        {

            Term term = this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm;

            double newValue;

            if (double.TryParse(this.txtStart.Text, out newValue))
            {

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm = new Term(term.name, term.start, term.left, term.right, newValue);
            }

            this.updateShape();
        }

        /// <summary>
        ///   Indică încheierea introducerii de text în căsuţa pentru valoarea de stânga la cereri personalizate.
        ///   Validează corectitudinea intrării şi recalculează forma termenului cererii.
        /// </summary>
        private void txtLeft_Leave(object sender, EventArgs e)
        {

            Term term = this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm;
            double newValue;


            if (double.TryParse(this.txtStart.Text, out newValue))
            {

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm = new Term(term.name, term.start, newValue, term.right, term.end);
            }

            this.updateShape();
        }

        /// <summary>
        ///   Indică încheierea introducerii de text în căsuţa pentru valoarea de dreapta la cereri personalizate.
        ///   Validează corectitudinea intrării şi recalculează forma termenului cererii.
        /// </summary>
        private void txtRight_Leave(object sender, EventArgs e)
        {

            Term term = this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm;

            double newValue;

            if (double.TryParse(this.txtStart.Text, out newValue))
            {

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm = new Term(term.name, term.start, term.left, newValue, term.end);
            }

            this.updateShape();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru trimiterea căutării.
        ///   Cere clientului să găsească rezultatul cererii.
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {

            RequestShape[] requestShapes = new RequestShape[this.propertyTabPageStates.Length];

            for (int i = 0; i < this.propertyTabPageStates.Length; ++i)
            {

                requestShapes[i] = this.propertyTabPageStates[i].customTerm == null ? null : new RequestShape(this.propertyTabPageStates[i].customTerm, this.propertyTabPageStates[i].importance);
            }

            string[] result = this.client.findServices(this.currentFunctionality, requestShapes);

            this.ActiveControl = null;

            if (result != null && this.ckBShowALLRes.Checked)
            {

                Thread thread = new Thread(delegate()
                {

                    Application.Run(new ClientResultsForm(result, true, -1));
                });

                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
                if (result != null && !this.ckBShowALLRes.Checked)
                {
                    Thread thread = new Thread(delegate()
                    {

                        Application.Run(new ClientResultsForm(result, false, (int)nudShowRes.Value));
                    });

                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
            else
            {

                if (this.client.lastError != null)
                {

                    MessageBox.Show(this.client.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru vizualizarea grafică a formei termenului din cerere.
        ///   Deschide o astfel de vizualizare.
        /// </summary>
        private void btnPreviewShape_Click(object sender, EventArgs e)
        {

            this.btnPreviewShape.Enabled = false;

            Property property = this.currentFunctionality.properties[this.tcProperties.SelectedIndex];

            this.visualizer = new Visualizer(property.name, this.Width, -1, this.Left, this.Top + this.Height, new FormClosedEventHandler(this.graphicVisualizer_Close));

            this.visualizer.addProperty(property, System.Drawing.Color.FromArgb(100, System.Drawing.Color.Green), System.Drawing.Color.FromArgb(50, System.Drawing.Color.Blue), true);

            Term term = this.propertyTabPageStates[this.tcProperties.SelectedIndex].customTerm;

            if (term != null)
            {

                term = new Term("Request", term.start, term.left, term.right, term.end);

                this.visualizer.addTerm(term, System.Drawing.Color.FromArgb(200, System.Drawing.Color.Red), false, true, this.visualUpdateShape);
            }
        }

        /// <summary>
        ///   Indică închiderea vizualizării grafice a formei termenului din cerere.
        ///   Reîmprospătează fereastra.
        /// </summary>
        private void graphicVisualizer_Close(object sender, FormClosedEventArgs e)
        {

            this.btnPreviewShape.Enabled = true;
            this.visualizer = null;
        }

        /// <summary>
        ///   Indică schimbarea slider-ului de importanţă a proprietăţii în cerere.
        ///   Ajustează importanţa şi reîmprospătează fereastra.
        /// </summary>
        private void tbImportance_ValueChanged(object sender, EventArgs e)
        {

            try
            {

                this.propertyTabPageStates[this.tcProperties.SelectedIndex].importance = this.tbImportance.Value;
            }
            catch (Exception)
            {

            }

            this.lblImportance.Text = "The importance of this \r\nproperty is: " + Constants.IMPORTANCES[this.tbImportance.Value - 1];
        }

        /// <summary>
        ///   Indică schimbarea unei componente a adresei serviciului de ontologia domeniului.
        ///   Anunţă clientul de noua adresă. Salvează noua adresă.
        /// </summary>
        private void adressDOS_Changed(object sender, EventArgs e)
        {

            ClientSettings.Default.DOS_IP = this.txtAdressDOS.Text;
            ClientSettings.Default.DOS_PORT = (int)this.nudPortDOS.Value;
            ClientSettings.Default.Save();

            this.client.domainOntologyServiceAddress = new Address(this.txtAdressDOS.Text, (int)this.nudPortDOS.Value);
        }

        /// <summary>
        ///   Indică schimbarea unei componente a adresei serviciului de găsire a funcţionalităţii.
        ///   Anunţă clientul de noua adresă. Salvează noua adresă.
        /// </summary>
        private void adressFFS_Changed(object sender, EventArgs e)
        {

            ClientSettings.Default.FFS_IP = this.txtAdressFFS.Text;
            ClientSettings.Default.FFS_PORT = (int)this.nudPortFFS.Value;
            ClientSettings.Default.Save();

            this.client.functionalityFindingServiceAddress = new Address(this.txtAdressFFS.Text, (int)this.nudPortFFS.Value);
        }
       
        /// <summary>
        ///   Indică închiderea ferestrei.
        ///   Salvează poziţia şi dimensiunile acesteia.
        /// </summary>
        private void ClientForm_FormClose(object sender, FormClosingEventArgs e)
        {

            ClientSettings.Default.BOUNDS = this.Bounds;
            ClientSettings.Default.Save();
        }

        /// <summary>
        /// Indica apasarea tastei 'Enter' care echivaleaza cu apsarea butonului 'Find'
        /// </summary>
        private void enterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.btnFind.Visible)
            {
                this.btnFind.BackColor = System.Drawing.Color.Blue;
                this.btnFind_Click(sender, e);
            }
        }

        /// <summary>
        /// Indica selectarea casutei pentru a cuprinde in form-ul cu rezultate toate serviciile.
        /// Acest lucru implica impiedicarea alegerii vreunei valori din numericUpDown in cazul selectarii casutei
        /// </summary>
        private void ckBShowALLRes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckBShowALLRes.Checked)
            {
                this.nudShowRes.Enabled = false;
            }

            else
            {
                this.nudShowRes.Enabled = true;
            }
        }
    }
}