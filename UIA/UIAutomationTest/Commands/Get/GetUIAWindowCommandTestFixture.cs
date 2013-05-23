/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using System.Diagnostics;
    using MbUnit.Framework;

    /// <summary>
    /// Description of GetUIAWindowCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Get-UIAWindowCommand test")]
    public class GetUIAWindowCommandTestFixture
    {
        public GetUIAWindowCommandTestFixture()
        {
        }
        
        public System.Diagnostics.Process process;
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " + 
                "'wrong process name' -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: 'wrong process name' process Id:  window title: ''");
                "Failed to get the window by: process name: 'wrong process name', process Id: , window title: '', automationId: '', className: ',");

        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                           MiddleLevelCode.TestFormProcess +
                           ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay1000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay1000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("May Fail")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout5000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 5000)) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay3000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay3000);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: 'UIAutomationTestForms' process Id:  window title: ''");
                "Failed to get the window by: process name: 'UIAutomationTestForms', process Id: , window title: '', automationId: '', className: ',");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout6000Delay3000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Control_Timeout6000Delay3000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 6000)) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout20000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 20000)) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay4000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay4000);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: 'UIAutomationTestForms' process Id:  window title: ''");
                "Failed to get the window by: process name: 'UIAutomationTestForms', process Id: , window title: '', automationId: '', className: ',");

        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout8000Delay5000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay5000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 8000)) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -n " + 
                "'wrong name' -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: '' process Id:  window title: 'wrong name'");
                "Failed to get the window by: process name: '', process Id: , window title: 'wrong name', automationId: '', className: ',");

        }
        

        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowAsGlobalVariableEmpty()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if (([uiautomation.currentdata]::currentwindow.current.name" + 
                ")) { 0; } else { 1; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowAsGlobalVariableNotEmpty()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -Name " +
                MiddleLevelCode.TestFormNameEmpty + 
                "; " +
                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
                ")) { 0; } else { 1; }",
                "System.Windows.Automation.AutomationElement");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowAsGlobalVariableSetNull()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"$ErrorActionPreference = [system.management.automation.actionpreference]::SilentlyContinue; " +
                @"try{ Get-UIAWindow -pn 'no such process' -seconds 2; } catch {} " +
                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
                ")) { 0; } else { 1; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByName_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByName_Wildcard1_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                "*" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByName_Wildcard2_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name *" + 
                MiddleLevelCode.TestFormNameEmpty +
                "*" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByName_Wildcard3_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name ?" + 
                MiddleLevelCode.TestFormNameEmpty.Substring(1, MiddleLevelCode.TestFormNameEmpty.Length - 2) +
                "?" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByName_Wildcard4_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name *" + 
                MiddleLevelCode.TestFormNameEmpty.Substring(2, 3) +
                "??" +
                MiddleLevelCode.TestFormNameEmpty.Substring(7, 2) +
                "*" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameDelay1000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay1000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameTimeout5000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 5000)) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameTimeout3000Delay5000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay5000);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 3000 " + 
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: '' process Id:  window title: 'WinFormsEmpty'");
                "Failed to get the window by: process name: '', process Id: , window title: 'WinFormsEmpty', automationId: '', className: ',");



        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByAutomationId_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -AutomationId " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByAutomationId_WildCard_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -AutomationId '*Empty*'" + 
                //MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByClassName_WildCard_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Class '" + 
                @"*WindowsForms10.Window.8.app*'" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByPIDWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pid " + 
                "12345678 -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: '' process Id: 12345678 window title: ''");
                "Failed to get the window by: process name: '', process Id: 12345678, window title: '', automationId: '', className: ',");

        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByPIDTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pid " + 
                "(Get-Process -Name " +
                MiddleLevelCode.TestFormProcess +
                ").Id " +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessFoundTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-Process -Name " +
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAWindow" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessStartedTimeoutDefault()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ((Start-Process '" +
                MiddleLevelCode.TestFormPath +
                // 20130130
                //"' -PassThru" +
                "'  -ArgumentList 1 -NoNewWindow -PassThru" +
                " | Get-UIAWindow" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAActiveWindow")]
        public void GetActiveWindow()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                "btn",
                "id",
                TimeoutsAndDelays.Control_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"sleep -Seconds 1; " +
                @"Get-UIAActiveWindow | Read-UIAcontrolName;",
                MiddleLevelCode.TestFormNameEmpty);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindowFromHandle")]
        public void GetWindowByHandle1TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void]($handle = Get-Process -Name " +
                MiddleLevelCode.TestFormProcess + 
                " | Get-UIAWindow | Read-UIAControlNativeWindowHandle); " +
                @"[void]([UIAutomation.CurrentData]::ResetData()); " +
                @"sleep -Seconds 2; " +
                "Get-UIAWindowFromHandle -Handle $handle | Read-UIAcontrolName;",
                MiddleLevelCode.TestFormNameEmpty);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameDelay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -n " + 
                           MiddleLevelCode.TestFormNameNoTaskBar +
                           ")) { 1; } else { 0; }");
        }
        
        
        
        // =============== Recurse ======================
        
        private void prepareThreeForms()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void](Get-UIAWindow -n '*outer*' | Get-UIAButton -n '*form*' | Invoke-UIAButtonClick); " +
                @"[void](Get-UIAWindow -n '*medium*' | Get-UIAButton -n '*form*' | Invoke-UIAButtonClick);");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessName_Recurse_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsThreeSet, 0);
            prepareThreeForms();
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                " -Recurse).Count;",
                "3");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessId_Recurse_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsThreeSet, 0);
            prepareThreeForms();
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -pid (Get-Process " +
                MiddleLevelCode.TestFormProcess +
                ").Id -Recurse).Count",
                "3");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcess_Recurse_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsThreeSet, 0);
            prepareThreeForms();
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -InputObject (Get-Process " +
                MiddleLevelCode.TestFormProcess +
                ") -Recurse).Count",
                "3");
        }
        
        // this is not supported
