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
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of AddTmxTestScenarioCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class AddTmxTestScenarioCommandTestFixture
    {
        public AddTmxTestScenarioCommandTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        [Description("Add-TmxTestScenario -Name name")]
        [Category("Fast")]
        public void AddTestScenario_NoTestSuites_Name()
        {
            string expectedResultName = "scenario";
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, string.Empty, string.Empty, string.Empty);
            
            Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [Test]
        [Description("Add-TmxTestScenario -Id id")]
        [Category("Fast")]
        public void AddTestScenario_NoTestSuites_Id()
        {
            string expectedResultId = "scenario id";
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, string.Empty, string.Empty);
            
            Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
        
        [Test]
        [Description("Add-TmxTestScenario -Name name -Description descr")]
        [Category("Fast")]
        public void AddTestScenario_NoTestSuites_Name_Description()
        {
            string expectedResultName = "scenario";
            string expectedResultDescr = "descr";
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, expectedResultDescr, string.Empty, string.Empty);
            
            Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
            
            Assert.AreEqual(
                expectedResultDescr,
                testScenario.Description);
        }
        
        [Test]
        [Description("Add-TmxTestScenario -Id id -Description descr")]
        [Category("Fast")]
        public void AddTestScenario_NoTestSuites_Id_Description()
        {
            string expectedResultId = "scenario id";
            string expectedResultDescr = "descr";
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, expectedResultDescr, string.Empty, string.Empty);
            
            Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
            
            Assert.AreEqual(
                expectedResultDescr,
                testScenario.Description);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Name name")]
        [Category("Fast")]
        public void AddTestScenario_CurrentTestSuite_Name()
        {
            string expectedResultName = "scenario";
            UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, string.Empty, string.Empty, string.Empty);
            
            Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Id id")]
        [Category("Fast")]
        public void AddTestScenario_CurrentTestSuite_Id()
        {
            string expectedResultId = "scenario id";
            UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, string.Empty, string.Empty);
            
            Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite -Id id | Add-TmxTestScenario -Name name")]
        [Category("Fast")]
        public void AddTestScenario_TestSuiteInPipeline_Name()
        {
            string expectedResultName = "scenario";
            ITestSuite testSuite =
                // 20131127
                //(ITestSuite)
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(testSuite, expectedResultName, string.Empty, string.Empty, string.Empty, string.Empty);

            Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite -Id id | Add-TmxTestScenario -Id id")]
        [Category("Fast")]
        public void AddTestScenario_TestSuiteInPipeline_Id()
        {
            string expectedResultId = "scenario id";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(testSuite, string.Empty, expectedResultId, string.Empty, string.Empty, string.Empty);

            Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Name name -TestSuiteName suite")]
        [Category("Fast")]
        public void AddTestScenario_TestSuiteName_Name()
        {
            string expectedResultName = "scenario";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, string.Empty, testSuite.Name, string.Empty);
            
            Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Id id -TestSuiteName suite")]
        [Category("Fast")]
        public void AddTestScenario_TestSuiteName_Id()
        {
            string expectedResultId = "scenario id";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, testSuite.Name, string.Empty);
            
            Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Name name -TestSuiteId id")]
        [Category("Fast")]
        public void AddTestScenario_TestSuiteId_Name()
        {
            string expectedResultName = "scenario";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, expectedResultName, string.Empty, string.Empty, string.Empty, testSuite.Id);
            
            Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite -Id id; Add-TmxTestScenario -Id id -TestSuiteId id")]
        [Category("Fast")]
        public void AddTestScenario_TestSuiteId_Id()
        {
            string expectedResultId = "scenario id";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(null, string.Empty, expectedResultId, string.Empty, string.Empty, testSuite.Id);
            
            Assert.AreEqual(
                expectedResultId,
                testScenario.Id);
        }
    }
}
