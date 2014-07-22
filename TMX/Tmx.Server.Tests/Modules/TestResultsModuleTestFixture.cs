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
    using System.Management.Automation;
    using Nancy;
    using Nancy.Testing;
    // using MbUnit.Framework;
    using NUnit.Framework;
	using Tmx;
	using Tmx.Core;
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
    	
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_react_on_posting_a_test_suite()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            
            // When
            // /Results/suites/
            var response = browser.Post(UrnList.TestStructure_Root + UrnList.TestStructure_Suites);
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_create_a_test_suite()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var testSuiteNameExpected = "test suite name";
            var testSuiteIdExpected = "111";
            var testSuite = new TestSuite { Name = testSuiteNameExpected, Id = testSuiteIdExpected };
            
            // When
            // /Results/suites/
            var response = browser.Post(UrnList.TestStructure_Root + UrnList.TestStructure_Suites, (with) => {
                with.JsonBody<TestSuite>(testSuite);
            });
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Xunit.Assert.Equal(testSuiteNameExpected, TestData.CurrentTestSuite.Name);
            Xunit.Assert.Equal(testSuiteIdExpected, TestData.CurrentTestSuite.Id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_add_a_test_scenario()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var testSuiteNameExpected = "test suite name";
            var testSuiteIdExpected = "111";
            var testSuite = new TestSuite { Name = testSuiteNameExpected, Id = testSuiteIdExpected };
            var testScenarioNameExpected = "test scenario name";
            var testScenarioIdExpected = "222";
            var testScenario = new TestScenario { Name = testScenarioNameExpected, Id = testScenarioIdExpected };
            
            // When
            // /Results/suites/
            /*
            var response = browser.Post(UrnList.TestStructure_Root + UrnList.TestStructure_Suites, (with) => {
                with.JsonBody<TestSuite>(testSuite);
            })
                .Then
                // /Results/scenarios/
                .Post(UrnList.TestStructure_Root + UrnList.TestStructure_Scenarios, (with) => {
                with.JsonBody<TestScenario>(testScenario);
            });
            */
			
			var response = browser.Post(UrnList.TestStructure_Root + UrnList.TestStructure_Suites, (with) => {
				with.JsonBody<ITestSuite>(testSuite);
			});
			response = browser.Post(UrnList.TestStructure_Root + UrnList.TestStructure_Scenarios, (with) => {
				with.JsonBody<ITestScenario>(testScenario);
			});
			
            // Then
            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Xunit.Assert.Equal(testScenarioNameExpected, TestData.CurrentTestScenario.Name);
            Xunit.Assert.Equal(testScenarioIdExpected, TestData.CurrentTestScenario.Id);
        }
    }
}
