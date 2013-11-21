/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/30/2013
 * Time: 6:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using TMX.Commands;
    
	/// <summary>
	/// Description of TmxAddSimpleTestResultCommand.
	/// </summary>
    internal class TmxAddSimpleTestResultCommand : TmxCommand
    {
        internal TmxAddSimpleTestResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
           
            AddTmxSimpleTestResultCommand cmdlet =
                (AddTmxSimpleTestResultCommand)this.Cmdlet;
            
            // 20130330
            cmdlet.ConvertTestResultStatusToTraditionalTestResult();
                
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking the current test structure, creating the first test suite and scenario if needed");
            TestData.InitCurrentTestScenario();
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking whether the current test result is fulfilled and must be added to the current test scenario's results");
            
            // 20130605
            // inserting the new simple test result to the suite/scenario the user provided
            TestSuite testSuiteToAddTestResult = null;
            TestScenario testScenarioToAddTestResult = null;
            if (null != cmdlet.TestSuiteName || null != cmdlet.TestSuiteId) {
                
                cmdlet.WriteVerbose(cmdlet, "getting test suite '" + cmdlet.TestSuiteName + "' with Id '" + cmdlet.TestSuiteId + "'");
                testSuiteToAddTestResult =
                    TestData.GetTestSuite(cmdlet.TestSuiteName, cmdlet.TestSuiteId, cmdlet.TestPlatformId);
                if (null == testSuiteToAddTestResult) {
                    
                    cmdlet.WriteVerbose(cmdlet, "getting the current test suite");
                    testSuiteToAddTestResult = TestData.CurrentTestSuite;
                }
            } else {
                
                cmdlet.WriteVerbose(cmdlet, "getting the current test suite");
                testSuiteToAddTestResult = TestData.CurrentTestSuite;
            }
            
            if (null != cmdlet.TestScenarioName || null != cmdlet.TestScenarioId) {
                
                testScenarioToAddTestResult =
                    TestData.GetTestScenario(testSuiteToAddTestResult, cmdlet.TestScenarioName, cmdlet.TestScenarioId, cmdlet.TestSuiteName, cmdlet.TestSuiteId, cmdlet.TestPlatformId) ??
                    TestData.CurrentTestScenario;

                /*
                testScenarioToAddTestResult =
                    TestData.GetTestScenario(testSuiteToAddTestResult, cmdlet.TestScenarioName, cmdlet.TestScenarioId, cmdlet.TestSuiteName, cmdlet.TestSuiteId, cmdlet.TestPlatformId);
                if (null == testScenarioToAddTestResult) {
                    testScenarioToAddTestResult = TestData.CurrentTestScenario;
                }
                */
            } else {
                testScenarioToAddTestResult = TestData.CurrentTestScenario;
            }

            //int newTestResultIndex = TestData.CurrentTestScenario.TestResults.Count - 1;
            int newTestResultIndex = testScenarioToAddTestResult.TestResults.Count - 1;
            
            //if (null != TestData.CurrentTestScenario.TestResults &&
            //    0 < TestData.CurrentTestScenario.TestResults.Count) {
            if (null != testScenarioToAddTestResult.TestResults &&
                0 < testScenarioToAddTestResult.TestResults.Count) {
                
                //TestData.CurrentTestScenario.TestResults.Insert(
                //    newTestResultIndex,
                //    new TestResult(
                //        TestData.CurrentTestScenario.Id,
                //        TestData.CurrentTestSuite.Id));
                
                testScenarioToAddTestResult.TestResults.Insert(
                    newTestResultIndex,
                    new TestResult(
                        // 20130627
                        testScenarioToAddTestResult.Id,
                        testSuiteToAddTestResult.Id));
                        //testScenarioToAddTestResult.Id));
                
                // 20130429
                TMX.Logger.TmxLogger.Info("Test result: '" + cmdlet.TestResultName + "'\t" + cmdlet.TestResultStatus.ToString());
                
            //} else {
            
            }
            
            if (null != cmdlet.TestResultName) {
                TestData.CurrentTestScenario.TestResults[newTestResultIndex].Name = cmdlet.TestResultName;
            }
            
            if (null != cmdlet.Id) {
                TestData.CurrentTestScenario.TestResults[newTestResultIndex].Id = cmdlet.Id;
            }
            
            if (null != cmdlet.Description) {
                TestData.CurrentTestScenario.TestResults[newTestResultIndex].Description = cmdlet.Description;
            }
            
            if (null != cmdlet.TestResultStatus) {
                TestData.CurrentTestScenario.TestResults[newTestResultIndex].enStatus = cmdlet.TestResultStatus;
            }
            
            // 20130605
            try {
                TestData.CurrentTestScenario.TestResults[newTestResultIndex].PlatformId =
                    TestData.CurrentTestPlatform.Id;
            }
            catch {}
            
            // 20130627
            //TestData.CurrentTestScenario.TestResults[newTestResultIndex].SetOrigin(TestResultOrigins.Logical);
            TestData.CurrentTestScenario.TestResults[newTestResultIndex].SetOrigin(cmdlet.TestOrigin);
            
//            if (null != TestData.CurrentTestResult) {
//
//                cmdlet.WriteVerbose(
//                    cmdlet,
//                    "The current test result is not null");
//
//                if ((null != TestData.CurrentTestResult.Name &&
//                     string.Empty != TestData.CurrentTestResult.Name) ||
//                    (0 < TestData.CurrentTestResult.Details.Count)) {
//                    
//                    cmdlet.WriteVerbose(
//                        cmdlet,
//                        "Adding the current test result to the current test scenario's results");
//                    
//
//                    // 20130326
//
//                    TmxHelper.TestCaseStarted =
//                        System.DateTime.Now;
//                    TestData.CurrentTestScenario.TestResults.Add(new TestResult(TestData.CurrentTestScenario.Id, TestData.CurrentTestSuite.Id));
//                    TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] = 
//                        TestData.CurrentTestResult;
//
//                } else {
//                    
//                    // nothing to do
//                }
//                
//                
//                
//            } else {
//                
//                // nothing to do
//            }
//            
//            cmdlet.WriteVerbose(
//                cmdlet,
//                "Creating the current test result for putting new data into it");
//            
//            TestData.CurrentTestResult =
//                new TestResult(
//                    TestData.CurrentTestScenario.Id,
//                    TestData.CurrentTestSuite.Id);
//
//            cmdlet.WriteVerbose(
//                cmdlet,
//                "Writing data to the current test result");
//
//            TmxHelper.SetCurrentTestResult(cmdlet);
            
            // 20130327
            //if (null != cmdlet.Banner && string.Empty != cmdlet.Banner && 0 < cmdlet.Banner.Length) {
                //UIAutomation.UiaHelper.ShowBanner(cmdlet.TestResultName);
                //TmxHelper.BannerForm
            //}
        }
    }
}
