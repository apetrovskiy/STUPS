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
    /// <summary>
    /// Description of GetUiaWindowCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class GetUiaWindowCommandTestFixture
    {
        public System.Diagnostics.Process process;
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UiaWindow -pn " + 
                "'wrong process name' -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: 'wrong process name' process Id:  window title: ''");
                // 20131108
                //"Failed to get the window by: process name: 'wrong process name', process Id: , window title: '', automationId: '', className: ',");
                // 20140110
                // "Failed to get window in 2000 seconds by: process name: 'wrong process name', process Id: , window title: '', automationId: '', className: ''");
                "Failed to get window in 2000 milliseconds by: process name: 'wrong process name', process Id: , window title: '', automationId: '', className: ''.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -pn " + 
                           MiddleLevelCode.TestFormProcess +
                           ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameDelay1000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay1000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("May Fail")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameTimeout5000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 5000)) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameDelay3000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay3000);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: 'UIAutomationTestForms' process Id:  window title: ''");
                // 20131108
                //"Failed to get the window by: process name: 'UIAutomationTestForms', process Id: , window title: '', automationId: '', className: ',");
                // 20140110
                // "Failed to get window in 3000 seconds by: process name: 'UIAutomationTestForms', process Id: , window title: '', automationId: '', className: ''");
                "Failed to get window in 3000 milliseconds by: process name: 'UIAutomationTestForms', process Id: , window title: '', automationId: '', className: ''.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameTimeout6000Delay3000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Control_Timeout6000Delay3000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 6000)) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameTimeout20000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 20000)) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameDelay4000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay4000);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: 'UIAutomationTestForms' process Id:  window title: ''");
                // 20131108
                //"Failed to get the window by: process name: 'UIAutomationTestForms', process Id: , window title: '', automationId: '', className: ',");
                // 20140110
                // "Failed to get window in 3000 seconds by: process name: 'UIAutomationTestForms', process Id: , window title: '', automationId: '', className: ''");
                "Failed to get window in 3000 milliseconds by: process name: 'UIAutomationTestForms', process Id: , window title: '', automationId: '', className: ''.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessNameTimeout8000Delay5000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay5000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 8000)) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByNameWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UiaWindow -n " + 
                "'wrong name' -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: '' process Id:  window title: 'wrong name'");
                // 20131108
                //"Failed to get the window by: process name: '', process Id: , window title: 'wrong name', automationId: '', className: ',");
                // 20140110
                // "Failed to get window in 2000 seconds by: process name: '', process Id: , window title: 'wrong name', automationId: '', className: ''");
                "Failed to get window in 2000 milliseconds by: process name: '', process Id: , window title: 'wrong name', automationId: '', className: ''.");

        }
        

        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowAsGlobalVariableEmpty()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if (([uiautomation.currentdata]::currentwindow.current.name" + 
                ")) { 0; } else { 1; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowAsGlobalVariableNotEmpty()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UiaWindow -Name " +
//                MiddleLevelCode.TestFormNameEmpty + 
//                "; " +
//                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
//                ")) { 0; } else { 1; }",
//                //"System.Windows.Automation.AutomationElement");
//                // 20131218
//                // "UIAutomation.UiElement");
//                // "Castle.Proxies.UiElementProxy");
//                "Castle.Proxies.UiElementProxy_1");

//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UiaWindow -Name " +
//                MiddleLevelCode.TestFormNameEmpty + 
//                "; " +
//                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
//                ")) { 0; } else { 1; }".Substring(0, 30),
//                "Castle.Proxies.UiElementProxy_1".Substring(0, 30));
            // 20140314
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -Name " +
                MiddleLevelCode.TestFormNameEmpty + 
                "; " +
                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
                ")) { 0; } else { 1; }",
                "Castle.Proxies.UiElementProxy_2");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowAsGlobalVariableSetNull()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"$ErrorActionPreference = [system.management.automation.actionpreference]::SilentlyContinue; " +
                @"try{ Get-UiaWindow -pn 'no such process' -seconds 2; } catch {} " +
                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
                ")) { 0; } else { 1; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByName_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByName_Wildcard1_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                "*" +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByName_Wildcard2_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Name *" + 
                MiddleLevelCode.TestFormNameEmpty +
                "*" +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByName_Wildcard3_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Name ?" + 
                MiddleLevelCode.TestFormNameEmpty.Substring(1, MiddleLevelCode.TestFormNameEmpty.Length - 2) +
                "?" +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByName_Wildcard4_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Name *" + 
                MiddleLevelCode.TestFormNameEmpty.Substring(2, 3) +
                "??" +
                MiddleLevelCode.TestFormNameEmpty.Substring(7, 2) +
                "*" +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByNameDelay1000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay1000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByNameTimeout5000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 5000)) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByNameTimeout3000Delay5000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay5000);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UiaWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 3000 " + 
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: '' process Id:  window title: 'WinFormsEmpty'");
                // 20131108
                //"Failed to get the window by: process name: '', process Id: , window title: 'WinFormsEmpty', automationId: '', className: ',");
                // 20140110
                // "Failed to get window in 3000 seconds by: process name: '', process Id: , window title: 'WinFormsEmpty', automationId: '', className: ''");
                "Failed to get window in 3000 milliseconds by: process name: '', process Id: , window title: 'WinFormsEmpty', automationId: '', className: ''.");


        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByAutomationId_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -AutomationId " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByAutomationId_WildCard_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -AutomationId '*Empty*'" + 
                //MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByClassName_WildCard_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Class '" + 
                @"*WindowsForms10.Window.8.app*'" +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByPIDWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UiaWindow -pid " + 
                "12345678 -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                // 20130318
                //"Failed to get the window by: process name: '' process Id: 12345678 window title: ''");
                // 20131108
                //"Failed to get the window by: process name: '', process Id: 12345678, window title: '', automationId: '', className: ',");
                // 20140110
                // "Failed to get window in 2000 seconds by: process name: '', process Id: 12345678, window title: '', automationId: '', className: ''");
                "Failed to get window in 2000 milliseconds by: process name: '', process Id: 12345678, window title: '', automationId: '', className: ''.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByPIDTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -pid " + 
                "(Get-Process -Name " +
                MiddleLevelCode.TestFormProcess +
                ").Id " +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessFoundTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-Process -Name " +
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaWindow" +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessStartedTimeoutDefault()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ((Start-Process '" +
                MiddleLevelCode.TestFormPath +
                // 20130130
                //"' -PassThru" +
                "'  -ArgumentList 1 -NoNewWindow -PassThru" +
                " | Get-UiaWindow" +
                ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaActiveWindow")]
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
                @"Get-UiaActiveWindow | Read-UIAcontrolName;",
                MiddleLevelCode.TestFormNameEmpty);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindowFromHandle")]
        public void GetWindowByHandle1TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void]($handle = Get-Process -Name " +
                MiddleLevelCode.TestFormProcess + 
                " | Get-UiaWindow | Read-UiaControlNativeWindowHandle); " +
                @"[void]([UIAutomation.CurrentData]::ResetData()); " +
                @"sleep -Seconds 2; " +
                "Get-UiaWindowFromHandle -Handle $handle | Read-UIAcontrolName;",
                MiddleLevelCode.TestFormNameEmpty);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByNameDelay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -n " + 
                           MiddleLevelCode.TestFormNameNoTaskBar +
                           ")) { 1; } else { 0; }");
        }
        
        
        
        // ================ Recurse ======================
        
        private void prepareThreeForms()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void](Get-UiaWindow -n '*outer*' | Get-UiaButton -n '*form*' | Invoke-UiaButtonClick); " +
                @"[void](Get-UiaWindow -n '*medium*' | Get-UiaButton -n '*form*' | Invoke-UiaButtonClick);");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessName_Recurse_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsThreeSet, 0);
            prepareThreeForms();
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                " -Recurse).Count;",
                "3");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcessId_Recurse_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsThreeSet, 0);
            prepareThreeForms();
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaWindow -pid (Get-Process " +
                MiddleLevelCode.TestFormProcess +
                ").Id -Recurse).Count",
                "3");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByProcess_Recurse_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsThreeSet, 0);
            prepareThreeForms();
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UiaWindow -InputObject (Get-Process " +
                MiddleLevelCode.TestFormProcess +
                ") -Recurse).Count",
                "3");
        }
        
        // this is not supported
