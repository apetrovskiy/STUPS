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
    /// Description of InvokeUiaValuePatternSetCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UiaValuePatternSetCommand test")]
    public class InvokeUiaValuePatternSetCommandTestFixture
    {
        public InvokeUiaValuePatternSetCommandTestFixture()
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
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTextBox -AutomationId '" + 
                auId + 
                "' -timeout 2000 | Set-UiaTextBoxText -Text '" +
                expectedResult + 
                "'; " + 
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaTextBox -AutomationId '" +
                auId + 
                "'" +
                " | Get-UiaTextBoxText",
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
//                @"$null = Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UiaProgressBar -AutomationId " + 
//                auId + 
//                " -timeout 2000 | Set-UiaProgressBarValue -Text " +
//                expectedResult +
//                "; " + 
//                @"Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UiaProgressBarValue;",
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
