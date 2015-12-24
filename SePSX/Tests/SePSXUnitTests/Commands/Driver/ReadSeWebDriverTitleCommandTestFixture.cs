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
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using Autofac;
    
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class ReadSeWebDriverTitleCommandTestFixture
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

            EnterSeUrlCommand cmdlet1 =
                //new EnterSeURLCommandTestFixture();
                WebDriverFactory.Container.Resolve<EnterSeUrlCommand>();
            cmdlet1.InputObject =
                //new FakeWebDriver[]{ (CommonCmdletBase.UnitTestOutput[0] as FakeWebDriver) };
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput) };
            cmdlet1.Url = url;
            SeEnterUrlCommand command1 =
                new SeEnterUrlCommand(cmdlet1);
            command1.Execute();

            ReadSeWebDriverTitleCommand cmdlet2 =
                //new ReadSeWebDriverTitleCommandTestFixture();
                WebDriverFactory.Container.Resolve<ReadSeWebDriverTitleCommand>();
            cmdlet2.InputObject =
                //new FakeWebDriver[]{ (CommonCmdletBase.UnitTestOutput[1] as FakeWebDriver) };
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput) };
            SeReadWebDriverTitleCommand command2 =
                new SeReadWebDriverTitleCommand(cmdlet2);
            command2.Execute();
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Right_Web_in_Title()
        {
            string url = @"http://google.com";
            enterUrl(url);
            Assert.Contains(
                //(CommonCmdletBase.UnitTestOutput[2] as string),
                (string)(object)PSTestLib.UnitTestOutput.LastOutput,
                url);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Right_File_in_Title()
        {
            string url = @"C:\1\1.txt";
            enterUrl(url);
            Assert.Contains(
                //(CommonCmdletBase.UnitTestOutput[2] as string),
                (string)(object)PSTestLib.UnitTestOutput.LastOutput,
                url);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Wrong_in_Title()
        {
            string url = "wrong url";
            enterUrl(url);
            Assert.Contains(
                //(CommonCmdletBase.UnitTestOutput[2] as string),
                (string)(object)PSTestLib.UnitTestOutput.LastOutput,
                url);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Empty_in_Title()
        {
            string url = string.Empty;
            enterUrl(url);
            Assert.Contains(
                //(CommonCmdletBase.UnitTestOutput[2] as string),
                (string)(object)PSTestLib.UnitTestOutput.LastOutput,
                url);
        }
    }
}
