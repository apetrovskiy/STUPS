/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/25/2013
 * Time: 1:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    using Tmx;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of SetTmxCurrentTestResultCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class SetTmxCurrentTestResultCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_Name()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[Tmx.TestData]::CurrentTestResult.Name;",
                testResultName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_Id()
        {
            const string testResultId = "1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Id " + 
                testResultId + 
                ";" + 
                "[Tmx.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_NameId_1()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                " -Id 1;" + 
                "[Tmx.TestData]::CurrentTestResult.Name;",
                testResultName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_NameId_2()
        {
            const string testResultName = "result1";
            const string testResultId = "1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                " -Id '" +
                testResultId +
                "';" +
                "[Tmx.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_TestResultStatus()
        {
            const string testResultName = "result1";
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            const TestStatuses expectedTestResultStatus = TestStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[Tmx.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultDetail =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_NotTested()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            const TestStatuses expectedTestResultStatus = TestStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                "[Tmx.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_Passed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                "[Tmx.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_Failed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                "[Tmx.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_KnownIssue()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            const TestStatuses expectedTestResultStatus = TestStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                "[Tmx.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via closing test result =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_ImplicitlyFailed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1'; " + 
                //"[Tmx.TestData]::CurrentTestResult.enStatus;",
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_Passed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                //"[Tmx.TestData]::CurrentTestResult.enStatus;",
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_Failed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                //"[Tmx.TestData]::CurrentTestResult.enStatus;",
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_KnownIssue()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            const TestStatuses expectedTestResultStatus = TestStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                //"[Tmx.TestData]::CurrentTestResult.enStatus;",
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultdetail and closing test result =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_Passed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_Failed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_KnownIssue()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            const TestStatuses expectedTestResultStatus = TestStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_Passed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_Failed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_KnownIssue()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            const TestStatuses expectedTestResultStatus = TestStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_Passed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_Failed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_KnownIssue()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            const TestStatuses expectedTestResultStatus = TestStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_Passed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_Failed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_KnownIssue()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            const TestStatuses expectedTestResultStatus = TestStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultdetail and setting a new test result =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        // 20130408
        //public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_ImplicitlyFailed()
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_NotTested()
        {
            // 20130408
            //TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            const TestStatuses expectedTestResultStatus = TestStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_Passed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_Failed()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            const TestStatuses expectedTestResultStatus = TestStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_KnownIssue()
        {
            // 20150805
            // const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            const TestStatuses expectedTestResultStatus = TestStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
    }
}
