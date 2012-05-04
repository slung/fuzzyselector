using System.Windows.Forms;

namespace FuzzySelector.Client {

    public partial class ClientForm : Form {
    
        /// <summary>
        ///   Clasă pentru definirea constantelor utilizate de client.
        /// </summary>
        private static class Constants {
            
            /// <summary>
            ///   Lista de chei în tabelele lingvistice pentru importanţele posibile.
            /// </summary>
            public static readonly string[] IMPORTANCES = new string[] { "Extremely Low", "Very Low", "Low", "Below Average", "Average", "Above Average", "High", "Very High", "Extremely High" };

            /// <summary>
            ///   Butoanele radio ce indică tipul cererii.
            /// </summary>
            public enum RADIO_BUTTONS { NOT_SPECIFIED, CRISP_VALUE, FUZZY_VALUE, CUSTOM };

            /// <summary>
            ///   Prefixuri pentru cereri de tip crisp sau fuzzy (cum se va aproxima forma termenului din cerere).
            /// </summary>
            public enum VALUE_PREFIXES { EXACTLY = 0, AT_LEAST = 1, AT_LEAST_ABOUT = 2, AT_MOST = 3, AT_MOST_ABOUT = 4, ABOUT = 5 };
        }
    }
}