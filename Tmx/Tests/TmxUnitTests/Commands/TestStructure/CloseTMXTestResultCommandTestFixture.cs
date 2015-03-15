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
    using MbUnit.Framework;using NUnit.Framework;
    using PSTestLib;
    using Tmx;
    // using Tmx.Core;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of CloseTmxTestResultCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class CloseTmxTestResultCommandTestFixture
    {
        public CloseTmxTestResultCommandTestFixture()
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
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void CloseTestResult_Current_WithPassed()
        {
            const string expectedResult = TestData.TestStatePassed;

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void CloseTestResult_Current_WithFailed()
        {
            const string expectedResult = TestData.TestStateFailed;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);

            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed -KnownIssue; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void CloseTestResult_Current_WithPassedKnownIssue()
        {
            const string expectedResult = TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, true);

            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void CloseTestResult_Current_WithFailedKnownIssue()
        {
            const string expectedResult = TestData.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, true);
            MbUnit.Framework.Assert.AreEqual(
                expectedResult,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Fast")]
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        public void Need_Code()
        {
            
        }
    }
}
