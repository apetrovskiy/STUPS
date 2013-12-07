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
//    /// Description of SearchUiaWindowCommandTestFixture.
//    /// </summary>
//    [TestFixture] // [TestFixture(Description="Search-UiaWindow test")]
//    public class SearchUiaWindowCommandTestFixture
//    {
//        public SearchUiaWindowCommandTestFixture()
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
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_1()
//        {
//            string name = "*Emp*";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameEmpty);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_2()
//        {
//            string name = "*Em?t*";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameEmpty);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_3()
//        {
//            string name = "*T???Bar*";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_4()
//        {
//            string name = "*T???Bar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_5()
//        {
//            string name = "*Tas?Bar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_6()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -Verbose | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_CaseSensitive1()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -CaseSensitive | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_CaseSensitive2()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -CaseSensitive:$true | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_CaseInsensitive1()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_CaseInsensitive2()
//        {
//            string name = "*TaskBar";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -CaseSensitive:$false | Read-UiaControlName;",
////                @"(Get-UiaDesktop | Search-UiaWindow -Name " + 
////                name +
////                ").Current.Name;",
//                MiddleLevelCode.TestFormNameNoTaskBar);
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_CaseSensitive_Failed()
//        {
//            string name = "*TASKBAR";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -CaseSensitive | Read-UiaControlName;");
//        }
//        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Window")]
//        [Category("Slow")][Category("Search_UiaWindow")]
//        public void SearchWindow_Name_CaseInsensitive_Success()
//        {
//            string name = "*TASKBAR";
//            string formName = MiddleLevelCode.TestFormNameEmpty;
//            MiddleLevelCode.StartProcessWithForm(
//                UIAutomationTestForms.Forms.WinFormsNoTaskBar, 
//                0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UiaWindow -pn '" + 
//                MiddleLevelCode.TestFormProcess +
//                @"'; [void]([UIAutomation.CurrentData]::ResetData()); " +
//                @"Get-UiaDesktop | Search-UiaWindow -Name '" + 
//                name +
//                @"' -CaseSensitive:$false | Read-UiaControlName;",
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
