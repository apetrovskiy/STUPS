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

    // using Xunit;
    
    /// <summary>
    /// Description of AddUiaWizardStepCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    [MbUnit.Framework.Ignore("temporarily")]
    [NUnit.Framework.Ignore("temporarily")]
    public class AddUiaWizardStepCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode2.PrepareRunspaceForParamChecks();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            // MiddleLevelCode.DisposeRunspace();
            WizardCollection.ResetData();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void AddWizardStep_Name()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {});");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void AddWizardStep_Name_StepForwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepForwardAction {};");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void AddWizardStep_Name_StepBackwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepBackwardAction {};");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void AddWizardStep_Name_StepForwardAction_StepBackwardAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsOK_CmdletException(
                @"Add-UiaWizardStep -Name 'stepName' -InputObject (New-UiaWizard -Name wizardName -StartAction {}) -StepForwardAction {} -StepBackwardAction {};");
        }
    }
}
