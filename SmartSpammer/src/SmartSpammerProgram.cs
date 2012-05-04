using System;
using System.Windows.Forms;

namespace FuzzySelector.SmartSpammer
{

    /// <summary>
    ///   Clasă ce comandă procesul spammer.
    /// </summary>
    public static class SmartSpammerProgram {

        /// <summary>
        ///   Funcţia de intrare în proces.
        /// </summary>
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new SmartSpammerForm());  
        }
    }
}