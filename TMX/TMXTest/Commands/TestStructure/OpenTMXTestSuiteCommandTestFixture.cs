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
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of OpenTmxTestSuiteCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Open-TmxTestSuite test")]
    public class OpenTmxTestSuiteCommandTestFixture
    {
        public OpenTmxTestSuiteCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void TestPrm_Name_Simple()
        {
            string name = "suite1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                ";" + 
                "(Open-TmxTestSuite -Name " + 
                name + 
                ").Name;",
                name);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void TestPrm_Name_Complex()
        {
            string name = "suite%%`1  1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                name + 
                "';" + 
                "(Open-TmxTestSuite -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [Test] //[Test(Description="The -Id parameter test: simple name and Id")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void TestPrm_Name_Id_Numeric()
        {
            string name = "suite1";
            string id = "3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                " -Id " + 
                id + 
                ";" +
                "(Open-TmxTestSuite -Name " + 
                name + 
                " -Id " +
                id +
                ").Name;",
                name);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                "(Open-TmxTestSuite -Name " + 
                name + 
                " -Id " +
                id +
                ").Id;",
                id);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[TMX.TestData]::TestSuites[0].Name",
                "suite1");
        }
        
        [Test] //[Test(Description="The -Id parameter test: simple name and complex Id")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void TestPrm_Name_Id_Alphanumeric()
        {
            string name = "suite1";
            string id = @"a\ 3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                " -Id '" + 
                id + 
                "';" +
                "(Open-TmxTestSuite -Name " + 
                name + 
                " -Id '" +
                id +
                "').Name;",
                name);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                "(Open-TmxTestSuite -Name " + 
                name + 
                " -Id '" +
                id +
                "').Id;",
                id);
        }
        
        [Test] //[Test(Description="The -Name parameter test: take by name from a bunch")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void TestPrm_Name_againts_bunch()
        {
            string name = "abc3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1; " + 
                @"$null = New-TmxTestSuite -Name abc2; " + 
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                "; " +
                @"$null = New-TmxTestSuite -Name abc4; " + 
                @"$null = New-TmxTestSuite -Name abc5; " + 
                "(Open-TmxTestSuite -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [Test] //[Test(Description="The -Id parameter test: take by name from a bunch")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void TestPrm_Id_againts_bunch()
        {
            string name = "abc3";
            string id = @"a\ 3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                " -Id '" +
                id + 
                "'; " +
                @"$null = New-TmxTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 'a\ 5'; " + 
                "(Open-TmxTestSuite -Id '" + 
                id + 
                "').Id;",
                id);
        }
        
        // ============================================================================================================
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void SetCurrentTestResult_Passed_OpenTestSuite()
        {
            string suiteName1 = @"suite1";
            string suiteName2 = @"suite2";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName2 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName2 +
                "'; " +
                "$null = Open-TmxTestSuite -Name " + 
                suiteName1 +
                ";" +
                "Get-TmxTestResultStatus -Id 001;",
                TMX.TestData.TestStatePassed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void SetCurrentTestResult_Failed_OpenTestSuite()
        {
            string suiteName1 = @"suite1";
            string suiteName2 = @"suite2";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName2 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName2 +
                "'; " +
                "$null = Open-TmxTestSuite -Name " + 
                suiteName1 +
                ";" +
                "Get-TmxTestResultStatus -Id 001;",
                TMX.TestData.TestStateFailed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void SetCurrentTestResult_KnownIssue_OpenTestSuite()
        {
            string suiteName1 = @"suite1";
            string suiteName2 = @"suite2";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName2 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName2 +
                "'; " +
                "$null = Open-TmxTestSuite -Name " + 
                suiteName1 +
                ";" +
                "Get-TmxTestResultStatus -Id 001;",
                TMX.TestData.TestStateKnownIssue);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TmxTestSuite")]
        public void SetCurrentTestResult_NotTested_OpenTestSuite()
        {
            string suiteName1 = @"suite1";
            string suiteName2 = @"suite2";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus NotTested;" +
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName2 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName2 +
                "'; " +
                "$null = Open-TmxTestSuite -Name " + 
                suiteName1 +
                ";" +
                "Get-TmxTestResultStatus -Id 001;",
                TMX.TestData.TestStateNotTested);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
