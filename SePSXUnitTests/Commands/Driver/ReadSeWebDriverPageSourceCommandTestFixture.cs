/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/30/2012
 * Time: 8:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver
{
    using System;
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using PSTestLib;
    using OpenQA.Selenium;
    using Autofac;
    
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class ReadSeWebDriverPageSourceCommandTestFixture
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
        
        private void enterUrl(string url)
        {
            StartSeChromeCommand cmdlet0 =
                //new StartSeChromeCommandTestFixture();
                WebDriverFactory.Container.Resolve<StartSeChromeCommand>();
            SeStartChromeCommand command0 =
                new SeStartChromeCommand(cmdlet0);
            command0.Execute();

            EnterSeURLCommand cmdlet1 =
                //new EnterSeURLCommandTestFixture();
                WebDriverFactory.Container.Resolve<EnterSeURLCommand>();
            cmdlet1.InputObject =
                new FakeWebDriver[]{ (CommonCmdletBase.UnitTestOutput[0] as FakeWebDriver) };
            cmdlet1.URL = url;
            SeEnterURLCommand command1 =
                new SeEnterURLCommand(cmdlet1);
            command1.Execute();

            ReadSeWebDriverPageSourceCommand cmdlet2 =
                //new ReadSeWebDriverPageSourceCommandTestFixture();
                WebDriverFactory.Container.Resolve<ReadSeWebDriverPageSourceCommand>();
            cmdlet2.InputObject =
                new FakeWebDriver[]{ (CommonCmdletBase.UnitTestOutput[1] as FakeWebDriver) };
            SeReadWebDriverPageSourceCommand command2 =
                new SeReadWebDriverPageSourceCommand(cmdlet2);
            command2.Execute();
        }
        
        [Test]
        public void Url_Right_Web_in_PageSource()
        {
            string url = @"http://google.com";
            enterUrl(url);
            Assert.Contains(
                (CommonCmdletBase.UnitTestOutput[2] as string),
                url);
        }
        
        [Test]
        public void Url_Right_File_in_PageSource()
        {
            string url = @"C:\1\1.txt";
            enterUrl(url);
            Assert.Contains(
                (CommonCmdletBase.UnitTestOutput[2] as string),
                url);
        }
        
        [Test]
        public void Url_Wrong_in_PageSource()
        {
            string url = "wrong url";
            enterUrl(url);
            Assert.Contains(
                (CommonCmdletBase.UnitTestOutput[2] as string),
                url);
        }
        
        [Test]
        public void Url_Empty_in_PageSource()
        {
            string url = string.Empty;
            enterUrl(url);
            Assert.Contains(
                (CommonCmdletBase.UnitTestOutput[2] as string),
                url);
        }
    }
}
