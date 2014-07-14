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
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of OpenTmxTestSuiteCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Open-TmxTestSuite test")]
    public class OpenTmxTestSuiteCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void TestPrm_Name_Simple()
        {
            const string name = "suite1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                ";" + 
                "(Open-TmxTestSuite -Name " + 
                name + 
                ").Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void TestPrm_Name_Complex()
        {
            const string name = "suite%%`1  1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                name + 
                "';" + 
                "(Open-TmxTestSuite -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Id parameter test: simple name and Id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void TestPrm_Name_Id_Numeric()
        {
            const string name = "suite1";
            const string id = "3";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Id parameter test: simple name and complex Id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void TestPrm_Name_Id_Alphanumeric()
        {
            const string name = "suite1";
            const string id = @"a\ 3";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: take by name from a bunch")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void TestPrm_Name_againts_bunch()
        {
            const string name = "abc3";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Id parameter test: take by name from a bunch")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void TestPrm_Id_againts_bunch()
        {
            const string name = "abc3";
            const string id = @"a\ 3";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void SetCurrentTestResult_Passed_OpenTestSuite()
        {
            const string suiteName1 = @"suite1";
            const string suiteName2 = @"suite2";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName1 + 
                "' | Add-TmxTestScenario -Name '" +
                scenarioName1 +
                "'; " +
                "Set-TmxCurrentTestResult 'tr1' -Id 001;" +
                "Add-TmxTestResultDetail 'detail 01' -TestResultStatus Passed;" +
                // 20140714
                "Add-TmxTestResultDetail 'detail 02' -TestResultStatus Passed -Finished;" +
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void SetCurrentTestResult_Failed_OpenTestSuite()
        {
            const string suiteName1 = @"suite1";
            const string suiteName2 = @"suite2";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void SetCurrentTestResult_KnownIssue_OpenTestSuite()
        {
            const string suiteName1 = @"suite1";
            const string suiteName2 = @"suite2";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Open_TmxTestSuite")]
        public void SetCurrentTestResult_NotTested_OpenTestSuite()
        {
            const string suiteName1 = @"suite1";
            const string suiteName2 = @"suite2";
            const string scenarioName1 = @"sc1";
            const string scenarioName2 = @"sc2";
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
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
