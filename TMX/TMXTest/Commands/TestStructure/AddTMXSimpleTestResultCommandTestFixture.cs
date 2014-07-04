/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/31/2013
 * Time: 12:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    using TMX;
    
    /// <summary>
    /// Description of AddTmxSimpleTestResultCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class AddTmxSimpleTestResultCommandTestFixture
    {
        public AddTmxSimpleTestResultCommandTestFixture()
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
        [MbUnit.Framework.Category("Add-TmxSimpleTestResult")]
        public void SetCurrentTestResult_Passed_AddSimpleTestResult_Passed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TmxCurrentTestResult 'tr01' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TmxSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Passed; " +
                "$null = Set-TmxCurrentTestResult 'tr03' -Id 003;" +
                "Get-TmxTestResultStatus -Id 002;",
                TMX.TestData.TestStatePassed);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Add-TmxSimpleTestResult")]
        public void SetCurrentTestResult_Passed_AddSimpleTestResult_Failed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TmxCurrentTestResult 'tr01' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TmxSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Failed; " +
                "$null = Set-TmxCurrentTestResult 'tr03' -Id 003;" +
                "Get-TmxTestResultStatus -Id 002;",
                TMX.TestData.TestStateFailed);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Add-TmxSimpleTestResult")]
        public void SetCurrentTestResult_Failed_AddSimpleTestResult_Passed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TmxCurrentTestResult 'tr01' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "$null = Add-TmxSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Passed; " +
                "$null = Set-TmxCurrentTestResult 'tr03' -Id 003;" +
                "Get-TmxTestResultStatus -Id 002;",
                TMX.TestData.TestStatePassed);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Add-TmxSimpleTestResult")]
        public void SetCurrentTestResult_Failed_AddSimpleTestResult_Failed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TmxCurrentTestResult 'tr01' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "$null = Add-TmxSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Failed; " +
                "$null = Set-TmxCurrentTestResult 'tr03' -Id 003;" +
                "Get-TmxTestResultStatus -Id 002;",
                TMX.TestData.TestStateFailed);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Add-TmxSimpleTestResult")]
        public void SetCurrentTestResult_Passed_AddSimpleTestResult_KnownIssue()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TmxCurrentTestResult 'tr01' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TmxSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus KnownIssue; " +
                "$null = Set-TmxCurrentTestResult 'tr03' -Id 003;" +
                "Get-TmxTestResultStatus -Id 002;",
                TMX.TestData.TestStateKnownIssue);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Add-TmxSimpleTestResult")]
        public void SetCurrentTestResult_KnownIssue_AddSimpleTestResult_Passed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TmxCurrentTestResult 'tr01' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                "$null = Add-TmxSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Passed; " +
                "$null = Set-TmxCurrentTestResult 'tr03' -Id 003;" +
                "Get-TmxTestResultStatus -Id 002;",
                TMX.TestData.TestStatePassed);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Add-TmxSimpleTestResult")]
        public void SetCurrentTestResult_Failed_AddSimpleTestResult_KnownIssue()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TmxCurrentTestResult 'tr01' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "$null = Add-TmxSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus KnownIssue; " +
                "$null = Set-TmxCurrentTestResult 'tr03' -Id 003;" +
                "Get-TmxTestResultStatus -Id 002;",
                TMX.TestData.TestStateKnownIssue);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Add-TmxSimpleTestResult")]
        public void SetCurrentTestResult_KnownIssue_AddSimpleTestResult_Failed()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string simpleTestResultName = @"tr02";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "$null = Set-TmxCurrentTestResult 'tr01' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                "$null = Add-TmxSimpleTestResult -Name '" + 
                simpleTestResultName + 
                "' -Id 002 -TestResultStatus Failed; " +
                "$null = Set-TmxCurrentTestResult 'tr03' -Id 003;" +
                "Get-TmxTestResultStatus -Id 002;",
                TMX.TestData.TestStateFailed);
        }
    }
}
