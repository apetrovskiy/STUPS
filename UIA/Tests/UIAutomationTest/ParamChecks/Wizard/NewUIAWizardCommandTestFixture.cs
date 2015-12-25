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
    /// Description of NewUiaWizardCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.Ignore("temporarily")]
    [NUnit.Framework.Ignore("temporarily")]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class NewUiaWizardCommandTestFixture
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
        public void NewWizard_Name_StartAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
                @"New-UiaWizard -Name 'wizardName' -StartAction { 'var' };");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        // [Ignore("20140128")]
        [MbUnit.Framework.Category("Fast")]
        public void NewWizard_Name_StartActionX3()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
                @"New-UiaWizard -Name 'wizardName' -StartAction { 'var1' },{ 'var2' },{ 'var3' };");
        }
    }
}
