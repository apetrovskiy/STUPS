/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Pattern
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAValuePatternSetCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UIAValuePatternSetCommand test")]
    public class InvokeUIAValuePatternSetCommandTestFixture
    {
        public InvokeUIAValuePatternSetCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        // Calendar
        // ComboBox
        // Custom
        // DataItem
    
        // Edit
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Set_TextBox_Value()
        {
            string name = "aaa";
            string auId = "TextBox111";
            string expectedResult = "result";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                name,
                auId,
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -AutomationId '" + 
                auId + 
                "' -timeout 2000 | Set-UIATextBoxText -Text '" +
                expectedResult + 
                "'; " + 
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIATextBox -AutomationId '" +
                auId + 
                "'" +
                " | Get-UIATextBoxText",
                expectedResult);
        }
        
        // Hyperlink
        // ListItem
        
        // ProgressBar
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        public void Set_ProgressBar_Value()
//        {
//            string name = "aaa";
//            string auId = "progressBar1";
//            string expectedResult = "50";
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.ProgressBar,
//                name,
//                auId,
//                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UIAProgressBar -AutomationId " + 
//                auId + 
//                " -timeout 2000 | Set-UIAProgressBarValue -Text " +
//                expectedResult +
//                "; " + 
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UIAProgressBarValue;",
//                expectedResult);
//        }
        
        // Slider
        // Spinner
        // Text
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
