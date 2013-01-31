/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2012
 * Time: 3:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Navigation
{
    using System;
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using PSTestLib;
    using OpenQA.Selenium;
    using Autofac;
    
    /// <summary>
    /// Description of InvokeSeNavigateBackCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class InvokeSeNavigateBackCommandTestFixture
    {
        public InvokeSeNavigateBackCommandTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
            FakeNavigation.previousUrl = string.Empty;
            FakeNavigation.previousTitle = string.Empty;
            FakeNavigation.previousPageSource = string.Empty;
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        private void enterUrl(string firstUrl, string secondUrl)
        {
            StartSeChromeCommand cmdlet0 =
                WebDriverFactory.Container.Resolve<StartSeChromeCommand>();

            SeStartChromeCommand command0 =
                new SeStartChromeCommand(cmdlet0);

            command0.Execute();

            EnterSeURLCommand cmdlet1 =
                WebDriverFactory.Container.Resolve<EnterSeURLCommand>();

            cmdlet1.InputObject =
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]) };

            cmdlet1.URL = firstUrl;
            SeEnterURLCommand command1 =
                new SeEnterURLCommand(cmdlet1);

            command1.Execute();

            EnterSeURLCommand cmdlet2 =
                WebDriverFactory.Container.Resolve<EnterSeURLCommand>();
            cmdlet2.InputObject =
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]) };
            cmdlet2.URL = secondUrl;
            SeEnterURLCommand command2 =
                new SeEnterURLCommand(cmdlet2);
            command2.Execute();

            InvokeSeNavigateBackCommand cmdlet3 =
                WebDriverFactory.Container.Resolve<InvokeSeNavigateBackCommand>();
            cmdlet3.InputObject =
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]) };
            SeInvokeNavigateBackCommand command3 =
                new SeInvokeNavigateBackCommand(cmdlet3);
            command3.Execute();
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Right_Web()
        {
            string secondUrl = @"http://google.com";
            string firstUrl = @"http://yahoo.com";
            enterUrl(firstUrl, secondUrl);
            Assert.AreEqual(
                firstUrl,
                ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Url);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Right_File()
        {
            string secondUrl = @"C:\1\1.txt";
            string firstUrl = @"C:\2\2.doc";
            enterUrl(firstUrl, secondUrl);
            Assert.AreEqual(
                firstUrl,
                ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Url);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Wrong()
        {
            string secondUrl = "wrong url";
            string firstUrl = @"broken url";
            enterUrl(firstUrl, secondUrl);
            Assert.AreEqual(
                firstUrl,
                ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Url);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Empty()
        {
            string secondUrl = string.Empty;
            string firstUrl = string.Empty;
            enterUrl(firstUrl, secondUrl);
            Assert.AreEqual(
                firstUrl,
                ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Url);
        }
    }
}
