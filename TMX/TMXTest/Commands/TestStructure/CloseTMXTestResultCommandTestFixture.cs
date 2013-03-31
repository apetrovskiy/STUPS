/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of CloseTMXTestResultCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Close-TMXTestResult test")]
    public class CloseTMXTestResultCommandTestFixture
    {
        public CloseTMXTestResultCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple string")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_Simple()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                testResultName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex string")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_Complex()
        {
            string testResultName = @"\\#result1  ;;;";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name '" + 
                testResultName + 
                "';" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Name;",
                testResultName);
        }
        
        [Test] //[Test(Description="The -TestPassed parameter test: the Passed state 1 (-TestPassed)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestPassed1()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "PASSED");
        }
        
        [Test] //[Test(Description="The -TestPassed parameter test: the Passed state 2 (-TestPassed:$true)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestPassed2()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed:$true;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "PASSED");
        }
        
        [Test] //[Test(Description="The -TestPassed parameter test: the Failed state 1 (-TestPassed:$false)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestFailed1()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed:$false;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "FAILED");
        }
        
        [Test] //[Test(Description="The -TestPassed parameter test: the Failed state 2 (no -TestPassed)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestFailed2()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "FAILED");
        }
        
        [Test] //[Test(Description="The -TestPassed parameter test: the NotTested state")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestNotTested()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TMXTestResultDetail -TestResultDetail " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "NOT TESTED");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 1 (the bare case)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue1()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -KnownIssue;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "KNOWN ISSUE");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 1t (the bare case)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue1t()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -KnownIssue:$true;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "KNOWN ISSUE");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 1f (the bare case)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue1f()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -KnownIssue:$false;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "FAILED");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 2 (known issue instead of failed)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue2()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed:$false" + 
                " -KnownIssue;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "KNOWN ISSUE");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 2t (known issue instead of failed)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue2t()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed:$false" + 
                " -KnownIssue:$true;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "KNOWN ISSUE");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 2f (known issue instead of failed)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue2f()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed:$false" + 
                " -KnownIssue:$false;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "FAILED");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 3 (known issue hidden by passed)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue3()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed:$true" + 
                " -KnownIssue;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                // 20120925 KnownIssue changes
                //"PASSED");
                "KNOWN ISSUE");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 3t (known issue hidden by passed)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue3t()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed:$true" + 
                " -KnownIssue:$true;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                // 20120925 KnownIssue changes
                //"PASSED");
                "KNOWN ISSUE");
        }
        
        [Test] //[Test(Description="The -TestPassed & -KnownIssue parameters test: the KnownIssue state 3f (known issue hidden by passed)")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_TestKnownIssue3f()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Close-TMXTestResult -Name " + 
                testResultName + 
                " -TestPassed:$true" + 
                " -KnownIssue:$false;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Status;",
                "PASSED");
        }
        
        [Test] //[Test(Description="The -Description parameter test: from the suite")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        [Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_DescriptionSuite()
        {
            string testResultDescription = "";
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TMXTestResult -TestPassed -Name test1); " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureExceptio",
                "Object reference not set to an instance of an object.");
        }
        
        [Test] //[Test(Description="The -Description parameter test: from the scenario 1")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        [Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_DescriptionScenario1()
        {
            string testResultDescription = "";
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description ''); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TMXTestResult -TestPassed -Name test1); " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureExceptio",
                "Object reference not set to an instance of an object.");
        }
        
        [Test] //[Test(Description="The -Description parameter test: from the scenario 2")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        [Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_DescriptionScenario2()
        {
            string testResultDescription = "";
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description 'scenario description'); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TMXTestResult -TestPassed -Name test1); " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureExceptio",
                "Object reference not set to an instance of an object.");
        }
        
        [Test] //[Test(Description="The -Description parameter test: from the test result 1")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        [Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_DescriptionTestResult1()
        {
            string testResultDescription = "";
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description 'scenario description'); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TMXTestResult -TestPassed -Name test1 -Description '" + 
                testResultDescription +
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureExceptio",
                "Object reference not set to an instance of an object.");
        }
        
        [Test] //[Test(Description="The -Description parameter test: from the test result 2")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestPrm_Name_DescriptionTestResult2()
        {
            string testResultDescription = "test result description";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description 'scenario description'); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TMXTestResult -TestPassed -Name test1 -Description '" + 
                testResultDescription +
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Description;",
                testResultDescription);
        }
        
        [Test] //[Test(Description="The cenarioId property")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestProperty_ScenarioId()
        {
            string scenarioId = "1111";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id " + 
                scenarioId + 
                " -TestSuiteName suite1); " +
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TMXTestResult -TestPassed -Name test1); " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].ScenarioId;",
                scenarioId);
        }
        
        [Test] //[Test(Description="The cenarioId property")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Close_TMXTestResult")]
        public void TestProperty_SuiteId()
        {
            string suiteId = "111";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id " + 
                suiteId +
                "); " +
                @"[void](Add-TMXTestScenario -Name sc1 -Id 111 -TestSuiteName suite1); " +
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""1""); " + 
                @"[void](Add-TMXTestResultDetail -TestResultDetail ""2""); " + 
                @"[void](Close-TMXTestResult -TestPassed -Name test1); " + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].SuiteId;",
                suiteId);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
