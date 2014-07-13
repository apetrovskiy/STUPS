/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 11:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    using PSTestLib;
    using TMX;
	using TMX.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of AddTmxTestScenarioCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class AddTmxTestScenarioCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("Add-TmxTestScenario -Name name")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_NoTestSuites_Name()
        {
            const string expectedResultName = "scenario";
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, string.Empty, string.Empty, string.Empty);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("Add-TmxTestScenario -Id id")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_NoTestSuites_Id()
        {
            const string expectedResultId = "scenario id";
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, string.Empty, string.Empty);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("Add-TmxTestScenario -Name name -Description descr")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_NoTestSuites_Name_Description()
        {
            const string expectedResultName = "scenario";
            const string expectedResultDescr = "descr";
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, expectedResultDescr, string.Empty, string.Empty);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultDescr,
                testScenario.Description);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("Add-TmxTestScenario -Id id -Description descr")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_NoTestSuites_Id_Description()
        {
            const string expectedResultId = "scenario id";
            const string expectedResultDescr = "descr";
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, expectedResultDescr, string.Empty, string.Empty);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultDescr,
                testScenario.Description);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Name name")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_CurrentTestSuite_Name()
        {
            const string expectedResultName = "scenario";
            UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, string.Empty, string.Empty, string.Empty);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Id id")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_CurrentTestSuite_Id()
        {
            const string expectedResultId = "scenario id";
            UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, string.Empty, string.Empty);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite -Id id | Add-TmxTestScenario -Name name")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_TestSuiteInPipeline_Name()
        {
            const string expectedResultName = "scenario";
            var testSuite =
                // 20131127
                //(ITestSuite)
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            var testScenario =
                UnitTestingHelper.AddTestScenario(testSuite, expectedResultName, string.Empty, string.Empty, string.Empty, string.Empty);

            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite -Id id | Add-TmxTestScenario -Id id")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_TestSuiteInPipeline_Id()
        {
            const string expectedResultId = "scenario id";
            var testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            var testScenario =
                UnitTestingHelper.AddTestScenario(testSuite, string.Empty, expectedResultId, string.Empty, string.Empty, string.Empty);

            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Name name -TestSuiteName suite")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_TestSuiteName_Name()
        {
            const string expectedResultName = "scenario";
            var testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, string.Empty, testSuite.Name, string.Empty);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Id id -TestSuiteName suite")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_TestSuiteName_Id()
        {
            const string expectedResultId = "scenario id";
            var testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, testSuite.Name, string.Empty);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Name name -TestSuiteId id")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_TestSuiteId_Name()
        {
            const string expectedResultName = "scenario";
            var testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, string.Empty, string.Empty, testSuite.Id);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Id id -TestSuiteId id")]
        [MbUnit.Framework.Category("Fast")]
        public void AddTestScenario_TestSuiteId_Id()
        {
            const string expectedResultId = "scenario id";
            var testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            var testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, string.Empty, testSuite.Id);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
    }
}
