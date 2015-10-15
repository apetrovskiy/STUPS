//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Text;
//namespace OpenQA.Selenium.Support.UI
namespace SePSXUnitTests
{
    using System.Collections.Generic;
    using OpenQA.Selenium;

    public interface ISelectElement
    {
        void SelectByText(string text);
        void SelectByValue(string value);
        void SelectByIndex(int index);
        void DeselectAll();
        void DeselectByText(string text);
        void DeselectByValue(string value);
        void DeselectByIndex(int index);
        //bool IsMultiple { get; private set; }
        bool IsMultiple { get; }
        IList<IWebElement> Options { get; }
        IWebElement SelectedOption { get; }
        IList<IWebElement> AllSelectedOptions { get; }
    }
}
