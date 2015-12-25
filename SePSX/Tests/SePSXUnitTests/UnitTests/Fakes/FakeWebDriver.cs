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
    using OpenQA.Selenium.Remote;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

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
            get { return WritableWindowHandles; }
            set{ }
        }
        public string CurrentWindowHandle { get; set; }
        
        private string pageSource;
        //public string PageSource { get; set; }
        public string PageSource { get { return pageSource; } set { pageSource = value; } }
        internal string _pageSource { get { return pageSource; } set { pageSource = value; } }
        //public string Title { get; set; }
        //
        //
        //public string Title { get { return "fake title"; } set {  } }
        private string title;
        public string Title { get { return title + "fake title: " + UnitTestReport; } set {  } }
        internal string _title { get { return title; } set { title = value; } }
        //
        //
        
        public string UnitTestReport = string.Empty;
        
        private string url;
        //public string Url { get; set; }
        public string Url { get {

Console.WriteLine("!!!!!!!!!!!!URL!!!!!!!!!!!!!!!!!!!!!");
PrintOutCollection();

                return url; } set { url = value; } }
        internal string _url { get { return url; } set { url = value; } }
        
        public void Dispose()
        {
            Dispose();
        }
        
        internal ReadOnlyCollection<IWebElement> Elements { get; set; }
        internal void SetElementsCollection(List<IWebElement> listOfElements)
        {
            
Console.WriteLine("!!!!!!!!!!!!SetElementsCollection!!!!!!!!!!!!!!!!!!!!!");
Console.WriteLine(listOfElements.Count.ToString());
Console.WriteLine(listOfElements[0].GetType().Name);
Console.WriteLine(((FakeRemoteWebElement)listOfElements[0]).TagName);
            
            
            Elements =
                new ReadOnlyCollection<IWebElement>(listOfElements);
            
            TagNameResponse =
                ((FakeRemoteWebElement)Elements[0]).TagName;
            TextResponse =
                ((FakeRemoteWebElement)Elements[0]).Text;
            EnabledResponse =
                ((FakeRemoteWebElement)Elements[0]).Enabled;
            DisplayedResponse =
                ((FakeRemoteWebElement)Elements[0]).Displayed;
            SelectedResponse =
                ((FakeRemoteWebElement)Elements[0]).Selected;
            
            
//if (null == this.Elements) {
//    Console.WriteLine("null == this.Elements");
//} else {
//    Console.WriteLine("null != this.Elements");
//    Console.WriteLine("Count = " + this.Elements.Count.ToString());
//}
//Console.WriteLine("WebDriver: set elements collection: " + this.Elements.Count.ToString());
//Console.WriteLine(this.Elements[0].GetType().Name);
////Console.WriteLine(this.Elements[0].Text);
//Console.WriteLine("text = " + ((FakeRemoteWebElement)this.Elements[0]).Text);
////Console.WriteLine(this.Elements[0].TagName);
//Console.WriteLine("tagName = " + ((FakeRemoteWebElement)this.Elements[0]).TagName);
//Console.WriteLine(this.Elements[1].GetType().Name);
////Console.WriteLine(this.Elements[1].Text);
//Console.WriteLine("text = " + ((FakeRemoteWebElement)this.Elements[1]).Text);
////Console.WriteLine(this.Elements[1].TagName);
//Console.WriteLine("tagName = " + ((FakeRemoteWebElement)this.Elements[1]).TagName);

Console.WriteLine("!!!!!!!!!!!!SetElementsCollection!!!!!!!!!!!!!!!!!!!!!");
PrintOutCollection();

        }
        
        
internal void PrintOutCollection()
{
    foreach (var element in Elements) {
        try {
            Console.WriteLine("PrintOutCollection: type = " + element.GetType().Name);
            Console.WriteLine("PrintOutCollection: TagName = " + ((FakeRemoteWebElement)element).TagName);
            Console.WriteLine("PrintOutCollection: Text = " + ((FakeRemoteWebElement)element).Text);
        }
        catch (Exception ePrintOut) {
            Console.WriteLine(ePrintOut.Message);
            Console.WriteLine(ePrintOut.GetType().Name);
        }
    }
}
        
        
        
        
        
        
        internal Response InternalExecute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            //return this.Execute(driverCommandToExecute, parameters);
            
            Response resp =
                new Response();
            
            if ("getElementTagName" == driverCommandToExecute) {
                resp.Value = TagNameResponse;
            }
            if ("getElementText" == driverCommandToExecute) {
                resp.Value = TextResponse;
            }
            if ("isElementEnabled" == driverCommandToExecute) {
                resp.Value = EnabledResponse;
            }
            if ("isElementSelected" == driverCommandToExecute) {
                resp.Value = SelectedResponse;
            }
            if ("isElementDisplayed" == driverCommandToExecute) {
                resp.Value = DisplayedResponse;
            }
//            if ("" == driverCommandToExecute) {
//                
//            }
//            if ("" == driverCommandToExecute) {
//                
//            }
//            if ("" == driverCommandToExecute) {
//                
//            }
//            if ("" == driverCommandToExecute) {
//                
//            }
//            if ("" == driverCommandToExecute) {
//                
//            }

            return resp;
        }
        
        internal string TagNameResponse { get; set; }
        internal string TextResponse { get; set; }
        internal bool EnabledResponse { get; set; }
        internal bool DisplayedResponse { get; set; }
        internal bool SelectedResponse { get; set; }
        
        
        
        
        
        
        
        
        
        
        
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Elements;
        }
        
        public IWebElement FindElement(By by)
        {
            return Elements[0];
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
            Dispose();
        }
        
        //internal IWebElement ElementToFind { get; set; }
        //internal ReadOnlyCollection<IWebElement> ElementsToFind { get; set; }
        internal ReadOnlyCollection<string> WritableWindowHandles { get; set; }

    }
}
