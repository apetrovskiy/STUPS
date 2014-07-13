/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/25/2013
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    using PSTestLib;
    using TMX;
    using TMX.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of SetTmxCurrentTestResultCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class SetTmxCurrentTestResultCommandTestFixture
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
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus()
        {
            // 20130331
            //string expectedStatus = TMX.TestData.TestStateFailed;
            const string expectedStatus = TestData.TestStateNotTested;
            const string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);

            MbUnit.Framework.Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name()
        {
            const string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);

            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                TestData.CurrentTestResult.Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName ''")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_Empty()
        {
            UnitTestingHelper.SetTestResult(string.Empty, null);

            MbUnit.Framework.Assert.AreEqual(
                // 20130918
                //"this test result was preset", // this is a bug // ?
                "this test result is not provided with name",
                TestData.CurrentTestResult.Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultId id")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Id()
        {
            const string expectedId = "test result id";

            UnitTestingHelper.SetTestResult(null, expectedId);

            MbUnit.Framework.Assert.AreEqual(
                expectedId,
                TestData.CurrentTestResult.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultId ''")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Id_Empty()
        {
            UnitTestingHelper.SetTestResult(null, string.Empty);

            MbUnit.Framework.Assert.AreEqual(
                // 20130606
                // now Ids are always generated
                //null,
                "1", 
                TestData.CurrentTestResult.Id);
        }
        
        // ==============================================================================================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName r -TestPassed:$true; Set-TmxCurrentTestResult -TestResultName result; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_after_a_closed_result_1()
        {
            // 20130331
            //string expectedStatus = TMX.TestData.TestStateFailed;
            const string expectedStatus = TMX.TestData.TestStateNotTested;
            const string expectedName = "test result name";

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);
            UnitTestingHelper.SetTestResult(expectedName, null);

            MbUnit.Framework.Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName r -TestPassed:$false; Set-TmxCurrentTestResult -TestResultName result; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_after_a_closed_result_2()
        {
            // 20130331
            //string expectedStatus = TMX.TestData.TestStateFailed;
            const string expectedStatus = TMX.TestData.TestStateNotTested;
            const string expectedName = "test result name";

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
            UnitTestingHelper.SetTestResult(expectedName, null);

            MbUnit.Framework.Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName r -TestPassed:$true; Set-TmxCurrentTestResult -TestResultName result")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_after_a_closed_result()
        {
            const string expectedName = "test result name";

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);
            UnitTestingHelper.SetTestResult(expectedName, null);

            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                TestData.CurrentTestResult.Name);
        }
        
        // ==============================================================================================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Close-TmxTestResult -TestPassed:$true; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_Checking_before_closing()
        {
            //string expectedStatus = TMX.TestData.TestStateFailed;
            const string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Close-TmxTestResult -TestPassed:$true; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_before_closing_1()
        {
            const string expectedStatus = TMX.TestData.TestStatePassed;
            const string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            MbUnit.Framework.Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Close-TmxTestResult -TestPassed:$false; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_before_closing_2()
        {
            const string expectedStatus = TMX.TestData.TestStateFailed;
            const string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);

            MbUnit.Framework.Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        // ==============================================================================================================================
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Set-TmxCurrentTestResult -TestResultName result2; Get-TmxTestSuiteStatus")]
        [MbUnit.Framework.Category("Fast")]
        public void SetCurrentTestResult_Name_Checking_before_setting_next_result()
        {
            //string expectedStatus = TMX.TestData.TestStateFailed;
            const string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);
            UnitTestingHelper.SetTestResult("test result name 2", null);

            MbUnit.Framework.Assert.AreEqual(
                expectedName,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Name);
        }
    }
}
