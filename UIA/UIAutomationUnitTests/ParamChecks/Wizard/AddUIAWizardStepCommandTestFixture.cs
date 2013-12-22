/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 10:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.CheckCmdletParameters
{
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of AddUiaWizardStepCommandTestFixture.
    /// </summary>
    [TestFixture]
    // [Ignore("temporarily")]
    public class AddUiaWizardStepCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
            WizardCollection.ResetData();
        }
        
        [Test]
        [Category("Fast")]
        public void AddWizardStep_Name()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		@"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {});");
        }
        
        [Test]
        [Category("Fast")]
        public void AddWizardStep_Name_StepForwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		@"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepForwardAction {};");
        }
        
        [Test]
        [Category("Fast")]
        public void AddWizardStep_Name_StepBackwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		@"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepBackwardAction {};");
        }
        
        [Test]
        [Category("Fast")]
        public void AddWizardStep_Name_StepForwardAction_StepBackwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		@"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepForwardAction {} -StepBackwardAction {};");
        }
    }
}
