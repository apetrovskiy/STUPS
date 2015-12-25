/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/27/2012
 * Time: 9:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Wizard
{
    /// <summary>
    /// Description of NewUiaWizardCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="1")]
    public class NewUiaWizardCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                //@"[UIAutomation.WizardCollection]::Wizards.Clear();");
                @"[UIAutomation.WizardCollection]::ResetData();");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Creating a simple wizard object")]
        [MbUnit.Framework.Category("NoForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Wizard")]
        public void NewWizard_Simple()
        {
            string name = "wizard";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UiaWizard -Name '" + 
                name + 
                "' -StartAction {}).Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Creating a simple wizard object with the complex name")]
        [MbUnit.Framework.Category("NoForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Wizard")]
        public void NewWizard_Complex1()
        {
            string name = "wi*za*rd";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UiaWizard -Name '" + 
                name + 
                "' -StartAction {}).Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Creating a simple wizard object with the complex name")]
        [MbUnit.Framework.Category("NoForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Wizard")]
        public void NewWizard_Complex2()
        {
            string name = @"``//\\`""`''#$(1)567";
            string answer = @"``//\\`""`'#$(1)567";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UiaWizard -Name '" + 
                name + 
                "' -StartAction {}).Name;",
                answer);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="Creating a simple wizard object with an action")]
        [MbUnit.Framework.Category("NoForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Wizard")]
        public void NewWizard_Simple_WithStartAction()
        {
            string name = "wizard";
            string result = "StartAction";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-UiaWizard -Name '" + 
                name + 
                "' -StartAction {$global:wzdTest = '" + result + "'};" + 
                @"$null = Invoke-UiaWizard -Name '" +
                name + 
                "';" + 
                @"$global:wzdTest;",
                result);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
