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
    /// test test case related functions.
    /// Excludes test case creation which has its own test fixture
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
        TestSuite = "TestCase Tests",
     PlatformName = "Testlink v1.9.3",
        DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class TestCaseTests  :Testbase
    {

        int tcId = 16;
        int buildId = 4;
        int kwId = 1;
        
        int assignedTo = 1;
       

        [SetUp]
        public void setup()
        {
            base.Setup();
            Assert.IsNotNull(AllProjects);           
        }
        [Test]
        public void GetNonExistentTc()
        {
           List<TestCaseId> idList = proxy.GetTestCaseIDByName("Does Not Exist");
           Assert.IsEmpty(idList);
        }

        [Test]
        public void DealWithDuplicateTestCaseNames()
        {
            List<TestCaseId> idList = proxy.GetTestCaseIDByName("duplicate test case");
            Assert.AreEqual(2, idList.Count, "there should be two test cases");
            Console.WriteLine("Business Rules Test Suite Id = {0}", base.BusinessRulesTestSuiteId);
           
            foreach (TestCaseId id in idList)
            {
                  Console.WriteLine("TC-id {0}, parent Id = {1}", id.tc_external_id, id.parent_id);
            }
        }
        [Test]
        public void GetTestCasesForTestPlan()
        {

            List<TestCaseFromTestPlan> idList = proxy.GetTestCasesForTestPlan(PlanCalledAutomatedTesting.id);


            foreach (TestCaseFromTestPlan tc in idList)
            {
                Console.Write ("TC-id {0} :'{1}. testsuiteId='{2}' ", tc.tc_id, tc.name, tc.testsuite_id);
                Console.WriteLine("Platform: {0}, Status:{1}", tc.platform_name, tc.status);
            }
            Assert.IsTrue(idList.Count>0, "there should be multiple test cases");
           
        }
        [Test]
        public void GetTestCasesForTestPlan_tc()
        {

            List<TestCaseFromTestPlan> idList = proxy.GetTestCasesForTestPlan(PlanCalledAutomatedTesting.id,16);


            foreach (TestCaseFromTestPlan tc in idList)
            {
                Console.Write("TC-id {0} :'{1}' ", tc.tc_id, tc.name);
                Console.WriteLine("Platform: {0}, Status:{1}", tc.platform_name, tc.status);
            }
            Assert.IsTrue(idList.Count > 0, "there should be multiple test cases");

        }
        [Test]
        public void GetTestCasesForTestPlan_tc_build()
        {

            List<TestCaseFromTestPlan> idList = proxy.GetTestCasesForTestPlan(PlanCalledAutomatedTesting.id, tcId, buildId);

            foreach (TestCaseFromTestPlan tc in idList)
            {
                Console.Write("TC-id {0} :'{1}' ", tc.tc_id, tc.name);
                Console.WriteLine("Platform: {0}, Status:{1}", tc.platform_name, tc.status);
            }
            Assert.IsTrue(idList.Count > 0, "there should be multiple test cases");
        }

        [Test]
        public void GetTestCasesForTestPlan_tc_build_kw_nonexistent()
        {
            List<TestCaseFromTestPlan> idList = proxy.GetTestCasesForTestPlan(PlanCalledAutomatedTesting.id, tcId, buildId,  kwId);

            foreach (TestCaseFromTestPlan tc in idList)
            {
                Console.WriteLine("TC-id {0} :'{1}'", tc.tc_id, tc.name);
                Console.WriteLine("Platform: {0}, Status:{1}", tc.platform_name, tc.status);
            }
            Assert.AreEqual(0, idList.Count, "There should be no test cases");
        }
        [Test]
        public void GetTestCasesForTestPlan_tc_build_executedTrue()
        {

            List<TestCaseFromTestPlan> idList = proxy.GetTestCasesForTestPlan(PlanCalledAutomatedTesting.id, tcId, buildId, kwId, true);

            foreach (TestCaseFromTestPlan tc in idList)
            {
                Console.WriteLine("TC-id {0} :'{1}'", tc.tc_id, tc.name);
                Console.WriteLine("Platform: {0}, Status:{1}", tc.platform_name, tc.status);
            }
            Assert.IsTrue(idList.Count == 0, "there should be no test cases");
        }
        [Test]
        public void GetTestCasesForTestPlan_tc_build_kw_executed_assignedToWrongId()
        {
            List<TestCaseFromTestPlan> idList = proxy.GetTestCasesForTestPlan(PlanCalledAutomatedTesting.id, tcId, buildId, kwId, true, assignedTo);

            foreach (TestCaseFromTestPlan tc in idList)
            {
                Console.WriteLine("TC-id {0} :'{1}'", tc.tc_id, tc.name);
                Console.WriteLine("Platform: {0}, Status:{1}", tc.platform_name, tc.status);
            }
            Assert.IsTrue(idList.Count == 0, "there should be no test cases"); 
        }
        [Test]
        public void GetTestCasesForTestPlan_tc_build_kw_executed_assignedTo_status_notexecuted()
        {
            List<TestCaseFromTestPlan> idList = proxy.GetTestCasesForTestPlan(PlanCalledAutomatedTesting.id, tcId, buildId, 
                kwId, true, assignedTo, "p");

            foreach (TestCaseFromTestPlan tc in idList)
            {
                Console.WriteLine("TC-id {0} :'{1}' Version {2}", tc.tc_id, tc.name, tc.version);
                Console.WriteLine("Platform: {0}, Status:{1}", tc.platform_name, tc.status);
            }
            Assert.IsTrue(idList.Count == 0, "there should be no test cases");
        }

        [Test]
        public void getTestCaseIdsForTestSuite_Shallow()
        {
            TestPlan plan = getTestPlan(theTestPlanName);

            List<Meyn.TestLink.TestSuite> list = proxy.GetTestSuitesForTestPlan(plan.id);

            List<int> items = proxy.GetTestCaseIdsForTestSuite(list[0].id, false);
            Assert.IsNotEmpty(items);
        }
        [Test]
        public void getTestCaseIdsForTestSuite_Deep()
        {
            TestPlan plan = getTestPlan(theTestPlanName);

            List<Meyn.TestLink.TestSuite> list = proxy.GetTestSuitesForTestPlan(plan.id);

            List<int> items = proxy.GetTestCaseIdsForTestSuite(list[0].id, true);
            Assert.IsNotEmpty(items);
        }
        [Test]
        public void getTestCasesForTestSuite_Shallow()
        {
            TestPlan plan = getTestPlan(theTestPlanName);

            List<Meyn.TestLink.TestSuite> list = proxy.GetTestSuitesForTestPlan(plan.id);

            List<Meyn.TestLink.TestCaseFromTestSuite> items = proxy.GetTestCasesForTestSuite(list[0].id, false);
            Assert.IsNotEmpty(items);
            foreach (Meyn.TestLink.TestCaseFromTestSuite item in items)
            {
                Console.WriteLine("id: {0}", item.id);
                Console.WriteLine("Name          : {0}", item.name);
                Console.WriteLine("Author Id     : {0}", item.author_id);
                Console.WriteLine("Created       : {0}", item.creation_ts);
                Console.WriteLine("Status        : {0}", item.status);
                Console.WriteLine("Test Case Version: {0}", item.tcversion_id);
                Console.WriteLine("Test Suite Id : {0}", item.testSuite_id);
                Console.WriteLine("Version       : {0}", item.version);
                Console.WriteLine("Summary       : {0}", item.summary);
                Console.WriteLine("Details       : {0}", item.details);
                Console.WriteLine("Preconditions : {0}", item.preconditions);
                Console.WriteLine("Update Id     : {0}", item.updater_id);
                Console.WriteLine("Modified on   : {0}", item.modification_ts);
                Console.WriteLine("Active        : {0}", item.active);
                Console.WriteLine("Is Open       : {0}", item.is_open);
                Console.WriteLine("Execution Type: {0}", item.execution_type);
                Console.WriteLine("External Id   : {0}", item.external_id);
                Console.WriteLine("Importance    : {0}", item.importance);
                Console.WriteLine("Layout        : {0}", item.layout);
                Console.WriteLine("Node Order    : {0}", item.node_order);
                Console.WriteLine("Node table    : {0}", item.node_table);
                Console.WriteLine("Node type id  : {0}", item.node_type_id);
                Console.WriteLine("====================================");
                
            }
        }
        [Test]
        public void getTestCasesForTestSuite_Deep()
        {
            TestPlan plan = getTestPlan(theTestPlanName);

            List<Meyn.TestLink.TestSuite> list = proxy.GetTestSuitesForTestPlan(plan.id);
            Assert.IsNotEmpty(list);
            List<Meyn.TestLink.TestCaseFromTestSuite> items = proxy.GetTestCasesForTestSuite(list[0].id, true);
            Assert.IsNotEmpty(items);
        }

        [Test]
        public void getTestCaseById()
        {
            int tcid = TestCaseIdWithVersions;
            Meyn.TestLink.TestCase tc = proxy.GetTestCase(tcid);
            Assert.IsNotNull(tc, "should have a test case");
            Console.WriteLine("Found {0}:{1} Version:{2}", tc.id, tc.name, tc.version);
        }

        [Test]
        [ExpectedException(typeof(TestLinkException))]
        public void getTestCaseById_nonexistingId()
        {
            int tcid = -12;
            proxy.GetTestCase(tcid);           
        }
        [Test]        
        public void TestCaseAttachmentCreation()
        {
            int tcid = TestCaseToUseWithAttachments;
            Meyn.TestLink.TestCase tc = proxy.GetTestCase(tcid);            

            byte[] content = new byte[4];
            content[0] = 48;
            content[1] = 49;
            content[2] = 50;
            content[3] = 51;

            AttachmentRequestResponse r = proxy.UploadTestCaseAttachment(tcid, "fileX.txt", "text/plain", content, "some result", "a description");
            Assert.AreEqual(r.foreignKeyId, tcid);
            Console.WriteLine("Upload Response id:{0}, table '{1}', title:'{2}' size:{3}", r.foreignKeyId, r.linkedTableName, r.title, r.size); 
           
             
        }

        /// <summary>
        /// prerequisite: a test case called 'TestCase with Attachments' that has two attachments
        /// </summary>
        [Test]
        public void getTestcaseAttachments()
        {
            List<TestCaseId> list = proxy.GetTestCaseIDByName("TestCase with Attachments");

            List<Attachment> result = proxy.GetTestCaseAttachments(list[0].id);
            foreach (Attachment a in result)
                Console.WriteLine("{0}:'{1}'. File Type:{2}. date added:{3}", a.id, a.name, a.file_type, a.date_added);
            Assert.AreEqual(2, result.Count, "Expected two attachments for test case called 'TestCase with Attachments'");
        }

        [Test]
        public void getTestcaseByName1()
        {
            List<TestCaseId> testcases = proxy.GetTestCaseIDByName("TestCase with no results", "business rules");
            Assert.IsNotEmpty(testcases, "there should be a test case named 'TestCase with no results' in the business rules test suite");
        }

        [Test]
        public void getTestcaseByName2()
        {
            List<TestCaseId> testcases = proxy.GetTestCaseIDByName("TestCase with no results", BusinessRulesTestSuiteId);
            Assert.IsNotEmpty(testcases, "there should be a test case named 'TestCase with no results' in the business rules test suite");
        }
        [Test]
        public void getTestcaseByName_noResult()
        {
            List<TestCaseId> testcases = proxy.GetTestCaseIDByName("xxxxxxxxxx", BusinessRulesTestSuiteId);
            Assert.IsEmpty(testcases, "there should be a no test case named 'xxxxxxxxxx' in the business rules test suite");
        }

        /// <summary>
        /// pre-requisite:
        /// a test case named 'Testcase with Steps'
        /// it must have 4 steps
        /// steps 1,2 and 4 are manual
        /// step 3 is automatic.
        /// </summary>
        [Test]
        [MultipleAsserts]
        public void getTestCaseWithSteps()
        {
            int tcId = TestCaseIdWithSteps;

            Meyn.TestLink.TestCase tc = proxy.GetTestCase(tcId);             
            Assert.IsNotNull(tc);
            Assert.AreEqual<int>(4, tc.steps.Count, " there should be 4 steps in tc named {0}. Check the Testlink DB", tc.name);
            for (int idx = 0; idx < 4; idx++)
            {
                TestStep ts = tc.steps[idx];
                Assert.AreEqual<int>(idx + 1, ts.step_number);
                if (idx == 2)
                    Assert.AreEqual<int>(2, ts.execution_type);
                else
                    Assert.AreEqual<int>(1, ts.execution_type);
                Assert.IsNotEmpty(ts.actions);
                Assert.IsNotEmpty(ts.expected_results);               
            }

        }
    }
}
