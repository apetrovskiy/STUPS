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
    using TMX.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of GetTmxTestSuiteStatusCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class GetTmxTestSuiteStatusCommandTestFixture
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
        [MbUnit.Framework.Description("Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_New()
        {
            const string expectedResult = TestData.TestStateNotTested;
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_WithNotTested()
        {
            const string expectedResult = TestData.TestStateNotTested;

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
            const string expectedResult = TestData.TestStatePassed;

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);
Console.WriteLine("suite -> " + TestData.CurrentTestSuite.Status);
Console.WriteLine("scenario -> " + TestData.CurrentTestScenario.Status);
Console.WriteLine("test result -> " + TestData.CurrentTestResult.Status);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestSuite_Current_WithFailed()
        {
            const string expectedResult = TestData.TestStateFailed;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
Console.WriteLine("suite -> " + TestData.CurrentTestSuite.Status);
Console.WriteLine("scenario -> " + TestData.CurrentTestScenario.Status);
Console.WriteLine("test result -> " + TestData.CurrentTestResult.Status);
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
            const string expectedResult = TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, true);
Console.WriteLine("suite -> " + TestData.CurrentTestSuite.Status);
Console.WriteLine("scenario -> " + TestData.CurrentTestScenario.Status);
Console.WriteLine("test result -> " + TestData.CurrentTestResult.Status);
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
            
            const string expectedResult = TestData.TestStateKnownIssue;
            
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, true);
Console.WriteLine("suite -> " + TestData.CurrentTestSuite.Status);
Console.WriteLine("scenario -> " + TestData.CurrentTestScenario.Status);
Console.WriteLine("test result -> " + TestData.CurrentTestResult.Status);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus(true));
        }
    }
}
