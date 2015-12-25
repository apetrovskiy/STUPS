/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/7/2014
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModel
{
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of ISupportsTogglePatternTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsTogglePatternTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ISupportsToggle")]
        public void CheckBox_ToggleState_On()
        {
            const string expectedName = "chkboxName";
            int expectedResult = (int)ToggleState.On;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty,
                0,
                ControlType.CheckBox,
                expectedName,
                "chkboxAuId",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaCheckBox -Name " +
                expectedName + 
                ").Toggle($true); " +
                @"[int](Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaCheckBox -Name " +
                expectedName + 
                ").ToggleState; ",
                expectedResult.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ISupportsToggle")]
        public void CheckBox_ToggleState_Off()
        {
            const string expectedName = "chkboxName";
            int expectedResult = (int)ToggleState.Off;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty,
                0,
                ControlType.CheckBox,
                expectedName,
                "chkboxAuId",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaCheckBox -Name " +
                expectedName + 
                ").Toggle($true); " +
                @"$null = (Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaCheckBox -Name " +
                expectedName + 
                ").Toggle($false); " +
                @"[int](Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaCheckBox -Name " +
                expectedName + 
                ").ToggleState; ",
                expectedResult.ToString());
        }
    }
}
