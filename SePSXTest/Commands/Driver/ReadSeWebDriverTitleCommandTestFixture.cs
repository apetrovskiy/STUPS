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
    
    //using System.Collections;
    //using System.Collections.ObjectModel;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of ReadSeWebDriverTitleCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class ReadSeWebDriverTitleCommandTestFixture
    {
        public ReadSeWebDriverTitleCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverTitle test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverTitle")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Driver_Title_Firefox()
        {
            string instanceName = "my i e ";
            Driver_Title(
                Settings.DriverNameFirefox, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverTitle test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverTitle")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Driver_Title_Chrome()
        {
            string instanceName = "my chrome";
            Driver_Title(
                Settings.DriverNameChrome, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverTitle test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverTitle")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Driver_Title_InternetExplorer()
        {
            string instanceName = "my i e ";
            Driver_Title(
                Settings.DriverNameInternetExplorer, 
                instanceName);
        }
        
        private void Driver_Title(string driverName, string instanceName)
        {
            CmdletUnitTest.TestRunspace.RunAndCompareTwoOutputs(
                @"Start-SeWebDriver -DriverName '" + 
                driverName + 
                "' -InstanceName '" +
                instanceName +
                @"' | Read-SeWebDriverTitle; " +
                @"[SePSX.CurrentData]::CurrentWebDriver.Title;",
                (new List<int>(0)),
                (new List<int>(1)));
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverTitle test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverTitle")]
        [Category("Slow")][Category("Firefox")]
        public void FF_Driver_Title_Firefox_2()
        {
            string instanceName = "my i e ";
            Driver_Title_2(
                Settings.DriverNameFirefox, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverTitle test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverTitle")]
        [Category("Slow")][Category("Chrome")]
        public void Ch_Driver_Title_Chrome_2()
        {
            string instanceName = "my chrome";
            Driver_Title_2(
                Settings.DriverNameChrome, 
                instanceName);
        }
        
        [Test] //[Test(Description="The Read-SeWebDriverTitle test")]
        [Category("Slow")][Category("WebDriver")]
        [Category("Slow")][Category("Read_SeWebDriverTitle")]
        [Category("Slow")][Category("InternetExplorer")]
        public void IE_Driver_Title_InternetExplorer_2()
        {
            string instanceName = "my i e ";
            Driver_Title_2(
                Settings.DriverNameInternetExplorer, 
                instanceName);
        }
        
        private void Driver_Title_2(string driverName, string instanceName)
        {
            CmdletUnitTest.TestRunspace.RunAndCompareTwoOutputs(
                @"$drivers = Start-SeWebDriver -DriverName '" + 
                driverName + 
                "' -Count 3 -InstanceName '" +
                instanceName +
                @"'; " + 
                @"$drivers |Read-SeWebDriverTitle; " +
                @"$drivers | %{ $_.Title;}",
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