//        [Test]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Get_UIAWindow")]
//        public void GetWindowByName_Recurse_TimeoutDefault()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsThreeSet, 0);
//            prepareThreeForms();
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"(Get-UIAWindow -n '*winform*' -Recurse).Count",
//                "3");
//        }
        
        // ================================================
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByName_WithControl_Timeout5000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty,
                0,
                System.Windows.Automation.ControlType.Button,
                "OK",
                "btn",
                TimeoutsAndDelays.Control_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                "Get-UIAWindow -Name '" +
                MiddleLevelCode.TestFormNameEmpty +
                "' -timeout 5000 -WithControl @{controlType=\"button\";name=\"*OK*\"} | Read-UIAControlName;",
                MiddleLevelCode.TestFormNameEmpty);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByName_WithControl_Wrong_Timeout5000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty,
                0,
                System.Windows.Automation.ControlType.Button,
                "OK",
                "btn",
                TimeoutsAndDelays.Control_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                "Get-UIAWindow -Name '" +
                MiddleLevelCode.TestFormNameEmpty +
                "' -timeout 5000 -WithControl @{controlType=\"button\";name=\"*Nope*\"} | Read-UIAControlName;",
                "CmdletInvocationException",
                "");
        }
        
        // ================================================
        
        
        // =============the -Win32 parameter===============
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByName_Win32_Delay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Win32 -n " + 
                           MiddleLevelCode.TestFormNameNoTaskBar +
                           ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByAutomationId_Win32_Delay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Win32 -au " + 
                           MiddleLevelCode.TestFormNameNoTaskBar +
                           ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByClass_Win32_Delay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Win32 -class " + 
                           @"*WindowsForms10.Window.8.app.0*" +
                           ")) { 1; } else { 0; }");
        }
        // ================================================
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
