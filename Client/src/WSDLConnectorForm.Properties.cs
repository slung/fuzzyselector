using System;
using System.Reflection;
using System.Windows.Forms;

namespace FuzzySelector.Client
{

    public partial class WSDLConnectorForm : Form
    {

        /// <summary>
        ///   Abstractizarea proprietatilor unei metode a unui serviciu web (ce poate fi invocata).
        /// </summary>
        private class Properties
        {

            /// <summary>
            ///   Tipurile parametrilor metodei.
            /// </summary>
            private Type[] myTypes;

            /// <summary>
            ///   Valorile date parametrilor metodei.
            /// </summary>
            private String[] myValues;

            /// <summary>
            ///   Numele parametrilor metodei.
            /// </summary>
            private String[] myNames;

            /// <summary>
            ///   Pozitie in cadrul parametrilor metodei.
            /// </summary>
            private int index;

            public Properties(int capacity)
            {

                myTypes = new Type[capacity];
                myValues = new String[capacity];
                myNames = new String[capacity];
            }

            [System.ComponentModel.Category("Parameter"),
             System.ComponentModel.ReadOnly(true),
             System.ComponentModel.Description("Name of parameter")]
            public String Name
            {

                get { return myNames[index]; }
                set { myNames[index] = value; }
            }

            [System.ComponentModel.Category("Parameter"),
             System.ComponentModel.ReadOnly(true),
             System.ComponentModel.Description("Type of parameter")]
            public Type Type
            {

                get { return myTypes[index]; }
                set { myTypes[index] = value; }
            }

            [System.ComponentModel.Category("Parameter"),
             System.ComponentModel.Description("Enter value but with great attention to Type of parameter")]
            public String Value
            {

                get { return myValues[index]; }
                set { myValues[index] = value; }
            }

            [System.ComponentModel.Browsable(false)]
            public int Index
            {

                set { index = value; }
            }

            [System.ComponentModel.Browsable(false)]
            public Type[] MyTypes
            {

                get { return myTypes; }
            }

            /// <summary>
            ///   Are loc o conversia valorilor specificate pentru parametrii la tipurile declarate.
            /// </summary>
            [System.ComponentModel.Browsable(false)]
            public Object[] MyParameters
            {

                get
                {

                    int capacity = myNames.Length;

                    if (capacity > 0)
                    {

                        Object[] myParameters = new Object[capacity];

                        string message = string.Empty;

                        for (int i = 0; i < capacity; ++i)
                        {

                            if (myValues[i] != null)
                            {

                                try
                                {

                                    myParameters[i] = Convert.ChangeType(myValues[i], myTypes[i]);
                                }
                                catch (Exception e)
                                {

                                    Value = null;

                                    message += myNames[i] + " " + e.Message + "\r\n";

                                }
                            }
                            else
                            {

                                message += myNames[i] + " Value must be set" + "\r\n";
                            }
                        }

                        if (message != String.Empty)
                        {

                            throw new Exception(message);
                        }
                        else
                        {

                            return myParameters;
                        }
                    }
                    else
                    {

                        return null;
                    }
                }
            }
        }
    }
}
