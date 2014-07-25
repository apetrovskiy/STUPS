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
    using MbUnit.Framework;using NUnit.Framework;
    using PSTestLib;
	// using Tmx.Core;
    using Tmx.Interfaces.TestStructure;
    using Tmx;
    
    /// <summary>
    /// Description of GetTmxTestScenarioStatusCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class GetTmxTestScenarioStatusCommandTestFixture
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
        [MbUnit.Framework.Description("Get-TmxTestScenarioStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestScenario_Current_New()
        {
            const string expectedResult = TestData.TestStateNotTested;
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestScenario -Name Scenario1; Get-TmxTestScenarioStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestScenario_Current_WithNotTested()
        {
            const string expectedResult = TestData.TestStateNotTested;

            UnitTestingHelper.GetNewTestScenario("name", "id", "description");
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestScenario -Name Scenario1; Close-TmxTestResult -TestResultName result -TestPassed; Get-TmxTestScenarioStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestScenario_Current_WithPassed()
        {
            const string expectedResult = TestData.TestStatePassed;

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestScenario -Name Scenario1; Close-TmxTestResult -TestResultName result -TestPassed:$false; Get-TmxTestScenarioStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestScenario_Current_WithFailed()
        {
            const string expectedResult = TestData.TestStateFailed;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestScenario -Name Scenario1; Close-TmxTestResult -TestResultName result -TestPassed -KnownIssue; Get-TmxTestScenarioStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestScenario_Current_WithPassedKnownIssue()
        {
            // Passed -> KnownIssue
            const string expectedResult = TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, true);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestScenario -Name Scenario1; Close-TmxTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TmxTestScenarioStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void GetTestScenario_Current_WithFailedKnownIssue()
        {
            // KnownIssue supersedes the Failed status.
            
            const string expectedResult = TestData.TestStateKnownIssue;
            
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, true);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestScenarioStatus(true));
        }
    }
}
