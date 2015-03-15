///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/22/2012
// * Time: 4:05 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace SePSXUnitTests
//{
//    using System;
//    using OpenQA.Selenium;
//    using Ninject;
//    using Ninject.Modules;
//    
//    using OpenQA.Selenium.Safari;
//    
//    
//    using OpenQA.Selenium.Chrome;
//    using SePSX;
//    
//    /// <summary>
//    /// Description of SimpleModule.
//    /// </summary>
//    public class SimpleModule : NinjectModule, INinjectModule
//    {
//        public SimpleModule()
//        {
//        }
//        
//        public override void Load()
//        {
//            //throw new NotImplementedException();
//            
//            Bind<IAlert>().To<FakeAlert>();
//            Bind<ICapabilities>().To<FakeCapabilities>();
//            Bind<ICookieJar>().To<FakeCookieJar>();
//            Bind<IHasCapabilities>().To<FakeHasCapabilities>();
//            Bind<IHasInputDevices>().To<FakeHasInputDevices>();
//            Bind<IJavaScriptExecutor>().To<FakeJavaScriptExecutor>();
//            Bind<IKeyboard>().To<FakeKeyboard>();
//            Bind<ILocatable>().To<FakeLocatable>();
//            Bind<IMouse>().To<FakeMouse>();
//            Bind<INavigation>().To<FakeNavigation>();
//            Bind<IOptions>().To<FakeOptions>();
//            Bind<IRotatable>().To<FakeRotatable>();
//            Bind<ISearchContext>().To<FakeSearchContext>();
//            //Bind<ISelectElement>().To<FakeSelectElement>();
//            Bind<ITakesScreenshot>().To<FakeTakesScreenshot>();
//            Bind<ITargetLocator>().To<FakeTargetLocator>();
//            Bind<ITimeouts>().To<FakeTimeouts>();
//            Bind<IWebDriver>().To<FakeWebDriver>();
//            Bind<IWebElement>().To<FakeWebElement>();
//            Bind<IWindow>().To<FakeWindow>();
//            
//            Bind<OpenQA.Selenium.Support.UI.SelectElement>().To<FakeSelectElement>();
//            
//            //Bind<SafariDriver>()..To<FakeWebDriver>();
//            
//            //Bind<SafariDriver>().ToMethod(() => WebDriverFactory.GetNativeDriver);
//            //WebDriverFactory factory = new WebDriverFactory();
//            //Bind<SafariDriver>().ToMethod(f => (SafariDriver)factory.GetNativeDriver(Drivers.Safari));
//            
//            //Bind<WebDriverFactory>().ToSelf().InSingletonScope();
//            
//            Bind<IWebDriverFactory>().To<FakeWebDriverFactory>();
//            
//            Bind<ChromeDriver>().To<FakeChromeDriver>().
//                WithConstructorArgument("url", "http://anekdot.ru")
//                .WithConstructorArgument("title", "fake browser")
//                .WithConstructorArgument("pageSource", "<html></html>");
//        }
//    }
//}
