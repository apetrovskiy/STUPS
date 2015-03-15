/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of CloseTmxTestResultCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Close-TmxTestResult test")]
    public class CloseTmxTestResultCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple string")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_Simple()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                ";" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                testResultName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex string")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_Complex()
        {
            const string testResultName = @"\\#result1  ;;;";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name '" + 
                testResultName + 
                "';" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                testResultName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed parameter test: the Passed state 1 (-TestPassed)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestPassed1()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "PASSED");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed parameter test: the Passed state 2 (-TestPassed:$true)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestPassed2()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed:$true;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "PASSED");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed parameter test: the Failed state 1 (-TestPassed:$false)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestFailed1()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed:$false;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "FAILED");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed parameter test: the Failed state 2 (no -TestPassed)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestFailed2()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                ";" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "FAILED");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed parameter test: the NotTested state")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestNotTested()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail " + 
                testResultName + 
                ";" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "NOT TESTED");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 1 (the bare case)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue1()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -KnownIssue;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "KNOWN ISSUE");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 1t (the bare case)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue1t()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -KnownIssue:$true;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "KNOWN ISSUE");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 1f (the bare case)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue1f()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -KnownIssue:$false;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "FAILED");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 2 (known issue instead of failed)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue2()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed:$false" + 
                " -KnownIssue;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "KNOWN ISSUE");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 2t (known issue instead of failed)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue2t()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed:$false" + 
                " -KnownIssue:$true;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "KNOWN ISSUE");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 2f (known issue instead of failed)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue2f()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed:$false" + 
                " -KnownIssue:$false;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "FAILED");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 3 (known issue hidden by passed)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue3()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed:$true" + 
                " -KnownIssue;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                // 20120925 KnownIssue changes
                //"PASSED");
                "KNOWN ISSUE");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 3t (known issue hidden by passed)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue3t()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed:$true" + 
                " -KnownIssue:$true;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                // 20120925 KnownIssue changes
                //"PASSED");
                "KNOWN ISSUE");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 3f (known issue hidden by passed)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_TestKnownIssue3f()
        {
            const string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TmxTestResult -Name " + 
                testResultName + 
                " -TestPassed:$true" + 
                " -KnownIssue:$false;" + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "PASSED");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test: from the suite")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        [MbUnit.Framework.Ignore("This code never worked before. 20130207")]
        [NUnit.Framework.Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_DescriptionSuite()
        {
            var testResultDescription = string.Empty;
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TmxTestResult -TestPassed -Name test1); " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureExceptio",
                "Object reference not set to an instance of an object.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test: from the scenario 1")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        [MbUnit.Framework.Ignore("This code never worked before. 20130207")]
        [NUnit.Framework.Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_DescriptionScenario1()
        {
            var testResultDescription = string.Empty;
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description ''); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TmxTestResult -TestPassed -Name test1); " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureExceptio",
                "Object reference not set to an instance of an object.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test: from the scenario 2")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        [MbUnit.Framework.Ignore("This code never worked before. 20130207")]
        [NUnit.Framework.Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_DescriptionScenario2()
        {
            var testResultDescription = string.Empty;
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description 'scenario description'); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TmxTestResult -TestPassed -Name test1); " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureExceptio",
                "Object reference not set to an instance of an object.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test: from the test result 1")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        [MbUnit.Framework.Ignore("This code never worked before. 20130207")]
        [NUnit.Framework.Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_DescriptionTestResult1()
        {
            var testResultDescription = string.Empty;
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description 'scenario description'); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TmxTestResult -TestPassed -Name test1 -Description '" + 
                testResultDescription +
                "'); " +
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureExceptio",
                "Object reference not set to an instance of an object.");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test: from the test result 2")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestPrm_Name_DescriptionTestResult2()
        {
            const string testResultDescription = "test result description";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description 'scenario description'); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TmxTestResult -TestPassed -Name test1 -Description '" + 
                testResultDescription +
                "'); " +
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                testResultDescription);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The cenarioId property")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestProperty_ScenarioId()
        {
            const string scenarioId = "1111";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id " + 
                scenarioId + 
                " -TestSuiteName suite1); " +
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TmxTestResult -TestPassed -Name test1); " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].ScenarioId;",
                scenarioId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The cenarioId property")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Close_TmxTestResult")]
        public void TestProperty_SuiteId()
        {
            const string suiteId = "111";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id " + 
                suiteId +
                "); " +
                @"[void](Add-TmxTestScenario -Name sc1 -Id 111 -TestSuiteName suite1); " +
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TmxTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TmxTestResult -TestPassed -Name test1); " + 
                "[Tmx.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].SuiteId;",
                suiteId);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
