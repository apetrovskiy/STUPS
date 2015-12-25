/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 3:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SePSX;
    
    /// <summary>
    /// Description of FakeChromeDriver.
    /// </summary>
    public class FakeChromeDriver : FakeWebDriver
    {
        public FakeChromeDriver()
        {
            UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_bare.ToString();
                DriverServerConstructorOptions.Bare.ToString();
        }
        
        public FakeChromeDriver(string chromeDriverDirectory)
        {
            UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_path.ToString();
                DriverServerConstructorOptions.WithPath.ToString();
        }
        
        public FakeChromeDriver(ChromeOptions options)
        {
            UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_options.ToString();
                DriverServerConstructorOptions.WithOptions.ToString();
        }
        
        public FakeChromeDriver(string chromeDriverDirectory, ChromeOptions options)
        {
            UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_path_and_options.ToString();
                DriverServerConstructorOptions.WithPathAndOptions.ToString();
        }
        
        public FakeChromeDriver(string chromeDriverDirectory, ChromeOptions options, TimeSpan commandTimeout)
        {
            UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_path_and_options_and_timespan.ToString();
                DriverServerConstructorOptions.WithPathAndOptionsAndTimespan.ToString();
        }
        
        public FakeChromeDriver(DriverService service, ChromeOptions options, TimeSpan commandTimeout)
        {
            UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_service_and_options_and_timespan.ToString();
                DriverServerConstructorOptions.WithServiceAndOptionsAndTimespan.ToString();
        }
    }
}
