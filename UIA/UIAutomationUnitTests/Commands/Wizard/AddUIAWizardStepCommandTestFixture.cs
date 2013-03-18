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
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using UIAutomation;
    using System.Management.Automation;
    
	/// <summary>
	/// Description of AddUIAWizardStepCommandTestFixture.
	/// </summary>
	[TestFixture]
	public class AddUIAWizardStepCommandTestFixture
	{
		public AddUIAWizardStepCommandTestFixture()
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
            WizardCollection.ResetData();
        }
        
        [Test]
        [Description("Add-UIAWizardStep")]
        [Category("Fast")]
        [Category("Wizard")]
        public void AddWizardStep_StandardName()
        {
            string expectedName = "name";
            UnitTestingHelper.AddWizardStep(expectedName, null, null);

            Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
        }
        
        [Test]
        [Description("Add-UIAWizardStep")]
        [Category("Fast")]
        [Category("Wizard")]
        public void AddWizardStep_ComplexName()
        {
            string expectedName = @"\\st//ep`` name;;";
            UnitTestingHelper.AddWizardStep(expectedName, null, null);

            Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
        }
	}
}
