/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/17/2012
 * Time: 11:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using SePSX;

    /// <summary>
    /// Description of FakeRemoteWebElement.
    /// </summary>
    public class FakeRemoteWebElement : RemoteWebElement
    {
//        public FakeRemoteWebElement()
//        {
//        }

        public FakeRemoteWebElement(RemoteWebDriver parentDriver, string id) : base(parentDriver, id) // base(null, string.Empty) //
        {
        }
        
        
        
        
        
        
        
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
        
        internal void SetInternalWebDriver(
            string tagName,
            string text,
            bool enabled,
            bool displayed,
            bool selected)
        {
            ((FakeWebDriver)base.WrappedDriver).TagNameResponse =
                tagName;
            ((FakeWebDriver)base.WrappedDriver).TextResponse =
                text;
            ((FakeWebDriver)base.WrappedDriver).EnabledResponse =
                enabled;
            ((FakeWebDriver)base.WrappedDriver).DisplayedResponse =
                displayed;
            ((FakeWebDriver)base.WrappedDriver).SelectedResponse =
                selected;
        }
        
        
        
        internal FakeWebElement DecoratedWebElement;
        internal List<ISearchHistory> SearchHistory { get; set; }
        internal void SetTagName(string tagName)
        {
            this.tagName = tagName;
Console.WriteLine("FakeRemoteWebElement: SetTagName: this.tagName = " + this.tagName);
Console.WriteLine("FakeRemoteWebElement: SetTagName: this.TagName = " + TagName);
        }
        internal void SetText(string text)
        {
            this.text = text;
Console.WriteLine("FakeRemoteWebElement: SetText: this.text = " + this.text);
Console.WriteLine("FakeRemoteWebElement: SetText: this.Text = " + Text);
        }
        internal void SetEnabled(bool enabled)
        {
            this.enabled = enabled;
        }
        internal void SetSelected(bool selected)
        {
            this.selected = selected;
        }
        internal void SetDipslayed(bool dipslayed)
        {
            displayed = dipslayed;
        }
        

        
        
        
        //public new string TagName
        public string TagName
        //public override string TagName
        {
            
            
            
            
            
            
            get { try { Console.WriteLine("FakeRemoteWebElement: TagName (prop) = " + tagName); return tagName; } catch (Exception eTagName) { Console.WriteLine(".TagName: " + eTagName.Message); return "tagname failed!!!!!!!!!!!!!!!!!!!!!!!!!!"; } }
        }
        public new string Text
        {
            
            
            
            
            
            get { Console.WriteLine("FakeRemoteWebElement: Text (prop) = " + text); return text; }
        }
        public new bool Enabled
        {
            get { return enabled; }
        }
        public new bool Selected
        {
            get { return selected; }
        }
        public new Point Location
        {
            get { return location; }
        }
        public new Size Size
        {
            get { return size; }
        }
        public new bool Displayed
        {
            get { return displayed; }
        }
        public new void Clear() { }
        public new void SendKeys(string text) { }
        public new void Submit() { }
        public new void Click() { }
        public new string GetAttribute(string attributeName) { return "attr"; }
        public new string GetCssValue(string propertyName) { return "css"; }
        
        
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
//        public ICoordinates Coordinates
//        {
//            get
//            {
//                return new FakeCoordinates(this); // this.DecoratedWebElement.Coordinates;
//            }
//        }
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
