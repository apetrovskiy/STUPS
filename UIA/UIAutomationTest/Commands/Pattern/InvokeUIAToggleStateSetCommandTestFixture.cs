/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/22/2013
 * Time: 7:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Pattern
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAToggleStateSetCommandTestFixture.
    /// </summary>
    public class InvokeUIAToggleStateSetCommandTestFixture
    {
        public InvokeUIAToggleStateSetCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test]
        [Category("Slow")]
        [Category("Set-UIACheckBoxToggleState")]
        public void InvokeToggleStateSet_CheckBox_On_True()
        {
            string name = "check_box";
            string automationId = "chbx";
            string expectedResult = "True";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty,
                0,
                System.Windows.Automation.ControlType.CheckBox,
                name,
                automationId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Set-UIACheckBoxToggleState $true; " +
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Set-UIACheckBoxToggleState $true; " +
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Get-UIACheckBoxToggleState;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("Set-UIACheckBoxToggleState")]
        public void InvokeToggleStateSet_CheckBox_On_False()
        {
            string name = "check_box";
            string automationId = "chbx";
            string expectedResult = "False";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty,
                0,
                System.Windows.Automation.ControlType.CheckBox,
                name,
                automationId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Set-UIACheckBoxToggleState $true; " +
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Set-UIACheckBoxToggleState $false; " +
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Get-UIACheckBoxToggleState;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("Set-UIACheckBoxToggleState")]
        public void InvokeToggleStateSet_CheckBox_Off_True()
        {
            string name = "check_box";
            string automationId = "chbx";
            string expectedResult = "True";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty,
                0,
                System.Windows.Automation.ControlType.CheckBox,
                name,
                automationId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Set-UIACheckBoxToggleState $true; " +
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Get-UIACheckBoxToggleState;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("Set-UIACheckBoxToggleState")]
        public void InvokeToggleStateSet_CheckBox_Off_False()
        {
            string name = "check_box";
            string automationId = "chbx";
            string expectedResult = "False";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty,
                0,
                System.Windows.Automation.ControlType.CheckBox,
                name,
                automationId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Set-UIACheckBoxToggleState $false; " +
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIACheckBox -Name '" +
                name +
                "' | Get-UIACheckBoxToggleState;",
                expectedResult);
        }
    }
}
