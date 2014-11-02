/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/2/2014
 * Time: 12:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsSearcher.
    /// </summary>
    public class TestResultsSearcher
    {
        #region Search
        /// <summary>
        /// Performs parametrized search for Test Suites.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public IOrderedEnumerable<ITestSuite> SearchForSuites(ISearchCmdletBaseDataObject cmdlet, List<ITestSuite> suitesForSearch)
        {
            IOrderedEnumerable<ITestSuite> suitesFound = null;
            
            // Filtering results
            
            // default result
            Func<ITestSuite, bool> query = suite => true;
            
            if (!string.IsNullOrEmpty(cmdlet.FilterNameContains)) {
                query = suite => suite.Name.Contains(cmdlet.FilterNameContains);
                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterIdContains)) {
                query = suite => suite.Id.Contains(cmdlet.FilterIdContains);
                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterDescriptionContains)) {
                query = suite => suite.Description != null && suite.Description.Contains(cmdlet.FilterDescriptionContains);
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassed) {
                query = suite => suite.enStatus == TestSuiteStatuses.Passed;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterFailed) {
                query = suite => suite.enStatus == TestSuiteStatuses.Failed;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterNotTested) {
                query = suite => suite.enStatus == TestSuiteStatuses.NotTested;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassedWithBadSmell) {
                query = suite => suite.enStatus == TestSuiteStatuses.KnownIssue;
                cmdlet.FilterAll = false;
            }
            if (cmdlet.FilterAll) {
                query = suite => true;
            }
            if (cmdlet.FilterNone) {
                query = suite => false;
            }
            
            // Ordering results
            
            // default result
            Func<ITestSuite, object> ordering = suite => suite.Id;
            
            if (cmdlet.OrderByTimeSpent) {
                ordering += suite => suite.Statistics.TimeSpent;
            } 
            if (cmdlet.OrderByName) {
                ordering += suite => suite.Name;
            } 
            if (cmdlet.OrderById) {
                ordering += suite => suite.Id;
            } 
			if (cmdlet.OrderByPassRate) {
				ordering += suite => {
					TestData.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
					return (suite.Statistics.Passed / suite.Statistics.All);
				};
			} 
			if (cmdlet.OrderByFailRate) {
				ordering += suite => {
					TestData.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
					return (suite.Statistics.Failed / suite.Statistics.All);
				};
			} 
            
            suitesFound = SearchTestSuite(
                suitesForSearch,
                query,
                    //Combine<TestSuite, bool>((x, y) => x && y, queriesList.ToArray()),
                ordering,
                cmdlet.Descending);

            return suitesFound;
        }
        
        internal IOrderedEnumerable<ITestSuite> SearchTestSuite(
            List<ITestSuite> suites,
            Func<ITestSuite, bool> query,
            Func<ITestSuite, object> ordering,
            bool desc)
        {
            IOrderedEnumerable<ITestSuite> result = null;
            
            if (desc) {
                result =
                    from suite in suites
                    where query(suite)
                    orderby ordering(suite) descending
                    select suite;
            } else {
                result =
                    from suite in suites
                    where query(suite)
                    orderby ordering(suite) ascending
                    select suite;
            }
            return result;
        }
        
//        public IOrderedEnumerable<ITestSuite> SearchForSuitesPS(ISearchCmdletBaseDataObject cmdlet)
//        {
//            IOrderedEnumerable<ITestSuite> suites = SearchForSuites(cmdlet);
//			return suites.Any() ? suites : null;
//        }
        
