/* 
TestLink API Unit Tests
Copyright (c) 2009, Stephan Meyn <stephanmeyn@gmail.com>

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, 
publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
*/

using System.Collections.Generic;
using MbUnit.Framework;
using Meyn.TestLink;
using System;
using Meyn.TestLink.GallioExporter;

namespace tlinkTest
{
    /// <summary>
    /// tests the API for functions on getting execution results.
    /// </summary>
    /// <remarks>
    /// See class TestBase for basic configuration.
    /// 
    /// This unit test has been marked up with a testlinkfixture attribute. 
    /// This fixture uses the Gallio Testlink Adapter to export results of this test 
    ///  fixture to Testlink. If you do not use the adapter, you can ignore this attribute.
    ///  if you DO use the adapter then you need to make sure that the parameters below are setup corectly
    ///  
    /// Please remember that this tests the API, not testlink.
    /// </remarks>
    [TestFixture]
    [TestLinkFixture(
       Url = "http://localhost/testlink/lib/api/xmlrpc.php",
       ProjectName = "TestLinkApi",
       UserId = "admin",
       TestPlan = "Automatic Testing",
       TestSuite = "testGetLastExecutionResult",
     PlatformName = "Testlink v1.9.3",
       DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class testGetLastExecutionResult : Testbase
    {
        int testPlanId = 11;  // this needs to be the test plan that is currently active and has the two test cases assigned to it

        [SetUp]
        public void setup()
        {
            base.Setup();
        }

        [Test]
        public void TestShouldHaveNoResults()
        {
            List<TestCaseId> testcases = proxy.GetTestCaseIDByName("TestCase with no results", "business rules");
            Assert.IsNotEmpty(testcases, "Setup failed - couldn't find test case");
               
            int id = testcases[0].id;

            ExecutionResult result = proxy.GetLastExecutionResult(testPlanId, id);
            //Console.WriteLine("Build {0}: status: '{1}'", result.build_id, result.status);
            Assert.IsNull(result, "Result should be null");    
        }
        [Test]
        [MultipleAsserts]
        public void TestShouldHavePassedResult()
        {
            List<TestCaseId> testcases = proxy.GetTestCaseIDByName("passed test case", "business rules");
            Assert.IsNotEmpty(testcases, "Setup failed - couldn't find test case");
            int id = testcases[0].id;

            ExecutionResult result = proxy.GetLastExecutionResult(testPlanId, id);
            Assert.IsNotNull(result);
            Console.WriteLine("Build {0}: status: '{1}' tc_id:{2} tplan id {3}", result.build_id, result.status, result.tcversion_id, result.testplan_id);
            Assert.AreEqual(TestCaseResultStatus.Pass , result.status);           
        }
        [Test]
        [MultipleAsserts]
        public void TestShouldHavePassedResult2()
        {
            List<TestCaseId> testcases = proxy.GetTestCaseIDByName("Test Case with many results", "child test suite with test cases");
            Assert.IsNotEmpty(testcases, "Setup failed - couldn't find test case");
            int id = testcases[0].id;

            ExecutionResult result = proxy.GetLastExecutionResult(testPlanId, id);
            Assert.IsNotNull(result);
            Console.WriteLine("Build {0}: status: '{1}'", result.build_id, result.status);
            Assert.AreEqual(TestCaseResultStatus.Pass, result.status);
        }
    }
}
