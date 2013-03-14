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
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using UIAutomation;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewUIAWizardCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class NewUIAWizardCommandTestFixture
    {
        public NewUIAWizardCommandTestFixture()
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
        
        private void createWizard(string name, ScriptBlock[] sb)
        {
            UIAutomation.Commands.NewUIAWizardCommand cmdlet =
                new UIAutomation.Commands.NewUIAWizardCommand();
            cmdlet.Name = name;
            cmdlet.StartAction = sb;
            UIANewWizardCommand command =
                new UIANewWizardCommand(cmdlet);
            command.Execute();
        }
        
        [Test]
        [Description("New-UIAWizard")]
        [Category("Fast")]
        public void NewWizard_StandardName()
        {
            string expectedName = "name";
            createWizard(expectedName, null);
            
            Assert.AreEqual(
                expectedName,
                ((Wizard)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test]
        [Description("New-UIAWizard")]
        [Category("Fast")]
        public void NewWizard_ComplexName()
        {
            string expectedName = @"\\aa//bb``cc";
            createWizard(expectedName, null);
            
            Assert.AreEqual(
                expectedName,
                ((Wizard)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test]
        [Description("New-UIAWizard")]
        [Category("Fast")]
        public void NewWizard_DuplicatedName()
        {
            string expectedName = "name";
            createWizard(expectedName, null);
            createWizard(expectedName, null);
            
            Assert.AreEqual(
                expectedName,
                ((Wizard)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
    }
}
