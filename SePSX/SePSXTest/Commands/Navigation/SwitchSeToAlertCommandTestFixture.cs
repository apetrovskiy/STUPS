/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/30/2012
 * Time: 12:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Alert
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SwitchSeToAlertCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class SwitchSeToAlertCommandTestFixture
    {
        public SwitchSeToAlertCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("Firefox")]
        public void FF_SwitchToAlert_alert_Firefox()
        {
            SwitchToAlert_alert(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_SwitchToAlert_alert_Chrome()
        {
            SwitchToAlert_alert(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_SwitchToAlert_alert_IE()
        {
            SwitchToAlert_alert(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        public void SwitchToAlert_alert(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL +
                @"' | Get-SeWebElement -XPath '" + 
                Settings.TestFile10Alerts1ElementButton01XPath + 
                @"' | Invoke-SeWebElementClick; " +
                //@"(Switch-SeToAlert).Text;",
                @"Switch-SeToAlert | Read-SeAlertText;",
                Settings.TestFile10Alerts1ElementButton01Text);
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("Firefox")]
        public void FF_SwitchToAlert_confirm_Firefox()
        {
            SwitchToAlert_confirm(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_SwitchToAlert_confirm_Chrome()
        {
            SwitchToAlert_confirm(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_SwitchToAlert_confirm_IE()
        {
            SwitchToAlert_confirm(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        public void SwitchToAlert_confirm(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL +
                @"' | Get-SeWebElement -XPath '" + 
                Settings.TestFile10Alerts1ElementButton02XPath + 
                @"' | Invoke-SeWebElementClick; " +
                //@"(Switch-SeToAlert).Text;",
                @"Switch-SeToAlert | Read-SeAlertText;",
                Settings.TestFile10Alerts1ElementButton02Text);
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("Firefox")]
        public void FF_SwitchToAlert_prompt_Firefox()
        {
            SwitchToAlert_prompt(
                Settings.DriverNameFirefox,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_SwitchToAlert_prompt_Chrome()
        {
            SwitchToAlert_prompt(
                Settings.DriverNameChrome,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        [Test] //[Test(Description="The navigation back test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Switch_SeToAlert")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_SwitchToAlert_prompt_IE()
        {
            SwitchToAlert_prompt(
                Settings.DriverNameInternetExplorer,
                MiddleLevelCode.GetURLFromPath(System.IO.Path.GetFullPath(Settings.TestFile10Alerts1)));
        }
        
        public void SwitchToAlert_prompt(string driverName, string URL)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                @"' | Enter-SeURL -URL '" +
                URL +
                @"' | Get-SeWebElement -XPath '" + 
                Settings.TestFile10Alerts1ElementButton03XPath + 
                @"' | Invoke-SeWebElementClick; " +
                //@"[string]$result = Switch-SeToAlert | Read-SeWebElementText; " +
                //@"Get-SeWebElement -Name OK | Invoke-SeWebElementClick;",
                @"Switch-SeToAlert | Read-SeAlertText;",
                Settings.TestFile10Alerts1ElementButton03Text);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Switch-SeToAlert | Invoke-SeAlertAccept;");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
