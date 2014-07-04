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
    using MbUnit.Framework;using NUnit.Framework;
    using PSTestLib;
    using TMX;
    using TMX.Interfaces;
    
    /// <summary>
    /// Description of GetTmxTestSuiteStatusCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class GetTmxTestSuiteStatusCommandTestFixture
    {
        public GetTmxTestSuiteStatusCommandTestFixture()
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
        [MbUnit.Framework.Description("Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_New()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_WithNotTested()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;

            UnitTestingHelper.GetNewTestSuite("name", "id", "description");
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_WithPassed()
        {
            string expectedResult = TMX.TestData.TestStatePassed;

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_WithFailed()
        {
            string expectedResult = TMX.TestData.TestStateFailed;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed -KnownIssue; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_WithPassedKnownIssue()
        {
            // Passed -> KnownIssue
            string expectedResult = TMX.TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, true);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_WithFailedKnownIssue()
        {
            // KnownIssue supersedes the Failed status.
            
            string expectedResult = TMX.TestData.TestStateKnownIssue;
            
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, true);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
    }
}
