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
    public class ReadSeWebDriverUrlCommandTestFixture
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

            ReadSeWebDriverUrlCommand cmdlet2 =
                //new ReadSeWebDriverUrlCommandTestFixture();
                WebDriverFactory.Container.Resolve<ReadSeWebDriverUrlCommand>();
            cmdlet2.InputObject =
                //new FakeWebDriver[]{ (CommonCmdletBase.UnitTestOutput[1] as FakeWebDriver) };
                new FakeWebDriver[]{ ((FakeWebDriver)(object)PSTestLib.UnitTestOutput.LastOutput) };
            SeReadWebDriverUrlCommand command2 =
                new SeReadWebDriverUrlCommand(cmdlet2);
            command2.Execute();
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Right_Web()
        {
            string url = @"http://google.com";
            enterUrl(url);
            Assert.AreEqual(
                url,
                //CommonCmdletBase.UnitTestOutput[2]);
                (string)(object)PSTestLib.UnitTestOutput.LastOutput);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Right_File()
        {
            string url = @"C:\1\1.txt";
            enterUrl(url);
            Assert.AreEqual(
                url,
                //CommonCmdletBase.UnitTestOutput[2]);
                (string)(object)PSTestLib.UnitTestOutput.LastOutput);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Wrong()
        {
            string url = "wrong url";
            enterUrl(url);
            Assert.AreEqual(
                url,
                //CommonCmdletBase.UnitTestOutput[2]);
                (string)(object)PSTestLib.UnitTestOutput.LastOutput);
        }
        
        [Test]
        [Category("Fast")]
        public void Url_Empty()
        {
            string url = string.Empty;
            enterUrl(url);
            Assert.AreEqual(
                url,
                //CommonCmdletBase.UnitTestOutput[2]);
                (string)(object)PSTestLib.UnitTestOutput.LastOutput);
        }
    }
}
