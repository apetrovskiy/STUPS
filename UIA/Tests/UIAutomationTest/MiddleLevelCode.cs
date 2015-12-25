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
    using System.Collections;
    using System.Diagnostics;
    
    /// <summary>
    /// Description of MiddleLevelCode.
    /// </summary>
    public static class MiddleLevelCode
    {
        public static string TestFormPath {
            get { return @"..\..\..\UIAutomationTestForms\bin\Release\UIAutomationTestForms.exe"; }
        }
        
        public static string TestFormProcess { get { return @"UIAutomationTestForms"; } }
        // public static string TestFormProcess { get { return @"nunit"; } }
        public static Process TestProcess { get; set; }
        public static ProcessStartInfo TestProcessStartInfo { get; set; }
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
            var formDelay = (int)formDelayEn;
            TestProcessStartInfo.Arguments = ((int)formCode).ToString();
            TestProcessStartInfo.CreateNoWindow = true;
            TestProcessStartInfo.UseShellExecute = false;
            
            TestProcessStartInfo.Arguments += " ";
            TestProcessStartInfo.Arguments += formDelay.ToString();

            Console.WriteLine(
                TestFormPath +
                " " +
                TestProcessStartInfo.Arguments);
            TestProcess = Process.Start(TestProcessStartInfo);
        }
        
        public static void StartProcessWithFormAndControl(
            UIAutomationTestForms.Forms formCode,
            TimeoutsAndDelays formDelayEn,
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            TimeoutsAndDelays controlDelayEn)
        {
            var controlToForm = 
                new ControlToForm(
                    controlType,
                    controlName,
                    controlAutomationId, 
                    controlDelayEn);
            
            // 20150322
            /*
            var arr = new System.Collections.ArrayList();
            arr.Add(controlToForm);
            
            StartProcessWithFormAndControl(
                formCode,
                formDelayEn,
                ((ControlToForm[])arr.ToArray(typeof(ControlToForm))));
            */
            var arr = new ArrayList {controlToForm};

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
            
            var controlToFormConverted = (ControlToForm[])controlToForm;
            
            TestProcessStartInfo.Arguments = ((int)formCode).ToString();
            TestProcessStartInfo.CreateNoWindow = true;
            TestProcessStartInfo.UseShellExecute = false;
            TestProcessStartInfo.LoadUserProfile = false;
            // form delay
            TestProcessStartInfo.Arguments += " ";
            TestProcessStartInfo.Arguments += formDelay.ToString();
            
            if (controlToFormConverted.Length > 0) {
                foreach (ControlToForm currentForm in controlToFormConverted)
                {
                    // control type
                    TestProcessStartInfo.Arguments += " ";
                    var controlType = 
                        currentForm.ControlType.ProgrammaticName.Substring(
                            currentForm.ControlType.ProgrammaticName.IndexOf(".") + 1);
                    TestProcessStartInfo.Arguments += controlType;
                    
                    // control delay
                    int controlDelay = (int)currentForm.ControlDelayEn;
                    TestProcessStartInfo.Arguments += " ";
                    TestProcessStartInfo.Arguments += controlDelay;
                    //controlToFormConverted[i].ControlDelayEn.ToString();
                    
                    // control name
                    TestProcessStartInfo.Arguments += " ";
                    TestProcessStartInfo.Arguments += currentForm.ControlName;
                    
                    // control AutomationId
                    TestProcessStartInfo.Arguments += " ";
                    TestProcessStartInfo.Arguments += currentForm.ControlAutomationId;
                }
            }

            Console.WriteLine(
                TestFormPath +
                " " +
                TestProcessStartInfo.Arguments);
            TestProcess = Process.Start(TestProcessStartInfo);
        }
        
        public static void PrepareRunspace()
        {
            CmdletUnitTest.TestRunspace.InitializeRunspace(Settings.RunspaceCommand);
            TestProcessStartInfo = new ProcessStartInfo();
            TestProcessStartInfo.FileName = TestFormPath;
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::OnSuccessDelay = 0); " + 
                @"[PSTestLib.PSCmdletBase]::SetCmdletParametersCheckingOn($false);");
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData()); " +
                @"rmo UIAutomation; " + 
                @"exit; ");
            CmdletUnitTest.TestRunspace.CloseRunspace();

            if (TestProcess != null)
            {
                try { TestProcess.CloseMainWindow(); } 
                catch { }
                try { TestProcess.Kill(); }
                catch { }
            }
            
            var processes = Process.GetProcessesByName(TestFormProcess);
            
            foreach (var process in processes)
            {
                try { process.CloseMainWindow(); } catch {}
                try { process.Kill(); } catch {}
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
            ControlType = controlType;
            ControlName = controlName;
            ControlAutomationId = controlAutomationId;
            ControlDelayEn = controlDelay;
        }
        
        public System.Windows.Automation.ControlType ControlType { get; set; }
        public string ControlName { get; set; }
        public string ControlAutomationId { get; set; }
        public TimeoutsAndDelays ControlDelayEn { get; set; }
    }
}
