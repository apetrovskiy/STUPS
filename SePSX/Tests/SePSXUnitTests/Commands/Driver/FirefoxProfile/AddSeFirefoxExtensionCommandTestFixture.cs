/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2012
 * Time: 10:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver.FirefoxProfile
{
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using OpenQA.Selenium.Firefox;
    using System.Collections.ObjectModel;
    using Autofac;
    
    /// <summary>
    /// Description of AddSeFirefoxExtensionCommandTestFixture.
    /// </summary>
    public class AddSeFirefoxExtensionCommandTestFixture
    {
        public AddSeFirefoxExtensionCommandTestFixture()
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
        [Ignore("Not having comprehended what to compare as there's no way to get back the value given")]
        public void FirefoxProfile_add_one_extension()
        {
            string[] expected = { "test1" };
            AddSeFirefoxExtensionCommand cmdlet =
                WebDriverFactory.Container.Resolve<AddSeFirefoxExtensionCommand>();
            //AddSeFirefoxExtensionCommand.UnitTestMode = true;
            cmdlet.InputObject =
                //WebDriverFactory.GetFirefoxProfile();
                // resolve FirefoxProfile
                WebDriverFactory.Container.Resolve<FirefoxProfile>();
            cmdlet.ExtensionList =
                expected;
            SeAddFirefoxExtensionCommand command =
                new SeAddFirefoxExtensionCommand(cmdlet);
            command.Execute();
            System.Collections.Generic.List<string> listOfArguments =
                new System.Collections.Generic.List<string>();
            listOfArguments.Add(expected[0]);
            ReadOnlyCollection<string> expectedList =
                new ReadOnlyCollection<string>(listOfArguments);
            //Assert.AreEqual(expectedList, (SePSX.CommonCmdletBase.UnitTestOutput[0] as FirefoxProfile)); // ??
        }
        
        [Test]
        [Category("Fast")]
        [Ignore("Not having comprehended what to compare as there's no way to get back the value given")]
        public void FirefoxProfile_add_five_extensions()
        {
            string[] expected = { "SePSX.dll", "SePSX.dll", "SePSX.dll", "SePSX.dll", "SePSX.dll" };
            AddSeFirefoxExtensionCommand cmdlet =
                WebDriverFactory.Container.Resolve<AddSeFirefoxExtensionCommand>();
            //AddSeFirefoxExtensionCommand.UnitTestMode = true;
            cmdlet.InputObject =
                //WebDriverFactory.GetFirefoxProfile();
                // resolve FirefoxProfile
                WebDriverFactory.Container.Resolve<FirefoxProfile>();
            cmdlet.ExtensionList =
                expected;
            SeAddFirefoxExtensionCommand command =
                new SeAddFirefoxExtensionCommand(cmdlet);
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
            //Assert.AreEqual(expectedList, (SePSX.CommonCmdletBase.UnitTestOutput[0] as FirefoxProfile)); // ??
        }
    }
}
