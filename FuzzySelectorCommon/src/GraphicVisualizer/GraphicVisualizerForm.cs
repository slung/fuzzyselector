using System.Windows.Forms;
using ZedGraph;

namespace FuzzySelector.Common.GraphicVisualizer {

    /// <summary>
    ///   Fereastra grafică pentru vizualizarea termenilor.
    /// </summary>
    public partial class GraphicVisualizerForm : Form {

        /// <summary>
        ///   Obiectul cu funcționalitatea efectivă.
        /// </summary>
        private Visualizer visualizer;

        /// <summary>
        ///   Controlul ZedGraph care realizează desenarea.
        /// </summary>
        public ZedGraphControl graphicControl {

            get {

                return this.zedGraph;
            }
        }

        /// <param name="visualizer">Obiectul cu funcționalitatea efectivă</param>
        public GraphicVisualizerForm(Visualizer visualizer) {

            InitializeComponent();

            this.visualizer = visualizer;

            this.zedGraph.GraphPane.Title.IsVisible = false;
            this.zedGraph.GraphPane.XAxis.Title.IsVisible = false;
            this.zedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;
            this.zedGraph.GraphPane.XAxis.MinorGrid.IsVisible = true;
            this.zedGraph.GraphPane.YAxis.Title.IsVisible = false;
            this.zedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;
            this.zedGraph.GraphPane.Y2Axis.MajorGrid.IsVisible = true;
            this.zedGraph.GraphPane.Y2Axis.IsVisible = true;
            this.zedGraph.GraphPane.YAxis.Scale.Max = 1.2;
            this.zedGraph.GraphPane.Y2Axis.Scale.Max = 1.3;
            this.zedGraph.GraphPane.Legend.Position = ZedGraph.LegendPos.Top;
        }

        /// <summary>
        ///   Indică apăsarea butonului de help.
        ///   Afișează informațiile legate de licența utilizării bibliotecii ZedGraph.
        /// </summary>
        private void GraphicVisualizeForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e) {

            MessageBox.Show(this.visualizer.resourceManager.GetString("COPYRIGHT_ZEDGRAPH"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}