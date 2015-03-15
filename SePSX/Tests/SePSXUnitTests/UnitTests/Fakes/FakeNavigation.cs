/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/15/2012
 * Time: 2:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    //using System.Drawing;
    //using System.Collections.ObjectModel;
    
    //using TestMethods;

    /// <summary>
    /// Description of FakeNavigation.
    /// </summary>
    public class FakeNavigation : INavigation
    {
//        public FakeNavigation()
//        {
//        }

        public FakeNavigation(FakeWebDriver driver)
        {
            this.Driver = driver;
        }
        
        internal FakeWebDriver Driver { get; set; }
        
        internal static string previousUrl;
        internal static string previousTitle;
        internal static string previousPageSource;
        
        private void swap(ref string str1, string str2)
        {
            string tempString = str1;
            str1 = str2;
            str2 = tempString;
        }

        private void saveCurrentState()
        {
Console.WriteLine("saveCurrentState: previousUrl = " + previousUrl);
Console.WriteLine("saveCurrentState: Driver._url = " + Driver._url);
            previousUrl = Driver.Url;
Console.WriteLine("saveCurrentState: previousUrl = " + previousUrl);
Console.WriteLine("saveCurrentState: Driver._url = " + Driver._url);
            previousTitle = Driver.Title;
            previousPageSource = Driver.PageSource;
        }
        
        private void revertToPreviousState()
        {
Console.WriteLine("revertToPreviousState: previousPageSource = " + previousPageSource);
Console.WriteLine("revertToPreviousState: Driver._pageSource = " + Driver._pageSource);
            //swap(ref previousPageSource, Driver._pageSource);
            string tempPageSource = Driver._pageSource;
            Driver._pageSource = previousPageSource;
            previousPageSource = tempPageSource;
Console.WriteLine("revertToPreviousState: previousPageSource = " + previousPageSource);
Console.WriteLine("revertToPreviousState: Driver._pageSource = " + Driver._pageSource);

Console.WriteLine("revertToPreviousState: previousUrl = " + previousUrl);
Console.WriteLine("revertToPreviousState: Driver._url = " + Driver._url);
            //swap(ref previousUrl, Driver._url);
            string tempUrl = Driver._url;
            Driver._url = previousUrl;
            previousUrl = tempUrl;
Console.WriteLine("revertToPreviousState: previousUrl = " + previousUrl);
Console.WriteLine("revertToPreviousState: Driver._url = " + Driver._url);
            //swap(ref previousTitle, Driver._title);
            string tempTitle = Driver._title;
            Driver._title = previousTitle;
            previousTitle = tempTitle;
        }

        public void Back()
        {
            revertToPreviousState();
        }
        
        public void Forward()
        {
            revertToPreviousState();
        }
        
        public void GoToUrl(string url)
        {
            saveCurrentState();
            Driver._url = url;
            Driver._title = url;
        }
        
        public void GoToUrl(Uri url)
        {
            saveCurrentState();
            Driver._url = url.ToString();
            Driver._title = url.ToString();
        }
        
        public void Refresh()
        {
            Driver._title = "refreshed";
        }
    }
}
