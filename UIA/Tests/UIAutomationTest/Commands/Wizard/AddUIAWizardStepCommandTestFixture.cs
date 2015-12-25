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
    /// <summary>
    /// Description of AddUiaWizardStepCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="1")]
    public class AddUiaWizardStepCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                //@"[UIAutomation.WizardCollection]::Wizards.Clear();");
                @"[UIAutomation.WizardCollection]::ResetData();");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Creating a simple wizard object with one step")]
        [MbUnit.Framework.Category("NoForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Wizard")]
        public void AddWizardStep_Simple()
        {
            string wizardName = "wizard";
            string stepName = "step1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UiaWizard -Name '" + 
                wizardName + 
                @"' -StartAction {} | " +
                @"Add-UiaWizardStep -Name '" + 
                stepName +
                @"' -StepForwardAction {}).Steps[0].Name;",
                stepName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Creating a simple wizard object with the complex name")]
        [MbUnit.Framework.Category("NoForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Wizard")]
        public void AddWizardStep_Complex1()
        {
            string wizardName = "wi*za*rd";
            string stepName = "st*ep*1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UiaWizard -Name '" + 
                wizardName + 
                @"' -StartAction {} | " +
                @"Add-UiaWizardStep -Name '" + 
                stepName +
                @"' -StepForwardAction {}).Steps[0].Name;",
                stepName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Creating a simple wizard object with the complex name")]
        [MbUnit.Framework.Category("NoForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Wizard")]
        public void AddWizardStep_Complex2()
        {
            string wizardName = @"``//\\`""`''#$(1)567";
            string answer = @"``//\\`""`'#$(1)5678";
            string stepName = @"``//\\`""`''#$(1)5678";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UiaWizard -Name '" + 
                wizardName + 
                @"' -StartAction {} | " +
                @"Add-UiaWizardStep -Name '" + 
                stepName +
                @"' -StepForwardAction {}).Steps[0].Name;",
                answer);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Creating a simple wizard object with an action")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("NoForms")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Wizard")]
//        public void AddWizardStep_Simple_WithStartAction()
//        {
//            string wizardName = "wizard";
//            string result1 = "StartAction";
//            string stepName = "step1";
//            string result2 = "StepForwardAction";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = New-UiaWizard -Name '" + 
//                wizardName + 
//                "' -StartAction {$global:wzdTest = '" + result1 + "'} | " +
//                @"Add-UiaWizardStep -Name '" + 
//                stepName +
//                @"' -StepForwardAction {$global:wzdTest = '" + result2 + "'}" + 
//                @" -SearchCriteria @{}; " +
//                @"$null = Invoke-UiaWizard -Name '" +
//                wizardName + 
//                "' | Step-UiaWizard -Name '" + stepName + "'; " + 
//                @"$global:wzdTest;",
//                result2);
//        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
