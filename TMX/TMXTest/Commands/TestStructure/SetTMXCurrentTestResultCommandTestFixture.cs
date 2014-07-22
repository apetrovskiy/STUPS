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
                "[Tmx.Core.TestData]::CurrentTestResult.Name;",
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
                "[Tmx.Core.TestData]::CurrentTestResult.Id;",
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
                "[Tmx.Core.TestData]::CurrentTestResult.Name;",
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
                "[Tmx.Core.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_TestResultStatus()
        {
            const string testResultName = "result1";
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultDetail =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_NotTested()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                "[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_Passed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                "[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_Failed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                "[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_KnownIssue()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                "[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via closing test result =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_ImplicitlyFailed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1'; " + 
                //"[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_Passed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                //"[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_Failed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                //"[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_KnownIssue()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                //"[Tmx.Core.TestData]::CurrentTestResult.enStatus;",
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultdetail and closing test result =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_Passed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_Failed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_KnownIssue()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_Passed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_Failed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_KnownIssue()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_Passed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_Failed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_KnownIssue()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_Passed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_Failed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_KnownIssue()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
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
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_Passed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_Failed()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_KnownIssue()
        {
			const TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
    }
}
