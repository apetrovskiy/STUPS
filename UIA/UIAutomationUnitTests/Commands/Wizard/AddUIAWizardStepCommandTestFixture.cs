/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 8:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Commands.Wizard
{
    using MbUnit.Framework;// using Xunit;
    using UIAutomation;
    
	/// <summary>
	/// Description of AddUiaWizardStepCommandTestFixture.
	/// </summary>
	[MbUnit.Framework.TestFixture]
	public class AddUiaWizardStepCommandTestFixture
	{
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
        
        [Test]// [Fact]
        [Description("Add-UiaWizardStep")]
        [Category("Fast")]
        [Category("Wizard")]
        public void AddWizardStep_StandardName()
        {
            const string expectedName = "name";
            UnitTestingHelper.AddWizardStep(expectedName, null, null);

            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
        }
        
        [Test]// [Fact]
        [Description("Add-UiaWizardStep")]
        [Category("Fast")]
        [Category("Wizard")]
        public void AddWizardStep_ComplexName()
        {
            const string expectedName = @"\\st//ep`` name;;";
            UnitTestingHelper.AddWizardStep(expectedName, null, null);

            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
        }
	}
}
