using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Uddi;
using Microsoft.Uddi.Businesses;
using Microsoft.Uddi.Services;
using Microsoft.Uddi.TModels;
using UddiConnector.XML;
using UddiConnector.Ontology;

namespace UDDIConnector
{
    public partial class CreateOntologyForm : Form
    {
        private readonly string propertiesFilePath = "./resx/properties.xml";
        private Properties availableProperties;
        /// <summary>
        ///   Informatii privind conexiunea la serverul UDDI.
        /// </summary>
        private UddiConnection uddiConnection;

        public CreateOntologyForm(UddiConnection uddiConnection)
        {
            this.uddiConnection = uddiConnection;
            this.availableProperties = new Properties();

            InitializeComponent();

            SetProperties();
            PopulateWithAvailableProperties();
        }

        private void SetProperties()
        {
            XMLElement root = XMLParser.parse(propertiesFilePath);

            if (root != null)
            {
                if (root.containsElements("property"))
                {
                    List<XMLElement> properties = root.getElements("property");

                    foreach (XMLElement property in properties)
                    {
                        string propertyName = null;
                        string composition = null;

                        if (property.containsAttribute("name"))
                        {
                            propertyName = property.getAttribute("name");

                            if (property.containsAttribute("composition"))
                            {
                                composition = property.getAttribute("composition");
                            }
                        }
                        else
                        {
                            return;
                        }

                        if (property.containsElements("term"))
                        {
                            List<XMLElement> xmlTerms = property.getElements("term");
                            List<Term> terms = new List<Term>();

                            foreach (XMLElement term in xmlTerms)
	                        {
		                        if (term.containsAttribute("name"))
                                {
                                    terms.Add(new Term(term.getAttribute("name")));
                                }
	                        }

                            this.availableProperties.AddProperty(new Property(propertyName, Property.GetCompositionMethodFromString(composition), terms));
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void PopulateWithAvailableProperties()
        {
            this.lbAvailableProperties.Items.AddRange(this.availableProperties.properties);//.DataSource = this.availableOntologyProperties.properties;
            this.lbAvailableProperties.SetSelected(0, true);
        }

        private void CopyAllItemsFromTo(ListBox listBoxFrom, ListBox listBoxTo)
        {
            foreach (object item in listBoxFrom.Items)
                if (!listBoxTo.Items.Contains(item))
                    listBoxTo.Items.Add(item);
        }

        private void RemoveAllItemsFromListBox(ListBox listBox)
        {
            List<object> listBoxItems = new List<object>();

            foreach (var item in listBox.Items)
            {
                listBoxItems.Add(item);
            }

            foreach (var item in listBoxItems)
            {
                listBox.Items.Remove(item);
            }
        }

        private void btnOneIn_Click(object sender, EventArgs e)
        {
            if (this.lbAvailableProperties.Items.Count > 0 && this.lbAvailableProperties.SelectedItem != null)
            {
                this.lbSelectedProperties.Items.Add(this.lbAvailableProperties.SelectedItem);
                this.lbAvailableProperties.Items.Remove(this.lbAvailableProperties.SelectedItem);

                if (this.lbAvailableProperties.Items.Count > 0)
                {
                    this.lbAvailableProperties.SetSelected(0, true);
                }
            }
        }

        private void btnOneOut_Click(object sender, EventArgs e)
        {
            if (this.lbSelectedProperties.Items.Count > 0 && this.lbSelectedProperties.SelectedItem != null)
            {
                this.lbAvailableProperties.Items.Add(this.lbSelectedProperties.SelectedItem);
                this.lbSelectedProperties.Items.Remove(this.lbSelectedProperties.SelectedItem);

                if (this.lbSelectedProperties.Items.Count > 0)
                {
                    this.lbSelectedProperties.SetSelected(0, true);
                }
            }
        }

        private void btnAllIn_Click(object sender, EventArgs e)
        {
            if (this.lbAvailableProperties.Items.Count > 0)
            {
                this.CopyAllItemsFromTo(this.lbAvailableProperties, this.lbSelectedProperties);

                this.RemoveAllItemsFromListBox(this.lbAvailableProperties);
            }
        }

        private void btnAllOut_Click(object sender, EventArgs e)
        {
            if (this.lbSelectedProperties.Items.Count > 0)
            {
                this.CopyAllItemsFromTo(this.lbSelectedProperties, this.lbAvailableProperties);

                this.RemoveAllItemsFromListBox(this.lbSelectedProperties);
            }
        }

        private void lbSelectedProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            Property selectedItem = (Property)this.lbSelectedProperties.SelectedItem;
        }
    }
}
