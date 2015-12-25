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
    using OpenQA.Selenium.IE;
    using SePSX;
    
    /// <summary>
    /// Description of FakeIEDriver.
    /// </summary>
    public class FakeIEDriver : FakeWebDriver
    {
        public FakeIEDriver()
        {
Console.WriteLine("bare2");
            UnitTestReport =
                //IEDriverConstructorOptions.ie_bare.ToString();
                DriverServerConstructorOptions.Bare.ToString();
        }
        
        public FakeIEDriver(string internetExplorerDriverServerDirectory)
        {
Console.WriteLine("dir2");
            UnitTestReport =
                //IEDriverConstructorOptions.ie_with_path.ToString();
                DriverServerConstructorOptions.WithPath.ToString();
        }
        
        public FakeIEDriver(InternetExplorerOptions options)
        {
Console.WriteLine("opt2");
            UnitTestReport =
                //IEDriverConstructorOptions.ie_with_options.ToString();
                DriverServerConstructorOptions.WithOptions.ToString();
        }
        
        public FakeIEDriver(string internetExplorerDriverServerDirectory, InternetExplorerOptions options)
        {
Console.WriteLine("dir opt2");
            UnitTestReport =
                //IEDriverConstructorOptions.ie_with_path_and_options.ToString();
                DriverServerConstructorOptions.WithPathAndOptions.ToString();
        }
        
        public FakeIEDriver(string internetExplorerDriverServerDirectory, InternetExplorerOptions options, TimeSpan commandTimeout)
        {
Console.WriteLine("dir opt span2");
            UnitTestReport =
                //IEDriverConstructorOptions.ie_with_path_and_options_and_timespan.ToString();
                DriverServerConstructorOptions.WithPathAndOptionsAndTimespan.ToString();
        }
        
        public FakeIEDriver(DriverService service, InternetExplorerOptions options, TimeSpan commandTimeout)
        {
Console.WriteLine("svc opt span2");
            UnitTestReport =
                //IEDriverConstructorOptions.ie_with_service_and_options_and_timespan.ToString();
                DriverServerConstructorOptions.WithServiceAndOptionsAndTimespan.ToString();
        }
    }
}
