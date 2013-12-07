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
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of SetTmxCurrentTestResultCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class SetTmxCurrentTestResultCommandTestFixture
    {
        public SetTmxCurrentTestResultCommandTestFixture()
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
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus()
        {
            // 20130331
            //string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedStatus = TMX.TestData.TestStateNotTested;
            string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);

            Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name()
        {
            string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);

            Assert.AreEqual(
                expectedName,
                TestData.CurrentTestResult.Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName ''")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_Empty()
        {
            UnitTestingHelper.SetTestResult(string.Empty, null);

            Assert.AreEqual(
                // 20130918
                //"this test result was preset", // this is a bug // ?
                "this test result is not provided with name",
                TestData.CurrentTestResult.Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultId id")]
        [Category("Fast")]
        public void SetCurrentTestResult_Id()
        {
            string expectedId = "test result id";

            UnitTestingHelper.SetTestResult(null, expectedId);

            Assert.AreEqual(
                expectedId,
                TestData.CurrentTestResult.Id);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultId ''")]
        [Category("Fast")]
        public void SetCurrentTestResult_Id_Empty()
        {
            UnitTestingHelper.SetTestResult(null, string.Empty);

            Assert.AreEqual(
                // 20130606
                // now Ids are always generated
                //null,
                "1", 
                TestData.CurrentTestResult.Id);
        }
        
        // ==============================================================================================================================
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName r -TestPassed:$true; Set-TmxCurrentTestResult -TestResultName result; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_after_a_closed_result_1()
        {
            // 20130331
            //string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedStatus = TMX.TestData.TestStateNotTested;
            string expectedName = "test result name";

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);
            UnitTestingHelper.SetTestResult(expectedName, null);

            Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName r -TestPassed:$false; Set-TmxCurrentTestResult -TestResultName result; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_after_a_closed_result_2()
        {
            // 20130331
            //string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedStatus = TMX.TestData.TestStateNotTested;
            string expectedName = "test result name";

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
            UnitTestingHelper.SetTestResult(expectedName, null);

            Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Close-TmxTestResult -TestResultName r -TestPassed:$true; Set-TmxCurrentTestResult -TestResultName result")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_after_a_closed_result()
        {
            string expectedName = "test result name";

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);
            UnitTestingHelper.SetTestResult(expectedName, null);

            Assert.AreEqual(
                expectedName,
                TestData.CurrentTestResult.Name);
        }
        
        // ==============================================================================================================================
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Close-TmxTestResult -TestPassed:$true; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_Checking_before_closing()
        {
            //string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            Assert.AreEqual(
                expectedName,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Name);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Close-TmxTestResult -TestPassed:$true; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_before_closing_1()
        {
            string expectedStatus = TMX.TestData.TestStatePassed;
            string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Close-TmxTestResult -TestPassed:$false; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_before_closing_2()
        {
            string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);

            Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 2].Status);
        }
        // ==============================================================================================================================
        [Test]
        [Description("New-TmxTestSuite -Name suite1; Set-TmxCurrentTestResult -TestResultName result; Set-TmxCurrentTestResult -TestResultName result2; Get-TmxTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_Checking_before_setting_next_result()
        {
            //string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);
            UnitTestingHelper.SetTestResult("test result name 2", null);

            Assert.AreEqual(
                expectedName,
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1].Name);
        }
    }
}
