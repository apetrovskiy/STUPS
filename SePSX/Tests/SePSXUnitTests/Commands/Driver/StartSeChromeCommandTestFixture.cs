/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/27/2012
 * Time: 3:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver
{
    using SePSX;
    using OpenQA.Selenium;
    using SePSX.Commands;
    using MbUnit.Framework;
    using Autofac;

//    using Moq;
//    using Ninject;
    
    /// <summary>
    /// Description of StartSeChromeCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class StartSeChromeCommandTestFixture
    {
        public StartSeChromeCommandTestFixture()
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
        
        //private IWebDriver startChrome(string directoryPath, bool useOptions, bool useService, int milliSeconds)
        private IWebDriver startChrome(string directoryPath, bool useOptions, int milliSeconds)
        {
            StartSeChromeCommand cmdlet =
                //new StartSeChromeCommandTestFixture();
                WebDriverFactory.Container.Resolve<StartSeChromeCommand>();

            if (string.Empty != directoryPath) {

                cmdlet.DriverDirectoryPath = directoryPath;
            }
            if (true == useOptions) {

                //cmdlet.Options = new FakeOptions();
                //cmdlet.Options = new ChromeOptions();
                //cmdlet.ChromeOptions = WebDriverFactory.GetChromeOptions();
                cmdlet.ChromeOptions = 
                    // resolve ChromeOptions
                    WebDriverFactory.Container.Resolve<OpenQA.Selenium.Chrome.ChromeOptions>();
            }

            if (0 != milliSeconds) {

                cmdlet.Timeout = milliSeconds;
            }

            SeStartChromeCommand command =
                new SeStartChromeCommand(cmdlet);
            command.Execute();
            
            return ((IWebDriver)PSTestLib.UnitTestOutput.LastOutput[0]);
        }
        
        [Test]
        [Category("Fast")]
        public void StartChrome_bare()
        {
            IWebDriver result =
                //startChrome(string.Empty, false, false, 0);
                startChrome(string.Empty, false, 0);
            
            Assert.AreEqual(
                //ChromeDriverConstructorOptions.chrome_bare.ToString(),
                //DriverServerConstructorOptions.bare.ToString(),
                DriverServerConstructorOptions.WithServiceAndOptionsAndTimespan.ToString(),
                ((FakeChromeDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartChrome_with_path()
        {
            IWebDriver result =
                //startChrome(@"C:\", false, false, 0);
                startChrome(System.IO.Path.GetDirectoryName(typeof(StartSeChromeCommand).Assembly.Location), false, 0);
            
            Assert.AreEqual(
                //ChromeDriverConstructorOptions.chrome_with_path.ToString(),
                //DriverServerConstructorOptions.with_path.ToString(),
                DriverServerConstructorOptions.WithServiceAndOptionsAndTimespan.ToString(),
                ((FakeChromeDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartChrome_with_options()
        {
            IWebDriver result =
                //startChrome(string.Empty, true, false, 0);
                startChrome(string.Empty, true, 0);
            
            Assert.AreEqual(
                //ChromeDriverConstructorOptions.chrome_with_options.ToString(),
                //DriverServerConstructorOptions.with_options.ToString(),
                DriverServerConstructorOptions.WithServiceAndOptionsAndTimespan.ToString(),
                ((FakeChromeDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartChrome_with_path_and_options()
        {
            IWebDriver result =
                //startChrome(@"C:\", true, false, 0);
                startChrome(System.IO.Path.GetDirectoryName(typeof(StartSeChromeCommand).Assembly.Location), true, 0);
            
            Assert.AreEqual(
                //ChromeDriverConstructorOptions.chrome_with_path_and_options.ToString(),
                //DriverServerConstructorOptions.with_path_and_options.ToString(),
                DriverServerConstructorOptions.WithServiceAndOptionsAndTimespan.ToString(),
                ((FakeChromeDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartChrome_with_path_and_options_and_timespan()
        {
            IWebDriver result =
                //startChrome(@"C:\", true, false, 120000);
                startChrome(System.IO.Path.GetDirectoryName(typeof(StartSeChromeCommand).Assembly.Location), true, 120000);
            
            Assert.AreEqual(
                //ChromeDriverConstructorOptions.chrome_with_path_and_options_and_timespan.ToString(),
                //DriverServerConstructorOptions.with_path_and_options_and_timespan.ToString(),
                DriverServerConstructorOptions.WithServiceAndOptionsAndTimespan.ToString(),
                ((FakeChromeDriver)result).UnitTestReport);
        }
        
        [Test]
        [Category("Fast")]
        public void StartChrome_with_service_and_options_and_timespan()
        {
            IWebDriver result =
                //startChrome(string.Empty, true, true, 180000);
                startChrome(string.Empty, true, 180000);
            
            Assert.AreEqual(
                //ChromeDriverConstructorOptions.chrome_with_service_and_options_and_timespan.ToString(),
                DriverServerConstructorOptions.WithServiceAndOptionsAndTimespan.ToString(),
                ((FakeChromeDriver)result).UnitTestReport);
        }
    }
}
