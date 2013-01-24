/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/22/2012
 * Time: 1:10 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    using UIAutomationTestForms;
    
    /// <summary>
    /// Description of TestResultsTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="-TestResultName and -TestPassed tests")]
    public class TestResultsTestFixture
    {
        public TestResultsTestFixture()
        {
        }
        
//        [SetUpFixture]
//        public void PrepareRunspaceCommon()
//        {
//            MiddleLevelCode.PrepareRunspace();
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"Import-Module '.\TMX.dll' -Force; ");
//            
////            CmdletUnitTest.TestRunspace.RunPSCode(
////                "Show-UIAModuleSettings; ");
////            
////            CmdletUnitTest.TestRunspace.RunPSCode(
////                "Show-UIACurrentData; ");
//            
////            CmdletUnitTest.TestRunspace.RunPSCode(
////                @"[void]([UIAutomation.CurrentData]::ResetData()); ");
//            
//        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Import-Module '.\TMX.dll' -Force; ");
            
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([TMX.TestData]::ResetData()); ");
            
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                "Show-UIAModuleSettings; ");
//            
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                "Show-UIACurrentData; ");
            
            
            // 20121017
            // ??
//            CmdletUnitTest.TestRunspace.RunPSCode(
//                @"[void]([UIAutomation.CurrentData]::ResetData()); ");
                
                
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[UIAutomation.Preferences]::EveryCmdletAsTestResult = $false;");
            
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_TestPassed_NoParam()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: no -TestResult parameter");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "'; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_TestPassed_Empty()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "PASSED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected PASSED: the -TestResult parameter");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_TestPassed_True()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "PASSED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected PASSED: the -TestResult:$true parameter");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_TestPassed_False()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -TestResult:$false parameter");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_TestPassed_True_Failure()
        {
            string name = "Button111";
            string wrongName = "Button222";
            string resultName = "not found";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -TestResult:$true parameter and cmdlet failure");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"try { $null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true; } catch {}" +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_TestPassed_False_Failure()
        {
            string name = "Button111";
            string wrongName = "Button222";
            string resultName = "not found";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -TestResult:$false parameter and cmdlet failure");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"try { $null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false; } catch {}" +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_KnownIssue()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "KNOWN ISSUE";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            //CmdletUnitTest.TestRunspace.RunPSCode(
            //    @"#expected KNOWN ISSUE: the -KnownIssue parameter");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -KnownIssue; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_KnownIssue_True()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "KNOWN ISSUE";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            //CmdletUnitTest.TestRunspace.RunPSCode(
            //    @"#expected KNOWN ISSUE: the -KnownIssue:$true parameter");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -KnownIssue:$true; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_KnownIssue_False()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -KnownIssue:$false and no -TestPassed parameters");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -KnownIssue:$false; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_KnownIssue_TestPassed_True()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "KNOWN ISSUE";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected KNOWN ISSUE: the -KnownIssue parameter");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true -KnownIssue; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_KnownIssue_TestPassed_False()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "KNOWN ISSUE";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected KNOWN ISSUE: the -KnownIssue parameter");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false -KnownIssue; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_NoKnownIssue_TestPassed_True()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "PASSED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected PASSED: the -KnownIssue:$false and -TestPassed:$true parameters");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true -KnownIssue:$false; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_NoKnownIssue_TestPassed_False()
        {
            string name = "Button111";
            string resultName = "clicked";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -KnownIssue:$false and -TestPassed:$false parameters");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                name +
                "' | Invoke-UIAButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false -KnownIssue:$false; " +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_KnownIssue_TestPassed_True_Failure()
        {
            string name = "Button111";
            string wrongName = "Button222";
            string resultName = "not found";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -KnownIssue:$true parameter and cmdlet failure");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"try { $null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true -KnownIssue; } catch {}" +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_KnownIssue_TestPassed_False_Failure()
        {
            string name = "Button111";
            string wrongName = "Button222";
            string resultName = "not found";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -KnownIssue:$true parameter and cmdlet failure");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"try { $null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false -KnownIssue; } catch {}" +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_NoKnownIssue_TestPassed_True_Failure()
        {
            string name = "Button111";
            string wrongName = "Button222";
            string resultName = "not found";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -KnownIssue::$false parameter and cmdlet failure");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"try { $null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true -KnownIssue:$false; } catch {}" +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("TestResults")]
        public void TestResults_NoKnownIssue_TestPassed_False_Failure()
        {
            string name = "Button111";
            string wrongName = "Button222";
            string resultName = "not found";
            string resultStatus = "FAILED";
            MiddleLevelCode.StartProcessWithFormAndControl(
                Forms.WinFormsEmpty,
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Delay0);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"#expected FAILED: the -KnownIssue::$false parameter and cmdlet failure");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"try { $null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UIAButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false -KnownIssue:$false; } catch {}" +
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
