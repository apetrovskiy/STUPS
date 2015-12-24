/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/8/2012
 * Time: 9:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Select
{
    using MbUnit.Framework;
    //using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Moq;
//    using System.Drawing;
//    using System.Collections.ObjectModel;

    /// <summary>
    /// Description of SetSeSelectionCommandTestFixture.
    /// </summary>
    public class SetSeSelectionCommandTestFixture
    {
        public SetSeSelectionCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
        }
        
        private SelectElement setSelectionByIndex(IWebElement webElement, System.Collections.Generic.List<string> selectionItemValues, int index)
        {
            var mock = new Mock<ISelectElement>();
            mock.Setup(element => element.SelectByIndex(index));
            mock.Setup(element => element.SelectedOption).Returns(() => (new FakeWebElement("option", selectionItemValues[index].ToString())));
            SelectElement selectElement = (SelectElement)mock.Object;
            return selectElement;
        }
        
        private SelectElement setSelectionByValue(IWebElement webElement, System.Collections.Generic.List<string> selectionItemValues, string strValue)
        {
            var mock = new Mock<ISelectElement>();
            mock.Setup(element => element.SelectByValue(strValue));
            mock.Setup(element => element.SelectedOption).Returns(() => (new FakeWebElement("option", strValue)));
            SelectElement selectElement = (SelectElement)mock.Object;
            return selectElement;
        }
        
        private SelectElement setSelectionByText(IWebElement webElement, System.Collections.Generic.List<string> selectionItemTexts, string strText)
        {
            var mock = new Mock<ISelectElement>();
            mock.Setup(element => element.SelectByText(strText));
            mock.Setup(element => element.SelectedOption).Returns(() => (new FakeWebElement("option", strText)));
            SelectElement selectElement = (SelectElement)mock.Object;
            return selectElement;
        }
        

        
        [Test] //[Test(Description="test of SelectElement.SelectByIndex")]
        [Category("Fast")]
        [Ignore]
        public void WebElement_Null()
        {
            setSelectionByIndex(null, null, 0);
            
            Assert.Fail("not implemented");
        }
        
        [Test] //[Test(Description="test of SelectElement.SelectByIndex")]
        [Category("Fast")]
        [Ignore]
        public void WebElement_Not_Null_Select_0_items_SelectByIndex_0()
        {
            IWebElement element = new FakeWebElement("select", "text");
            setSelectionByIndex(element, null, 0);
            
            Assert.Fail("not implemented");
        }
        
        [Test] //[Test(Description="test of SelectElement.SelectByIndex")]
        [Category("Fast")]
        [Ignore]
        public void WebElement_Not_Null_Select_1_itemSelectByIndex_1()
        {
            IWebElement element = new FakeWebElement("select", "text");
            System.Collections.Generic.List<string> selectItems = 
                new System.Collections.Generic.List<string>();
            selectItems.Add("item1");
            setSelectionByIndex(element, selectItems, 1);
            
            Assert.Fail("not implemented");
        }
        
        [Test] //(Description="test of SelectElement.SelectByIndex")]
        [Category("Fast")]
        [Ignore]
        public void WebElement_Not_Null_Select_2_itemsSelectByIndex_0()
        {
            Assert.Fail("not implemented");
        }
        
        [Test] //(Description="test of SelectElement.SelectByIndex")]
        [Category("Fast")]
        [Ignore]
        public void WebElement_Not_Null_Select_2_itemsSelectByIndex_1()
        {
            Assert.Fail("not implemented");
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            //Settings.CleanUpRecordingCollection();
        }
    }
}
