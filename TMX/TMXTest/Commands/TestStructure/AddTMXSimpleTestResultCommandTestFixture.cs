/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/31/2013
 * Time: 12:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using TMX;
    
    /// <summary>
    /// Description of AddTMXSimpleTestResultCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class AddTMXSimpleTestResultCommandTestFixture
    {
        public AddTMXSimpleTestResultCommandTestFixture()
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
        [Category("Add-TMXSimpleTestResult")]
        public void SetCurrentTestResult_Passed_AddSimpleTestResult_Passed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TMXCurrentTestResult 'tr01' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TMXSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Passed; " +
                "$null = Set-TMXCurrentTestResult 'tr03' -Id 003;" +
                "Get-TMXTestResultStatus -Id 002;",
                TMX.TestData.TestStatePassed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Add-TMXSimpleTestResult")]
        public void SetCurrentTestResult_Passed_AddSimpleTestResult_Failed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TMXCurrentTestResult 'tr01' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TMXSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Failed; " +
                "$null = Set-TMXCurrentTestResult 'tr03' -Id 003;" +
                "Get-TMXTestResultStatus -Id 002;",
                TMX.TestData.TestStateFailed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Add-TMXSimpleTestResult")]
        public void SetCurrentTestResult_Failed_AddSimpleTestResult_Passed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TMXCurrentTestResult 'tr01' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "$null = Add-TMXSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Passed; " +
                "$null = Set-TMXCurrentTestResult 'tr03' -Id 003;" +
                "Get-TMXTestResultStatus -Id 002;",
                TMX.TestData.TestStatePassed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Add-TMXSimpleTestResult")]
        public void SetCurrentTestResult_Failed_AddSimpleTestResult_Failed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TMXCurrentTestResult 'tr01' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "$null = Add-TMXSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Failed; " +
                "$null = Set-TMXCurrentTestResult 'tr03' -Id 003;" +
                "Get-TMXTestResultStatus -Id 002;",
                TMX.TestData.TestStateFailed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Add-TMXSimpleTestResult")]
        public void SetCurrentTestResult_Passed_AddSimpleTestResult_KnownIssue()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TMXCurrentTestResult 'tr01' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TMXSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus KnownIssue; " +
                "$null = Set-TMXCurrentTestResult 'tr03' -Id 003;" +
                "Get-TMXTestResultStatus -Id 002;",
                TMX.TestData.TestStateKnownIssue);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Add-TMXSimpleTestResult")]
        public void SetCurrentTestResult_KnownIssue_AddSimpleTestResult_Passed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TMXCurrentTestResult 'tr01' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                "$null = Add-TMXSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Passed; " +
                "$null = Set-TMXCurrentTestResult 'tr03' -Id 003;" +
                "Get-TMXTestResultStatus -Id 002;",
                TMX.TestData.TestStatePassed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Add-TMXSimpleTestResult")]
        public void SetCurrentTestResult_Failed_AddSimpleTestResult_KnownIssue()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TMXCurrentTestResult 'tr01' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "$null = Add-TMXSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus KnownIssue; " +
                "$null = Set-TMXCurrentTestResult 'tr03' -Id 003;" +
                "Get-TMXTestResultStatus -Id 002;",
                TMX.TestData.TestStateKnownIssue);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Add-TMXSimpleTestResult")]
        public void SetCurrentTestResult_KnownIssue_AddSimpleTestResult_Failed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TMXCurrentTestResult 'tr01' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                "$null = Add-TMXSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Failed; " +
                "$null = Set-TMXCurrentTestResult 'tr03' -Id 003;" +
                "Get-TMXTestResultStatus -Id 002;",
                TMX.TestData.TestStateFailed);
        }
    }
}
