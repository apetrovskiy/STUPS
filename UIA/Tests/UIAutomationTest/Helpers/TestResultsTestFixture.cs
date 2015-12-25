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
    using UIAutomationTestForms;
    
    /// <summary>
    /// Description of TestResultsTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="-TestResultName and -TestPassed tests")]
    public class TestResultsTestFixture
    {
        public TestResultsTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Import-Module '.\Tmx.dll' -Force; ");
            
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([Tmx.TestData]::ResetData()); ");
            
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[UIAutomation.Preferences]::EveryCmdletAsTestResult = $false;");
            
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "'; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"try { $null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true; } catch {}" +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"try { $null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false; } catch {}" +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -KnownIssue; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -KnownIssue:$true; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -KnownIssue:$false; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true -KnownIssue; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false -KnownIssue; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true -KnownIssue:$false; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"$null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                name +
                "' | Invoke-UiaButtonClick -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false -KnownIssue:$false; " +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"try { $null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true -KnownIssue; } catch {}" +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"try { $null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false -KnownIssue; } catch {}" +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"try { $null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$true -KnownIssue:$false; } catch {}" +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("TestResults")]
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
                @"try { $null = Get-UiaWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty +
                @"' | Get-UiaButton -n '" + 
                wrongName +
                "' -Timeout 500 -TestResultName '" + 
                resultName + 
                "' -TestPassed:$false -KnownIssue:$false; } catch {}" +
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                resultName);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                resultStatus);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
