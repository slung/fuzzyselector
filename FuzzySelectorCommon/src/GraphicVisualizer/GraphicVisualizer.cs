using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using FuzzySelector.Common.Ontology;
using ZedGraph;
using System.Windows.Forms;

namespace FuzzySelector.Common.GraphicVisualizer {

    /// <summary>
    ///   Callback după ce un termen este editat din vizualizarea grafică.
    /// </summary>
    /// <param name="term">Noua formă a termenului după editare</param>
    public delegate void AfterEditEventHandler(Term term);

    /// <summary>
    ///   Clasă ce oferă funcţionalitatea de vizualizare grafică a formelor pentru termenii fuzzy.
    /// </summary>
    public class Visualizer {

        /// <summary>
        ///   Grosimea liniei cu care se desenează.
        /// </summary>
        private const int lineWidth = 2;

        /// <summary>
        ///   Mărimea punctelor de pe grafic.
        /// </summary>
        private const int symbolSize = 4;

        /// <summary>
        ///   Stilul de umplere al punctelor de pe grafic.
        /// </summary>
        private static readonly Fill symbolFill = new Fill(Color.Black);

        /// <summary>
        ///   Unghiul gradientului cu care se colorează termenii.
        /// </summary>
        private const int gradientAngle = 270;

        /// <summary>
        ///   Structură ce agrega proprietăţile necesare a fi asociate unui termen.
        /// </summary>
        private struct GraphicalTerm {

            /// <summary>
            ///   Indică dacă se acceptă editarea termenului direct din interfaţa vizuală.
            /// </summary>
            public readonly bool isEditable;

            /// <summary>
            ///   Dacă este editabil ce callback este apelat după editare, null pentru nici o apelare.
            /// </summary>
            public readonly AfterEditEventHandler afterEditEventHandler;

            /// <summary>
            ///   Curba grafică vizuală asociată formei termenului.
            /// </summary>
            public readonly CurveItem associatedCurve;

            /// <param name="isEditable">Indică dacă se acceptă editarea termenului direct din interfaţa vizuală</param>
            /// <param name="afterEditEventHandler">Ce callback este apelat după editare</param>
            /// <param name="associatedCurve">Curba grafică vizuală asociată formei termenului</param>
            public GraphicalTerm(bool isEditable, AfterEditEventHandler afterEditEventHandler, CurveItem associatedCurve) {

                this.isEditable = isEditable;
                this.afterEditEventHandler = afterEditEventHandler;
                this.associatedCurve = associatedCurve;
            }
        }

        /// <summary>
        ///   Manager tabele lingvistice.
        /// </summary>
        public readonly ResourceManager resourceManager = new ResourceManager("FuzzySelectorCommon.resx.FuzzySelectorCommonStrings", System.Reflection.Assembly.GetExecutingAssembly());

        /// <summary>
        ///   Fereastra efectivă de vizualizare.
        /// </summary>
        private GraphicVisualizerForm form;

        /// <summary>
        ///   Controlul ZedGraph ce realizează desenarea graficului.
        /// </summary>
        private ZedGraphControl zedGraph;

        /// <summary>
        ///   Dicţionar de asociere a unui termen cu proprietăţile sale.
        /// </summary>
        private Dictionary<Term, GraphicalTerm> termAssocGraphics = new Dictionary<Term, GraphicalTerm>();

        /// <param name="title">Titlul ferestrei</param>
        /// <param name="width">Lăţimea ferestrei</param>
        /// <param name="height">Înălţimea ferestrei</param>
        /// <param name="x">Distanţa de la marginea dreaptă a ecranului până la fereastră</param>
        /// <param name="y">Distanţa de la marginea de sus a ecranului până la fereastră</param>
        /// <param name="onClose">Handlerul evenimentului de închidere a ferestrei, null pentru nici un handler</param>
        public Visualizer(string title, int width, int height, int x, int y,FormClosedEventHandler onClose) {
            
            if (height < 0 && width < 0) {

                height = 200;
            }

            if (height < 0) {

                height = 9 * width / 16;
            }

            if (width < 0) {

                width = 16 * height / 9;
            }

            this.form = new GraphicVisualizerForm(this);

            if (onClose != null) {

                this.form.FormClosed += onClose;
            }

            this.form.Show();

            this.zedGraph = this.form.graphicControl;
            this.zedGraph.PointEditEvent += new ZedGraphControl.PointEditHandler(this.curveHasBeenEdited);
            this.form.Text = title;
            this.form.Bounds = new Rectangle(x, y, width, height);
        }

        /// <summary>
        ///   Închide fereastra de vizualizare.
        /// </summary>
        public void closeMe() {

            this.form.Close();
        }

