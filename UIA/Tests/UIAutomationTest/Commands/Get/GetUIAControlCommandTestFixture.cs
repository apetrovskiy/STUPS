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
    /// <summary>
    /// Description of GetUiaControlCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Get-UiaControlCommand test")]
    public class GetUiaControlCommandTestFixture
    {
        public GetUiaControlCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " -timeout 3000 | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name " + 
                name + " | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name " + 
                name + " -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name " + 
                name + " -timeout 3000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name " + 
                name + " -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -ControlType Button | Read-UiaControlType",
                "ControlType.Button");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -ControlType Button -timeout 2000 | Read-UiaControlType",
                "ControlType.Button");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -ControlType Button -timeout 3000 | Read-UiaControlType",
                "ControlType.Button");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -ControlType Button -timeout 2000 | Read-UiaControlType",
                "ControlType.Button");
        }
        
// [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
// [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
// [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
// public void GetControlByClassTimeoutDefault()
// {
// MiddleLevelCode.StartProcessWithFormAndControl(
// UIAutomationTestForms.Forms.WinFormsEmpty, 
// 0,
// System.Windows.Automation.ControlType.Button,
// 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
// @"Get-UiaWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " | Get-UiaControl -Class 'WindowsForms10.BUTTON.app.0.141b42a_r15_ad1' | " + 
// "Read-UiaControlClass",
// "WindowsForms10.BUTTON.app.0.141b42a_r15_ad1");
// } // WindowsForms10.BUTTON.app.0.378734a


        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaControl -ControlType Button -Name " + 
                nameToSearch +
                " -timeout 2000 | Read-UiaControlName;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaControl -ControlType Button -Name " + 
                nameToSearch +
                " -timeout 2000 | Read-UiaControlName;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaButton -Name " + 
                nameToSearch +
                " -timeout 2000 | Read-UiaControlName;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaLabel -Name " + 
                nameToSearch +
                " -timeout 2000 | Read-UiaControlName;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaControl -ControlType Button -AutomationId " + 
                auIdToSearch +
                " -timeout 2000 | Read-UiaControlAutomationId;",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaControl -ControlType Button -AutomationId " + 
                auIdToSearch +
                " -timeout 2000 | Read-UiaControlAutomationId;",
                auId);
        }
        
        
        // the -Win32 parameter
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Win32")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name " + 
                name + " -Win32 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Win32")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name " + 
                name + " -Win32 -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Win32")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name " + 
                name + " -Win32 -timeout 3000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Win32")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name " + 
                name + " -Win32 -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetAllButtons_TimeoutDefault()
        {
            // 20140109
            // string answer = "34";
            string answer = "36";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                TimeoutsAndDelays.Form_Delay0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaButton -Name *).Count;",
                answer);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -SearchCriteria @{name=\"" + 
                name + "\"} | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByHashtable_AutomationId_TimeoutDefault()
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -SearchCriteria @{automationid=\"" + 
                automationId + "\"} | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -SearchCriteria @{controltype=\"button\"} | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -SearchCriteria @{iskeyboardfocusable=\"true\"} | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -SearchCriteria @{name=\"" + 
                "nope" + "\"} | " +
                "Read-UiaControlName",
                "CmdletInvocationException",
                // 20130219
                //"Get-UiaControl: timeout expired for class: ' + , control type: , title: ");
                // 20140110
                // @"Get-UiaControl: timeout expired for control with class: + '', control type: '', title: '', automationId: '', value: ''.");
                //@"Get-UiaControl: timeout expired for control with class: + '', control type: '', title: '', automationId: '', value: ''");
                // 20140111
                // @"Get-UiaControl: failed to get control in 3000 milliseconds by: title: '', automationId: '', className: '', value: ''.");
                @"failed to get control in 3000 milliseconds by: title: '', automationId: '', className: '', value: ''.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -Name '" + 
                name +
                "' -SearchCriteria @{automationid=\"" +
                // 20121120
                //name + "\"} | " +
                automationId + 
                "\"} | " +
                "Read-UiaControlName",
                "CmdletInvocationException",
                // 20130219
                //"Get-UiaControl: timeout expired for class: ' + , control type: , title: Button222");
                // 20140110
                // @"Get-UiaControl: timeout expired for control with class: + '', control type: '', title: 'Button222', automationId: '', value: ''");
                // 20140110
                // @"Get-UiaControl: failed to get control in 3000 milliseconds by: title: 'Button222', automationId: '', className: '', value: ''");
                // @"Get-UiaControl: failed to get control in 3000 milliseconds by: title: '', automationId: '', className: '', value: ''.");
                // 20140111
                // @"Get-UiaControl: failed to get control in 3000 milliseconds by: title: 'Button222', automationId: '', className: '', value: ''.");
                @"failed to get control in 3000 milliseconds by: title: 'Button222', automationId: '', className: '', value: ''.");
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Get_UiaControl")]
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
//                @"Get-UiaWindow -n " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " | Get-UiaControl -ControlType Button -Name " + 
//                nameToSearch +
//                " -timeout 2000 | Read-UiaControlName;",
//                name);
//        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaButton -SearchCriteria @{Name='" +
                name1 + 
                "'},@{automationid='" + 
                auId2 +
                "'} | " +
                "Read-UiaControlName;",
                coll);
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Get_UiaControl")]
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
//                @"Get-UiaWindow -n " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " | Get-UiaControl -ControlType Button -Name " + 
//                nameToSearch +
//                " -timeout 2000 | Read-UiaControlName;",
//                name);
//        }



