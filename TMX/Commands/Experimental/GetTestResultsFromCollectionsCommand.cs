/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2012
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GetTestResultsFromCollectionsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TestResultsFromCollections")]
    internal class GetTestResultsFromCollectionsCommand : CommonCmdletBase
    {
        public GetTestResultsFromCollectionsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckParameters();
            
            // enumerate test suites
            foreach (ITestSuite testSuite in TestData.TestSuites) {
                
                // add a test suite to your report
                this.WriteObject(this, testSuite);
                
                // enumerate test scenarios
                foreach (ITestScenario testScenario in testSuite.TestScenarios) {
                    
                    // add a test scenario to your report
                    this.WriteObject(this, testScenario);
                    
                    // enumerate test results
                    foreach (ITestResult testResult in testScenario.TestResults) {
                        
                        // add a test result to your report
                        this.WriteObject(this, testResult);
                        
                        // enumerate test result details
                        foreach (ITestResultDetail testResultDetail in testResult.Details) {
                            
                            // add each test result detail to your report
                            this.WriteObject(this, testResultDetail);
                            
                        }
                    }
                }
            }
        }
    }
}