//        public static Func<TInput, bool> Combine<TInput, Tout>
//            (Func<bool, bool, bool> aggregator,
//            params Func<TInput, bool>[] delegates) {
//
//            // delegates[0] provides the initial value
//            return t => delegates.Skip(1).Aggregate(delegates[0](t), aggregator);
//        }
//
////        public static Func<T, bool> And<T>(params Func<T, bool>[] predicates) {
////            return Combine<T, bool>((x, y) => x && y, predicates);
////        }
        
        /// <summary>
        /// Performs parametrized search for Test Scenarios.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public IOrderedEnumerable<ITestScenario> SearchForScenarios(ISearchCmdletBaseDataObject searchCriteria, List<ITestSuite> suitesForSearch)
        {
            IOrderedEnumerable<ITestScenario> scenarios = null;
            
            // Filtering results
            
            // default result
            Func<ITestScenario, bool> query = scenario => true;
            
            if (!string.IsNullOrEmpty(searchCriteria.FilterNameContains)) {
                query = scenario => scenario.Name.Contains(searchCriteria.FilterNameContains);
                searchCriteria.FilterAll = false;
            } else if (!string.IsNullOrEmpty(searchCriteria.FilterIdContains)) {
                query = scenario => scenario.Id.Contains(searchCriteria.FilterIdContains);
                searchCriteria.FilterAll = false;
            } else if (!string.IsNullOrEmpty(searchCriteria.FilterDescriptionContains)) {
                query = scenario => scenario.Description != null && scenario.Description.Contains(searchCriteria.FilterDescriptionContains);
                searchCriteria.FilterAll = false;
            } else if (searchCriteria.FilterPassed) {
                query = scenario => scenario.enStatus == TestScenarioStatuses.Passed;
                searchCriteria.FilterAll = false;
            } else if (searchCriteria.FilterFailed) {
                query = scenario => scenario.enStatus == TestScenarioStatuses.Failed;
                searchCriteria.FilterAll = false;
            } else if (searchCriteria.FilterNotTested) {
                query = scenario => scenario.enStatus == TestScenarioStatuses.NotTested;
                searchCriteria.FilterAll = false;
            } else if (searchCriteria.FilterPassedWithBadSmell) {
                query = scenario => scenario.enStatus == TestScenarioStatuses.KnownIssue;
                searchCriteria.FilterAll = false;
            }
            if (searchCriteria.FilterAll) {
                query = scenario => true;
            }
            if (searchCriteria.FilterNone) {
                query = scenario => false;
            }
            
            // Ordering results
            
            // default result
            Func<ITestScenario, object> ordering = scenario => scenario.Id;
            
            if (searchCriteria.OrderByTimeSpent) {
                ordering = scenario => scenario.Statistics.TimeSpent;
            } else if (searchCriteria.OrderByName) {
                ordering = scenario => scenario.Name;
            } else if (searchCriteria.OrderById) {
                ordering = scenario => scenario.Id;
            } else if (searchCriteria.OrderByPassRate) {
                ordering = scenario => 
                    scenario.Statistics.Passed / 
                        (scenario.Statistics.Passed + scenario.Statistics.Failed + 
                        scenario.Statistics.PassedButWithBadSmell + scenario.Statistics.NotTested);
            } else if (searchCriteria.OrderByFailRate) {
                ordering = scenario => 
                    scenario.Statistics.Failed / 
                        (scenario.Statistics.Passed + scenario.Statistics.Failed + 
                        scenario.Statistics.PassedButWithBadSmell + scenario.Statistics.NotTested);
            }
            
            scenarios = 
                SearchTestScenario(
                suitesForSearch,
                query,
                ordering,
                searchCriteria.Descending);
            
            return scenarios;
        }
        
        IOrderedEnumerable<ITestScenario> SearchTestScenario(
            List<ITestSuite> suitesForSearch,
            Func<ITestScenario, bool> query,
            Func<ITestScenario, object> ordering,
            bool desc)
        {
            IOrderedEnumerable<ITestScenario> result = null;
            
            if (desc) {
                result =
                    from scenario in getAllScenarios(suitesForSearch)
                    where query(scenario)
                    orderby ordering(scenario) descending
                    select scenario;
            } else {
                result =
                    from scenario in getAllScenarios(suitesForSearch)
                    where query(scenario)
                    orderby ordering(scenario) ascending
                    select scenario;
            }
            
            return result;
        }
        
        IEnumerable<ITestScenario> getAllScenarios(List<ITestSuite> suites)
        {
            // return TestData.TestSuites.SelectMany(suite => suite.TestScenarios).ToList();
            return suites.SelectMany(suite => suite.TestScenarios).ToList();
        }
        
