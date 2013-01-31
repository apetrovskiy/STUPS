/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2012
 * Time: 9:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest
{
    using System;
    using System.Diagnostics;
    
    /// <summary>
    /// Description of MiddleLevelCode.
    /// </summary>
    public static class MiddleLevelCode
    {
        static MiddleLevelCode()
        {
        }
        
        //public static string RunspaceCommand { get; set; }
        
        public static string TestFormPath {
            get {
#if DEBUG
                return @"..\..\..\UIAutomationTestForms\bin\Debug\UIAutomationTestForms.exe";
#else
                return @"..\..\..\UIAutomationTestForms\bin\Release35\UIAutomationTestForms.exe";
#endif
            }
        }
        
        public static string TestFormProcess { get { return @"UIAutomationTestForms"; } }
        // public static string TestFormProcess { get { return @"nunit"; } }
        public static System.Diagnostics.Process TestProcess { get; set; }
        public static System.Diagnostics.ProcessStartInfo TestProcessStartInfo { get; set; }
        public static string TestFormNameEmpty { get { return @"WinFormsEmpty"; } }
        public static string TestFormNameAnonymous { get { return @""; } }
        public static string TestFormNameMinimized { get { return @"WinFormsMinimized"; } }
        public static string TestFormNameMaximized { get { return @"WinFormsMaximized"; } }
        public static string TestFormNameNoTaskBar { get { return @"WinFormsNoTaskBar"; } }
        public static string TestFormNameRich { get { return @"WinFormsRich"; } }
        public static string TestFormNameFull { get { return @"WinFormsFull"; } }
        
        public static string TestFormWPFNameEmpty { get { return @"WPFEmpty"; } }
        public static string TestFormWPFNameAnonymous { get { return @""; } }
        public static string TestFormWPFNameMinimized { get { return @"WPFMinimized"; } }
        public static string TestFormWPFNameMaximized { get { return @"WPFMaximized"; } }
        public static string TestFormWPFNameCollapsed { get { return @"WPFCollapsed"; } }
        
        public static void StartProcessWithForm(UIAutomationTestForms.Forms formCode,
                                                TimeoutsAndDelays formDelayEn)
        {
            int formDelay = (int)formDelayEn;
            TestProcessStartInfo.Arguments = 
                ((int)formCode).ToString();
            TestProcessStartInfo.CreateNoWindow = true;
            TestProcessStartInfo.UseShellExecute = false;
            
            TestProcessStartInfo.Arguments += " ";
            TestProcessStartInfo.Arguments +=
                formDelay.ToString();

            Console.WriteLine(
                TestFormPath +
                " " +
                TestProcessStartInfo.Arguments);
            TestProcess =
                System.Diagnostics.Process.Start(TestProcessStartInfo);
        }
        
        public static void StartProcessWithFormAndControl(
            UIAutomationTestForms.Forms formCode,
            TimeoutsAndDelays formDelayEn,
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            TimeoutsAndDelays controlDelayEn)
        {
            ControlToForm controlToForm = 
                new ControlToForm(
                    controlType,
                    controlName,
                    controlAutomationId, 
                    controlDelayEn);
            System.Collections.ArrayList arr = 
                new System.Collections.ArrayList();
            arr.Add(controlToForm);
            
            StartProcessWithFormAndControl(
                formCode,
                formDelayEn,
                ((ControlToForm[])arr.ToArray(typeof(ControlToForm))));
        }
        
        public static void StartProcessWithFormAndControl(
            UIAutomationTestForms.Forms formCode,
            TimeoutsAndDelays formDelayEn,
            object[] controlToForm)
        {
            int formDelay = (int)formDelayEn;
            
            ControlToForm[] controlToFormConverted = 
                (ControlToForm[])controlToForm;
            
            TestProcessStartInfo.Arguments = 
                ((int)formCode).ToString();
            TestProcessStartInfo.CreateNoWindow = true;
            TestProcessStartInfo.UseShellExecute = false;
            TestProcessStartInfo.LoadUserProfile = false;
            // form delay
            TestProcessStartInfo.Arguments += " ";
            TestProcessStartInfo.Arguments +=
                formDelay.ToString();
            
            if (controlToFormConverted.Length > 0) {
                for (int i = 0; i < controlToFormConverted.Length; i++) {
                    
                    // control type
                    TestProcessStartInfo.Arguments += " ";
                    string _controlType = 
                        controlToFormConverted[i].ControlType.ProgrammaticName.Substring(
                            controlToFormConverted[i].ControlType.ProgrammaticName.IndexOf(".") + 1);
                    TestProcessStartInfo.Arguments +=
                        _controlType;
                    
                    // control delay
                    int controlDelay = (int)controlToFormConverted[i].ControlDelayEn;
                    TestProcessStartInfo.Arguments += " ";
                    TestProcessStartInfo.Arguments +=
                        controlDelay;
                        //controlToFormConverted[i].ControlDelayEn.ToString();
                    
                    // control name
                    TestProcessStartInfo.Arguments += " ";
                    TestProcessStartInfo.Arguments +=
                        controlToFormConverted[i].ControlName;
                    
                    // control AutomationId
                    TestProcessStartInfo.Arguments += " ";
                    TestProcessStartInfo.Arguments +=
                        controlToFormConverted[i].ControlAutomationId;
                }
            }

            Console.WriteLine(
                TestFormPath +
                " " +
                TestProcessStartInfo.Arguments);
            TestProcess =
                System.Diagnostics.Process.Start(TestProcessStartInfo);
            
            // System.Threading.Thread.Sleep(200); // just to check
        }
        
        public static void PrepareRunspace() //string command)
        {
            CmdletUnitTest.TestRunspace.IitializeRunspace(Settings.RunspaceCommand);
// string codeSnippet = 
// @"$ErrorPreference = [System.Management.Automation.ActionPreference]::SilentlyContinue;";
            TestProcessStartInfo =
                new ProcessStartInfo();
            TestProcessStartInfo.FileName = 
                MiddleLevelCode.TestFormPath;
            CmdletUnitTest.TestRunspace.RunPSCode(
                // 20120920
                //@"[void]([UIAutomation.Preferences]::OnSuccessDelay = 100);");
                @"[void]([UIAutomation.Preferences]::OnSuccessDelay = 0);");
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            CmdletUnitTest.TestRunspace.CloseRunspace();

            if (TestProcess != null)
            {
                try { TestProcess.CloseMainWindow(); } 
                catch { }
                try { TestProcess.Kill(); }
                catch { }
            }
            System.Diagnostics.Process[] processes = 
                System.Diagnostics.Process.GetProcessesByName(
                    MiddleLevelCode.TestFormProcess);
            foreach (System.Diagnostics.Process p in processes)
            {
                try {
                    p.CloseMainWindow();
                }
                catch { }
                try {
                    p.Kill();
                } 
                catch { }
            }
            TestProcessStartInfo = null;
            TestProcess = null;
        }
        
        
    }
    
    public class ControlToForm
    {
        public ControlToForm(
           System.Windows.Automation.ControlType controlType,
           string controlName,
           string controlAutomationId,
           TimeoutsAndDelays controlDelay)
        {
            this.ControlType = controlType;
            this.ControlName = controlName;
            this.ControlAutomationId = controlAutomationId;
            this.ControlDelayEn = controlDelay;
        }
        
        public System.Windows.Automation.ControlType ControlType { get; set; }
        public string ControlName { get; set; }
        public string ControlAutomationId { get; set; }
        public TimeoutsAndDelays ControlDelayEn { get; set; }
    }
}
