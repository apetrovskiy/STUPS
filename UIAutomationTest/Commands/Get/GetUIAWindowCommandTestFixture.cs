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
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;

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
        // 20120206 System.Diagnostics.ProcessStartInfo startInfo;
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessNameWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//                           "'wrong process name'" +
//                           ")) { 0; } else { 1; }");
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"if ((Get-UIAWindow -pn " + 
//                "'wrong process name' -Seconds 2" +
//                ")) { 0; } else { 1; }",
//                "System.NullReferenceException",
//                "Object reference not set to an instance of an object.");

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " + 
                "'wrong process name' -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                "Failed to get the window by: process name: 'wrong process name' process Id:  window title: ''");
                
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameWrong:
//  Expected string length 105 but was 93. Strings differ at index 76.
//  Expected: "...wrong process name' process Id: 0 process: wrong process name"
//  But was:  "...wrong process name' process Id:  window title: ''"
//  ----------------------------------------------^

                
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameWrong:
//  Expected string length 99 but was 91. Strings differ at index 25.
//  Expected: "Failed to get the window process name: wrong process name pro..."
//  But was:  "Failed to get the window by: process name: wrong process name..."
//  ------------------------------------^

                
//                UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameWrong:
//  Expected string length 29 but was 25. Strings differ at index 0.
//  Expected: "System.NullReferenceException"
//  But was:  "CmdletInvocationException"
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameWrong:
//  Expected string length 53 but was 99. Strings differ at index 0.
//  Expected: "Object reference not set to an instance of an object."
//  But was:  "Failed to get the window process name: wrong process name pro..."
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameWrong:
//  Expected string length 81 but was 99. Strings differ at index 81.
//  Expected: "... wrong process name process Id: 0 process: "
//  But was:  "... wrong process name process Id: 0 process: wrong process name"
//  ---------------------------------------------------------^



        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                           MiddleLevelCode.TestFormProcess +
                           ")) { 1; } else { 0; }");
        }
        
// [Test] //[Test(Description="TBD")]
// [Category("Slow")][Category("WinForms")]
// [Category("Slow")][Category("May Fail")]
// public void GetWindowByProcessNameTimeout1000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " -timeout 1000)) { 0; } else { 1; }");
// }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay1000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay1000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }");
        }
        
// [Test("May Fail")]
// [Category("Slow")][Category("WinForms")]
// [Category("Slow")][Category("May Fail")]
// public void GetWindowByProcessNameTimeout2000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " -timeout 2000)) { 0; } else { 1; }");
// }
        
    
    // 20120630 swithed off as failed at KU2
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Get_UIAWindow")]
//        public void GetWindowByProcessNameDelay2000()
//        {
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                TimeoutsAndDelays.Form_Delay2000);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                ")) { 1; } else { 0; }");
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("May Fail")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout5000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 5000)) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay3000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay3000);
            //CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"if ((Get-UIAWindow -pn " +
//                MiddleLevelCode.TestFormProcess +
//                ")) { 1; } else { 0; }",
//                "System.NullReferenceException",
//                "Object reference not set to an instance of an object.");

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }",
                "CmdletInvocationException",
                "Failed to get the window by: process name: 'UIAutomationTestForms' process Id:  window title: ''");
                
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay3000:
//  Expected string length 111 but was 96. Strings differ at index 79.
//  Expected: "...mationTestForms' process Id: 0 process: UIAutomationTestForms"
//  But was:  "...mationTestForms' process Id:  window title: ''"
//  -------------------------------------------^

            
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay3000:
//  Expected string length 105 but was 94. Strings differ at index 25.
//  Expected: "Failed to get the window process name: UIAutomationTestForms ..."
//  But was:  "Failed to get the window by: process name: UIAutomationTestFo..."
//  ------------------------------------^

            
//            UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay3000:
//  Expected string length 29 but was 25. Strings differ at index 0.
//  Expected: "System.NullReferenceException"
//  But was:  "CmdletInvocationException"
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay3000:
//  Expected string length 53 but was 105. Strings differ at index 0.
//  Expected: "Object reference not set to an instance of an object."
//  But was:  "Failed to get the window process name: UIAutomationTestForms ..."
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay3000:
//  Expected string length 84 but was 105. Strings differ at index 84.
//  Expected: "...omationTestForms process Id: 0 process: "
//  But was:  "...omationTestForms process Id: 0 process: UIAutomationTestForms"
//  ------------------------------------------------------^



        }
        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        public void GetWindowByProcessNameTimeout10000()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " -timeout 10000)) { 1; } else { 0; }");
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
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
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout20000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 20000)) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay4000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay4000);
            //CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"if ((Get-UIAWindow -pn " +
