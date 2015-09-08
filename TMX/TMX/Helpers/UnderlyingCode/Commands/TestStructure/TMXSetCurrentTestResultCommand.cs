/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/25/2013
 * Time: 1:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Linq;
    using Interfaces;
    using Commands;
    
    /// <summary>
    /// Description of TmxSetCurrentTestResultCommand.
    /// </summary>
    class TmxSetCurrentTestResultCommand : TmxCommand
    {
        internal TmxSetCurrentTestResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (SetTmxCurrentTestResultCommand)Cmdlet;
            
            cmdlet.ConvertTestResultStatusToTraditionalTestResult();
                
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking the current test structure, creating the first test suite and scenario if needed");
            TestData.InitCurrentTestScenario();
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking whether the current test result is fulfilled and must be added to the current test scenario's results");

            if (null != TestData.CurrentTestResult) {

                cmdlet.WriteVerbose(
                    cmdlet,
                    "The current test result is not null");

                if (!string.IsNullOrEmpty(TestData.CurrentTestResult.Name) ||
                    (0 < TestData.CurrentTestResult.Details.Count)) {
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "Adding the current test result to the current test scenario's results");
                    
                    TestData.CurrentTestResult.SetTimeSpent(
                        //(TestData.CurrentTestResult.Timestamp - TmxHelper.TestCaseStarted).TotalSeconds);
                        //(System.DateTime.Now - TmxHelper.TestCaseStarted).TotalSeconds);
                        (DateTime.Now - TestData.CurrentTestResult.Timestamp).TotalSeconds);
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "Finishing test result Id = '" +
                        TestData.CurrentTestResult.Id + 
                        "' Name = '" + 
                        TestData.CurrentTestResult.Name +
                        "' Status = '" +
                        TestData.CurrentTestResult.Status +
                        "' TimeSpent = " +
                        TestData.CurrentTestResult.TimeSpent.ToString() +
                        " seconds");
                    
                    TmxHelper.TestCaseStarted =
                        DateTime.Now;
                    TestData.CurrentTestScenario.TestResults.Add(new TestResult(TestData.CurrentTestScenario.Id, TestData.CurrentTestSuite.Id));
                    TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1] = 
                        TestData.CurrentTestResult;

                } else {
                    
                    // nothing to do
                }
                
            } else {
                
                // nothing to do
            }
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Creating the current test result for putting new data into it");
            
            TestData.CurrentTestResult =
                new TestResult(
                    TestData.CurrentTestScenario.Id,
                    TestData.CurrentTestSuite.Id);
            
            if (string.IsNullOrEmpty(TestData.CurrentTestResult.Id)) {
                
                if (!string.IsNullOrEmpty(cmdlet.Id)) {
                    TestData.CurrentTestResult.Id = cmdlet.Id;
                } else {
                    cmdlet.WriteVerbose(cmdlet, "generating new test result Id for test result '" + TestData.CurrentTestResult.Name + "'");
                    TestData.CurrentTestResult.Id = TestData.GetTestResultId();
                }
            }
            
            try {
                // 20141119
                // TestData.CurrentTestResult.PlatformId =
                TestData.CurrentTestResult.PlatformUniqueId =
                    // 20141114
                    // TestData.CurrentTestPlatform.Id;
                    TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == TestData.CurrentTestPlatform.Id).UniqueId;
            }
            catch {}

            cmdlet.WriteVerbose(
                cmdlet,
                "Writing data to the current test result");
            
            // 20140720
            // TmxHelper.SetCurrentTestResult(cmdlet);
            TmxHelper.SetCurrentTestResult(
                new TestResultCmdletBaseDataObject {
                    TestResultName = cmdlet.TestResultName,
                    Id = cmdlet.Id,
                    Description = cmdlet.Description,
                    KnownIssue = cmdlet.KnownIssue,
                    TestOrigin = cmdlet.TestOrigin
                });
            
            TestData.SetScenarioStatus(true); // skipAutomatic
            TestData.SetSuiteStatus(true); // skipAutomatic
            try {
                TestData.OnTmxNewTestResultClosed(
                    TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1],
                    null);
            }
            catch {}
        }
    }
}
