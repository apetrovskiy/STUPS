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
    using TMX;
    using TMX.Interfaces;
    
    /// <summary>
    /// Description of SetTmxCurrentTestResultCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class SetTmxCurrentTestResultCommandTestFixture
    {
        public SetTmxCurrentTestResultCommandTestFixture()
        {
        }
        
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
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.Name;",
                testResultName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_Id()
        {
            string testResultId = "1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Id " + 
                testResultId + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_NameId_1()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                " -Id 1;" + 
                "[TMX.TestData]::CurrentTestResult.Name;",
                testResultName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_NameId_2()
        {
            string testResultName = "result1";
            string testResultId = "1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                " -Id '" +
                testResultId +
                "';" +
                "[TMX.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_TestResultStatus()
        {
            string testResultName = "result1";
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultDetail =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_NotTested()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_TestResultStatus_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via closing test result =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_ImplicitlyFailed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1'; " + 
                //"[TMX.TestData]::CurrentTestResult.enStatus;",
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                //"[TMX.TestData]::CurrentTestResult.enStatus;",
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                //"[TMX.TestData]::CurrentTestResult.enStatus;",
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_CloseTmxTestResult_TestResultStatus_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                //"[TMX.TestData]::CurrentTestResult.enStatus;",
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultdetail and closing test result =====================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_NotTested_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Passed_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_Failed_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_CloseTmxTestResult_TestResultStatus_KnownIssue_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TmxTestResult -Name 'tr1' -KnownIssue; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
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
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Set-TmxCurrentTestResult")]
        public void SetTmxCurrentTestResult_AddTmxTestResultDetail_SetTmxCurrentTestResult_TestResultStatus_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TmxCurrentTestResult -Name 'tr1'; " + 
                @"Add-TmxTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Set-TmxCurrentTestResult -Name 'tr2'; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
    }
}
