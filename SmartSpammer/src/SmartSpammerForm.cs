using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

using FuzzySelector.Common.Communication;
using FuzzySelector.Common.GraphicVisualizer;
using FuzzySelector.Common.Ontology;

using SmartSpammer.resx;
using System.Collections.Generic;

namespace FuzzySelector.SmartSpammer
{

    /// <summary>
    ///   Fereastra procesului SmartSpammer.
    /// </summary>
    public partial class SmartSpammerForm : Form
    {

        /// <summary>
        ///   SmartSpammerul asociat ferestrei.
        /// </summary>
        private SmartSpammer SmartSpammer;

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

        public SmartSpammerForm()
        {

            InitializeComponent();

            this.SmartSpammer = new SmartSpammer(new Address(SmartSpammerSettings.Default.DOS_IP, SmartSpammerSettings.Default.DOS_PORT), new Address(SmartSpammerSettings.Default.FFS_IP, SmartSpammerSettings.Default.FFS_PORT));

            this.Bounds = SmartSpammerSettings.Default.BOUNDS;

            this.txtAdressDOS.Text = SmartSpammerSettings.Default.DOS_IP;
            this.nudPortDOS.Value = SmartSpammerSettings.Default.DOS_PORT;
            this.txtAdressFFS.Text = SmartSpammerSettings.Default.FFS_IP;
            this.nudPortFFS.Value = SmartSpammerSettings.Default.FFS_PORT;

            this.nudLoadLevel.Value = SmartSpammerSettings.Default.THREADS;
            this.nudLoadLevel.Value = SmartSpammerSettings.Default.EXECUTIONS;
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
        ///   Cere SmartSpammerului să returneze funcţionalităţile şi reîmprospătează interfaţa ferestrei.
        /// </summary>
        private void btnFunctionalities_Click(object sender, EventArgs e)
        {

            this.btnFunctionalities.Enabled = false;

            Functionality[] functionalities = this.SmartSpammer.getFunctionalities();

            if (functionalities != null)
            {

                this.btnFunctionalities.Visible = false;

                this.lblFunctionality.Visible = this.cboFunctionality.Visible = true;

                this.nudLoadLevel.Enabled = this.nudNoReq.Enabled = true;

                this.cboFunctionality.Items.AddRange(functionalities);
            }
            else
            {

                if (this.SmartSpammer.lastError != null)
                {

                    MessageBox.Show(this.SmartSpammer.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.btnFunctionalities.Enabled = true;
            }
        }

        /// <summary>
        ///   Indică alegerea unei noi funcţionalităţi.
        ///   Cere SmartSpammerului să returneze proprietăţile şi reîmprospătează interfaţa.
        /// </summary>
        private void cboFunctionality_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.visualizer != null)
            {

                this.visualizer.closeMe();
            }

            this.btnSpam.Enabled = this.tcProperties.Enabled = false;

            if (this.cboFunctionality.SelectedIndex == -1)
            {

                this.tcProperties.TabPages[0].Text = "Choose a functionality";

                return;
            }

            this.cboFunctionality.Enabled = false;

            this.currentFunctionality = this.SmartSpammer.getOntology(this.cboFunctionality.SelectedItem as Functionality);

            if (this.currentFunctionality == null)
            {

                if (this.SmartSpammer.lastError != null)
                {

                    MessageBox.Show(this.SmartSpammer.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                this.btnSpam.Enabled = this.cboFunctionality.Enabled = this.tcProperties.Enabled = true;
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
        /// Seteaza nivelul de incarcare pe FFS, trimite nrul de cereri specificat dupa atingerea nivelului de 
        /// incarcare pe FFS si masoara timpul de raspuns al FFS-ului pentru cererile trimise.
        /// </summary>
        /// <param name="functionalityName">Numele functionalitatii din cadrul configuratiei de testare</param>
        /// <param name="requestShapes">Termenii cererii din cadrul configuratiei de testare</param>
        /// <param name="minLoadLevel">Nivelul de incarcare al FFS din cadrul configuratiei de testare</param>
        /// <param name="nrRequests">Nrul de cereri trimise dupa atingerea 'minLoadLevel' de catre FFS</param>
        /// <returns></returns>
        private TimeSpan spamRequest(string functionalityName, RequestShape[] requestShapes, int minLoadLevel, int nrRequests)
        {

            string actualServerLoadStatus = this.SmartSpammer.setServerLoadLevel(minLoadLevel, functionalityName, requestShapes);

            if (actualServerLoadStatus == null)
            {

                if (this.SmartSpammer.lastError != null)
                {
                    MessageBox.Show(this.SmartSpammer.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return TimeSpan.Zero;
                }
            }
            else
            {

                TimeSpan results = TimeSpan.Zero;

                Functionality simpleFunctionality = new Functionality(functionalityName);
                Functionality completeFunctionality = this.SmartSpammer.getOntology(simpleFunctionality);

                if (actualServerLoadStatus.Equals("true"))
                {

                    DateTime startTime = DateTime.Now;

                    for (int i = 0; i < nrRequests; i++)
                    {

                        this.SmartSpammer.findServices(completeFunctionality, requestShapes);
                    }

                    DateTime stopTime = DateTime.Now;

                    results = stopTime - startTime;

                    return results;


                }


                else
                {
                    MessageBox.Show("Server Load not achieved !");
                    
                    return TimeSpan.Zero;
                }
            }

            return TimeSpan.Zero;
        }

        /// <summary>
        /// Metoda care realizeaza procedura de testare in mod automat luand pe rand fiecare configuratie de testare
        /// prezenta in lista din SmartSpammer si care a fost incarcata in prealabil. Incarca Form-ul cu rezultatele
        /// constand in timpii de raspuns pentru fiecare din configuratiile de testare rulate.
        /// </summary>
        private void spamAutomatically()
        {
            string functionalityName = "";
            List<RequestShape> requestShapes = new List<RequestShape>();
            string[] serializedRequestShapes;
            int minLoadLevel = 0;
            int counter = 0;
            int[] noOfReqAfterLoadLevelAchieved = new int[lvTestConfigs.Items.Count];
            TimeSpan[] results=new TimeSpan[lvTestConfigs.Items.Count];
            string[] testDetails = new string[lvTestConfigs.Items.Count];


            foreach (ListViewItem lvi in this.lvTestConfigs.Items)
            {
                functionalityName = lvi.SubItems[0].Text;

                serializedRequestShapes = (string[])lvi.Tag;

                minLoadLevel = int.Parse(lvi.SubItems[2].Text);

                noOfReqAfterLoadLevelAchieved[counter] = int.Parse(lvi.SubItems[3].Text);

                for (int i = 0; i < serializedRequestShapes.Length; i++)
                {
                    RequestShape rs = new RequestShape(serializedRequestShapes[i]);

                    requestShapes.Add(rs);
                }

                results[counter] = spamRequest(functionalityName, requestShapes.ToArray(), minLoadLevel, noOfReqAfterLoadLevelAchieved[counter]);
                testDetails[counter] = functionalityName + "*" + minLoadLevel + "*" + noOfReqAfterLoadLevelAchieved[counter] + "*" + requestShapes.Count;

                counter++;
            }

            string[] finalResults = new string[results.Length];

            for (int i = 0; i < results.Length; i++)
            {
                finalResults[i] = i+1 + "*" + results[i].TotalSeconds / noOfReqAfterLoadLevelAchieved[i] + "*" + results[i].TotalMilliseconds / noOfReqAfterLoadLevelAchieved[i];
            }

            this.ActiveControl = null;

            Thread thread = new Thread(delegate()
            {

                Application.Run(new SmartSpammerResultsForm(testDetails, finalResults));
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        /// Metoda care realizeaza procedura de testare in mod manual, adica ruleaza o singura configuratie de testare,
        /// incarcand apoi Form-ul cu timpul de raspuns pentru respectiva configuratie testata.
        /// </summary>
        private void spamManually()
        {
            string functionalityName="";
            List<RequestShape> requestShapes = new List<RequestShape>();
            string[] serializedRequestShapes;
            int minLoadLevel = 0;
            int noOfReqAfterLoadLevelAchieved = 0;
            string[] testDetails = new string[1];

            if (this.lvTestConfigs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a test configuration from the list first !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            ListViewItem lvi = this.lvTestConfigs.SelectedItems[0];

            functionalityName = lvi.SubItems[0].Text;

            serializedRequestShapes = (string[])lvi.Tag;

            minLoadLevel = int.Parse(lvi.SubItems[2].Text);

            noOfReqAfterLoadLevelAchieved = int.Parse(lvi.SubItems[3].Text);

            for (int i = 0; i < serializedRequestShapes.Length; i++)
            {
                RequestShape rs = new RequestShape(serializedRequestShapes[i]);

                requestShapes.Add(rs);
            }
            string[] result = new string[1];

            TimeSpan results = spamRequest(functionalityName, requestShapes.ToArray(), minLoadLevel, noOfReqAfterLoadLevelAchieved);

            result[0] = 1 + "*" + results.TotalSeconds / noOfReqAfterLoadLevelAchieved + "*" + results.TotalMilliseconds / noOfReqAfterLoadLevelAchieved;

            testDetails[0] = functionalityName + "*" + minLoadLevel + "*" + noOfReqAfterLoadLevelAchieved + "*" + requestShapes.Count;

            this.ActiveControl = null;

            Thread thread = new Thread(delegate()
            {

                Application.Run(new SmartSpammerResultsForm(testDetails, result));
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /// <summary>
        ///   Indică apăsarea butonului pentru trimiterea căutării.
        ///   Cere SmartSpammerului să găsească rezultatul cererii.
        /// </summary>
        private void btnSpam_Click(object sender, EventArgs e)
        {
            if (this.radBtnAutoTesting.Checked)
            {
                spamAutomatically();
            }
            else
                if (this.radBtnManualTesting.Checked)
                {
                    spamManually();
                }
                else
                {
                    MessageBox.Show("Please select spamming mode: Manual or Automatic !");
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
        ///   Anunţă SmartSpammerul de noua adresă. Salvează noua adresă.
        /// </summary>
        private void adressDOS_Changed(object sender, EventArgs e)
        {

            SmartSpammerSettings.Default.DOS_IP = this.txtAdressDOS.Text;
            SmartSpammerSettings.Default.DOS_PORT = (int)this.nudPortDOS.Value;
            SmartSpammerSettings.Default.Save();

            this.SmartSpammer.domainOntologyServiceAddress = new Address(this.txtAdressDOS.Text, (int)this.nudPortDOS.Value);
        }

        /// <summary>
        ///   Indică schimbarea unei componente a adresei serviciului de găsire a funcţionalităţii.
        ///   Anunţă SmartSpammerul de noua adresă. Salvează noua adresă.
        /// </summary>
        private void adressFFS_Changed(object sender, EventArgs e)
        {

            SmartSpammerSettings.Default.FFS_IP = this.txtAdressFFS.Text;
            SmartSpammerSettings.Default.FFS_PORT = (int)this.nudPortFFS.Value;
            SmartSpammerSettings.Default.Save();

            this.SmartSpammer.functionalityFindingServiceAddress = new Address(this.txtAdressFFS.Text, (int)this.nudPortFFS.Value);
        }

        /// <summary>
        ///   Indică schimbarea parametrilor pentru spam: numar fire executie, respectiv executii/fir.
        ///   Salvează noile valori.
        /// </summary>
        private void spamParameters_Changed(object sender, EventArgs e)
        {

            SmartSpammerSettings.Default.THREADS = (int)this.nudLoadLevel.Value;
            SmartSpammerSettings.Default.EXECUTIONS = (int)this.nudNoReq.Value;
            SmartSpammerSettings.Default.Save();
        }

        /// <summary>
        ///   Indică închiderea ferestrei.
        ///   Salvează poziţia şi dimensiunile acesteia.
        /// </summary>
        private void SmartSpammerForm_FormClose(object sender, FormClosingEventArgs e)
        {

            SmartSpammerSettings.Default.BOUNDS = this.Bounds;
            SmartSpammerSettings.Default.Save();
        }

        /// <summary>
        /// Indica apasarea tastei 'Enter' si echivaleaza cu apasarea butonului de 'Spam'. 
        /// </summary>
        private void enterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.btnSpam.Visible)
            {
                this.btnSpam.BackColor = System.Drawing.Color.Blue;
                this.btnSpam_Click(sender, e);
            }
        }

        /// <summary>
        /// Indica apasarea butonului de salvare a configuratiilor de testare prezente in lista din interfata 
        /// SmartSpammer. Se realizeaza salvarea acestor configuratii
        /// </summary>
        private void btnSaveTestConfig_Click(object sender, EventArgs e)
        {
            if (this.lvTestConfigs.Items.Count != 0)
            {

                List<string[]> requestsSerialized = new List<string[]>();
                List<string> functionalities = new List<string>();
                List<string> minServerLoads = new List<string>();
                List<string> nrOfReqAfterLoadAchieved = new List<string>();

                foreach (ListViewItem listViewItem in this.lvTestConfigs.Items)
                {
                    try
                    {
                        functionalities.Add(listViewItem.Text);

                        requestsSerialized.Add((string[])listViewItem.Tag);

                        minServerLoads.Add(listViewItem.SubItems[2].Text);

                        nrOfReqAfterLoadAchieved.Add(listViewItem.SubItems[3].Text);
                    }
                    catch (Exception g)
                    {
                        MessageBox.Show(g.Message);
                    }
                }

                if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    this.SmartSpammer.saveTestConfigs(this.saveFileDialog.FileName, functionalities.ToArray(), requestsSerialized.ToArray(), minServerLoads.ToArray(), nrOfReqAfterLoadAchieved.ToArray());

                    if (this.SmartSpammer.lastError != null)
                    {

                        MessageBox.Show(this.SmartSpammer.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {

                MessageBox.Show("Request list is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Indica apsarea butonului de adaugare a unei configuratii de testare in lista din interfata grafica a
        /// SmartSpammer. 
        /// </summary>
        private void btnAddTestConfig_Click(object sender, EventArgs e)
        {        

            List<RequestShape> requestShapes = new List<RequestShape>();

            for (int i = 0; i < this.propertyTabPageStates.Length; ++i)
            {

                if (this.propertyTabPageStates[i].customTerm != null)

                    requestShapes.Add(new RequestShape(this.propertyTabPageStates[i].customTerm, this.propertyTabPageStates[i].importance));
            }

            if (requestShapes.Count != 0)
            {

                ListViewItem item = new ListViewItem(this.currentFunctionality.name);

                string requests = "";

                string[] rss = new string[requestShapes.Count];

                for (int i = 0; i < requestShapes.Count; ++i)
                {

                    requests += requestShapes[i].shape.name + " " +
                                requestShapes[i].shape.start + " " +
                                requestShapes[i].shape.left + " " +
                                requestShapes[i].shape.right + " " +
                                requestShapes[i].shape.end + " " +
                                requestShapes[i].importance + " " +
                                "   ";

                    rss[i] = requestShapes[i].serialize();
                }

                item.SubItems.Add(requests);

                item.Tag = rss;

                item.SubItems.Add(nudLoadLevel.Value.ToString());

                item.SubItems.Add(nudNoReq.Value.ToString());

                foreach (ListViewItem listViewItem in this.lvTestConfigs.Items)
                {

                    if (listViewItem.SubItems[0].Text.Equals(this.currentFunctionality.name) && listViewItem.SubItems[1].Text.Equals(requests))
                    {

                        MessageBox.Show("Request already exists in request list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                this.lvTestConfigs.Items.Add(item);
            }
            else
            {

                MessageBox.Show("None of the properties has a specified value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Indica apasarea butonului de stergere a continutului listei din interfata grafica a SmartSpammer.
        /// Se goleste continutul respectivei liste.
        /// </summary>
        private void btnClearTestConfig_Click(object sender, EventArgs e)
        {
            this.lvTestConfigs.Items.Clear();
        }

        /// <summary>
        /// Indica apasarea butonului de stergere a unei configuratii din lista cu configuratii din interfata
        /// grafica a SmartSpammer. Realizeaza stergerea respectivei configuratii. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeTestConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvTestConfigs.SelectedItems.Count > 0)
            {

                lvTestConfigs.Items.Remove(lvTestConfigs.SelectedItems[0]);
            }
        }

        /// <summary>
        /// Indica alegerea optinuii de vizualizare a detaliilor uneo configuratii de testare din cadrul listei cu 
        /// configuratii din interfata grafica a SmartSpammer. Apare un fereastra de mesaje cu continutul detaliat
        /// al configuratiei selectate.
        /// </summary>
        private void viewTestConfigurationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvTestConfigs.SelectedItems[0];

            MessageBox.Show("Functionality: " + lvi.SubItems[0].Text + "\r\n\r\n" + "Request Shapes: " + lvi.SubItems[1].Text + "\r\n\r\n" + "Min. Server Load Level: " + lvi.SubItems[2].Text + "\r\n\r\n" + "No. of Requests after Load Level achieved: " + lvi.SubItems[3].Text, "Selected Test Configuration Details");
        }

        /// <summary>
        /// Indica apasarea butonului de incarcare a unui fisier XML care contine un batch de configuratii de testare.
        /// Incarca configuratiile in lista din interfata grafica a SmartSpammer.
        /// </summary>
        private void btnLoadTestConfig_Click(object sender, EventArgs e)
        {
            if (this.lvTestConfigs.Items.Count != 0)
            {
                this.btnClearTestConfig_Click(sender,e);
            }           

            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                List<string>  parseResults = this.SmartSpammer.loadTestConfigsFromXml(this.openFileDialog.FileName);

                
                string lvRequestShapes="";
                string[] lvRss;
                string[][] deserializedRequestShapes = new string[parseResults.Count / 4][];

                if (parseResults != null)
                {
                    for (int i=0; i<parseResults.Count/4; i++) {

                        if (parseResults[4 * i] != null || parseResults[4 * i] != "")
                        {
        
                            lvRequestShapes="";

                            ListViewItem lvi = new ListViewItem(parseResults[4 * i]);

                            try
                            {
                                int contor = 0;
                                string serializedRequestShape = "";

                                deserializedRequestShapes[i] = parseResults[4 * i + 1].Split('\n');

                                lvRss = new string[deserializedRequestShapes[i].Length / 6];

                                for (int k = 0; k < deserializedRequestShapes[i].Length; k++)
                                {
                                    serializedRequestShape = serializedRequestShape + deserializedRequestShapes[i][k] + "\n";

                                    if ((k + 1) % 6 == 0)
                                    {
                                        lvRss[contor++] = serializedRequestShape.Substring(0,serializedRequestShape.Length-1);
                                        serializedRequestShape = "";
                                    }
                                }

                                lvi.Tag = lvRss;
            
                                for (int j = 0; j < deserializedRequestShapes[i].Length; j++)
                                {
                                    lvRequestShapes += deserializedRequestShapes[i][j] + " ";
                                }            

                                lvi.SubItems.Add(lvRequestShapes);
                            }
                            catch(Exception f)
                            {
                                MessageBox.Show(f.Message);
                            }


                            lvi.SubItems.Add(parseResults[4 * i + 2]);
                            lvi.SubItems.Add(parseResults[4 * i + 3]);

                            

                            this.lvTestConfigs.Items.Add(lvi);
                        }
                    }

                }
                else
                {

                    if (this.SmartSpammer.lastError != null)
                    {

                        MessageBox.Show(this.SmartSpammer.lastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
