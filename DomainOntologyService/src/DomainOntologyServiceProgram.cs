using System;
using System.Windows.Forms;

using Microsoft.Uddi;
using Microsoft.Uddi.TModels;

namespace FuzzySelector.DomainOntologyService
{

    /// <summary>
    ///   Clasă ce comandă procesul serviciului de ontologia domeniului.
    /// </summary>
    static class DomainOntologyServiceProgram
    {

        /// <summary>
        ///   Funcţia de intrare în proces.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DomainOntologyService domainOntologyService = new DomainOntologyService();

            Application.Run(new DomainOntologyServiceForm(domainOntologyService));
        }
    }
}