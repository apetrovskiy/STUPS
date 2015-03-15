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
            this.UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_bare.ToString();
                DriverServerConstructorOptions.bare.ToString();
        }
        
        public FakeChromeDriver(string chromeDriverDirectory)
        {
            this.UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_path.ToString();
                DriverServerConstructorOptions.with_path.ToString();
        }
        
        public FakeChromeDriver(ChromeOptions options)
        {
            this.UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_options.ToString();
                DriverServerConstructorOptions.with_options.ToString();
        }
        
        public FakeChromeDriver(string chromeDriverDirectory, ChromeOptions options)
        {
            this.UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_path_and_options.ToString();
                DriverServerConstructorOptions.with_path_and_options.ToString();
        }
        
        public FakeChromeDriver(string chromeDriverDirectory, ChromeOptions options, TimeSpan commandTimeout)
        {
            this.UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_path_and_options_and_timespan.ToString();
                DriverServerConstructorOptions.with_path_and_options_and_timespan.ToString();
        }
        
        public FakeChromeDriver(DriverService service, ChromeOptions options, TimeSpan commandTimeout)
        {
            this.UnitTestReport =
                //ChromeDriverConstructorOptions.chrome_with_service_and_options_and_timespan.ToString();
                DriverServerConstructorOptions.with_service_and_options_and_timespan.ToString();
        }
    }
}
