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
    using System;
    //using System.Diagnostics;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of PreferencesTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Preferences test")]
    public class PreferencesTestFixture
    {
        public PreferencesTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_AfterFailTurboTimeout_DefaultValue()
        {
            string timeoutInterval = "2000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Mode]::Profile = [UIAutomation.Modes]::Presentation; " +
                @"[UIAutomation.Preferences]::AfterFailTurboTimeout;",
                timeoutInterval);
        }

        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterSuccess_Window_1()
        {
            string timeoutInterval = "10000"; // default in unit tests
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                //@"[UIAutomation.Preferences]::Timeout; " +
                //@"sleep -seconds 1; " +
                @"$null = Get-UIAWindow -pn '" +
                MiddleLevelCode.TestFormProcess + 
                "'; " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterSuccess_Window_2()
        {
            string timeoutInterval = "10000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                @"$null = Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                "; " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterSuccess_Window_3()
        {
            string timeoutInterval = "10000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                @"$null = Get-UIAWindow -pid " + 
                @"(Get-Process -Name '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id; " +
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterFail_Window_ProcessName()
        {
            string processName = "no such process";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -pn '" + 
                processName + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterFail_Window_WindowTitle()
        {
            string windowTitle = "no such window";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -n '" + 
                windowTitle + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterFail_Window_ProcessId()
        {
            string processId = "-1";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -pid " + 
                processId + 
                ";} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Preferences")]
//        public void PreferencesTimeoutAfterFailWindow4_Process()
//        {
//            string timeoutInterval = "2000";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"[UIAutomation.Preferences]::Timeout = 4000; " +
//                @"$process = Get-Process -Name '" + 
//                MiddleLevelCode.TestFormProcess +
//                "'; " +
//                @"$null = Stop-Process -InputObject $process; " +
//                @"try{ $process | Get-UIAWindow;} catch {} " + 
//                @"[UIAutomation.Preferences]::Timeout;",
//                timeoutInterval);
//        }

        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterFailAndFurtherSuccess_Window_ProcessName()
        {
            string processName = "no such process";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -pn '" + 
                processName + 
                "';} catch {} " + 
                @"try{ $null = Get-UIAWindow -pn '" + 
                MiddleLevelCode.TestFormProcess + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterFailAndFurtherSuccess_Window_WindowTitle()
        {
            string windowTitle = "no such window";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -n '" + 
                windowTitle + 
                "';} catch {} " + 
                @"try{ $null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
        public void Preferences_TimeoutAfterFailAndFurtherSuccess_Window_ProcessId()
        {
            string processId = "-1";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -pid " + 
                processId + 
                ";} catch {} " + 
                @"try{ $null = Get-UIAWindow -pid (" + 
                @"Get-Process -Name '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id;} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
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
                @"try{ $null = Get-UIAWindow -n '" + 
                UIAutomationTestForms.Forms.WinFormsEmpty + 
                "' | Get-UIAButton -n '111' -IsCritical;} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                UIAutomation.Preferences.AfterFailTurboTimeout.ToString());
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Preferences")]
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
                @"try{ $null = Get-UIAWindow -n '" + 
                UIAutomationTestForms.Forms.WinFormsEmpty + 
                "' | Get-UIAButton -n '111' -IsCritical;} catch {} " + 
                @"$null = Get-UIAWindow -n '" + 
                UIAutomationTestForms.Forms.WinFormsEmpty +
                "' | Get-UIAButton -n '" + 
                name + 
                "'; " +
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
