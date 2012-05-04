using System;
using System.Windows.Forms;
using System.IO;
using System.Resources;

namespace FuzzySelector.SmartSpammer {

    /// <summary>
    ///   Fereastra de afișare a rezultatelor pentru SmartSpammer
    /// </summary>
    public partial class SmartSpammerResultsForm : Form {

        /// <summary>
        ///   Manager tabele lingvistice.
        /// </summary>
        public readonly ResourceManager resourceManager = new ResourceManager("SmartSpammer.resx.SmartSpammerStrings", System.Reflection.Assembly.GetExecutingAssembly());

    
        /// <param name="testInfos">Informatii despre test</param>
        /// <param name="results">Rezultatele serializate, fiecare string reprezentând o linie</param>
        public SmartSpammerResultsForm(string[] testDetails, String[] result) {

            InitializeComponent();

            for (int i = 0; i < result.Length; i++) {

                string[] testData = result[i].Split('*');

                ListViewItem item = new ListViewItem(testData[0]);

                item.SubItems.Add(testData[1]);
                item.SubItems.Add(testData[2]);
                
                item.Tag = testDetails[i];

                this.resultListView.Items.Add(item);
            }
        }

        /// <summary>
        ///   Indică apăsarea butonului de salvare a rezultatelor.
        ///   Deschide fereastra de salvare fișiere și încearcă scrierea rezultatelor în cel ales.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e) {

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK) {

                string  separator = this.saveFileDialog.FilterIndex == 2 ? "\t" : ",";
                string[] contents = new string[this.resultListView.Items.Count];

                for (int i = 0; i < contents.Length; ++i) {

                    for (int j = 1; j < this.resultListView.Items[i].SubItems.Count; ++j) {

                        if (j > 1) {

                            contents[i] += separator;
                        }

                        contents[i] += this.resultListView.Items[i].SubItems[j].Text;
                    }
                }

                try {

                    File.WriteAllLines(this.saveFileDialog.FileName, contents);
                } 
                catch(Exception) {

                    MessageBox.Show(resourceManager.GetString("ERROR_FILE_SAVING"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Afiseaza detaliile testului selectat din lista cu timpii de raspuns corespunzatori testelor rulate.
        /// </summary>
        private void resultListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultListView.SelectedItems.Count != 0)
            {
                
                ListViewItem lvi = resultListView.SelectedItems[0];

                string[] testDetails = ((string)lvi.Tag).Split('*');

                this.resultRichTextBox.Clear();
                this.resultRichTextBox.AppendText("Test information parameters:\r\n\r\n");
                this.resultRichTextBox.AppendText("Inference Machine on: Client" + "\r\n");
                this.resultRichTextBox.AppendText("Functionality: " + testDetails[0] + "\r\n");
                this.resultRichTextBox.AppendText("Server Load Level: " + testDetails[1] + "\r\n");
                this.resultRichTextBox.AppendText("No. of requests after load level achieved: " + testDetails[2] + "\r\n");
                this.resultRichTextBox.AppendText("Number of selected properties: " + testDetails[3]);
            }
        }
    }
}
