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
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewUIAWizardCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="1")]
    public class NewUIAWizardCommandTestFixture
    {
        public NewUIAWizardCommandTestFixture()
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
        
        [Test] //[Test(Description="Creating a simple wizard object")]
        [Category("NoForms")]
        [Category("Slow")]
        [Category("Wizard")]
        public void NewWizard_Simple()
        {
            string name = "wizard";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UIAWizard -Name '" + 
                name + 
                "' -StartAction {}).Name;",
                name);
        }
        
        [Test] //[Test(Description="Creating a simple wizard object with the complex name")]
        [Category("NoForms")]
        [Category("Slow")]
        [Category("Wizard")]
        public void NewWizard_Complex1()
        {
            string name = "wi*za*rd";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UIAWizard -Name '" + 
                name + 
                "' -StartAction {}).Name;",
                name);
        }
        
        [Test] //[Test(Description="Creating a simple wizard object with the complex name")]
        [Category("NoForms")]
        [Category("Slow")]
        [Category("Wizard")]
        public void NewWizard_Complex2()
        {
            string name = @"``//\\`""`''#$(1)567";
            string answer = @"``//\\`""`'#$(1)567";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-UIAWizard -Name '" + 
                name + 
                "' -StartAction {}).Name;",
                answer);
        }
        
        [Test] //[Test(Description="Creating a simple wizard object with an action")]
        [Category("NoForms")]
        [Category("Slow")]
        [Category("Wizard")]
        public void NewWizard_Simple_WithStartAction()
        {
            string name = "wizard";
            string result = "StartAction";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-UIAWizard -Name '" + 
                name + 
                "' -StartAction {$global:wzdTest = '" + result + "'};" + 
                @"$null = Invoke-UIAWizard -Name '" +
                name + 
                "';" + 
                @"$global:wzdTest;",
                result);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
