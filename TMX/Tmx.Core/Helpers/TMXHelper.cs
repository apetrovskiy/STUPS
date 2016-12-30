/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/20/2012
 * Time: 11:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    
    using System.Linq;
    using System.Xml.Linq;
    using Interfaces.Remoting;
    using Core;
    using Core.Proxy;
//    using System.Reflection;
    using Interfaces;
    using Interfaces.TestStructure;
    // using Tmx.Core;
    
    //using System.Data.SqlTypes;
    
    // using NHibernate.Persister.Entity;

    /// <summary>
    /// Description of TmxHelper.
    /// </summary>
    public static class TmxHelper
    {
        static TmxHelper()
        {
//            try {
            TestData.InitTestData();
//            }
//            catch (Exception ee) {
//                Console.WriteLine(ee.Message);
//            }
        }

        // 20161223
        // internal static DateTime TestCaseStarted { get; set; }
        public static DateTime TestCaseStarted { get; set; }
        public static System.Windows.Forms.Form BannerForm { get; set; }
        
        // 20160116
//        public static string GetScriptName(InvocationInfo iInfo)
//        {
//            string result = string.Empty;
//            try{
//                result = iInfo.ScriptName;
//            }
//            catch {
//                return result;
//            }
//            return result;
//        }
//        
//        public static int GetScriptLineNumber(InvocationInfo iInfo)
//        {
//            int result = 0;
//            try{
//                result = iInfo.ScriptLineNumber;
//            }
//            catch {
//                return result;
//            }
//            return result;
//        }
//        
//        public static int GetPipelinePosition(InvocationInfo iInfo)
//        {
//            int result = 0;
//            try{
//                result = iInfo.PipelinePosition;
//            }
//            catch {
//            }
//            return result;
//        }
        
        #region Actions
        // 20141114
        // public static bool OpenTestSuite(string testSuiteName, string testSuiteId, string testPlatformId)
        public static bool OpenTestSuite(string testSuiteName, string testSuiteId, Guid testPlatformUniqueId)
        {
            // set time spent on the previous suite
            if (null != TestData.CurrentTestSuite) {
                
                if (DateTime.MinValue != TestData.CurrentTestSuite.Timestamp) {
                    
                    TestData.CurrentTestSuite.SetTimeSpent(
                        TestData.CurrentTestSuite.TimeSpent +=
                        (DateTime.Now - TestData.CurrentTestSuite.Timestamp).TotalSeconds);
                    TestData.CurrentTestSuite.Timestamp = DateTime.MinValue;
                }
            }
            
            TestData.CurrentTestSuite = TestData.GetTestSuite(testSuiteName, testSuiteId, testPlatformUniqueId);
            if (null != TestData.CurrentTestSuite && null != TestData.CurrentTestSuite.TestScenarios && 0 < TestData.CurrentTestSuite.TestScenarios.Count)
                TestData.CurrentTestScenario = TestData.CurrentTestSuite.TestScenarios[TestData.CurrentTestSuite.TestScenarios.Count - 1];
            if (null == TestData.CurrentTestSuite) return false;
            // set the initial time for this suite's session
            TestData.CurrentTestSuite.SetNow();
            TestData.OnTmxTestSuiteOpened(TestData.CurrentTestSuite, null);
            return true;
        }
        
        public static bool NewTestPlatform(
            string testPlatformName,
            string testPlatformId,
            string testPlatformDesctiption,
            string testPlatformOS,
            string testPlatformVersion,
            string testPlatformArchitecture,
            string testPlatformLanguage)
        {
            return TestData.AddTestPlatform(
                    testPlatformName,
                    testPlatformId,
                    testPlatformDesctiption,
                    testPlatformOS,
                    testPlatformVersion,
                    testPlatformArchitecture,
                    testPlatformLanguage);
        }
        
        public static bool NewTestSuite(string testSuiteName, 
                                        string testSuiteId,
                                        Guid testPlatformId,
                                        string testSuiteDesctiption,
                                        ICodeBlock[] testSuiteBeforeScenario,
                                        ICodeBlock[] testSuiteAfterScenario)
        {
            return TestData.AddTestSuite(testSuiteName,
                                         testSuiteId,
                                         testPlatformId,
                                         testSuiteDesctiption,
                                         testSuiteBeforeScenario,
                                         testSuiteAfterScenario);
        }
        
        public static bool OpenTestScenario(IOpenScenarioCmdletBaseDataObject cmdlet)
        {
            bool result = false;
            
            if (TestData.CurrentTestResult.Details.Count > 0) {
                
                TestData.AddTestResult(
                    "autoclosed", 
                    TestData.GetTestResultId(), 
                    null, 
                    false, // isKnownIssue
                    false, // geenrateNextResult
                    // 20140720
                    // cmdlet.MyInvocation,
                    // 20160116
                    // null,
                    null, // Error
                    string.Empty,
                    TestResultOrigins.Automatic,
                    false);
            }
            
            // set time spent on the previous scenario
            if (null != TestData.CurrentTestScenario) {
                if (DateTime.MinValue != TestData.CurrentTestScenario.Timestamp) {
                    TestData.CurrentTestScenario.SetTimeSpent(
                        TestData.CurrentTestScenario.TimeSpent +=
                        (DateTime.Now - TestData.CurrentTestScenario.Timestamp).TotalSeconds);
                    TestData.CurrentTestScenario.Timestamp = DateTime.MinValue;
                }
            }
            
                //true);
            //TestData.CurrentTestScenario =
            TestData.GetTestScenario(cmdlet.InputObject,
                                     cmdlet.Name,
                                     cmdlet.Id,
                                     cmdlet.TestSuiteName,
                                     cmdlet.TestSuiteId,
                                     // 20141114
                                     // cmdlet.TestPlatformId);
                                     TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId);
            
            if (TestData.CurrentTestScenario == null) return result;
            TestData.CurrentTestScenario.TestResults.Add(
                new TestResult(
                    TestData.CurrentTestScenario.Id,
                    TestData.CurrentTestScenario.SuiteId));
            TestData.CurrentTestResult =
                TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1];
            
            // set the initial time for this scenario's session
            TestData.CurrentTestScenario.SetNow();
            //TestData.FireTmxTestScenarioOpened(TestData.CurrentTestResult, null);
            TestData.OnTmxTestScenarioOpened(TestData.CurrentTestScenario, null);
            result = true;
            
            /*
            if (TestData.CurrentTestScenario != null) {

                TestData.CurrentTestScenario.TestResults.Add(
                    new TestResult(
                       TestData.CurrentTestScenario.Id,
                       TestData.CurrentTestScenario.SuiteId));

                TestData.CurrentTestResult =
                    TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1];

                // 20130301
                // set the initial time for this scenario's session
                TestData.CurrentTestScenario.SetNow();

                //TestData.FireTmxTestScenarioOpened(TestData.CurrentTestResult, null);
                TestData.OnTmxTestScenarioOpened(TestData.CurrentTestScenario, null);

                result = true;
            }
            */
            return result;
        }
        
        // 20140720
        // public static bool AddTestScenario(AddScenarioCmdletBase cmdlet)
        public static bool AddTestScenario(IAddScenarioCmdletBaseDataObject cmdlet)
        {
            bool result = false;
            result = 
                TestData.AddTestScenario(cmdlet.InputObject,
                                         cmdlet.Name,
                                         cmdlet.Id,
                                         cmdlet.Description,
                                         cmdlet.TestSuiteName,
                                         cmdlet.TestSuiteId,
                                         // 20141114
                                         // cmdlet.TestPlatformId,
                                         TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId,
                                         cmdlet.BeforeTest,
                                         cmdlet.AfterTest);
            
            return result;
        }
        
        public static bool AddTestResultScreenshotDetail(string testResultScreenshotDetail)
        {
            bool result = false;
            
            TestData.AddTestResultScreenshotDetail(testResultScreenshotDetail);
            
            return result;
        }
        
        // 20160116
        // public static bool AddTestResultErrorDetail(ErrorRecord testResultErrorDetail)
        public static bool AddTestResultErrorDetail(Exception testResultErrorDetail)
        {
            bool result = false;
            
            // 20130702
            try {
                TestData.AddTestResultErrorDetail(testResultErrorDetail);
            }
            catch {}
            
            return result;
        }
        
