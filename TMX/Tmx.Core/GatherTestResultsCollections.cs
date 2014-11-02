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
        
        public void GatherCollections(ISearchCmdletBaseDataObject cmdlet)
        {
            IOrderedEnumerable<ITestSuite> suites = TmxHelper.SearchForSuites(cmdlet);
            TestSuites = suites;
            
            IOrderedEnumerable<ITestScenario> scenarios = TmxHelper.SearchForScenarios(cmdlet);
            TestScenarios = scenarios;
            
            IOrderedEnumerable<ITestResult> testResults = TmxHelper.SearchForTestResults(cmdlet);
            TestResults = testResults;
        }
        
        // 20141102
        public void GatherCollections(ISearchCmdletBaseDataObject searchCriteria, List<ITestSuite> suitesForSearch)
        {
            var testResultsSearcher = new TestResultsSearcher();
            
            IOrderedEnumerable<ITestSuite> suites = testResultsSearcher.SearchForSuites(searchCriteria, suitesForSearch);
            TestSuites = suites;
            
            IOrderedEnumerable<ITestScenario> scenarios = testResultsSearcher.SearchForScenarios(searchCriteria, suitesForSearch);
            TestScenarios = scenarios;
            
            IOrderedEnumerable<ITestResult> testResults = testResultsSearcher.SearchForTestResults(searchCriteria, suitesForSearch);
            TestResults = testResults;
        }
    }
}
