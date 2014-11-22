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
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsImporter.
    /// </summary>
    public class TestResultsImporter
    {
        public XDocument ImportedDocument { get; set; }
        
        public void MergeTestSuites(List<ITestSuite> sourceTestSuites, List<ITestSuite> testSuitesToAdd)
        {
            foreach (var testSuite in testSuitesToAdd) {
                if (sourceTestSuites.All(ts => ts.UniqueId != testSuite.UniqueId)) {
                    sourceTestSuites.Add(testSuite);
                    continue;
                }
                var existingTestSuite = sourceTestSuites.First(ts => ts.UniqueId == testSuite.UniqueId);
                MergeTestScenarios(existingTestSuite.TestScenarios, testSuite.TestScenarios);
            }
        }
        
        void MergeTestScenarios(List<ITestScenario> sourceTestScenarios, List<ITestScenario> testScenariosToAdd)
        {
            foreach (var testScenario in testScenariosToAdd) {
                if (sourceTestScenarios.All(tsc => tsc.UniqueId != testScenario.UniqueId)) {
                    sourceTestScenarios.Add(testScenario);
                    continue;
                }
                var existingTestScenario = sourceTestScenarios.First(tsc => tsc.UniqueId == testScenario.UniqueId);
                MergeTestResults(existingTestScenario.TestResults, testScenario.TestResults);
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
Console.WriteLine("======================= source platforms =======================");
foreach(var p in sourceTestPlatforms)
    Console.WriteLine(p.Id + " " + p.Name + " " + p.UniqueId);
Console.WriteLine("======================= new platforms =======================");
foreach(var p in testPlatformsToAdd)
    Console.WriteLine(p.Id + " " + p.Name + " " + p.UniqueId);
//            foreach (var testPlatform in testPlatformsToAdd)
//                if (sourceTestPlatforms.All(tr => tr.UniqueId != testPlatform.UniqueId))
//                    sourceTestPlatforms.Add(testPlatform);
            sourceTestPlatforms.AddRange(testPlatformsToAdd.Where(tp => !sourceTestPlatforms.Contains(tp)));
        }
        
        public bool LoadDocument(IImportExportCmdletBaseDataObject cmdlet, string path)
        {
            try {
                
                string pathToImportFile = cmdlet.Path;
                
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
                return false;
            }
        }
        
//        public List<ITestPlatform> ImportPlatformsFromXML(IImportExportCmdletBaseDataObject cmdlet, string path)
//        {
//            try {
//                
//                string pathToImportFile = cmdlet.Path;
//                
//                if (!System.IO.File.Exists(pathToImportFile)) {
//                    throw new Exception(
//                        "There is no such file '" +
//                        cmdlet.Path +
//                        "'.");
//                }
//                
//                var xDoc = XDocument.Load(pathToImportFile);
//                // 20141120
//                // importTestPlatformFromXdocument(xDoc);
//                // MergeTestPlatforms(TestData.TestPlatforms, importTestPlatformFromXdocument(xDoc));
//                return importTestPlatformFromXdocument(xDoc);
//            }
//            catch (Exception eImportDocument) {
//                throw new Exception(
//                    "Unable to load an XML report from the file '" +
//                    path +
//                    "'. " + 
//                    eImportDocument.Message);
//            }
//        }
        
//        public List<ITestSuite> ImportResultsFromXML(IImportExportCmdletBaseDataObject cmdlet, string path)
//        {
//            try {
//                
//                string pathToImportFile = cmdlet.Path;
//                
//                if (!System.IO.File.Exists(pathToImportFile)) {
//                    throw new Exception(
//                        "There is no such file '" +
//                        cmdlet.Path +
//                        "'.");
//                }
//                
//                var xDoc = XDocument.Load(pathToImportFile);
//                // 20141120
//                // importTestPlatformFromXdocument(xDoc);
//                // MergeTestPlatforms(TestData.TestPlatforms, importTestPlatformFromXdocument(xDoc));
//                return ImportTestResultsFromXdocument(xDoc);
//            }
//            catch (Exception eImportDocument) {
//                throw new Exception(
//                    "Unable to load an XML report from the file '" +
//                    path +
//                    "'. " + 
//                    eImportDocument.Message);
//            }
//        }
        
        public List<ITestPlatform> ImportTestPlatformFromXdocument(XDocument xDoc)
        {
            var df = xDoc.Root.Name.Namespace;
            var platforms = from platform in xDoc.Descendants("testplatform")
                                  where platform.Attribute("name").Value != TestData.DefaultPlatformName
                                  select platform;
            return importTestPlatforms(platforms);
        }
        
        List<ITestPlatform> importTestPlatforms(IEnumerable<XElement> platformElements)
        {
            var importedTestPlatforms = new List<ITestPlatform>();
            
            foreach (var platformElement in platformElements) {
                bool addTestPlatform = false;
                var testPlatform = importedTestPlatforms.FirstOrDefault(tp => tp.Id == getStringAttribute(platformElement, "id") &&
                                                                        tp.Name == getStringAttribute(platformElement, "name") &&
                                                                        tp.UniqueId == getGuidAttribute(platformElement, "uniqueId"));
                
                if (null == testPlatform) {
                    testPlatform = new TestPlatform {
                        UniqueId = getGuidAttribute(platformElement, "uniqueId"),
                        Id = getStringAttribute(platformElement, "id"),
                        Name = getStringAttribute(platformElement, "name"),
                        Description = getStringAttribute(platformElement, "description")
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
            var testStatistics = new TestStatistics();
            
			foreach (var suiteElement in suiteElements) {
				string suiteDescription = string.Empty;
                suiteDescription = getStringAttribute(suiteElement, "description");
				
                bool addTestSuite = false;
                var testSuite = importedTestSuites.FirstOrDefault(ts => ts.Id == getStringAttribute(suiteElement, "id") &&
                                                         ts.Name == getStringAttribute(suiteElement, "name") &&
                                                         ts.PlatformUniqueId == getGuidAttribute(suiteElement, "platformUniqueId"));
                
                if (null == testSuite) {
                    testSuite = new TestSuite {
                        UniqueId = getGuidAttribute(suiteElement, "uniqueId"),
                        Id = getStringAttribute(suiteElement, "id"),
                        Name = getStringAttribute(suiteElement, "name"),
                        PlatformId = getStringAttribute(suiteElement, "platformId"),
                        PlatformUniqueId = getGuidAttribute(suiteElement, "platformUniqueId"),
                        Description = suiteDescription,
                        TimeSpent = getDoubleAttribute(suiteElement, "timeSpent")
                    };
                    addTestSuite = true;
                }
                
                var scenarioElements = from scenarioElement in suiteElement.Descendants("scenario")
                                            where getStringAttribute(scenarioElement, "name") != TestData.Autogenerated
                                            && testSuite.PlatformUniqueId == getGuidAttribute(scenarioElement, "platformUniqueId")
                                            select scenarioElement;
                testSuite.TestScenarios.AddRange(importTestScenarios(scenarioElements, testSuite.Id));
				testStatistics.RefreshSuiteStatistics(testSuite, true);
				setSuiteStatus(testSuite, true);
				if (addTestSuite)
				   importedTestSuites.Add(testSuite);
			}
            return importedTestSuites;
		}

		List<ITestScenario> importTestScenarios(IEnumerable<XElement> scenarioElements, string suiteId)
		{
            var importedTestScenarios = new List<ITestScenario>();
            if (null == scenarioElements) return importedTestScenarios;
            
			foreach (var scenarioElement in scenarioElements) {
				string scenarioDescription = string.Empty;
                scenarioDescription = getStringAttribute(scenarioElement, "description");
				
                bool addTestScenario = false;
                var testScenario = importedTestScenarios.FirstOrDefault(tsc => tsc.Id == getStringAttribute(scenarioElement, "id") &&
                                                               tsc.Name == getStringAttribute(scenarioElement, "name") &&
                                                               tsc.PlatformUniqueId == getGuidAttribute(scenarioElement, "platformUniqueId"));
                
                if (null == testScenario) {
                    testScenario = new TestScenario {
                        UniqueId = getGuidAttribute(scenarioElement, "uniqueId"),
                        Id = getStringAttribute(scenarioElement, "id"),
                        Name = getStringAttribute(scenarioElement, "name"),
                        PlatformId = getStringAttribute(scenarioElement, "platformId"),
                        PlatformUniqueId = getGuidAttribute(scenarioElement, "platformUniqueId"),
                        Description = scenarioDescription,
                        TimeSpent = getDoubleAttribute(scenarioElement, "timeSpent"),
                        SuiteId = suiteId
                    };
                    addTestScenario = true;
                }
                var testResultElements = from testResultElement in scenarioElement.Descendants("testResult")
                    where testScenario.PlatformUniqueId == getGuidAttribute(testResultElement, "platformUniqueId")
                                  //where testResult.Attribute("name").Value != "autoclosed"
				select testResultElement;
                testScenario.TestResults.AddRange(importTestResults(testResultElements, testScenario.SuiteId, testScenario.Id));
                if (addTestScenario)
                    importedTestScenarios.Add(testScenario);
			}
            return importedTestScenarios;
		}
		
		List<ITestResult> importTestResults(IEnumerable<XElement> testResultElements, string suiteId, string scenarioId)
		{
            var importedTestResults = new List<ITestResult>();
            if (null == testResultElements) return importedTestResults;
            
			foreach (var testResultElement in testResultElements) {
				bool passedValue = false;
				bool knownIssueValue = false;
                passedValue |= "PASSED" == getStringAttribute(testResultElement, "status");
                knownIssueValue |= "KNOWN ISSUE" == getStringAttribute(testResultElement, "status");
				TestResultOrigins origin = TestResultOrigins.Logical;
                if ("TECHNICAL" == getStringAttribute(testResultElement, "origin").ToUpper())
                    origin = TestResultOrigins.Technical;
                if ("AUTOMATIC" == getStringAttribute(testResultElement, "origin").ToUpper())
                    origin = TestResultOrigins.Automatic;
				if ((TestResultOrigins.Technical == origin) &&
				    passedValue) {
					continue;
				}
				string testResultDescription = string.Empty;
                testResultDescription = getStringAttribute(testResultElement, "description");
				
                bool addTestResult = false;
                var testResult = importedTestResults.FirstOrDefault(tr => tr.Id == getStringAttribute(testResultElement, "id") &&
                                                           tr.Name == getStringAttribute(testResultElement, "name"));

				if (null == testResult) {
    				testResult = new TestResult {
				        UniqueId = getGuidAttribute(testResultElement, "uniqueId"),
    				    Id = getStringAttribute(testResultElement, "id"),
    				    Name = getStringAttribute(testResultElement, "name"),
    				    Description = testResultDescription,
    				    enStatus = (!passedValue ? TestResultStatuses.Failed : knownIssueValue ? TestResultStatuses.KnownIssue : passedValue ? TestResultStatuses.Passed : TestResultStatuses.NotTested),
    				    SuiteId = suiteId,
    				    ScenarioId = scenarioId
    				};
				    addTestResult = true;
				}
				// TODO: DI
				(testResult as TestResult).SetTimestamp(getDateTimeAttribute(testResultElement, "timestamp"));
				testResult.SetOrigin(origin);
				testResult.SetTimeSpent(getDoubleAttribute(testResultElement, "timeSpent"));
                testResult.PlatformId = getStringAttribute(testResultElement, "platformId");
                testResult.PlatformUniqueId = getGuidAttribute(testResultElement, "platformUniqueId");
				try {
					// lastTestResultDetailName = string.Empty;
                    var testResultDetails = from testResultDetail in testResultElement.Descendants("detail")
                                            select testResultDetail;
//					if (null == testResultDetails || !testResultDetails.Any())
//						continue;
					testResult.Details.AddRange(importTestResultDetails(testResultDetails)); // , testResult);
				} catch (Exception e) {
					//                                cmdlet.WriteVerbose(cmdlet, eImportDetails);
				}
				if (addTestResult)
				    importedTestResults.Add(testResult);
			}
            return importedTestResults;
		}

		List<ITestResultDetail> importTestResultDetails(IEnumerable<XElement> testResultDetailElements)
		{
		    var importedTestResultDetails = new List<ITestResultDetail>();
		    if (null == testResultDetailElements) return importedTestResultDetails;
		    
			foreach (var testResultDetailElement in testResultDetailElements) {
				var detail = new TestResultDetail {
					TextDetail = getStringAttribute(testResultDetailElement, "name")
				};
				string detailStatus = getStringAttribute(testResultDetailElement, "status");
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
			}
		    return importedTestResultDetails;
		}
		
        internal void setSuiteStatus(ITestSuite testSuite, bool skipAutomatic)
        {
            int counterPassedResults = 0;
            int counterKnownIssueResults = 0;
            
            if (null != testSuite.TestScenarios && 0 < testSuite.TestScenarios.Count) {
                
                foreach (var scenario in testSuite.TestScenarios) {
                    
                    setScenarioStatus(scenario, skipAutomatic);
                    
                    switch (scenario.enStatus) {
                        case TestScenarioStatuses.Passed:
                            counterPassedResults++;
                            if (TestSuiteStatuses.Failed != testSuite.enStatus)
                                testSuite.enStatus = TestSuiteStatuses.Passed;
                            break;
                        case TestScenarioStatuses.Failed:
                            testSuite.enStatus = TestSuiteStatuses.Failed;
                            return;
                        case TestScenarioStatuses.NotTested:
                            break;
                        case TestScenarioStatuses.KnownIssue:
                            counterKnownIssueResults++;
                            if (TestSuiteStatuses.Failed != testSuite.enStatus)
                                testSuite.enStatus = TestSuiteStatuses.Passed;
                            break;
                        default:
                            // 20130428
                            //throw new Exception("Invalid value for TestScenarioStatuses");
                            // as Not Tested
                            break;
                    }
                }
            	
                if (0 == counterPassedResults && 0 < counterKnownIssueResults)
                    testSuite.enStatus = TestSuiteStatuses.KnownIssue;
                
                var testStatistics = new TestStatistics();
                testStatistics.RefreshSuiteStatistics(testSuite, skipAutomatic);
            }
        }
        
        internal void setScenarioStatus(ITestScenario testScenario, bool skipAutomatic)
        {
            int counterPassedResults = 0;
            int counterKnownIssueResults = 0;
            
            if (null != testScenario.TestResults && 0 < testScenario.TestResults.Count) {
                foreach (var testResult in testScenario.TestResults) {

                    switch (testResult.enStatus) {
                        case TestResultStatuses.Passed:
                            counterPassedResults++;
                            if (TestScenarioStatuses.Failed != testScenario.enStatus)
                                testScenario.enStatus = TestScenarioStatuses.Passed;
                            break;
                        case TestResultStatuses.Failed:
                            testScenario.enStatus = TestScenarioStatuses.Failed;
                            return;
                        case TestResultStatuses.NotTested:
                            
                            break;
                        case TestResultStatuses.KnownIssue:
                            counterKnownIssueResults++;
                            if (TestScenarioStatuses.Failed != testScenario.enStatus)
                                testScenario.enStatus = TestScenarioStatuses.Passed;
                            break;
                        default:
                            throw new Exception("Invalid value for TestResultStatuses");
                    }
                }
                if (0 == counterPassedResults && 0 < counterKnownIssueResults)
                    testScenario.enStatus = TestScenarioStatuses.KnownIssue;
                
                var testStatistics = new TestStatistics();
                testStatistics.RefreshScenarioStatistics(testScenario, skipAutomatic);
            }
        }
        
		string getStringAttribute(XElement element, string name)
		{
			try {
				return element.Attribute(name).Value;
			}
			catch {
				return string.Empty;
			}
		}
		
		double getDoubleAttribute(XElement element, string name)
		{
			try {
		        return Convert.ToDouble(element.Attribute(name).Value);
			}
			catch {
				return 0;
			}
		}
		
		DateTime getDateTimeAttribute(XElement element, string name)
		{
			try {
		        return Convert.ToDateTime(element.Attribute(name).Value);
			}
			catch {
				return Convert.ToDateTime(0);
			}
		}
		
		Guid getGuidAttribute(XElement element, string name)
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
