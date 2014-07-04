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
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of AddTmxTestScenarioCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class AddTmxTestScenarioCommandTestFixture
    {
        public AddTmxTestScenarioCommandTestFixture()
        {
        }
        
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
            string expectedResultName = "scenario";
            ITestScenario testScenario =
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
            string expectedResultId = "scenario id";
            ITestScenario testScenario =
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
            string expectedResultName = "scenario";
            string expectedResultDescr = "descr";
            ITestScenario testScenario =
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
            string expectedResultId = "scenario id";
            string expectedResultDescr = "descr";
            ITestScenario testScenario =
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
            string expectedResultName = "scenario";
            UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
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
            string expectedResultId = "scenario id";
            UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
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
            string expectedResultName = "scenario";
            ITestSuite testSuite =
                // 20131127
                //(ITestSuite)
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
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
            string expectedResultId = "scenario id";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
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
            string expectedResultName = "scenario";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
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
            string expectedResultId = "scenario id";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
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
            string expectedResultName = "scenario";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
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
            string expectedResultId = "scenario id";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, string.Empty, testSuite.Id);
            
            MbUnit.Framework.Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
    }
}
