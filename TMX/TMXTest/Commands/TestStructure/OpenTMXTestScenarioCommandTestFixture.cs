/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
	using Tmx.Core; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of OpenTmxTestScenarioCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Open-TmxTestScenario test")]
    public class OpenTmxTestScenarioCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name (from the active suite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void TestPrm_Name_Simple_from_active_suite()
        {
            const string suiteName = "suite1";
            const string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name " + 
                suiteName + 
                " | Add-TmxTestScenario -Name " + 
                scenarioName + 
                "; " + 
                @"(Open-TmxTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name (from the active suite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void TestPrm_Name_Complex_from_active_suite()
        {
            const string suiteName = @"suite%%`1  1";
            const string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "'; " +
                @"(Open-TmxTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name (from the selected suite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void TestPrm_Name_Simple_from_selected_suite()
        {
            const string suiteName = "suite2";
            const string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = Add-TmxTestScenario -Name sc1; " + 
                @"$null = New-TmxTestSuite -Name " + 
                suiteName + 
                "; " +
                @"$null = Add-TmxTestScenario -Name " + 
                scenarioName + 
                "; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"$null = Open-TmxTestSuite -Name " +
                suiteName +
                "; " + 
                @"(Open-TmxTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name (from the selected suite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void TestPrm_Name_Complex_from_selected_suite()
        {
            const string suiteName = @"suite%%`2  2";
            const string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = Add-TmxTestScenario -Name '$(`r)'; " + 
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "'; " +
                @"$null = Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "'; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"$null = Open-TmxTestSuite -Name '" +
                suiteName +
                "'; " +
                @"(Open-TmxTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name (selected scenario from the active suite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void TestPrm_Name_Simple_selected_from_active_suite()
        {
            const string suiteName = "suite1";
            const string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name " + 
                suiteName + 
                " | Add-TmxTestScenario -Name " + 
                scenarioName + 
                "; " + 
                @"$null = Add-TmxTestScenario -Name sc2; " + 
                @"$null = Add-TmxTestScenario -Name sc3; " + 
                @"(Open-TmxTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name (selected scenario from the active suite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void TestPrm_Name_Complex_selected_from_active_suite()
        {
            const string suiteName = @"suite%%`1  1";
            const string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name 'asdfa \\sdter//'; " + 
                "$null = Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "'; " +
                @"$null = Add-TmxTestScenario -Name '""`bb`""'; " + 
                @"(Open-TmxTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        // ============================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void SetCurrentTestResult_Passed_OpenTestScenario()
        {
            const string suiteName = @"suite1";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TmxTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TmxTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TmxTestResultStatus -Id 001;",
                TestData.TestStatePassed);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void SetCurrentTestResult_Failed_OpenTestScenario()
        {
            const string suiteName = @"suite1";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "$null = Add-TmxTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TmxTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TmxTestResultStatus -Id 001;",
                TestData.TestStateFailed);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void SetCurrentTestResult_KnownIssue_OpenTestScenario()
        {
            const string suiteName = @"suite1";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                "$null = Add-TmxTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TmxTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TmxTestResultStatus -Id 001;",
                TestData.TestStateKnownIssue);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void SetCurrentTestResult_FailedOverPassed_OpenTestScenario()
        {
            const string suiteName = @"suite1";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TmxTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TmxTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TmxTestResultStatus -Id 001;",
                TestData.TestStateFailed);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Open_TmxTestScenario")]
        public void SetCurrentTestResult_KnownIssueOverFailed_OpenTestScenario()
        {
            const string suiteName = @"suite1";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TmxTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TmxTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TmxTestResultStatus -Id 001;",
                TestData.TestStateKnownIssue);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
