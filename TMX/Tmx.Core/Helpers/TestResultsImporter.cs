/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/31/2014
 * Time: 6:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Interfaces;
    using Interfaces.TestStructure;
    using Proxy;

    /// <summary>
    /// Description of TestResultsImporter.
    /// </summary>
    public class TestResultsImporter
    {
        public XDocument ImportedDocument { get; set; }
        
        public void MergeTestSuites(List<ITestSuite> sourceTestSuites, List<ITestSuite> testSuitesToAdd)
        {
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            
            foreach (var testSuite in testSuitesToAdd) {
                if (sourceTestSuites.All(ts => ts.UniqueId != testSuite.UniqueId)) {
                    // 20150219
                    // TODO: move it to another place
                    testStatistics.RefreshSuiteStatistics(testSuite, false);
                    sourceTestSuites.Add(testSuite);
                    continue;
                }
                var existingTestSuite = sourceTestSuites.First(ts => ts.UniqueId == testSuite.UniqueId);
                MergeTestScenarios(existingTestSuite.TestScenarios, testSuite.TestScenarios);
                testStatistics.RefreshSuiteStatistics(existingTestSuite, false);
            }
        }
        
        void MergeTestScenarios(List<ITestScenario> sourceTestScenarios, List<ITestScenario> testScenariosToAdd)
        {
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            
            foreach (var testScenario in testScenariosToAdd) {
                if (sourceTestScenarios.All(tsc => tsc.UniqueId != testScenario.UniqueId)) {
                    // 20150219
                    // TODO: move it to another place
                    testStatistics.RefreshScenarioStatistics(testScenario, false);
                    sourceTestScenarios.Add(testScenario);
                    continue;
                }
                var existingTestScenario = sourceTestScenarios.First(tsc => tsc.UniqueId == testScenario.UniqueId);
                MergeTestResults(existingTestScenario.TestResults, testScenario.TestResults);
                testStatistics.RefreshScenarioStatistics(existingTestScenario, false);
            }
        }
        
        void MergeTestResults(List<ITestResult> sourceTestResults, List<ITestResult> testResultsToAdd)
        {
            foreach (var testResult in testResultsToAdd)
                if (sourceTestResults.All(tr => tr.UniqueId != testResult.UniqueId))
                    sourceTestResults.Add(testResult);
        }
        
        public void MergeTestPlatforms(List<ITestPlatform> sourceTestPlatforms, List<ITestPlatform> testPlatformsToAdd)
        {
            foreach (var testPlatform in testPlatformsToAdd)
                if (sourceTestPlatforms.All(tr => tr.UniqueId != testPlatform.UniqueId))
                    sourceTestPlatforms.Add(testPlatform);
        }
        
        public bool LoadDocument(IImportExportCmdletBaseDataObject cmdlet, string path)
        {
            try {
                
                var pathToImportFile = cmdlet.Path;
                
                if (!System.IO.File.Exists(pathToImportFile)) {
                    throw new Exception(
                        "There is no such file '" +
                        cmdlet.Path +
                        "'.");
                }
                
                ImportedDocument = XDocument.Load(pathToImportFile);
                return true;
            }
            catch (Exception eImportDocument) {
                throw new Exception(
                    "Unable to load an XML report from the file '" +
                    path +
                    "'. " + 
                    eImportDocument.Message);
            }
        }
        
        public List<ITestPlatform> ImportTestPlatformFromXdocument(XDocument xDoc)
        {
            var df = xDoc.Root.Name.Namespace;
            var platforms = from platform in xDoc.Descendants("testplatform")
                                  where platform.Attribute("name").Value != TestData.DefaultPlatformName
                                  select platform;
            return ImportTestPlatforms(platforms);
        }
        
        List<ITestPlatform> ImportTestPlatforms(IEnumerable<XElement> platformElements)
        {
            var importedTestPlatforms = new List<ITestPlatform>();
            
            foreach (var platformElement in platformElements) {
                var addTestPlatform = false;
                var testPlatform = importedTestPlatforms.FirstOrDefault(tp => tp.Id == GetStringAttribute(platformElement, "id") &&
//                ITestPlatform testPlatform = null;
//                try {
//                    testPlatform = importedTestPlatforms.First(tp => tp.Id == getStringAttribute(platformElement, "id") &&
                                                                        tp.Name == GetStringAttribute(platformElement, "name") &&
                                                                        tp.UniqueId == GetGuidAttribute(platformElement, "uniqueId"));
//                }
//                catch (Exception ee) {
//Console.WriteLine(ee.Message);
//                }
                if (null == testPlatform) {
                    testPlatform = new TestPlatform {
                        UniqueId = GetGuidAttribute(platformElement, "uniqueId"),
                        Id = GetStringAttribute(platformElement, "id"),
                        Name = GetStringAttribute(platformElement, "name"),
                        Description = GetStringAttribute(platformElement, "description")
                    };
                    addTestPlatform = true;
                }
                
                if (addTestPlatform)
                   importedTestPlatforms.Add(testPlatform);                
            }
            
            return importedTestPlatforms;
        }
        
        public List<ITestSuite> ImportTestResultsFromXdocument(XDocument xDoc)
        {
            var df = xDoc.Root.Name.Namespace;
            var suites = from suite in xDoc.Descendants("suite")
                                  where suite.Attribute("name").Value != TestData.Autogenerated
                                  select suite;
            return ImportTestSuites(suites);
        }
        
        public List<ITestSuite> ImportTestSuites(IEnumerable<XElement> suiteElements)
        {
            var importedTestSuites = new List<ITestSuite>();
            // TODO: DI
            // 20150925
            // var testStatistics = new TestStatistics();
            var testStatistics = ProxyFactory.Get<TestStatistics>();
            
            foreach (var suiteElement in suiteElements) {
                var suiteDescription = string.Empty;
                suiteDescription = GetStringAttribute(suiteElement, "description");
                
                var addTestSuite = false;
                var testSuite = importedTestSuites.FirstOrDefault(ts => ts.Id == GetStringAttribute(suiteElement, "id") &&
                                                         ts.Name == GetStringAttribute(suiteElement, "name") &&
                                                         ts.PlatformUniqueId == GetGuidAttribute(suiteElement, "platformUniqueId"));
                
                if (null == testSuite) {
                    testSuite = new TestSuite {
                        UniqueId = GetGuidAttribute(suiteElement, "uniqueId"),
                        Id = GetStringAttribute(suiteElement, "id"),
                        Name = GetStringAttribute(suiteElement, "name"),
                        PlatformId = GetStringAttribute(suiteElement, "platformId"),
                        PlatformUniqueId = GetGuidAttribute(suiteElement, "platformUniqueId"),
                        Description = suiteDescription,
                        TimeSpent = GetDoubleAttribute(suiteElement, "timeSpent")
                    };
                    addTestSuite = true;
                }
                
                var scenarioElements = from scenarioElement in suiteElement.Descendants("scenario")
                                            where GetStringAttribute(scenarioElement, "name") != TestData.Autogenerated
                                            && testSuite.PlatformUniqueId == GetGuidAttribute(scenarioElement, "platformUniqueId")
                                            select scenarioElement;
                testSuite.TestScenarios.AddRange(ImportTestScenarios(scenarioElements, testSuite.Id, testSuite.UniqueId));
                testStatistics.RefreshSuiteStatistics(testSuite, true);
                SetSuiteStatus(testSuite, true);
                if (addTestSuite)
                   importedTestSuites.Add(testSuite);
            }
            return importedTestSuites;
        }
        
        List<ITestScenario> ImportTestScenarios(IEnumerable<XElement> scenarioElements, string suiteId, Guid suiteUniqueId)
        {
            var importedTestScenarios = new List<ITestScenario>();
            if (null == scenarioElements) return importedTestScenarios;
            
            foreach (var scenarioElement in scenarioElements) {
                var scenarioDescription = string.Empty;
                scenarioDescription = GetStringAttribute(scenarioElement, "description");
                
                var addTestScenario = false;
                var testScenario = importedTestScenarios.FirstOrDefault(tsc => tsc.Id == GetStringAttribute(scenarioElement, "id") &&
                                                               tsc.Name == GetStringAttribute(scenarioElement, "name") &&
                                                               tsc.PlatformUniqueId == GetGuidAttribute(scenarioElement, "platformUniqueId"));
                
                if (null == testScenario) {
                    testScenario = new TestScenario {
                        UniqueId = GetGuidAttribute(scenarioElement, "uniqueId"),
                        Id = GetStringAttribute(scenarioElement, "id"),
                        Name = GetStringAttribute(scenarioElement, "name"),
                        PlatformId = GetStringAttribute(scenarioElement, "platformId"),
                        PlatformUniqueId = GetGuidAttribute(scenarioElement, "platformUniqueId"),
                        Description = scenarioDescription,
                        TimeSpent = GetDoubleAttribute(scenarioElement, "timeSpent"),
                        SuiteId = suiteId,
                        SuiteUniqueId = suiteUniqueId
                    };
                    addTestScenario = true;
                }
                var testResultElements = from testResultElement in scenarioElement.Descendants("testResult")
                    where testScenario.PlatformUniqueId == GetGuidAttribute(testResultElement, "platformUniqueId")
                                  //where testResult.Attribute("name").Value != "autoclosed"
                select testResultElement;
                testScenario.TestResults.AddRange(ImportTestResults(testResultElements, testScenario.SuiteId, testScenario.SuiteUniqueId, testScenario.Id, testScenario.UniqueId));
                if (addTestScenario)
                    importedTestScenarios.Add(testScenario);
            }
            return importedTestScenarios;
        }
        
        List<ITestResult> ImportTestResults(IEnumerable<XElement> testResultElements, string suiteId, Guid suiteUniqueId, string scenarioId, Guid scenarioUniqueId)
        {
            var importedTestResults = new List<ITestResult>();
            if (null == testResultElements) return importedTestResults;
            
            foreach (var testResultElement in testResultElements) {
                var status = GetTestResultStatus(testResultElement);
                var origin = TestResultOrigins.Logical;
                if ("TECHNICAL" == GetStringAttribute(testResultElement, "origin").ToUpper())
                    origin = TestResultOrigins.Technical;
                if ("AUTOMATIC" == GetStringAttribute(testResultElement, "origin").ToUpper())
                    origin = TestResultOrigins.Automatic;

                /*
                if (TestResultOrigins.Technical == origin && TestStatuses.Passed == status)
                    continue;

                */

                var testResultDescription = string.Empty;
                testResultDescription = GetStringAttribute(testResultElement, "description");
                
                var addTestResult = false;
                var testResult = importedTestResults.FirstOrDefault(tr => tr.Id == GetStringAttribute(testResultElement, "id") &&
                                                           tr.Name == GetStringAttribute(testResultElement, "name"));

                if (null == testResult) {
                    testResult = new TestResult {
                        UniqueId = GetGuidAttribute(testResultElement, "uniqueId"),
                        Id = GetStringAttribute(testResultElement, "id"),
                        Name = GetStringAttribute(testResultElement, "name"),
                        Description = testResultDescription,
                        // 20150127
                        // enStatus = (!passedValue ? TestResultStatuses.Failed : knownIssueValue ? TestResultStatuses.KnownIssue : passedValue ? TestResultStatuses.Passed : TestResultStatuses.NotTested),
                        enStatus = status,
                        SuiteId = suiteId,
                        ScenarioId = scenarioId,
                        SuiteUniqueId = suiteUniqueId,
                        ScenarioUniqueId = scenarioUniqueId
                    };
                    addTestResult = true;
                }
                // TODO: DI
                (testResult as TestResult).SetTimestamp(GetDateTimeAttribute(testResultElement, "timestamp"));
                testResult.SetOrigin(origin);
                testResult.SetTimeSpent(GetDoubleAttribute(testResultElement, "timeSpent"));
                testResult.PlatformId = GetStringAttribute(testResultElement, "platformId");
                testResult.PlatformUniqueId = GetGuidAttribute(testResultElement, "platformUniqueId");
                try {
                    var testResultDetails = from testResultDetail in testResultElement.Descendants("detail")
                                            select testResultDetail;
                    testResult.Details.AddRange(ImportTestResultDetails(testResultDetails)); // , testResult);
                } catch (Exception e) {
                    //                                cmdlet.WriteVerbose(cmdlet, eImportDetails);
                    // 20160125
                    Console.WriteLine(e.Message);
                }
                if (addTestResult)
                    importedTestResults.Add(testResult);
            }
            return importedTestResults;
        }

        TestStatuses GetTestResultStatus(XElement testResultElement)
        {
            return ("PASSED" == GetStringAttribute(testResultElement, "status")) ? TestStatuses.Passed : ("FAILED" == GetStringAttribute(testResultElement, "status")) ? TestStatuses.Failed : ("KNOWN ISSUE" == GetStringAttribute(testResultElement, "status")) ? TestStatuses.KnownIssue : TestStatuses.NotRun;
        }
        
        List<ITestResultDetail> ImportTestResultDetails(IEnumerable<XElement> testResultDetailElements)
        {
            var importedTestResultDetails = new List<ITestResultDetail>();
            if (null == testResultDetailElements) return importedTestResultDetails;
            
            foreach (var testResultDetailElement in testResultDetailElements) {
                var detail = new TestResultDetail {
                    TextDetail = GetStringAttribute(testResultDetailElement, "name")
                };
                var detailStatus = GetStringAttribute(testResultDetailElement, "status");
                switch (detailStatus.ToUpper()) {
                    case "FAILED":
                        detail.DetailStatus = TestStatuses.Failed;
                        break;
                    case "PASSED":
                        detail.DetailStatus = TestStatuses.Passed;
                        break;
                    case "KNOWNISSUE":
                        detail.DetailStatus = TestStatuses.KnownIssue;
                        break;
                    case "NOTTESTED":
                        detail.DetailStatus = TestStatuses.NotRun;
                        break;
                    default:
                        detail.DetailStatus = TestStatuses.NotRun;
                        break;
                }
                // 20160125
                importedTestResultDetails.Add(detail);
            }
            return importedTestResultDetails;
        }
        
        internal void SetSuiteStatus(ITestSuite testSuite, bool skipAutomatic)
        {
            var counterPassedResults = 0;
            var counterKnownIssueResults = 0;
            
            if (null != testSuite.TestScenarios && 0 < testSuite.TestScenarios.Count) {
                
                foreach (var scenario in testSuite.TestScenarios) {
                    
                    SetScenarioStatus(scenario, skipAutomatic);
                    
                    switch (scenario.enStatus) {
                        case TestStatuses.Passed:
                            counterPassedResults++;
                            if (TestStatuses.Failed != testSuite.enStatus)
                                testSuite.enStatus = TestStatuses.Passed;
                            break;
                        case TestStatuses.Failed:
                            testSuite.enStatus = TestStatuses.Failed;
                            return;
                        case TestStatuses.NotRun:
                            break;
                        case TestStatuses.KnownIssue:
                            counterKnownIssueResults++;
                            if (TestStatuses.Failed != testSuite.enStatus)
                                testSuite.enStatus = TestStatuses.Passed;
                            break;
                        default:
                            // 20130428
                            //throw new Exception("Invalid value for TestScenarioStatuses");
                            // as Not Tested
                            break;
                    }
                }
                
                if (0 == counterPassedResults && 0 < counterKnownIssueResults)
                    testSuite.enStatus = TestStatuses.KnownIssue;
                
                // 20150925
                // var testStatistics = new TestStatistics();
                var testStatistics = ProxyFactory.Get<TestStatistics>();
                testStatistics.RefreshSuiteStatistics(testSuite, skipAutomatic);
            }
        }
        
        internal void SetScenarioStatus(ITestScenario testScenario, bool skipAutomatic)
        {
            var counterPassedResults = 0;
            var counterKnownIssueResults = 0;
            
            if (null != testScenario.TestResults && 0 < testScenario.TestResults.Count) {
                foreach (var testResult in testScenario.TestResults) {

                    switch (testResult.enStatus) {
                        // 20150805
                        // case TestResultStatuses.Passed:
                        case TestStatuses.Passed:
                            counterPassedResults++;
                            // 20150805
                            // if (TestScenarioStatuses.Failed != testScenario.enStatus)
                            if (TestStatuses.Failed != testScenario.enStatus)
                                // 20150805
                                // testScenario.enStatus = TestScenarioStatuses.Passed;
                                testScenario.enStatus = TestStatuses.Passed;
                            break;
                        // 20150805
                        // case TestResultStatuses.Failed:
                        case TestStatuses.Failed:
                            // 20150805
                            // testScenario.enStatus = TestScenarioStatuses.Failed;
                            testScenario.enStatus = TestStatuses.Failed;
                            return;
                        // 20150805
                        // case TestResultStatuses.NotTested:
                        case TestStatuses.NotRun:
                            
                            break;
                        // 20150805
                        // case TestResultStatuses.KnownIssue:
                        case TestStatuses.KnownIssue:
                            counterKnownIssueResults++;
                            // 20150805
                            // if (TestScenarioStatuses.Failed != testScenario.enStatus)
                            if (TestStatuses.Failed != testScenario.enStatus)
                                // 20150805
                                // testScenario.enStatus = TestScenarioStatuses.Passed;
                                testScenario.enStatus = TestStatuses.Passed;
                            break;
                        default:
                            throw new Exception("Invalid value for TestResultStatuses");
                    }
                }
                if (0 == counterPassedResults && 0 < counterKnownIssueResults)
                    // 20150805
                    // testScenario.enStatus = TestScenarioStatuses.KnownIssue;
                    testScenario.enStatus = TestStatuses.KnownIssue;

                // 20150925
                // var testStatistics = new TestStatistics();
                var testStatistics = ProxyFactory.Get<TestStatistics>();
                testStatistics.RefreshScenarioStatistics(testScenario, skipAutomatic);
            }
        }
        
        string GetStringAttribute(XElement element, string name)
        {
            try {
                return element.Attribute(name).Value;
            }
            catch {
                return string.Empty;
            }
        }
        
        double GetDoubleAttribute(XElement element, string name)
        {
            try {
                return Convert.ToDouble(element.Attribute(name).Value);
            }
            catch {
                return 0;
            }
        }
        
        DateTime GetDateTimeAttribute(XElement element, string name)
        {
            try {
                return Convert.ToDateTime(element.Attribute(name).Value);
            }
            catch {
                return Convert.ToDateTime(0);
            }
        }
        
        Guid GetGuidAttribute(XElement element, string name)
        {
            try {
                return new Guid(element.Attribute(name).Value);
            }
            catch {
                return Guid.Empty;
            }
        }
    }
}
