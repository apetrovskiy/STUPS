/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/20/2012
 * Time: 11:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    using System.Linq;
    
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Reflection;
    
    //using System.Data.SqlTypes;
    
    using NHibernate.Persister.Entity;

    /// <summary>
    /// Description of TmxHelper.
    /// </summary>
    public static class TmxHelper
    {
        static TmxHelper()
        {
            TestData.InitTestData();
        }
        
        internal static DateTime TestCaseStarted { get; set; }
        public static System.Windows.Forms.Form BannerForm { get; set; }
        
        public static string GetScriptName(InvocationInfo iInfo)
        {
            string result = string.Empty;
            try{
                result =
                    iInfo.ScriptName;
            }
            catch {
                return result;
            }
            return result;
        }
        
        public static int GetScriptLineNumber(InvocationInfo iInfo)
        {
            int result = 0;
            try{
                result =
                    iInfo.ScriptLineNumber;
            }
            catch {
                return result;
            }
            return result;
        }
        
        public static int GetPipelinePosition(InvocationInfo iInfo)
        {
            int result = 0;
            try{
                result =
                    iInfo.PipelinePosition;
            }
            catch {
            }
            return result;
        }
        
        #region Actions
        public static bool OpenTestSuite(string testSuiteName, string testSuiteId, string testPlatformId)
        {
            bool result = false;
            
            // 20130429
            // 20140317
            // turning off the logger
            // TMX.Logger.TmxLogger.Info("Test suite: '" + testSuiteName + "'");
            
            // 20130301
            // set time spent on the previous suite
            if (null != TMX.TestData.CurrentTestSuite) {

                if (System.DateTime.MinValue != TMX.TestData.CurrentTestSuite.Timestamp) {

                    TMX.TestData.CurrentTestSuite.SetTimeSpent(
                        TMX.TestData.CurrentTestSuite.TimeSpent +=
                        (System.DateTime.Now - TMX.TestData.CurrentTestSuite.Timestamp).TotalSeconds);
                    TMX.TestData.CurrentTestSuite.Timestamp = System.DateTime.MinValue;
                }
            }
            
            TMX.TestData.CurrentTestSuite = 
                TMX.TestData.GetTestSuite(testSuiteName, testSuiteId, testPlatformId);
            if (TMX.TestData.CurrentTestSuite == null) return result;
            //TMX.TestData.FireTmxTestSuiteOpened(TMX.TestData.CurrentTestSuite, null);
                
            // 20130301
            // set the initial time for this suite's session
            TMX.TestData.CurrentTestSuite.SetNow();

            TMX.TestData.OnTmxTestSuiteOpened(TMX.TestData.CurrentTestSuite, null);
            result = true;

            /*
            if (TMX.TestData.CurrentTestSuite != null) {
                //TMX.TestData.FireTmxTestSuiteOpened(TMX.TestData.CurrentTestSuite, null);
                
                // 20130301
                // set the initial time for this suite's session
                TMX.TestData.CurrentTestSuite.SetNow();

                TMX.TestData.OnTmxTestSuiteOpened(TMX.TestData.CurrentTestSuite, null);
                result = true;
            }
            */

            return result;
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
            bool result = false;
            result = 
                TMX.TestData.AddTestPlatform(
                    testPlatformName,
                    testPlatformId,
                    testPlatformDesctiption,
                    testPlatformOS,
                    testPlatformVersion,
                    testPlatformArchitecture,
                    testPlatformLanguage);
            
            return result;
        }
        
        public static bool NewTestSuite(string testSuiteName, 
                                        string testSuiteId,
                                        string testPlatformId,
                                        string testSuiteDesctiption,
                                        ScriptBlock[] testSuiteBeforeScenario,
                                        ScriptBlock[] testSuiteAfterScenario)
        {
            bool result = false;
            result = 
                TMX.TestData.AddTestSuite(testSuiteName, 
                                          testSuiteId,
                                          testPlatformId,
                                          testSuiteDesctiption,
                                          testSuiteBeforeScenario,
                                          testSuiteAfterScenario);
            return result;
        }
        
        public static bool OpenTestScenario(OpenScenarioCmdletBase cmdlet)
        {
            bool result = false;

            if (TestData.CurrentTestResult.Details.Count > 0) {

            TMX.TestData.AddTestResult(
                "autoclosed", 
                TestData.GetTestResultId(), 
                null, 
                false, // isKnownIssue
                false, // geenrateNextResult
                cmdlet.MyInvocation,
                null, // Error
                string.Empty,
                // 20130322
                //true);
                // 20130626
                //true,
                TestResultOrigins.Automatic,
                false);

            }

            // 20130301
            // set time spent on the previous scenario
            if (null != TMX.TestData.CurrentTestScenario) {

                if (System.DateTime.MinValue != TMX.TestData.CurrentTestScenario.Timestamp) {

                    TMX.TestData.CurrentTestScenario.SetTimeSpent(
                        TMX.TestData.CurrentTestScenario.TimeSpent +=
                        (System.DateTime.Now - TMX.TestData.CurrentTestScenario.Timestamp).TotalSeconds);
                    TMX.TestData.CurrentTestScenario.Timestamp = System.DateTime.MinValue;

                }
            }

                //true);
            //TMX.TestData.CurrentTestScenario =
                TMX.TestData.GetTestScenario(cmdlet.InputObject,
                                             cmdlet.Name,
                                             cmdlet.Id,
                                             cmdlet.TestSuiteName,
                                             cmdlet.TestSuiteId,
                                             cmdlet.TestPlatformId);

            if (TMX.TestData.CurrentTestScenario == null) return result;
            TMX.TestData.CurrentTestScenario.TestResults.Add(
                new TestResult(
                    TMX.TestData.CurrentTestScenario.Id,
                    TMX.TestData.CurrentTestScenario.SuiteId));

            TMX.TestData.CurrentTestResult =
                TMX.TestData.CurrentTestScenario.TestResults[TMX.TestData.CurrentTestScenario.TestResults.Count - 1];

            // 20130301
            // set the initial time for this scenario's session
            TMX.TestData.CurrentTestScenario.SetNow();

            //TMX.TestData.FireTmxTestScenarioOpened(TMX.TestData.CurrentTestResult, null);
            TMX.TestData.OnTmxTestScenarioOpened(TMX.TestData.CurrentTestScenario, null);

            result = true;

            /*
            if (TMX.TestData.CurrentTestScenario != null) {

                TMX.TestData.CurrentTestScenario.TestResults.Add(
                    new TestResult(
                       TMX.TestData.CurrentTestScenario.Id,
                       TMX.TestData.CurrentTestScenario.SuiteId));

                TMX.TestData.CurrentTestResult =
                    TMX.TestData.CurrentTestScenario.TestResults[TMX.TestData.CurrentTestScenario.TestResults.Count - 1];

                // 20130301
                // set the initial time for this scenario's session
                TMX.TestData.CurrentTestScenario.SetNow();

                //TMX.TestData.FireTmxTestScenarioOpened(TMX.TestData.CurrentTestResult, null);
                TMX.TestData.OnTmxTestScenarioOpened(TMX.TestData.CurrentTestScenario, null);

                result = true;
            }
            */
            return result;
        }
        
        public static bool AddTestScenario(AddScenarioCmdletBase cmdlet)
        {
            bool result = false;
            result = 
                TMX.TestData.AddTestScenario(cmdlet.InputObject,
                                             cmdlet.Name,
                                             cmdlet.Id,
                                             cmdlet.Description,
                                             cmdlet.TestSuiteName,
                                             cmdlet.TestSuiteId,
                                             cmdlet.TestPlatformId,
                                             cmdlet.BeforeTest,
                                             cmdlet.AfterTest);
            
            return result;
        }
        
        // 20130331
//        public static bool AddTestResultTextDetail(string testResultTextDetail)
//        {
//            bool result = false;
//            
//            // 20130331
//            //TMX.TestData.AddTestResultTextDetail(testResultTextDetail);
//            TMX.TestData.AddTestResultTextDetail(testResultTextDetail);
//            
//            return result;
//        }
        
        public static bool AddTestResultScreenshotDetail(string testResultScreenshotDetail)
        {
            bool result = false;
            
            TMX.TestData.AddTestResultScreenshotDetail(testResultScreenshotDetail);
            
            return result;
        }
        
        public static bool AddTestResultErrorDetail(ErrorRecord testResultErrorDetail)
        {
            bool result = false;
            
            // 20130702
            try {
                TMX.TestData.AddTestResultErrorDetail(testResultErrorDetail);
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
            InvocationInfo myInvocation,
            ErrorRecord error,
            string description,
            TestResultOrigins origin,
            bool skipAutomatic)
        {
            // 20121224
            //bool result = false;
            
//            if (TestData.TestSuites.Count == 0) {
//                TestData.InitTestData();
//            }

            TMX.TestData.AddTestResult(
                testResultName, 
                testResultId, 
                testResult, 
                isKnownIssue,
                true,
                myInvocation,
                error,
                description,
                origin,
                skipAutomatic);
        }
        #endregion Actions
        
        #region Import/export test structure
        public static bool ImportTestStructure(string path)
        {
            bool result = false;
            
            
            return result;
        }
        
        public static bool ExportTestStructure(string path)
        {
            bool result = false;
            
            
            return result;
        }
        #endregion Import/export test structure
        
        #region Export results
        
            #region export to XML
        public static XElement CreateSuitesXElementWithParameters(
                IOrderedEnumerable<TestSuite> suites,
                IOrderedEnumerable<TestScenario> scenarios,
                IOrderedEnumerable<TestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {

            XElement suitesElement = 
                new XElement(xmlStruct.SuitesNode,
                             from suite in suites
                             select new XElement(xmlStruct.SuiteNode,
                                                 new XAttribute("id", suite.Id),
                                                 new XAttribute("name", suite.Name),
                                                 new XAttribute("status", suite.Status),
                                                 TmxHelper.CreateXAttribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(suite.Statistics.TimeSpent)),
                                                 new XAttribute("all", suite.Statistics.All.ToString()),
                                                 new XAttribute("passed", suite.Statistics.Passed.ToString()),
                                                 TmxHelper.CreateXAttribute(xmlStruct.FailedAttribute, suite.Statistics.Failed.ToString()),
                                                 new XAttribute("notTested", suite.Statistics.NotTested.ToString()),
                                                 new XAttribute("knownIssue", suite.Statistics.PassedButWithBadSmell.ToString()),
                                                 TmxHelper.CreateXAttribute("description", suite.Description),
                                                 // 20130603
                                                 TmxHelper.CreateXAttribute("platformId", suite.PlatformId),
                                                 TmxHelper.CreateScenariosXElementCommon(
                                                     suite,
                                                     scenarios,
                                                     testResults,
                                                     xmlStruct)
                                                 )
                            );
            return suitesElement;
        }
            
        public static XElement CreateScenariosXElementCommon(
                TMX.TestSuite suite,
                IOrderedEnumerable<TestScenario> scenarios,
                IOrderedEnumerable<TestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {

            var testScenariosFiltered = 
                from scenario in scenarios
                where scenario.SuiteId == suite.Id
                select scenario;

            if (!testScenariosFiltered.Any()) {
                return null;
            }

            /*
            if (0 == testScenariosFiltered.Count()) {
                return null;
            }
            */

            XElement scenariosElement = 
                 new XElement(xmlStruct.ScenariosNode,
                              from scenario in testScenariosFiltered
                              select getScenariosXElement(
                                  suite, 
                                  scenario, 
                                  testResults, 
                                  xmlStruct)
                             );
            return scenariosElement;
        }
            
        private static XElement getScenariosXElement(
                TMX.TestSuite suite,
                TMX.TestScenario scenario,
                IOrderedEnumerable<TestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {

            XElement scenariosElement =
                new XElement(xmlStruct.ScenarioNode,
                             new XAttribute("id", scenario.Id),
                             new XAttribute("name", scenario.Name),
                             new XAttribute("status", scenario.Status),
                             TmxHelper.CreateXAttribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(suite.Statistics.TimeSpent)),
                             new XAttribute("all", scenario.Statistics.All.ToString()),
                             new XAttribute("passed", scenario.Statistics.Passed.ToString()),
                             TmxHelper.CreateXAttribute(xmlStruct.FailedAttribute, scenario.Statistics.Failed.ToString()),
                             new XAttribute("notTested", scenario.Statistics.NotTested.ToString()),
                             new XAttribute("knownIssue", scenario.Statistics.PassedButWithBadSmell.ToString()),
                             TmxHelper.CreateXAttribute("description", scenario.Description),
                             // 20130603
                             TmxHelper.CreateXAttribute("platformId", scenario.PlatformId),
                             TmxHelper.CreateTestResultsXElementCommon(
                                 suite,
                                 scenario,
                                 testResults,
                                 xmlStruct)
                            );

            return scenariosElement;
        }
            
        public static XElement CreateTestResultsXElementCommon(
                TMX.TestSuite suite,
                TMX.TestScenario scenario,
                IOrderedEnumerable<TestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {

            var testResultsFiltered = 
                from testResult in testResults
                where testResult.SuiteId == suite.Id &&
                testResult.ScenarioId == scenario.Id &&
                testResult.Id != null &&
                testResult.Name != null
                select testResult;

            if (!testResultsFiltered.Any()) {
                return null;
            }

            /*
            if (0 == testResultsFiltered.Count()) {
                return null;
            }
            */

            XElement testResultsElement =
                new XElement(xmlStruct.TestResultsNode,
                             from testResult in testResultsFiltered
                             select getTestResultsXElement(testResult, xmlStruct)
                            );

            return testResultsElement;
        }
            
        private static XElement getTestResultsXElement(
                TMX.TestResult testResult,
                IXMLElementsStruct xmlStruct)
        {

            XElement testResultsElement =
                new XElement(xmlStruct.TestResultNode,
                             new XAttribute("id", testResult.Id),
                             new XAttribute("name", testResult.Name),
                             new XAttribute("status", testResult.Status),
                             // 20130626
                             new XAttribute("origin", testResult.Origin),
                             TmxHelper.CreateXAttribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(testResult.TimeSpent)), // ??
                             TmxHelper.CreateXElement(
                                 "source",
                                 TmxHelper.CreateXAttribute("scriptName", testResult.ScriptName),
                                 TmxHelper.CreateXAttribute("lineNumber", testResult.LineNumber),
                                 TmxHelper.CreateXAttribute("position", testResult.Position),
                                 TmxHelper.CreateXAttribute("code", testResult.Code)
                                ),
                             TmxHelper.CreateXAttribute(xmlStruct.TimeStampAttribute, testResult.Timestamp),
                             TmxHelper.CreateXElement(
                                 "error",
                                 TmxHelper.CreateXAttribute("error", testResult.Error)
                                ),
                             TmxHelper.CreateXAttribute("screenshot", testResult.Screenshot),
                             TmxHelper.CreateXAttribute("description", testResult.Description),
                             // 20130603
                             TmxHelper.CreateXAttribute("platformId", testResult.PlatformId),
                             TmxHelper.CreateTestResultDetailsXElement(
                                 testResult,
                                 xmlStruct)
                            );

            return testResultsElement;
        }
            
        public static XElement CreateTestResultDetailsXElement(
                TMX.TestResult testResult,
                IXMLElementsStruct xmlStruct)
        {

            if (0 == testResult.Details.Count) {
                return null;
            }

            XElement testResultDetailsElement =
                new XElement("details",
                             from testResultDetail in testResult.Details
                             select new XElement("detail", 
                                                 TmxHelper.CreateXAttribute("name", testResultDetail.Name),
                                                 TmxHelper.CreateXAttribute(xmlStruct.TimeSpentAttribute, testResultDetail.Timestamp),
                                                 TmxHelper.CreateXAttribute("status", testResultDetail.DetailStatus)
                                                )
                            );

            return testResultDetailsElement;
        }
        
        /// <summary>
        /// Performs parametrized search for all types of TMX objects and stores
        /// the findings by the path provided.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <param name="path"></param>
        public static void ExportResultsToXML(SearchCmdletBase cmdlet, string path)
        {
            try {
            
                GatherTestResultsCollections gathered =
                    new GatherTestResultsCollections();
                gathered.GatherCollections(cmdlet);
                
                cmdlet.WriteVerbose(cmdlet, "converting data to XML");
                XElement suitesElement = 
                    TmxHelper.CreateSuitesXElementWithParameters(
                        gathered.TestSuites,
                        gathered.TestScenarios,
                        gathered.TestResults,
                        (new XMLElementsNativeStruct(cmdlet)));
                
                cmdlet.WriteVerbose(cmdlet, "creating an XML document");
                System.Xml.Linq.XDocument document =
                    new System.Xml.Linq.XDocument();
                cmdlet.WriteVerbose(cmdlet, "adding XML data to the document");
                document.Add(suitesElement);
                cmdlet.WriteVerbose(
                    cmdlet, 
                    "saving XML to the file '" + 
                    path +
                    "'.");
                document.Save(path);
                cmdlet.WriteVerbose(cmdlet, "the document is saved");
            }
            catch (Exception eCreateDocument) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to save XML report to the file '" +
                    path +
                    "'. " + 
                    eCreateDocument.Message,
                    "FailedToSaveReport",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
            #endregion export to XML
        
        #endregion Export results
        
        #region Search
        /// <summary>
        /// Performs parametrized search for Test Suites.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<TestSuite> SearchForSuites(SearchCmdletBase cmdlet)
        {
            IOrderedEnumerable<TestSuite> suites = null;
            //IQueryable<TestSuite> suites = null;
            
            // Filtering results
            
            // default result
            Func<TestSuite, bool> query = suite => true;
            
            // 20130203
//            System.Collections.Generic.List<Func<TestSuite, bool>> queriesList =
//                new List<Func<TestSuite, bool>>();
//            queriesList.Add(query);
            
            if (!string.IsNullOrEmpty(cmdlet.FilterNameContains)) {
            // if (cmdlet.FilterNameContains != null && cmdlet.FilterNameContains.Length > 0) {
                // 20130203
                query = suite => suite.Name.Contains(cmdlet.FilterNameContains);
                //queriesList.Add((suite => suite.Name.Contains(cmdlet.FilterNameContains)));
                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterIdContains)) {
            // } else if (cmdlet.FilterIdContains != null && cmdlet.FilterIdContains.Length > 0) {
                // 20130203
                query = suite => suite.Id.Contains(cmdlet.FilterIdContains);
                //queriesList.Add((suite => suite.Id.Contains(cmdlet.FilterIdContains)));
                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterDescriptionContains)) {
            // } else if (cmdlet.FilterDescriptionContains != null && cmdlet.FilterDescriptionContains.Length > 0) {
                // 20130203
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
                // 20130203
                query = suite => suite.enStatus == TestSuiteStatuses.Passed;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.Passed));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterFailed) {
                // 20130203
                query = suite => suite.enStatus == TestSuiteStatuses.Failed;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.Failed));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterNotTested) {
                // 20130203
                query = suite => suite.enStatus == TestSuiteStatuses.NotTested;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.NotTested));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassedWithBadSmell) {
                // 20130203
                query = suite => suite.enStatus == TestSuiteStatuses.KnownIssue;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.KnownIssue));
                cmdlet.FilterAll = false;
            }
            if (cmdlet.FilterAll) {
                query = suite => true;
            }
            // 20121006
            if (cmdlet.FilterNone) {
                query = suite => false;
                // 20130203
                //queriesList.Clear();
                //queriesList.Add(query);
            }
            
            // Ordering results
            
            // default result
            Func<TestSuite, object> ordering = suite => suite.Id;
            
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
                ordering += suite => 
                    {
                        // 20130322
                        //TMX.TestData.RefreshSuiteStatistics(suite);
                        TMX.TestData.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
                        return (suite.Statistics.Passed / suite.Statistics.All);
                    };
            } 
            if (cmdlet.OrderByFailRate) {
                ordering += suite => 
                    {
                        // 20130322
                        //TMX.TestData.RefreshSuiteStatistics(suite);
                        TMX.TestData.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
                        return (suite.Statistics.Failed / suite.Statistics.All);
                    };
            } 

            cmdlet.WriteVerbose(cmdlet, "query = " + query.ToString());
            cmdlet.WriteVerbose(cmdlet, "ordering = " + ordering.ToString());
            
            suites = 
                TMX.TestData.SearchTestSuite(
                    // 20130203
                    query,
                    //Combine<TestSuite, bool>((x, y) => x && y, queriesList.ToArray()),
                    ordering,
                    cmdlet.Descending);

            return suites;
        }
        
        public static void SearchForSuitesPS(SearchCmdletBase cmdlet)
        {
            IOrderedEnumerable<TestSuite> suites =
                SearchForSuites(cmdlet);
            
            if (suites.Any()) {
                cmdlet.WriteObject(suites, true);
            } else {
                cmdlet.WriteObject(null);
            }

            /*
            if (suites.Count<TMX.TestSuite>() > 0) {
                cmdlet.WriteObject(suites, true);
            } else {
                cmdlet.WriteObject(null);
            }
            */
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
        public static IOrderedEnumerable<TestScenario> SearchForScenarios(SearchCmdletBase cmdlet)
        {
            IOrderedEnumerable<TestScenario> scenarios = null;
            
            // Filtering results
            
            // default result
            Func<TestScenario, bool> query = scenario => true;
            
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
                query = scenario => scenario.enStatus == TestScenarioStatuses.Passed;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterFailed) {
                query = scenario => scenario.enStatus == TestScenarioStatuses.Failed;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterNotTested) {
                query = scenario => scenario.enStatus == TestScenarioStatuses.NotTested;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassedWithBadSmell) {
                query = scenario => scenario.enStatus == TestScenarioStatuses.KnownIssue;
                cmdlet.FilterAll = false;
            }
            if (cmdlet.FilterAll) {
                query = scenario => true;
            }
            // 20121006
            if (cmdlet.FilterNone) {
                query = scenario => false;
            }
            
            // Ordering results
            
            // default result
            Func<TestScenario, object> ordering = scenario => scenario.Id;
            
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
            
            cmdlet.WriteVerbose(cmdlet, "query = " + query.ToString());
            cmdlet.WriteVerbose(cmdlet, "ordering = " + ordering.ToString());
            
            scenarios = 
                TMX.TestData.SearchTestScenario(
                    query,
                    ordering,
                    cmdlet.Descending);
            
            return scenarios;
        }
        
        public static void SearchForScenariosPS(SearchCmdletBase cmdlet)
        {
            IOrderedEnumerable<TestScenario> scenarios =
                SearchForScenarios(cmdlet);
            
            if (scenarios.Any()) {
                cmdlet.WriteObject(scenarios, true);
            } else {
                cmdlet.WriteObject(null);
            }

            /*
            if (scenarios.Count<TMX.TestScenario>() > 0) {
                cmdlet.WriteObject(scenarios, true);
            } else {
                cmdlet.WriteObject(null);
            }
            */
        }
        
        /// <summary>
        /// Performs parametrized search for Test Results.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<TestResult> SearchForTestResults(SearchCmdletBase cmdlet)
        {
            IOrderedEnumerable<TestResult> testResults = null;

            // Filtering results
            
            // default result
            Func<TestResult, bool> query = testResult => true;
            
            if (!string.IsNullOrEmpty(cmdlet.FilterNameContains)) {
            // if (cmdlet.FilterNameContains != null && cmdlet.FilterNameContains.Length > 0) {
                query = testResult => testResult.Name != null && testResult.Name.Contains(cmdlet.FilterNameContains);

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

                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterIdContains)) {
            // } else if (cmdlet.FilterIdContains != null && cmdlet.FilterIdContains.Length > 0) {
                query = testResult => testResult.Id != null && testResult.Id.Contains(cmdlet.FilterIdContains);

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

                cmdlet.FilterAll = false;
            } else if (!string.IsNullOrEmpty(cmdlet.FilterDescriptionContains)) {
            // } else if (cmdlet.FilterDescriptionContains != null && cmdlet.FilterDescriptionContains.Length > 0) {
                query = testResult => testResult.Description != null && testResult.Description.Contains(cmdlet.FilterDescriptionContains);

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

                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassed) {
                query = testResult => testResult.enStatus == TestResultStatuses.Passed;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterFailed) {
                query = testResult => testResult.enStatus == TestResultStatuses.Failed;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterNotTested) {
                query = testResult => testResult.enStatus == TestResultStatuses.NotTested;
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassedWithBadSmell) {
                query = testResult => testResult.enStatus == TestResultStatuses.KnownIssue;
                cmdlet.FilterAll = false;
            } // 20130322
            else if (cmdlet.FilterOutAutomaticResults) {
                query = testResult => testResult.Origin != TestResultOrigins.Automatic;
                cmdlet.FilterAll = false;
            }
            // 20130626
            else if (cmdlet.FilterOutAutomaticAndTechnicalResults) {
                query = testResult => testResult.Origin != TestResultOrigins.Automatic && testResult.Origin != TestResultOrigins.Technical;
                cmdlet.FilterAll = false;
            }
            if (cmdlet.FilterAll) {
                query = testResult => true;
            }
            // 20121006
            if (cmdlet.FilterNone) {
                query = testResult => false;
            }
            
            // Ordering results
            
            // default result
            Func<TestResult, object> ordering = testResult => testResult.Id;
            
            if (cmdlet.OrderByTimeSpent) {
                ordering = testResult => testResult.TimeSpent;
            } else if (cmdlet.OrderByDateTime) {
                ordering = testResult => testResult.Timestamp;
            } else if (cmdlet.OrderByName) {
                ordering = testResult => testResult.Name;
            } else if (cmdlet.OrderById) {
                ordering = testResult => testResult.Id;
            }
            
            cmdlet.WriteVerbose(cmdlet, "query = " + query.ToString());
            cmdlet.WriteVerbose(cmdlet, "ordering = " + ordering.ToString());

            testResults = 
                TMX.TestData.SearchTestResult(
                    query,
                    ordering,
                    cmdlet.Descending);

            return testResults;
        }
        
        public static void SearchForTestResultsPS(SearchCmdletBase cmdlet)
        {
            IOrderedEnumerable<TestResult> testResults =
                SearchForTestResults(cmdlet);
            
            if (testResults.Any()) {
                cmdlet.WriteObject(testResults, true);
            } else {
                cmdlet.WriteObject(null);
            }

            /*
            if (testResults.Count<TMX.TestResult>() > 0) {
                cmdlet.WriteObject(testResults, true);
            } else {
                cmdlet.WriteObject(null);
            }
            */
        }
        
        internal static XAttribute CreateXAttribute(string name, object valueObject)
        {
            XAttribute result = null;
            
            if (null == valueObject) {
                return null;
            }
            
            result = new XAttribute(name, valueObject);
            
            return result;
        }
        
        internal static XElement CreateXElement(string name, params object[] content)
        {
            XElement result = null;
            
            if (null == content[0]) {
                return null;
            }
            
            result = new XElement(name, content);
            
            return result;
        }
        #endregion Search
        
        #region Test settings
        public static void ExportTestSettings(
            SettingsCmdletBase cmdlet,
            string path,
            string[] variableNames)
        {
            try {
                XElement rootElement = 
                    new XElement("variables");
                
                foreach (string variableName in variableNames) {
                    PSVariable variable = 
                        cmdlet.SessionState.PSVariable.Get(variableName);
                    try {
                        if (string.IsNullOrEmpty(variable.Name)) continue;
                        // if (null != variable.Name && string.Empty != variable.Name) {
                        XElement variableElement =
                            new XElement("variable",
                                new XAttribute("name", variable.Name),
                                new XAttribute("value", variable.Value));
                        rootElement.Add(variableElement);

                        /*
                        if (!string.IsNullOrEmpty(variable.Name)) {
                        // if (null != variable.Name && string.Empty != variable.Name) {
                            XElement variableElement =
                                new XElement("variable",
                                             new XAttribute("name", variable.Name),
                                             new XAttribute("value", variable.Value));
                            rootElement.Add(variableElement);
                        }
                        */
                    }
                    catch (Exception eVariable) {
                        cmdlet.WriteError(
                            cmdlet,
                            "Unable to export variable '" +
                            variableName +
                            "'.",
                            "FailedToExportVariable",
                            ErrorCategory.InvalidArgument,
                            false);
                    }
                }
                
                System.Xml.Linq.XDocument document =
                    new System.Xml.Linq.XDocument();
                document.Add(rootElement);
                document.Save(path);
            }
            catch (Exception eCreateDocument) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to save XML report to the file '" +
                    path +
                    "'. " + 
                    eCreateDocument.Message,
                    "FailedToSaveReport",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        
        public static void ImportTestSettings(
            SettingsCmdletBase cmdlet,
            string path,
            string[] variableNames)
        {
            XElement wholeXML =
                XElement.Load(path);
            
            // default result
            Func<IEnumerable<string>, XElement, bool> query = (variableNamesCollection, variableElement) => true;
            
            cmdlet.WriteVerbose(cmdlet, "checking the VariableName list");
            if (null != variableNames && variableNames.Any()) {
                cmdlet.WriteVerbose(cmdlet, "the VariableName list is not empty");
                query = (variableNamesCollection, variableElement) => variableNamesCollection.Contains(variableElement.Attribute((XName)"name").Value);
            }

            /*
            if (null != variableNames && 0 < variableNames.Count()) {
                cmdlet.WriteVerbose(cmdlet, "the VariableName list is not empty");
                query = (variableNamesCollection, variableElement) => variableNamesCollection.Contains(variableElement.Attribute((XName)"name").Value);
            }
            */

            cmdlet.WriteVerbose(cmdlet, "getting the variables collection");
            var variablesCollection = 
                from variableElement in wholeXML.Elements()
                where query(((IEnumerable<string>)variableNames), variableElement)
                    select variableElement;
            
            cmdlet.WriteVerbose(cmdlet, "collection created");
            
            if (null == variablesCollection || !variablesCollection.Any()) {
                cmdlet.WriteVerbose(cmdlet, "there are no variables to import");
                return;
            }

            /*
            if (null == variablesCollection || 0 == variablesCollection.Count()) {
                cmdlet.WriteVerbose(cmdlet, "there are no variables to import");
                return;
            }
            */

            TmxHelper.ImportVariables(cmdlet, variablesCollection);
        }
        
        public static bool ImportVariables(
            SettingsCmdletBase cmdlet,
            IEnumerable<XElement> variablesCollection)
        {
            bool result = false;
            
            foreach (XElement element in variablesCollection) {
                
                string variableName = string.Empty;
                
                try {
                
                    variableName =
                            element.Attribute((XName)"name").Value;
                    
                    cmdlet.WriteVerbose(cmdlet, "importing the '" + variableName + "' variable");
                    
                    string variableValue =
                        string.Empty;
                    try {
                        variableValue =
                            element.Attribute((XName)"value").Value;
                    }
                    catch {
                        // nothing to do
                    }
                        
                    //ScopedItemOptions.AllScope
                    //ScopedItemOptions.Constant
                    //ScopedItemOptions.None
                    //ScopedItemOptions.Private
                    //ScopedItemOptions.ReadOnly
                    //ScopedItemOptions.Unspecified
                
                    PSVariable variable = 
                        new PSVariable(
                            variableName,
                            variableValue);
                    cmdlet.SessionState.PSVariable.Set(variable);
                }
                catch (Exception eLoadingVariable) {
                    cmdlet.WriteError(
                        cmdlet,
                        "Unable to load variable '" +
                        variableName +
                        "'. " +
                        eLoadingVariable.Message,
                        "FailedToLoadVariable",
                        ErrorCategory.InvalidData,
                        false);
                }
            }

            return result;
        }
        #endregion Test settings
        
        public static void ExportResultsToJUnitXML(SearchCmdletBase cmdlet, string path)
        {
            try {

                GatherTestResultsCollections gathered =
                    new GatherTestResultsCollections();
                gathered.GatherCollections(cmdlet);
                
                cmdlet.WriteVerbose(cmdlet, "converting data to XML");
                XElement suitesElement = 
                    TmxHelper.CreateSuitesXElementWithParameters(
                        gathered.TestSuites,
                        gathered.TestScenarios,
                        gathered.TestResults,
                        (new XMLElementsJUnitStruct(cmdlet)));
                
                cmdlet.WriteVerbose(cmdlet, "creating an XML document");
                System.Xml.Linq.XDocument document =
                    new System.Xml.Linq.XDocument();
                cmdlet.WriteVerbose(cmdlet, "adding XML data to the document");
                document.Add(suitesElement);
                cmdlet.WriteVerbose(
                    cmdlet, 
                    "saving XML to the file '" + 
                    path +
                    "'.");
                document.Save(path);
                cmdlet.WriteVerbose(cmdlet, "the document is saved");
            }
            catch (Exception eCreateDocument) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to save XML report to the file '" +
                    path +
                    "'. " + 
                    eCreateDocument.Message,
                    "FailedToSaveReport",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        
        public static void GetCurrentTestSuiteStatus(OpenSuiteCmdletBase cmdlet, bool skipAutomatic)
        {
            if (null == TestData.CurrentTestSuite) return;
            // 20130322
            //TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite);
            TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite.Status);

            /*
            if (null != TestData.CurrentTestSuite) {
                
                // 20130322
                //TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite);
                TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite.Status);
            }
            */
        }
        
        public static void GetTestSuiteStatusByName(OpenSuiteCmdletBase cmdlet, string name, string testPlatformId, bool skipAutomatic)
        {
            TmxHelper.OpenTestSuite(
                name,
                string.Empty,
                testPlatformId);
            if (null == TestData.CurrentTestSuite) return;
            // 20130322
            //TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite);
            TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite.Status);

            /*
            if (null != TestData.CurrentTestSuite) {
                
                // 20130322
                //TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite);
                TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite.Status);
            }
            */
        }
        
        public static void GetTestSuiteStatusById(OpenSuiteCmdletBase cmdlet, string id, string testPlatformId, bool skipAutomatic)
        {
            TmxHelper.OpenTestSuite(
                string.Empty,
                id,
                testPlatformId);
            if (null == TestData.CurrentTestSuite) return;
            // 20130322
            //TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite);
            TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite.Status);

            /*
            if (null != TestData.CurrentTestSuite) {
                
                // 20130322
                //TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite);
                TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite.Status);
            }
            */
        }
        
        public static void GetCurrentTestScenarioStatus(OpenScenarioCmdletBase cmdlet, bool skipAutomatic)
        {
            if (null == TestData.CurrentTestScenario) return;
            // 20130322
            //TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario);
            TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
            cmdlet.WriteObject(cmdlet, TestData.CurrentTestScenario.Status);

            /*
            if (null != TestData.CurrentTestScenario) {
                
                // 20130322
                //TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario);
                TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestScenario.Status);
            }
            */
        }
        
        public static void GetTestScenarioStatus(OpenScenarioCmdletBase cmdlet, bool skipAutomatic)
        {
            TmxHelper.OpenTestScenario(cmdlet);
            if (null == TestData.CurrentTestScenario) return;
            // 201330322
            //TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario);
            TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
            cmdlet.WriteObject(cmdlet, TestData.CurrentTestScenario.Status);

            /*
            if (null != TestData.CurrentTestScenario) {
                
                // 201330322
                //TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario);
                TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestScenario.Status);
            }
            */
        }
        
        public static void SetCurrentTestResult(TestResultCmdletBase cmdlet)
        {
            if (null != TestData.CurrentTestResult) {

                TestData.CurrentTestResult.Name = !string.IsNullOrEmpty(cmdlet.TestResultName) ? cmdlet.TestResultName : "this test result is not provided with name";

                /*
                if (!string.IsNullOrEmpty(cmdlet.TestResultName)) {
                // if (null != cmdlet.TestResultName && 0 < cmdlet.TestResultName.Length) {

                    TestData.CurrentTestResult.Name = cmdlet.TestResultName;
                } else {
                    
                    // 20130819
                    //TestData.CurrentTestResult.Name = "this test result was preset";
                    // this is a potential bug
                    
                    // 20130918
                    TestData.CurrentTestResult.Name = "this test result is not provided with name";
                }
                */

                if (!string.IsNullOrEmpty(cmdlet.Id)) {
                // if (null != cmdlet.Id && 0 < cmdlet.Id.Length) {

                    TestData.CurrentTestResult.Id = cmdlet.Id;
                } else {
                    
                    TestData.GetTestResultId();
                }
                
                if (!string.IsNullOrEmpty(cmdlet.Description)) {
                // if (null != cmdlet.Description && 0 < cmdlet.Description.Length) {

                    TestData.CurrentTestResult.Description = cmdlet.Description;
                }

                // 20130330
                //TestData.CurrentTestResult.enStatus = TestResultStatuses.Failed;
                TestData.CurrentTestResult.enStatus = TestResultStatuses.NotTested;

                if (cmdlet.KnownIssue) {

                    TestData.CurrentTestResult.enStatus = TestResultStatuses.KnownIssue;
                }
                
                // 20130627
                //TestData.CurrentTestResult.SetOrigin(TestResultOrigins.Logical);
                TestData.CurrentTestResult.SetOrigin(cmdlet.TestOrigin);

            } else {

                // there always is the current test result
            }
        }
        
        public static void GetCurrentTestResultStatus(TestResultCmdletBase cmdlet)
        {
            // 20130403
            string testResultId = cmdlet.Id;
            
            cmdlet.WriteVerbose(cmdlet, "Getting test result with Id = " + testResultId);
            
            if (!string.IsNullOrEmpty(testResultId)) {
            // if (null != testResultId && string.Empty != testResultId && 0 < testResultId.Length) {
            
//                if (null != TestData.CurrentTestResult) {
//                    cmdlet.WriteObject(cmdlet, TestData.CurrentTestResult.Status);
//                } else {
//                    cmdlet.WriteObject(cmdlet, "NOT TESTED");
//                }
                
                
                
                
                
                
                
                
                
                
                
                cmdlet.WriteVerbose(cmdlet, "Trying to get a test result with Id = " + testResultId);
                
                var testResultWithIdCollection =
                    from testResult in TestData.CurrentTestScenario.TestResults
                    where testResult.Id == testResultId
                    select testResult;

                if (null == testResultWithIdCollection || !testResultWithIdCollection.Any()) return;
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

            } else {
                
                cmdlet.WriteVerbose(cmdlet, "Trying the current test result");

                if (null == TestData.CurrentTestResult) return;
                cmdlet.WriteVerbose(cmdlet, "The current test result");
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestResult.Status);

                /*
                if (null != TestData.CurrentTestResult) {
                    
                    cmdlet.WriteVerbose(cmdlet, "The current test result");
                    cmdlet.WriteObject(cmdlet, TestData.CurrentTestResult.Status);
                }
                */

            }
        }
        
        public static void GetTestResultDetails(TestResultStatusCmdletBase cmdlet)
        {
            string testResultId = cmdlet.Id;
            
            cmdlet.WriteVerbose(cmdlet, "Getting test result with Id = " + testResultId);
            
            if (!string.IsNullOrEmpty(testResultId)) {
            // if (null != testResultId && string.Empty != testResultId && 0 < testResultId.Length) {
                
                cmdlet.WriteVerbose(cmdlet, "Trying to get a test result with Id = " + testResultId);
                
                var testResultWithIdCollection =
                    from testResult in TestData.CurrentTestScenario.TestResults
                    where testResult.Id == testResultId
                    select testResult;

                if (null == testResultWithIdCollection || !testResultWithIdCollection.Any()) return;
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

            } else {
                
                cmdlet.WriteVerbose(cmdlet, "Trying the current test result");

                if (null == TestData.CurrentTestResult) return;
                cmdlet.WriteVerbose(cmdlet, "The current test result");
                cmdlet.WriteObject(cmdlet, TestData.CurrentTestResult.ListDetailNames(cmdlet));

                /*
                if (null != TestData.CurrentTestResult) {
                    
                    cmdlet.WriteVerbose(cmdlet, "The current test result");
                    cmdlet.WriteObject(cmdlet, TestData.CurrentTestResult.ListDetailNames(cmdlet));
                }
                */
            }
        }
        
        public static void ImportResultsFromXML(ImportExportCmdletBase cmdlet, string path)
        {
            
            string lastTestSuiteName = string.Empty;
            string lastTestScenarioName = string.Empty;
            string lastTestResultName = string.Empty;
            string lastTestResultDetailName = string.Empty;
            
            try {
            
                if (!System.IO.File.Exists(cmdlet.Path)) {
                    
                    cmdlet.WriteError(
                        cmdlet,
                        "There is no such file '" +
                        cmdlet.Path +
                        "'.",
                        "NoSuchFile",
                        ErrorCategory.InvalidArgument,
                        true);
                }
                
                TestSuite currentTestSuite = TMX.TestData.CurrentTestSuite;
                TestScenario currentTestScenario = TMX.TestData.CurrentTestScenario;
                ITestResult currentTestResult = TMX.TestData.CurrentTestResult;
                
                TMX.TestData.CurrentTestSuite = null;
                TMX.TestData.CurrentTestScenario = null;
                TMX.TestData.CurrentTestResult = null;
                
                XDocument doc = XDocument.Load(cmdlet.Path);
                XNamespace df = doc.Root.Name.Namespace;
                var suites = from suite in doc.Descendants("suite")
                    where suite.Attribute("name").Value != "autogenerated"
                    select suite;
                
                foreach (var singleSuite in suites) {
                    
                    cmdlet.WriteVerbose(cmdlet, "importing suite '" + singleSuite.Attribute("name").Value + "'");
                    lastTestSuiteName = singleSuite.Attribute("name").Value;
                    
                    string suiteDescription = string.Empty;
                    try {
                        suiteDescription = singleSuite.Attribute("description").Value;
                    }
                    catch {}
                    
                    TestSuite testSuite =
                        TMX.TestData.GetTestSuite(
                            singleSuite.Attribute("name").Value,
                            singleSuite.Attribute("id").Value,
                            singleSuite.Attribute("platformId").Value);
                    TMX.TestData.CurrentTestSuite = testSuite;
                    
                    if (null == testSuite) {
                        TMX.TestData.AddTestSuite(
                            singleSuite.Attribute("name").Value,
                            singleSuite.Attribute("id").Value,
                            singleSuite.Attribute("platformId").Value,
                            suiteDescription,
                            null,
                            null);
                    }
                    
                    var scenarios = from scenario in singleSuite.Descendants("scenario")
                        where scenario.Attribute("name").Value != "autogenerated"
                        select scenario;
                    
                    foreach (var singleScenario in scenarios) {
                        
                        cmdlet.WriteVerbose(cmdlet, "importing scenario '" + singleScenario.Attribute("name").Value + "'");
                        lastTestScenarioName = singleScenario.Attribute("name").Value;
                        
                        string scenarioDescription = string.Empty;
                        try {
                            scenarioDescription = singleScenario.Attribute("description").Value;
                        }
                        catch {}
                        
                        TestScenario testScenario =
                            TMX.TestData.GetTestScenario(
                                TMX.TestData.CurrentTestSuite,
                                singleScenario.Attribute("name").Value,
                                singleScenario.Attribute("id").Value,
                                TMX.TestData.CurrentTestSuite.Name,
                                TMX.TestData.CurrentTestSuite.Id,
                                TMX.TestData.CurrentTestSuite.PlatformId);
                        TMX.TestData.CurrentTestScenario = testScenario;
                        
                        if (null == testScenario) {
                            TMX.TestData.AddTestScenario(
                                TMX.TestData.CurrentTestSuite,
                                singleScenario.Attribute("name").Value,
                                singleScenario.Attribute("id").Value,
                                scenarioDescription,
                                string.Empty,
                                string.Empty,
                                singleScenario.Attribute("platformId").Value,
                                null,
                                null);
                        }
                        
                        var testResults = from testResult in singleScenario.Descendants("testResult")
                            //where testResult.Attribute("name").Value != "autoclosed"
                            select testResult;
                        
                        foreach (var singleTestResult in testResults) {
                            
                            cmdlet.WriteVerbose(cmdlet, "importing test result '" + singleTestResult.Attribute("name").Value + "', id = '" + singleTestResult.Attribute("id").Value + "'");
                            lastTestResultName = singleTestResult.Attribute("name").Value;
                            
                            bool passedValue = false;
                            bool knownIssueValue = false;
                            try {
                                if ("PASSED" == singleTestResult.Attribute("status").Value) {
                                    passedValue = true;
                                }
                                if ("KNOWN ISSUE" == singleTestResult.Attribute("status").Value) {
                                    knownIssueValue = true;
                                }
                            }
                            catch {}
                            
                            TestResultOrigins origin = TestResultOrigins.Logical;
                            try {
                                if ("TECHNICAL" == singleTestResult.Attribute("origin").Value.ToUpper()) {
                                    origin = TestResultOrigins.Technical;
                                }
                                if ("AUTOMATIC" == singleTestResult.Attribute("origin").Value.ToUpper()) {
                                    origin = TestResultOrigins.Automatic;
                                }
                            }
                            catch {}
                            
                            if ((TestResultOrigins.Technical == origin) &&
                                //(!knownIssueValue &&
                                 passedValue) {
                                
                                continue;
                            }
                            
                            string testResultDescription = string.Empty;
                            try {
                                testResultDescription = singleTestResult.Attribute("description").Value;
                            }
                            catch {}
                            
                            TMX.TestData.AddTestResult(
                                singleTestResult.Attribute("name").Value,
                                singleTestResult.Attribute("id").Value,
                                passedValue,
                                knownIssueValue,
                                false,
                                null,
                                null,
                                testResultDescription,
                                origin,
                                true);
                            
                            ITestResult currentlyAddedTestResult = TMX.TestData.CurrentTestScenario.TestResults[TMX.TestData.CurrentTestScenario.TestResults.Count - 1];
                            
                            try {
                                currentlyAddedTestResult.PlatformId =
                                    singleTestResult.Attribute("platformId").Value;
                            }
                            catch (Exception eTestResultPlatform) {
                                cmdlet.WriteVerbose(cmdlet, "adding test platform to the current test result");
                                cmdlet.WriteVerbose(cmdlet, eTestResultPlatform.Message);
                            }
                            
                            try {
                                lastTestResultDetailName = string.Empty;
                                
                                var testResultDetails = from testResultDetail in singleTestResult.Descendants("detail")
                                    select testResultDetail;

                                if (null == testResultDetails || !testResultDetails.Any()) continue;
                                // if (null != testResultDetails && 0 < testResultDetails.Count()) {
                                foreach (var singleDetail in testResultDetails) {
                                        
                                    cmdlet.WriteVerbose(cmdlet, "importing test result detail '" + singleDetail.Attribute("name").Value + "', status = '" + singleDetail.Attribute("status").Value + "'");
                                    lastTestResultDetailName = singleDetail.Attribute("name").Value;
                                        
                                    TestResultDetail detail = new TestResultDetail
                                    {
                                        TextDetail = singleDetail.Attribute("name").Value
                                    };
                                    // TestResultDetail detail = new TestResultDetail();
                                    // detail.TextDetail = singleDetail.Attribute("name").Value;
                                    string detailStatus = singleDetail.Attribute("status").Value;
                                    switch (detailStatus.ToUpper()) {
                                        case "FAILED":
                                            detail.DetailStatus = TestResultStatuses.Failed;
                                            break;
                                        case "PASSED":
                                            detail.DetailStatus = TestResultStatuses.Passed;
                                            break;
                                        case "KNOWNISSUE":
                                            detail.DetailStatus = TestResultStatuses.KnownIssue;
                                            break;
                                        case "NOTTESTED":
                                            detail.DetailStatus = TestResultStatuses.NotTested;
                                            break;
                                        default:
                                            detail.DetailStatus = TestResultStatuses.NotTested;
                                            break;
                                    }
                                        
                                    cmdlet.WriteVerbose(cmdlet, "the current test result is name = '" + currentlyAddedTestResult.Name + "', id ='" + currentlyAddedTestResult.Id + "'");
                                        
                                    currentlyAddedTestResult.Details.Add(detail);
                                        
                                }

                                /*
                                if (null != testResultDetails && testResultDetails.Any()) {
                                // if (null != testResultDetails && 0 < testResultDetails.Count()) {
                                    foreach (var singleDetail in testResultDetails) {
                                        
                                        cmdlet.WriteVerbose(cmdlet, "importing test result detail '" + singleDetail.Attribute("name").Value + "', status = '" + singleDetail.Attribute("status").Value + "'");
                                        lastTestResultDetailName = singleDetail.Attribute("name").Value;
                                        
                                        TestResultDetail detail = new TestResultDetail();
                                        detail.TextDetail = singleDetail.Attribute("name").Value;
                                        string detailStatus = singleDetail.Attribute("status").Value;
                                        switch (detailStatus.ToUpper()) {
                                            case "FAILED":
                                                detail.DetailStatus = TestResultStatuses.Failed;
                                                break;
                                            case "PASSED":
                                                detail.DetailStatus = TestResultStatuses.Passed;
                                                break;
                                            case "KNOWNISSUE":
                                                detail.DetailStatus = TestResultStatuses.KnownIssue;
                                                break;
                                            case "NOTTESTED":
                                                detail.DetailStatus = TestResultStatuses.NotTested;
                                                break;
                                            default:
                                                detail.DetailStatus = TestResultStatuses.NotTested;
                                            	break;
                                        }
                                        
                                        cmdlet.WriteVerbose(cmdlet, "the current test result is name = '" + currentlyAddedTestResult.Name + "', id ='" + currentlyAddedTestResult.Id + "'");
                                        
                                        currentlyAddedTestResult.Details.Add(detail);
                                        
                                    }
                                }
                                */
                            }
                            catch (Exception eImportDetails) {
                                cmdlet.WriteVerbose(cmdlet, eImportDetails);
                            }
                        }
                    }
                    
                    TMX.TestData.RefreshSuiteStatistics(TMX.TestData.CurrentTestSuite, true);
                }
                
                TMX.TestData.CurrentTestSuite = currentTestSuite;
                TMX.TestData.CurrentTestScenario = currentTestScenario;
                
                TMX.TestData.CurrentTestResult = currentTestResult;
                
            }
            catch (Exception eImportDocument) {
                
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to load an XML report from the file '" +
                    path +
                    "'. " + 
                    eImportDocument.Message +
                    "\r\nsuite='" + 
                    lastTestSuiteName +
                    "', scenario='" +
                    lastTestScenarioName +
                    "', test result='" +
                    lastTestResultName +
                    "', detail='" +
                    lastTestResultDetailName +
                    "',",
                    "FailedToImportReport",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        
        public static void ImportResultsFromJUnitXML(SearchCmdletBase cmdlet, string path)
        {
            throw new NotImplementedException();
        }
        
        public static bool AddTestCase(AddTestCaseCmdletBase cmdlet)
        {
            bool result = false;
            
            result = 
                TMX.TestData.AddTestCase(cmdlet.Name,
                                         cmdlet.Id,
                                         "", //cmdlet.Description,
                                         TestData.CurrentTestSuite.Name, //cmdlet.TestSuiteName,
                                         TestData.CurrentTestSuite.Id, //cmdlet.TestSuiteId,
                                         TestData.CurrentTestScenario.Name, //cmdlet.TestScenarioName,
                                         TestData.CurrentTestScenario.Id, //cmdlet.TestScenarioId,
                                         cmdlet.TestPlatformId,
                                         cmdlet.TestCode);
            
            return result;
        }
        
        public static ITestPlatform GetTestPlatformById(string id)
        {
            return TMX.TestData.TestPlatforms.FirstOrDefault(platform => id == platform.Id);
            /*
            ITestPlatform resultPlatform = null;

            foreach (TestPlatform platform in TMX.TestData.TestPlatforms)
            {

                if (id == platform.Id)
                {

                    resultPlatform = platform;
                    break;
                }
            }

            return resultPlatform;
            */
        }
    }
}
