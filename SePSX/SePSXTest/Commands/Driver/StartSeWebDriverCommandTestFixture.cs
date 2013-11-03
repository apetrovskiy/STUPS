/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26.07.2012
 * Time: 9:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Driver
{
    using System;
    using MbUnit.Framework;
    
	/// <summary>
	/// Description of StartSeWebDriverCommandTestFixture.
	/// </summary>
	[TestFixture] // [TestFixture(Description=" test")]
	public class StartSeWebDriverCommandTestFixture
	{
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("Firefox")]
        public void FF_TestPrm_DriverName_Firefox()
        {
            TestPrm_DriverName(Settings.DriverNameFirefox, Settings.ObjectNameFirefox);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Start-SeWebDriver -DriverName '" + 
//                Settings.DriverNameFirefox + 
//                "'; " +
//                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
//                Settings.ObjectNameFirefox);
        }
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("Firefox")]
        public void FF_TestPrm_DriverName_FF()
        {
            TestPrm_DriverName(Settings.DriverNameFF, Settings.ObjectNameFirefox);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Start-SeWebDriver -DriverName '" + 
//                Settings.DriverNameFF + 
//                "'; " +
//                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
//                Settings.ObjectNameFirefox);
        }
        
        private void TestPrm_DriverName(string driverName, string answer)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                "'; " +
                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
                answer);
        }
        
        [Test] //[Test(Description="The default parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeFirefox")]
        [Category("Firefox")]
        public void FF_TestPrm_Firefox()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeFirefox; " +
                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
                Settings.ObjectNameFirefox);
        }
        
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("Chrome")]
        public void Ch_TestPrm_DriverName_Chrome()
        {
            TestPrm_DriverName(Settings.DriverNameChrome, Settings.ObjectNameChrome);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Start-SeWebDriver -DriverName '" + 
//                Settings.DriverNameChrome + 
//                "'; " +
//                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
//                Settings.ObjectNameChrome);
        }
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("Chrome")]
        public void Ch_TestPrm_DriverName_Ch()
        {
            TestPrm_DriverName(Settings.DriverNameCh, Settings.ObjectNameChrome);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Start-SeWebDriver -DriverName '" + 
//                Settings.DriverNameCh + 
//                "'; " +
//                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
//                Settings.ObjectNameChrome);
        }
        
        [Test] //[Test(Description="The default parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeChrome")]
        [Category("Chrome")]
        public void Ch_TestPrm_Chrome()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeChrome; " +
                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
                Settings.ObjectNameChrome);
        }
        
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("InternetExplorer")]
        public void IE_TestPrm_DriverName_InternetExplorer()
        {
            TestPrm_DriverName(Settings.DriverNameInternetExplorer, Settings.ObjectNameInternetExplorer);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Start-SeWebDriver -DriverName '" + 
//                Settings.DriverNameInternetExplorer + 
//                "'; " +
//                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
//                Settings.ObjectNameInternetExplorer);
        }
        
        [Test] //[Test(Description="The -DriverName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("InternetExplorer")]
        public void IE_TestPrm_DriverName_IE()
        {
            TestPrm_DriverName(Settings.DriverNameIE, Settings.ObjectNameInternetExplorer);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Start-SeWebDriver -DriverName '" + 
//                Settings.DriverNameIE + 
//                "'; " +
//                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
//                Settings.ObjectNameInternetExplorer);
        }
        
        [Test] //[Test(Description="The default parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeInternetExplorer")]
        [Category("InternetExplorer")]
        public void IE_TestPrm_InternetExplorer32()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeInternetExplorer32; " +
                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
                Settings.ObjectNameInternetExplorer);
        }
        
        [Test] //[Test(Description="The default parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeInternetExplorer")]
        [Category("InternetExplorer")]
        public void IE_TestPrm_InternetExplorer64()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeInternetExplorer64; " +
                @"[SePSX.CurrentData]::Drivers[$([SePSX.CurrentData]::Drivers.Keys)].GetType().Name;",
                Settings.ObjectNameInternetExplorer);
        }
        

        [Test] //[Test(Description="The -InstanceName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("Firefox")]
        public void FF_TestPrm_InstanceName_Firefox()
        {
            string instanceName = "my firefox";
            TestPrm_InstanceName(Settings.DriverNameFirefox, instanceName, Settings.ObjectNameFirefox);
        }
        
        [Test] //[Test(Description="The -InstanceName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("Chrome")]
        public void Ch_TestPrm_InstanceName_Chrome()
        {
            string instanceName = "my chrome";
            TestPrm_InstanceName(Settings.DriverNameChrome, instanceName, Settings.ObjectNameChrome);
        }
        
        [Test] //[Test(Description="The -InstanceName parameter test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Start_SeWebDriver")]
        [Category("InternetExplorer")]
        public void IE_TestPrm_InstanceName_InternetExplorer()
        {
            string instanceName = "my i e ";
            TestPrm_InstanceName(Settings.DriverNameInternetExplorer, instanceName, Settings.ObjectNameInternetExplorer);
        }
        
        private void TestPrm_InstanceName(string driverName, string instanceName, string answer)
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Start-SeWebDriver -DriverName '" + 
                driverName + 
                "' -InstanceName '" +
                instanceName +
                @"'; " +
                @"[SePSX.CurrentData]::Drivers['" +
                instanceName +
                @"'].GetType().Name;",
                answer);
        }

        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
