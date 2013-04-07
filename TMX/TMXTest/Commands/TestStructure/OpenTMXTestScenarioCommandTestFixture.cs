/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of OpenTMXTestScenarioCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Open-TMXTestScenario test")]
    public class OpenTMXTestScenarioCommandTestFixture
    {
        public OpenTMXTestScenarioCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name (from the active suite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void TestPrm_Name_Simple_from_active_suite()
        {
            string suiteName = "suite1";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name " + 
                suiteName + 
                " | Add-TMXTestScenario -Name " + 
                scenarioName + 
                "; " + 
                @"(Open-TMXTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name (from the active suite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void TestPrm_Name_Complex_from_active_suite()
        {
            string suiteName = @"suite%%`1  1";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" + 
                scenarioName + 
                "'; " +
                @"(Open-TMXTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name (from the selected suite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void TestPrm_Name_Simple_from_selected_suite()
        {
            string suiteName = "suite2";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = Add-TMXTestScenario -Name sc1; " + 
                @"$null = New-TMXTestSuite -Name " + 
                suiteName + 
                "; " +
                @"$null = Add-TMXTestScenario -Name " + 
                scenarioName + 
                "; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"$null = Open-TMXTestSuite -Name " +
                suiteName +
                "; " + 
                @"(Open-TMXTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name (from the selected suite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void TestPrm_Name_Complex_from_selected_suite()
        {
            string suiteName = @"suite%%`2  2";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = Add-TMXTestScenario -Name '$(`r)'; " + 
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "'; " +
                @"$null = Add-TMXTestScenario -Name '" + 
                scenarioName + 
                "'; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"$null = Open-TMXTestSuite -Name '" +
                suiteName +
                "'; " +
                @"(Open-TMXTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name (selected scenario from the active suite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void TestPrm_Name_Simple_selected_from_active_suite()
        {
            string suiteName = "suite1";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name " + 
                suiteName + 
                " | Add-TMXTestScenario -Name " + 
                scenarioName + 
                "; " + 
                @"$null = Add-TMXTestScenario -Name sc2; " + 
                @"$null = Add-TMXTestScenario -Name sc3; " + 
                @"(Open-TMXTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name (selected scenario from the active suite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void TestPrm_Name_Complex_selected_from_active_suite()
        {
            string suiteName = @"suite%%`1  1";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name 'asdfa \\sdter//'; " + 
                "$null = Add-TMXTestScenario -Name '" + 
                scenarioName + 
                "'; " +
                @"$null = Add-TMXTestScenario -Name '""`bb`""'; " + 
                @"(Open-TMXTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        // ============================================================================================================
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void SetCurrentTestResult_Passed_OpenTestScenario()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TMXTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TMXTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStatePassed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void SetCurrentTestResult_Failed_OpenTestScenario()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "$null = Add-TMXTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TMXTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStateFailed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void SetCurrentTestResult_KnownIssue_OpenTestScenario()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                "$null = Add-TMXTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TMXTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStateKnownIssue);
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void SetCurrentTestResult_FailedOverPassed_OpenTestScenario()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TMXTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TMXTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStateFailed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Open_TMXTestScenario")]
        public void SetCurrentTestResult_KnownIssueOverFailed_OpenTestScenario()
        {
            string suiteName = @"suite1";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                "$null = Add-TMXTestScenario -Name '" + 
                scenarioName2 + 
                "'; " +
                "$null = Open-TMXTestScenario -Name '" + 
                scenarioName1 + 
                "';" + 
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStateKnownIssue);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
