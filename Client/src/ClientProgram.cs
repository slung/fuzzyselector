using System;
using System.Windows.Forms;

namespace FuzzySelector.Client {

    /// <summary>
    ///   Clasă ce comandă procesul client.
    /// </summary>
    public static class ClientProgram {

        /// <summary>
        ///   Funcţia de intrare în proces.
        /// </summary>
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new ClientForm());  
        }
    }
}