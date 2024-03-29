using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml.Serialization;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using Microsoft.CSharp;

namespace FuzzySelector.Client
{

    /// <summary>
    ///   Fereastra folosita pentru invocarea unui serviciu web.
    /// </summary>
    public partial class WSDLConnectorForm : Form
    {

        /// <summary>
        ///   Tipul serviciului.
        /// </summary>
        private Type service;

        /// <summary>
        ///   Proprietatile folosite de catre PropertyGrid.
        /// </summary>
        private Properties properties;

        /// <summary>
        ///   Informatii despre metodele puse la dispozitie de catre serviciul web.
        /// </summary>
        private MethodInfo[] methodInfos;

        /// <summary>
        ///   Informatii despre parametrii unei metode puse la dispozitie de catre serviciul web.
        /// </summary> 
        private ParameterInfo[] parameterInfos;

        /// <summary>
        ///   Numele metodei ce va fi invocata.
        /// </summary>
        private String methodName;

        /// <summary>
        ///   Tipurile parametrilor pentru metoda ce va fi invocata.
        /// </summary>
        private Type[] parameterTypes;

        /// <summary>
        ///   Valorile parametrilor pentru metoda ce va fi invocata.
        /// </summary>
        private Object[] parameters;

        /// <summary>
        ///   Executor al metodei invocate pe un fir separat.
        /// </summary>
        private BackgroundWorker asyncWorker;

        public WSDLConnectorForm(string accessPoint)
        {

            InitializeComponent();

            txbWSDLAddress.Text = accessPoint;

            asyncWorker = new BackgroundWorker();

            asyncWorker.RunWorkerCompleted += Async_RunWorkerCompleted;
            asyncWorker.DoWork += Async_DoWork;
        }

        /// <summary>
        ///   Preia informatiile din documentul WSDL (contruieste si compileaza un proxy local pentru serviciul web).
        ///   Pune la dispozitie toate metodele ce pot fi invocate prin acest proxy.
        /// </summary>
        private void DynamicInvocation()
        {

            try
            {

                txbMessage.Text = "";

                Uri uri = new Uri(txbWSDLAddress.Text);

                txbMessage.Text += "Requesting WSDL\r\n";

                WebRequest webRequest = WebRequest.Create(uri);
                System.IO.Stream requestStream = webRequest.GetResponse().GetResponseStream();

                ServiceDescription serviceDescription = ServiceDescription.Read(requestStream);
                string serviceName = serviceDescription.Services[0].Name;

                trvMethods.Nodes.Add(serviceName);

                txbMessage.Text += "Generating Proxy\r\n";

                ServiceDescriptionImporter serviceDescriptionImporter = new ServiceDescriptionImporter();

                serviceDescriptionImporter.AddServiceDescription(serviceDescription, String.Empty, String.Empty);
                serviceDescriptionImporter.ProtocolName = "Soap";
                serviceDescriptionImporter.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;

                txbMessage.Text += "Generating assembly\r\n";

                CodeNamespace codeNameSpace = new CodeNamespace();
                CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

                codeCompileUnit.Namespaces.Add(codeNameSpace);

                ServiceDescriptionImportWarnings serviceDescriptionImportWarnings = serviceDescriptionImporter.Import(codeNameSpace, codeCompileUnit);

                if (serviceDescriptionImportWarnings == 0)
                {

                    StringWriter stringWriter = new StringWriter();
                    CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();

                    cSharpCodeProvider.GenerateCodeFromNamespace(codeNameSpace, stringWriter, new CodeGeneratorOptions());

                    txbMessage.Text += "Compiling assembly\r\n";

                    string[] assemblyReferences = new string[2] { "System.Web.Services.dll", "System.Xml.dll" };

                    CompilerParameters compileParameters = new CompilerParameters(assemblyReferences);

                    compileParameters.GenerateExecutable = false;
                    compileParameters.GenerateInMemory = true;
                    compileParameters.TreatWarningsAsErrors = false;
                    compileParameters.WarningLevel = 4;

                    CompilerResults compilerResults = new CompilerResults(new TempFileCollection());
                    compilerResults = cSharpCodeProvider.CompileAssemblyFromDom(compileParameters, codeCompileUnit);

                    Assembly assembly = compilerResults.CompiledAssembly;

                    service = assembly.GetType(serviceName);

                    txbMessage.Text += "Retrieving web service methods\r\n";

                    methodInfos = service.GetMethods();

                    foreach (MethodInfo methodInfo in methodInfos)
                    {

                        if (methodInfo.Name == "Discover")
                        {

                            break;
                        }

                        trvMethods.Nodes[0].Nodes.Add(methodInfo.Name);

                    }

                    trvMethods.Nodes[0].Expand();

                    txbMessage.Text += "Ready to invoke\r\n ";
                }
                else
                {

                    txbMessage.Text += serviceDescriptionImportWarnings;
                }
            }
            catch (Exception e)
            {

                txbMessage.Text += "\r\n" + e.Message + "\r\n\r\n" + e.ToString();
            }

            tabControl.SelectedTab = tabPageMessage;

            txbMessage.DeselectAll();
        }

