using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FuzzySelector.Client
{

    /// <summary>
    ///   Fereastra de afișare a rezultatelor pentru client
    /// </summary>
    public partial class ClientResultsForm : Form
    {


        /// <summary>
        ///   Scorurile serviciilor in ordine descrescatoare.
        /// </summary>
        private double[] _results;

        /// <param name="results">Rezultatele serializate, fiecare string reprezentând o linie</param>
        /// <param name="allResults">Variabila booleana care indica daca utilizatrul a ales varianta afisarii tuturor rezultatelor</param>
        /// <param name="nrResults">Indica o valoare care semnifica primele cate rezultate in ordinea descrescatoare vor fi afisate in form-ul de rezultate</param>
        public ClientResultsForm(string[] results, bool allResults, int nrResults)
        {

            InitializeComponent();

            Array.Sort(results, delegate(String result1, String result2)
            {

                return double.Parse(result2.Split(',')[1]).CompareTo(double.Parse(result1.Split(',')[1]));
            });

            this._results = new double[results.Length];

            if (allResults)
            {

                for (int i = 0; i < results.Length; ++i)
                {

                    string[] data = results[i].Split(',');

                    this._results[i] = double.Parse(data[1]);

                    ListViewItem item = new ListViewItem(data[0]);

                    item.SubItems.Add(data[1]);
                    item.SubItems.Add(data[2]);

                    this.resultListView.Items.Add(item);
                }
            }
            else
            {
                if (nrResults <= results.Length)
                {

                    for (int i = 0; i < nrResults; ++i)
                    {

                        string[] data = results[i].Split(',');

                        this._results[i] = double.Parse(data[1]);

                        ListViewItem item = new ListViewItem(data[0]);

                        item.SubItems.Add(data[1]);
                        item.SubItems.Add(data[2]);

                        this.resultListView.Items.Add(item);
                    }
                }
                else
                {
                    for (int i = 0; i < results.Length; ++i)
                    {

                        string[] data = results[i].Split(',');

                        this._results[i] = double.Parse(data[1]);

                        ListViewItem item = new ListViewItem(data[0]);

                        item.SubItems.Add(data[1]);
                        item.SubItems.Add(data[2]);

                        this.resultListView.Items.Add(item);
                    }
                }
            }
        }

        /// <summary>
        ///   Indică apăsarea butonului de salvare a rezultatelor.
        ///   Deschide fereastra de salvare fișiere și încearcă scrierea rezultatelor în cel ales.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                string separator = this.saveFileDialog.FilterIndex == 2 ? "\t" : ",";
                string[] contents = new string[this.resultListView.Items.Count];

                for (int i = 0; i < contents.Length; ++i)
                {

                    for (int j = 0; j < this.resultListView.Items[i].SubItems.Count; ++j)
                    {

                        if (j > 0)
                        {

                            contents[i] += separator;
                        }

                        contents[i] += this.resultListView.Items[i].SubItems[j].Text;
                    }
                }

                try
                {

                    File.WriteAllLines(this.saveFileDialog.FileName, contents);
                }
                catch (Exception)
                {

                    MessageBox.Show("There was an error trying to save the file ! Please make sure the file isn't opened by another program and that you have access to modify it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Indica apasarea optiunii de invocare a serviciului web selectat din lista de rezultate.
        /// Initiaza form-ul prin care se va realiza invocarea efectiva a servicului web.
        /// </summary>
        private void invokeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (resultListView.SelectedItems.Count > 0)
            {

                try
                {

                    String accessPoint = resultListView.SelectedItems[0].SubItems[2].Text;

                    Thread thread = new Thread(delegate()
                    {

                        Application.Run(new WSDLConnectorForm(accessPoint));
                    });

                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

