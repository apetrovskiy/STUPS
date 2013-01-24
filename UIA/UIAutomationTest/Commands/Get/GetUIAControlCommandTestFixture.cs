/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIAControlCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Get-UIAControlCommand test")]
    public class GetUIAControlCommandTestFixture
    {
        public GetUIAControlCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByAutomationIDTimeoutDefault()
        {
            string auId = "Button111";
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
                " | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByAutomationIDTimeout2000()
        {
            string auId = "Button111";
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
                " -timeout 2000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByAutomationIDTimeout3000Delay500()
        {
            string auId = "Button111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " -timeout 3000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByAutomationIDTimeout2000Delay4000()
        {
            string auId = "Button111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByTitleTimeoutDefault()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByTitleTimeout2000()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -timeout 2000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByTitleTimeout3000Delay500()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -timeout 3000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByTitleTimeout2000Delay4000()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -timeout 2000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByControlTypeTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -ControlType Button | Read-UIAControlType",
                "ControlType.Button");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByControlTypeTimeout2000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -ControlType Button -timeout 2000 | Read-UIAControlType",
                "ControlType.Button");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByControlTypeTimeout3000Delay500()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -ControlType Button -timeout 3000 | Read-UIAControlType",
                "ControlType.Button");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByControlTypeTimeout2000Delay4000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -ControlType Button -timeout 2000 | Read-UIAControlType",
                "ControlType.Button");
        }
        
// [Test] //[Test(Description="TBD")]
// [Category("Slow")][Category("WinForms")]
// [Category("Slow")][Category("Control")]
// public void GetControlByClassTimeoutDefault()
// {
// MiddleLevelCode.StartProcessWithFormAndControl(
// UIAutomationTestForms.Forms.WinFormsEmpty, 
// 0,
// System.Windows.Automation.ControlType.Button,
// 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
// @"Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " | Get-UIAControl -Class 'WindowsForms10.BUTTON.app.0.141b42a_r15_ad1' | " + 
// "Read-UIAControlClass",
// "WindowsForms10.BUTTON.app.0.141b42a_r15_ad1");
// } // WindowsForms10.BUTTON.app.0.378734a


        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByName_WildCard1_Timeout2000Delay4000()
        {
            string name = "ccc";
            string nameToSearch = "c*c";
            string auId = "ddd";
            ControlToForm ctf = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name,
                    auId, 
                    TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(ctf);
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl -ControlType Button -Name " + 
                nameToSearch +
                " -timeout 2000 | Read-UIAControlName;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByName_WildCard2_Timeout2000Delay4000()
        {
            string name = "co?ntro*NaME";
            string nameToSearch = "co*tro*ame";
            string auId = "au*";
            ControlToForm ctf = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name,
                    auId, 
                    TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(ctf);
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl -ControlType Button -Name " + 
                nameToSearch +
                " -timeout 2000 | Read-UIAControlName;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByName_WildCard3_Timeout2000Delay4000()
        {
            string name = "co?ntro*NaME";
            string nameToSearch = "co*tro*ame";
            string auId = "au*";
            ControlToForm ctf = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name,
                    auId, 
                    TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(ctf);
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAButton -Name " + 
                nameToSearch +
                " -timeout 2000 | Read-UIAControlName;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByName_WildCard4_Timeout2000Delay4000()
        {
            string name = "co?ntro*NaME";
            string nameToSearch = "co*tro*ame";
            string auId = "au*";
            ControlToForm ctf = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Text,
                    name,
                    auId, 
                    TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(ctf);
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIALabel -Name " + 
                nameToSearch +
                " -timeout 2000 | Read-UIAControlName;",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByAutomationId_WildCard1_Timeout2000Delay4000()
        {
            string name = "ccc";
            string auId = "ddd";
            string auIdToSearch = "d*d";
            ControlToForm ctf = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name,
                    auId, 
                    TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(ctf);
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl -ControlType Button -AutomationId " + 
                auIdToSearch +
                " -timeout 2000 | Read-UIAControlAutomationId;",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByAutomationId_WildCard2_Timeout2000Delay4000()
        {
            string name = "controlN[a-z]me";
            string auId = "?d&d*";
            string auIdToSearch = "*[?]d*d*";
            ControlToForm ctf = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    name,
                    auId, 
                    TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            arrList.Add(ctf);
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl -ControlType Button -AutomationId " + 
                auIdToSearch +
                " -timeout 2000 | Read-UIAControlAutomationId;",
                auId);
        }
        
        
        // the -Win32 parameter
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Win32")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByTitle_Win32_TimeoutDefault()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -Win32 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Win32")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByTitle_Win32_Timeout2000()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -Win32 -timeout 2000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Win32")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByTitle_Win32_Timeout3000Delay500()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -Win32 -timeout 3000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Win32")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByTitle_Win32_Timeout2000Delay4000()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -Win32 -timeout 2000 | " +
                "Read-UIAControlName",
                name);
        }
        
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetAllButtons_TimeoutDefault()
        {
            string answer = "34";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                TimeoutsAndDelays.Form_Delay0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAButton -Name *).Count;",
                answer);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByHashtable_Name_TimeoutDefault()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -SearchCriteria @{name=\"" + 
                name + "\"} | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByHashtable_AutomaitonId_TimeoutDefault()
        {
            string name = "Button222";
            string automationId = "btn";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                automationId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -SearchCriteria @{automationid=\"" + 
                automationId + "\"} | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByHashtable_ControlType_TimeoutDefault()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -SearchCriteria @{controltype=\"button\"} | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByHashtable_IsKeyboardFocusable_TimeoutDefault()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -SearchCriteria @{iskeyboardfocusable=\"true\"} | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByHashtable_WrongName_TimeoutDefault()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -SearchCriteria @{name=\"" + 
                "nope" + "\"} | " +
                "Read-UIAControlName",
                "CmdletInvocationException",
                "Get-UIAControl: timeout expired for class: ' + , control type: , title: ");
        }
        
//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongName_TimeoutDefault:
//System.Management.Automation.CmdletInvocationException : A generic error occurred in GDI+.
//  ----> System.Runtime.InteropServices.ExternalException : A generic error occurred in GDI+.

//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongName_TimeoutDefault:
//  Expected string length 54 but was 25. Strings differ at index 0.
//  Expected: "System.Management.Automation.CmdletInvocationException"
//  But was:  "CmdletInvocationException"
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongName_TimeoutDefault:
//  Expected string length 33 but was 71. Strings differ at index 0.
//  Expected: "A generic error occurred in GDI+."
//  But was:  "GetUIAControl: timeout expired for class: ' + , control type:..."
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongName_TimeoutDefault:
//  Expected string length 61 but was 71. Strings differ at index 61.
//  Expected: "...rol: timeout expired for class: ' + , control type:"
//  But was:  "...rol: timeout expired for class: ' + , control type: , title: "
//  -----------------------------------------------------------------^

//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongName_TimeoutDefault:
//  Expected string length 71 but was 72. Strings differ at index 3.
//  Expected: "GetUIAControl: timeout expired for class: ' + , control type:..."
//  But was:  "Get-UIAControl: timeout expired for class: ' + , control type..."
//  --------------^


        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByHashtable_WrongAutomationId_TimeoutDefault()
        {
            string name = "Button222";
            string automationId = "nope";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name '" + 
                name +
                "' -SearchCriteria @{automationid=\"" +
                // 20121120
                //name + "\"} | " +
                automationId + 
                "\"} | " +
                "Read-UIAControlName",
                "CmdletInvocationException",
                "Get-UIAControl: timeout expired for class: ' + , control type: , title: Button222");
        }
        