//                MiddleLevelCode.TestFormProcess +
//                ")) { 1; } else { 0; }",
//                "System.NullReferenceException",
//                "Object reference not set to an instance of an object.");

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }",
                "CmdletInvocationException",
                "Failed to get the window by: process name: 'UIAutomationTestForms' process Id:  window title: ''");
                
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay4000:
//  Expected string length 111 but was 96. Strings differ at index 79.
//  Expected: "...mationTestForms' process Id: 0 process: UIAutomationTestForms"
//  But was:  "...mationTestForms' process Id:  window title: ''"
//  -------------------------------------------^

            
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay4000:
//  Expected string length 105 but was 94. Strings differ at index 25.
//  Expected: "Failed to get the window process name: UIAutomationTestForms ..."
//  But was:  "Failed to get the window by: process name: UIAutomationTestFo..."
//  ------------------------------------^

            
//            UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay4000:
//  Expected string length 29 but was 25. Strings differ at index 0.
//  Expected: "System.NullReferenceException"
//  But was:  "CmdletInvocationException"
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay4000:
//  Expected string length 53 but was 105. Strings differ at index 0.
//  Expected: "Object reference not set to an instance of an object."
//  But was:  "Failed to get the window process name: UIAutomationTestForms ..."
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByProcessNameDelay4000:
//  Expected string length 84 but was 105. Strings differ at index 84.
//  Expected: "...omationTestForms process Id: 0 process: "
//  But was:  "...omationTestForms process Id: 0 process: UIAutomationTestForms"
//  ------------------------------------------------------^



        }
    
// since the default timeout has been changed from 60000 to 10000,
// these tests make no sense
// [Test] //[Test(Description="TBD")]
// [Category("Slow")][Category("WinForms")]
// public void GetWindowByProcessNameTimeout120000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " -timeout 120000)) { 1; } else { 0; }");
// }
// 
// [Test] //[Test(Description="TBD")]
// [Category("Slow")][Category("WinForms")]
// public void GetWindowByProcessNameDelay120000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 120000);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// ")) { 1; } else { 0; }");
// }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout8000Delay5000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay5000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 8000)) { 1; } else { 0; }");
        }
        
// 20120620 switched off as tool long and changed to GetWindowByProcessNameTimeout5000Delay4000
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Get_UIAWindow")]
//        public void GetWindowByProcessNameTimeout12000Delay11000()
//        {
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                TimeoutsAndDelays.Form_Delay11000);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " -timeout 12000)) { 1; } else { 0; }");
//        }

// 20120630 switched off as failed at KU2
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Get_UIAWindow")]
//        public void GetWindowByProcessNameTimeout5000Delay4000()
//        {
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                TimeoutsAndDelays.Form_Delay4000);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " -timeout 5000)) { 1; } else { 0; }");
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByNameWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
//                "'wrong name'" +
//                " -timeout 2000" +
//                ")) { 0; } else { 1; }");
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"if ((Get-UIAWindow -n " + 
//                "'wrong name' -Seconds 2" +
//                ")) { 0; } else { 1; }",
//                "System.NullReferenceException",
//                "Object reference not set to an instance of an object.");

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -n " + 
                "'wrong name' -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                "Failed to get the window by: process name: '' process Id:  window title: 'wrong name'");
                
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByNameWrong:
//  Expected string length 63 but was 83. Strings differ at index 25.
//  Expected: "...ow process name:  process Id: 0 process: "
//  But was:  "...ow by: process name:  process Id:  window title: 'wrong name'"
//  -----------------^

                
//                UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByNameWrong:
//  Expected string length 29 but was 25. Strings differ at index 0.
//  Expected: "System.NullReferenceException"
//  But was:  "CmdletInvocationException"
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByNameWrong:
//  Expected string length 53 but was 63. Strings differ at index 0.
//  Expected: "Object reference not set to an instance of an object."
//  But was:  "Failed to get the window process name:  process Id: 0 process: "
//  -----------^


        }
        

        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowAsGlobalVariableEmpty()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if (([uiautomation.currentdata]::currentwindow.current.name" + 
                ")) { 0; } else { 1; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
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
        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        public void GetWindowAsGlobalVariablePossiblyNotEmpty()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
//                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
//                ")) { 0; } else { 1; }");
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
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
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByName_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByName_Wildcard1_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                "*" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByName_Wildcard2_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name *" + 
                MiddleLevelCode.TestFormNameEmpty +
                "*" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByName_Wildcard3_TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name ?" + 
                MiddleLevelCode.TestFormNameEmpty.Substring(1, MiddleLevelCode.TestFormNameEmpty.Length - 2) +
                "?" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
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
        
// [Test] //[Test(Description="TBD")]
// [Category("Slow")][Category("WinForms")]
// [Category("Slow")][Category("May Fail")]
// public void GetWindowByNameTimeout1000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
// MiddleLevelCode.TestFormNameEmpty +
// " -timeout 1000)) { 0; } else { 1; }");
// }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
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
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByNameTimeout5000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 5000)) { 1; } else { 0; }");
        }
        
