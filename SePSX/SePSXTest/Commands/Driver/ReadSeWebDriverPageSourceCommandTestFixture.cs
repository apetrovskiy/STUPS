/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Driver
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ReadSeWebDriverPageSourceCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class ReadSeWebDriverPageSourceCommandTestFixture
    {
        public ReadSeWebDriverPageSourceCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverPageSource test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Read_SeWebDriverPageSource")]
        [Category("Firefox")]
        public void FF_Driver_PageSource_Firefox()
        {
            string instanceName = "my i e ";
            Driver_PageSource(
                Settings.DriverNameFirefox, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverPageSource test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Read_SeWebDriverPageSource")]
        [Category("Chrome")]
        public void Ch_Driver_PageSource_Chrome()
        {
            string instanceName = "my chrome";
            Driver_PageSource(
                Settings.DriverNameChrome, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverPageSource test")]
        [Category("Slow")]
        [Category("WebDriver")]
        [Category("Read_SeWebDriverPageSource")]
        [Category("InternetExplorer")]
        public void IE_Driver_PageSource_InternetExplorer()
        {
            string instanceName = "my i e ";
            Driver_PageSource(
                Settings.DriverNameInternetExplorer, 
                instanceName);
        }
        
        private void Driver_PageSource(string driverName, string instanceName)
        {
            CmdletUnitTest.TestRunspace.RunAndCompareTwoOutputs(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                "' -InstanceName '" +
                instanceName +
                @"' | Read-SeWebDriverPageSource; " +
                @"[SePSX.CurrentData]::CurrentWebDriver.PageSource;",
                (new List<int>(0)),
                (new List<int>(1)));
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverPageSource test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverPageSource")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Driver_PageSource_Firefox_2()
        {
            string instanceName = "my i e ";
            Driver_PageSource_2(
                Settings.DriverNameFirefox, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverPageSource test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverPageSource")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Driver_PageSource_Chrome_2()
        {
            string instanceName = "my chrome";
            Driver_PageSource_2(
                Settings.DriverNameChrome, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverPageSource test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverPageSource")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Driver_PageSource_InternetExplorer_2()
        {
            string instanceName = "my i e ";
            Driver_PageSource_2(
                Settings.DriverNameInternetExplorer, 
                instanceName);
        }
        
        private void Driver_PageSource_2(string driverName, string instanceName)
        {
            CmdletUnitTest.TestRunspace.RunAndCompareTwoOutputs(
                @"$drivers = Start-SeWebDriver -DriverName '" + 
                driverName + 
                "' -Count 3 -InstanceName '" +
                instanceName +
                @"'; " + 
                @"$drivers |Read-SeWebDriverPageSource; " +
                @"$drivers | %{ $_.PageSource;}",
                new List<int>(){0,1,2},
                new List<int>(){3,4,5});
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