//        public static void CloseTestResultAsIs()
//        {
//
//            if (TestData.TestSuites.Count == 0) {
//                TestData.InitTestData();
//            }
//            
//            if (null != TestData.CurrentTestResult) {
//                TestData.CurrentTestScenario.TestResults.Add(TestData.CurrentTestResult);
//            }
//            
//            TestData.CurrentTestResult =
//                new TestResult(
//                    TestData.CurrentTestScenario.Id,
//                    TestData.CurrentTestSuite.Id);
//
//        }
        
        public static void CloseTestResult(
            string testResultName, 
            string testResultId, 
            bool testResult,
            bool isKnownIssue,
            // 20160116
            // InvocationInfo myInvocation,
            // 20160116
            // ErrorRecord error,
            Exception error,
            string description,
            TestResultOrigins origin,
            bool skipAutomatic)
        {
            // 20121224
            //bool result = false;
            
//            if (TestData.TestSuites.Count == 0) {
//                TestData.InitTestData();
//            }

            TestData.AddTestResult(
                testResultName, 
                testResultId, 
                testResult, 
                isKnownIssue,
                true,
                // 20160116
                // myInvocation,
                error,
                description,
                origin,
                skipAutomatic);
        }
        #endregion Actions
        
        #region Import/export test structure
//        public static bool ImportTestStructure(string path)
//        {
//            bool result = false;
//            
//            
//            return result;
//        }
        
