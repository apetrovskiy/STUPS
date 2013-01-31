/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2012
 * Time: 12:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXUnitTests.Commands.Status
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of CloseTMXTestResultCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class CloseTMXTestResultCommandTestFixture
    {
        public CloseTMXTestResultCommandTestFixture()
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
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName result -TestPassed; Get-TMXTestSuiteStatus")]
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
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName result -TestPassed:$false; Get-TMXTestSuiteStatus")]
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
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName result -TestPassed -KnownIssue; Get-TMXTestSuiteStatus")]
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
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TMXTestSuiteStatus")]
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