//        [MbUnit.Framework.Test][NUnit.Framework.Test]
//        [MbUnit.Framework.Category("Slow")]
//        [MbUnit.Framework.Category("WinForms")]
//        [MbUnit.Framework.Category("Get_UiaWindow")]
//        public void GetWindowByName_Recurse_TimeoutDefault()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsThreeSet, 0);
//            prepareThreeForms();
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"(Get-UiaWindow -n '*winform*' -Recurse).Count",
//                "3");
//        }
        
        // =============== WithControl ====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
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
                "Get-UiaWindow -Name '" +
                MiddleLevelCode.TestFormNameEmpty +
                "' -timeout 5000 -WithControl @{controlType=\"button\";name=\"*OK*\"} | Read-UiaControlName;",
                MiddleLevelCode.TestFormNameEmpty);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
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
                "Get-UiaWindow -Name '" +
                MiddleLevelCode.TestFormNameEmpty +
                "' -timeout 5000 -WithControl @{controlType=\"button\";name=\"*Nope*\"} | Read-UiaControlName;",
                "CmdletInvocationException",
                "");
        }
        
        // ================================================
        
        
        // =============the -Win32 parameter===============
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByName_Win32_Delay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Win32 -n " + 
                           MiddleLevelCode.TestFormNameNoTaskBar +
                           ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByAutomationId_Win32_Delay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Win32 -au " + 
                           MiddleLevelCode.TestFormNameNoTaskBar +
                           ")) { 1; } else { 0; }");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Get_UiaWindow")]
        public void GetWindowByClass_Win32_Delay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UiaWindow -Win32 -class " + 
                           @"*WindowsForms10.Window.8.app.0*" +
                           ")) { 1; } else { 0; }");
        }
        // ================================================
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
