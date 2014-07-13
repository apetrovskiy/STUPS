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
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
    using Xunit;
    using Tmx;
    
    /// <summary>
    /// Description of TestResultsModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TestResultsModuleTestFixture
    {
        [MbUnit.Framework.Test]
        [NUnit.Framework.Test]
        [Fact]
        public void Should_react_on_posting_a_test_suite()
        {
            var sut = new Browser(new DefaultNancyBootstrapper());
            
            var actual = sut.Post("/Results/suites/");
            
            Xunit.Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
        }
        
        [MbUnit.Framework.Test]
        [NUnit.Framework.Test]
        [Fact]
        public void Should_create_a_test_suite()
        {
            var sut = new Browser(new DefaultNancyBootstrapper());
            var testSuiteNameExpected = "test suite name";
            var testSuiteIdExpected = "111";
            var testSuite = new TMX.TestSuite(testSuiteNameExpected, testSuiteIdExpected);
            // var actual = sut.Post("/Results/suites/", testSuite);
        }
    }
}
