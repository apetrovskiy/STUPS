///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/23/2012
// * Time: 2:45 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace SePSXUnitTests
//{
//    using System;
//    using OpenQA.Selenium;
//    using OpenQA.Selenium.Chrome;
//    using Ninject;
//    using Ninject.Injection;
//
//    /// <summary>
//    /// Description of FakeChromeDriver.
//    /// </summary>
//    public class FakeChromeDriver : ChromeDriver, IWebDriver
//    {
//        private FakeChromeDriver()
//        {
//        }
//        
//        [Inject]
//        public FakeChromeDriver(string url, string title, string pageSource)
//        {
//            this._url = url;
//            this._title = title;
//            this._pageSource = pageSource;
//            
//            base.StopClient();
//
//            base.StartClient();
//
//        }
//        
//        public FakeChromeDriver(string url, string title, string pageSource, string currentWindowHandle) :
//            this(url, title, pageSource)
//        {
//            this._currentWindowHandle = currentWindowHandle;
//        }
//        
//        public FakeChromeDriver(
//            string url, 
//            string title, 
//            string pageSource, 
//            string currentWindowHandle,
//            System.Collections.ObjectModel.ReadOnlyCollection<string> windowHandles) :
//            this(url, title, pageSource, currentWindowHandle)
//        {
//            this._windowHandles = windowHandles;
//        }
//        
//        private string _url;
//        private string _title;
//        private string _pageSource;
//        private string _currentWindowHandle;
//        private System.Collections.ObjectModel.ReadOnlyCollection<string> _windowHandles;
//            
//        public string Url {
//            get {
//                return this._url;
//            }
//            set {
//                this._url = value;
//            }
//        }
//        
//        public string Title {
//            get {
//                return this._title;
//            }
//        }
//        
//        public string PageSource {
//            get {
//                return this._pageSource;
//            }
//        }
//        
//        public string CurrentWindowHandle {
//            get {
//                return this._currentWindowHandle;
//            }
//        }
//        
//        public System.Collections.ObjectModel.ReadOnlyCollection<string> WindowHandles {
//            get {
//                return this._windowHandles;
//            }
//        }
//        
//        public void Close()
//        {
//            throw new NotImplementedException();
//        }
//        
//        public void Quit()
//        {
//            throw new NotImplementedException();
//        }
//        
//        public IOptions Manage()
//        {
//            throw new NotImplementedException();
//        }
//        
//        public INavigation Navigate()
//        {
//            throw new NotImplementedException();
//        }
//        
//        public ITargetLocator SwitchTo()
//        {
//            throw new NotImplementedException();
//        }
//        
//        public IWebElement FindElement(By @by)
//        {
//            throw new NotImplementedException();
//        }
//        
//        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElements(By @by)
//        {
//            throw new NotImplementedException();
//        }
//        
//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
