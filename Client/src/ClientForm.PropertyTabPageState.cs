using System;
using System.Windows.Forms;

using FuzzySelector.Common.Ontology;

namespace FuzzySelector.Client {

    public partial class ClientForm : Form {

        /// <summary>
        ///   Abstractizarea unui tab(proprietate) dintr-o cerere a clientului.
        /// </summary>
        private class PropertyTabPageState {

            /// <summary>
            ///   Valoarea medie a importanţei unei proprietaţi.
            /// </summary>
            public static readonly int MEDIUM_IMPORTANCE = 5;

            private double _crispValue = double.NaN;
            private int    _fuzzyIndex = 0;

            private Constants.VALUE_PREFIXES _crispPrefix = Constants.VALUE_PREFIXES.AT_LEAST_ABOUT;
            private int _crispAboutPercentage = 0;

            private Constants.VALUE_PREFIXES _fuzzyPrefix = Constants.VALUE_PREFIXES.AT_LEAST_ABOUT;
            private int _fuzzyAboutPercentage = 0;

            private Constants.RADIO_BUTTONS _selectedRadioButton = Constants.RADIO_BUTTONS.NOT_SPECIFIED;
           
            private int _importance = MEDIUM_IMPORTANCE;
            
            private Term _customTerm = null;

            /// <summary>
            ///   Fereastra clientul pe care se gaseşte acest tab.
            /// </summary>
            private ClientForm parent;

            /// <summary>
            ///   Valoarea crisp afişată în fereastra clientului.
            /// </summary>
            public double crispValue { 
                
                get { 
                    
                    return this._crispValue; 
                } 
                
                set {
                    
                    this._crispValue = value; 
                } 
            }

            /// <summary>
            ///   Valoarea fuzzy afişată în fereastra clientului.
            /// </summary>
            public int fuzzyIndex { 
                
                get { 
                    
                    return this._fuzzyIndex; 
                }
 
                set { 

                    this._fuzzyIndex = value; 
                } 
            }

            /// <summary>
            ///   Prefixul valorii crisp (exact, aproximativ)
            /// </summary>
            public Constants.VALUE_PREFIXES crispPrefix { 
                
                get { 
                    
                    return this._crispPrefix; 
                } 
                
                set { 
                    
                    this._crispPrefix = value; 
                }
            }

            /// <summary>
            ///   Procentul pentru estimări aproximative a valorii crisp.
            /// </summary>
            public int crispAboutPercentage { 
                
                get { 
                    
                    return this._crispAboutPercentage; 
                }

                set { 
                    
                    this._crispAboutPercentage = value; 
                }
            }

            /// <summary>
            ///   Prefixul valorii fuzzy (exact, aproximativ, etc.)
            /// </summary>
            public Constants.VALUE_PREFIXES fuzzyPrefix { 
                
                get {
                    
                    return this._fuzzyPrefix; 
                }

                set { 
                    
                    this._fuzzyPrefix = value; 
                }
            }

            /// <summary>
            ///   Procentul pentru estimări aproximative a valorii fuzzy.
            /// </summary>
            public int fuzzyAboutPercentage { 
                
                get { 
                    
                    return this._fuzzyAboutPercentage; 
                }
                
                set { 
                    
                    this._fuzzyAboutPercentage = value;
                }
            }

            /// <summary>
            ///   Butonul radio selectat indicând tipul cererii.
            /// </summary>
            public Constants.RADIO_BUTTONS selectedRadioButton { 
                
                get { 
                    
                    return this._selectedRadioButton; 
                }
                
                set { 
                    
                    this._selectedRadioButton = value; 
                }
            }

            /// <summary>
            ///   Importanţa acestei proprietăţi în cadrul cererii.
            /// </summary>
            public int importance { 
                
                get { 
                    
                    return this._importance; 
                } 
                
                set { 
                    
                    this._importance = value; 
                }
            }

            /// <summary>
            ///   Termenul efectiv utilizat pentru a face cererea.
            /// </summary>
            public Term customTerm { 
                
                get { 
                    
                    return this._customTerm; 
                } 
                
                set {
                    
                    this._customTerm = value; 
                }
            }

            /// <param name="form">Fereastra clientul pe care se gaseşte acest tab.</param>
            public PropertyTabPageState(ClientForm form) {

                this.parent = form;
            }

            /// <summary>
            ///   Improspătează fereastra clientului cu valorile acestui tab.
            /// </summary>
            public void applyState() {

                this.parent.txtCrispValue.Text = this._crispValue.ToString();

                try {

                    this.parent.cboFuzzyValue.SelectedIndex = this._fuzzyIndex;
                } 
                catch (ArgumentOutOfRangeException) {

                }

                this.parent.rbNotSpecified.Checked    = this._selectedRadioButton == Constants.RADIO_BUTTONS.NOT_SPECIFIED;
                this.parent.rbSpecifiedCrisp.Checked  = this._selectedRadioButton == Constants.RADIO_BUTTONS.CRISP_VALUE;
                this.parent.rbSpecifiedFuzzy.Checked  = this._selectedRadioButton == Constants.RADIO_BUTTONS.FUZZY_VALUE;
                this.parent.rbSpecifiedCustom.Checked = this._selectedRadioButton == Constants.RADIO_BUTTONS.CUSTOM;

                this.parent.cboFuzzyValuePrefix.SelectedIndex = (int)this._fuzzyPrefix;
                this.parent.nudFuzzyPercent.Value             = this._fuzzyAboutPercentage;
                this.parent.cboCrispValuePrefix.SelectedIndex = (int)this._crispPrefix;
                this.parent.nudCrispPercent.Value             = this._crispAboutPercentage;

                this.parent.tbImportance.Value = this._importance;
            }

