/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:01 PM
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
    /// Description of GetTMXTestScenarioStatusCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetTMXTestScenarioStatusCommandTestFixture
    {
        public GetTMXTestScenarioStatusCommandTestFixture()
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
        [Description("Get-TMXTestScenarioStatus")]
        [Category("Fast")]
        public void GetTestScenario_Current_New()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [Test]
        [Description("New-TMXTestScenario -Name Scenario1; Get-TMXTestScenarioStatus")]
        [Category("Fast")]
        public void GetTestScenario_Current_WithNotTested()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;

            UnitTestingHelper.GetNewTestScenario("name", "id", "description");
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [Test]
        [Description("New-TMXTestScenario -Name Scenario1; Close-TMXTestResult -TestResultName result -TestPassed; Get-TMXTestScenarioStatus")]
        [Category("Fast")]
        public void GetTestScenario_Current_WithPassed()
        {
            string expectedResult = TMX.TestData.TestStatePassed;

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [Test]
        [Description("New-TMXTestScenario -Name Scenario1; Close-TMXTestResult -TestResultName result -TestPassed:$false; Get-TMXTestScenarioStatus")]
        [Category("Fast")]
        public void GetTestScenario_Current_WithFailed()
        {
            string expectedResult = TMX.TestData.TestStateFailed;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [Test]
        [Description("New-TMXTestScenario -Name Scenario1; Close-TMXTestResult -TestResultName result -TestPassed -KnownIssue; Get-TMXTestScenarioStatus")]
        [Category("Fast")]
        public void GetTestScenario_Current_WithPassedKnownIssue()
        {
            // Passed -> KnownIssue
            string expectedResult = TMX.TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, true);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [Test]
        [Description("New-TMXTestScenario -Name Scenario1; Close-TMXTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TMXTestScenarioStatus")]
        [Category("Fast")]
        public void GetTestScenario_Current_WithFailedKnownIssue()
        {
            // KnownIssue supersedes the Failed status.
            
            string expectedResult = TMX.TestData.TestStateKnownIssue;
            
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, true);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
    }
}
