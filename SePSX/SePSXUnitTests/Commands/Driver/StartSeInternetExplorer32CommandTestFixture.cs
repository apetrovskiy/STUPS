/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 4:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver
{
    using System;
    using SePSX;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using SePSX.Commands;
    using MbUnit.Framework;
//    using Moq;
//    using Ninject;
    using Autofac;
    
    /// <summary>
    /// Description of StartSeInternetExplorer32CommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeInternetExplorer32CommandTestFixture
    {
        public StartSeInternetExplorer32CommandTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        //private IWebDriver startIE(string directoryPath, bool useOptions, bool useService, int milliSeconds)
        private IWebDriver startIE(string directoryPath, bool useOptions, int milliSeconds)
        {
            StartSeInternetExplorer32Command cmdlet =
                //new StartSeInternetExplorer32CommandTestFixture();
                WebDriverFactory.Container.Resolve<StartSeInternetExplorer32Command>();

            if (string.Empty != directoryPath) {

                cmdlet.DriverDirectoryPath = directoryPath;
            }
            if (true == useOptions) {

                //cmdlet.Options = new FakeOptions();
                //cmdlet.Options = new ChromeOptions();
                //cmdlet.IEOptions = WebDriverFactory.GetIEOptions();
                cmdlet.IEOptions =
                    WebDriverFactory.Container.Resolve<OpenQA.Selenium.IE.InternetExplorerOptions>();
            }
//            if (true == useService) {
//
//                cmdlet.AsService = true;
//            } else {
//
//                cmdlet.AsService = false;
//            }
            if (0 != milliSeconds) {

                cmdlet.Timeout = milliSeconds;
            }

            SeStartInternetExplorer32Command command =
                new SeStartInternetExplorer32Command(cmdlet);
            command.Execute();
            
            //return ((IWebDriver)CommonCmdletBase.UnitTestOutput[0]);
            return ((IWebDriver)PSTestLib.UnitTestOutput.LastOutput[0]);
        }
        
        [Test]
        [Category("Fast")]
        public void StartIE_bare()
        {
            IWebDriver result =
                //startIE(string.Empty, false, false, 0);
                startIE(string.Empty, false, 0);
            
            Assert.AreEqual(
                //IEDriverConstructorOptions.ie_bare.ToString(),
                //DriverServerConstructorOptions.bare.ToString(),
                DriverServerConstructorOptions.with_service_and_options_and_timespan.ToString(),
                ((FakeIEDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartIE_with_path()
        {
            IWebDriver result =
                //startIE(@"C:\", false, false, 0);
                startIE(System.IO.Path.GetDirectoryName(typeof(StartSeInternetExplorer32Command).Assembly.Location) + "\\32\\", false, 0);
            
            Assert.AreEqual(
                //IEDriverConstructorOptions.ie_with_path.ToString(),
                //DriverServerConstructorOptions.with_path.ToString(),
                DriverServerConstructorOptions.with_service_and_options_and_timespan.ToString(),
                ((FakeIEDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartIE_with_options()
        {
            IWebDriver result =
                //startIE(string.Empty, true, false, 0);
                startIE(string.Empty, true, 0);
            
            Assert.AreEqual(
                //IEDriverConstructorOptions.ie_with_options.ToString(),
                //DriverServerConstructorOptions.with_options.ToString(),
                DriverServerConstructorOptions.with_service_and_options_and_timespan.ToString(),
                ((FakeIEDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartIE_with_path_and_options()
        {
            IWebDriver result =
                //startIE(@"C:\", true, false, 0);
                startIE(System.IO.Path.GetDirectoryName(typeof(StartSeInternetExplorer32Command).Assembly.Location) + "\\32\\", true, 0);
            
            Assert.AreEqual(
                //IEDriverConstructorOptions.ie_with_path_and_options.ToString(),
                //DriverServerConstructorOptions.with_path_and_options.ToString(),
                DriverServerConstructorOptions.with_service_and_options_and_timespan.ToString(),
                ((FakeIEDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartIE_with_path_and_options_and_timespan()
        {
            IWebDriver result =
                //startIE(@"C:\", true, false, 120000);
                startIE(System.IO.Path.GetDirectoryName(typeof(StartSeInternetExplorer32Command).Assembly.Location) + "\\32\\", true, 120000);
            
            Assert.AreEqual(
                //IEDriverConstructorOptions.ie_with_path_and_options_and_timespan.ToString(),
                //DriverServerConstructorOptions.with_path_and_options_and_timespan.ToString(),
                DriverServerConstructorOptions.with_service_and_options_and_timespan.ToString(),
                ((FakeIEDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartIE_with_service_and_options_and_timespan()
        {
            IWebDriver result =
                //startIE(string.Empty, true, true, 180000);
                startIE(string.Empty, true, 180000);
            
            Assert.AreEqual(
                //IEDriverConstructorOptions.ie_with_service_and_options_and_timespan.ToString(),
                DriverServerConstructorOptions.with_service_and_options_and_timespan.ToString(),
                ((FakeIEDriver)result).UnitTestReport);
        }
    }
}
