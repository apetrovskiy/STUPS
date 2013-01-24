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
    using OpenQA.Selenium.Remote;
    using System.Collections.Generic;
    using System.Linq;
    using Autofac;
    
    using Moq;
    
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
//Console.WriteLine("getElement: 00001");
            GetSeWebElementCommand cmdlet =
                WebDriverFactory.Container.Resolve<GetSeWebElementCommand>();
            cmdlet.Timeout = 1000;
//Console.WriteLine("getElement: 00002");
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
//Console.WriteLine("getElement: 00003");
            IWebDriver testDriver = null;
            IWebElement testElement = null;
            if (WebElementsFrom.WebDriver == typeFrom) {
//Console.WriteLine("getElement: 00004-1");
                testDriver =
                    WebDriverFactory.Container.Resolve<FakeWebDriver>();
//Console.WriteLine("getElement: 00004-2");
//Console.WriteLine(listOfElements.Count.ToString());
//Console.WriteLine(listOfElements[0].GetType().Name);
//Console.WriteLine(((FakeRemoteWebElement)listOfElements[0]).TagName);
//Console.WriteLine("getElement: 00004-3");

                ((FakeWebDriver)testDriver).SetElementsCollection(listOfElements);

//Console.WriteLine("getElement1:  " + ((FakeWebDriver)testDriver).Elements.Count.ToString());
//Console.WriteLine("getElement2:  " + ((FakeWebDriver)testDriver).Elements[0].GetType().Name);
//Console.WriteLine("getElement3:  " + ((FakeWebDriver)testDriver).Elements[0].ToString());
////Console.WriteLine("getElement4:  " + ((FakeWebDriver)testDriver).Elements[0].Text);
//Console.WriteLine("getElement4:  " + ((FakeRemoteWebElement)((FakeWebDriver)testDriver).Elements[0]).Text);
////Console.WriteLine("getElement5:  " + ((FakeWebDriver)testDriver).Elements[0].TagName);
//Console.WriteLine("getElement5:  " + ((FakeRemoteWebElement)((FakeWebDriver)testDriver).Elements[0]).TagName);
//Console.WriteLine("getElement6:  " + ((FakeRemoteWebElement)((FakeWebDriver)testDriver).Elements[1]).Text);
//Console.WriteLine("getElement7:  " + ((FakeRemoteWebElement)((FakeWebDriver)testDriver).Elements[1]).TagName);
                
//Console.WriteLine("getElement: 00004-3");
                cmdlet.InputObject = new object[]{ testDriver };
//Console.WriteLine("getElement: 00004-4");
            } else if (WebElementsFrom.WebElement == typeFrom) {
//Console.WriteLine("getElement: 00005-1");
                testElement =
                    //WebDriverFactory.Container.Resolve<FakeWebElement>(new PositionalParameter(0, null));
                    WebDriverFactory.Container.ResolveKeyed<FakeWebElement>(Constructors.FakeWebElement_NoParameters);
//Console.WriteLine("getElement: 00005-2");
                ((FakeWebElement)testElement).SetElementsCollection(listOfElements);
//Console.WriteLine("getElement: 00005-3");
                cmdlet.InputObject = new object[]{ testElement };
//Console.WriteLine("getElement: 00005-4");
            }
//Console.WriteLine("getElement: 00006");
            SeGetWebElementCommand command =
                new SeGetWebElementCommand(cmdlet);
            command.Execute();
