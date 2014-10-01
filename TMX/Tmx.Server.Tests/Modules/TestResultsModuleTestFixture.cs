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
    using System.Management.Automation;
    using System.Reflection;
	using System.Xml.Linq;
	using NSubstitute;
    using Nancy;
    using Nancy.Testing;
	using Tmx.Interfaces.Server;
	using Tmx.Server.Modules;
    // using MbUnit.Framework;
    using NUnit.Framework;
	using Tmx;
	using Tmx.Interfaces.TestStructure;
    using Xunit;
    using Tmx.Interfaces;
    using PSTestLib;
    
    /// <summary>
    /// Description of TestResultsModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestResultsModuleTestFixture
    {
    	public TestResultsModuleTestFixture()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
		
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_ignore_empty_results_collection()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_test_suites_from_results_collection()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_test_suites_and_test_scenarios_from_results_collection()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
//    	
//    	[MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//    	public void Should_add_test_results_from_results_collection()
//    	{
//    	    Xunit.Assert.Equal(0, 1);
//    	}
    	
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_react_on_posting_no_data()
        {
        	var element = GIVEN_empty_element();
            
            var response = WHEN_Posting_TestResults<XElement>(element);
            
            THEN_HttpResponse_Is_ExpectationFailed(response);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_create_a_test_suite()
        {
			const string testSuiteNameExpected = "test suite name";
			const string testSuiteIdExpected = "111";
            var testSuite = GIVEN_test_suite(testSuiteIdExpected, testSuiteNameExpected);
            
            var response = WHEN_Posting_TestResults<TestSuite>(testSuite);
            
            THEN_HttpResponse_Is_Created(response);
            Xunit.Assert.Equal(testSuiteNameExpected, TestData.CurrentTestSuite.Name);
            Xunit.Assert.Equal(testSuiteIdExpected, TestData.CurrentTestSuite.Id);
            Xunit.Assert.Equal(TestData.GetDefaultPlatformId(), TestData.CurrentTestSuite.PlatformId);
        }
        
        [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
        [MbUnit.Framework.Test][NUnit.Framework.Test]// [Fact]
        public void Should_add_a_test_scenario()
        {
			const string testSuiteNameExpected = "test suite name";
			const string testSuiteIdExpected = "111";
			var testSuite = GIVEN_test_suite(testSuiteIdExpected, testSuiteNameExpected);
			const string testScenarioNameExpected = "test scenario name";
			const string testScenarioIdExpected = "222";
            var testScenario = GIVEN_test_scenario(testScenarioIdExpected, testScenarioNameExpected, testSuiteIdExpected, testSuite.PlatformId);
			
			var response = WHEN_Posting_TestResults<TestSuite>(testSuite);
			response = WHEN_Posting_TestResults<TestScenario>(testScenario);
			
            THEN_HttpResponse_Is_Created(response);
            Xunit.Assert.Equal(testScenarioNameExpected, TestData.CurrentTestScenario.Name);
            Xunit.Assert.Equal(testScenarioIdExpected, TestData.CurrentTestScenario.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_add_a_test_result()
        {
			const string testSuiteNameExpected = "test suite name";
			const string testSuiteIdExpected = "111";
            var testSuite = GIVEN_test_suite(testSuiteIdExpected, testSuiteNameExpected);
			const string testScenarioNameExpected = "test scenario name";
			const string testScenarioIdExpected = "222";
            var testScenario = GIVEN_test_scenario(testScenarioIdExpected, testScenarioNameExpected, testSuiteIdExpected, testSuite.PlatformId);
            var testResult = GIVEN_test_result("test result name", TestResultStatuses.Passed);
            
			var response = WHEN_Posting_TestResults<TestResult>(testResult);
			
            THEN_HttpResponse_Is_Created(response);
//            Xunit.Assert.Equal(testScenarioNameExpected, TestData.CurrentTestScenario.Name);
//            Xunit.Assert.Equal(testScenarioIdExpected, TestData.CurrentTestScenario.Id);
        }
        
        // ============================================================================================================================
        void probe()
        {
            var suite01 = Substitute.For<ITestSuite>();
            suite01.Id = "1";
            suite01.Name = "s01";
            var suite02 = Substitute.For<ITestSuite>();
            suite02.Id = "2";
            suite02.Name = "s02";
            
        }
        
        XElement getElementWithTestResults(IOrderedEnumerable<ITestSuite> suites, IOrderedEnumerable<ITestScenario> scenarios, IOrderedEnumerable<ITestResult> testResults)
        {
            return TmxHelper.CreateSuitesXElementWithParameters(suites, scenarios, testResults, (new XMLElementsNativeStruct()));            
        }
        
        XElement GIVEN_empty_element()
        {
            return new XElement("aaa");
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
        
        TestSuite GIVEN_test_suite(string testSuiteId, string testSuiteName)
        {
            var testSuite = Substitute.For<TestSuite>();
            testSuite.Name = testSuiteName;
            testSuite.Id = testSuiteId;
            testSuite.PlatformId = TestData.GetDefaultPlatformId();
            return testSuite;
        }
        
        TestScenario GIVEN_test_scenario(string testScenarioId, string testScenarioName, string testSuiteId, string testPlatformId)
        {
            var testScenario = Substitute.For<TestScenario>();
            testScenario.Name = testScenarioName;
            testScenario.Id = testScenarioId;
            testScenario.PlatformId = testPlatformId;
            testScenario.SuiteId = testSuiteId;
            return testScenario;
        }
        
        TestResult GIVEN_test_result(string testResultName, TestResultStatuses status)
        {
            var testResult = new TestResult();
            testResult.Name = testResultName;
            testResult.enStatus = status;
            return testResult;
        }
        
        BrowserResponse WHEN_Posting_TestResults<T>(T element)
        {
			var browser = TestFactory.GetBrowserForTestResultsModule();
			return browser.Post(getPathToResourcesCollection(typeof(T)), (with) => with.JsonBody<T>(element));
        }
        
        string getPathToResourcesCollection(MemberInfo type)
        {
            string path = string.Empty;
			switch (type.Name) {
			    case "XElement":
			        return UrnList.TestResultsPostingPoint;
			    case "TestSuite":
			        return UrnList.TestStructure_Root + UrnList.TestStructure_Suites;
			    case "TestScenario":
			        return UrnList.TestStructure_Root + UrnList.TestStructure_Scenarios;
			    case "TestResult":
			        return UrnList.TestStructure_Root + UrnList.TestStructure_Results;
			    default:
			        return path;
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
        
        void THEN_HttpResponse_Is_Created(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        void THEN_HttpResponse_Is_ExpectationFailed(BrowserResponse response)
        {
            Xunit.Assert.Equal(HttpStatusCode.ExpectationFailed, response.StatusCode);
        }
    }
}
