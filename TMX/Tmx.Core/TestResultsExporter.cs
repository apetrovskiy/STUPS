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
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsExporter.
    /// </summary>
    public class TestResultsExporter
    {
        public void ExportResultsToXml(ISearchCmdletBaseDataObject cmdlet, string path, List<ITestSuite> suites)
        {
            try {
                var document = GetTestResultsAsXdocument(cmdlet, suites);
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
        
		public XDocument GetTestResultsAsXdocument(ISearchCmdletBaseDataObject searchCriteria, List<ITestSuite> suites)
		{
		    var suitesElement = GetTestResultsAsXelement(searchCriteria, suites);
			var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
			document.Add(suitesElement);
			return document;
		}

		public XElement GetTestResultsAsXelement(ISearchCmdletBaseDataObject searchCriteria, List<ITestSuite> suites)
		{
			var gathered = new GatherTestResultsCollections();
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
                                                 createXattribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(suite.Statistics.TimeSpent)),
                                                 new XAttribute("all", suite.Statistics.All.ToString()),
                                                 new XAttribute("passed", suite.Statistics.Passed.ToString()),
                                                 createXattribute(xmlStruct.FailedAttribute, suite.Statistics.Failed.ToString()),
                                                 new XAttribute("notTested", suite.Statistics.NotTested.ToString()),
                                                 new XAttribute("knownIssue", suite.Statistics.PassedButWithBadSmell.ToString()),
                                                 createXattribute("description", suite.Description),
                                                 createXattribute("platformId", suite.PlatformId),
                                                 // 20141119
                                                 createXattribute("platformUniqueId", suite.PlatformUniqueId),
                                                 CreateScenariosXElementCommon(
                                                     suite,
                                                     // scenarios,
                                                     scenarios.Where(scenario => scenario.SuiteId == suite.Id).OrderBy(scenario => scenario.Id),
                                                     // testResults,
                                                     testResults.Where(testResult => testResult.SuiteId == suite.Id).OrderBy(testResult => testResult.Id),
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
                // 20141119
                // where scenario.SuiteId == suite.Id && scenario.PlatformId == suite.PlatformId
                where scenario.SuiteId == suite.Id && scenario.PlatformUniqueId == suite.PlatformUniqueId
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
                                  // testResults,
                                  testResults.Where(testResult => testResult.SuiteId == suite.Id && testResult.ScenarioId == scenario.Id).OrderBy(testResult => testResult.Id),
                                  xmlStruct)
                             );
            return scenariosElement;
        }
        
        XElement getScenariosXElement(
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
                             createXattribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(suite.Statistics.TimeSpent)),
                             new XAttribute("all", scenario.Statistics.All.ToString()),
                             new XAttribute("passed", scenario.Statistics.Passed.ToString()),
                             createXattribute(xmlStruct.FailedAttribute, scenario.Statistics.Failed.ToString()),
                             new XAttribute("notTested", scenario.Statistics.NotTested.ToString()),
                             new XAttribute("knownIssue", scenario.Statistics.PassedButWithBadSmell.ToString()),
                             createXattribute("description", scenario.Description),
                             // 20141119
                             // createXattribute("platformId", scenario.PlatformId),
                             createXattribute("platformId", scenario.PlatformId),
                             createXattribute("platformUniqueId", scenario.PlatformUniqueId),
                             CreateTestResultsXElementCommon(
                                 suite,
                                 scenario,
                                 testResults,
                                 // testResults.Where(testResult => testResult.SuiteId == suite.Id && testResult.ScenarioId == scenario.Id).OrderBy(testResult => testResult.Id),
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
                // 20141119
                // testResult.PlatformId == scenario.PlatformId
                testResult.PlatformUniqueId == scenario.PlatformUniqueId
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
        
        XElement getTestResultsXElement(
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
                             createXattribute(xmlStruct.TimeSpentAttribute, Convert.ToInt32(testResult.TimeSpent)), // ??
                             createXelement(
                                 "source",
                                 createXattribute("scriptName", testResult.ScriptName),
                                 createXattribute("lineNumber", testResult.LineNumber),
                                 createXattribute("position", testResult.Position),
                                 createXattribute("code", testResult.Code)
                                ),
                             createXattribute(xmlStruct.TimeStampAttribute, testResult.Timestamp),
                             createXelement(
                                 "error",
                                 createXattribute("error", testResult.Error)
                                ),
                             createXattribute("screenshot", testResult.Screenshot),
                             createXattribute("description", testResult.Description),
                             createXattribute("platformId", testResult.PlatformId),
                             // 20141119
                             createXattribute("platformUniqueId", testResult.PlatformUniqueId),
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
                                                 createXattribute("name", testResultDetail.Name),
                                                 createXattribute(xmlStruct.TimeSpentAttribute, testResultDetail.Timestamp),
                                                 createXattribute("status", testResultDetail.DetailStatus)
                                                )
                            );

            return testResultDetailsElement;
        }
		
        XAttribute createXattribute(string name, object valueObject)
        {
			return null == valueObject ? null : new XAttribute(name, valueObject);
        }
        
        XElement createXelement(string name, params object[] content)
        {
			return null == content[0] ? null : new XElement(name, content);
        }
    }
}
