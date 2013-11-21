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
            this.CheckCmdletParameters();
            
            SearchCmdletBase cmdlet = 
                new SearchCmdletBase();
            cmdlet.FilterAll = true;

            IOrderedEnumerable<TestSuite> suites =
                TmxHelper.SearchForSuites(cmdlet);
            
cmdlet.FilterNone = true;

            IOrderedEnumerable<TestScenario> scenarios = 
                TmxHelper.SearchForScenarios(cmdlet);

            //cmdlet.FilterAll = false;
            //cmdlet.FilterPassedWithBadSmell = true;
//            cmdlet.FilterNone = true;
            
            
            IOrderedEnumerable<TestResult> testResults = 
                TmxHelper.SearchForTestResults(cmdlet);
            
            XElement suitesElement = 
                TmxHelper.CreateSuitesXElementWithParameters(
                    suites,
                    scenarios,
                    testResults,
                    (new XMLElementsNativeStruct(null)));
            
            this.WriteObject(this, suitesElement);

        }
    }
}
