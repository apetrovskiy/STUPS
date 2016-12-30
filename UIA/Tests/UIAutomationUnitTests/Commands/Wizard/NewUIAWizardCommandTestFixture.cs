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
    using Xunit;
    using UIAutomation;
    
    /// <summary>
    /// Description of NewUiaWizardCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class NewUiaWizardCommandTestFixture
    {
        public NewUiaWizardCommandTestFixture()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
            // 20140130
            AutomationFactory.InitUnitTests();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
            
            // 20140227
            AutomationFactory.InitUnitTests();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            WizardCollection.ResetData();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("New-UiaWizard")]
//        [Category("Fast")]
//        [Category("Wizard")]
        public void NewWizard_StandardName()
        {
            const string expectedName = "name";
            UnitTestingHelper.CreateWizard(expectedName, null);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("New-UiaWizard")]
//        [Category("Fast")]
//        [Category("Wizard")]
        public void NewWizard_ComplexName()
        {
            const string expectedName = @"\\aa//bb``cc";
            UnitTestingHelper.CreateWizard(expectedName, null);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        [Description("New-UiaWizard")]
//        [Category("Fast")]
//        [Category("Wizard")]
        // [Ignore]
        [MbUnit.Framework.Ignore]
        [NUnit.Framework.Ignore("")]
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
