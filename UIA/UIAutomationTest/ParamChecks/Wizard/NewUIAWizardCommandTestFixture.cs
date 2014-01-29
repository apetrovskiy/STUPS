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
    /// Description of NewUiaWizardCommandTestFixture.
    /// </summary>
    [Ignore("temporarily")]
    [MbUnit.Framework.TestFixture]
    public class NewUiaWizardCommandTestFixture
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
        public void NewWizard_Name_StartAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		@"New-UiaWizard -Name 'wizardName' -StartAction { 'var' };");
        }
        
        [Test]// [Fact]
        // [Ignore("20140128")]
        [Category("Fast")]
        public void NewWizard_Name_StartActionX3()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		@"New-UiaWizard -Name 'wizardName' -StartAction { 'var1' },{ 'var2' },{ 'var3' };");
        }
    }
}
