/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/14/2012
 * Time: 12:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetUIATextBoxCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Get-UIATextBoxCommand test")]
    public class GetUIATextBoxCommandTestFixture
    {
        public GetUIATextBoxCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByAutomationIDTimeoutDefault()
        {
            string auId = "TextBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "aaa", // name?
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -AutomationId " + 
                auId + 
                " | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByAutomationIDTimeout2000()
        {
            string auId = "TextBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "aaa", // name?
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByAutomationIDTimeout3000Delay500()
        {
            string auId = "TextBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "aaa", // name?
                auId,
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -AutomationId " + 
                auId + 
                " -timeout 3000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByAutomationIDTimeout2000Delay4000()
        {
            string auId = "TextBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "aaa", // name?
                auId,
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByTitleTimeoutDefault()
        {
            string name = "TextBox222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -Name " + 
                name + " | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByTitleTimeout2000()
        {
            string name = "TextBox222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -Name " + 
                name + " -timeout 2000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByTitleTimeout3000Delay500()
        {
            string name = "TextBox222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -Name " + 
                name + " -timeout 3000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByTitleTimeout2000Delay4000()
        {
            string name = "TextBox222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -Name " + 
                name + " -timeout 2000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByControlTypeTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox | Read-UIAControlType",
                "ControlType.Edit");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByControlTypeTimeout2000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -timeout 2000 | Read-UIAControlType",
                "ControlType.Edit");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByControlTypeTimeout3000Delay500()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -timeout 3000 | Read-UIAControlType",
                "ControlType.Edit");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void GetTextBoxByControlTypeTimeout2000Delay4000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -timeout 2000 | Read-UIAControlType",
                "ControlType.Edit");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}