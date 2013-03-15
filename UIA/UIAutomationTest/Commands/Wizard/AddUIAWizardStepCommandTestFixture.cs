/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/22/2012
 * Time: 11:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Wizard
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of AddUIAWizardStepCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="1")]
    public class AddUIAWizardStepCommandTestFixture
    {
        public AddUIAWizardStepCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                //@"[UIAutomation.WizardCollection]::Wizards.Clear();");
                @"[UIAutomation.WizardCollection]::ResetData();");
        }
        
        [Test] //[Test(Description="Creating a simple wizard object with one step")]
        [Category("NoForms")]
        [Category("Slow")]
        [Category("Wizard")]
        public void AddWizardStep_Simple()
        {
            string wizardName = "wizard";
            string stepName = "step1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UIAWizard -Name '" + 
                wizardName + 
                @"' -StartAction {} | " +
                @"Add-UIAWizardStep -Name '" + 
                stepName +
                @"' -StepForwardAction {}).Steps[0].Name;",
                stepName);
        }
        
        [Test] //[Test(Description="Creating a simple wizard object with the complex name")]
        [Category("NoForms")]
        [Category("Slow")]
        [Category("Wizard")]
        public void AddWizardStep_Complex1()
        {
            string wizardName = "wi*za*rd";
            string stepName = "st*ep*1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UIAWizard -Name '" + 
                wizardName + 
                @"' -StartAction {} | " +
                @"Add-UIAWizardStep -Name '" + 
                stepName +
                @"' -StepForwardAction {}).Steps[0].Name;",
                stepName);
        }
        
        [Test] //[Test(Description="Creating a simple wizard object with the complex name")]
        [Category("NoForms")]
        [Category("Slow")]
        [Category("Wizard")]
        public void AddWizardStep_Complex2()
        {
            string wizardName = @"``//\\`""`''#$(1)567";
            string answer = @"``//\\`""`'#$(1)5678";
            string stepName = @"``//\\`""`''#$(1)5678";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UIAWizard -Name '" + 
                wizardName + 
                @"' -StartAction {} | " +
                @"Add-UIAWizardStep -Name '" + 
                stepName +
                @"' -StepForwardAction {}).Steps[0].Name;",
                answer);
        }
        
//        [Test] //[Test(Description="Creating a simple wizard object with an action")]
//        [Category("Slow")][Category("NoForms")]
//        [Category("Slow")][Category("Wizard")]
//        public void AddWizardStep_Simple_WithStartAction()
//        {
//            string wizardName = "wizard";
//            string result1 = "StartAction";
//            string stepName = "step1";
//            string result2 = "StepForwardAction";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = New-UIAWizard -Name '" + 
//                wizardName + 
//                "' -StartAction {$global:wzdTest = '" + result1 + "'} | " +
//                @"Add-UIAWizardStep -Name '" + 
//                stepName +
//                @"' -StepForwardAction {$global:wzdTest = '" + result2 + "'}" + 
//                @" -SearchCriteria @{}; " +
//                @"$null = Invoke-UIAWizard -Name '" +
//                wizardName + 
//                "' | Step-UIAWizard -Name '" + stepName + "'; " + 
//                @"$global:wzdTest;",
//                result2);
//        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
