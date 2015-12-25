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
    /// <summary>
    /// Description of InvokeUiaSelectionItemPatternCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Invoke-UiaSelectionItemPatternCommand test")]
    public class InvokeUiaSelectionItemPatternCommandTestFixture
    {
        public InvokeUiaSelectionItemPatternCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        public void InvokeSelectItem_RadioButton()
        {
            string name1 = "RadioButton1";
            string auId1 = "rb111";
            string name2 = "RadioButton2";
            string auId2 = "rb222";
            string expectedResult = "True";
            ControlToForm ctf = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.RadioButton,
                    name1,
                    auId1, 
                    TimeoutsAndDelays.Control_Delay0);
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(ctf);
            ctf = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.RadioButton,
                    name2,
                    auId2, 
                    TimeoutsAndDelays.Control_Delay0);
            arrList.Add(ctf);
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaRadioButton -AutomationId '" + 
                auId1 + 
                "' | Invoke-UiaRadioButtonSelectItem -ItemName '" + 
                name1 +
                @"';" +
                @"Get-UiaRadioButton -AutomationId '" + 
                auId1 + 
                "' | Get-UiaRadioButtonSelectionItemState;",
                expectedResult);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