        /// <summary>
        ///   Adaugă o proprietate în graficul vizual. Se foloseşte un gradient cu gradaţii discrete pentru afişarea termenilor.
        /// </summary>
        /// <param name="property">Proprietatea de adăugat</param>
        /// <param name="startColor">Prima culoare în gradientul de afişare a termenilor</param>
        /// <param name="endColor">Ultima culoare în gradientul de afişare a termenilor</param>
        /// <param name="secondAxis">True indică plasarea formelor pe axa Y2, False pe axa Y1</param>
        public void addProperty(Property property, Color startColor, Color endColor, bool secondAxis) {
            
            if (property == null) {

                return;
            }

            int termsCount = property.termsCount;

            if (termsCount > 0) {

                float plusA = (float)(endColor.A - startColor.A) / termsCount;
                float plusR = (float)(endColor.R - startColor.R) / termsCount;
                float plusG = (float)(endColor.G - startColor.G) / termsCount;
                float plusB = (float)(endColor.B - startColor.B) / termsCount;

                float colA = (float)startColor.A;
                float colR = (float)startColor.R;
                float colG = (float)startColor.G;
                float colB = (float)startColor.B;

                foreach (Term term in property.terms) {

                    this.addTerm(term, Color.FromArgb((int)colA, (int)colR, (int)colG, (int)colB), secondAxis, false, null);
                 
                    colA += plusA;
                    colR += plusR;
                    colG += plusG;
                    colB += plusB;
                }
            }
        }

        /// <summary>
        ///   Adaugă un termen în graficul vizual.
        /// </summary>
        /// <param name="term">Termenul de adăugat</param>
        /// <param name="color">Culoarea termenului</param>
        /// <param name="secondAxis">True indică plasarea formelor pe axa Y2, False pe axa Y1</param>
        /// <param name="isEditable">Indică dacă se acceptă editarea termenului direct din interfaţa vizuală</param>
        /// <param name="eventHandler">Dacă este editabil ce callback este apelat după editare, null pentru nici o apelare</param>
        public void addTerm(Term term, Color color, bool secondAxis, bool isEditable, AfterEditEventHandler eventHandler) {
           
            if (term == null || this.termAssocGraphics.ContainsKey(term)) {

                return;
            }

            PointPairList ppList = new PointPairList(new double[] { term.start, term.left, term.right, term.end }, new double[] { 0, 1, 1, 0 });
            
            LineItem curve = this.zedGraph.GraphPane.AddCurve(term.name, ppList, Color.FromArgb(255, color), ZedGraph.SymbolType.Circle);
           
            curve.Line.Width = lineWidth;
            curve.Line.Fill = new Fill(color, Color.FromArgb(color.A / 4, color), gradientAngle);
            curve.Symbol.Size = symbolSize;
            curve.Symbol.Fill = symbolFill;
            curve.IsY2Axis = secondAxis;

            this.termAssocGraphics.Add(term, new GraphicalTerm(isEditable, eventHandler, curve));
            this.zedGraph.GraphPane.AxisChange();
            this.zedGraph.Invalidate();
        }

        /// <summary>
        ///   Scoate un termen cu numele dat din graficul vizual.
        /// </summary>
        /// <param name="name">Numele termenului de scos</param>
        public void removeTerm(string name) {

            foreach (Term term in this.termAssocGraphics.Keys) {

                if (term.name == name) {

                    this.zedGraph.GraphPane.CurveList.Remove(this.termAssocGraphics[term].associatedCurve);
                    this.termAssocGraphics.Remove(term);
                    return;
                }
            }            
        }

        /// <summary>
        ///   Schimbă axa de afişare a unui termen.
        /// </summary>
        /// <param name="term">Termenul pentru care se schimbă axa de afişare</param>
        /// <param name="secondAxis">True indică plasarea formelor pe axa Y2, False pe axa Y1</param>
        public void changeTermAxis(Term term, bool secondAxis) {

            if (term != null && this.termAssocGraphics.ContainsKey(term)) {

                this.termAssocGraphics[term].associatedCurve.IsY2Axis = secondAxis;
                this.zedGraph.GraphPane.AxisChange();
                this.zedGraph.Invalidate();
            }
        }

        /// <summary>
        ///   Indică editarea direct din interfaţa vizuală a unui termen.
        ///   Validează dacă termenul este marcat ca editabil şi apelează callback-ul acestuia dacă există.
        /// </summary>
        /// <param name="sender">Controlul ZedGraph de care aparţine curba vizuală a termenului</param>
        /// <param name="pane">Panoul grafic de care aparţine curba vizuală a termenului</param>
        /// <param name="curve">Curba vizuală a termenului</param>
        /// <param name="iPt">Indexul punctului de pe curbă ce a fost editat</param>
        private string curveHasBeenEdited(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt) {

            foreach (Term term in this.termAssocGraphics.Keys) {

                GraphicalTerm gTerm = this.termAssocGraphics[term];

                if (gTerm.associatedCurve == curve) {

                    if (gTerm.isEditable) {

                        if (gTerm.afterEditEventHandler != null) {

                            gTerm.afterEditEventHandler(new Term(term.name, iPt == 0 ? curve.Points[iPt].X : term.start, iPt == 1 ? curve.Points[iPt].X : term.left, iPt == 2 ? curve.Points[iPt].X : term.right, iPt == 3 ? curve.Points[iPt].X : term.end));
                        }
                    } 
                    else {

                        curve.Points[iPt].X = iPt == 0 ? term.start : iPt == 1 ? term.left : iPt == 2 ? term.right : term.end;
                        pane.AxisChange();
                        sender.Invalidate();
                    }

                    return default(string);
                }
            }

            return default(string);
        }
    }
}