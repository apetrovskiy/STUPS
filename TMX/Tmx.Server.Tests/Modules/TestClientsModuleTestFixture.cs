/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/18/2014
 * Time: 9:54 PM
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
    /// Description of TestClientsModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestClientsModuleTestFixture
    {
        public TestClientsModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
        }
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
    	
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_react_on_registering_a_neww_test_client()
//        {
//        	// Given
//            var browser = new Browser(new DefaultNancyBootstrapper());
//            
//            // When
//            var response = browser.Post("/Results/suites/");
//            
//            // Then
//            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
//        }
//        
//        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
//        public void Should_create_a_test_suite()
//        {
//        	// Given
//            var browser = new Browser(new DefaultNancyBootstrapper());
//            var testSuiteNameExpected = "test suite name";
//            var testSuiteIdExpected = "111";
//            var testSuite = new TMX.TestSuite { Name = testSuiteNameExpected, Id = testSuiteIdExpected };
//            
//            // When
//            var response = browser.Post("/Results/suites/", (with) => {
//                with.JsonBody<TMX.TestSuite>(testSuite);
//            });
//            
//            // Then
//            Xunit.Assert.Equal(HttpStatusCode.Created, response.StatusCode);
//            Xunit.Assert.Equal(testSuiteNameExpected, TestData.CurrentTestSuite.Name);
//            Xunit.Assert.Equal(testSuiteIdExpected, TestData.CurrentTestSuite.Id);
//        }
    }
}
