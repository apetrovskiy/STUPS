/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of AddTMXTestScenarioCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Add-TMXTestScenario test")]
    public class AddTMXTestScenarioCommandTestFixture
    {
        public AddTMXTestScenarioCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name (New-TMXTestSuite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_Simple_after_NewSuite()
        {
            string suiteName = "suite1";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TMXTestSuite -Name " + 
                suiteName + 
                " | Add-TMXTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name (New-TMXTestSuite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_Complex_after_NewSuite()
        {
            string suiteName = @"suite%%`1  1";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TMXTestSuite -Name '" + 
                suiteName + 
                "' | Add-TMXTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name (Open-TMXTestSuite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_Simple_after_OpenSuite()
        {
            string suiteName = "suite2";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = New-TMXTestSuite -Name " + 
                suiteName + 
                "; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"(Open-TMXTestSuite -Name " +
                suiteName +
                " | Add-TMXTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name (Open-TMXTestSuite)")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_Complex_after_OpenSuite()
        {
            string suiteName = @"suite%%`2  2";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "'; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"(Open-TMXTestSuite -Name '" +
                suiteName +
                "' | Add-TMXTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name and simple suite name")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_TestSuiteName_Simple()
        {
            string suiteName = "suite2";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = New-TMXTestSuite -Name " + 
                suiteName + 
                "; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"(Add-TMXTestScenario -Name " + 
                scenarioName + 
                " -TestSuiteName " +
                suiteName +
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name and complex suite name")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_TestSuiteName_Complex()
        {
            string suiteName = @"suite%%`2  2";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "'; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"(Add-TMXTestScenario -Name '" + 
                scenarioName + 
                "' -TestSuiteName '" +
                suiteName +
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name and simple suite id")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_TestSuiteId_Simple()
        {
            string suiteName = "suite2";
            string suiteId = "222";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = New-TMXTestSuite -Name " + 
                suiteName + 
                " -Id " + 
                suiteId + 
                "; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"(Add-TMXTestScenario -Name " + 
                scenarioName + 
                " -TestSuiteId " +
                suiteId +
                ").Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name and complex suite id")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_TestSuiteId_Complex()
        {
            string suiteName = @"suite%%`2  2";
            string suiteId = @"/2\";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' -Id '" + 
                suiteId + 
                "'; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"(Add-TMXTestScenario -Name '" + 
                scenarioName + 
                "' -TestSuiteId '" +
                suiteId +
                "').Name;",
                scenarioName);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name, simple suite name, and simple suite id")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_TestSuiteName_TestSuiteId_Simple()
        {
            string suiteName = "suite2";
            string suiteId = "222";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = New-TMXTestSuite -Name " + 
                suiteName + 
                " -Id " + 
                suiteId + 
                "; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"(Add-TMXTestScenario -Name " + 
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
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_TestSuiteName_TestSuiteId_Complex()
        {
            string suiteName = @"suite%%`2  2";
            string suiteId = @"/2\";
            string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " +
                @"$null = New-TMXTestSuite -Name '" + 
                suiteName + 
                "' -Id '" + 
                suiteId + 
                "'; " +
                @"$null = New-TMXTestSuite -Name suite3; " +
                @"(Add-TMXTestScenario -Name '" + 
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
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_Description1()
        {
            string testScenarioDescription = "";
            CmdletUnitTest.TestRunspace.RunAndGetTheException( //.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description '" + 
                testScenarioDescription + 
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].Description;",
                "System.NullReferenceException",
                "Object reference not set to an instance of an object.");
        }
        
        [Test] //[Test(Description="The -Description parameter test 2")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_Description2()
        {
            string testScenarioDescription = "test scenario description";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description '" + 
                testScenarioDescription + 
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].Description;",
                testScenarioDescription);
        }
        
        [Test] //[Test(Description="The -Description parameter test 3")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestPrm_Name_Description3()
        {
            string testScenarioDescription = @"test \\scenario `r`ndescription ...";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TMXTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TMXTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description '" + 
                testScenarioDescription + 
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].Description;",
                testScenarioDescription);
        }
        
        [Test] //[Test(Description="The SuiteId assignment test")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Add_TMXTestScenario")]
        public void TestProperty_SuiteId()
        {
            string suiteName = "suite1";
            string suiteId = "111";
            string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TMXTestSuite -Name '" + 
                suiteName + 
                @"' -Id '" +
                suiteId + 
                @"' | Add-TMXTestScenario -Name " + 
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
