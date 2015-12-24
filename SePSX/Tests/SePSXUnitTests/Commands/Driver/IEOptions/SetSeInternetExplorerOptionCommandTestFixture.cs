/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 5:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver.InternetExplorerOptions
{
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using OpenQA.Selenium.IE;
    using Autofac;
    
    /// <summary>
    /// Description of SetSeInternetExplorerOptionCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class SetSeInternetExplorerOptionCommandTestFixture
    {
        public SetSeInternetExplorerOptionCommandTestFixture()
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
        [Ignore]
        public void InternetExplorer_new()
        {
            NewSeInternetExplorerOptionsCommand cmdlet =
                //new NewSeInternetExplorerOptionsCommandTestFixture();
                WebDriverFactory.Container.Resolve<NewSeInternetExplorerOptionsCommand>();
            //NewSeInternetExplorerOptionsCommand.UnitTestMode = true;
            SeNewIeOptionsCommand command =
                new SeNewIeOptionsCommand(cmdlet);
            command.Execute();
            //Assert.IsNotNull(SePSX.CommonCmdletBase.UnitTestOutput[0] as InternetExplorerOptions);
            Assert.IsNotNull(
                (InternetExplorerOptions)(object)PSTestLib.UnitTestOutput.LastOutput[0]);
        }
    }
}
