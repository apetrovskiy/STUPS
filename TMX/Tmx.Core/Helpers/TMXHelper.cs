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
    using System.Management.Automation;
    
    using System.Linq;
    
    using System.Collections.Generic;
    using System.Xml.Linq;
//    using System.Reflection;
	using Tmx.Interfaces;
	using Tmx.Interfaces.TestStructure;
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
            TestData.InitTestData();
        }
        
        internal static DateTime TestCaseStarted { get; set; }
        public static System.Windows.Forms.Form BannerForm { get; set; }
        
        public static string GetScriptName(InvocationInfo iInfo)
        {
            string result = string.Empty;
            try{
                result = iInfo.ScriptName;
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
                result = iInfo.ScriptLineNumber;
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
                result = iInfo.PipelinePosition;
            }
            catch {
            }
            return result;
        }
        
        #region Actions
        public static bool OpenTestSuite(string testSuiteName, string testSuiteId, string testPlatformId)
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
            
			TestData.CurrentTestSuite = TestData.GetTestSuite(testSuiteName, testSuiteId, testPlatformId);
			// 20140714
			// if (null != TestData.CurrentTestSuite.TestScenarios && 0 < TestData.CurrentTestSuite.TestScenarios.Count) {
			if (null != TestData.CurrentTestSuite && null != TestData.CurrentTestSuite.TestScenarios && 0 < TestData.CurrentTestSuite.TestScenarios.Count)
			    // 20140720
				// TestData.CurrentTestScenario = (TestScenario)TestData.CurrentTestSuite.TestScenarios[TestData.CurrentTestSuite.TestScenarios.Count - 1];
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
            bool result = false;
            result = 
                TestData.AddTestPlatform(
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
                null,
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
                                     cmdlet.TestPlatformId);
            
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
                                         cmdlet.TestPlatformId,
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
        
        public static bool AddTestResultErrorDetail(ErrorRecord testResultErrorDetail)
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

			TestData.AddTestResult(
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
                IOrderedEnumerable<ITestSuite> suites,
                IOrderedEnumerable<ITestScenario> scenarios,
                IOrderedEnumerable<ITestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {

            var suitesElement = 
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
                ITestSuite suite,
                IOrderedEnumerable<ITestScenario> scenarios,
                IOrderedEnumerable<ITestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {

            var testScenariosFiltered = 
                from scenario in scenarios
                where scenario.SuiteId == suite.Id
                select scenario;

            if (!testScenariosFiltered.Any()) {
                return null;
            }
            
            var scenariosElement = 
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
        
        static XElement getScenariosXElement(
                ITestSuite suite,
                ITestScenario scenario,
                IOrderedEnumerable<ITestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {

            var scenariosElement =
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
                ITestSuite suite,
                ITestScenario scenario,
                IOrderedEnumerable<ITestResult> testResults,
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
            
            var testResultsElement =
                new XElement(xmlStruct.TestResultsNode,
                             from testResult in testResultsFiltered
                             select getTestResultsXElement(testResult, xmlStruct)
                            );

            return testResultsElement;
        }
        
        static XElement getTestResultsXElement(
                ITestResult testResult,
                IXMLElementsStruct xmlStruct)
        {

            var testResultsElement =
                new XElement(xmlStruct.TestResultNode,
                             new XAttribute("id", testResult.Id),
                             new XAttribute("name", testResult.Name),
                             new XAttribute("status", testResult.Status),
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
                             TmxHelper.CreateXAttribute("platformId", testResult.PlatformId),
                             TmxHelper.CreateTestResultDetailsXElement(
                                 testResult,
                                 xmlStruct)
                            );

            return testResultsElement;
        }
        
        public static XElement CreateTestResultDetailsXElement(
                ITestResult testResult,
                IXMLElementsStruct xmlStruct)
        {

            if (0 == testResult.Details.Count) {
                return null;
            }

            var testResultDetailsElement =
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
        public static void ExportResultsToXML(ISearchCmdletBaseDataObject cmdlet, string path)
        {
            try {
                var document = GetTestResultsAsXdocument(cmdlet);
                document.Save(path);
            }
            catch (Exception eCreateDocument) {
                throw new Exception(
                    "Unable to save XML report to the file '" +
                    path +
                    "'. " + 
                    eCreateDocument.Message);
            }
        }

		public static XDocument GetTestResultsAsXdocument(ISearchCmdletBaseDataObject cmdlet)
		{
			var suitesElement = GetTestResultsAsXelement(cmdlet);
			var document = new XDocument();
			document.Add(suitesElement);
			return document;
		}

		public static XElement GetTestResultsAsXelement(ISearchCmdletBaseDataObject cmdlet)
		{
			var gathered = new GatherTestResultsCollections();
			gathered.GatherCollections(cmdlet);
			var suitesElement = TmxHelper.CreateSuitesXElementWithParameters(gathered.TestSuites, gathered.TestScenarios, gathered.TestResults, (new XMLElementsNativeStruct()));
			return suitesElement;
		}

            #endregion export to XML
        
        #endregion Export results
        
        #region Search
        /// <summary>
        /// Performs parametrized search for Test Suites.
        /// </summary>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public static IOrderedEnumerable<ITestSuite> SearchForSuites(ISearchCmdletBaseDataObject cmdlet)
        {
            IOrderedEnumerable<ITestSuite> suites = null;
            
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
                query = suite => suite.enStatus == TestSuiteStatuses.Passed;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.Passed));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterFailed) {
                query = suite => suite.enStatus == TestSuiteStatuses.Failed;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.Failed));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterNotTested) {
                query = suite => suite.enStatus == TestSuiteStatuses.NotTested;
                //queriesList.Add((suite => suite.enStatus == TestSuiteStatuses.NotTested));
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterPassedWithBadSmell) {
                query = suite => suite.enStatus == TestSuiteStatuses.KnownIssue;
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
					TestData.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
					return (suite.Statistics.Passed / suite.Statistics.All);
				};
			} 
			if (cmdlet.OrderByFailRate) {
				ordering += suite => {
					//TestData.RefreshSuiteStatistics(suite);
					TestData.RefreshSuiteStatistics(suite, cmdlet.FilterOutAutomaticResults);
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
        // 20140720
        // public static IOrderedEnumerable<TestResult> SearchForTestResults(SearchCmdletBase cmdlet)
        public static IOrderedEnumerable<ITestResult> SearchForTestResults(ISearchCmdletBaseDataObject dataObject)
        {
            // 20140720
            // IOrderedEnumerable<TestResult> testResults = null;
            IOrderedEnumerable<ITestResult> testResults = null;

            // Filtering results
            
            // default result
            // 20140720
            // Func<TestResult, bool> query = testResult => true;
            Func<ITestResult, bool> query = testResult => true;
            
            // 20140722
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
				query = testResult => testResult.enStatus == TestResultStatuses.Passed;
                // dataObject.FilterAll = false;
            else if (dataObject.FilterFailed)
				query = testResult => testResult.enStatus == TestResultStatuses.Failed;
                // dataObject.FilterAll = false;
            else if (dataObject.FilterNotTested)
				query = testResult => testResult.enStatus == TestResultStatuses.NotTested;
                // dataObject.FilterAll = false;
            else if (dataObject.FilterPassedWithBadSmell)
				query = testResult => testResult.enStatus == TestResultStatuses.KnownIssue;
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
        
        // 20140720
        // public static void SearchForTestResultsPS(SearchCmdletBase cmdlet)
        // public static void SearchForTestResultsPS(ISearchCmdletBaseDataObject cmdlet)
        public static IOrderedEnumerable<ITestResult> SearchForTestResultsPS(ISearchCmdletBaseDataObject dataObject)
        {
            var testResults = SearchForTestResults(dataObject);
			return testResults.Any() ? testResults : null;
        }
        
        internal static XAttribute CreateXAttribute(string name, object valueObject)
        {
            XAttribute result = null;
            
            if (null == valueObject)
                return null;
            
            result = new XAttribute(name, valueObject);
            
            return result;
        }
        
        internal static XElement CreateXElement(string name, params object[] content)
        {
            XElement result = null;
            
			if (null == content[0])
				return null;
            
            result = new XElement(name, content);
            
            return result;
        }
        #endregion Search
        
//        #region Test settings
//        public static void ExportTestSettings(
//            // 20140720
//            // SettingsCmdletBase cmdlet,
//            ISettingsCmdletBaseDataObject cmdlet,
//            string path,
//            string[] variableNames)
//        {
//            try {
//                var rootElement = new XElement("variables");
//                
//                foreach (string variableName in variableNames) {
//                    PSVariable variable = 
//                        cmdlet.SessionState.PSVariable.Get(variableName);
//                    try {
//                        if (string.IsNullOrEmpty(variable.Name)) continue;
//                        // if (null != variable.Name && string.Empty != variable.Name) {
//                        var variableElement =
//                            new XElement("variable",
//                                new XAttribute("name", variable.Name),
//                                new XAttribute("value", variable.Value));
//                        rootElement.Add(variableElement);
//
//                        /*
//                        if (!string.IsNullOrEmpty(variable.Name)) {
//                        // if (null != variable.Name && string.Empty != variable.Name) {
//                            XElement variableElement =
//                                new XElement("variable",
//                                             new XAttribute("name", variable.Name),
//                                             new XAttribute("value", variable.Value));
//                            rootElement.Add(variableElement);
//                        }
//                        */
//                    }
//                    catch (Exception eVariable) {
//                        // 20140720
////                        cmdlet.WriteError(
////                            cmdlet,
////                            "Unable to export variable '" +
////                            variableName +
////                            "'.",
////                            "FailedToExportVariable",
////                            ErrorCategory.InvalidArgument,
////                            false);
//                        throw new Exception(
//                            "Unable to export variable '" +
//                            variableName +
//                            "'.");
//                    }
//                }
//                
//                var document = new XDocument();
//                document.Add(rootElement);
//                document.Save(path);
//            }
//            catch (Exception eCreateDocument) {
//                // 20140720
////                cmdlet.WriteError(
////                    cmdlet,
////                    "Unable to save XML report to the file '" +
////                    path +
////                    "'. " + 
////                    eCreateDocument.Message,
////                    "FailedToSaveReport",
////                    ErrorCategory.InvalidOperation,
////                    true);
//                throw new Exception(
//                    "Unable to save XML report to the file '" +
//                    path +
//                    "'. " + 
//                    eCreateDocument.Message);
//            }
//        }
//        
//        public static void ImportTestSettings(
//            // 20140720
//            // SettingsCmdletBase cmdlet,
//            ISettingsCmdletBaseDataObject cmdlet,
//            string path,
//            string[] variableNames)
//        {
//            XElement wholeXML =
//                XElement.Load(path);
//            
//            // default result
//            Func<IEnumerable<string>, XElement, bool> query = (variableNamesCollection, variableElement) => true;
//            
////            cmdlet.WriteVerbose(cmdlet, "checking the VariableName list");
//            if (null != variableNames && variableNames.Any()) {
////                cmdlet.WriteVerbose(cmdlet, "the VariableName list is not empty");
//                query = (variableNamesCollection, variableElement) => variableNamesCollection.Contains(variableElement.Attribute((XName)"name").Value);
//            }
//            
////            cmdlet.WriteVerbose(cmdlet, "getting the variables collection");
//            var variablesCollection = 
//                from variableElement in wholeXML.Elements()
//                where query(((IEnumerable<string>)variableNames), variableElement)
//                    select variableElement;
//            
////            cmdlet.WriteVerbose(cmdlet, "collection created");
//            
//            if (null == variablesCollection || !variablesCollection.Any()) {
////                cmdlet.WriteVerbose(cmdlet, "there are no variables to import");
//                return;
//            }
//            
//            TmxHelper.ImportVariables(cmdlet, variablesCollection);
//        }
//        
//        public static bool ImportVariables(
//            // 20140720
//            // SettingsCmdletBase cmdlet,
//            ISettingsCmdletBaseDataObject cmdlet,
//            IEnumerable<XElement> variablesCollection)
//        {
//            bool result = false;
//            
//            foreach (XElement element in variablesCollection) {
//                
//                string variableName = string.Empty;
//                
//                try {
//                
//                    variableName =
//                            element.Attribute((XName)"name").Value;
//                    
////                    cmdlet.WriteVerbose(cmdlet, "importing the '" + variableName + "' variable");
//                    
//                    string variableValue =
//                        string.Empty;
//                    try {
//                        variableValue =
//                            element.Attribute((XName)"value").Value;
//                    }
//                    catch {
//                        // nothing to do
//                    }
//                        
//                    //ScopedItemOptions.AllScope
//                    //ScopedItemOptions.Constant
//                    //ScopedItemOptions.None
//                    //ScopedItemOptions.Private
//                    //ScopedItemOptions.ReadOnly
//                    //ScopedItemOptions.Unspecified
//                
//                    var variable = 
//                        new PSVariable(
//                            variableName,
//                            variableValue);
//                    cmdlet.SessionState.PSVariable.Set(variable);
//                }
//                catch (Exception eLoadingVariable) {
//                    // 20140720
////                    cmdlet.WriteError(
////                        cmdlet,
////                        "Unable to load variable '" +
////                        variableName +
////                        "'. " +
////                        eLoadingVariable.Message,
////                        "FailedToLoadVariable",
////                        ErrorCategory.InvalidData,
////                        false);
//                    throw new Exception(
//                        "Unable to load variable '" +
//                        variableName +
//                        "'. " +
//                        eLoadingVariable.Message);
//                }
//            }
//
//            return result;
//        }
//        #endregion Test settings
        
        public static void ExportResultsToJUnitXML(ISearchCmdletBaseDataObject cmdlet, string path)
        {
            try {

                var gathered = new GatherTestResultsCollections();
                gathered.GatherCollections(cmdlet);
                
                var suitesElement = 
                    TmxHelper.CreateSuitesXElementWithParameters(
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
            TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            return TestData.CurrentTestSuite.Status;
        }
        
        public static string GetTestSuiteStatusByName(string name, string testPlatformId, bool skipAutomatic)
        {
            TmxHelper.OpenTestSuite(
                name,
                string.Empty,
                testPlatformId);
            // 20140720
            // if (null == TestData.CurrentTestSuite) return;
            if (null == TestData.CurrentTestSuite) return string.Empty;
            TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            // 20140720
            // cmdlet.WriteObject(cmdlet, TestData.CurrentTestSuite.Status);
            return TestData.CurrentTestSuite.Status;
        }
        
        public static string GetTestSuiteStatusById(string id, string testPlatformId, bool skipAutomatic)
        {
            TmxHelper.OpenTestSuite(
                string.Empty,
                id,
                testPlatformId);
            if (null == TestData.CurrentTestSuite) return string.Empty;
            TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, skipAutomatic);
            return TestData.CurrentTestSuite.Status;
        }
        
        public static string GetCurrentTestScenarioStatus(IOpenScenarioCmdletBaseDataObject cmdlet, bool skipAutomatic)
        {
            if (null == TestData.CurrentTestScenario) return string.Empty;
            TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
            return TestData.CurrentTestScenario.Status;
        }
        
        public static string GetTestScenarioStatus(IOpenScenarioCmdletBaseDataObject dataObject, bool skipAutomatic)
        {
            TmxHelper.OpenTestScenario(dataObject);
            if (null == TestData.CurrentTestScenario) return string.Empty;
            TestData.RefreshScenarioStatistics(TestData.CurrentTestScenario, skipAutomatic);
            return TestData.CurrentTestScenario.Status;
        }
        
        public static void SetCurrentTestResult(ITestResultCmdletBaseDataObject cmdlet)
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

				if (!string.IsNullOrEmpty(cmdlet.Id))
					TestData.CurrentTestResult.Id = cmdlet.Id;
				else
					TestData.GetTestResultId();
                
				if (!string.IsNullOrEmpty(cmdlet.Description))
					TestData.CurrentTestResult.Description = cmdlet.Description;
				
                TestData.CurrentTestResult.enStatus = TestResultStatuses.NotTested;

				if (cmdlet.KnownIssue)
					TestData.CurrentTestResult.enStatus = TestResultStatuses.KnownIssue;
                
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
		
        public static void ImportResultsFromXML(IImportExportCmdletBaseDataObject cmdlet, string path)
        {
            try {
                
                string pathToImportFile = cmdlet.Path;
                
                if (!System.IO.File.Exists(pathToImportFile)) {
                    throw new Exception(
                        "There is no such file '" +
                        cmdlet.Path +
                        "'.");
                }
                
                var doc = XDocument.Load(pathToImportFile);
                ImportTestResultsFromXdocument(doc);
            }
            catch (Exception eImportDocument) {
                throw new Exception(
                    "Unable to load an XML report from the file '" +
                    path +
                    "'. " + 
//                    eImportDocument.Message +
//                    "\r\nsuite='" + 
//                    lastTestSuiteName +
//                    "', scenario='" +
//                    lastTestScenarioName +
//                    "', test result='" +
//                    lastTestResultName +
//                    "', detail='" +
//                    lastTestResultDetailName +
//                    "',");
                    eImportDocument.Message);
            }
        }
        
		public static void ImportTestResultsFromXdocument(XDocument doc)
		{
			var currentTestSuite = TestData.CurrentTestSuite;
			var currentTestScenario = TestData.CurrentTestScenario;
			var currentTestResult = TestData.CurrentTestResult;
			TestData.CurrentTestSuite = null;
			TestData.CurrentTestScenario = null;
			TestData.CurrentTestResult = null;
			
			var df = doc.Root.Name.Namespace;
			var suites = from suite in doc.Descendants("suite")
			             where suite.Attribute("name").Value != TestData.Autogenerated
			             select suite;
			importTestSuites(suites);
			
			TestData.CurrentTestSuite = currentTestSuite;
			TestData.CurrentTestScenario = currentTestScenario;
			TestData.CurrentTestResult = currentTestResult;
		}
		
		static void importTestSuites(IEnumerable<XElement> suites)
		{
            string lastTestSuiteName = string.Empty;
            
			foreach (var singleSuite in suites) {
				lastTestSuiteName = singleSuite.Attribute("name").Value;
				string suiteDescription = string.Empty;
				try {
					suiteDescription = singleSuite.Attribute("description").Value;
				} catch {
				}
				var testSuite = TestData.GetTestSuite(singleSuite.Attribute("name").Value, singleSuite.Attribute("id").Value, singleSuite.Attribute("platformId").Value);
				TestData.CurrentTestSuite = testSuite;
				if (null == testSuite)
					TestData.AddTestSuite(singleSuite.Attribute("name").Value, singleSuite.Attribute("id").Value, singleSuite.Attribute("platformId").Value, suiteDescription, null, null);
                var scenarios = from scenario in singleSuite.Descendants("scenario")
                                where scenario.Attribute("name").Value != TestData.Autogenerated
                                select scenario;
				importTestScenarios(scenarios);
				TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, true);
			}
		}

		static void importTestScenarios(IEnumerable<XElement> scenarios)
		{
            string lastTestScenarioName = string.Empty;
            
			foreach (var singleScenario in scenarios) {
				lastTestScenarioName = singleScenario.Attribute("name").Value;
				string scenarioDescription = string.Empty;
				try {
					scenarioDescription = singleScenario.Attribute("description").Value;
				} catch {
				}
				var testScenario = TestData.GetTestScenario(TestData.CurrentTestSuite, singleScenario.Attribute("name").Value, singleScenario.Attribute("id").Value, TestData.CurrentTestSuite.Name, TestData.CurrentTestSuite.Id, TestData.CurrentTestSuite.PlatformId);
				TestData.CurrentTestScenario = testScenario;
				if (null == testScenario) {
					TestData.AddTestScenario(TestData.CurrentTestSuite, singleScenario.Attribute("name").Value, singleScenario.Attribute("id").Value, scenarioDescription, string.Empty, string.Empty, singleScenario.Attribute("platformId").Value, null, null);
				}
                var testResults = from testResult in singleScenario.Descendants("testResult")
                                  //where testResult.Attribute("name").Value != "autoclosed"
				select testResult;
				importTestResults(testResults);
			}
		}

		static void importTestResults(IEnumerable<XElement> testResults)
		{
            string lastTestResultName = string.Empty;
            
			foreach (var singleTestResult in testResults) {
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
				} catch {
				}
				TestResultOrigins origin = TestResultOrigins.Logical;
				try {
					if ("TECHNICAL" == singleTestResult.Attribute("origin").Value.ToUpper()) {
						origin = TestResultOrigins.Technical;
					}
					if ("AUTOMATIC" == singleTestResult.Attribute("origin").Value.ToUpper()) {
						origin = TestResultOrigins.Automatic;
					}
				} catch {
				}
				if ((TestResultOrigins.Technical == origin) && //(!knownIssueValue &&
				    passedValue) {
					continue;
				}
				string testResultDescription = string.Empty;
				try {
					testResultDescription = singleTestResult.Attribute("description").Value;
				} catch {
				}
				
				TestData.AddTestResult(singleTestResult.Attribute("name").Value, singleTestResult.Attribute("id").Value, passedValue, knownIssueValue, false, null, null, testResultDescription, origin, true);
				var currentlyAddedTestResult = TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1];
				try {
					currentlyAddedTestResult.PlatformId = singleTestResult.Attribute("platformId").Value;
				} catch (Exception) {
					//                                cmdlet.WriteVerbose(cmdlet, "adding test platform to the current test result");
					//                                cmdlet.WriteVerbose(cmdlet, eTestResultPlatform.Message);
				}
				try {
					// lastTestResultDetailName = string.Empty;
                    var testResultDetails = from testResultDetail in singleTestResult.Descendants("detail")
                                            select testResultDetail;
					if (null == testResultDetails || !testResultDetails.Any())
						continue;
					importTestResultDetails(testResultDetails, currentlyAddedTestResult);
				} catch (Exception) {
					//                                cmdlet.WriteVerbose(cmdlet, eImportDetails);
				}
			}
		}

		static void importTestResultDetails(IEnumerable<XElement> testResultDetails, ITestResult currentlyAddedTestResult)
		{
		    string lastTestResultDetailName = string.Empty;
		    
			foreach (var singleDetail in testResultDetails) {
				lastTestResultDetailName = singleDetail.Attribute("name").Value;
				var detail = new TestResultDetail {
					TextDetail = singleDetail.Attribute("name").Value
				};
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
				currentlyAddedTestResult.Details.Add(detail);
			}
		}

        /*
        public static void ImportResultsFromXML(IImportExportCmdletBaseDataObject cmdlet, string path)
        {
            
            string lastTestSuiteName = string.Empty;
            string lastTestScenarioName = string.Empty;
            string lastTestResultName = string.Empty;
            string lastTestResultDetailName = string.Empty;
            
            try {
            
                if (!System.IO.File.Exists(cmdlet.Path)) {
                    // 20140720
//                    cmdlet.WriteError(
//                        cmdlet,
//                        "There is no such file '" +
//                        cmdlet.Path +
//                        "'.",
//                        "NoSuchFile",
//                        ErrorCategory.InvalidArgument,
//                        true);
                    throw new Exception(
                        "There is no such file '" +
                        cmdlet.Path +
                        "'.");
                }
                
                // 20140720
                // TestSuite currentTestSuite = TestData.CurrentTestSuite;
                // TestScenario currentTestScenario = TestData.CurrentTestScenario;
                // ITestResult currentTestResult = TestData.CurrentTestResult;
                var currentTestSuite = TestData.CurrentTestSuite;
                var currentTestScenario = TestData.CurrentTestScenario;
                var currentTestResult = TestData.CurrentTestResult;
                
				TestData.CurrentTestSuite = null;
				TestData.CurrentTestScenario = null;
				TestData.CurrentTestResult = null;
                
                var doc = XDocument.Load(cmdlet.Path);
                var df = doc.Root.Name.Namespace;
                var suites = from suite in doc.Descendants("suite")
                	// 20140716
                    // where suite.Attribute("name").Value != "autogenerated"
                	where suite.Attribute("name").Value != TestData.Autogenerated
                    select suite;
                
                foreach (var singleSuite in suites) {
                    
                    lastTestSuiteName = singleSuite.Attribute("name").Value;
                    
                    string suiteDescription = string.Empty;
                    try {
                        suiteDescription = singleSuite.Attribute("description").Value;
                    }
                    catch {}
                    
                    var testSuite =
						TestData.GetTestSuite(
                            singleSuite.Attribute("name").Value,
                            singleSuite.Attribute("id").Value,
                            singleSuite.Attribute("platformId").Value);
					TestData.CurrentTestSuite = testSuite;
                    
                    if (null == testSuite) {
						TestData.AddTestSuite(
                            singleSuite.Attribute("name").Value,
                            singleSuite.Attribute("id").Value,
                            singleSuite.Attribute("platformId").Value,
                            suiteDescription,
                            null,
                            null);
                    }
                    
                    var scenarios = from scenario in singleSuite.Descendants("scenario")
                    	// 20140716
                        // where scenario.Attribute("name").Value != "autogenerated"
                    	where scenario.Attribute("name").Value != TestData.Autogenerated
                        select scenario;
                    
                    foreach (var singleScenario in scenarios) {
                        
                        lastTestScenarioName = singleScenario.Attribute("name").Value;
                        
                        string scenarioDescription = string.Empty;
                        try {
                            scenarioDescription = singleScenario.Attribute("description").Value;
                        }
                        catch {}
                        
                        var testScenario =
							TestData.GetTestScenario(
								TestData.CurrentTestSuite,
                                singleScenario.Attribute("name").Value,
                                singleScenario.Attribute("id").Value,
								TestData.CurrentTestSuite.Name,
								TestData.CurrentTestSuite.Id,
								TestData.CurrentTestSuite.PlatformId);
						TestData.CurrentTestScenario = testScenario;
                        
                        if (null == testScenario) {
							TestData.AddTestScenario(
								TestData.CurrentTestSuite,
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
                            
							TestData.AddTestResult(
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
                            
                            var currentlyAddedTestResult = TestData.CurrentTestScenario.TestResults[TestData.CurrentTestScenario.TestResults.Count - 1];
                            
                            try {
                                currentlyAddedTestResult.PlatformId =
                                    singleTestResult.Attribute("platformId").Value;
                            }
                            catch (Exception eTestResultPlatform) {
//                                cmdlet.WriteVerbose(cmdlet, "adding test platform to the current test result");
//                                cmdlet.WriteVerbose(cmdlet, eTestResultPlatform.Message);
                            }
                            
                            try {
                                lastTestResultDetailName = string.Empty;
                                
                                var testResultDetails = from testResultDetail in singleTestResult.Descendants("detail")
                                    select testResultDetail;

                                if (null == testResultDetails || !testResultDetails.Any()) continue;
                                foreach (var singleDetail in testResultDetails) {
                                        
//                                    cmdlet.WriteVerbose(cmdlet, "importing test result detail '" + singleDetail.Attribute("name").Value + "', status = '" + singleDetail.Attribute("status").Value + "'");
                                    lastTestResultDetailName = singleDetail.Attribute("name").Value;
                                        
                                    var detail = new TestResultDetail
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
                                    
                                    currentlyAddedTestResult.Details.Add(detail);
                                        
                                }
                            }
                            catch (Exception eImportDetails) {
//                                cmdlet.WriteVerbose(cmdlet, eImportDetails);
                            }
                        }
                    }
                    
					TestData.RefreshSuiteStatistics(TestData.CurrentTestSuite, true);
                }
                
				TestData.CurrentTestSuite = currentTestSuite;
				TestData.CurrentTestScenario = currentTestScenario;
                
				TestData.CurrentTestResult = currentTestResult;
                
            }
            catch (Exception eImportDocument) {
                throw new Exception(
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
                    "',");
            }
        }
        */
        
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
                                         cmdlet.TestPlatformId,
                                         cmdlet.TestCode);
            
            return result;
        }
        
        public static ITestPlatform GetTestPlatformById(string id)
        {
            return TestData.TestPlatforms.FirstOrDefault(platform => id == platform.Id);
        }
    }
}
