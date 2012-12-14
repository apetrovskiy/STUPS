/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/22/2012
 * Time: 10:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Pattern
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIASelectionItemStateCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UIASelectionItemStateCommand test")]
    public class InvokeUIASelectionItemStateCommandTestFixture
    {
        public InvokeUIASelectionItemStateCommandTestFixture()
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
        // the same as InvokeSelectItem_RadioButton()
        public void InvokeSelectionItemState_RadioButton()
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
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIARadioButton -AutomationId '" + 
                auId1 + 
                "' | Invoke-UIARadioButtonSelectItem -ItemName '" + 
                name1 +
                @"';" +
                @"Get-UIARadioButton -AutomationId '" + 
                auId1 + 
                "' | Get-UIARadioButtonSelectionItemState;",
                expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
