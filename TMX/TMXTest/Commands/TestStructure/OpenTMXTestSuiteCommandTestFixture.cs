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
    /// Description of OpenTMXTestSuiteCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Open-TMXTestSuite test")]
    public class OpenTMXTestSuiteCommandTestFixture
    {
        public OpenTMXTestSuiteCommandTestFixture()
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
        [Category("Open_TMXTestSuite")]
        public void TestPrm_Name_Simple()
        {
            string name = "suite1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name " + 
                name + 
                ";" + 
                "(Open-TMXTestSuite -Name " + 
                name + 
                ").Name;",
                name);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TMXTestSuite")]
        public void TestPrm_Name_Complex()
        {
            string name = "suite%%`1  1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                name + 
                "';" + 
                "(Open-TMXTestSuite -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [Test] //[Test(Description="The -Id parameter test: simple name and Id")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TMXTestSuite")]
        public void TestPrm_Name_Id_Numeric()
        {
            string name = "suite1";
            string id = "3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name " + 
                name + 
                " -Id " + 
                id + 
                ";" +
                "(Open-TMXTestSuite -Name " + 
                name + 
                " -Id " +
                id +
                ").Name;",
                name);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                "(Open-TMXTestSuite -Name " + 
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
        [Category("Open_TMXTestSuite")]
        public void TestPrm_Name_Id_Alphanumeric()
        {
            string name = "suite1";
            string id = @"a\ 3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name " + 
                name + 
                " -Id '" + 
                id + 
                "';" +
                "(Open-TMXTestSuite -Name " + 
                name + 
                " -Id '" +
                id +
                "').Name;",
                name);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                "(Open-TMXTestSuite -Name " + 
                name + 
                " -Id '" +
                id +
                "').Id;",
                id);
        }
        
        [Test] //[Test(Description="The -Name parameter test: take by name from a bunch")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TMXTestSuite")]
        public void TestPrm_Name_againts_bunch()
        {
            string name = "abc3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1; " + 
                @"$null = New-TMXTestSuite -Name abc2; " + 
                @"$null = New-TMXTestSuite -Name " + 
                name + 
                "; " +
                @"$null = New-TMXTestSuite -Name abc4; " + 
                @"$null = New-TMXTestSuite -Name abc5; " + 
                "(Open-TMXTestSuite -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [Test] //[Test(Description="The -Id parameter test: take by name from a bunch")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TMXTestSuite")]
        public void TestPrm_Id_againts_bunch()
        {
            string name = "abc3";
            string id = @"a\ 3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = New-TMXTestSuite -Name " + 
                name + 
                " -Id '" +
                id + 
                "'; " +
                @"$null = New-TMXTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 'a\ 5'; " + 
                "(Open-TMXTestSuite -Id '" + 
                id + 
                "').Id;",
                id);
        }
        
        // ============================================================================================================
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TMXTestSuite")]
        public void SetCurrentTestResult_Passed_OpenTestSuite()
        {
            string suiteName1 = @"suite1";
            string suiteName2 = @"suite2";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName2 + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName2 +
                "'; " +
                "$null = Open-TMXTestSuite -Name " + 
                suiteName1 +
                ";" +
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStatePassed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TMXTestSuite")]
        public void SetCurrentTestResult_Failed_OpenTestSuite()
        {
            string suiteName1 = @"suite1";
            string suiteName2 = @"suite2";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus Failed;" +
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName2 + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName2 +
                "'; " +
                "$null = Open-TMXTestSuite -Name " + 
                suiteName1 +
                ";" +
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStateFailed);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TMXTestSuite")]
        public void SetCurrentTestResult_KnownIssue_OpenTestSuite()
        {
            string suiteName1 = @"suite1";
            string suiteName2 = @"suite2";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus KnownIssue;" +
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName2 + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName2 +
                "'; " +
                "$null = Open-TMXTestSuite -Name " + 
                suiteName1 +
                ";" +
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStateKnownIssue);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Open_TMXTestSuite")]
        public void SetCurrentTestResult_NotTested_OpenTestSuite()
        {
            string suiteName1 = @"suite1";
            string suiteName2 = @"suite2";
            string scenarioName1 = @"sc1";
            string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TMXCurrentTestResult 'tr1' -Id 001;" +
                "Add-TMXTestResultDetail 'detail 01' -TestResultStatus NotTested;" +
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName2 + 
                "' | Add-TMXTestScenario -Name '" +
                scenarioName2 +
                "'; " +
                "$null = Open-TMXTestSuite -Name " + 
                suiteName1 +
                ";" +
                "Get-TMXTestResultStatus -Id 001;",
                TMX.TestData.TestStateNotTested);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
