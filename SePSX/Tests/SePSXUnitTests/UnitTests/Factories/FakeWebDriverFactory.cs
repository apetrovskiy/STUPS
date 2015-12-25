/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/23/2012
 * Time: 2:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    using Moq;
    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of FakeWebDriverFactory.
    /// </summary>
    public class FakeWebDriverFactory //: IWebDriverFactory
    {
        public FakeWebDriverFactory()
        {
        }

        [ThreadStatic]
        private static Random generator = new Random();
        
        #region IWebDriver
        private static Mock<IWebDriver> _getWebDriverMock()
        {
            var byMock = new Mock<By>().As<FakeBy>();
            var webDriverMock = new Mock<FakeWebDriver>().As<IWebDriver>();
            
            #region IWebDriver
            /*public ReadOnlyCollection<string> WindowHandles
            public string CurrentWindowHandle { get; set; }
            public string PageSource { get; set; }
            public string Title { get { return "fake title: " + this.UnitTestReport; } set {  } }
            public string Url { get; set; }
            public void Dispose()
            public ReadOnlyCollection<IWebElement> FindElements(OpenQA.Selenium.By by)
            public IWebElement FindElement(OpenQA.Selenium.By by)
            public ITargetLocator SwitchTo()
            public INavigation Navigate()
            public IOptions Manage()
            public void Close()
            public void Quit()*/
            #endregion IWebDriver
            
            #region public void Close()
            if (1 < webDriverMock.Object.WindowHandles.Count) {
                System.Collections.Generic.List<string> listOfWindows =
                    new System.Collections.Generic.List<string>();
                foreach (string window in webDriverMock.Object.WindowHandles) {
                    if (webDriverMock.Object.CurrentWindowHandle != window) {
                        listOfWindows.Add(window);
                    }
                }
                webDriverMock.Setup(w => w.Close())
                    .Callback(() => ((FakeWebDriver)webDriverMock.Object).WritableWindowHandles =
                              new ReadOnlyCollection<string>(listOfWindows));
            } else {
                webDriverMock.Setup(w => w.Close()).Callback(() => webDriverMock.Object.Quit());
            }
            #endregion public void Close()
            
            #region public void Quit()
            #endregion public void Quit()
            //OpenQA.Selenium.By by = new OpenQA.Selenium.By();

            
            
//            // checking the api key via TestLink.checkDevKey(string)
//            if (tagName.ToUpper() || tagName.ToUpper()) {
//                //webDriverMock.Setup(w => w.Clear())
//            } else {
//                
//            }
//            webDriverMock.Setup(t => t.checkDevKey(TestLinkApiKeyWrong))
//                .Throws(new TestLinkException("2000:(checkDevKey) - Can not authenticate client: invalid developer key"));
//            webDriverMock.Setup(t => t.checkDevKey(string.Empty))
//                .Throws(new TestLinkException("Devkey is empty. You must supply a development key"));
//            
//            // checking the url via TestLink.SayHello()
//            if (TestLinkUrlRight == url) {
//                webDriverMock.Setup(t => t.SayHello()).Returns(() => string.Empty);
//            } else if (TestLinkUrlWrong == url) {
//                webDriverMock.Setup(t => t.SayHello())
//                    .Throws(new UriFormatException("Invalid URI: The format of the URI could not be determined."));
//            } else if (string.Empty == url) {
//                webDriverMock.Setup(t => t.SayHello())
//                    .Throws(new XmlRpcMissingUrl("Proxy XmlRpcUrl attribute or Url property not set."));
//            }
            
            
            
//            var builder = new ContainerBuilder();
//            builder.RegisterType<ITestLinkExtra>();
//            var container = builder.Build(ContainerBuildOptions.Default);
//            TestLink testLink = container.Resolve<TestLink>();
//            //testLink.checkDevKey().
            
            
            return webDriverMock;
        }
        
        public static IWebDriver GetWebDriver()
        {
            var webDriverMock = _getWebDriverMock();
            return webDriverMock.Object;
        }
        #endregion IWebDriver
        
        #region IWebElement
        private static Mock<IWebElement> _getWebElementMock()
        {
            var byMock = new Mock<By>().As<FakeBy>();
            var webElementMock = new Mock<FakeWebElement>().As<IWebElement>();
            
            
            return webElementMock;
        }
        
        public static IWebElement GetWebElement()
        {
            var webElementMock = _getWebElementMock();
            return webElementMock.Object;
        }
        #endregion IWebElement
        
//        private static Mock<IWebElement> _getWebElementMock() //string apiKey, string url)
//        {
//            //var webElementMock = new Mock<RemoteWebElement>(apiKey, url).As<ITestLinkExtra>();
//            var webElementMock = new Mock<RemoteWebElement>().As<IWebElement>();
//            
//            // checking the api key via TestLink.checkDevKey(string)
//            webElementMock.Setup(t => t.checkDevKey(TestLinkApiKeyRight)).Returns(true);
//            webElementMock.Setup(t => t.checkDevKey(TestLinkApiKeyWrong))
//                .Throws(new TestLinkException("2000:(checkDevKey) - Can not authenticate client: invalid developer key"));
//            webElementMock.Setup(t => t.checkDevKey(string.Empty))
//                .Throws(new TestLinkException("Devkey is empty. You must supply a development key"));
//            
//            // checking the url via TestLink.SayHello()
//            if (TestLinkUrlRight == url) {
//                webElementMock.Setup(t => t.SayHello()).Returns(() => string.Empty);
//            } else if (TestLinkUrlWrong == url) {
//                webElementMock.Setup(t => t.SayHello())
//                    .Throws(new UriFormatException("Invalid URI: The format of the URI could not be determined."));
//            } else if (string.Empty == url) {
//                webElementMock.Setup(t => t.SayHello())
//                    .Throws(new XmlRpcMissingUrl("Proxy XmlRpcUrl attribute or Url property not set."));
//            }
//            
//            
//            
////            var builder = new ContainerBuilder();
////            builder.RegisterType<ITestLinkExtra>();
////            var container = builder.Build(ContainerBuildOptions.Default);
////            TestLink testLink = container.Resolve<TestLink>();
////            //testLink.checkDevKey().
//            
//            
//            return webElementMock;
//            
//        }
//        
//        private static Mock<ITestLinkExtra> _getTestLinkMock()
//        {
//            var testLinkMock =
//                _getTestLinkMock(
//                    TestLinkApiKeyRight,
//                    TestLinkUrlRight);
//            
//            return testLinkMock;
//        }
//        
//        public static ITestLinkExtra GetTestLink(string apiKey, string url)
//        {
//            // constructor
//            var testLinkMock = _getTestLinkMock(apiKey, url);
//            
//#region the list
//            // methods
//            
//            // about();
//            // addTestCaseToTestPlan()
//            
//            // CreateBuild()
//            //testLinkMock.Setup(t => 
//            
//            // CreateProject()
//            //testLinkMock.Setup(t => 
//            
//            // CreateTestCase()
//            //testLinkMock.Setup(t => 
//            
//            // CreateTestPlan()
//            //testLinkMock.Setup(t => 
//            
//            // CreateTestSuite()
//            //testLinkMock.Setup(t => 
//            
//            // DeleteExecution()
//            // DoesUserExist()
//            // GetBuildsForTestPlan()
//            // GetFirstLevelTestSuitesForTestProject()
//            // GetLastExecutionResult()
//            
//            // GetLatestBuildForTestPlan()
//            //testLinkMock.Setup(t => 
//            
//            // GetProject()
//            //testLinkMock.Setup(t => 
//            
//            // GetProjects()
//            //testLinkMock.Setup(t => t.GetProjects()).Returns
//            
//            
//            // GetProjectTestPlans()
//            //testLinkMock.Setup(t => 
//            
//            // GetTestCase()
//            //testLinkMock.Setup(t => 
//            
//            // GetTestCaseAttachments()
//            //testLinkMock.Setup(t => 
//            
//            // GetTestCaseIDByName()
//            // GetTestCaseIdsForTestSuite()
//            
//            // GetTestCasesForTestPlan()
//            //testLinkMock.Setup(t => 
//            
//            // GetTestCasesForTestSuite()
//            //testLinkMock.Setup(t => 
//            
//            // getTestPlanByName()
//            //testLinkMock.Setup(t => 
//            
//            // GetTestPlanPlatforms()
//            // GetTestSuiteById()
//            
//            // GetTestSuitesForTestPlan()
//            //testLinkMock.Setup(t => 
//            
//            // GetTestSuitesForTestSuite()
//            //testLinkMock.Setup(t => 
//            
//            // GetTotalsForTestPlan()
//            //testLinkMock.Setup(t => 
//            
//            // ReportTCResult()
//            //testLinkMock.Setup(t => 
//            
//            // UploadExecutionAttachment()
//            
//            // UploadTestCaseAttachment()
//            //testLinkMock.Setup(t => 
//            
//            // UploadTestProjectAttachment()
//            // UploadTestSuiteAttachment()
//            
//            // properties
//            // LastRequest
//            // LastResponse
//#endregion the list
//
//            return testLinkMock.Object;
//        }
    }
    
    internal enum WebDriverTypes {
        Chrome,
        IE,
        Firefox
    }
}
