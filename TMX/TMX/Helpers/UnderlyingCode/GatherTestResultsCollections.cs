/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2012
 * Time: 5:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Reflection;
    
    /// <summary>
    /// Description of GatherTestResultsCollections.
    /// </summary>
    public class GatherTestResultsCollections
    {
        public GatherTestResultsCollections()
        {
        }
        
        public IOrderedEnumerable<TestSuite> TestSuites { get; set; }
        public IOrderedEnumerable<TestScenario> TestScenarios { get; set; }
        public IOrderedEnumerable<TestResult> TestResults { get; set; }
        
        public void GatherCollections(SearchCmdletBase cmdlet)
        {
            cmdlet.WriteVerbose(cmdlet, "getting test suites");
            IOrderedEnumerable<TestSuite> suites =
                TmxHelper.SearchForSuites(cmdlet);
            this.TestSuites = suites;

            cmdlet.WriteVerbose(cmdlet, "getting test scenarios");
            IOrderedEnumerable<TestScenario> scenarios = 
                TmxHelper.SearchForScenarios(cmdlet);
            this.TestScenarios = scenarios;

            cmdlet.WriteVerbose(cmdlet, "getting test results");
            IOrderedEnumerable<TestResult> testResults = 
                TmxHelper.SearchForTestResults(cmdlet);
            this.TestResults = testResults;
        }
    }
}