//Console.WriteLine("getElement: 00007");
//if (null == SePSX.CommonCmdletBase.UnitTestOutput) {
//    Console.WriteLine("null == SePSX.CommonCmdletBase.UnitTestOutput");
//} else {
//    Console.WriteLine("null != SePSX.CommonCmdletBase.UnitTestOutput");
//}
//if (null == SePSX.CommonCmdletBase.UnitTestOutput[0]) {
//    Console.WriteLine("null == SePSX.CommonCmdletBase.UnitTestOutput[0]");
//} else {
//    Console.WriteLine("null != SePSX.CommonCmdletBase.UnitTestOutput[0]");
//}
//if (null == (SePSX.CommonCmdletBase.UnitTestOutput[0] as IWebElement)) {
//    Console.WriteLine("null == (SePSX.CommonCmdletBase.UnitTestOutput[0] as IWebElement)");
//} else {
//    Console.WriteLine("null != (SePSX.CommonCmdletBase.UnitTestOutput[0] as IWebElement)");
//}
//Console.WriteLine("(SePSX.CommonCmdletBase.UnitTestOutput[0] as IWebElement) = " + (SePSX.CommonCmdletBase.UnitTestOutput[0] as IWebElement).ToString());
Console.WriteLine("(IWebElement)(object)PSTestLib.UnitTestOutput[0]) = " + ((IWebElement)(object)PSTestLib.UnitTestOutput.LastOutput[0]).ToString());
//Console.WriteLine("Text (dec) = " + (SePSX.CommonCmdletBase.UnitTestOutput[0] as WebElementDecorator).Text);
Console.WriteLine("Text (dec) = " + ((WebElementDecorator)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Text);
//Console.WriteLine("text (fake remote) = " + (SePSX.CommonCmdletBase.UnitTestOutput[0] as FakeRemoteWebElement).Text);
//Console.WriteLine("TagName (dec) = " + (SePSX.CommonCmdletBase.UnitTestOutput[0] as WebElementDecorator).TagName);
Console.WriteLine("TagName (dec) = " + ((WebElementDecorator)(object)PSTestLib.UnitTestOutput.LastOutput[0]).TagName);
//Console.WriteLine("tagName = " + (SePSX.CommonCmdletBase.UnitTestOutput[0] as FakeRemoteWebElement).TagName);
            //return (SePSX.CommonCmdletBase.UnitTestOutput[0] as IWebElement);
            //return (SePSX.CommonCmdletBase.UnitTestOutput[0] as FakeWebElement);
            //return (SePSX.CommonCmdletBase.UnitTestOutput[0] as FakeRemoteWebElement);
            return ((FakeRemoteWebElement)(object)PSTestLib.UnitTestOutput.LastOutput[0]);
        }
        
