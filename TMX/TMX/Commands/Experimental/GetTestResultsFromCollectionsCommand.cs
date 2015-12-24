/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2012
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    using Tmx;

    /// <summary>
    /// Description of GetTestResultsFromCollectionsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TestResultsFromCollections")]
    internal class GetTestResultsFromCollectionsCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            // enumerate test suites
            foreach (var testSuite in TestData.TestSuites) {
                
                // add a test suite to your report
                WriteObject(this, testSuite);
                
                // enumerate test scenarios
                foreach (var testScenario in testSuite.TestScenarios) {
                    
                    // add a test scenario to your report
                    WriteObject(this, testScenario);
                    
                    // enumerate test results
                    foreach (var testResult in testScenario.TestResults) {
                        
                        // add a test result to your report
                        WriteObject(this, testResult);
                        
                        // enumerate test result details
                        foreach (var testResultDetail in testResult.Details) {
                            
                            // add each test result detail to your report
                            WriteObject(this, testResultDetail);
                            
                        }
                    }
                }
            }
        }
    }
}
