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
	/// Description of TMXAddSimpleTestResultCommand.
	/// </summary>
    internal class TMXAddSimpleTestResultCommand : TMXCommand
    {
        internal TMXAddSimpleTestResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            // 20130327
            //TestResultCmdletBase cmdlet =
            //    (TestResultCmdletBase)this.Cmdlet;
            
            AddTMXSimpleTestResultCommand cmdlet =
                (AddTMXSimpleTestResultCommand)this.Cmdlet;
            
            // 20130330
            cmdlet.ConvertTestResultStatusToTraditionalTestResult();
                
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking the current test structure, creating the first test suite and scenario if needed");
            TestData.InitCurrentTestScenario();
            
            cmdlet.WriteVerbose(
                cmdlet,
                "Checking whether the current test result is fulfilled and must be added to the current test scenario' results");

            if (null != TestData.CurrentTestResult) {

                cmdlet.WriteVerbose(
                    cmdlet,
                    "The current test result is not null");

                if ((null != TestData.CurrentTestResult.Name &&
                     string.Empty != TestData.CurrentTestResult.Name) ||
                    (0 < TestData.CurrentTestResult.Details.Count)) {
                    
                    cmdlet.WriteVerbose(
                        cmdlet,
                        "Adding the current test result to the current test scenario' results");
                    

                    // 20130326

                    TMXHelper.TestCaseStarted =
                        System.DateTime.Now;
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

            cmdlet.WriteVerbose(
                cmdlet,
                "Writing data to the current test result");

            TMXHelper.SetCurrentTestResult(cmdlet);
            
            // 20130327
            //if (null != cmdlet.Banner && string.Empty != cmdlet.Banner && 0 < cmdlet.Banner.Length) {
                //UIAutomation.UIAHelper.ShowBanner(cmdlet.TestResultName);
                //TMXHelper.BannerForm
            //}
        }
    }
}
