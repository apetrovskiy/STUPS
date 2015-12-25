/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/29/2012
 * Time: 1:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers
{
    //using System.Diagnostics;

    /// <summary>
    /// Description of PreferencesTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    [MbUnit.Framework.Description("A Preferences test")]
    public class PreferencesTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks the default value of AfterFailTurboTimeout")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_AfterFailTurboTimeout_DefaultValue()
        {
            string timeoutInterval = "2000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Mode]::Profile = [UIAutomation.Modes]::Presentation; " +
                @"[UIAutomation.Preferences]::AfterFailTurboTimeout;",
                timeoutInterval);
        }

        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the custom timeout does not change after getting a windw by process name")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterSuccess_Window_1()
        {
            string timeoutInterval = "10000"; // default in unit tests
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                @"$null = Get-UiaWindow -pn '" +
                MiddleLevelCode.TestFormProcess + 
                "'; " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the custom timeout does not change after getting a windw by name")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterSuccess_Window_2()
        {
            string timeoutInterval = "10000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                @"$null = Get-UiaWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                "; " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the custom timeout does not change after getting a windw by process id")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterSuccess_Window_3()
        {
            string timeoutInterval = "10000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                @"$null = Get-UiaWindow -pid " + 
                @"(Get-Process -Name '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id; " +
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the timeout becomes short after a fail on getting a window by process name")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterFail_Window_ProcessName()
        {
            string processName = "no such process";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UiaWindow -pn '" + 
                processName + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the timeout becomes short after a fail on getting a window by name")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterFail_Window_WindowTitle()
        {
            string windowTitle = "no such window";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UiaWindow -n '" + 
                windowTitle + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the timeout becomes short after a fail on getting a window by process id")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterFail_Window_ProcessId()
        {
            string processId = "-1";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UiaWindow -pid " + 
                processId + 
                ";} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Description("TBD")]
//        [MbUnit.Framework.Category("WinForms")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
//        public void PreferencesTimeoutAfterFailWindow4_Process()
//        {
//            string timeoutInterval = "2000";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"[UIAutomation.Preferences]::Timeout = 4000; " +
//                @"$process = Get-Process -Name '" + 
//                MiddleLevelCode.TestFormProcess +
//                "'; " +
//                @"$null = Stop-Process -InputObject $process; " +
//                @"try{ $process | Get-UiaWindow;} catch {} " + 
//                @"[UIAutomation.Preferences]::Timeout;",
//                timeoutInterval);
//        }

        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the timeout returns its custom value after getting a window successfully by process name")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterFailAndFurtherSuccess_Window_ProcessName()
        {
            string processName = "no such process";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UiaWindow -pn '" + 
                processName + 
                "';} catch {} " + 
                @"try{ $null = Get-UiaWindow -pn '" + 
                MiddleLevelCode.TestFormProcess + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the timeout returns its custom value after getting a window successfully by name")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterFailAndFurtherSuccess_Window_WindowTitle()
        {
            string windowTitle = "no such window";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UiaWindow -n '" + 
                windowTitle + 
                "';} catch {} " + 
                @"try{ $null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the timeout returns its custom value after getting a window successfully by process id")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterFailAndFurtherSuccess_Window_ProcessId()
        {
            string processId = "-1";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UiaWindow -pid " + 
                processId + 
                ";} catch {} " + 
                @"try{ $null = Get-UiaWindow -pid (" + 
                @"Get-Process -Name '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id;} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the timeout gets the AfterFailTurboTimeout value after a fail")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterFail_Control()
        {
            string name = "Button333";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = " + 
                timeoutInterval +
                "; " +
                @"try{ $null = Get-UiaWindow -n '" + 
                UIAutomationTestForms.Forms.WinFormsEmpty + 
                "' | Get-UiaButton -n '111' -IsCritical;} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                UIAutomation.Preferences.AfterFailTurboTimeout.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("checks that the timeout gets back its value after a fail and further success")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Preferences")]
        public void Preferences_TimeoutAfterFailAndFurtherSuccess_Control()
        {
            string name = "Button333";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = " + 
                timeoutInterval +
                "; " +
                @"try{ $null = Get-UiaWindow -n '" + 
                UIAutomationTestForms.Forms.WinFormsEmpty + 
                "' | Get-UiaButton -n '111' -IsCritical;} catch {} " + 
                @"$null = Get-UiaWindow -n '" + 
                UIAutomationTestForms.Forms.WinFormsEmpty +
                "' | Get-UiaButton -n '" + 
                name + 
                "'; " +
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
