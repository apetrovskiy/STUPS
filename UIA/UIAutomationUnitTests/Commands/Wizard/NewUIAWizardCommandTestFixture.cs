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
        
        [Test]
        [Description("New-UIAWizard")]
        [Category("Fast")]
        [Category("Wizard")]
        public void NewWizard_StandardName()
        {
            string expectedName = "name";
            UnitTestingHelper.CreateWizard(expectedName, null);
            
            Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test]
        [Description("New-UIAWizard")]
        [Category("Fast")]
        [Category("Wizard")]
        public void NewWizard_ComplexName()
        {
            string expectedName = @"\\aa//bb``cc";
            UnitTestingHelper.CreateWizard(expectedName, null);
            
            Assert.AreEqual(
                expectedName,
                ((Wizard)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
        
        [Test]
        [Description("New-UIAWizard")]
        [Category("Fast")]
        [Category("Wizard")]
        [Ignore]
        public void NewWizard_DuplicatedName()
        {
            string expectedName = "name";
            UnitTestingHelper.CreateWizard(expectedName, null);
            
            //Assert.Throws<Type>(UnitTestingHelper.CreateWizard(expectedName, null));
            
//            createWizard(expectedName, null);
//            
//            Assert.AreEqual(
//                expectedName,
//                ((Wizard)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
        }
    }
}
