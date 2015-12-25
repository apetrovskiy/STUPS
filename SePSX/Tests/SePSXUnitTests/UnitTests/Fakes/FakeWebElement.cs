/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/3/2012
 * Time: 11:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions.Internal;
    using OpenQA.Selenium.Internal;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using SePSX;

    /// <summary>
    /// Description of WebElementFromSelenium.
    /// </summary>
    public class FakeWebElement : IWebElement, ISearchContext, IFindsByLinkText, IFindsById, IFindsByName, IFindsByTagName, IFindsByClassName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, IWrapsDriver, ILocatable
    {
       
        private string tagName = string.Empty;
        private string text = string.Empty;
        
        private bool displayed = false;
        private bool enabled = false;
        private bool selected = false;
        
        private Point location;
        private Size size;
        
        internal void Init()
        {
            //this.Elements =
            //    new List<IWebElement>();
            Attributes =
                new Dictionary<string, string>();
            CssValues =
                new Dictionary<string, string>();
        }
        
        /// <summary>
        /// Like decorator
        /// </summary>
        /// <param name="realWebElement"></param>
        public FakeWebElement(IWebElement realWebElement)
        //public WebElementDecorator(RemoteWebElement realWebElement) // : base(realWebElement.WrappedDriver, "")
        {
            DecoratedWebElement = realWebElement as FakeWebElement;
            SearchHistory =
                new List<ISearchHistory>();
        }
        
        internal FakeWebElement DecoratedWebElement;
        internal List<ISearchHistory> SearchHistory { get; set; }
        
        //[
        public FakeWebElement()
        {
            tagName = "tag";
            text = "text";
            Init();
        }
        
        public FakeWebElement(string tagName, string text)
        {
            this.tagName = tagName;
            this.text = text;
            Init();
        }
        
        public FakeWebElement(string tagName, string text, bool displayed, bool enabled, bool selected) : this(tagName, text)
        {
//            this.tagName = tagName;
//            this.text = text;
            this.displayed = displayed;
            this.enabled = enabled;
            this.selected = selected;
        }
        
        public FakeWebElement(string tagName, string text, Point location, Size size) : this(tagName, text)
        {
//            this.tagName = tagName;
//            this.text = text;
            this.location = location;
            this.size = size;
        }
        
        public string TagName
        {
            get { return tagName; }
        }
        public string Text
        {
            get { return text; }
        }
        public bool Enabled
        {
            get { return enabled; }
        }
        public bool Selected
        {
            get { return selected; }
        }
        public Point Location
        {
            get { return location; }
        }
        public Size Size
        {
            get { return size; }
        }
        public bool Displayed
        {
            get { return displayed; }
        }
        public void Clear() { }
        public void SendKeys(string text) { }
        public void Submit() { }
        public void Click() { }
        public string GetAttribute(string attributeName) { return "attr"; }
        public string GetCssValue(string propertyName) { return "css"; }
        
        
        internal Dictionary<string, string> Attributes { get; set; }
        internal Dictionary<string, string> CssValues { get; set; }
//        public IWebElement FindElement(By by) { return (new FakeWebElement()); }
//        public ReadOnlyCollection<IWebElement> FindElements(By by) 
//        { 
//            return (new ReadOnlyCollection<IWebElement>((new System.Collections.Generic.List<IWebElement>())));
//        }
        
        internal ReadOnlyCollection<IWebElement> Elements { get; set; }
        internal void SetElementsCollection(List<IWebElement> listOfElements)
        {
            Elements =
                new ReadOnlyCollection<IWebElement>(listOfElements);
        }
        
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Elements;
        }
        
        public IWebElement FindElement(By by)
        {
            return Elements[0];
        }
        
        
        
        public IWebDriver WrappedDriver
        {
            get
            {
                return new FakeChromeDriver(); //this.DecoratedWebElement.WrappedDriver;
            }
        }

        public Point LocationOnScreenOnceScrolledIntoView
        {
            get
            {
                return new Point(1,1); // this.DecoratedWebElement.LocationOnScreenOnceScrolledIntoView;
            }
        }
        public ICoordinates Coordinates
        {
            get
            {
                return new FakeCoordinates(this); // this.DecoratedWebElement.Coordinates;
            }
        }
        public IWebElement FindElementByLinkText(string linkText)
        {
            return Elements[0]; // this.DecoratedWebElement.FindElementByLinkText(linkText);
        }
        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText)
        {
            return Elements; // this.DecoratedWebElement.FindElementsByLinkText(linkText);
        }
        public IWebElement FindElementById(string id)
        {
            return Elements[0]; // this.DecoratedWebElement.FindElementById(id);
        }
        public ReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            return Elements; // this.DecoratedWebElement.FindElementsById(id);
        }
        public IWebElement FindElementByName(string name)
        {
            return Elements[0]; // this.DecoratedWebElement.FindElementByName(name);
        }
        public ReadOnlyCollection<IWebElement> FindElementsByName(string name)
        {
            return Elements; // this.DecoratedWebElement.FindElementsByName(name);
        }
        public IWebElement FindElementByTagName(string tagName)
        {
            return Elements[0]; // this.DecoratedWebElement.FindElementByTagName(tagName);
        }
        public ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName)
        {
            return Elements; // this.DecoratedWebElement.FindElementsByTagName(tagName);
        }
        public IWebElement FindElementByClassName(string className)
        {
            return Elements[0]; // this.DecoratedWebElement.FindElementByClassName(className);
        }
        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            return Elements; // this.DecoratedWebElement.FindElementsByClassName(className);
        }
        public IWebElement FindElementByXPath(string xpath)
        {
            return Elements[0]; // this.DecoratedWebElement.FindElementByXPath(xpath);
        }
        public ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath)
        {
            return Elements; // this.DecoratedWebElement.FindElementsByXPath(xpath);
        }
        public IWebElement FindElementByPartialLinkText(string partialLinkText)
        {
            return Elements[0]; // this.DecoratedWebElement.FindElementByPartialLinkText(partialLinkText);
        }
        public ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText)
        {
            return Elements; // this.DecoratedWebElement.FindElementsByPartialLinkText(partialLinkText);
        }
        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            return Elements[0]; // this.DecoratedWebElement.FindElementByCssSelector(cssSelector);
        }
        public ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector)
        {
            return Elements; // this.DecoratedWebElement.FindElementsByCssSelector(cssSelector);
        }
    }
}
