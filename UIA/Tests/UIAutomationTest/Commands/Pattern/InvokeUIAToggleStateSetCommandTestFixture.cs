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
    /// <summary>
    /// Description of InvokeUiaToggleStateSetCommandTestFixture.
    /// </summary>
    public class InvokeUiaToggleStateSetCommandTestFixture
    {
        public InvokeUiaToggleStateSetCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Set-UiaCheckBoxToggleState")]
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
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Set-UiaCheckBoxToggleState $true; " +
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Set-UiaCheckBoxToggleState $true; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Get-UiaCheckBoxToggleState;",
                expectedResult);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Set-UiaCheckBoxToggleState")]
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
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Set-UiaCheckBoxToggleState $true; " +
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Set-UiaCheckBoxToggleState $false; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Get-UiaCheckBoxToggleState;",
                expectedResult);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Set-UiaCheckBoxToggleState")]
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
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Set-UiaCheckBoxToggleState $true; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Get-UiaCheckBoxToggleState;",
                expectedResult);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Set-UiaCheckBoxToggleState")]
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
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Set-UiaCheckBoxToggleState $false; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaCheckBox -Name '" +
                name +
                "' | Get-UiaCheckBoxToggleState;",
                expectedResult);
        }
    }
}
