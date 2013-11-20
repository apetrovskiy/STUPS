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
    using System;
    using System.Windows.Automation;
    using PSTestLib;
    using UIAutomation;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of NewUIAWizardCommandTestFixture.
    /// </summary>
    public class NewUIAWizardCommandTestFixture
    {
        public NewUIAWizardCommandTestFixture()
        {
        }
        
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
        public void NewWizard_Name_StartAction()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		@"New-UIAWizard -Name 'wizardName' -StartAction { 'var' };");
        }
        
        [Test]
        [Category("Fast")]
        public void NewWizard_Name_StartActionX3()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters_ParamsAccepted(
        		@"New-UIAWizard -Name 'wizardName' -StartAction { 'var1' },{ 'var2' },{ 'var3' };");
        }
    }
}
