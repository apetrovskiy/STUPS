/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/23/2012
 * Time: 10:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXTest.Commands.Driver
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ReadSeWebDriverUrlCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class ReadSeWebDriverUrlCommandTestFixture
    {
        public ReadSeWebDriverUrlCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverUrl test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverUrl")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Driver_Url_Firefox()
        {
            string instanceName = "my i e ";
            Driver_Url(
                Settings.DriverNameFirefox, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverUrl test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverUrl")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Driver_Url_Chrome()
        {
            string instanceName = "my chrome";
            Driver_Url(
                Settings.DriverNameChrome, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverUrl test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverUrl")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Driver_Url_InternetExplorer()
        {
            string instanceName = "my i e ";
            Driver_Url(
                Settings.DriverNameInternetExplorer, 
                instanceName);
        }
        
        private void Driver_Url(string driverName, string instanceName)
        {
            CmdletUnitTest.TestRunspace.RunAndCompareTwoOutputs(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                "' -InstanceName '" +
                instanceName +
                @"' | Read-SeWebDriverUrl; " +
                @"[SePSX.CurrentData]::CurrentWebDriver.Url;",
                (new List<int>(0)),
                (new List<int>(1)));
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverUrl test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverUrl")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Driver_Url_Firefox_2()
        {
            string instanceName = "my i e ";
            Driver_Url_2(
                Settings.DriverNameFirefox, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverUrl test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverUrl")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Driver_Url_Chrome_2()
        {
            string instanceName = "my chrome";
            Driver_Url_2(
                Settings.DriverNameChrome, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverUrl test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverUrl")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Driver_Url_InternetExplorer_2()
        {
            string instanceName = "my i e ";
            Driver_Url_2(
                Settings.DriverNameInternetExplorer, 
                instanceName);
        }
        
        private void Driver_Url_2(string driverName, string instanceName)
        {
            CmdletUnitTest.TestRunspace.RunAndCompareTwoOutputs(
                @"$drivers = Start-SeWebDriver -DriverName '" + 
                driverName + 
                "' -Count 3 -InstanceName '" +
                instanceName +
                @"'; " + 
                @"$drivers |Read-SeWebDriverUrl; " +
                @"$drivers | %{ $_.Url;}",
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
