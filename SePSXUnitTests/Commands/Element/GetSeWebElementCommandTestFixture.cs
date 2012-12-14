/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 8:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Element
{
    using System;
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using PSTestLib;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;
    using Autofac;
    
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class GetSeWebElementCommandTestFixture
    {
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        private IWebElement getElement(
            WebElementsFrom typeFrom,
            List<IWebElement> listOfElements,
            FindElementParameters searchType,
            string searchValue)
        {
Console.WriteLine("getElement: 00001");
            GetSeWebElementCommand cmdlet =
                WebDriverFactory.Container.Resolve<GetSeWebElementCommand>();
            cmdlet.Timeout = 1000;
Console.WriteLine("getElement: 00002");
            switch (searchType) {
                case FindElementParameters.ById:
                    cmdlet.Id = searchValue;
                    break;
                case FindElementParameters.ByClassName:
                    cmdlet.ClassName = searchValue;
                    break;
                case FindElementParameters.ByTagName:
                    cmdlet.TagName = searchValue;
                    break;
                case FindElementParameters.ByName:
                    cmdlet.Name = searchValue;
                    break;
                case FindElementParameters.ByLinkText:
                    cmdlet.LinkText = searchValue;
                    break;
                case FindElementParameters.ByPartialLinkText:
                    cmdlet.PartialLinkText = searchValue;
                    break;
                case FindElementParameters.ByCSS:
                    cmdlet.CssSelector = searchValue;
                    break;
                case FindElementParameters.ByXPath:
                    cmdlet.XPath = searchValue;
                    break;
                case FindElementParameters.ByJavaScript:
                    throw new Exception("JS! ... Invalid value for FindElementParameters");
                    break;
                default:
                    throw new Exception("Invalid value for FindElementParameters");
            }
Console.WriteLine("getElement: 00003");
            IWebDriver testDriver = null;
            IWebElement testElement = null;
            if (WebElementsFrom.WebDriver == typeFrom) {
Console.WriteLine("getElement: 00004-1");
                testDriver =
                    WebDriverFactory.Container.Resolve<FakeWebDriver>();
Console.WriteLine("getElement: 00004-2");
                ((FakeWebDriver)testDriver).SetElementsCollection(listOfElements);
Console.WriteLine("getElement: 00004-3");
                cmdlet.InputObject = new object[]{ testDriver };
Console.WriteLine("getElement: 00004-4");
            } else if (WebElementsFrom.WebElement == typeFrom) {
Console.WriteLine("getElement: 00005-1");
                testElement =
                    //WebDriverFactory.Container.Resolve<FakeWebElement>(new PositionalParameter(0, null));
                    WebDriverFactory.Container.ResolveKeyed<FakeWebElement>(Constructors.FakeWebElement_NoParameters);
Console.WriteLine("getElement: 00005-2");
                ((FakeWebElement)testElement).SetElementsCollection(listOfElements);
Console.WriteLine("getElement: 00005-3");
                cmdlet.InputObject = new object[]{ testElement };
Console.WriteLine("getElement: 00005-4");
            }
Console.WriteLine("getElement: 00006");
            SeGetWebElementCommand command =
                new SeGetWebElementCommand(cmdlet);
            command.Execute();
Console.WriteLine("getElement: 00007");
            return (SePSX.CommonCmdletBase.UnitTestOutput[0] as IWebElement);
        }
        
        [Test]
        [Category("Get_SeWebElement")]
        public void WebDriverInput_Element_TagName()
        {
            string expectedValue = "a";
            List<IWebElement> listOfElements =
                new List<IWebElement>();
            //listOfElements.Add(new FakeWebElement(expectedValue, "aaa"));
            listOfElements.Add(
                WebDriverFactory.Container.ResolveKeyed<IWebElement>(
                    Constructors.FakeWebElement_TagName_Text,
                    new Autofac.Core.Parameter[] {
                        new NamedParameter("tagName", expectedValue),
                        new NamedParameter("text", "aaa")
                    }));
            //listOfElements.Add(new FakeWebElement("input", "iii"));
            listOfElements.Add(
                WebDriverFactory.Container.ResolveKeyed<IWebElement>(
                    Constructors.FakeWebElement_TagName_Text,
                    new Autofac.Core.Parameter[] {
                        new NamedParameter("tagName", "input"),
                        new NamedParameter("text", "iii")
                    }));
            Assert.AreEqual<string>(
                expectedValue,
                (getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue)).TagName);
        }
        
//        [Test]
//        public void WebDriverInput_Element_Id()
//        {
//            string expectedValue = "a";
//            List<IWebElement> listOfElements =
//                new List<IWebElement>();
//            listOfElements.Add(new FakeWebElement((expectedValue, "aaa"));
//            listOfElements.Add(new FakeWebElement("input", "iii"));
//            Assert.AreEqual<string>(
//                expectedValue,
//                getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue));
//        }
        
//        [Test]
//        public void WebDriverInput_Element_Name()
//        {
//            string expectedValue = "a";
//            List<IWebElement> listOfElements =
//                new List<IWebElement>();
//            listOfElements.Add(new FakeWebElement(expectedValue, "aaa"));
//            listOfElements.Add(new FakeWebElement("input", "iii"));
//            Assert.AreEqual<string>(
//                expectedValue,
//                getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue));
//        }
        
//        [Test]
//        public void WebDriverInput_Element_ClassName()
//        {
//            string expectedValue = "a";
//            List<IWebElement> listOfElements =
//                new List<IWebElement>();
//            listOfElements.Add(new FakeWebElement(expectedValue, "aaa"));
//            listOfElements.Add(new FakeWebElement("input", "iii"));
//            Assert.AreEqual<string>(
//                expectedValue,
//                getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue));
//        }












        [Test]
        [Category("Get-SeWebElement")]
        public void WebElementInput_Element_TagName()
        {
            string expectedValue = "a";
            List<IWebElement> listOfElements =
                new List<IWebElement>();
            listOfElements.Add(new FakeWebElement(expectedValue, "aaa"));
            listOfElements.Add(new FakeWebElement("input", "iii"));
            Assert.AreEqual<string>(
                expectedValue,
                (getElement(WebElementsFrom.WebElement, listOfElements, FindElementParameters.ByTagName, expectedValue)).TagName);
        }
    }
}