// =========================================================

        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByTextSearch_AutomationId_Timeout2000()
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByTextSearch_Title_Timeout2000()
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl " + 
                name + " -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByTextSearch_Win32_Title_Timeout2000()
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
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl " + 
                name + " -Win32 -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByTextSearch_Value_Timeout2000()
        {
            string auId = "Edit222";
            string expectedString = "my text";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "edit", // name?
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId '" + 
                auId + "' | " +
                "Clear-UiaControlText | " +
                "Set-UiaControlText '" +
                expectedString +
                "'; " +
                "Get-UiaControl '" +
                expectedString +
                "' -timeout 2000 | Read-UiaControlAutomationId;",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByTextSearch_Win32_Value_Timeout2000()
        {
            string auId = "Edit222";
            string expectedString = "my text";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "edit", // name?
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId '" + 
                auId + "' | " +
                "Clear-UiaControlText | " +
                "Set-UiaControlText '" +
                expectedString +
                "'; " +
                "Get-UiaControl '" +
                expectedString +
                "' -Win32 -timeout 2000 | Read-UiaControlAutomationId;",
                auId);
        }
        
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
//        [MbUnit.Framework.Category("Slow")]
//        [MbUnit.Framework.Category("WinForms")]
//        [MbUnit.Framework.Category("Control")]
//        [MbUnit.Framework.Category("Get_UiaControl")]
//        public void GetControlByTextSearch_ControlType_Timeout2000()
//        {
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                "ccc",
//                "ddd",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UiaWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Get-UiaControl -ControlType Button -timeout 2000 | Read-UiaControlType",
//                "ControlType.Button");
//        }

// =========================================================


        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByValue_WildCard_TimeoutDefault() //Timeout2000()
        {
            string auId1 = "Edit1";
            string expectedValue = "my text";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "aaa",
                auId1,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId1 + 
                " | " +
                //"Set-UIAcontrolText -Text '" +
                "Set-UiaEditText -Text '" +
                expectedValue +
                "'; Get-UiaEdit -Value '" +
                expectedValue +
                //"' -timeout 2000 | Get-UiaEditText;",
                "' | Get-UiaEditText;",
                expectedValue);
        }

        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByValue_Win32_WildCard_TimeoutDefault() //Timeout2000()
        {
            string auId1 = "Edit1";
            string expectedValue = "my text";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "aaa",
                auId1,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId1 + 
                " | " +
                //"Set-UIAcontrolText -Text '" +
                "Set-UiaEditText -Text '" +
                expectedValue +
                "'; Get-UiaEdit -Value '" +
                expectedValue +
                //"' -timeout 2000 | Get-UiaEditText;",
                "' -Win32 | Get-UiaEditText;",
                expectedValue);
        }

        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByValueX2_WildCard_TimeoutDefault()
        {
            string auId1 = "Edit1";
            string auId2 = "Edit2";
            string expectedValue = "my text";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "e1",
                    auId1, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "e2",
                    auId2, 
                    0);
            arrList.Add(ctf2);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UiaControl -AutomationId Edit* | Set-UiaEditText -Text '" + 
                expectedValue +
                "'; Get-UiaEdit -Value '" +
                expectedValue +
                "' | Get-UiaEditText;",
                expectedValue);
        }

        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByValueAndAutomationId_WildCard_TimeoutDefault()
        {
            string auId1 = "Edit1";
            string expectedValue = "my text";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                "aaa",
                auId1,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId1 + 
                " | " +
                "Set-UiaEditText -Text '" +
                expectedValue +
                "'; Get-UiaEdit -Value '" +
                expectedValue +
                "' -AutomationId '" +
                auId1 +
                "' | Get-UiaEditText;",
                expectedValue);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Get_UiaControl")]
        public void GetControlByNoValueAndAutomationId_WildCard_Timeout2000()
        {
            string auId1 = "Button1";
            string expectedValue = "my text";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId1,
                0);
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaButton -Value '" +
                expectedValue +
                "' -AutomationId '" +
                auId1 +
                "' -timeout 2000;",
                "CmdletInvocationException",
                // 20130219
                //@"Get-UiaButton: timeout expired for class: ' + , control type: Button, title:");
                // 20131129
                // @"Get-UiaButton: timeout expired for control with class: + '', control type: 'Button', title: '', automationId: 'Button1', value: 'my text'");
                // 20140110
                // @"Get-UiaButton: timeout expired for control with class: + '', control type: 'System.String[]', title: '', automationId: 'Button1', value: 'my text'");
                // 20140111
                // @"Get-UiaButton: failed to get control in 2000 milliseconds by: title: '', automationId: 'Button1', className: '', value: 'my text'.");
                @"failed to get control in 2000 milliseconds by: title: '', automationId: 'Button1', className: '', value: 'my text'.");
        }

// =========================================================
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
