///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/22/2012
// * Time: 4:14 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace SePSXUnitTests
//{
//    using System;
//    using OpenQA.Selenium;
//    using OpenQA.Selenium.Chrome;
//    
//    
//    using Ninject;
//    using Ninject.Modules;
//    
//    
//    
//    using SePSX;
//    using SePSX.Commands;
//    
//    /// <summary>
//    /// Description of SimpleContainer.
//    /// </summary>
//    public class SimpleContainer
//    {
//        public SimpleContainer()
//        {
//        }
//        
//        public void Init()
//        {
//            NinjectModule module = new SimpleModule();
//            
//            using (IKernel kernel = new StandardKernel(module)) {
//
//                var driver = kernel.Get<IWebDriver>();
//                
//                //var driver2 = WebDriverFactory.GetDriver((new StartSeSafariCommandTestFixture()), Drivers.Safari);
//                var factory = kernel.Get<IWebDriverFactory>(); //new WebDriverFactory();
//                var driver2 = factory.GetDriver((new StartSeSafariCommandTestFixture()), Drivers.Safari);
//                var driver3 = factory.GetDriver((new StartSeChromeCommandTestFixture()), Drivers.Chrome);
//                var driver4 = factory.GetDriver((new StartSeFirefoxCommandTestFixture()), Drivers.Firefox);
//                var driver5 = kernel.Get<ChromeDriver>(); 
//                // factory.GetDriver((new StartSeChromeCommandTestFixture()), Drivers.Chrome);
//                driver5.Navigate().GoToUrl("http://lenta.ru");
//            };
//            
//            using (IKernel kernel = new StandardKernel()) {
//                
//            }
//        }
//    }
//    
//    public static class MainClass
//    {
//        public static void Main()
//        {
//            SimpleContainer cont = new SimpleContainer();
//            cont.Init();
//            System.Threading.Thread.Sleep(2000);
//            
//            Console.ReadKey();
//        }
//    }
//}
