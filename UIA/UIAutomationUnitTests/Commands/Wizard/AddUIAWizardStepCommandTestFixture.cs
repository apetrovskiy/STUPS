/*
 * Created by SharpDevelop.
 * User: Alexander
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
Console.WriteLine("AddWizardStep_StandardName 000001");
Console.WriteLine("AddWizardStep_StandardName (Wizard)PSTestLib.UnitTestOutput.LastOutput[0] = " + ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).ToString());
Console.WriteLine("AddWizardStep_StandardName ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps.Count = " + ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps.Count.ToString());
Console.WriteLine("AddWizardStep_StandardName ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name = " + ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
            Assert.AreEqual(
                expectedName,
                //((Wizard)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
Console.WriteLine("AddWizardStep_StandardName 000002");
        }
        
        [Test]
        [Description("Add-UIAWizardStep")]
        [Category("Fast")]
        [Category("Wizard")]
        public void AddWizardStep_ComplexName()
        {
            string expectedName = @"\\st//ep`` name;;";
            UnitTestingHelper.AddWizardStep(expectedName, null, null);
Console.WriteLine("AddWizardStep_ComplexName 000001");
Console.WriteLine("AddWizardStep_ComplexName (Wizard)PSTestLib.UnitTestOutput.LastOutput[0] = " + ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).ToString());
Console.WriteLine("AddWizardStep_ComplexName ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps.Count = " + ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps.Count.ToString());
Console.WriteLine("AddWizardStep_ComplexName ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name = " + ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
            Assert.AreEqual(
                expectedName,
                //((Wizard)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Steps[0].Name);
Console.WriteLine("AddWizardStep_ComplexName 000002");
        }
	}
}