//        private RemoteWebElement getRemoteWebElement(
//            string tagName,
//            string text,
//            bool enabled,
//            bool displayed,
//            bool selected)
//        {
//            var remoteWebElementMock = new Mock<RemoteWebElement>();
//            //remoteWebElementMock.Setup(t => t.TagName).Returns(tagName);
//            remoteWebElementMock.SetupProperty(t => t.TagName, tagName);
//            //remoteWebElementMock.Setup(t => t.Text).Returns(text);
//            remoteWebElementMock.SetupProperty(t => t.Text, text);
//            //remoteWebElementMock.Setup(t => t.Enabled).Returns(enabled);
//            //remoteWebElementMock.Setup(t => t.Displayed).Returns(displayed);
//            //remoteWebElementMock.Setup(t => t.Selected).Returns(selected);
//                                                                  
//            return remoteWebElementMock.Object;
//        }
        
        [Test]
        [Category("Fast")]
        [Category("Get_SeWebElement")]
        public void WebDriverInput_Element_TagName()
        {
            string expectedValue = "a";
            List<IWebElement> listOfElements =
                new List<IWebElement>();
//            //listOfElements.Add(new FakeWebElement(expectedValue, "aaa"));
//            listOfElements.Add(
//                WebDriverFactory.Container.ResolveKeyed<IWebElement>(
//                    Constructors.FakeWebElement_TagName_Text,
//                    new Autofac.Core.Parameter[] {
//                        new NamedParameter("tagName", expectedValue),
//                        new NamedParameter("text", "aaa")
//                    }));
//            //listOfElements.Add(new FakeWebElement("input", "iii"));
//            listOfElements.Add(
//                WebDriverFactory.Container.ResolveKeyed<IWebElement>(
//                    Constructors.FakeWebElement_TagName_Text,
//                    new Autofac.Core.Parameter[] {
//                        new NamedParameter("tagName", "input"),
//                        new NamedParameter("text", "iii")
//                    }));
            
//            listOfElements.Add(
//                new FakeRemoteWebElement((RemoteWebDriver)CurrentData.CurrentWebDriver, "01"));
//            listOfElements.Add(
//                new FakeRemoteWebElement((RemoteWebDriver)CurrentData.CurrentWebDriver, "02"));
                
Console.WriteLine("00000000000000000000000000001");

            FakeRemoteWebElement fake01 =
                //new FakeRemoteWebElement((RemoteWebDriver)CurrentData.CurrentWebDriver, "01");
                new FakeRemoteWebElement(
                    //new RemoteWebDriver(new FakeCapabilities()),
                    (RemoteWebDriver)null,
                    "01");
//                new FakeRemoteWebElement(
//                    WebDriverFactory.Container.Resolve<FakeRemoteWebDriver>(
//                        new Autofac.NamedParameter("remoteAddress", new Uri(@"file:///C/")),
//                        new Autofac.NamedParameter("desiredCapabilities", new FakeCapabilities())),
//                    "01");
            fake01.Init();
            fake01.SetTagName(expectedValue);
            fake01.SetText("aaa");
            listOfElements.Add(fake01);

            
//            RemoteWebElement fake01 =
//                //new RemoteWebElement((RemoteWebDriver)CurrentData.CurrentWebDriver, "01");
//                new RemoteWebElement(
//                    new FakeRemoteWebDriver(new Uri(@"file:///C"), new FakeCapabilities()),
//                    "01");
//Console.WriteLine("00000000000000000000000000001-1");
//if (null == CurrentData.CurrentWebDriver) {
//    Console.WriteLine("null == CurrentData.CurrentWebDriver");
//} else {
//    Console.WriteLine("null != CurrentData.CurrentWebDriver");
//}
//Console.WriteLine(fake01.WrappedDriver.ToString());
//            
//            ((FakeWebDriver)fake01.WrappedDriver).TagNameResponse =
//                expectedValue;
//            
//Console.WriteLine("00000000000000000000000000001-2");
//            
//            ((FakeWebDriver)fake01.WrappedDriver).TextResponse =
//                "aaa";
//Console.WriteLine("00000000000000000000000000001-3");
//            
//            listOfElements.Add(fake01);
            
//            listOfElements.Add(
//                getRemoteWebElement(
//                    expectedValue,
//                    "aaa",
//                    true,
//                    true,
//                    true));

Console.WriteLine("00000000000000000000000000002");

Console.WriteLine("((FakeRemoteWebElement)listOfElements[0]).TagName = " + ((FakeRemoteWebElement)listOfElements[0]).TagName);
//Console.WriteLine("((RemoteWebElement)listOfElements[0]).TagName = " + ((RemoteWebElement)listOfElements[0]).TagName);
//Console.WriteLine("((RemoteWebElement)listOfElements[0]).TagName = " + ((RemoteWebElement)listOfElements[0]).TagName);
//Console.WriteLine("listOfElements[0].TagName = " + listOfElements[0].TagName);
            
            FakeRemoteWebElement fake02 =
                //new FakeRemoteWebElement((RemoteWebDriver)CurrentData.CurrentWebDriver, "02");
                new FakeRemoteWebElement(
                    //new RemoteWebDriver(new FakeCapabilities()),
                    (RemoteWebDriver)null,
                    "02");
            fake02.Init();
            fake02.SetTagName("input");
            fake02.SetText("iii");
            listOfElements.Add(fake02);

Console.WriteLine("00000000000000000000000000003");
//            
//            RemoteWebElement fake02 =
//                //new RemoteWebElement((RemoteWebDriver)CurrentData.CurrentWebDriver, "02");
//                new RemoteWebElement(
//                    new FakeRemoteWebDriver(new Uri(@"file:///C"), new FakeCapabilities()),
//                    "02");
//            ((FakeWebDriver)fake02.WrappedDriver).TagNameResponse =
//                "input";
//            ((FakeWebDriver)fake02.WrappedDriver).TextResponse =
//                "iii";
//            listOfElements.Add(fake02);
//            
//Console.WriteLine("00000000000000000000000000004");
            
//            listOfElements.Add(
//                getRemoteWebElement(
//                    "input",
//                    "iii",
//                    true,
//                    true,
//                    true));
            
Console.WriteLine("((FakeRemoteWebElement)listOfElements[0]).Text = " + ((FakeRemoteWebElement)listOfElements[0]).Text);
//Console.WriteLine("((RemoteWebElement)listOfElements[0]).Text = " + ((RemoteWebElement)listOfElements[0]).Text);
                
            
//            try {
//                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
//                try {
//                    var aaa = getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue);
//                    if (null == aaa) {
//                        Console.WriteLine("WebDriverInput_Element_TagName: null == aaa");
//                    } else {
//                        Console.WriteLine("WebDriverInput_Element_TagName: null != aaa");
//                        Console.WriteLine(aaa.GetType().Name);
//                    }
//                }
//                catch (Exception e00000000001) {
//                    Console.WriteLine("WebDriverInput_Element_TagName: e00000000001: " + e00000000001.Message);
//                    Console.WriteLine("WebDriverInput_Element_TagName: e00000000001: " + e00000000001.GetType().Name);
//                }
//                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!2!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
//                try {
//                    var bbb = (getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue)).TagName;
//                    if (null == bbb) {
//                        Console.WriteLine("WebDriverInput_Element_TagName: null == bbb");
//                    } else {
//                        Console.WriteLine("WebDriverInput_Element_TagName: null != bbb");
//                        Console.WriteLine(bbb.GetType().Name);
//                    }
//                }
//                catch (Exception e00000000002) {
//                    Console.WriteLine("WebDriverInput_Element_TagName: e00000000002: " + e00000000002.Message);
//                    Console.WriteLine("WebDriverInput_Element_TagName: e00000000002: " + e00000000002.GetType().Name);
//                }
//                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!3!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
//            }
//            catch (Exception erty) {
//                Console.WriteLine("WebDriverInput_Element_TagName: erty: " + erty.Message);
//                Console.WriteLine("WebDriverInput_Element_TagName: erty: " + erty.GetType().Name);
//            }
            
            try {
                
Console.WriteLine(@"///////////////////////////////////1///////////////////////////////////");
                //FakeRemoteWebElement webElDec =
                var webElDec =
                    //(FakeRemoteWebElement)getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue);
                    (WebElementDecorator)getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue);
Console.WriteLine(@"///////////////////////////////////2///////////////////////////////////");
if (null == webElDec) {
    Console.WriteLine("null == webElDec");
} else {
    Console.WriteLine("null != webElDec");
    if (null == expectedValue) {
        Console.WriteLine("null == expectedValue");
    } else {
        Console.WriteLine("null != expectedValue");
    }
    if (null == webElDec.DecoratedWebElement) {
        Console.WriteLine("null == webElDec.DecoratedWebElement");
    } else {
        Console.WriteLine("null != webElDec.DecoratedWebElement");
    }
    if (null == webElDec.TagName) {
        Console.WriteLine("null == webElDec.TagName");
    } else {
        Console.WriteLine("null != webElDec.TagName");
    }
}
              
Console.WriteLine("<<<<<<<<<<<===================before result=========================>>>>>>>>>>>>>>>>>>");
              
//            Assert.AreEqual<string>(
//                expectedValue,
//                ((FakeRemoteWebElement)(getElement(WebElementsFrom.WebDriver, listOfElements, FindElementParameters.ByTagName, expectedValue))).TagName);

//Console.WriteLine("after result");

            Assert.AreEqual<string>(
                    expectedValue,
                    webElDec.TagName);
                    
Console.WriteLine("<<<<<<<<<<<<<<<!!!!!!!!!!!!!!!!!!!!!!after result!!!!!!!!!!!!!!!!!!!!!!!>>>>>>>>>>>>>>>>>");
            
            }
            catch (Exception eOnAreEqual) {
                Console.WriteLine("WebDriverInput_Element_TagName: on areEgual: " + eOnAreEqual.Message);
                Console.WriteLine("WebDriverInput_Element_TagName: on areEgual: " + eOnAreEqual.GetType().Name);
            }
            
        }
        
//        [Test]
//        [Category("Fast")]
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
//        [Category("Fast")]
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
//        [Category("Fast")]
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
