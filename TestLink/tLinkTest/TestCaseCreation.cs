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
    /// Unit Test for creation of test cases 
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
        TestSuite = "TestCaseCreation Tests",
     PlatformName = "Testlink v1.9.3",
        DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class TestCaseCreation : Testbase
    {

        int platformId;

        [SetUp]
        public void setup()
        {
            base.Setup();
            Assert.IsNotNull(AllProjects);
            platformId = Platforms[0].id;           
        }
        [Test]
        [MultipleAsserts]
        public void createAUniqueTestCase()
        {
            string uniqueName = string.Format("unitTest created at {0}", DateTime.Now);

            TestStep[] steps = new TestStep[3];
            steps[0] = new TestStep(1, "<p>Step 1</p>", "<p>result 1</p>", true, 1);
            steps[1] = new TestStep(2, "<p>Step 2</p>", "<p>result 2</p>", true, 1);
            steps[2] = new TestStep(3, "<p>Step 3</p>", "<p>result 3</p>", true, 1);

            GeneralResult result = proxy.CreateTestCase(userName, 
                BusinessRulesTestSuiteId, uniqueName, ApiTestProjectId,
                "This is a summary", 
                steps,
                 "auto,positive", 0, true, 
                 ActionOnDuplicatedName.CreateNewVersion, 2, 2);
            Assert.AreEqual(true, result.status);
            Assert.AreEqual("Success!", result.message);
		    Assert.AreEqual("createTestCase", result.operation);	
		    Assert.AreEqual("", result.additionalInfo.new_name);	
		    Assert.AreEqual(true, result.additionalInfo.status_ok);	
		    Assert.AreEqual("ok", result.additionalInfo.msg);	
            Assert.AreEqual(1, result.additionalInfo.version_number);	
            Assert.AreEqual(false, result.additionalInfo.has_duplicate);	
        }
        [Test]
        [Category("Changes Database")]
        [MultipleAsserts]
        public void createANewVersion()
        {
            string tcName ="externally created test case";
            GeneralResult result = proxy.CreateTestCase(userName, BusinessRulesTestSuiteId,
                tcName, ApiTestProjectId,"A summary",
                 "auto,positive", 0, true, 
                 ActionOnDuplicatedName.CreateNewVersion,
                 2, 2);
            Assert.AreEqual(true, result.status);
            Assert.AreEqual("Success!", result.message);
            Assert.AreEqual("createTestCase", result.operation);
//            Assert.AreEqual(tcName, result.additionalInfo.new_name);
            Assert.AreEqual(true, result.additionalInfo.status_ok);
            Assert.StartsWith(result.additionalInfo.msg, "Created new version");
            Assert.AreNotEqual(-1, result.additionalInfo.version_number); // that's a bug in testlink which has now a fix
            Assert.AreEqual(true, result.additionalInfo.has_duplicate);
        }

        [Test]
        [Category("Changes Database")]
        public void VersionIncrementTest()
        {
            string tcName = "version Number test case";
            GeneralResult result = proxy.CreateTestCase(userName, BusinessRulesTestSuiteId,
                tcName, ApiTestProjectId,
                 "This is a summary for an externally created test case",                
                 "auto,positive", 0, true,
                 ActionOnDuplicatedName.CreateNewVersion
                 , 2, 2);


            int versionNumber = result.additionalInfo.version_number;
            Console.WriteLine("Version Number first pass: {0}", result.additionalInfo.version_number);

            TestStep[] steps = new TestStep[3];
            steps[0] = new TestStep(1, "<p>Step 1</p>", "<p>result 1</p>", true, 1);
            steps[1] = new TestStep(2, "<p>Step 2</p>", "<p>result 2</p>", true, 2);
            steps[2] = new TestStep(3, "<p>Step 3</p>", "<p>result 3</p>", true, 1);

            result = proxy.CreateTestCase(userName, BusinessRulesTestSuiteId,
                tcName, ApiTestProjectId,
                 "This is a different summary for an externally created test case", steps,
              "auto,positive", 0, true,
              ActionOnDuplicatedName.CreateNewVersion, 
              2, 2);
            Console.WriteLine("Version Number second pass: {0}", result.additionalInfo.version_number);
            Assert.AreEqual(versionNumber + 1, result.additionalInfo.version_number, "Version number should have been incremented");
        }

        [Test]
        [Category("Changes Database")]
        public void TestBlock()
        {
            GeneralResult result = proxy.CreateTestCase(userName, BusinessRulesTestSuiteId,
                "externally created test case", ApiTestProjectId,
                 "This is a summary for an externally created test case",
                 "auto,positive", 0, true, ActionOnDuplicatedName.Block
                   
                 , 2, 2);
            Assert.AreEqual(true, result.status);
            Assert.AreEqual("Success!", result.message);
            Assert.AreEqual("createTestCase", result.operation);
            Assert.AreEqual("", result.additionalInfo.new_name);
            Assert.AreEqual(false, result.additionalInfo.status_ok);
            Assert.StartsWith(result.additionalInfo.msg, "There's already a Test Case with this title");
            Assert.AreEqual(-1, result.additionalInfo.id);
            //Assert.AreEqual(1, result.additionalInfo.version_number);  // should ignore this
            Assert.AreEqual(true, result.additionalInfo.has_duplicate);
        }

        [Test]
        [Category("Changes Database")]
        [MultipleAsserts]
        public void createDuplicateNotNewVersion()
        {
            string tcName = "externally created test case";
            GeneralResult result = proxy.CreateTestCase(userName, BusinessRulesTestSuiteId,
                tcName, ApiTestProjectId,
                 "This is a summary for an externally created test case",
                 "auto,positive", 0, true, ActionOnDuplicatedName.GenerateNew, 2, 2);
            Assert.AreEqual(true, result.status);
            Assert.AreEqual("Success!", result.message);
            Assert.AreEqual("createTestCase", result.operation);
            //Assert.AreEqual(tcName, result.additionalInfo.new_name); - no longer true the new name has a date prefixed
            Assert.AreEqual(true, result.additionalInfo.status_ok);
            Assert.StartsWith(result.additionalInfo.msg, "Created with title");
            Assert.AreNotEqual(-1, result.additionalInfo.id);
            Assert.AreEqual(1, result.additionalInfo.version_number);  
            Assert.AreEqual(true, result.additionalInfo.has_duplicate);
        }

        // we are not testing individual data failures as we are not testing testLink but the 
        // .net interface and its error handling
        [Test]
        [Category("Changes Database")]
        [ExpectedException(typeof(TestLinkException))]
        public void ShouldRejectBecauseOfInvalidData()
        {
            string tcName = "externally created test case";
            GeneralResult result = proxy.CreateTestCase(userName, BusinessRulesTestSuiteId,
                tcName, 0,
                 "This is a summary for an externally created test case",
                 "auto,positive", 0, true,  ActionOnDuplicatedName.GenerateNew,  2, 2);
         }

        [Test]
        [Category("Changes Database")]
        public void AddTestCaseToTestPlan()
        {
            string tcName = "externally created test case";
            GeneralResult newTestResult = proxy.CreateTestCase(userName, BusinessRulesTestSuiteId,
                tcName, ApiTestProjectId,
                 "This is a summary for an externally created test case",
                 "auto,positive", 0, true,  ActionOnDuplicatedName.GenerateNew,  2, 2);

            string prefix = ApiTestProject.prefix;
            string extid = string.Format("{0}-{1}", prefix, newTestResult.additionalInfo.external_id);
            TestPlan plan = getTestPlan(theTestPlanName);

            int result = proxy.addTestCaseToTestPlan(ApiTestProject.id, plan.id, extid, 1, platformId);
            Assert.AreNotEqual(0, result);
           
        }
        [Test][Ignore]
        [Category("Changes Database")]
        [Annotation(Gallio.Model.AnnotationType.Info, "this was done to deal with a bug in the implementation")]
        [MultipleAsserts]
        public void testExternalId()
        {
            string tcName = "externally created test case";
            GeneralResult result = proxy.CreateTestCase(userName, BusinessRulesTestSuiteId,
                tcName, ApiTestProjectId,
                 "This is a summary for an externally created test case",
                 "auto,positive", 0, true,  ActionOnDuplicatedName.GenerateNew, 
                 2, 2);

            string extId = string.Format("TAPI-{0}", result.additionalInfo.external_id);

            proxy.addTestCaseToTestPlan(ApiTestProjectId, PlanCalledAutomatedTesting.id, extId, 1);
            List<Meyn.TestLink.TestCaseFromTestPlan> tcList = proxy.GetTestCasesForTestPlan(PlanCalledAutomatedTesting.id);
            foreach (Meyn.TestLink.TestCaseFromTestPlan tc in tcList)
            {
                Console.WriteLine("tc:{0}, feature_id:{1}, external_id:{2}, tcversion:{3}, tcversion_number:{4}", 
                    tc.tc_id, tc.feature_id, tc.external_id, tc.version, tc.tcversion_id, tc.tcversion_number);
                if (tc.tc_id == result.id)
                    Assert.AreEqual(tc.external_id, extId);
            }
        }
     }
}
