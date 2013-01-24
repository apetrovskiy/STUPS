/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/26/2012
 * Time: 8:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver.ChromeOptions
{
    using System;
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using PSTestLib;
    using OpenQA.Selenium.Chrome;
    using Autofac;
    
    /// <summary>
    /// Description of NewSeChromeOptionsCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class NewSeChromeOptionsCommandTestFixture
    {
        public NewSeChromeOptionsCommandTestFixture()
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
        public void ChromeOptions_new()
        {
            NewSeChromeOptionsCommand cmdlet =
                //new NewSeChromeOptionsCommandTestFixture();
                WebDriverFactory.Container.Resolve<NewSeChromeOptionsCommand>();
            //NewSeChromeOptionsCommand.UnitTestMode = true;
            SeNewChromeOptionsCommand command =
                new SeNewChromeOptionsCommand(cmdlet);
                //WebDriverFactory.Container.Resolve<SeNewChromeOptionsCommand>
            command.Execute();
            //Assert.IsNotNull(SePSX.CommonCmdletBase.UnitTestOutput[0] as ChromeOptions);
            Assert.IsNotNull(
                (ChromeOptions)(object)PSTestLib.UnitTestOutput.LastOutput[0]);
        }
    }
}
