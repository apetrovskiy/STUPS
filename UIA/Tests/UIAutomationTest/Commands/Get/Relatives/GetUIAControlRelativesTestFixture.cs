/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/5/2012
 * Time: 6:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    /// <summary>
    /// Description of GetUiaControlRelativesTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Get-UiaControl[Relatives] test")]
    public class GetUiaControlRelativesTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlParent()
        {
            string auId = "Button111";
            string formName = MiddleLevelCode.TestFormNameEmpty;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | Get-UiaControlParent | Read-UiaControlName;",
                formName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlParent_OnlyOne()
        {
            string name = "ccc";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                name,
                "ddd",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -timeout 2000 | Get-UiaControlParent | Read-UiaControlName;",
                name);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlAncestors()
        {
            string auId = "Button111";
            string formName = MiddleLevelCode.TestFormNameEmpty;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | Get-UiaControlAncestors -ControlType Window | Read-UiaControlName;",
                formName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlAncestors_MoreThanOne()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -timeout 2000 | Get-UiaControlAncestors | Read-UiaControlName).Count;",
                "2");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlChildren()
        {
            string auId = "Button111";
            string formName = MiddleLevelCode.TestFormNameEmpty;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControlChildren -ControlType Button | " +
                "Read-UiaControlAutomationId;",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlDescendants()
        {
            string auId = "Button111";
            string formName = MiddleLevelCode.TestFormNameEmpty;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControlDescendants -ControlType Button | " +
                "Read-UiaControlAutomationId;",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlNextSibling()
        {
            string name1 = "Button111";
            string auId1 = "btn111";
            string name2 = "Button222";
            string auId2 = "btn22";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name1,
                    auId1, 
                    TimeoutsAndDelays.Control_Delay0));
            arrList.Add(
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name2,
                    auId2, 
                    TimeoutsAndDelays.Control_Delay0));
            ControlToForm[] ctf = (ControlToForm[])arrList.ToArray(typeof(ControlToForm));
            string formName = MiddleLevelCode.TestFormNameEmpty;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ctf);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaButton -Name '" +
                name1 + 
                "' | Get-UiaControlNextSibling | " +
                "Read-UiaControlAutomationId;",
                auId2);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlPreviousSibling()
        {
            string name1 = "Button111";
            string auId1 = "btn111";
            string name2 = "Button222";
            string auId2 = "btn22";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name1,
                    auId1, 
                    TimeoutsAndDelays.Control_Delay0));
            arrList.Add(
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name2,
                    auId2, 
                    TimeoutsAndDelays.Control_Delay0));
            ControlToForm[] ctf = (ControlToForm[])arrList.ToArray(typeof(ControlToForm));
            string formName = MiddleLevelCode.TestFormNameEmpty;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ctf);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaButton -Name '" +
                name2 + 
                "' | Get-UiaControlPreviousSibling | " +
                "Read-UiaControlAutomationId;",
                auId1);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlFirstChild()
        {
            string name1 = "Button111";
            string auId1 = "btn111";
            string name2 = "Button222";
            string auId2 = "btn22";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name1,
                    auId1, 
                    TimeoutsAndDelays.Control_Delay0));
            arrList.Add(
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name2,
                    auId2, 
                    TimeoutsAndDelays.Control_Delay0));
            ControlToForm[] ctf = (ControlToForm[])arrList.ToArray(typeof(ControlToForm));
            string formName = MiddleLevelCode.TestFormNameEmpty;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ctf);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaControlFirstChild | " +
                "Read-UiaControlAutomationId;",
                auId1);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControlRelatives")]
        public void GetControlLastChild()
        {
            string name1 = "Button111";
            string auId1 = "btn111";
            string name2 = "Button222";
            string auId2 = "btn22";
            string theAnswer = "TitleBar";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name1,
                    auId1, 
                    TimeoutsAndDelays.Control_Delay0));
            arrList.Add(
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name2,
                    auId2, 
                    TimeoutsAndDelays.Control_Delay0));
            ControlToForm[] ctf = (ControlToForm[])arrList.ToArray(typeof(ControlToForm));
            string formName = MiddleLevelCode.TestFormNameEmpty;
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ctf);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaControlLastChild | " +
                "Read-UiaControlAutomationId;",
                theAnswer);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