//        public IOrderedEnumerable<ITestScenario> SearchForScenariosPS(ISearchCmdletBaseDataObject cmdlet)
//        {
//            var scenarios = SearchForScenarios(cmdlet);
//			return scenarios.Any() ? scenarios : null;
//        }
        
        /// <summary>
        /// Performs parametrized search for Test Results.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public IOrderedEnumerable<ITestResult> SearchForTestResults(ISearchCmdletBaseDataObject dataObject, List<ITestSuite> suitesForSearch)
        {
            IOrderedEnumerable<ITestResult> testResults = null;

            // Filtering results
            
            // default result
            Func<ITestResult, bool> query = testResult => true;
            
            dataObject.FilterAll = false;
            
			if (!string.IsNullOrEmpty(dataObject.FilterNameContains))
                query = testResult => testResult.Name != null && testResult.Name.Contains(dataObject.FilterNameContains);
            else if (!string.IsNullOrEmpty(dataObject.FilterIdContains))
                query = testResult => testResult.Id != null && testResult.Id.Contains(dataObject.FilterIdContains);
            else if (!string.IsNullOrEmpty(dataObject.FilterDescriptionContains))
                query = testResult => testResult.Description != null && testResult.Description.Contains(dataObject.FilterDescriptionContains);
            else if (dataObject.FilterPassed)
				query = testResult => testResult.enStatus == TestResultStatuses.Passed;
            else if (dataObject.FilterFailed)
				query = testResult => testResult.enStatus == TestResultStatuses.Failed;
            else if (dataObject.FilterNotTested)
				query = testResult => testResult.enStatus == TestResultStatuses.NotTested;
            else if (dataObject.FilterPassedWithBadSmell)
				query = testResult => testResult.enStatus == TestResultStatuses.KnownIssue;
            else if (dataObject.FilterOutAutomaticResults)
				query = testResult => testResult.Origin != TestResultOrigins.Automatic;
            else if (dataObject.FilterOutAutomaticAndTechnicalResults)
				query = testResult => testResult.Origin != TestResultOrigins.Automatic && testResult.Origin != TestResultOrigins.Technical;
            if (dataObject.FilterAll) {
                query = testResult => true;
                dataObject.FilterAll = true;
            }
            if (dataObject.FilterNone) {
                query = testResult => false;
            }
            
            // Ordering results
            
            // default result
            Func<ITestResult, object> ordering = testResult => testResult.Id;
            
			if (dataObject.OrderByTimeSpent)
				ordering = testResult => testResult.TimeSpent;
			else if (dataObject.OrderByDateTime)
				ordering = testResult => testResult.Timestamp;
			else if (dataObject.OrderByName)
				ordering = testResult => testResult.Name;
			else if (dataObject.OrderById)
				ordering = testResult => testResult.Id;
            
            testResults = 
                SearchTestResult(
                    suitesForSearch,
                    query,
                    ordering,
                    dataObject.Descending);

            return testResults;
        }
        
        IOrderedEnumerable<ITestResult> SearchTestResult(
            List<ITestSuite> suites,
            Func<ITestResult, bool> query,
            Func<ITestResult, object> ordering,
            bool desc)
        {
            IOrderedEnumerable<ITestResult> result = null;
            
            if (desc) {
                result =
                    from testResult in getAllTestResults(suites)
                    where query(testResult)
                    orderby ordering(testResult) descending
                    select testResult;
            } else {
                result =
                    from testResult in getAllTestResults(suites)
                    where query(testResult)
                    orderby ordering(testResult) ascending
                    select testResult;
            }
            return result;
        }
        
        IEnumerable<ITestResult> getAllTestResults(List<ITestSuite> suites)
        {
            // return (from suite in TestData.TestSuites from ITestScenario scenario in suite.TestScenarios from ITestResult testResult in scenario.TestResults select testResult).ToList();
            return (from suite in suites from ITestScenario scenario in suite.TestScenarios from ITestResult testResult in scenario.TestResults select testResult).ToList();
        }
        
//        public IOrderedEnumerable<ITestResult> SearchForTestResultsPS(ISearchCmdletBaseDataObject dataObject)
//        {
//            var testResults = SearchForTestResults(dataObject);
//			return testResults.Any() ? testResults : null;
//        }
        
//        XAttribute CreateXAttribute(string name, object valueObject)
//        {
//            XAttribute result = null;
//            
//            if (null == valueObject)
//                return null;
//            
//            result = new XAttribute(name, valueObject);
//            
//            return result;
//        }
//        
//        XElement CreateXElement(string name, params object[] content)
//        {
//            XElement result = null;
//            
//			if (null == content[0])
//				return null;
//            
//            result = new XElement(name, content);
//            
//            return result;
//        }
        #endregion Search
    }
}
