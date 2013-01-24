/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/22/2012
 * Time: 4:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    using System;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of FakeSelectElement.
    /// </summary>
    public class FakeSelectElement : OpenQA.Selenium.Support.UI.SelectElement //: ISelectElement
    {
        public FakeSelectElement(IWebElement element) : base (element)
        {
        }
        
        public bool IsMultiple {
            get {
                throw new NotImplementedException();
            }
        }
        
        public System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> Options {
            get {
                throw new NotImplementedException();
            }
        }
        
        public OpenQA.Selenium.IWebElement SelectedOption {
            get {
                throw new NotImplementedException();
            }
        }
        
        public System.Collections.Generic.IList<OpenQA.Selenium.IWebElement> AllSelectedOptions {
            get {
                throw new NotImplementedException();
            }
        }
        
        public void SelectByText(string text)
        {
            throw new NotImplementedException();
        }
        
        public void SelectByValue(string value)
        {
            throw new NotImplementedException();
        }
        
        public void SelectByIndex(int index)
        {
            throw new NotImplementedException();
        }
        
        public void DeselectAll()
        {
            throw new NotImplementedException();
        }
        
        public void DeselectByText(string text)
        {
            throw new NotImplementedException();
        }
        
        public void DeselectByValue(string value)
        {
            throw new NotImplementedException();
        }
        
        public void DeselectByIndex(int index)
        {
            throw new NotImplementedException();
        }
    }
}
