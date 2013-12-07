/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 12:57 AM
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
    /// Description of CloseTmxTestResultCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class CloseTmxTestResultCommandTestFixture
    {
        public CloseTmxTestResultCommandTestFixture()
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
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void CloseTestResult_Current_WithPassed()
        {
            string expectedResult = TMX.TestData.TestStatePassed;

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            Assert.AreEqual(
                expectedResult,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void CloseTestResult_Current_WithFailed()
        {
            string expectedResult = TMX.TestData.TestStateFailed;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);

            Assert.AreEqual(
                expectedResult,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed -KnownIssue; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void CloseTestResult_Current_WithPassedKnownIssue()
        {
            string expectedResult = TMX.TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, true);

            Assert.AreEqual(
                expectedResult,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void CloseTestResult_Current_WithFailedKnownIssue()
        {
            string expectedResult = TMX.TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, true);
            Assert.AreEqual(
                expectedResult,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [Test]
        [Category("Fast")]
        [Ignore]
        public void Need_Code()
        {
            
        }
    }
}
