/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 11:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of AddTMXTestScenarioCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class AddTMXTestScenarioCommandTestFixture
    {
        public AddTMXTestScenarioCommandTestFixture()
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
        [Description("Add-TMXTestScenario -Name name")]
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
        [Description("Add-TMXTestScenario -Id id")]
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
        [Description("Add-TMXTestScenario -Name name -Description descr")]
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
        [Description("Add-TMXTestScenario -Id id -Description descr")]
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
        [Description("New-TMXTestSuite -Name suite -Id id; Add-TMXTestScenario -Name name")]
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
        [Description("New-TMXTestSuite -Name suite -Id id; Add-TMXTestScenario -Id id")]
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
        [Description("New-TMXTestSuite -Name suite -Id id | Add-TMXTestScenario -Name name")]
        [Category("Fast")]
        public void AddTestScenario_TestSuiteInPipeline_Name()
        {
            string expectedResultName = "scenario";
            ITestSuite testSuite =
                UnitTestingHelper.GetNewTestSuite("suite", "suite id", string.Empty);
            ITestScenario testScenario =
                UnitTestingHelper.AddTestScenario(testSuite, expectedResultName, string.Empty, string.Empty, string.Empty, string.Empty);

            Assert.AreEqual(
                expectedResultName,
                testScenario.Name);
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite -Id id | Add-TMXTestScenario -Id id")]
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
        [Description("New-TMXTestSuite -Name suite -Id id; Add-TMXTestScenario -Name name -TestSuiteName suite")]
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
        [Description("New-TMXTestSuite -Name suite -Id id; Add-TMXTestScenario -Id id -TestSuiteName suite")]
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
        [Description("New-TMXTestSuite -Name suite -Id id; Add-TMXTestScenario -Name name -TestSuiteId id")]
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
        [Description("New-TMXTestSuite -Name suite -Id id; Add-TMXTestScenario -Id id -TestSuiteId id")]
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
