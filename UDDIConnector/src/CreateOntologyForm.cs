﻿using System;
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
        private readonly string ontologiesFilePath = "./resx/";
        private Properties availableProperties;
        private Properties selectedProperties;
        private Ontology ontology;

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

        #region EVENTS

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
            this.gbDetails.Enabled = true;

            Property selectedItem = (Property)this.lbSelectedProperties.SelectedItem;

            this.PopultateWithTerms(selectedItem.Terms);
        }

        private void btnSaveProperty_Click(object sender, EventArgs e)
        {
            //Save property Start & End
            ((Property)this.lbSelectedProperties.SelectedItem).start = Double.Parse(this.tbOntologyStart.Text);
            ((Property)this.lbSelectedProperties.SelectedItem).end = Double.Parse(this.tbOntologyEnd.Text);
        }

        private void lbAvailableProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gbDetails.Enabled = false;
        }

        private void btnCreatePublish_Click(object sender, EventArgs e)
        {
            //Create properties from selected properties
            this.selectedProperties = new Properties();

            foreach (Property property in this.lbSelectedProperties.Items)
            {
                this.selectedProperties.AddProperty(property);
            }

            //Create Ontology object
            this.ontology = new Ontology(this.tbOntologyName.Text, this.selectedProperties); 


            //Save new Ontology to XML
            this.ontology.ToXML(this.ontologiesFilePath);
        }

        private void tbOntologyName_TextChanged(object sender, EventArgs e)
        {
            this.ToggleCreatePublishEnabled();
        }

        private void tbOntologyStart_TextChanged(object sender, EventArgs e)
        {
            this.ToggleSavePropertyEnabled();
            this.ToggleCreatePublishEnabled();
        }

        private void tbOntologyEnd_TextChanged(object sender, EventArgs e)
        {
            this.ToggleSavePropertyEnabled();
            this.ToggleCreatePublishEnabled();
        }

        #endregion

        #region HELPERS

        private void ToggleCreatePublishEnabled()
        {
            this.btnCreatePublish.Enabled = this.btnSaveProperty.Enabled &&
                                            this.tbOntologyName.Text.Length > 0 &&
                                            this.tbOntologyStart.Text.Length > 0 &&
                                            this.tbOntologyEnd.Text.Length > 0 ? true : false;
        }

        private void ToggleSavePropertyEnabled()
        {
            double propertyStart, propertyEnd;

            this.btnSaveProperty.Enabled = double.TryParse(this.tbOntologyStart.Text, out propertyStart) &&
                                           double.TryParse(this.tbOntologyEnd.Text, out propertyEnd) ? true : false;
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

        private void PopultateWithTerms(List<Term> terms)
        {
            this.dgvTerms.DataSource = terms;
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

        #endregion
    }
}
