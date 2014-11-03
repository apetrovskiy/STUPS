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
	using Tmx.Interfaces;
	using Tmx.Interfaces.TestStructure;
    using Tmx.Core;
    
    /// <summary>
    /// Description of GatherTestResultsCollections.
    /// </summary>
    public class GatherTestResultsCollections
    {
        public IOrderedEnumerable<ITestSuite> TestSuites { get; set; }
        public IOrderedEnumerable<ITestScenario> TestScenarios { get; set; }
        public IOrderedEnumerable<ITestResult> TestResults { get; set; }
        
        [Obsolete]
        public void GatherCollections(ISearchCmdletBaseDataObject searchCriteria)
        {
            // IOrderedEnumerable<ITestSuite> suites = TmxHelper.SearchForSuites(searchCriteria);
            // TestSuites = suites;
            TestSuites = TmxHelper.SearchForSuites(searchCriteria);
            
            // IOrderedEnumerable<ITestScenario> scenarios = TmxHelper.SearchForScenarios(searchCriteria);
            // TestScenarios = scenarios;
            TestScenarios = TmxHelper.SearchForScenarios(searchCriteria);
            
            // IOrderedEnumerable<ITestResult> testResults = TmxHelper.SearchForTestResults(searchCriteria);
            // TestResults = testResults;
            TestResults = TmxHelper.SearchForTestResults(searchCriteria);
        }
        
        public void GatherCollections(ISearchCmdletBaseDataObject searchCriteria, List<ITestSuite> suitesForSearch)
        {
            var testResultsSearcher = new TestResultsSearcher();
            
            // IOrderedEnumerable<ITestSuite> suites = testResultsSearcher.SearchForSuites(searchCriteria, suitesForSearch);
            // TestSuites = suites;
            TestSuites = testResultsSearcher.SearchForSuites(searchCriteria, suitesForSearch);
            
            // IOrderedEnumerable<ITestScenario> scenarios = testResultsSearcher.SearchForScenarios(searchCriteria, suitesForSearch);
            // TestScenarios = scenarios;
            TestScenarios = testResultsSearcher.SearchForScenarios(searchCriteria, suitesForSearch);
            
            // IOrderedEnumerable<ITestResult> testResults = testResultsSearcher.SearchForTestResults(searchCriteria, suitesForSearch);
            // TestResults = testResults;
            TestResults = testResultsSearcher.SearchForTestResults(searchCriteria, suitesForSearch);
        }
    }
}
