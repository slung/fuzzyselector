using System;
using System.Windows.Forms;
using FuzzySelector.Common.Communication;

using Microsoft.Uddi;
using Microsoft.Uddi.TModels;
using Microsoft.Uddi.Services;
using FuzzySelector.Common.XML;
using System.Collections.Generic;

using FunctionalityFindingService.resx;

namespace FuzzySelector.FunctionalityFindingService
{

    /// <summary>
    ///   Clasă ce comandă procesul serviciului de găsire a funcționalității.
    /// </summary>
    static class FunctionalityFindingServiceProgram
    {

        /// <summary>
        ///   Funcţia de intrare în proces.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FunctionalityFindingService functionalityFindingService = new FunctionalityFindingService();

            Application.Run(new FunctionalityFindingServiceForm(functionalityFindingService));
        }
    }
}