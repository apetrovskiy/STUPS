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
    using System.Linq;
    using System.Xml.Linq;
    
    /// <summary>
    /// Description of GetTestResultsFromSearchCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TestResultsFromSearch")]
    internal class GetTestResultsFromSearchCommand : CommonCmdletBase
    {
        public GetTestResultsFromSearchCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckParameters();
            
            SearchCmdletBase cmdlet = 
                new SearchCmdletBase();
            cmdlet.FilterAll = true;

            IOrderedEnumerable<TestSuite> suites =
                TMXHelper.SearchForSuites(cmdlet);
            
cmdlet.FilterNone = true;

            IOrderedEnumerable<TestScenario> scenarios = 
                TMXHelper.SearchForScenarios(cmdlet);

            //cmdlet.FilterAll = false;
            //cmdlet.FilterPassedWithBadSmell = true;
//            cmdlet.FilterNone = true;
            
            
            IOrderedEnumerable<TestResult> testResults = 
                TMXHelper.SearchForTestResults(cmdlet);
            
            
            //try {
                //testResults = null;
            //testResults = testResults.Where 1 == 2;
                //= new System.Linq.Expressions.ConditionalExpression
//            }
//            catch (Exception eNull) {
//                Console.WriteLine(eNull.Message);
//            }
            
            
            XElement suitesElement = 
                TMXHelper.CreateSuitesXElementWithParameters(
                    suites,
                    scenarios,
                    testResults,
                    (new XMLElementsNativeStruct(null)));
                //TMXHelper.CreateSuitesXElementNative(suites, scenarios, testResults);
            
#region commented
//                new XElement("suites",
//                             from suite in suites
//                             select new XElement("suite",
//                                                 new XAttribute("id", suite.Id),
//                                                 new XAttribute("name", suite.Name),
//                                                 new XAttribute("status", suite.Status),
//                                                 new XAttribute("timeSpent", Convert.ToInt32(suite.Statistics.TimeSpent)),
//                                                 new XAttribute("all", suite.Statistics.All.ToString()),
//                                                 new XAttribute("passed", suite.Statistics.Passed.ToString()),
//                                                 new XAttribute("failed", suite.Statistics.Failed.ToString()),
//                                                 new XAttribute("notTested", suite.Statistics.NotTested.ToString()),
//                                                 new XAttribute("knownIssue", suite.Statistics.PassedButWithBadSmell.ToString()),
//                                                 TMXHelper.CreateXAttribute("description", suite.Description),
//                                                 new XElement("scenarios",
//                                                              from scenario in scenarios
//                                                              where scenario.SuiteId == suite.Id
//                                                              select new XElement("scenario",
//                                                                                  new XAttribute("id", scenario.Id),
//                                                                                  new XAttribute("name", scenario.Name),
//                                                                                  new XAttribute("status", scenario.Status),
//                                                                                  new XAttribute("timeSpent", Convert.ToInt32(suite.Statistics.TimeSpent)),
//                                                                                  new XAttribute("all", scenario.Statistics.All.ToString()),
//                                                                                  new XAttribute("passed", scenario.Statistics.Passed.ToString()),
//                                                                                  new XAttribute("failed", scenario.Statistics.Failed.ToString()),
//                                                                                  new XAttribute("notTested", scenario.Statistics.NotTested.ToString()),
//                                                                                  new XAttribute("knownIssue", scenario.Statistics.PassedButWithBadSmell.ToString()),
//                                                                                  TMXHelper.CreateXAttribute("description", scenario.Description),
//                                                                                  new XElement("testResults",
//                                                                                               from testResult in testResults
//                                                                                               where testResult.SuiteId == suite.Id &&
//                                                                                               testResult.ScenarioId == scenario.Id &&
//                                                                                               testResult.Id != null &&
//                                                                                               testResult.Name != null
//                                                                                               select new XElement("testResult",
//                                                                                                                   new XAttribute("id", testResult.Id),
//                                                                                                                   new XAttribute("name", testResult.Name),
//                                                                                                                   new XAttribute("status", testResult.Status),
//                                                                                                                   new XAttribute("timeSpent", Convert.ToInt32(testResult.TimeSpent)),
//                                                                                                                   //TMXHelper.CreateXAttribute("generated", testResult.Generated.ToString()),
//                                                                                                                   new XElement("source", 
//                                                                                                                                TMXHelper.CreateXAttribute("scriptName", testResult.ScriptName),
//                                                                                                                                TMXHelper.CreateXAttribute("lineNumber", testResult.LineNumber),
//                                                                                                                                TMXHelper.CreateXAttribute("position", testResult.Position),
//                                                                                                                                TMXHelper.CreateXAttribute("code", testResult.Code)
//                                                                                                                                ),
//                                                                                                                   TMXHelper.CreateXAttribute("timestamp", testResult.Timestamp),
//                                                                                                                   new XElement("error", 
//                                                                                                                                TMXHelper.CreateXAttribute("error", testResult.Error)
//                                                                                                                                ),
//                                                                                                                   TMXHelper.CreateXAttribute("screenshot", testResult.Screenshot),
//                                                                                                                   TMXHelper.CreateXAttribute("description", testResult.Description)
//                                                                                                                  )
//                                                                                              )
//                                                                                 )
//                                                             )
//                                                 )
//                            );
#endregion commented

            this.WriteObject(this, suitesElement);

        }
    }
}