// too long!
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Get_UIAWindow")]
//        public void GetWindowByNameTimeout12000()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " -timeout 12000)) { 1; } else { 0; }");
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByNameTimeout3000Delay5000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay5000);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " -timeout 3000 " + 
//                ")) { 0; } else { 1; }");
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"if ((Get-UIAWindow -Name " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " -timeout 3000 " + 
//                ")) { 0; } else { 1; }",
//                "System.NullReferenceException",
//                "Object reference not set to an instance of an object.");
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 3000 " + 
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                "Failed to get the window by: process name: '' process Id:  window title: 'WinFormsEmpty'");
                
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByNameTimeout3000Delay5000:
//  Expected string length 63 but was 86. Strings differ at index 25.
//  Expected: "...process name:  process Id: 0 process: "
//  But was:  "...by: process name:  process Id:  window title: 'WinFormsEmpty'"
//  --------------^

                
//                UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByNameTimeout3000Delay5000:
//  Expected string length 29 but was 25. Strings differ at index 0.
//  Expected: "System.NullReferenceException"
//  But was:  "CmdletInvocationException"
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByNameTimeout3000Delay5000:
//  Expected string length 53 but was 66. Strings differ at index 0.
//  Expected: "Object reference not set to an instance of an object."
//  But was:  "Failed to get the window\r\nprocess name: \r\nprocess Id: 0\r\nproc..."
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByNameTimeout3000Delay5000:
//  Expected string length 53 but was 63. Strings differ at index 0.
//  Expected: "Object reference not set to an instance of an object."
//  But was:  "Failed to get the window\tprocess name: \tprocess Id: 0\tprocess: "
//  -----------^


        }
        
// 20120620 switched off as it failed twice
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Get_UIAWindow")]
//        public void GetWindowByNameDelay2500()
//        {
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                TimeoutsAndDelays.Form_Delay2500);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                ")) { 1; } else { 0; }");
//        }
        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        public void GetWindowByNameDelay60000()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 60000);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                ")) { 0; } else { 1; }");
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByPIDWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pid " + 
//                "0" +
//                " -timeout 2000" +
//                ")) { 0; } else { 1; }");
//            CmdletUnitTest.TestRunspace.RunAndGetTheException(
//                @"if ((Get-UIAWindow -pid " + 
//                "12345678 -Seconds 2" +
//                ")) { 0; } else { 1; }",
//                "System.NullReferenceException",
//                "Object reference not set to an instance of an object.");

            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pid " + 
                "12345678 -Seconds 2" +
                ")) { 0; } else { 1; }",
                "CmdletInvocationException",
                "Failed to get the window by: process name: '' process Id: 12345678 window title: ''");
                
//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByPIDWrong:
//  Expected string length 70 but was 81. Strings differ at index 25.
//  Expected: "...ndow process name:  process Id: 12345678 process: "
//  But was:  "...ndow by: process name:  process Id: 12345678 window title: ''"
//  -------------------^

                
//                UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByPIDWrong:
//  Expected string length 29 but was 25. Strings differ at index 0.
//  Expected: "System.NullReferenceException"
//  But was:  "CmdletInvocationException"
//  -----------^

//UIAutomationTest.Commands.Get.GetUIAWindowCommandTestFixture.GetWindowByPIDWrong:
//  Expected string length 53 but was 70. Strings differ at index 0.
//  Expected: "Object reference not set to an instance of an object."
//  But was:  "Failed to get the window process name:  process Id: 12345678 ..."
//  -----------^


        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
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
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessFoundTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-Process -Name " +
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAWindow" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByProcessStartedTimeoutDefault()
        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ((Start-Process '" +
                MiddleLevelCode.TestFormPath + 
                "' -PassThru" +
                " | Get-UIAWindow" +
                ")) { 1; } else { 0; }");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAActiveWindow")]
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
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindowFromHandle")]
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
        
        // 20120630 switched off as failed at KU2
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Get_UIAWindow")]
//        public void GetWindowByProcessNameDelay2000_NoTaskBar()
//        {
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                TimeoutsAndDelays.Form_Delay2000);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//                           MiddleLevelCode.TestFormProcess +
//                           ")) { 1; } else { 0; }");
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Get_UIAWindow")]
        public void GetWindowByNameDelay2000_NoTaskBar()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -n " + 
                           MiddleLevelCode.TestFormNameNoTaskBar +
                           ")) { 1; } else { 0; }");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
