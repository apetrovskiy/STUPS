/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/11/2014
 * Time: 7:09 PM
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
    /// Description of TestResultsExporter.
    /// </summary>
    public class TestResultsExporter
    {
        public virtual void ExportResultsToXml(ISearchCmdletBaseDataObject cmdlet, string path, List<ITestSuite> suites, List<ITestPlatform> platforms)
        {
            try {
                var document = GetTestResultsAsXdocument(cmdlet, suites, platforms);
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
        
        public XDocument GetTestResultsAsXdocument(ISearchCmdletBaseDataObject searchCriteria, List<ITestSuite> suites, List<ITestPlatform> platforms)
        {
            var suitesElement = GetTestResultsAsXelement(searchCriteria, suites);
            var platformsElement = GetTestPlatformsAsXelement(new XMLElementsNativeStruct(), platforms);
            var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            var rootElement = new XElement("results", platformsElement, suitesElement);
            document.Add(rootElement);
            return document;
        }
        
        XElement GetTestPlatformsAsXelement(IXMLElementsStruct xmlStruct, List<ITestPlatform> platforms)
        {
            var query = from platform in platforms
                select generateTestPlatformXelement(xmlStruct.PlatformNode, platform);
            var platformsElement = new XElement(xmlStruct.PlatformsNode, query);
            return platformsElement;
        }
        
        XElement generateTestPlatformXelement(string platformNodeName, ITestPlatform platform)
        {
            return new XElement(platformNodeName,
                new XAttribute("uniqueId", platform.UniqueId),
                new XAttribute("id", platform.Id ?? string.Empty),
                new XAttribute("name", platform.Name ?? string.Empty),
                CreateXattribute("description", platform.Description ?? string.Empty) //,
                
//                new XAttribute("created", platform.Created)
            );
        }
        
        public XElement GetTestResultsAsXelement(ISearchCmdletBaseDataObject searchCriteria, List<ITestSuite> suites)
        {
            // 20150925
            // var gathered = new GatherTestResultsCollections();
            var gathered = ProxyFactory.Get<GatherTestResultsCollections>();
            gathered.GatherCollections(searchCriteria, suites);
            var suitesElement = CreateSuitesXElementWithParameters(gathered.TestSuites, gathered.TestScenarios, gathered.TestResults, (new XMLElementsNativeStruct()));
            return suitesElement;
        }
        
        public XElement CreateSuitesXElementWithParameters(
                IOrderedEnumerable<ITestSuite> suites,
                IOrderedEnumerable<ITestScenario> scenarios,
                IOrderedEnumerable<ITestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {
            var suitesElement = 
                new XElement(xmlStruct.SuitesNode,
                             from suite in suites
                             select new XElement(xmlStruct.SuiteNode,
                                                 new XAttribute("uniqueId", suite.UniqueId),
                                                 new XAttribute("id", suite.Id),
                                                 new XAttribute("name", suite.Name),
                                                 new XAttribute("status", suite.Status),
                                                 CreateXattribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(suite.Statistics.TimeSpent)),
                                                 new XAttribute("all", suite.Statistics.All.ToString()),
                                                 new XAttribute("passed", suite.Statistics.Passed.ToString()),
                                                 CreateXattribute(xmlStruct.FailedAttribute, suite.Statistics.Failed.ToString()),
                                                 new XAttribute("notTested", suite.Statistics.NotTested.ToString()),
                                                 new XAttribute("knownIssue", suite.Statistics.PassedButWithBadSmell.ToString()),
                                                 CreateXattribute("description", suite.Description),
                                                 CreateXattribute("platformId", suite.PlatformId),
                                                 CreateXattribute("platformUniqueId", suite.PlatformUniqueId),
                                                 CreateScenariosXElementCommon(
                                                     suite,
                                                     // 20141122
                                                     // scenarios.Where(scenario => scenario.SuiteId == suite.Id).OrderBy(scenario => scenario.Id),
                                                     // testResults.Where(testResult => testResult.SuiteId == suite.Id).OrderBy(testResult => testResult.Id),
                                                     scenarios.Where(scenario => scenario.SuiteId == suite.Id && scenario.SuiteUniqueId == suite.UniqueId).OrderBy(scenario => scenario.Id),
                                                     testResults.Where(testResult => testResult.SuiteId == suite.Id && testResult.SuiteUniqueId == suite.UniqueId).OrderBy(testResult => testResult.Id),
                                                     xmlStruct)
                                                 )
                            );
            return suitesElement;
        }
        
        public XElement CreateScenariosXElementCommon(
                ITestSuite suite,
                IOrderedEnumerable<ITestScenario> scenarios,
                IOrderedEnumerable<ITestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {
            var testScenariosFiltered = 
                from scenario in scenarios
                where scenario.SuiteId == suite.Id && scenario.PlatformUniqueId == suite.PlatformUniqueId
                select scenario;

            if (!testScenariosFiltered.Any()) {
                return null;
            }
            
            var scenariosElement = 
                 new XElement(xmlStruct.ScenariosNode,
                              from scenario in testScenariosFiltered
                              select GetScenariosXElement(
                                  suite, 
                                  scenario,
                                  // 20141122
                                  // testResults.Where(testResult => testResult.SuiteId == suite.Id && testResult.ScenarioId == scenario.Id).OrderBy(testResult => testResult.Id),
                                  testResults.Where(
                                      testResult => testResult.SuiteId == suite.Id && 
                                      testResult.SuiteUniqueId == suite.UniqueId && 
                                      testResult.ScenarioId == scenario.Id && 
                                      testResult.ScenarioUniqueId == scenario.UniqueId).OrderBy(testResult => testResult.Id),
                                  xmlStruct)
                             );
            return scenariosElement;
        }
        
        XElement GetScenariosXElement(
                ITestSuite suite,
                ITestScenario scenario,
                IOrderedEnumerable<ITestResult> testResults,
                IXMLElementsStruct xmlStruct)
        {
            var scenariosElement =
                new XElement(xmlStruct.ScenarioNode,
                             new XAttribute("uniqueId", scenario.UniqueId),
                             new XAttribute("id", scenario.Id),
                             new XAttribute("name", scenario.Name),
                             new XAttribute("status", scenario.Status),
                             CreateXattribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(suite.Statistics.TimeSpent)),
                             new XAttribute("all", scenario.Statistics.All.ToString()),
                             new XAttribute("passed", scenario.Statistics.Passed.ToString()),
                             CreateXattribute(xmlStruct.FailedAttribute, scenario.Statistics.Failed.ToString()),
                             new XAttribute("notTested", scenario.Statistics.NotTested.ToString()),
                             new XAttribute("knownIssue", scenario.Statistics.PassedButWithBadSmell.ToString()),
                             CreateXattribute("description", scenario.Description),
                             CreateXattribute("platformId", scenario.PlatformId),
                             CreateXattribute("platformUniqueId", scenario.PlatformUniqueId),
                             CreateTestResultsXElementCommon(
                                 suite,
                                 scenario,
                                 testResults,
                                 xmlStruct)
                            );

            return scenariosElement;
        }
            
        public XElement CreateTestResultsXElementCommon(
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
                testResult.Name != null &&
                testResult.PlatformUniqueId == scenario.PlatformUniqueId
                select testResult;

            if (!testResultsFiltered.Any()) {
                return null;
            }
            
            var testResultsElement =
                new XElement(xmlStruct.TestResultsNode,
                             from testResult in testResultsFiltered
                             select GetTestResultsXElement(testResult, xmlStruct)
                            );

            return testResultsElement;
        }
        
        XElement GetTestResultsXElement(
                ITestResult testResult,
                IXMLElementsStruct xmlStruct)
        {
            var testResultsElement =
                new XElement(xmlStruct.TestResultNode,
                             new XAttribute("uniqueId", testResult.UniqueId),
                             new XAttribute("id", testResult.Id),
                             new XAttribute("name", testResult.Name),
                             new XAttribute("status", testResult.Status),
                             new XAttribute("origin", testResult.Origin),
                             CreateXattribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(testResult.TimeSpent)), // ??
                             CreateXelement(
                                 "source",
                                 CreateXattribute("scriptName", testResult.ScriptName),
                                 CreateXattribute("lineNumber", testResult.LineNumber),
                                 CreateXattribute("position", testResult.Position),
                                 CreateXattribute("code", testResult.Code)
                                ),
                             CreateXattribute(xmlStruct.TimeStampAttribute, testResult.Timestamp),
                             CreateXelement(
                                 "error",
                                 CreateXattribute("error", testResult.Error)
                                ),
                             CreateXattribute("screenshot", testResult.Screenshot),
                             CreateXattribute("description", testResult.Description),
                             CreateXattribute("platformId", testResult.PlatformId),
                             CreateXattribute("platformUniqueId", testResult.PlatformUniqueId),
                             CreateTestResultDetailsXElement(
                                 testResult,
                                 xmlStruct)
                            );

            return testResultsElement;
        }
        
        public XElement CreateTestResultDetailsXElement(
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
                                                 CreateXattribute("name", testResultDetail.Name),
                                                 CreateXattribute(xmlStruct.TimeSpentAttribute, testResultDetail.Timestamp),
                                                 CreateXattribute("status", testResultDetail.DetailStatus)
                                                )
                            );

            return testResultDetailsElement;
        }
        
        XAttribute CreateXattribute(string name, object valueObject)
        {
            return null == valueObject ? null : new XAttribute(name, valueObject);
        }
        
        XElement CreateXelement(string name, params object[] content)
        {
            return null == content[0] ? null : new XElement(name, content);
        }
    }
}
