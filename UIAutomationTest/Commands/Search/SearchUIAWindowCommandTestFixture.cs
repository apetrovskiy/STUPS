///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 4/9/2012
// * Time: 11:17 PM
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
//    /// Description of SearchUIAWindowCommandTestFixture.
//    /// </summary>
//    [TestFixture] // [TestFixture(Description="Search-UIAWindow test")]
//    public class SearchUIAWindowCommandTestFixture
//    {
//        public SearchUIAWindowCommandTestFixture()
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
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_1()
//        {
//            string name = "*Emp*";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameEmpty);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_2()
//        {
//            string name = "*Em?t*";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameEmpty);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_3()
//        {
//            string name = "*T???Bar*";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_4()
//        {
//            string name = "*T???Bar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_5()
//        {
//            string name = "*Tas?Bar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_6()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_CaseSensitive1()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -CaseSensitive | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_CaseSensitive2()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -CaseSensitive:$true | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_CaseInsensitive1()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_CaseInsensitive2()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -CaseSensitive:$false | Read-UIAControlName;",
////                @"(Get-UIADesktop | Search-UIAWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_CaseSensitive_Failed()
//        {
//            string name = "*TASKBAR";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -CaseSensitive | Read-UIAControlName;");
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UIAWindow")]
//        public void SearchWindow_Name_CaseInsensitive_Success()
//        {
//            string name = "*TASKBAR";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UIADesktop | Search-UIAWindow -Name '" + 
//                name +
//                @"' -CaseSensitive:$false | Read-UIAControlName;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [TearDown]
//        public void DisposeRunspace()
//        {
//            MiddleLevelCode.DisposeRunspace();
//        }
//    }
//}