//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongAutomationId_TimeoutDefault:
//System.Management.Automation.CmdletInvocationException : A generic error occurred in GDI+.
//  ----> System.Runtime.InteropServices.ExternalException : A generic error occurred in GDI+.

//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongAutomationId_TimeoutDefault:
//  Expected string length 54 but was 25. Strings differ at index 0.
//  Expected: "System.Management.Automation.CmdletInvocationException"
//  But was:  "CmdletInvocationException"
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongAutomationId_TimeoutDefault:
//  Expected string length 33 but was 80. Strings differ at index 0.
//  Expected: "A generic error occurred in GDI+."
//  But was:  "GetUIAControl: timeout expired for class: ' + , control type:..."
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongAutomationId_TimeoutDefault:
//  Expected string length 61 but was 80. Strings differ at index 61.
//  Expected: "...out expired for class: ' + , control type:"
//  But was:  "...out expired for class: ' + , control type: , title: Button222"
//  --------------------------------------------------------^

//UIAutomationTest.Commands.Get.GetUIAControlCommandTestFixture.GetControlByHashtable_WrongAutomationId_TimeoutDefault:
//  Expected string length 80 but was 81. Strings differ at index 3.
//  Expected: "GetUIAControl: timeout expired for class: ' + , control type:..."
//  But was:  "Get-UIAControl: timeout expired for class: ' + , control type..."
//  --------------^


//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Get_UIAControl")]
//        public void GetControlByHashtable_WildCard1_TimeoutDefault()
//        {
//            string name = "ccc";
//            string nameToSearch = "c*c";
//            string auId = "ddd";
//            ControlToForm ctf = 
//                new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    name,
//                    auId, 
//                    TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
//            System.Collections.ArrayList arrList = 
//                new System.Collections.ArrayList();
//            arrList.Add(ctf);
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -n " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " | Get-UIAControl -ControlType Button -Name " + 
//                nameToSearch +
//                " -timeout 2000 | Read-UIAControlName;",
//                name);
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        [Category("Slow")][Category("Get_UIAControl")]
        public void GetControlByHashtable_Name_AutomationId_TimeoutDefault()
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
            
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject(name1));
            coll.Add(new System.Management.Automation.PSObject(name2));
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ctf);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAButton -SearchCriteria @{Name='" +
                name1 + 
                "'},@{automationid='" + 
                auId2 +
                "'} | " +
                "Read-UIAControlName;",
                coll);
        }
        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Get_UIAControl")]
//        public void GetControlByHashtable_WildCard1_TimeoutDefault()
//        {
//            string name = "ccc";
//            string nameToSearch = "c*c";
//            string auId = "ddd";
//            ControlToForm ctf = 
//                new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    name,
//                    auId, 
//                    TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
//            System.Collections.ArrayList arrList = 
//                new System.Collections.ArrayList();
//            arrList.Add(ctf);
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -n " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " | Get-UIAControl -ControlType Button -Name " + 
//                nameToSearch +
//                " -timeout 2000 | Read-UIAControlName;",
//                name);
//        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
