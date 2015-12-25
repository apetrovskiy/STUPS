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
    /// <summary>
    /// Description of SetUiaLoggingSettingsCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Set-UiaLoggingSettingsCommand test")]
    public class SetUiaLoggingSettingsCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaLoggingSettings")]
        public void SetLog_On1()
        {
            string logResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaLoggingSettings -Log " + 
                "; " + 
                @"[UIAutomation.Preferences]::Log;",
                logResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaLoggingSettings")]
        public void SetLog_On2()
        {
            string log = "true";
            string logResponse = "True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaLoggingSettings -Log:$" + 
                log +
                "; " + 
                @"[UIAutomation.Preferences]::Log;",
                logResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaLoggingSettings")]
        public void SetLog_Off()
        {
            string log = "false";
            string logResponse = "False";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaLoggingSettings -Log:$" + 
                log +
                "; " + 
                @"[UIAutomation.Preferences]::Log;",
                logResponse);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Settings")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Set_UiaLoggingSettings")]
        public void SetLogPath_Simple()
        {
            string logPath = @"C:\1\Log.txt";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Set-UiaLoggingSettings -Log " + 
                " -Path " + 
                logPath +
                "; " + 
                @"[UIAutomation.Preferences]::LogPath;",
                logPath);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
