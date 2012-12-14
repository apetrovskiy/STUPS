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
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetUIAControlRelativesTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Get-UIAControl[Relatives] test")]
    public class GetUIAControlRelativesTestFixture
    {
        public GetUIAControlRelativesTestFixture()
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
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | Get-UIAControlParent | Read-UIAControlName;",
                formName);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATable -timeout 2000 | Get-UIAControlParent | Read-UIAControlName;",
                name);
        }
        
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | Get-UIAControlAncestors -ControlType Window | Read-UIAControlName;",
                formName);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"(Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATable -timeout 2000 | Get-UIAControlAncestors | Read-UIAControlName).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControlChildren -ControlType Button | " +
                "Read-UIAControlAutomationId;",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControlDescendants -ControlType Button | " +
                "Read-UIAControlAutomationId;",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAButton -Name '" +
                name1 + 
                "' | Get-UIAControlNextSibling | " +
                "Read-UIAControlAutomationId;",
                auId2);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAButton -Name '" +
                name2 + 
                "' | Get-UIAControlPreviousSibling | " +
                "Read-UIAControlAutomationId;",
                auId1);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAControlFirstChild | " +
                "Read-UIAControlAutomationId;",
                auId1);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControlRelatives")]
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
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAControlLastChild | " +
                "Read-UIAControlAutomationId;",
                theAnswer);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
