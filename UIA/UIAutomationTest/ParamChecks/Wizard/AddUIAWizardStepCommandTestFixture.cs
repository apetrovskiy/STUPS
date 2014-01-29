/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 10:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.CheckCmdletParameters
{
    using UIAutomation;
    using MbUnit.Framework;// using Xunit;
    
    /// <summary>
    /// Description of AddUiaWizardStepCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    [Ignore("temporarily")]
    public class AddUiaWizardStepCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode2.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace();
            WizardCollection.ResetData();
        }
        
        [Test]// [Fact]
        // [Ignore("20140128")]
        [Category("Fast")]
        public void AddWizardStep_Name()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		@"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {});");
        }
        
        [Test]// [Fact]
        // [Ignore("20140128")]
        [Category("Fast")]
        public void AddWizardStep_Name_StepForwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		@"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepForwardAction {};");
        }
        
        [Test]// [Fact]
        // [Ignore("20140128")]
        [Category("Fast")]
        public void AddWizardStep_Name_StepBackwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		@"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepBackwardAction {};");
        }
        
        [Test]// [Fact]
        // [Ignore("20140128")]
        [Category("Fast")]
        public void AddWizardStep_Name_StepForwardAction_StepBackwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
        		@"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepForwardAction {} -StepBackwardAction {};");
        }
    }
}
