/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/10/2013
 * Time: 12:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ParameterlessSearchTestFixture.
    /// </summary>
    public class ParameterlessSearchTestFixture
    {
        public ParameterlessSearchTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_X2_SearchInName_Timeout2000()
        {
            string expectedName = "my_name";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    expectedName,
                    "1", 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "e2",
                    "2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    expectedName,
                    "3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedName +
                "' -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_Win32_X2_SearchInName_Timeout2000()
        {
            string expectedName = "my_name";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    expectedName,
                    "1", 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "e2",
                    "2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    expectedName,
                    "3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedName +
                "' -Win32 -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_X2_SearchInAutomationId_Timeout2000()
        {
            string expectedAuId = "myAuId";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "1",
                    expectedAuId, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "2",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "3",
                    expectedAuId, 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedAuId +
                "' -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_Win32_X2_SearchInAutomationId_Timeout2000()
        {
            string expectedAuId = "myAuId";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "1",
                    expectedAuId, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "2",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "3",
                    expectedAuId, 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedAuId +
                "' -Win32 -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_X2_SearchInValue_Timeout2000()
        {
            string expectedValue = "my text";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "1",
                    "auid1", 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "2",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "3",
                    "auid3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl -AutomationId auid1 | Set-UIAControlText '" + 
                expectedValue +
                "'; " +
                "$null = Get-UIAControl -AutomationId auid3 | Set-UIAControlText '" + 
                expectedValue +
                "'; " +
                "(Get-UIAControl '" +
                expectedValue +
                "' -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_Win32_X2_SearchInValue_Timeout2000()
        {
            string expectedValue = "my text";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "1",
                    "auid1", 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "2",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "3",
                    "auid3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl -AutomationId auid1 | Set-UIAControlText '" + 
                expectedValue +
                "'; " +
                "$null = Get-UIAControl -AutomationId auid3 | Set-UIAControlText '" + 
                expectedValue +
                "'; " +
                "(Get-UIAControl '" +
                expectedValue +
                "' -Win32 -Timeout 2000).Count;",
                "2");
        }
        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")]
//        [Category("WinForms")]
//        [Category("Control")]
//        [Category("Get_UIAControl")]
//        public void GetControl_X2_SearchInClassName_Timeout2000()
//        {
//            string expectedClass = "button";
//            System.Collections.ArrayList arrList = 
//                new System.Collections.ArrayList();
//            ControlToForm ctf1 = 
//                new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    "1",
//                    "auid1", 
//                    0);
//            arrList.Add(ctf1);
//            ControlToForm ctf2 = 
//                new ControlToForm(
//                    System.Windows.Automation.ControlType.Edit,
//                    "2",
//                    "auid2", 
//                    0);
//            arrList.Add(ctf2);
//            ControlToForm ctf3 = 
//                new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    "3",
//                    "auid3", 
//                    0);
//            arrList.Add(ctf3);
//            
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"(Get-UIAWindow -n " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " | Get-UIAControl '" +
//                expectedClass +
//                "' -Timeout 2000).Count;",
//                "2");
//        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_Win32_X2_SearchInClassName_Timeout2000()
        {
            string expectedClass = "button";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "1",
                    "auid1", 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "2",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "3",
                    "auid3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '*" +
                expectedClass +
                "*' -Win32 -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_X2_SearchInNameAutomationId_Timeout2000()
        {
            string expectedName = "myName";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    expectedName,
                    expectedName, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "e2",
                    expectedName, 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "3",
                    "3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedName +
                "' -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_Win32_X2_SearchInNameAutomationId_Timeout2000()
        {
            string expectedName = "myName";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    expectedName,
                    expectedName, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "e2",
                    expectedName, 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "3",
                    "3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedName +
                "' -Win32 -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_X2_SearchInNameClassName_Timeout2000()
        {
            string expectedClass = "button";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    expectedClass,
                    "auid1", 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "2",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    expectedClass,
                    "auid3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedClass +
                "' -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_Win32_X2_SearchInNameClassName_Timeout2000()
        {
            string expectedClass = "button";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    expectedClass,
                    "auid1", 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "2",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    expectedClass,
                    "auid3", 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedClass +
                "' -Win32 -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_X2_SearchInAutomationIdClassName_Timeout2000()
        {
            string expectedClass = "button";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "aaa",
                    expectedClass, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "bbb",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "ccc",
                    expectedClass, 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedClass +
                "' -Timeout 2000).Count;",
                "2");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControl_Win32_X2_SearchInAutomationIdClassName_Timeout2000()
        {
            string expectedClass = "button";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "aaa",
                    expectedClass, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "bbb",
                    "auid2", 
                    0);
            arrList.Add(ctf2);
            ControlToForm ctf3 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Button,
                    "ccc",
                    expectedClass, 
                    0);
            arrList.Add(ctf3);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl '" +
                expectedClass +
                "' -Win32 -Timeout 2000).Count;",
                "2");
        }
    }
}
