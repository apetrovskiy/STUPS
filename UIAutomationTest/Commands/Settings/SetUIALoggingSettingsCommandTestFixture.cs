/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Settings
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUIALoggingSettingsCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Set-UIALoggingSettingsCommand test")]
    public class SetUIALoggingSettingsCommandTestFixture
    {
        public SetUIALoggingSettingsCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIALoggingSettings")]
        public void SetLog_On1()
        {
            string logResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIALoggingSettings -Log " + 
                "; " + 
                @"[UIAutomation.Preferences]::Log;",
                logResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIALoggingSettings")]
        public void SetLog_On2()
        {
            string log = "true";
            string logResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIALoggingSettings -Log:$" + 
                log +
                "; " + 
                @"[UIAutomation.Preferences]::Log;",
                logResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIALoggingSettings")]
        public void SetLog_Off()
        {
            string log = "false";
            string logResponse = "False";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIALoggingSettings -Log:$" + 
                log +
                "; " + 
                @"[UIAutomation.Preferences]::Log;",
                logResponse);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("Settings")]
        [Category("Slow")][Category("Set_UIALoggingSettings")]
        public void SetLogPath_Simple()
        {
            string logPath = @"C:\1\Log.txt";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UIALoggingSettings -Log " + 
                " -Path " + 
                logPath +
                "; " + 
                @"[UIAutomation.Preferences]::LogPath;",
                logPath);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
