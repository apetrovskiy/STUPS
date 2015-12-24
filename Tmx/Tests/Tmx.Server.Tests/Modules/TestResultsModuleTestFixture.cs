/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/13/2014
 * Time: 2:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;
    using NSubstitute;
    using Nancy;
    using Nancy.Testing;
    using Core;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Interfaces.Server;
    // using MbUnit.Framework;
    using NUnit.Framework;
    using Tmx;
    using Interfaces.TestStructure;
    using Xunit;
    using Interfaces;
    using Logic.ObjectModel.Objects;
    using UnitTestingHelpers;

    /// <summary>
    /// Description of TestResultsModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][TestFixture]
    public class TestResultsModuleTestFixture
    {
        ITestWorkflow _workflow;
        ITestRun _testRun;
        BrowserResponse _response;
        Browser _browser;
        
        public TestResultsModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestResultsModule();
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            _workflow = WorkflowCollection.Workflows.First();
            _testRun = TestRunQueue.TestRuns.First();
        }
        
        [MbUnit.Framework.SetUp][SetUp]
        public void SetUp()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForTestResultsModule();
            TestFactory.GetTestRunWithStatus(TestRunStatuses.Running);
            _workflow = WorkflowCollection.Workflows.First();
            _testRun = TestRunQueue.TestRuns.First();
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_ignore_empty_results_collection()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_test_suites_from_results_collection()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_test_suites_and_test_scenarios_from_results_collection()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_add_test_results_from_results_collection()
//        {
//            Xunit.Assert.Equal(0, 1);
//        }
        
        [MbUnit.Framework.Test][Test][Fact]
        public void ShouldAcceptWhenPostingNoData()
        {
            var testResultsExporter = new TestResultsExporter();
            testResultsExporter.GetTestResultsAsXdocument(new SearchCmdletBaseDataObject { FilterAll = true }, new List<ITestSuite>(), new List<ITestPlatform>());
            
            var dataObject = new TestResultsDataObject {
                Data = string.Empty
            };
            
            WhenPostingTestResults(dataObject);
            
            ThenHttpResponseIsCreated();
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_react_on_posting_bunch_of_data()
//        {
////            var xDoc = XDocument.Load(@"../../Modules/TMX_report.xml");
//            var xDoc = XDocument.Load(@"../../Modules/TMX_red_report.xml");
//            
//            var dataObject = new TestResultsDataObject {
//                Data = xDoc.ToString()
//            };
//            
//            WhenPostingTestResults<TestResultsDataObject>(dataObject);
//            
//            ThenHttpResponseIsCreated();
//        }
        
        [MbUnit.Framework.Test][Test][Fact]
        public void ShouldSendOneTestSuiteWithInnerData()
        {
            var testPlatform = new TestPlatform();
            var suites = GivenOneTestSuiteWithInnerHierarchy("1", "2", "3", testPlatform.UniqueId);
            var testResultsExporter = new TestResultsExporter();
            var xDoc = testResultsExporter.GetTestResultsAsXdocument(new SearchCmdletBaseDataObject {
                                                                         FilterAll = true,
                                                                         OrderById = true
                                                                     },
                                                                     suites,
                                                                     new List<ITestPlatform> { testPlatform });
            var dataObject = new TestResultsDataObject {
                Data = xDoc.ToString()
            };
            
            WhenPostingTestResults(dataObject);
            
            ThenHttpResponseIsCreated();
            Xunit.Assert.Equal(suites[0].Id, _testRun.TestSuites[0].Id);
            Xunit.Assert.Equal(suites[0].TestScenarios[0].Id, _testRun.TestSuites[0].TestScenarios[0].Id);
            Xunit.Assert.Equal(suites[0].TestScenarios[0].TestResults[0].Id, _testRun.TestSuites[0].TestScenarios[0].TestResults[0].Id);
        }
        
        [MbUnit.Framework.Test][Test][Fact]
        public void ShouldSendThreeTestSuitesWithInnerData()
        {
            var guid = Guid.NewGuid();
            var suites = GivenOneTestSuiteWithInnerHierarchy("1", "2", "3", guid);
            suites.AddRange(GivenOneTestSuiteWithInnerHierarchy("10", "20", "30", guid));
            suites.AddRange(GivenOneTestSuiteWithInnerHierarchy("100", "200", "300", guid));
            var testResultsExporter = new TestResultsExporter();
            var xDoc = testResultsExporter.GetTestResultsAsXdocument(new SearchCmdletBaseDataObject {
                                                                         FilterAll = true,
                                                                         OrderById = true
                                                                     },
                                                                     suites,
                                                                     new List<ITestPlatform> { new TestPlatform { UniqueId = guid } });
            var dataObject = new TestResultsDataObject {
                Data = xDoc.ToString()
            };
            
            Console.WriteLine(xDoc.ToString());
            
            WhenPostingTestResults(dataObject);
            
            ThenHttpResponseIsCreated();
            Xunit.Assert.Equal(suites[0].Id, _testRun.TestSuites[0].Id);
            Xunit.Assert.Equal(suites[0].TestScenarios[0].Id, _testRun.TestSuites[0].TestScenarios[0].Id);
            Xunit.Assert.Equal(suites[0].TestScenarios[0].TestResults[0].Id, _testRun.TestSuites[0].TestScenarios[0].TestResults[0].Id);
            
            Xunit.Assert.Equal(suites[1].Id, _testRun.TestSuites[1].Id);
            Xunit.Assert.Equal(suites[1].TestScenarios[0].Id, _testRun.TestSuites[1].TestScenarios[0].Id);
            Xunit.Assert.Equal(suites[1].TestScenarios[0].TestResults[0].Id, _testRun.TestSuites[1].TestScenarios[0].TestResults[0].Id);
            
            Xunit.Assert.Equal(suites[2].Id, _testRun.TestSuites[2].Id);
            Xunit.Assert.Equal(suites[2].TestScenarios[0].Id, _testRun.TestSuites[2].TestScenarios[0].Id);
            Xunit.Assert.Equal(suites[2].TestScenarios[0].TestResults[0].Id, _testRun.TestSuites[2].TestScenarios[0].TestResults[0].Id);
        }
        
        [MbUnit.Framework.Test][Test][Fact]
        public void ShouldReceiveTestResultsOneSuiteFromTestRun()
        {
            var suites = GivenOneTestSuiteWithInnerHierarchy("10", "11", "12", Guid.NewGuid());
            _testRun.TestSuites.AddRange(suites);
            
            WhenGettingTestResults();
            
            Console.WriteLine(_response.Body);
            Console.WriteLine(_response.Body.GetType().Name);
//            var model = _response..GetModel<TestResultsDataObject>();
//            var loadedSuites = _response..Body as ITestSuite[];
//            Xunit.Assert.Equal(suites[0].Id, loadedSuites[0].Id);
        }
        
        [MbUnit.Framework.Test][Test][Fact]
        public void ShouldReceiveTestResultsTwoSuitesFromTestRun()
        {
            var suites = GivenOneTestSuiteWithInnerHierarchy("10", "11", "12", Guid.NewGuid());
            suites.AddRange(GivenOneTestSuiteWithInnerHierarchy("10", "11", "12", Guid.NewGuid()));
            _testRun.TestSuites.AddRange(suites);
            
            WhenGettingTestResults();
            
            Console.WriteLine(_response.Body);
            Console.WriteLine(_response.Body.GetType().Name);
//            var model = _response.GetModel<TestResultsDataObject>();
        }
        
        // ============================================================================================================================
        void Probe()
        {
            var suite01 = Substitute.For<ITestSuite>();
            suite01.Id = "1";
            suite01.Name = "s01";
            var suite02 = Substitute.For<ITestSuite>();
            suite02.Id = "2";
            suite02.Name = "s02";
            
        }
        
        XElement GetElementWithTestResults(IOrderedEnumerable<ITestSuite> suites, IOrderedEnumerable<ITestScenario> scenarios, IOrderedEnumerable<ITestResult> testResults)
        {
            var testResultsExporter = new TestResultsExporter();
            return testResultsExporter.CreateSuitesXElementWithParameters(suites, scenarios, testResults, (new XMLElementsNativeStruct()));
        }
        
        XElement GivenEmptyElement()
        {
            return new XElement("suites");
        }
        
        XElement GivenSuiteElement()
        {
            var suites = new XElement("suites");
            suites.AddFirst(new XElement("suite"));
            return suites;
        }
        
        List<ITestSuite> GivenOneTestSuiteWithInnerHierarchy(string suiteId, string scenarioId, string testResultId, Guid platformId)
        {
            var suites = new List<ITestSuite>() {
                new TestSuite {
                    Id = suiteId,
                    Name = "s01",
                    PlatformUniqueId = platformId
                }
            };
            var testScenario = new TestScenario {
                Id = scenarioId,
                Name = "sc01",
                PlatformUniqueId = platformId,
                SuiteId = suiteId,
                // 20141122
                SuiteUniqueId = suites[0].UniqueId
            };
            testScenario.TestResults.Add(new TestResult {
                Id = testResultId,
                Name = "tr01",
                PlatformUniqueId = platformId,
                SuiteId = suiteId,
                ScenarioId = scenarioId,
                // 20141122
                SuiteUniqueId = suites[0].UniqueId,
                ScenarioUniqueId = testScenario.UniqueId,
                // 20150908
                // experimental
                // support for technical test results (back again)
                // Origin = TestResultOrigins.Logical,
                Origin = TestResultOrigins.Technical,
                
                // 20150908
                // experimental
                // support for technical test results (back again)
                //enStatus = TestStatuses.Passed
                enStatus = TestStatuses.Failed
            });
            suites[0].TestScenarios.Add(testScenario);
            return suites;
        }
        
//        XElement GIVEN_one_test_suite()
//        {
//            return new XElement("aaa");
//        }
//        
//        XElement GIVEN_three_test_suites()
//        {
//            return new XElement("aaa");
//        }
//        
//        XElement GIVEN_one_test_suite_and_one_test_scenario()
//        {
//            return new XElement("aaa");
//        }
//        
//        XElement GIVEN_one_test_suite_and_three_test_scenarios()
//        {
//            return new XElement("aaa");
//        }
//        
//        XElement GIVEN_one_test_suite_and_one_test_scenario_and_one_test_result()
//        {
//            return new XElement("aaa");
//        }
        
        TestSuite GivenTestSuite(string testSuiteId, string testSuiteName)
        {
            var testSuite = Substitute.For<TestSuite>();
            testSuite.Name = testSuiteName;
            testSuite.Id = testSuiteId;
            testSuite.PlatformUniqueId = TestData.GetDefaultPlatformUniqueId();
            return testSuite;
        }
        
        TestScenario GivenTestScenario(string testScenarioId, string testScenarioName, string testSuiteId, Guid testPlatformId)
        {
            var testScenario = Substitute.For<TestScenario>();
            testScenario.Name = testScenarioName;
            testScenario.Id = testScenarioId;
            testScenario.PlatformUniqueId = testPlatformId;
            testScenario.SuiteId = testSuiteId;
            return testScenario;
        }

        TestResult GivenTestResult(string testResultName, TestStatuses status)
        {
            var testResult = new TestResult();
            testResult.Name = testResultName;
            testResult.enStatus = status;
            return testResult;
        }
        
        void WhenPostingTestResults<T>(T element)
        {
            _response = _browser.Post(GetPathToResourcesCollection(typeof(T)), (with) => {
                                          with.JsonBody(element);
                                          with.Accept("application/json");
                                      });
        }
        
        void WhenGettingTestResults()
        {
            _response = _browser.Get(GetPathToResourcesCollection(typeof(List<ITestSuite>)), (with) => with.Accept("application/json"));
        }
        
        string GetPathToResourcesCollection(MemberInfo type)
        {
            string path = string.Empty;
            switch (type.Name) {
                case "XElement":
                case "XDocument":
                case ".XDocument":
                case "String":
                    return UrlList.TestResults_Root + "/" + _testRun.Id + UrlList.TestResultsPostingPoint_forClient_relPath;
                default:
                    return UrlList.TestResults_Root + "/" + _testRun.Id + UrlList.TestResultsPostingPoint_forClient_relPath;
            }
        }
        
//        ITestClient givenSendingRegistration(ITestClient testClient)
//        {
//            var response = whenSendingRegistration(testClient);
//            return response.Body.DeserializeJson<TestClient>();
//        }
//        
//        BrowserResponse whenSendingRegistration(ITestClient testClient)
//        {
//            var browser = TestFactory.GetBrowserForTestResultsModule();
//            return browser.Post(UrnList.TestClientRegistrationPoint, with => with.JsonBody<ITestClient>(testClient));
//        }
//        
//        void whenSendingDeregistration(ITestClient testClient)
//        {
//            var browser = TestFactory.GetBrowserForTestResultsModule();
//            browser.Delete(UrnList.TestClients_Root + "/" + testClient.Id);
//        }
        
        void ThenHttpResponseIsCreated()
        {
            Xunit.Assert.Equal(HttpStatusCode.Created, _response.StatusCode);
        }
        
        void ThenHttpResponseIsExpectationFailed()
        {
            Xunit.Assert.Equal(HttpStatusCode.ExpectationFailed, _response.StatusCode);
        }
    }
}
