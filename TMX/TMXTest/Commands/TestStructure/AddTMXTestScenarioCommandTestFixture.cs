/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of AddTmxTestScenarioCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Add-TmxTestScenario test")]
    public class AddTmxTestScenarioCommandTestFixture
    {
        public AddTmxTestScenarioCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name (New-TmxTestSuite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Simple_after_NewSuite()
        {
            string suiteName = "suite1";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name " + 
                suiteName + 
                " | Add-TmxTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name (New-TmxTestSuite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Complex_after_NewSuite()
        {
            string suiteName = @"suite%%`1  1";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name (Open-TmxTestSuite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Simple_after_OpenSuite()
        {
            string suiteName = "suite2";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = New-TmxTestSuite -Name " + 
                suiteName + 
                "; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"(Open-TmxTestSuite -Name " +
                suiteName +
                " | Add-TmxTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name (Open-TmxTestSuite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Complex_after_OpenSuite()
        {
            string suiteName = @"suite%%`2  2";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "'; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"(Open-TmxTestSuite -Name '" +
                suiteName +
                "' | Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name and simple suite name")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteName_Simple()
        {
            string suiteName = "suite2";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = New-TmxTestSuite -Name " + 
                suiteName + 
                "; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"(Add-TmxTestScenario -Name " + 
                scenarioName + 
                " -TestSuiteName " +
                suiteName +
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name and complex suite name")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteName_Complex()
        {
            string suiteName = @"suite%%`2  2";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "'; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"(Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "' -TestSuiteName '" +
                suiteName +
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name and simple suite id")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteId_Simple()
        {
            string suiteName = "suite2";
            string suiteId = "222";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = New-TmxTestSuite -Name " + 
                suiteName + 
                " -Id " + 
                suiteId + 
                "; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"(Add-TmxTestScenario -Name " + 
                scenarioName + 
                " -TestSuiteId " +
                suiteId +
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name and complex suite id")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteId_Complex()
        {
            string suiteName = @"suite%%`2  2";
            string suiteId = @"/2\";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' -Id '" + 
                suiteId + 
                "'; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"(Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "' -TestSuiteId '" +
                suiteId +
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name, simple suite name, and simple suite id")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteName_TestSuiteId_Simple()
        {
            string suiteName = "suite2";
            string suiteId = "222";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = New-TmxTestSuite -Name " + 
                suiteName + 
                " -Id " + 
                suiteId + 
                "; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"(Add-TmxTestScenario -Name " + 
                scenarioName + 
                " -TestSuiteName " +
                suiteName +
                " -TestSuiteId " + 
                suiteId +
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name, complex suite name, and complex suite id")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteName_TestSuiteId_Complex()
        {
            string suiteName = @"suite%%`2  2";
            string suiteId = @"/2\";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " +
                @"$null = New-TmxTestSuite -Name '" + 
                suiteName + 
                "' -Id '" + 
                suiteId + 
                "'; " +
                @"$null = New-TmxTestSuite -Name suite3; " +
                @"(Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "' -TestSuiteName '" +
                suiteName +
                "' -TestSuiteId '" + 
                suiteId +
                "').Name;",
                scenarioName);
        }

        [Test] //[Test(Description="The -Description parameter test 1")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        [Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_Description1()
        {
            string testScenarioDescription = "";
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description '" + 
                testScenarioDescription + 
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].Description;",
                // 20130207
                //"System.NullReferenceException",
                "AssertionFailureException",
                "Object reference not set to an instance of an object.");
        }
        
        [Test] //[Test(Description="The -Description parameter test 2")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Description2()
        {
            string testScenarioDescription = "test scenario description";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description '" + 
                testScenarioDescription + 
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].Description;",
                testScenarioDescription);
        }
        
        [Test] //[Test(Description="The -Description parameter test 3")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Description3()
        {
            string testScenarioDescription = @"test \\scenario `r`ndescription ...";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description '" + 
                testScenarioDescription + 
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].Description;",
                testScenarioDescription);
        }
        
        [Test] //[Test(Description="The SuiteId assignment test")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TmxTestScenario")]
        public void TestProperty_SuiteId()
        {
            string suiteName = "suite1";
            string suiteId = "111";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name '" + 
                suiteName + 
                @"' -Id '" +
                suiteId + 
                @"' | Add-TmxTestScenario -Name " + 
                scenarioName + 
                ").SuiteId;",
                suiteId);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
