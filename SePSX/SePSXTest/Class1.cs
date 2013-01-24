///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 7/17/2012
// * Time: 10:23 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace SePSXTest
//{
//    using System;
//    using SePSX;
//    using System.Linq;
//    using OpenQA.Selenium;
//    using OpenQA.Selenium.Firefox;
//    using OpenQA.Selenium.Chrome;
//    using OpenQA.Selenium.Android;
//    using OpenQA.Selenium.IE;
//    using OpenQA.Selenium.Safari;
//    using OpenQA.Selenium.Interactions;
//    using OpenQA.Selenium.Support.UI;
//    
//    /// <summary>
//    /// Description of Class1.
//    /// </summary>
//    public static class Class1
//    {
//        public static void Main()
//        {
//            //SePSX.SeHelper.Init();
//            //SePSX.SeHelper.DriverFF.Navigate().GoToUrl("http://www.lenta.ru");
//            
//            //var driver = SePSX.SeHelper.DriverFF;
//            IWebDriver driver = new FirefoxDriver();
//
//        //Notice navigation is slightly different than the Java version
//        //This is because 'get' is a keyword in C#
//        driver.Navigate().GoToUrl("http://www.google.com/");
//
//        // Find the text input element by its name
//        IWebElement query = driver.FindElement(OpenQA.Selenium.By.Name("q"));
//
//        // Enter something to search for
//        query.SendKeys("Cheese");
//
//        // Now submit the form. WebDriver will find the form for us from the element
//        query.Submit();
//
//        // Google's search is rendered dynamically with JavaScript.
//        // Wait for the page to load, timeout after 10 seconds
//        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        wait.Until((d) => { return d.Title.ToLower().StartsWith("cheese"); });
//
//        // Should see: "Cheese - Google Search"
//        System.Console.WriteLine("Page title is: " + driver.Title);
//        
////        IWebDriver driver2 = new ChromeDriver();
////        driver2.Navigate().GoToUrl("http://www.google.com/");
////        IWebElement query2 = driver2.FindElement(OpenQA.Selenium.By.Name("q"));
////        query2.SendKeys("Cheese");
////        query2.Submit();
////        WebDriverWait wait2 = new WebDriverWait(driver2, TimeSpan.FromSeconds(10));
////        wait2.Until((d2) => { return d2.Title.ToLower().StartsWith("cheese"); });
////        System.Console.WriteLine("Page title is: " + driver2.Title);
//        
//        IWebDriver driver3 = new InternetExplorerDriver();
//        driver3.Navigate().GoToUrl("http://www.google.com/");
//        IWebElement query3 = driver3.FindElement(OpenQA.Selenium.By.Name("q"));
//        query3.SendKeys("Cheese");
//        query3.Submit();
//        WebDriverWait wait3 = new WebDriverWait(driver3, TimeSpan.FromSeconds(10));
//        wait3.Until((d3) => { return d3.Title.ToLower().StartsWith("cheese"); });
//        System.Console.WriteLine("Page title is: " + driver3.Title);
//        
//        IWebDriver driver4 = new FirefoxDriver();
//        driver4.Navigate().GoToUrl("http://www.yandex.ru/");
//        IWebElement query4 = driver4.FindElement(OpenQA.Selenium.By.Name("text"));
//        query4.SendKeys("Cheese");
//        query4.Submit();
//        WebDriverWait wait4 = new WebDriverWait(driver4, TimeSpan.FromSeconds(10));
//        wait4.Until((d4) => { return d4.Title.ToLower().StartsWith("cheese"); });
//        System.Console.WriteLine("Page title is: " + driver4.Title);
//        
//        IWebDriver driver5 = new InternetExplorerDriver();
//        driver5.Navigate().GoToUrl("http://www.yandex.ru/");
//        IWebElement query5 = driver5.FindElement(OpenQA.Selenium.By.Name("text"));
//        query5.SendKeys("Cheese");
//        query5.Submit();
//        WebDriverWait wait5 = new WebDriverWait(driver5, TimeSpan.FromSeconds(10));
//        wait5.Until((d5) => { return d5.Title.ToLower().StartsWith("cheese"); });
//        System.Console.WriteLine("Page title is: " + driver5.Title);
//        
//        //Close the browser
//        driver.Quit();
////        driver2.Quit();
//        driver3.Quit();
//        driver4.Quit();
//        driver5.Quit();
//
//
//        }
//    }
//}
