/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/25/2013
 * Time: 1:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using TMX;
    
    /// <summary>
    /// Description of SetTMXCurrentTestResultCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class SetTMXCurrentTestResultCommandTestFixture
    {
        public SetTMXCurrentTestResultCommandTestFixture()
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
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_Name()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.Name;",
                testResultName);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_Id()
        {
            string testResultId = "1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Id " + 
                testResultId + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_NameId_1()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name " + 
                testResultName + 
                " -Id 1;" + 
                "[TMX.TestData]::CurrentTestResult.Name;",
                testResultName);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_NameId_2()
        {
            string testResultName = "result1";
            string testResultId = "1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name " + 
                testResultName + 
                " -Id '" +
                testResultId +
                "';" +
                "[TMX.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_TestResultStatus()
        {
            string testResultName = "result1";
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultDetail =====================
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_TestResultStatus_NotTested()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_TestResultStatus_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_TestResultStatus_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_TestResultStatus_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via closing test result =====================
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_CloseTMXTestResult_TestResultStatus_ImplicitlyFailed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TMXTestResult -Name 'tr1'; " + 
                //"[TMX.TestData]::CurrentTestResult.enStatus;",
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_CloseTMXTestResult_TestResultStatus_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed; " + 
                //"[TMX.TestData]::CurrentTestResult.enStatus;",
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_CloseTMXTestResult_TestResultStatus_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed:$false; " + 
                //"[TMX.TestData]::CurrentTestResult.enStatus;",
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_CloseTMXTestResult_TestResultStatus_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                //@"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TMXTestResult -Name 'tr1' -KnownIssue; " + 
                //"[TMX.TestData]::CurrentTestResult.enStatus;",
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultdetail and closing test result =====================
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_NotTested_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_NotTested_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_NotTested_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Close-TMXTestResult -Name 'tr1' -KnownIssue; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_Passed_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_Passed_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_Passed_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Close-TMXTestResult -Name 'tr1' -KnownIssue; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_Failed_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_Failed_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_Failed_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Close-TMXTestResult -Name 'tr1' -KnownIssue; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_KnownIssue_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_KnownIssue_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TMXTestResult -Name 'tr1' -TestPassed:$false; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_CloseTMXTestResult_TestResultStatus_KnownIssue_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Close-TMXTestResult -Name 'tr1' -KnownIssue; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        // ========== Statuses via TestResultdetail and setting a new test result =====================
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        // 20130408
        //public void SetTMXCurrentTestResult_AddTMXTestResultDetail_SetTMXCurrentTestResult_TestResultStatus_ImplicitlyFailed()
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_SetTMXCurrentTestResult_TestResultStatus_NotTested()
        {
            // 20130408
            //TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus NotTested; " +
                @"Set-TMXCurrentTestResult -Name 'tr2'; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_SetTMXCurrentTestResult_TestResultStatus_Passed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Passed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Passed; " +
                @"Set-TMXCurrentTestResult -Name 'tr2'; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_SetTMXCurrentTestResult_TestResultStatus_Failed()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.Failed;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus Failed; " +
                @"Set-TMXCurrentTestResult -Name 'tr2'; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_AddTMXTestResultDetail_SetTMXCurrentTestResult_TestResultStatus_KnownIssue()
        {
            TestResultStatuses expectedTestResultStatus = TestResultStatuses.KnownIssue;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name 'tr1'; " + 
                @"Add-TMXTestResultDetail 'TestResultDetailCmdletBase 01' -TestResultStatus KnownIssue; " +
                @"Set-TMXCurrentTestResult -Name 'tr2'; " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults.Count - 1].enStatus;",
                expectedTestResultStatus.ToString());
        }
    }
}