//        public static bool ExportTestStructure(string path)
//        {
//            bool result = false;
//            
//            
//            return result;
//        }
        #endregion Import/export test structure
        
        #region Search
        /// <summary>
        /// Performs parametrized search for Test Suites.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<ITestSuite> SearchForSuites(ISearchCmdletBaseDataObject cmdlet)
        {
            IOrderedEnumerable<ITestSuite> suites = null;
            // 20141107
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            
            // Filtering results
            
            // default result
            Func<ITestSuite, bool> query = suite => true;
            
//            System.Collections.Generic.List<Func<TestSuite, bool>> queriesList =
//                new List<Func<TestSuite, bool>>();
//            queriesList.Add(query);
            
            if (!string.IsNullOrEmpty(cmdlet.FilterNameContains)) {
            // if (cmdlet.FilterNameContains != null && cmdlet.FilterNameContains.Length > 0) {
                query = suite => suite.Name.Contains(cmdlet.FilterNameContains);
                //queriesList.Add((suite => suite.Name.Contains(cmdlet.FilterNameContains)));
                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterIdContains)) {
            // } else if (cmdlet.FilterIdContains != null && cmdlet.FilterIdContains.Length > 0) {
                query = suite => suite.Id.Contains(cmdlet.FilterIdContains);
                //queriesList.Add((suite => suite.Id.Contains(cmdlet.FilterIdContains)));
                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterDescriptionContains)) {
            // } else if (cmdlet.FilterDescriptionContains != null && cmdlet.FilterDescriptionContains.Length > 0) {
                query = suite => suite.Description != null && suite.Description.Contains(cmdlet.FilterDescriptionContains);

                //query = suite =>
                //{
                //    return suite.Description != null && suite.Description.Contains(cmdlet.FilterDescriptionContains);

                //    /*
                //        if (suite.Description != null) {
                //            return suite.Description.Contains(cmdlet.FilterDescriptionContains);
                //        }
                //        return false;
                //        */
                //};

//                queriesList.Add((suite =>
//                    {
//                        if (suite.Description != null) {
//                            return suite.Description.Contains(cmdlet.FilterDescriptionContains);
//                        }
//                        return false;
//                    }));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassed) {
                query = suite => suite.enStatus == TestStatuses.Passed;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.Passed));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterFailed) {
                query = suite => suite.enStatus == TestStatuses.Failed;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.Failed));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterNotTested) {
                query = suite => suite.enStatus == TestStatuses.NotRun;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.NotTested));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassedWithBadSmell) {
                query = suite => suite.enStatus == TestStatuses.KnownIssue;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.KnownIssue));
                cmdlet.FilterAll = false;
            }
            if (cmdlet.FilterAll) {
                query = suite => true;
            }
            if (cmdlet.FilterNone) {
                query = suite => false;
                //queriesList.Clear();
                //queriesList.Add(query);
            }
            
            // Ordering results
            
            // default result
            // 20140720
            // Func<TestSuite, object> ordering = suite => suite.Id;
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
                    //TestData.RefreshSuiteStatistics(suite);
                    // 20141107
                    // TestData.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
                    testStatistics.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
                    return (suite.Statistics.Passed / suite.Statistics.All);
                };
            } 
            if (cmdlet.OrderByFailRate) {
                ordering += suite => {
                    //TestData.RefreshSuiteStatistics(suite);
                    // 20141107
                    // TestData.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
                    testStatistics.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
                    return (suite.Statistics.Failed / suite.Statistics.All);
                };
            } 

