using System.Data.SqlTypes;
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

    /// <summary>
    /// Description of TMXHelper.
    /// </summary>
    public static class TMXHelper
    {
        //public TMXHelper()
        static TMXHelper()
        {
        }
        
        internal static DateTime TestCaseStarted { get; set; }
        
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
        public static bool OpenTestSuite(string testSuiteName, string testSuiteId)
        {
            bool result = false;
            
            TMX.TestData.CurrentTestSuite = 
                TMX.TestData.GetTestSuite(testSuiteName, testSuiteId);
            if (TMX.TestData.CurrentTestSuite != null) {
                //TMX.TestData.FireTMXTestSuiteOpened(TMX.TestData.CurrentTestSuite, null);
                TMX.TestData.OnTMXTestSuiteOpened(TMX.TestData.CurrentTestSuite, null);
                result = true;
            }
            
            return result;
        }
        
        public static bool NewTestSuite(string testSuiteName, 
                                        string testSuiteId,
                                        string testSuiteDesctiption)
        {
            bool result = false;
            result = 
                TMX.TestData.AddTestSuite(testSuiteName, 
                                          testSuiteId,
                                          testSuiteDesctiption);
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
                true);
            }
                //true);
            //TMX.TestData.CurrentTestScenario =
                TMX.TestData.GetTestScenario(cmdlet.InputObject,
                                             cmdlet.Name,
                                             cmdlet.Id,
                                             cmdlet.TestSuiteName,
                                             cmdlet.TestSuiteId);
            if (TMX.TestData.CurrentTestScenario != null) {
                TMX.TestData.CurrentTestScenario.TestResults.Add(
                    new TestResult(
                       TMX.TestData.CurrentTestScenario.Id,
                       TMX.TestData.CurrentTestScenario.SuiteId));
                TMX.TestData.CurrentTestResult =
                    TMX.TestData.CurrentTestScenario.TestResults[TMX.TestData.CurrentTestScenario.TestResults.Count - 1];
                //TMX.TestData.FireTMXTestScenarioOpened(TMX.TestData.CurrentTestResult, null);
                TMX.TestData.OnTMXTestScenarioOpened(TMX.TestData.CurrentTestScenario, null);
                result = true;
            }
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
                                             cmdlet.TestSuiteId);
            
            return result;
        }
        
        public static bool AddTestResultTextDetail(string testResultTextDetail)
        {
            bool result = false;
            
            TMX.TestData.AddTestResultTextDetail(testResultTextDetail);
            
            return result;
        }
        
        public static bool AddTestResultScreenshotDetail(string testResultScreenshotDetail)
        {
            bool result = false;
            
            TMX.TestData.AddTestResultScreenshotDetail(testResultScreenshotDetail);
            
            return result;
        }
        
        public static bool AddTestResultErrorDetail(ErrorRecord testResultErrorDetail)
        {
            bool result = false;
            
            TMX.TestData.AddTestResultErrorDetail(testResultErrorDetail);
            
            return result;
        }
        
        public static bool CloseTestResult(
            string testResultName, 
            string testResultId, 
            bool testResult,
            bool isKnownIssue,
            InvocationInfo myInvocation,
            ErrorRecord error,
            string description,
            bool generated)
        {
            bool result = false;
            
            if (TestData.TestSuites.Count == 0) {
                TestData.InitTestData();
            }

            TMX.TestData.AddTestResult(
                testResultName, 
                testResultId, 
                testResult, 
                isKnownIssue,
                true,
                myInvocation,
                error,
                description,
                generated);

            return result;
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
                                                 TMXHelper.CreateXAttribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(suite.Statistics.TimeSpent)),
                                                 new XAttribute("all", suite.Statistics.All.ToString()),
                                                 new XAttribute("passed", suite.Statistics.Passed.ToString()),
                                                 TMXHelper.CreateXAttribute(xmlStruct.FailedAttribute, suite.Statistics.Failed.ToString()),
                                                 new XAttribute("notTested", suite.Statistics.NotTested.ToString()),
                                                 new XAttribute("knownIssue", suite.Statistics.PassedButWithBadSmell.ToString()),
                                                 TMXHelper.CreateXAttribute("description", suite.Description),
                                                 TMXHelper.CreateScenariosXElementCommon(
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

            if (0 == testScenariosFiltered.Count()) {
                return null;
            }

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
                             TMXHelper.CreateXAttribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(suite.Statistics.TimeSpent)),
                             new XAttribute("all", scenario.Statistics.All.ToString()),
                             new XAttribute("passed", scenario.Statistics.Passed.ToString()),
                             TMXHelper.CreateXAttribute(xmlStruct.FailedAttribute, scenario.Statistics.Failed.ToString()),
                             new XAttribute("notTested", scenario.Statistics.NotTested.ToString()),
                             new XAttribute("knownIssue", scenario.Statistics.PassedButWithBadSmell.ToString()),
                             TMXHelper.CreateXAttribute("description", scenario.Description),
                             TMXHelper.CreateTestResultsXElementCommon(
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

            if (0 == testResultsFiltered.Count()) {
                return null;
            }

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
                             TMXHelper.CreateXAttribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(testResult.TimeSpent)), // ??
                             TMXHelper.CreateXElement(
                                 "source",
                                 TMXHelper.CreateXAttribute("scriptName", testResult.ScriptName),
                                 TMXHelper.CreateXAttribute("lineNumber", testResult.LineNumber),
                                 TMXHelper.CreateXAttribute("position", testResult.Position),
                                 TMXHelper.CreateXAttribute("code", testResult.Code)
                                ),
                             TMXHelper.CreateXAttribute(xmlStruct.TimeStampAttribute, testResult.Timestamp),
                             TMXHelper.CreateXElement(
                                 "error",
                                 TMXHelper.CreateXAttribute("error", testResult.Error)
                                ),
                             TMXHelper.CreateXAttribute("screenshot", testResult.Screenshot),
                             TMXHelper.CreateXAttribute("description", testResult.Description),
                             TMXHelper.CreateTestResultDetailsXElement(
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
                                                 TMXHelper.CreateXAttribute("name", testResultDetail.Name),
                                                 TMXHelper.CreateXAttribute(xmlStruct.TimeSpentAttribute, testResultDetail.Timestamp)
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
                    TMXHelper.CreateSuitesXElementWithParameters(
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
            
            if (cmdlet.FilterNameContains != null && cmdlet.FilterNameContains.Length > 0) {
                query = suite => suite.Name.Contains(cmdlet.FilterNameContains);
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterIdContains != null && cmdlet.FilterIdContains.Length > 0) {
                query = suite => suite.Id.Contains(cmdlet.FilterIdContains);
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterDescriptionContains != null && cmdlet.FilterDescriptionContains.Length > 0) {
                query = suite => 
                    {
                        if (suite.Description != null) {
                            return suite.Description.Contains(cmdlet.FilterDescriptionContains);
                        }
                        return false;
                    };
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
            // 20121006
            if (cmdlet.FilterNone) {
                query = suite => false;
            }
            
            // Ordering results
            
            // default result
            Func<TestSuite, object> ordering = suite => suite.Id;
            
            if (cmdlet.OrderByTimeSpent) {
                ordering = suite => suite.Statistics.TimeSpent;
            } 
            if (cmdlet.OrderByName) {
                ordering = suite => suite.Name;
            } 
            if (cmdlet.OrderById) {
                ordering = suite => suite.Id;
            } 
            if (cmdlet.OrderByPassRate) {
                ordering = suite => 
                    {
                        TMX.TestData.RefreshSuiteStatistics(suite);
                        return (suite.Statistics.Passed / suite.Statistics.All);
                    };
            } 
            if (cmdlet.OrderByFailRate) {
                ordering = suite => 
                    {
                        TMX.TestData.RefreshSuiteStatistics(suite);
                        return (suite.Statistics.Failed / suite.Statistics.All);
                    };
            } 

            cmdlet.WriteVerbose(cmdlet, "query = " + query.ToString());
            cmdlet.WriteVerbose(cmdlet, "ordering = " + ordering.ToString());
            
            suites = 
                TMX.TestData.SearchTestSuite(
                    query,
                    ordering,
                    cmdlet.Descending);

            return suites;
        }
        
        public static void SearchForSuitesPS(SearchCmdletBase cmdlet)
        {
            IOrderedEnumerable<TestSuite> suites =
                SearchForSuites(cmdlet);
            
            if (suites.Count<TMX.TestSuite>() > 0) {
                cmdlet.WriteObject(suites, true);
            } else {
                cmdlet.WriteObject(null);
            }
        }
        
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
            
            if (cmdlet.FilterNameContains != null && cmdlet.FilterNameContains.Length > 0) {
                query = scenario => scenario.Name.Contains(cmdlet.FilterNameContains);
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterIdContains != null && cmdlet.FilterIdContains.Length > 0) {
                query = scenario => scenario.Id.Contains(cmdlet.FilterIdContains);
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterDescriptionContains != null && cmdlet.FilterDescriptionContains.Length > 0) {
                query = scenario => 
                    {
                        if (scenario.Description != null) {
                            return scenario.Description.Contains(cmdlet.FilterDescriptionContains);
                        }
                        return false;
                    };
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
            
            if (scenarios.Count<TMX.TestScenario>() > 0) {
                cmdlet.WriteObject(scenarios, true);
            } else {
                cmdlet.WriteObject(null);
            }
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
            
            if (cmdlet.FilterNameContains != null && cmdlet.FilterNameContains.Length > 0) {
                query = testResult => 
                    {
                        if (testResult.Name != null) {
                            return testResult.Name.Contains(cmdlet.FilterNameContains);
                        }
                        return false;
                    };
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterIdContains != null && cmdlet.FilterIdContains.Length > 0) {
                query = testResult => 
                    {
                        if (testResult.Id != null) {
                            return testResult.Id.Contains(cmdlet.FilterIdContains);
                        }
                        return false;
                    };
                cmdlet.FilterAll = false;
            } else if (cmdlet.FilterDescriptionContains != null && cmdlet.FilterDescriptionContains.Length > 0) {
                query = testResult => 
                    {
                        if (testResult.Description != null) {
                            return testResult.Description.Contains(cmdlet.FilterDescriptionContains);
                        }
                        return false;
                    };
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
            
            if (testResults.Count<TMX.TestResult>() > 0) {
                cmdlet.WriteObject(testResults, true);
            } else {
                cmdlet.WriteObject(null);
            }
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
                        if (null != variable.Name && string.Empty != variable.Name) {
                            XElement variableElement =
                                new XElement("variable",
                                             new XAttribute("name", variable.Name),
                                             new XAttribute("value", variable.Value));
                            rootElement.Add(variableElement);
                        }
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
            if (null != variableNames && 0 < variableNames.Count()) {
                cmdlet.WriteVerbose(cmdlet, "the VariableName list is not empty");
                query = (variableNamesCollection, variableElement) => variableNamesCollection.Contains(variableElement.Attribute((XName)"name").Value);
            }
            
            cmdlet.WriteVerbose(cmdlet, "getting the variables collection");
            var variablesCollection = 
                from variableElement in wholeXML.Elements()
                where query(((IEnumerable<string>)variableNames), variableElement)
                    select variableElement;
            
            cmdlet.WriteVerbose(cmdlet, "collection created");
            
            if (null == variablesCollection || 0 == variablesCollection.Count()) {
                cmdlet.WriteVerbose(cmdlet, "there are no variables to import");
                return;
            }
            
            TMXHelper.ImportVariables(cmdlet, variablesCollection);
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
                    TMXHelper.CreateSuitesXElementWithParameters(
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
    }
}
