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
                //new StartSeChromeCommandTestFixture();
                WebDriverFactory.Container.Resolve<StartSeChromeCommand>();
//Console.WriteLine("0000000000000000000--0001");
            SeStartChromeCommand command0 =
                new SeStartChromeCommand(cmdlet0);
//Console.WriteLine("0000000000000000000--0002");
                //WebDriverFactory.Container.Resolve<SeStartChromeCommand>();
            command0.Execute();
//Console.WriteLine("0000000000000000000--0003");
            EnterSeURLCommand cmdlet1 =
                //new EnterSeURLCommandTestFixture();
                WebDriverFactory.Container.Resolve<EnterSeURLCommand>();
//Console.WriteLine("0000000000000000000--0004");
            cmdlet1.InputObject =
                //new FakeWebDriver[]{ (CommonCmdletBase.UnitTestOutput[0] as FakeWebDriver) };
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]) };
//Console.WriteLine("0000000000000000000--0005");
            cmdlet1.URL = firstUrl;
            SeEnterURLCommand command1 =
                new SeEnterURLCommand(cmdlet1);
//Console.WriteLine("0000000000000000000--0006");
            command1.Execute();
Console.WriteLine("after the first EnterURL");
//Console.WriteLine((CommonCmdletBase.UnitTestOutput[1] as FakeWebDriver).Url);
Console.WriteLine(((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Url);
Console.WriteLine("after the first EnterURL, saved");
//Console.WriteLine((CommonCmdletBase.UnitTestOutput[1] as FakeWebDriver)._url);
Console.WriteLine(((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0])._url);
            EnterSeURLCommand cmdlet2 =
                //new EnterSeURLCommandTestFixture();
                WebDriverFactory.Container.Resolve<EnterSeURLCommand>();
            cmdlet2.InputObject =
                //new FakeWebDriver[]{ (CommonCmdletBase.UnitTestOutput[1] as FakeWebDriver) };
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]) };
            cmdlet2.URL = secondUrl;
            SeEnterURLCommand command2 =
                new SeEnterURLCommand(cmdlet2);
            command2.Execute();
Console.WriteLine("after the second EnterURL");
//Console.WriteLine((CommonCmdletBase.UnitTestOutput[2] as FakeWebDriver).Url);
Console.WriteLine(((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Url);
Console.WriteLine("after the second EnterURL, saved");
//Console.WriteLine((CommonCmdletBase.UnitTestOutput[2] as FakeWebDriver)._url);
Console.WriteLine(((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0])._url);
            InvokeSeNavigateBackCommand cmdlet3 =
                //new InvokeSeNavigateBackCommandTestFixture();
                WebDriverFactory.Container.Resolve<InvokeSeNavigateBackCommand>();
            cmdlet3.InputObject =
                //new FakeWebDriver[]{ (CommonCmdletBase.UnitTestOutput[2] as FakeWebDriver) };
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]) };
            SeInvokeNavigateBackCommand command3 =
                new SeInvokeNavigateBackCommand(cmdlet3);
            command3.Execute();
Console.WriteLine("after the third EnterURL");
//Console.WriteLine((CommonCmdletBase.UnitTestOutput[3] as FakeWebDriver).Url);
Console.WriteLine(((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Url);
Console.WriteLine("after the third EnterURL, saved");
//Console.WriteLine((CommonCmdletBase.UnitTestOutput[3] as FakeWebDriver)._url);
Console.WriteLine(((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0])._url);
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
                //((FakeWebDriver)CommonCmdletBase.UnitTestOutput[3]).Url);
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
                //((FakeWebDriver)CommonCmdletBase.UnitTestOutput[3]).Url);
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
                //((FakeWebDriver)CommonCmdletBase.UnitTestOutput[3]).Url);
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
                //((FakeWebDriver)CommonCmdletBase.UnitTestOutput[3]).Url);
                ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Url);
        }
    }
}