//            cmdlet.WriteVerbose(cmdlet, "query = " + query);
//            cmdlet.WriteVerbose(cmdlet, "ordering = " + ordering);
            
            suites = 
                TestData.SearchTestSuite(
                    query,
                    //Combine<TestSuite, bool>((x, y) => x && y, queriesList.ToArray()),
                    ordering,
                    cmdlet.Descending);

            return suites;
        }
        
        public static IOrderedEnumerable<ITestSuite> SearchForSuitesPS(ISearchCmdletBaseDataObject cmdlet)
        {
            IOrderedEnumerable<ITestSuite> suites = SearchForSuites(cmdlet);
            return suites.Any() ? suites : null;
        }
        
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
        // 20140720
        // public static IOrderedEnumerable<TestScenario> SearchForScenarios(SearchCmdletBase cmdlet)
        public static IOrderedEnumerable<ITestScenario> SearchForScenarios(ISearchCmdletBaseDataObject cmdlet)
        {
            // 20140720
            // IOrderedEnumerable<TestScenario> scenarios = null;
            IOrderedEnumerable<ITestScenario> scenarios = null;
            
            // Filtering results
            
            // default result
            // 20140720
            // Func<TestScenario, bool> query = scenario => true;
            Func<ITestScenario, bool> query = scenario => true;
            
            if (!string.IsNullOrEmpty(cmdlet.FilterNameContains)) {
            // if (cmdlet.FilterNameContains != null && cmdlet.FilterNameContains.Length > 0) {
                query = scenario => scenario.Name.Contains(cmdlet.FilterNameContains);
                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterIdContains)) {
            // } else if (cmdlet.FilterIdContains != null && cmdlet.FilterIdContains.Length > 0) {
                query = scenario => scenario.Id.Contains(cmdlet.FilterIdContains);
                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterDescriptionContains)) {
            // } else if (cmdlet.FilterDescriptionContains != null && cmdlet.FilterDescriptionContains.Length > 0) {
                query = scenario => scenario.Description != null && scenario.Description.Contains(cmdlet.FilterDescriptionContains);

                //query = scenario =>
                //{
                //    return scenario.Description != null && scenario.Description.Contains(cmdlet.FilterDescriptionContains);

                //    /*
                //        if (scenario.Description != null) {
                //            return scenario.Description.Contains(cmdlet.FilterDescriptionContains);
                //        }
                //        return false;
                //        */
                //};
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassed) {
                query = scenario => scenario.enStatus == TestStatuses.Passed;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterFailed) {
                query = scenario => scenario.enStatus == TestStatuses.Failed;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterNotTested) {
                query = scenario => scenario.enStatus == TestStatuses.NotRun;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassedWithBadSmell) {
                query = scenario => scenario.enStatus == TestStatuses.KnownIssue;
                cmdlet.FilterAll = false;
            }
            if (cmdlet.FilterAll) {
                query = scenario => true;
            }
            if (cmdlet.FilterNone) {
                query = scenario => false;
            }
            
            // Ordering results
            
            // default result
            // 20140720
            // Func<TestScenario, object> ordering = scenario => scenario.Id;
            Func<ITestScenario, object> ordering = scenario => scenario.Id;
            
            if (cmdlet.OrderByTimeSpent) {
                ordering = scenario => scenario.Statistics.TimeSpent;
            } else if (cmdlet.OrderByName) {
                ordering = scenario => scenario.Name;
            } else if (cmdlet.OrderById) {
                ordering = scenario => scenario.Id;
            } else if (cmdlet.OrderByPassRate) {
                ordering = scenario => 
                    scenario.Statistics.Passed / 
                        (scenario.Statistics.Passed + scenario.Statistics.Failed + 
                        scenario.Statistics.PassedButWithBadSmell + scenario.Statistics.NotTested);
            } else if (cmdlet.OrderByFailRate) {
                ordering = scenario => 
                    scenario.Statistics.Failed / 
                        (scenario.Statistics.Passed + scenario.Statistics.Failed + 
                        scenario.Statistics.PassedButWithBadSmell + scenario.Statistics.NotTested);
            }
            
