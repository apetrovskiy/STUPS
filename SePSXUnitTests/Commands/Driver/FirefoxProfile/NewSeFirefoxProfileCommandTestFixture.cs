/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 5:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver.FirefoxProfile
{
    using System;
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using PSTestLib;
    using OpenQA.Selenium.IE;
    using Autofac;
    
    /// <summary>
    /// Description of NewSeFirefoxProfileCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class NewSeFirefoxProfileCommandTestFixture
    {
        public NewSeFirefoxProfileCommandTestFixture()
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
        public void Firefox_new_bare()
        {
            NewSeFirefoxProfileCommand cmdlet =
                //new NewSeFirefoxProfileCommandTestFixture();
                WebDriverFactory.Container.Resolve<NewSeFirefoxProfileCommand>();
            NewSeFirefoxProfileCommand.UnitTest = true;
            SeNewFirefoxProfileCommand command =
                new SeNewFirefoxProfileCommand(cmdlet);
            command.Execute();
            Assert.IsNotNull(
                SePSX.CommonCmdletBase.UnitTestOutput[0] as OpenQA.Selenium.Firefox.FirefoxProfile);
        }
        
        [Test]
        [Ignore]
        public void Firefox_new_with_path()
        {
//            NewSeFirefoxProfileCommand cmdlet =
//                new NewSeFirefoxProfileCommandTestFixture();
//            NewSeFirefoxProfileCommand.UnitTest = true;
//            SeNewFirefoxProfileCommand command =
//                new SeNewFirefoxProfileCommand(cmdlet);
//            command.Execute();
//            Assert.IsNotNull(SePSX.CommonCmdletBase.UnitTestOutput[0] as FirefoxProfile);
        }
        
        [Test]
        [Ignore]
        public void Firefox_new_with_path_and_deletion()
        {
//            NewSeFirefoxProfileCommand cmdlet =
//                new NewSeFirefoxProfileCommandTestFixture();
//            NewSeFirefoxProfileCommand.UnitTest = true;
//            SeNewFirefoxProfileCommand command =
//                new SeNewFirefoxProfileCommand(cmdlet);
//            command.Execute();
//            Assert.IsNotNull(SePSX.CommonCmdletBase.UnitTestOutput[0] as FirefoxProfile);
        }
    }
}
