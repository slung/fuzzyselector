using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UDDIConnector {

    /// <summary>
    ///   Clasă ce comandă procesul provider.
    /// </summary>
    static class ProviderProgram {

        /// <summary>
        ///   Funcţia de intrare în proces.
        /// </summary>
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new ProviderForm());
        }
    }
}
