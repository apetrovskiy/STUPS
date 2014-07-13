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
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of AddTmxTestScenarioCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Add-TmxTestScenario test")]
    public class AddTmxTestScenarioCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name (New-TmxTestSuite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Simple_after_NewSuite()
        {
            const string suiteName = "suite1";
            const string scenarioName = "sc1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name " + 
                suiteName + 
                " | Add-TmxTestScenario -Name " + 
                scenarioName + 
                ").Name;",
                scenarioName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name (New-TmxTestSuite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Complex_after_NewSuite()
        {
            const string suiteName = @"suite%%`1  1";
            const string scenarioName = @"\ s c 1 \";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name '" + 
                suiteName + 
                "' | Add-TmxTestScenario -Name '" + 
                scenarioName + 
                "').Name;",
                scenarioName);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name (Open-TmxTestSuite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Simple_after_OpenSuite()
        {
            const string suiteName = "suite2";
            const string scenarioName = "sc1";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name (Open-TmxTestSuite)")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Complex_after_OpenSuite()
        {
            const string suiteName = @"suite%%`2  2";
            const string scenarioName = @"\ s c 1 \";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name and simple suite name")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteName_Simple()
        {
            const string suiteName = "suite2";
            const string scenarioName = "sc1";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name and complex suite name")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteName_Complex()
        {
            const string suiteName = @"suite%%`2  2";
            const string scenarioName = @"\ s c 1 \";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name and simple suite id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteId_Simple()
        {
            const string suiteName = "suite2";
            const string suiteId = "222";
            const string scenarioName = "sc1";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name and complex suite id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteId_Complex()
        {
            const string suiteName = @"suite%%`2  2";
            const string suiteId = @"/2\";
            const string scenarioName = @"\ s c 1 \";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name, simple suite name, and simple suite id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteName_TestSuiteId_Simple()
        {
            const string suiteName = "suite2";
            const string suiteId = "222";
            const string scenarioName = "sc1";
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name, complex suite name, and complex suite id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_TestSuiteName_TestSuiteId_Complex()
        {
            const string suiteName = @"suite%%`2  2";
            const string suiteId = @"/2\";
            const string scenarioName = @"\ s c 1 \";
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

        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test 1")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        [MbUnit.Framework.Ignore("This code never worked before. 20130207")]
        [NUnit.Framework.Ignore("This code never worked before. 20130207")]
        public void TestPrm_Name_Description1()
        {
            var testScenarioDescription = string.Empty;
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
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test 2")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Description2()
        {
            const string testScenarioDescription = "test scenario description";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description '" + 
                testScenarioDescription + 
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].Description;",
                testScenarioDescription);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test 3")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestPrm_Name_Description3()
        {
            const string testScenarioDescription = @"test \\scenario `r`ndescription ...";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void](New-TmxTestSuite -Description ""suite description"" -Name suite1 -Id 111); " + 
                @"[void](Add-TmxTestScenario -Name sc1 -Id 1111 -TestSuiteName suite1 -Description '" + 
                testScenarioDescription + 
                "'); " +
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].Description;",
                testScenarioDescription);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The SuiteId assignment test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Add_TmxTestScenario")]
        public void TestProperty_SuiteId()
        {
            const string suiteName = "suite1";
            const string suiteId = "111";
            const string scenarioName = "sc1";
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
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
