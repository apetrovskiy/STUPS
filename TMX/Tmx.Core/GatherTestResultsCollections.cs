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
    using Interfaces;
    using Interfaces.TestStructure;
    using Core;
    using Core.Proxy;

    /// <summary>
    /// Description of GatherTestResultsCollections.
    /// </summary>
    public class GatherTestResultsCollections
    {
        public virtual IOrderedEnumerable<ITestSuite> TestSuites { get; set; }
        public virtual IOrderedEnumerable<ITestScenario> TestScenarios { get; set; }
        public virtual IOrderedEnumerable<ITestResult> TestResults { get; set; }
        
        [Obsolete]
        public virtual void GatherCollections(ISearchCmdletBaseDataObject searchCriteria)
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
        
        public virtual void GatherCollections(ISearchCmdletBaseDataObject searchCriteria, List<ITestSuite> suitesForSearch)
        {
            // 20150925
            // var testResultsSearcher = new TestResultsSearcher();
            var testResultsSearcher = ProxyFactory.Get<TestResultsSearcher>();
            TestSuites = testResultsSearcher.SearchForSuites(searchCriteria, suitesForSearch);
            TestScenarios = testResultsSearcher.SearchForScenarios(searchCriteria, suitesForSearch);
            TestResults = testResultsSearcher.SearchForTestResults(searchCriteria, suitesForSearch);
        }
    }
}
