/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/12/2012
 * Time: 3:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Internal;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Description of WebElementDecorator.
    /// </summary>
    public class WebElementDecorator : IWebElement, ISearchContext, IFindsByLinkText, IFindsById, IFindsByName, IFindsByTagName, IFindsByClassName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, IWrapsDriver, ILocatable
        // : RemoteWebElement //, IWebElement
    {
        //public WebElementDecorator(IWebElement realWebElement)
        //public WebElementDecorator(RemoteWebElement realWebElement) // : base(realWebElement.WrappedDriver, "")
        public WebElementDecorator(RemoteWebElement realWebElement)
        {
            DecoratedWebElement = realWebElement; // as RemoteWebElement;
Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<WebElementDecorator(IWebElement realWebElement): " + DecoratedWebElement.ToString());
Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<WebElementDecorator(IWebElement realWebElement): " + DecoratedWebElement.GetType().Name);
try {
//Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<WebElementDecorator(IWebElement realWebElement): " + this.DecoratedWebElement.TagName);
Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<WebElementDecorator(IWebElement realWebElement): " + DecoratedWebElement.TagName);
} catch (Exception eTagName) {
    Console.WriteLine(eTagName.Message);
    Console.WriteLine(eTagName.GetType().Name);
}
Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<WebElementDecorator(IWebElement realWebElement): OK");
            SearchHistory =
                new List<ISearchHistory>();
        }
        
//        internal WebElementDecorator()
//        {
//            this.SearchHistory =
//                new List<ISearchHistory>();
//        }
        
        //private IWebElement decoratedWebElement;
        internal RemoteWebElement DecoratedWebElement;
        
        //internal ReadOnlyCollection<ISearchHistory> SearchHistory { get; }
        internal List<ISearchHistory> SearchHistory { get; set; }
        //internal 
        
        public string TagName
        {
            get { try { return DecoratedWebElement.TagName; } 
                catch (Exception eTagName) { Console.WriteLine("WebElementDecorator (tagName): " + eTagName.Message); return null; } }
        }
        public string Text
        {
            get { try { return DecoratedWebElement.Text; } 
                catch (Exception eText) { Console.WriteLine("WebElementDecorator (text): " + eText.Message); return null; } }
        }
        public bool Enabled
        {
            get { return DecoratedWebElement.Enabled; }
        }
        public bool Selected
        {
            get { return DecoratedWebElement.Selected; }
        }
        public Point Location
        {
            get { return DecoratedWebElement.Location; }
        }
        public Size Size
        {
            get { return DecoratedWebElement.Size; }
        }
        public bool Displayed
        {
            get { return DecoratedWebElement.Displayed; }
        }
        public void Clear()
        {
            DecoratedWebElement.Clear();
        }
        public void SendKeys(string text)
        {
            DecoratedWebElement.SendKeys(text);
        }
        public void Submit()
        {
            DecoratedWebElement.Submit();
        }
        public void Click()
        {
            DecoratedWebElement.Click();
        }
        public string GetAttribute(string attributeName)
        {
            return DecoratedWebElement.GetAttribute(attributeName);
        }
        public string GetCssValue(string propertyName)
        {
            return DecoratedWebElement.GetCssValue(propertyName);
        }
        public IWebElement FindElement(By by)
        {
            return DecoratedWebElement.FindElement(by);
        }
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return DecoratedWebElement.FindElements(by);
        }
        
        public IWebDriver WrappedDriver
        {
            get
            {
                return DecoratedWebElement.WrappedDriver;
            }
        }

        public Point LocationOnScreenOnceScrolledIntoView
        {
            get
            {
                return DecoratedWebElement.LocationOnScreenOnceScrolledIntoView;
            }
        }
        /// <summary>
        ///       Gets the coordinates identifying the location of this element using
        ///       various frames of reference.
        ///       </summary>
        public ICoordinates Coordinates
        {
            get
            {
                return DecoratedWebElement.Coordinates;
                //return new RemoteCoordinates(this);
            }
        }

        /// <summary>
        ///       Finds the first of elements that match the link text supplied
        ///       </summary>
        /// <param name="linkText">Link text of element </param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       IWebElement elem = driver.FindElementByLinkText("linktext")
        ///       </code>
        /// </example>
        public IWebElement FindElementByLinkText(string linkText)
        {
            return DecoratedWebElement.FindElementByLinkText(linkText);
        }
        /// <summary>
        ///       Finds the first of elements that match the link text supplied
        ///       </summary>
        /// <param name="linkText">Link text of element </param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       ReadOnlyCollection<![CDATA[<IWebElement>]]> elem = driver.FindElementsByLinkText("linktext")
        ///       </code>
        /// </example>
        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText)
        {
            return DecoratedWebElement.FindElementsByLinkText(linkText);
        }
        /// <summary>
        ///       Finds the first element in the page that matches the ID supplied
        ///       </summary>
        /// <param name="id">ID of the element</param>
        /// <returns>IWebElement object so that you can interact with that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       IWebElement elem = driver.FindElementById("id")
        ///       </code>
        /// </example>
        public IWebElement FindElementById(string id)
        {
            return DecoratedWebElement.FindElementById(id);
        }
        /// <summary>
        ///       Finds the first element in the page that matches the ID supplied
        ///       </summary>
        /// <param name="id">ID of the Element</param>
        /// <returns>ReadOnlyCollection of Elements that match the object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       ReadOnlyCollection<![CDATA[<IWebElement>]]> elem = driver.FindElementsById("id")
        ///       </code>
        /// </example>
        public ReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            return DecoratedWebElement.FindElementsById(id);
        }
        /// <summary>
        ///       Finds the first of elements that match the name supplied
        ///       </summary>
        /// <param name="name">Name of the element</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       elem = driver.FindElementsByName("name")
        ///       </code>
        /// </example>
        public IWebElement FindElementByName(string name)
        {
            return DecoratedWebElement.FindElementByName(name);
        }
        /// <summary>
        ///       Finds a list of elements that match the name supplied
        ///       </summary>
        /// <param name="name">Name of element</param>
        /// <returns>ReadOnlyCollect of IWebElement objects so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       ReadOnlyCollection<![CDATA[<IWebElement>]]> elem = driver.FindElementsByName("name")
        ///       </code>
        /// </example>
        public ReadOnlyCollection<IWebElement> FindElementsByName(string name)
        {
            return DecoratedWebElement.FindElementsByName(name);
        }
        /// <summary>
        ///       Finds the first of elements that match the DOM Tag supplied
        ///       </summary>
        /// <param name="tagName">tag name of the element</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       IWebElement elem = driver.FindElementsByTagName("tag")
        ///       </code>
        /// </example>
        public IWebElement FindElementByTagName(string tagName)
        {
            return DecoratedWebElement.FindElementByTagName(tagName);
        }
        /// <summary>
        ///       Finds a list of elements that match the DOM Tag supplied
        ///       </summary>
        /// <param name="tagName">DOM Tag of the element on the page</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       ReadOnlyCollection<![CDATA[<IWebElement>]]> elem = driver.FindElementsByTagName("tag")
        ///       </code>
        /// </example>
        public ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName)
        {
            return DecoratedWebElement.FindElementsByTagName(tagName);
        }
        /// <summary>
        ///       Finds the first element in the page that matches the CSS Class supplied
        ///       </summary>
        /// <param name="className">CSS class name of the element on the page</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       IWebElement elem = driver.FindElementByClassName("classname")
        ///       </code>
        /// </example>
        public IWebElement FindElementByClassName(string className)
        {
            return DecoratedWebElement.FindElementByClassName(className);
        }
        /// <summary>
        ///       Finds a list of elements that match the class name supplied
        ///       </summary>
        /// <param name="className">CSS class name of the elements on the page</param>
        /// <returns>ReadOnlyCollection of IWebElement object so that you can interact with those objects</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       ReadOnlyCollection<![CDATA[<IWebElement>]]> elem = driver.FindElementsByClassName("classname")
        ///       </code>
        /// </example>
        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            return DecoratedWebElement.FindElementsByClassName(className);
        }
        /// <summary>
        ///       Finds the first of elements that match the XPath supplied
        ///       </summary>
        /// <param name="xpath">xpath to the element</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       IWebElement elem = driver.FindElementsByXPath("//table/tbody/tr/td/a");
        ///       </code>
        /// </example>
        public IWebElement FindElementByXPath(string xpath)
        {
            return DecoratedWebElement.FindElementByXPath(xpath);
        }
        /// <summary>
        ///       Finds a list of elements that match the XPath supplied
        ///       </summary>
        /// <param name="xpath">xpath to element on the page</param>
        /// <returns>ReadOnlyCollection of IWebElement objects so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       ReadOnlyCollection<![CDATA[<IWebElement>]]> elem = driver.FindElementsByXpath("//tr/td/a")
        ///       </code>
        /// </example>
        public ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath)
        {
            return DecoratedWebElement.FindElementsByXPath(xpath);
        }
        /// <summary>
        ///       Finds the first of elements that match the part of the link text supplied
        ///       </summary>
        /// <param name="partialLinkText">part of the link text</param>
        /// <returns>IWebElement object so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       IWebElement elem = driver.FindElementsByPartialLinkText("partOfLink")
        ///       </code>
        /// </example>
        public IWebElement FindElementByPartialLinkText(string partialLinkText)
        {
            return DecoratedWebElement.FindElementByPartialLinkText(partialLinkText);
        }
        /// <summary>
        ///       Finds a list of elements that match the link text supplied
        ///       </summary>
        /// <param name="partialLinkText">part of the link text</param>
        /// <returns>ReadOnlyCollection<![CDATA[<IWebElement>]]> objects so that you can interact that object</returns>
        /// <example>
        ///   <code>
        ///       IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        ///       ReadOnlyCollection<![CDATA[<IWebElement>]]> elem = driver.FindElementsByPartialLinkText("partOfTheLink")
        ///       </code>
        /// </example>
        public ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText)
        {
            return DecoratedWebElement.FindElementsByPartialLinkText(partialLinkText);
        }
        /// <summary>
        ///       Finds the first element matching the specified CSS selector.
        ///       </summary>
        /// <param name="cssSelector">The id to match.</param>
        /// <returns>The first <see cref="T:OpenQA.Selenium.IWebElement" /> matching the criteria.</returns>
        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            return DecoratedWebElement.FindElementByCssSelector(cssSelector);
        }
        /// <summary>
        ///       Finds all elements matching the specified CSS selector.
        ///       </summary>
        /// <param name="cssSelector">The CSS selector to match.</param>
        /// <returns>A <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1" /> containing all
        ///       <see cref="T:OpenQA.Selenium.IWebElement">IWebElements</see> matching the criteria.</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector)
        {
            return DecoratedWebElement.FindElementsByCssSelector(cssSelector);
        }
    }
}