        /// <summary>
        ///   Indica o modificare a adresei documentului WSDL.
        /// </summary>
        private void txbWSDLAddress_TextChanged(object sender, EventArgs e)
        {

            if (txbWSDLAddress.Text.Length != 0)
            {

                btnGet.Enabled = true;
            }
        }

        /// <summary>
        ///   Indică apasarea butonului de preluare a informatiilor de la serviciul web.
        /// </summary>
        private void btnGet_Click(object sender, EventArgs e)
        {

            trvMethods.Nodes.Clear();
            trvParameters.Nodes.Clear();

            btnGet.Enabled = false;
            btnInvoke.Enabled = false;

            propertyGrid.SelectedObject = null;

            DynamicInvocation();
        }

        /// <summary>
        ///   Indică selectarea unui nod din tree-view-ul cu metode.
        ///   Introduce informatiile corespunzatoare metodei selectate in tree-view-ul cu parametrii.
        /// </summary>
        private void trvMethods_AfterSelect(object sender, TreeViewEventArgs e)
        {

            trvParameters.Nodes.Clear();

            propertyGrid.SelectedObject = null;

            if (e.Node.Parent != null)
            {

                trvParameters.Nodes.Add(e.Node.Text);

                btnInvoke.Enabled = true;

                parameterInfos = methodInfos[e.Node.Index].GetParameters();

                properties = new Properties(parameterInfos.Length);

                foreach (ParameterInfo parameterInfo in parameterInfos)
                {

                    trvParameters.Nodes[0].Nodes.Add(parameterInfo.Name);

                    properties.Index = parameterInfo.Position;
                    properties.Type = parameterInfo.ParameterType;
                    properties.Name = parameterInfo.Name;
                }

                trvParameters.ExpandAll();
            }
            else
            {

                btnInvoke.Enabled = false;
            }
        }

        /// <summary>
        ///   Indică selectarea unui nod din tree-view-ul cu parametrii.
        ///   Introduce informatiile corespunzatoare parametrului selectat in PropertyGrid.
        /// </summary>
        private void trvParameters_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Parent != null)
            {

                properties.Index = e.Node.Index;
                propertyGrid.SelectedObject = properties;
            }
            else
            {

                propertyGrid.SelectedObject = null;
            }
        }

        /// <summary>
        ///   Indică apasarea butonului de invocarea a unei metode a serviciului web.
        ///   Stocheaza informatiile necesare invocarii, aceasta avand loc in mod asincron. 
        /// </summary>
        private void btnInvoke_Click(object sender, EventArgs e)
        {

            try
            {

                parameters = properties.MyParameters;
                parameterTypes = properties.MyTypes;
                methodName = trvMethods.SelectedNode.Text;

                invokeMethodStart();

                asyncWorker.RunWorkerAsync();
            }
            catch (Exception ex)
            {

                invokeMethodStop();

                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///   Invocarea  propriu-zisa a unei metode a serviciului web. 
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void Async_DoWork(object sender, DoWorkEventArgs e)
        {

            MethodInfo met = service.GetMethod(methodName, parameterTypes);
            Object obj = Activator.CreateInstance(service);
            Object resp = met.Invoke(obj, parameters);

            e.Result = resp;
        }

        /// <summary>
        ///   Preluarea si afisarea rezultatelor obtinute in urma invocarii unei metode a serviciului web. 
        /// </summary>
        private void Async_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            invokeMethodStop();

            if (e.Error != null)
            {

                MessageBox.Show("Completed " + e.Error.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txbMessage.Text = "Output: \r\n\r\n" + e.Result.ToString();

            tabControl.SelectedTab = tabPageMessage;

            txbMessage.DeselectAll();
        }

        /// <summary>
        ///   Modificari in interfata in momentul pornirii unei invocarii a unei metode a serviciului web. 
        /// </summary>
        private void invokeMethodStart()
        {

            btnInvoke.Enabled = false;

            trvMethods.Enabled = false;
            trvParameters.Enabled = false;

            txbWSDLAddress.Enabled = false;
            propertyGrid.Enabled = false;
        }

        /// <summary>
        ///   Modificari in interfata in momentul pornirii unei invocarii a unei metode a serviciului web. 
        /// </summary>
        private void invokeMethodStop()
        {

            btnInvoke.Enabled = true;

            trvMethods.Enabled = true;
            trvParameters.Enabled = true;

            txbWSDLAddress.Enabled = true;
            propertyGrid.Enabled = true;
        }
    }
}