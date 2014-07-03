/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests.Commands.Status
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    using TMX.Interfaces;
    
    /// <summary>
    /// Description of GetTmxTestScenarioStatusCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetTmxTestScenarioStatusCommandTestFixture
    {
        public GetTmxTestScenarioStatusCommandTestFixture()
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
        [Description("Get-TmxTestScenarioStatus")]
        [Category("Fast")]
        public void GetTestScenario_Current_New()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [Test]
        [Description("New-TmxTestScenario -Name Scenario1; Get-TmxTestScenarioStatus")]
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
        [Description("New-TmxTestScenario -Name Scenario1; Close-TmxTestResult -TestResultName result -TestPassed; Get-TmxTestScenarioStatus")]
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
        [Description("New-TmxTestScenario -Name Scenario1; Close-TmxTestResult -TestResultName result -TestPassed:$false; Get-TmxTestScenarioStatus")]
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
        [Description("New-TmxTestScenario -Name Scenario1; Close-TmxTestResult -TestResultName result -TestPassed -KnownIssue; Get-TmxTestScenarioStatus")]
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
        [Description("New-TmxTestScenario -Name Scenario1; Close-TmxTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TmxTestScenarioStatus")]
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
