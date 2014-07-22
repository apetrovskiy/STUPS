/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/3/2012
 * Time: 5:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Reflection;
	using TMX.Interfaces;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of GatherTestResultsCollections.
    /// </summary>
    public class GatherTestResultsCollections
    {
        // 20140720
        // public IOrderedEnumerable<TestSuite> TestSuites { get; set; }
        // public IOrderedEnumerable<TestScenario> TestScenarios { get; set; }
        // public IOrderedEnumerable<TestResult> TestResults { get; set; }
        public IOrderedEnumerable<ITestSuite> TestSuites { get; set; }
        public IOrderedEnumerable<ITestScenario> TestScenarios { get; set; }
        public IOrderedEnumerable<ITestResult> TestResults { get; set; }
        
        // 20140720
        // public void GatherCollections(SearchCmdletBase cmdlet)
        public void GatherCollections(ISearchCmdletBaseDataObject cmdlet)
        {
//            cmdlet.WriteVerbose(cmdlet, "getting test suites");
            // 20140720
            // IOrderedEnumerable<TestSuite> suites =
            IOrderedEnumerable<ITestSuite> suites = TmxHelper.SearchForSuites(cmdlet);
            TestSuites = suites;

//            cmdlet.WriteVerbose(cmdlet, "getting test scenarios");
            // 20140720
            // IOrderedEnumerable<TestScenario> scenarios =
            IOrderedEnumerable<ITestScenario> scenarios = TmxHelper.SearchForScenarios(cmdlet);
            TestScenarios = scenarios;

//            cmdlet.WriteVerbose(cmdlet, "getting test results");
            // 20140720
            // IOrderedEnumerable<TestResult> testResults =
            IOrderedEnumerable<ITestResult> testResults = TmxHelper.SearchForTestResults(cmdlet);
            TestResults = testResults;
        }
    }
}
