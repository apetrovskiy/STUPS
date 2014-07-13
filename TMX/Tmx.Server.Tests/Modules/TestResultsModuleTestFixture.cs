/*
 * Created by SharpDevelop.
 * User: Alexander
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
    using MbUnit.Framework;
    using NUnit.Framework;
	using TMX;
	using TMX.Interfaces.TestStructure;
    using Xunit;
    using Tmx;
    using PSTestLib;
    
    /// <summary>
    /// Description of TestResultsModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestResultsModuleTestFixture
    {
    	public TestResultsModuleTestFixture()
    	{
            PSCmdletBase.UnitTestMode = true;
            
            if (0 < PSTestLib.UnitTestOutput.Count) {

                PSTestLib.UnitTestOutput.Clear();
            }
            
            TMX.TestData.ResetData();
    	}
    	
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
            PSCmdletBase.UnitTestMode = true;
            
            if (0 < PSTestLib.UnitTestOutput.Count) {

                PSTestLib.UnitTestOutput.Clear();
            }
            
            TMX.TestData.ResetData();
    	}
    	
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_react_on_posting_a_test_suite()
//        {
//        	// Given
//            var browser = new Browser(new DefaultNancyBootstrapper());
//            
//            // When
//            var response = browser.Post("/Results/suites/");
//            
//            // Then
//            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
//        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_create_a_test_suite()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var testSuiteNameExpected = "test suite name";
            var testSuiteIdExpected = "111";
            var testSuite = new TMX.TestSuite { Name = testSuiteNameExpected, Id = testSuiteIdExpected };
            
            // When
            var response = browser.Post("/Results/suites/", (with) => {
                                        	// with.JsonBody<TMX.TestSuite>(testSuite);
                                        	// with.
                                        });
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
            var testSuite = new TMX.TestSuite { Name = testSuiteNameExpected, Id = testSuiteIdExpected };
            var testScenarioNameExpected = "test scenario name";
            var testScenarioIdExpected = "222";
            var testScenario = new TMX.TestScenario { Name = testScenarioNameExpected, Id = testScenarioIdExpected };
            
            // When
            var response = browser.Post("/Results/suites/", (with) => {
                                        	with.JsonBody<TMX.TestSuite>(testSuite);
                                        });
            response = browser.Post("/Results/scenarios/", (with) => {
                                        	with.JsonBody<TMX.TestScenario>(testScenario);
                                        });
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Xunit.Assert.Equal(testScenarioNameExpected, TestData.CurrentTestScenario.Name);
            Xunit.Assert.Equal(testScenarioIdExpected, TestData.CurrentTestScenario.Id);
        }
    }
}
