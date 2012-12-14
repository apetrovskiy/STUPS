/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/8/2012
 * Time: 10:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    //using OpenQA.Selenium.Chrome;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using SePSX;
    
    /// <summary>
    /// Description of FakeWebDriver.
    /// </summary>
    public class FakeWebDriver : IWebDriver
    {
        public FakeWebDriver()
        {
        }
        
//        public FakeWebDriver()
//        {
//            this.UnitTestReport =
//                ChromeDriverConstructorOptions.chrome_bare.ToString();
//        }
//        
//        public FakeWebDriver(string chromeDriverDirectory)
//        {
//            this.UnitTestReport =
//                ChromeDriverConstructorOptions.chrome_with_path.ToString();
//        }
//        
//        public FakeWebDriver(ChromeOptions options)
//        {
//            this.UnitTestReport =
//                ChromeDriverConstructorOptions.chrome_with_options.ToString();
//        }
//        
//        public FakeWebDriver(string chromeDriverDirectory, ChromeOptions options)
//        {
//            this.UnitTestReport =
//                ChromeDriverConstructorOptions.chrome_with_path_and_options.ToString();
//        }
//        
//        public FakeWebDriver(string chromeDriverDirectory, ChromeOptions options, TimeSpan commandTimeout)
//        {
//            this.UnitTestReport =
//                ChromeDriverConstructorOptions.chrome_with_path_and_options_and_timespan.ToString();
//        }
//        
//        public FakeWebDriver(DriverService service, ChromeOptions options, TimeSpan commandTimeout)
//        {
//            this.UnitTestReport =
//                ChromeDriverConstructorOptions.chrome_with_service_and_options_and_timespan.ToString();
//        }
        
        public ReadOnlyCollection<string> WindowHandles
        {
            get { return this.WritableWindowHandles; }
            set{ }
        }
        public string CurrentWindowHandle { get; set; }
        
        private string pageSource;
        //public string PageSource { get; set; }
        public string PageSource { get { return this.pageSource; } set { this.pageSource = value; } }
        internal string _pageSource { get { return this.pageSource; } set { this.pageSource = value; } }
        //public string Title { get; set; }
        //
        //
        //public string Title { get { return "fake title"; } set {  } }
        private string title;
        public string Title { get { return this.title + "fake title: " + this.UnitTestReport; } set {  } }
        internal string _title { get { return this.title; } set { this.title = value; } }
        //
        //
        
        public string UnitTestReport = string.Empty;
        
        private string url;
        //public string Url { get; set; }
        public string Url { get { return this.url; } set { this.url = value; } }
        internal string _url { get { return this.url; } set { this.url = value; } }
        
        public void Dispose()
        {
            this.Dispose();
        }
        
        internal ReadOnlyCollection<IWebElement> Elements { get; set; }
        internal void SetElementsCollection(List<IWebElement> listOfElements)
        {
            this.Elements =
                new ReadOnlyCollection<IWebElement>(listOfElements);
        }
        
        public ReadOnlyCollection<IWebElement> FindElements(OpenQA.Selenium.By by)
        {
            return this.Elements;
        }
        
        public IWebElement FindElement(OpenQA.Selenium.By by)
        {
            return this.Elements[0];
        }
        
        public ITargetLocator SwitchTo()
        {
            ITargetLocator locator = null;
            
            
            return locator;
        }
        
        public INavigation Navigate()
        {
            INavigation navigation =
                new FakeNavigation(this);
            return navigation;
        }
        
        public IOptions Manage()
        {
            IOptions options = null;
            
            
            return options;
        }
        
        public void Close()
        {
        }
        
        public void Quit()
        {
            this.Dispose();
        }
        
        //internal IWebElement ElementToFind { get; set; }
        //internal ReadOnlyCollection<IWebElement> ElementsToFind { get; set; }
        internal ReadOnlyCollection<string> WritableWindowHandles { get; set; }

    }
}
