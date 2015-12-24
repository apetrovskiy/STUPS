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
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using System.Collections.Generic;
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
            GetSeWebElementCommand cmdlet =
                WebDriverFactory.Container.Resolve<GetSeWebElementCommand>();
            cmdlet.Timeout = 1000;

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
                case FindElementParameters.ByCss:
                    cmdlet.CssSelector = searchValue;
                    break;
                case FindElementParameters.ByXPath:
                    cmdlet.XPath = searchValue;
                    break;
                case FindElementParameters.ByJavaScript:
                    throw new Exception("JS! ... Invalid value for FindElementParameters");
                    //break;
                default:
                    throw new Exception("Invalid value for FindElementParameters");
            }

            IWebDriver testDriver = null;
            IWebElement testElement = null;
            if (WebElementsFrom.WebDriver == typeFrom) {

                testDriver =
                    WebDriverFactory.Container.Resolve<FakeWebDriver>();

                ((FakeWebDriver)testDriver).SetElementsCollection(listOfElements);

                cmdlet.InputObject = new object[]{ testDriver };

            } else if (WebElementsFrom.WebElement == typeFrom) {

                testElement =
                    WebDriverFactory.Container.ResolveKeyed<FakeWebElement>(Constructors.FakeWebElementNoParameters);

                ((FakeWebElement)testElement).SetElementsCollection(listOfElements);

                cmdlet.InputObject = new object[]{ testElement };

            }

            SeGetWebElementCommand command =
                new SeGetWebElementCommand(cmdlet);
            command.Execute();

            return ((FakeRemoteWebElement)(object)PSTestLib.UnitTestOutput.LastOutput[0]);
        }
        
        [Test]
        [Category("Fast")]
        [Category("Get_SeWebElement")]
        public void WebDriverInput_Element_TagName()
        {
            string expectedValue = "a";
            List<IWebElement> listOfElements =
                new List<IWebElement>();

            FakeRemoteWebElement fake01 =
                new FakeRemoteWebElement(
                    (RemoteWebDriver)null,
                    "01");

            fake01.Init();
            fake01.SetTagName(expectedValue);
            fake01.SetText("aaa");
            listOfElements.Add(fake01);
            
            FakeRemoteWebElement fake02 =
                new FakeRemoteWebElement(
                    (RemoteWebDriver)null,
                    "02");
            fake02.Init();
            fake02.SetTagName("input");
            fake02.SetText("iii");
            listOfElements.Add(fake02);
            
            try {
                
                var webElDec =
                    (WebElementDecorator)getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue);

            Assert.AreEqual<string>(
                    expectedValue,
                    webElDec.TagName);
            
            }
            catch (Exception eOnAreEqual) {
                Console.WriteLine("WebDriverInput_Element_TagName: on areEgual: " + eOnAreEqual.Message);
                Console.WriteLine("WebDriverInput_Element_TagName: on areEgual: " + eOnAreEqual.GetType().Name);
            }
            
        }
        





        [Test]
        [Category("Fast")]
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
