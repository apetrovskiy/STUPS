/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 12:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Wizard
{
    using MbUnit.Framework;using Xunit;
    using UIAutomation;
    
    /// <summary>
    /// Description of NewUiaWizardCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class NewUiaWizardCommandTestFixture
    {
        public NewUiaWizardCommandTestFixture()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
            WizardCollection.ResetData();
        }
        
        [Test][Fact]
        [Description("New-UiaWizard")]
        [Category("Fast")]
        [Category("Wizard")]
        public void NewWizard_StandardName()
        {
            const string expectedName = "name";
            UnitTestingHelper.CreateWizard(expectedName, null);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test][Fact]
        [Description("New-UiaWizard")]
        [Category("Fast")]
        [Category("Wizard")]
        public void NewWizard_ComplexName()
        {
            const string expectedName = @"\\aa//bb``cc";
            UnitTestingHelper.CreateWizard(expectedName, null);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test][Fact]
        [Description("New-UiaWizard")]
        [Category("Fast")]
        [Category("Wizard")]
        [Ignore]
        public void NewWizard_DuplicatedName()
        {
            const string expectedName = "name";
            UnitTestingHelper.CreateWizard(expectedName, null);
            
            //Assert.Throws<Type>(UnitTestingHelper.CreateWizard(expectedName, null));
            
//            createWizard(expectedName, null);
//            
//            MbUnit.Framework.Assert.AreEqual(
//                expectedName,
//                ((Wizard)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
    }
}
