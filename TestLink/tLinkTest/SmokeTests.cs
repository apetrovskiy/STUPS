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



using System;
using System.Collections.Generic;
using MbUnit.Framework;
using Meyn.TestLink;
using Meyn.TestLink.GallioExporter;

namespace tlinkTest
{
    /// <summary>
    /// smoke tests for the test link api
    /// </summary>
    /// <remarks>
    /// See class testbase for basic configuration.
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
        TestSuite = "SmokeTests",
        PlatformName = "Testlink v1.9.3",
        DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class SmokeTests : Testbase
    {

        [SetUp]
        public void setup()
        {
            base.Setup();           
        }

        [Test]
        public void SayHello()
        {
            
            string result = proxy.SayHello();
            Assert.AreEqual("Hello!", result, "Unexpected Server Response");
        }

        [Test]
        [MultipleAsserts]
        public void TestThatTestDBisProperlySetup()
        {
            Assert.IsNotNull(ApiTestProject, "Can't run tests. Project named {0} is not set up.", testProjectName);
            int empty = EmptyProjectId;
            Assert.AreNotEqual(0, empty, "Can't run tests. Empty Project named '{0}' is not set up.", emptyProjectName);
            Assert.AreNotEqual(0, BusinessRulesTestSuiteId, "Setup failed to find test suite named '{0}'", testSuiteName2);
            Assert.IsNotNull(PlanCalledAutomatedTesting, "Can't run tests. need to have at least one testplan named {1} defined for project '{0}' .", testProjectName, theTestPlanName);
            List<TestPlatform> platforms = Platforms;
            Assert.IsNotEmpty(platforms, "Can't run tests. need to have at least one platform defined for project '{0}' .", testProjectName);
        }

        [Test]
        public void ShouldGetListofProjects()
        {
            List<TestProject> result = proxy.GetProjects();
            Assert.IsNotNull(result, "should at least be an empty list");
            foreach (TestProject tp in result)
                Console.WriteLine("{0}: {1}",tp.id, tp.name);
        }

        [Test]
        [ExpectedException(typeof(CookComputing.XmlRpc.XmlRpcServerException))]
        public void shouldFailBecauseOfInvalidURL()
        {
            proxy = new TestLink(apiKey, "http://localhost/testlink/api/xmlrpc.php");
            string result = proxy.SayHello();
            Assert.AreNotEqual("Hello!", result, "Unexpected Server Response");
            Assert.Fail("Did not cause an exception");
        }

        [Test]
        [ExpectedException(typeof(Meyn.TestLink.TestLinkException))]
        public void shouldFailBecauseOfInvalidDevKey()
        {
            proxy = new TestLink("", targetDBUrl);
            List<TestCaseId> tcidList = proxy.GetTestCaseIDByName("10 G shock");
            string result = proxy.SayHello();
            Assert.AreNotEqual("Hello!", result, "Unexpected Server Response");
            Assert.Fail("Did not cause an exception");
        }

        [Test]
        [ExpectedException(typeof(Meyn.TestLink.TestLinkException))]
        public void shouldFailBecauseOfNullDevKey()
        {
            proxy = new TestLink(null, targetDBUrl);
            List<TestCaseId> tcidList = proxy.GetTestCaseIDByName("10 G shock");
            string result = proxy.SayHello();
            Assert.AreNotEqual("Hello!", result, "Unexpected Server Response");
            Assert.Fail("Did not cause an exception");
        }

        [Test]
        [Row(5,  "10 G shock", "Handheld devices")]
        [Row(7, "Gamma Ray Storm", "Handheld devices")]
        public void GetTestCase(int id, string name, string testSuiteId)
        {
           List<TestCaseId> tcidList = proxy.GetTestCaseIDByName(name);
           Assert.AreEqual(1, tcidList.Count, "Call should return only 1 element");
            TestCaseId tcid = tcidList[0];
           Assert.AreEqual(id, tcid.id);
           Assert.AreEqual(name, tcid.name);
           Assert.AreEqual(testSuiteId, tcid.tsuite_name);
        }
        [Test]
        [Row("joe", true)]
        [Row("admin", true)]
        [Row("Nonexistentuser", false)]
        public void testUserExists(string userName, bool shouldExist)
        {
            bool result = proxy.DoesUserExist(userName);
            Assert.AreEqual<bool>(shouldExist, result, "tried user {0} and got result {1}", userName, shouldExist);
        }

    }
}
