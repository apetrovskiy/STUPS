/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/2/2012
 * Time: 11:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ExampleCustomTestReport
{
    using System.Management.Automation;
    using Tmx;
    // using Tmx.Core;

    /// <summary>
    /// Description of Export_TestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TestResults")]
    public class ExportTestResultsCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            
            // enumerate test suites
            foreach (var testSuite in TestData.TestSuites) {
                
                // add a test suite to your report
                
                
                // enumerate test scenarios
                foreach (var testScenario in testSuite.TestScenarios) {
                    
                    // add a test scenario to your report
                    
                    
                    // enumerate test results
                    foreach (var testResult in testScenario.TestResults) {
                        
                        // add a test result to your report
                        
                        
                        // enumerate test result details
                        foreach (var testResultDetail in testResult.Details) {
                            
                            // add each test result detail to your report
                            
                            
                        }
                    }
                }
            }
        }
    }
}
