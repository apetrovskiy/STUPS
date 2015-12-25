/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/4/2012
 * Time: 11:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSRunner
{
    using System;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading;
    using System.Globalization;
    using System.Management.Automation;
    using System.Management.Automation.Host;
    using System.Management.Automation.Runspaces;
    using System.Windows.Forms;
    
    /// <summary>
    /// Description of UiaPSHost.
    /// </summary>
    public sealed class UiaPSHost : PSHost
    {
        
        // private data
        private Guid instanceId;
        private Version version;
        private const string privateData = "gui host private data";
        //private PSGUIForm gui;
        private Form gui;
        //private Runspace runspace;

        //public UiaPSHost(PSGUIForm form)
        public UiaPSHost(Form form)
            : base()
        {
            gui = form;
            //gui.InvokeButton.Click += new EventHandler(InvokeButton_Click);
            instanceId = Guid.NewGuid();
            version = new Version("2.0.0");
        }

        public void Initialize(string command)
        {
//            runspace = RunspaceFactory.CreateRunspace(this);
//            runspace.Open();

            Runner.InitializeRunspace(command);

        }
        
        //private psguifo
        
//        public UiaPSHost()
//        {
//        }

        private void pipeline_StateChanged(object sender, PipelineStateEventArgs e)
        {
            Pipeline source = sender as Pipeline;
            // if the command completed update GUI.
            bool updateGUI = false;
            StringBuilder output = new StringBuilder();
            if (e.PipelineStateInfo.State == PipelineState.Completed)
            {
                updateGUI = true;
                Collection<PSObject> results = source.Output.ReadToEnd();
                foreach (PSObject result in results)
                {
                    string resultString = (string)LanguagePrimitives.ConvertTo(result, typeof(string));
                    output.Append(resultString);
                }
            }
            else if ((e.PipelineStateInfo.State == PipelineState.Stopped) ||
                     (e.PipelineStateInfo.State == PipelineState.Failed))
            {
                updateGUI = true;
                string message = string.Format("Command did not complete successfully. Reason: {0}",
                    e.PipelineStateInfo.Reason.Message);
                MessageBox.Show(message);
            }

            if (updateGUI)
            {
//                PSGUIForm.SetOutputTextBoxContentDelegate optDelegate =
//                    new PSGUIForm.SetOutputTextBoxContentDelegate(gui.SetOutputTextBoxContent);
//                gui.OutputTextBox.Invoke(optDelegate, new object[] { output.ToString() });
//
//                PSGUIForm.SetInvokeButtonStateDelegate invkBtnDelegate =
//                    new PSGUIForm.SetInvokeButtonStateDelegate(gui.SetInvokeButtonState);
//                gui.InvokeButton.Invoke(invkBtnDelegate, new object[] { true });
            }
        }
        
        
        public override Guid InstanceId
        {
            get { return instanceId; }
        }

        public override string Name
        {
            get { return "PSBook.Chapter7.Host"; }
        }

        public override Version Version
        {
            get { return version; }
        }
        
        public override CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture; }
        }

        public override CultureInfo CurrentUICulture
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
        }

//        public override PSObject PrivateData
//        {
//            get
//            {
//                return PSObject.AsPSObject(privateData);
//            }
//        }

        /// <summary>
        /// 
        /// </summary>
        public override void EnterNestedPrompt()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ExitNestedPrompt()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void NotifyBeginApplication()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void NotifyEndApplication()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exitCode"></param>
        public override void SetShouldExit(int exitCode)
        {
//            string message = string.Format("Exiting with exit code: {0}", exitCode);
//            MessageBox.Show(message);
//            runspace.CloseAsync();
//            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        public override PSHostUserInterface UI
        {
            //get { return null; }
            get { return (new object() as PSHostUserInterface); }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Write(string value)
        {
//            Runner.PSOutputArrived(strValue);
//            internal static void OnPSOutputArrived(object data)
//            {
//                if (PSOutputArrived != null) {
//                    PSOutputArrived(data);
//                }
//            }
            //Runner.PSOutputArrived(strValue);
            Runner.OnPSOutputArrived(value);
        }
    }
}
