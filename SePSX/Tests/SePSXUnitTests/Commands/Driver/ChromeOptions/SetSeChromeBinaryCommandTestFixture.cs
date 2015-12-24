/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/28/2012
 * Time: 9:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver.ChromeOptions
{
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using Autofac;
    
    /// <summary>
    /// Description of SetSeChromeBinaryCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class SetSeChromeBinaryCommandTestFixture
    {
        public SetSeChromeBinaryCommandTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        [Category("Fast")]
        public void ChromeOptions_add_binary_location_first()
        {
            string expected = "path1";
            SetSeChromeBinaryCommand cmdlet =
                //new SetSeChromeBinaryCommandTestFixture();
                WebDriverFactory.Container.Resolve<SetSeChromeBinaryCommand>();
            //SetSeChromeBinaryCommand.UnitTestMode = true;
            ((EditChromeOptionsCmdletBase)cmdlet).InputObject =
                //WebDriverFactory.GetChromeOptions();
                // resolve ChromeOptions
                WebDriverFactory.Container.Resolve<ChromeOptions>();
            cmdlet.BinaryPath =
                expected;
            SeSetChromeBinaryCommand command =
                new SeSetChromeBinaryCommand(cmdlet);
            command.Execute();
            //Assert.AreEqual(expected, (SePSX.CommonCmdletBase.UnitTestOutput[0] as ChromeOptions).BinaryLocation);
            Assert.AreEqual(
                expected,
                ((ChromeOptions)(object)PSTestLib.UnitTestOutput.LastOutput[0]).BinaryLocation);
        }
        
        [Test]
        [Category("Fast")]
        public void ChromeOptions_add_binary_location_second()
        {
            string expected = "path2";
            SetSeChromeBinaryCommand cmdlet =
                //new SetSeChromeBinaryCommandTestFixture();
                WebDriverFactory.Container.Resolve<SetSeChromeBinaryCommand>();
            //SetSeChromeBinaryCommand.UnitTestMode = true;
            ((EditChromeOptionsCmdletBase)cmdlet).InputObject =
                //WebDriverFactory.GetChromeOptions();
                // resolve ChromeOptions
                WebDriverFactory.Container.Resolve<ChromeOptions>();
            cmdlet.BinaryPath =
                "path1";
            SeSetChromeBinaryCommand command =
                new SeSetChromeBinaryCommand(cmdlet);
            command.Execute();
            //SePSX.CommonCmdletBase.UnitTestOutput.Clear();
            PSTestLib.UnitTestOutput.Clear();
            cmdlet.BinaryPath =
                expected;
            SeSetChromeBinaryCommand command2 =
                new SeSetChromeBinaryCommand(cmdlet);
            command2.Execute();
            //Assert.AreEqual(expected, (SePSX.CommonCmdletBase.UnitTestOutput[0] as ChromeOptions).BinaryLocation);
            Assert.AreEqual(
                expected,
                ((ChromeOptions)(object)PSTestLib.UnitTestOutput.LastOutput[0]).BinaryLocation);
        }
    }
}
