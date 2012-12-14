///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 4/5/2012
// * Time: 6:16 PM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace UIAutomationTest.Commands.Search
//{
//    using System;
//    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
//    using System.Management.Automation;
//    
//    /// <summary>
//    /// Description of SearchUIAControlCommandTestFixture.
//    /// </summary>
//    [TestFixture] // [TestFixture(Description="Search-UIAControl test")]
//    public class SearchUIAControlCommandTestFixture
//    {
//        public SearchUIAControlCommandTestFixture()
//        {
//        }
//        
//        [SetUp]
//        public void PrepareRunspace()
//        {
//            MiddleLevelCode.PrepareRunspace();
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_NoControlType()
//        {
//            string name = "Button111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -Name '" +
//                name +
//                "' | Read-UIAControlName;",
//                name);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButton()
//        {
//            string name = "Button111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                name +
//                "' | Read-UIAControlName;",
//                name);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButtonButLabel()
//        {
//            string name = "Label111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Text,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                name +
//                "' | Read-UIAControlName;");
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButtonX2_1()
//        {
//            string name = "Button???";
//            string name1 = "Button111";
//            string name2 = "Button222";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            ControlToForm[] controlToForm = 
//                {new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    name1,
//                    "au", 
//                    TimeoutsAndDelays.Control_Delay0),
//                new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    name2,
//                    "au2", 
//                    TimeoutsAndDelays.Control_Delay0)};
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                controlToForm);
////            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
////                @"Get-UIAWindow -pn " + 
////                MiddleLevelCode.TestFormProcess +
////                " | Search-UIAControl -ControlType Button -Name '" +
////                name +
////                "' | Read-UIAControlName;",
////                name1);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"(Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                name +
//                "').Count;",
//                "2");
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButtonX2_2()
//        {
//            string name = "*ton???";
//            string name1 = "Button111";
//            string name2 = "Button222";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            ControlToForm[] controlToForm = 
//                {new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    name1,
//                    "au", 
//                    TimeoutsAndDelays.Control_Delay0),
//                new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    name2,
//                    "au2", 
//                    TimeoutsAndDelays.Control_Delay0)};
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                controlToForm);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"(Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                name +
//                "').Count;",
//                "2");
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButton_CaseSensitive1()
//        {
//            string name = "Button111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                name +
//                "' -CaseSensitive | Read-UIAControlName;",
//                name);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButton_CaseSensitive2()
//        {
//            string name = "Button111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                name +
//                "' -CaseSensitive:$true | Read-UIAControlName;",
//                name);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButton_CaseInsensitive1()
//        {
//            string name = "Button111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                name +
//                "' | Read-UIAControlName;",
//                name);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButton_CaseInsensitive2()
//        {
//            string name = "Button111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                name +
//                "' -CaseSensitive:$false | Read-UIAControlName;",
//                name);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButton_CaseSensitive_Failed()
//        {
//            string name = "Button111";
//            string nameToCheck = "BUTTON111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                nameToCheck +
//                "' -CaseSensitive:$true | Read-UIAControlName;");
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Search_UIAControl")]
//        public void SearchControl_Name_ControlTypeButton_CaseInsensitive_Success()
//        {
//            string name = "Button111";
//            string nameToCheck = "BUTTON111";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                name,
//                "aaa",
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " | Search-UIAControl -ControlType Button -Name '" +
//                nameToCheck +
//                "' -CaseSensitive:$false | Read-UIAControlName;",
//                name);
//        }
//        
//        [TearDown]
//        public void DisposeRunspace()
//        {
//            MiddleLevelCode.DisposeRunspace();
//        }
//    }
//}