            /// <summary>
            ///   Se asigură că valorile cererii se încadrează în restricţiile ontologiei.
            ///   Apelat după ce utilizatorul modifică ceva în cerere.
            /// </summary>
            /// <param name="property">Proprietatea din ontologie a cărei restricţii trebuiesc respectate.</param>
            public void reconstructTerm(Property property) {

                if (this._selectedRadioButton == Constants.RADIO_BUTTONS.CRISP_VALUE) {

                    this.reconstructCrispTerm(property);
                } 
                else {

                    if (this._selectedRadioButton == Constants.RADIO_BUTTONS.FUZZY_VALUE) {

                        this.reconstructFuzzyTerm(property);
                    }
                }
            }

            /// <summary>
            ///   Se asigură că valorile cererii se încadrează în restricţiile ontologiei pentru un termen crisp.
            /// </summary>
            /// <param name="property">Proprietatea din ontologie a cărei restricţii trebuiesc respectate.</param>
            private void reconstructCrispTerm(Property property) {

                bool isAtLeast = this.parent.cboCrispValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_LEAST || this.parent.cboCrispValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_LEAST_ABOUT;
                bool isAtMost  = this.parent.cboCrispValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_MOST  || this.parent.cboCrispValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_MOST_ABOUT;
               
                double aroundPercentage = this.parent.nudCrispPercent.Visible ? (double)this.parent.nudCrispPercent.Value / 100 : 0;
               
                double start = 0;
                double left = 0;
                double right = 0;
                double end = 0;
                
                aroundPercentage = aroundPercentage < 0 ? 0 : aroundPercentage > 1 ? 1 : aroundPercentage;
               
                double domainLength = Math.Abs(property.start - property.end);

                if (double.IsInfinity(domainLength)) {

                    domainLength = 2 * Math.Min(Math.Abs(this._crispValue - property.start), Math.Abs(this._crispValue - property.end));
                }

                if (double.IsInfinity(domainLength) || double.IsNaN(domainLength)) {

                    domainLength = 0; 
                }

                double distance = (property.start > property.end ? -1 : 1) * aroundPercentage * domainLength / 2;
               
                if (isAtMost) {

                    start = left = property.start;
                } 
                else {

                    start = this._crispValue - distance;
                    left = this._crispValue;
                }

                if (isAtLeast) {

                    right = end = property.end;
                } 
                else {

                    right = this._crispValue;
                    end = this._crispValue + distance;
                }

                this._customTerm = new Term(property.name, start, left, right, end);
            }

            /// <summary>
            ///   Se asigură că valorile cererii se încadrează în restricţiile ontologiei pentru un termen fuzzy.
            /// </summary>
            /// <param name="property">Proprietatea din ontologie a cărei restricţii trebuiesc respectate.</param>
            private void reconstructFuzzyTerm(Property property) {

                bool isAtLeast = this.parent.cboFuzzyValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_LEAST || this.parent.cboFuzzyValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_LEAST_ABOUT;
                bool isAtMost  = this.parent.cboFuzzyValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_MOST  || this.parent.cboFuzzyValuePrefix.SelectedIndex == (int)Constants.VALUE_PREFIXES.AT_MOST_ABOUT;
               
                double aroundPercentage = this.parent.nudFuzzyPercent.Visible ? (double)this.parent.nudFuzzyPercent.Value / 100 : 0;
                
                double start = 0;
                double left = 0;
                double right = 0;
                double end = 0;
                
                Term fuzzyTerm = property.terms[this._fuzzyIndex];
               
                aroundPercentage = aroundPercentage < 0 ? 0 : aroundPercentage > 1 ? 1 : aroundPercentage;
                
                double domainLength = Math.Abs(property.start - property.end);

                if (double.IsInfinity(domainLength)) {

                    domainLength = 2 * Math.Min(Math.Abs(fuzzyTerm.start - property.start), Math.Abs(fuzzyTerm.end - property.end));
                }

                if (double.IsInfinity(domainLength) || double.IsNaN(domainLength)) {

                    domainLength = 0; 
                }

                double distance = (property.start > property.end ? -1 : 1) * aroundPercentage * domainLength / 2;
             
                if (isAtMost) {

                    start = left = property.start;
                } 
                else {

                    start = (property.start > property.end ? fuzzyTerm.end : fuzzyTerm.start) - distance;
                    left = property.start > property.end ? fuzzyTerm.right : fuzzyTerm.left;
                }

                if (isAtLeast) {

                    right = end = property.end;
                } 
                else {

                    right = property.start > property.end ? fuzzyTerm.left : fuzzyTerm.right;
                    end = (property.start > property.end ? fuzzyTerm.start : fuzzyTerm.end) + distance;
                }

                this._customTerm = new Term(property.name, start, left, right, end);
            }
        }
    }
}