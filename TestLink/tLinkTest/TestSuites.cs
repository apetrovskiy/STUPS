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
    /// test TestLinkAPI.TestSuite related calls
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
      TestSuite = "TestSuites",
     PlatformName = "Testlink v1.9.3",
      DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class TestSuites : Testbase
    {    
        [SetUp]
        public void setup()
        {
            base.Setup();

            Assert.IsNotEmpty(AllProjects, "Setup failed to get list of projects");
            loadProjectIds();
        }

       
        [Test]
        public void GetTestSuitesForTestPlan()
        {
            TestPlan plan = getTestPlan(theTestPlanName);

            List<Meyn.TestLink.TestSuite> list = proxy.GetTestSuitesForTestPlan(plan.id);
            Assert.IsNotEmpty(list);
            foreach (Meyn.TestLink.TestSuite ts in list)
                Console.WriteLine("{0}:{1}", ts.id, ts.name);

        }



        [Test]
        public void GetTestSuitesForTestProject()
        {
            List<Meyn.TestLink.TestSuite> list = proxy.GetFirstLevelTestSuitesForTestProject(ApiTestProjectId);
            Assert.IsNotEmpty(list);
            foreach (Meyn.TestLink.TestSuite ts in list)
                Console.WriteLine("{0}:{1}. parent =", ts.id, ts.name, ts.parentId);

        }
        [Test]
        public void GetTestSuitesForEmptyTestProject()
        {
            List<Meyn.TestLink.TestSuite> list = proxy.GetFirstLevelTestSuitesForTestProject(EmptyProjectId);
            Assert.IsEmpty(list, "empty project is not empty but has {0} test suites", list.Count);
        }

  

        [Test]
        public void CreateTestSuite()
        {
            string name = string.Format("AutocreatedTestSuite at {0}", DateTime.Now.ToUniversalTime());
            Assert.AreNotEqual(-1, ApiTestProjectId);
            Console.WriteLine("Creating TestSuite for TestProjectId = {0}", ApiTestProjectId);
            GeneralResult createResult = proxy.CreateTestSuite(ApiTestProjectId, name, "Here are some details");
            Console.WriteLine("Result status:{0}, id:{1}, message:'{2}'", createResult.status, createResult.id, createResult.message);
            Assert.AreEqual(true, createResult.status, "Create did not return true");


            Console.WriteLine("checking against all first level test suites");
            List<Meyn.TestLink.TestSuite> result = proxy.GetFirstLevelTestSuitesForTestProject(ApiTestProjectId);
            bool found = false;
            foreach (Meyn.TestLink.TestSuite suite in result)
            {
                if (suite.name == testSuiteName1)
                
                Console.Write("Looking at suite id:{0} '{1}'", suite.id, suite.name);
                if (suite.id == createResult.id)
                {
                    found = true;
                    Console.WriteLine(" --- Found!");
                    Assert.AreEqual(name, suite.name, "Suite name is wrong");
                    break;
                }
                //else Console.WriteLine(" --- no match");
            }
            Assert.IsTrue(found, "No Suite matched");
        }

        [Test]
        public void getChildTestSuites()
        {
            List<Meyn.TestLink.TestSuite> suites = proxy.GetFirstLevelTestSuitesForTestProject(ApiTestProject.id);
            Meyn.TestLink.TestSuite parent = null;
            foreach (Meyn.TestLink.TestSuite suite in suites)
            {
                if (suite.name == testSuiteName2)
                {
                    parent = suite;
                    break;
                }
            }
            Assert.IsNotNull(parent, "couldn't find named {0}. Can't proceed", testSuiteName2);
            List<Meyn.TestLink.TestSuite> children = proxy.GetTestSuitesForTestSuite(parent.id);
            Assert.IsNotEmpty(children, "expected at least two children");
            foreach (Meyn.TestLink.TestSuite testSuite in children)
                Console.WriteLine("{0}:{1}. nodeTypeid:{2}, nodeOrder:{3}, parentId:{4}"
                    , testSuite.id, testSuite.name, testSuite.nodeTypeId, testSuite.nodeOrder, testSuite.parentId);
        }

        [Test]
        public void getChildTestSuitesShouldGetNone()
        {
            List<Meyn.TestLink.TestSuite> suites = proxy.GetFirstLevelTestSuitesForTestProject(ApiTestProject.id);
            Meyn.TestLink.TestSuite parent = null;
            foreach (Meyn.TestLink.TestSuite suite in suites)
            {
                if (suite.name == emptyTestSuiteName)
                {
                    parent = suite;
                    break;
                }
            }
            Assert.IsNotNull(parent, "couldn't find named {0}. Can't proceed", testSuiteName1);
            List<Meyn.TestLink.TestSuite> children = proxy.GetTestSuitesForTestSuite(parent.id);
            Assert.IsEmpty(children, "expected no children");
        }
        [Test]
        public void CreateTestSuiteOneLevelDown()
        {
            List<Meyn.TestLink.TestSuite> suites = proxy.GetFirstLevelTestSuitesForTestProject(ApiTestProject.id);
            Meyn.TestLink.TestSuite parent = null;
            foreach (Meyn.TestLink.TestSuite suite in suites)
            {
                if (suite.name == testSuiteName1)
                {
                    parent = suite;
                    break;
                }
            }
            string name = string.Format("Autocreated SubtestSuite at {0}", DateTime.Now.ToUniversalTime());

            Assert.IsNotNull(parent, "couldn't find named {0}. Can't proceed",testSuiteName1);
            GeneralResult createResult = proxy.CreateTestSuite(ApiTestProjectId, name, "Here are some details", parentId: parent.id);
            Assert.AreEqual(true ,createResult.status, "create seems to have failed:{0}", createResult);
        }
        /// <summary>
        /// pre-requisite, a test suite with the name of 'business rules'
        /// </summary>
        [Test]
        public void GetTestSuiteById_validId()
        {
            Meyn.TestLink.TestSuite target = proxy.GetTestSuiteById(BusinessRulesTestSuiteId);
            Assert.IsNotNull(target, "should have gotten the Business Rules TestSuite. id:{0}", BusinessRulesTestSuiteId);
            Assert.AreEqual(testSuiteName1, target.name);
        }
        [Test]
        public void GetTestSuiteById_InvalidId()
        {
            Meyn.TestLink.TestSuite target = proxy.GetTestSuiteById(999999);
            Assert.IsNull(target, "No test suite should be returned, but found one'");
        }

        [Test]
        [Category("Changes Database")]
        public void TestSuiteAttachmentCreation()
        {
            int tsid = Testsuitetohaveattachmentsadded.id;           

            byte[] content = new byte[4];
            content[0] = 48;
            content[1] = 49;
            content[2] = 50;
            content[3] = 51;

            AttachmentRequestResponse r = proxy.UploadTestSuiteAttachment(tsid, "fileX.txt", "text/plain", content, "some result", "a description");
            Assert.AreEqual(r.foreignKeyId, tsid);
            Console.WriteLine("Upload Response id:{0}, table '{1}', title:'{2}' size:{3}", r.foreignKeyId, r.linkedTableName, r.title, r.size); 
           
        }
    }

}
