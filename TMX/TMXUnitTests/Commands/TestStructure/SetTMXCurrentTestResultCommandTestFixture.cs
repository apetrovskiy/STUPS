/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/25/2013
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXUnitTests.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using TMX;
    
    /// <summary>
    /// Description of SetTMXCurrentTestResultCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class SetTMXCurrentTestResultCommandTestFixture
    {
        public SetTMXCurrentTestResultCommandTestFixture()
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
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultName result; Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus()
        {
            string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedName = "test result name";

            UnitTestingHelper.SetTestResult(expectedName, null);

            Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultName result")]
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
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultName ''")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_Empty()
        {
            UnitTestingHelper.SetTestResult(string.Empty, null);

            Assert.AreEqual(
                "this test result was preset",
                TestData.CurrentTestResult.Name);
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultId id")]
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
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultId ''")]
        [Category("Fast")]
        public void SetCurrentTestResult_Id_Empty()
        {
            UnitTestingHelper.SetTestResult(null, string.Empty);

            Assert.AreEqual(
                null,
                TestData.CurrentTestResult.Id);
        }
        
        // ==============================================================================================================================
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName r -TestPassed:$true; Set-TMXTestResult -TestResultName result; Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_after_a_closed_result_1()
        {
            string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedName = "test result name";

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);
            UnitTestingHelper.SetTestResult(expectedName, null);

            Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName r -TestPassed:$false; Set-TMXTestResult -TestResultName result; Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void SetCurrentTestResult_Name_CheckingStatus_after_a_closed_result_2()
        {
            string expectedStatus = TMX.TestData.TestStateFailed;
            string expectedName = "test result name";

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
            UnitTestingHelper.SetTestResult(expectedName, null);

            Assert.AreEqual(
                expectedStatus,
                TestData.CurrentTestResult.Status);
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName r -TestPassed:$true; Set-TMXTestResult -TestResultName result")]
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
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultName result; Close-TMXTestResult -TestPassed:$true; Get-TMXTestSuiteStatus")]
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
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultName result; Close-TMXTestResult -TestPassed:$true; Get-TMXTestSuiteStatus")]
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
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultName result; Close-TMXTestResult -TestPassed:$false; Get-TMXTestSuiteStatus")]
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
        [Description("New-TMXTestSuite -Name suite1; Set-TMXTestResult -TestResultName result; Set-TMXTestResult -TestResultName result2; Get-TMXTestSuiteStatus")]
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