//            cmdlet.WriteVerbose(cmdlet, "query = " + query);
//            cmdlet.WriteVerbose(cmdlet, "ordering = " + ordering);
            
            scenarios = 
                TestData.SearchTestScenario(
                    query,
                    ordering,
                    cmdlet.Descending);
            
            return scenarios;
        }
        
        public static IOrderedEnumerable<ITestScenario> SearchForScenariosPS(ISearchCmdletBaseDataObject cmdlet)
        {
            var scenarios = SearchForScenarios(cmdlet);
            return scenarios.Any() ? scenarios : null;
        }
        
        /// <summary>
        /// Performs parametrized search for Test Results.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<ITestResult> SearchForTestResults(ISearchCmdletBaseDataObject dataObject)
        {
            IOrderedEnumerable<ITestResult> testResults = null;

            // Filtering results
            
            // default result
            Func<ITestResult, bool> query = testResult => true;
            
            dataObject.FilterAll = false;
            
            if (!string.IsNullOrEmpty(dataObject.FilterNameContains))
            // if (cmdlet.FilterNameContains != null && cmdlet.FilterNameContains.Length > 0) {
                query = testResult => testResult.Name != null && testResult.Name.Contains(dataObject.FilterNameContains);

                //query = testResult =>
                //{
                //    return testResult.Name != null && testResult.Name.Contains(cmdlet.FilterNameContains);

                //    /*
                //        if (testResult.Name != null) {
                //            return testResult.Name.Contains(cmdlet.FilterNameContains);
                //        }
                //        return false;
                //        */
                //};

                // dataObject.FilterAll = false;
            else if (!string.IsNullOrEmpty(dataObject.FilterIdContains))
            // } else if (cmdlet.FilterIdContains != null && cmdlet.FilterIdContains.Length > 0) {
                query = testResult => testResult.Id != null && testResult.Id.Contains(dataObject.FilterIdContains);

                //query = testResult =>
                //{
                //    return testResult.Id != null && testResult.Id.Contains(cmdlet.FilterIdContains);

                //    /*
                //        if (testResult.Id != null) {
                //            return testResult.Id.Contains(cmdlet.FilterIdContains);
                //        }
                //        return false;
                //        */
                //};

                // dataObject.FilterAll = false;
            else if (!string.IsNullOrEmpty(dataObject.FilterDescriptionContains))
            // } else if (cmdlet.FilterDescriptionContains != null && cmdlet.FilterDescriptionContains.Length > 0) {
                query = testResult => testResult.Description != null && testResult.Description.Contains(dataObject.FilterDescriptionContains);

                //query = testResult =>
                //{
                //    return testResult.Description != null && testResult.Description.Contains(cmdlet.FilterDescriptionContains);

                //    /*
                //        if (testResult.Description != null) {
                //            return testResult.Description.Contains(cmdlet.FilterDescriptionContains);
                //        }
                //        return false;
                //        */
                //};

                // dataObject.FilterAll = false;
            else if (dataObject.FilterPassed)
                // 20150805
                // query = testResult => testResult.enStatus == TestResultStatuses.Passed;
                query = testResult => testResult.enStatus == TestStatuses.Passed;
                // dataObject.FilterAll = false;
            else if (dataObject.FilterFailed)
                // 20150805
                // query = testResult => testResult.enStatus == TestResultStatuses.Failed;
                query = testResult => testResult.enStatus == TestStatuses.Failed;
                // dataObject.FilterAll = false;
            else if (dataObject.FilterNotTested)
                // 20150805
                // query = testResult => testResult.enStatus == TestResultStatuses.NotTested;
                query = testResult => testResult.enStatus == TestStatuses.NotRun;
                // dataObject.FilterAll = false;
            else if (dataObject.FilterPassedWithBadSmell)
                // 20150805
                // query = testResult => testResult.enStatus == TestResultStatuses.KnownIssue;
                query = testResult => testResult.enStatus == TestStatuses.KnownIssue;
                // dataObject.FilterAll = false;
            else if (dataObject.FilterOutAutomaticResults)
                query = testResult => testResult.Origin != TestResultOrigins.Automatic;
                // dataObject.FilterAll = false;
            else if (dataObject.FilterOutAutomaticAndTechnicalResults)
                query = testResult => testResult.Origin != TestResultOrigins.Automatic && testResult.Origin != TestResultOrigins.Technical;
            // dataObject.FilterAll = false;
            if (dataObject.FilterAll) {
                query = testResult => true;
                // 20140722
                dataObject.FilterAll = true;
            }
            if (dataObject.FilterNone) {
                query = testResult => false;
            }
            
            // Ordering results
            
            // default result
            // 20140720
            // Func<TestResult, object> ordering = testResult => testResult.Id;
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
                TestData.SearchTestResult(
                    query,
                    ordering,
                    dataObject.Descending);

            return testResults;
        }
        
        public static IOrderedEnumerable<ITestResult> SearchForTestResultsPS(ISearchCmdletBaseDataObject dataObject)
        {
            var testResults = SearchForTestResults(dataObject);
            return testResults.Any() ? testResults : null;
        }
        #endregion Search
        
        public static void ExportResultsToJUnitXML(ISearchCmdletBaseDataObject cmdlet, string path)
        {
            try {
                // 20150925
                // var gathered = new GatherTestResultsCollections();
                var gathered = ProxyFactory.Get<GatherTestResultsCollections>();
                gathered.GatherCollections(cmdlet);

                // 20150925
                // var testResultsExporter = new TestResultsExporter();
                var testResultsExporter = ProxyFactory.Get<TestResultsExporter>();
                var suitesElement = testResultsExporter.CreateSuitesXElementWithParameters(
                    gathered.TestSuites,
                    gathered.TestScenarios,
                    gathered.TestResults,
                    (new XMLElementsJUnitStruct()));
                
                var document = new XDocument();
                document.Add(suitesElement);
                document.Save(path);
            }
            catch (Exception eCreateDocument) {
                // 20140720
//                cmdlet.WriteError(
//                    cmdlet,
//                    "Unable to save XML report to the file '" +
//                    path +
//                    "'. " + 
//                    eCreateDocument.Message,
//                    "FailedToSaveReport",
//                    ErrorCategory.InvalidOperation,
//                    true);
                throw new Exception(
                    "Unable to save XML report to the file '" +
                    path +
                    "'. " + 
                    eCreateDocument.Message);
            }
        }
        
        public static string GetCurrentTestSuiteStatus(IOpenSuiteCmdletBaseDataObject cmdlet, bool skipAutomatic)
        {
            if (null == TestData.CurrentTestSuite) return string.Empty;
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            testStatistics.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            return TestData.CurrentTestSuite.Status;
        }
        
        public static string GetTestSuiteStatusByName(string name, Guid testPlatformId, bool skipAutomatic)
        {
            OpenTestSuite(
                name,
                string.Empty,
                testPlatformId);
            if (null == TestData.CurrentTestSuite) return string.Empty;
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            testStatistics.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            return TestData.CurrentTestSuite.Status;
        }
        
        public static string GetTestSuiteStatusById(string id, Guid testPlatformId, bool skipAutomatic)
        {
            OpenTestSuite(
                string.Empty,
                id,
                testPlatformId);
            if (null == TestData.CurrentTestSuite) return string.Empty;
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            testStatistics.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            return TestData.CurrentTestSuite.Status;
        }
        
        public static string GetCurrentTestScenarioStatus(IOpenScenarioCmdletBaseDataObject cmdlet, bool skipAutomatic)
        {
            if (null == TestData.CurrentTestScenario) return string.Empty;
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            testStatistics.RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
            return TestData.CurrentTestScenario.Status;
        }
        
        public static string GetTestScenarioStatus(IOpenScenarioCmdletBaseDataObject dataObject, bool skipAutomatic)
        {
            OpenTestScenario(dataObject);
            if (null == TestData.CurrentTestScenario) return string.Empty;
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            testStatistics.RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
            return TestData.CurrentTestScenario.Status;
        }
        
        public static void SetCurrentTestResult(ITestResultCmdletBaseDataObject cmdlet)
        {
            if (null != TestData.CurrentTestResult) {

                TestData.CurrentTestResult.Name = !string.IsNullOrEmpty(cmdlet.TestResultName) ? cmdlet.TestResultName : "this test result is not provided with name";
                
                if (!string.IsNullOrEmpty(cmdlet.Id))
                    TestData.CurrentTestResult.Id = cmdlet.Id;
                else
                    TestData.GetTestResultId();
                
                if (!string.IsNullOrEmpty(cmdlet.Description))
                    TestData.CurrentTestResult.Description = cmdlet.Description;

                // 20150805
                // TestData.CurrentTestResult.enStatus = TestResultStatuses.NotTested;
                TestData.CurrentTestResult.enStatus = TestStatuses.NotRun;

                if (cmdlet.KnownIssue)
                    // 20150805
                    // TestData.CurrentTestResult.enStatus = TestResultStatuses.KnownIssue;
                    TestData.CurrentTestResult.enStatus = TestStatuses.KnownIssue;
                
                TestData.CurrentTestResult.SetOrigin(cmdlet.TestOrigin);

            } else {

                // there always is the current test result
            }
        }
        
        public static string GetCurrentTestResultStatus(ITestResultCmdletBaseDataObject cmdlet)
        {
            string testResultId = cmdlet.Id;
            
            if (!string.IsNullOrEmpty(testResultId)) {
            // if (null != testResultId && string.Empty != testResultId && 0 < testResultId.Length) {
            
//                if (null != TestData.CurrentTestResult) {
//                    cmdlet.WriteObject(cmdlet, TestData.CurrentTestResult.Status);
//                } else {
//                    cmdlet.WriteObject(cmdlet, "NOT TESTED");
//                }
                
                
                
                
                
                
                
                
                
                
                
//                cmdlet.WriteVerbose(cmdlet, "Trying to get a test result with Id = " + testResultId);
                
                var testResultWithIdCollection =
                    from testResult in TestData.CurrentTestScenario.TestResults
                    where testResult.Id == testResultId
                    select testResult;
                
                // 20140720
                // if (null == testResultWithIdCollection || !testResultWithIdCollection.Any()) return;
                if (null == testResultWithIdCollection || !testResultWithIdCollection.Any()) return string.Empty;
                    
                foreach (ITestResult testResultWithId in testResultWithIdCollection) {
                        
//                    cmdlet.WriteVerbose(cmdlet, "Trying the test result '" + ((ITestResult)testResultWithId).Name + "'");
                    try {
                        // if the result is null, there's the try-catch construction
                        // 20140720
                        // cmdlet.WriteObject(cmdlet, ((ITestResult)testResultWithId).Status);
                        return ((ITestResult)testResultWithId).Status;
                    }
                    catch {
                        //cmdlet.WriteObject(cmdlet, (new object[] { null }));
                        // 20140720
                        // cmdlet.WriteObject(cmdlet, "NOT TESTED");
                        return "NOT TESTED";
                    }
                }

                /*
                if (null != testResultWithIdCollection  && testResultWithIdCollection.Any()) {
                // if (null != testResultWithIdCollection  && 0 < testResultWithIdCollection.Count()) {
                    
                    foreach (ITestResult testResultWithId in testResultWithIdCollection) {
                        
                        cmdlet.WriteVerbose(cmdlet, "Trying the test result '" + ((ITestResult)testResultWithId).Name + "'");
                        try {
                            // if the result is null, there's the try-catch construction
                            cmdlet.WriteObject(cmdlet, ((ITestResult)testResultWithId).Status);
                        }
                        catch {
                            //cmdlet.WriteObject(cmdlet, (new object[] { null }));
                            cmdlet.WriteObject(cmdlet, "NOT TESTED");
                        }
                    }
                }
                */
                
                // 20140720
                return string.Empty;
            } else {
                
//                cmdlet.WriteVerbose(cmdlet, "Trying the current test result");
                
                // 20140720
                // if (null == TestData.CurrentTestResult) return;
                return null == TestData.CurrentTestResult ? string.Empty : TestData.CurrentTestResult.Status;
//                cmdlet.WriteVerbose(cmdlet, "The current test result");
                // 20140720
                // cmdlet.WriteObject(cmdlet, TestData.CurrentTestResult.Status);
            }
        }
        
        public static object[] GetTestResultDetails(ITestResultStatusCmdletBaseDataObject cmdlet)
        {
            string testResultId = cmdlet.Id;
            
            if (!string.IsNullOrEmpty(testResultId)) {
                
                var testResultWithIdCollection =
                    from testResult in TestData.CurrentTestScenario.TestResults
                    where testResult.Id == testResultId
                    select testResult;
                
                // 20140720
                // if (null == testResultWithIdCollection || !testResultWithIdCollection.Any()) return;
                if (null == testResultWithIdCollection || !testResultWithIdCollection.Any()) return new[] { string.Empty };
                    
                foreach (ITestResult testResultWithId in testResultWithIdCollection) {
                        
                    try {
                        // if the result is null, there's the try-catch construction
                        // 20140703
                        // refactoring
                        // foreach (ITestResultDetail singleDetail in ((ITestResult)testResultWithId).ListDetailNames(cmdlet)) {
                        foreach (ITestResultDetail singleDetail in ((ITestResult)testResultWithId).ListDetailNames(cmdlet.TestResultStatus)) {
                            // 20140720
                            // cmdlet.WriteObject(cmdlet, singleDetail.Name);
                            return new[] { singleDetail.Name };
                        }
                    }
                    catch {
                        // 20140720
                        // cmdlet.WriteObject(cmdlet, (new object[] { null }));
                        return new object[] { null };
                    }
                }

                /*
                if (null != testResultWithIdCollection  && testResultWithIdCollection.Any()) {
                // if (null != testResultWithIdCollection  && 0 < testResultWithIdCollection.Count()) {
                    
                    foreach (ITestResult testResultWithId in testResultWithIdCollection) {
                        
                        cmdlet.WriteVerbose(cmdlet, "Trying the test result '" + ((ITestResult)testResultWithId).Name + "'");
                        try {
                            // if the result is null, there's the try-catch construction
                            foreach (ITestResultDetail singleDetail in ((ITestResult)testResultWithId).ListDetailNames(cmdlet)) {
                                cmdlet.WriteObject(cmdlet, singleDetail.Name);
                            }
                        }
                        catch {
                            cmdlet.WriteObject(cmdlet, (new object[] { null }));
                        }
                    }
                }
                */
                
                // 20140720
                return new[] { string.Empty };
            } else {
                
                // 20140720
                // if (null == TestData.CurrentTestResult) return;
                return null == TestData.CurrentTestResult ? new[] {
                    string.Empty
                } : TestData.CurrentTestResult.ListDetailNames(cmdlet.TestResultStatus);
//                cmdlet.WriteVerbose(cmdlet, "The current test result");
                // 20140720
                // cmdlet.WriteObject(cmdlet, TestData.CurrentTestResult.ListDetailNames(cmdlet.TestResultStatus));
            }
        }
        
        public static void ImportResultsFromJUnitXML(ISearchCmdletBaseDataObject cmdlet, string path)
        {
            throw new NotImplementedException();
        }
        
        public static bool AddTestCase(IAddTestCaseCmdletBaseDataObject cmdlet)
        {
            bool result = false;
            
            result = 
                TestData.AddTestCase(cmdlet.Name,
                                         cmdlet.Id,
                                         "", //cmdlet.Description,
                                         TestData.CurrentTestSuite.Name, //cmdlet.TestSuiteName,
                                         TestData.CurrentTestSuite.Id, //cmdlet.TestSuiteId,
                                         TestData.CurrentTestScenario.Name, //cmdlet.TestScenarioName,
                                         TestData.CurrentTestScenario.Id, //cmdlet.TestScenarioId,
                                         // 20141114
                                         // cmdlet.TestPlatformId,
                                         TestData.TestPlatforms.FirstOrDefault(tp => tp.Id == cmdlet.TestPlatformId).UniqueId,
                                         cmdlet.TestCode);
            
            return result;
        }
        
        public static ITestPlatform GetTestPlatformById(string id)
        {
            return TestData.TestPlatforms.FirstOrDefault(platform => id == platform.Id);
        }
    }
}
