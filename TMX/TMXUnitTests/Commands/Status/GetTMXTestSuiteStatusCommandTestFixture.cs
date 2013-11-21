/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests.Commands.Status
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of GetTmxTestSuiteStatusCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetTmxTestSuiteStatusCommandTestFixture
    {
        public GetTmxTestSuiteStatusCommandTestFixture()
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
        [Description("Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_New()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithNotTested()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;

            UnitTestingHelper.GetNewTestSuite("name", "id", "description");
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithPassed()
        {
            string expectedResult = TMX.TestData.TestStatePassed;

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithFailed()
        {
            string expectedResult = TMX.TestData.TestStateFailed;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed -KnownIssue; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithPassedKnownIssue()
        {
            // Passed -> KnownIssue
            string expectedResult = TMX.TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, true);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithFailedKnownIssue()
        {
            // KnownIssue supersedes the Failed status.
            
            string expectedResult = TMX.TestData.TestStateKnownIssue;
            
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, true);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
    }
}
