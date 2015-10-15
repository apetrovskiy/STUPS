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
    using System.Collections.ObjectModel;
    using Autofac;
    
    /// <summary>
    /// Description of AddSeChromeArgumentCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class AddSeChromeArgumentCommandTestFixture
    {
        public AddSeChromeArgumentCommandTestFixture()
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
        public void ChromeOptions_add_one_argument()
        {
            string[] expected = { "test1" };
            AddSeChromeArgumentCommand cmdlet =
                //new AddSeChromeArgumentCommandTestFixture();
                WebDriverFactory.Container.Resolve<AddSeChromeArgumentCommand>();
            //AddSeChromeArgumentCommand.UnitTestMode = true;
            cmdlet.InputObject =
                //WebDriverFactory.GetChromeOptions();
                // resolve ChromeOptions
                WebDriverFactory.Container.Resolve<ChromeOptions>();
            cmdlet.ArgumentList =
                expected;
            SeAddChromeArgumentCommand command =
                new SeAddChromeArgumentCommand(cmdlet);
                //WebDriverFactory.Container.Resolve<SeAddChromeArgumentCommand>().
            command.Execute();
            System.Collections.Generic.List<string> listOfArguments =
                new System.Collections.Generic.List<string>();
            listOfArguments.Add(expected[0]);
            ReadOnlyCollection<string> expectedList =
                new ReadOnlyCollection<string>(listOfArguments);
            //Assert.AreEqual(expectedList, (SePSX.CommonCmdletBase.UnitTestOutput[0] as ChromeOptions).Arguments);
            Assert.AreEqual(
                expectedList,
                ((ChromeOptions)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Arguments);
        }
        
        [Test]
        [Category("Fast")]
        public void ChromeOptions_add_five_arguments()
        {
            string[] expected = { "test1", "test2", "test3", "test4", "test5" };
            AddSeChromeArgumentCommand cmdlet =
                //new AddSeChromeArgumentCommandTestFixture();
                WebDriverFactory.Container.Resolve<AddSeChromeArgumentCommand>();
            //AddSeChromeArgumentCommand.UnitTestMode = true;
            cmdlet.InputObject =
                //WebDriverFactory.GetChromeOptions();
                // resolve ChromeOptions
                WebDriverFactory.Container.Resolve<ChromeOptions>();
            cmdlet.ArgumentList =
                expected;
            SeAddChromeArgumentCommand command =
                new SeAddChromeArgumentCommand(cmdlet);
            command.Execute();
            System.Collections.Generic.List<string> listOfArguments =
                new System.Collections.Generic.List<string>();
            listOfArguments.Add(expected[0]);
            listOfArguments.Add(expected[1]);
            listOfArguments.Add(expected[2]);
            listOfArguments.Add(expected[3]);
            listOfArguments.Add(expected[4]);
            ReadOnlyCollection<string> expectedList =
                new ReadOnlyCollection<string>(listOfArguments);
            //Assert.AreEqual(expectedList, (SePSX.CommonCmdletBase.UnitTestOutput[0] as ChromeOptions).Arguments);
            Assert.AreEqual(
                expectedList,
                ((ChromeOptions)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Arguments);
        }
    }
}
