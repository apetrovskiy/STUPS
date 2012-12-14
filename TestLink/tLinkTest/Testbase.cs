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
using Meyn.TestLink;
using MbUnit.Framework;


namespace tlinkTest
{
    /// <summary>
    /// This is the base class containing common stuff for all test fixtures.
    /// prior to using the smoke tests you need to modify the settings below
    /// and setup the test project. 
    /// </summary>
    public class Testbase
    {

        protected const string targetDBUrl = "http://localhost/testlink/lib/api/xmlrpc.php";
        //protected const string targetDBUrl = "http://192.168.1.11/testlink/lib/api/xmlrpc.php";
        /// <summary>
        /// this apiKey needs to be set whenever a new user is created.
        /// </summary>
        protected const string apiKey = "fb37eb345a5b4f05659d5c35bb3465fd"; //on xampp
        //protected const string apiKey = "3e64f6589b1bcc4326bc81d6a5b07e8b"; //on NAS old
        protected const string userName = "admin";

        protected const string testProjectName = "apiSandbox";
        protected const string emptyProjectName = "Empty TestProject";  // this test project needs to be empty
        /// <summary>
        /// the test plan used for most automated testing. they are all to be setup under the project named apiSandbox
        /// This test plan should have 2 platform: OS/X and Windows 95
        /// </summary>
        protected const string theTestPlanName = "Automated Testing"; // need to have one plan of this name
        protected const string platformName1 = "OS/X";
        protected const string platformName2 = "Windows 95";
        /// <summary>
        /// this test plan should have neither test cases nor test platforms associated no builds
        /// </summary>
        protected const string emptyTestplanName = "Empty Test plan";




        protected const string testSuiteName2 = "Function Requirements";
        protected const string testSuiteName1 = "business rules";
        protected const string emptyTestSuiteName = "Empty Test Suite";
        protected const string subTestSuiteName1 = "child test suite with test cases";
        protected const string subTestSuiteName2 = "empty Child Test Suite";
        protected const string testCasetoHaveResults = "Test Case with many results";
        protected const string testCaseWithVersions = "TestCaseWithVersions";
        protected const string buildUsedForTestingName = "Build to be used for testing";
        protected const string testsuitetohaveattachmentsaddedName = "Testsuite to have attachments added";
        protected const string TestCaseToUseWithAttachmentsName = "TestCase to use to test attachments";
        protected const string TestCaseWithAttachmentsName = "TestCase with Attachments";
        protected const string TestCaseWithStepsName = "Testcase with Steps";
        private int apiTestProjectId;
        private int emptyProjectId=0;
        private int businessRulesTestSuiteId;
        private int testSuiteWithSubtestSuitesId;
        private List<TestProject> allProjects = null;
        private TestPlan planCalledAutomatedTesting = null;

        protected TestLink proxy;

        /// <summary>
        /// the id of the project that is used for automated testing of the API
        /// </summary>
        protected int ApiTestProjectId
        {
            get {
                if (apiTestProjectId == 0)
                    loadProjectIds();
                return apiTestProjectId; }
        }
        /// <summary>
        /// get the APITest project
        /// </summary>
        protected TestProject ApiTestProject
        {
            get
            {
                if (allProjects == null)
                    loadProjectIds();
                foreach (TestProject tp in allProjects)
                    if (tp.name == testProjectName)
                        return tp;
                return null ; // not found
            }
        }
        /// <summary>
        /// the id of a project that is empty
        /// </summary>
        protected int EmptyProjectId
        {
            get
            {
             if (emptyProjectId == 0)
                    loadProjectIds(); 
                return emptyProjectId;
            }
        }
        /// <summary>
        /// get all platforms for the standard test plan
        /// </summary>
        protected List<TestPlatform> Platforms
        {
            get
            {
                return proxy.GetTestPlanPlatforms(PlanCalledAutomatedTesting.id);
            }
        }
        /// <summary>
        /// the id of the test suite where we can create test cases and record test results
        /// </summary>
        protected int BusinessRulesTestSuiteId
        {
            get
            {
                if (businessRulesTestSuiteId == 0)
                {
                    List<Meyn.TestLink.TestSuite> allSuites = proxy.GetFirstLevelTestSuitesForTestProject(ApiTestProjectId);
                    foreach (Meyn.TestLink.TestSuite ts in allSuites)
                        if (ts.name == testSuiteName1) 
                            businessRulesTestSuiteId = ts.id;
                }
                // Assert.AreNotEqual(0, businessRulesTestSuiteId, "Setup failed to find test suite named '{0}'", testSuiteName2);
                return businessRulesTestSuiteId;
            }
        }

        protected int TestSuiteWithSubTestSuites
        {
            get {
                     if (testSuiteWithSubtestSuitesId == 0)
                {
                    List<Meyn.TestLink.TestSuite> allSuites = proxy.GetFirstLevelTestSuitesForTestProject(ApiTestProjectId);
                    foreach (Meyn.TestLink.TestSuite ts in allSuites)
                        if (ts.name == testSuiteName2)
                            testSuiteWithSubtestSuitesId = ts.id;
                }
                // Assert.AreNotEqual(0, businessRulesTestSuiteId, "Setup failed to find test suite named '{0}'", testSuiteName2);
                return testSuiteWithSubtestSuitesId;
            }
        }


        protected Meyn.TestLink.TestSuite Testsuitetohaveattachmentsadded
        {
            get
            {
                List<Meyn.TestLink.TestSuite> allSuites = proxy.GetFirstLevelTestSuitesForTestProject(ApiTestProjectId);
                foreach (Meyn.TestLink.TestSuite ts in allSuites)
                    if (ts.name == testsuitetohaveattachmentsaddedName)
                        return ts;
                Assert.Fail("Setup failed, could not get test suite named '{0}'. must be top level test suite", testsuitetohaveattachmentsaddedName);
                return null;
            }
        }
        /// <summary>
        /// a test case where new results can be added and then deleted
        /// </summary>
        protected int TestCaseToHaveResultsDeleted
        {
            get
            {
                List<TestCaseId> testcases = proxy.GetTestCaseIDByName("TestCaseToHaveResultsDeleted", testSuiteName1);
                Assert.IsNotEmpty(testcases, "could not find test cases called 'TestCaseToHaveResultsDeleted'. Can't proceed with test");
                return testcases[0].id;
            }
        }


        protected int TestCaseToUseWithAttachments
        {
            get
            {
                List<TestCaseId> testcases = proxy.GetTestCaseIDByName(TestCaseToUseWithAttachmentsName);
                Assert.IsNotEmpty(testcases, "Setup:Could not find any test cases with this name: '{0}'", testCaseWithVersions);
                return testcases[0].id;
            }
        }

        protected int TestCaseIdWithAttachments
        {
            get
            {
                List<TestCaseId> testcases = proxy.GetTestCaseIDByName(TestCaseWithAttachmentsName);
                Assert.IsNotEmpty(testcases, "Setup:Could not find any test cases with this name: '{0}'", testCaseWithVersions);
                return testcases[0].id;
            }
        }

        protected int TestCaseIdWithVersions
        {
            get
            {
                List<TestCaseId> testcases = proxy.GetTestCaseIDByName(testCaseWithVersions);
                Assert.IsNotEmpty(testcases, "Setup:Could not find any test cases with this name: '{0}'", testCaseWithVersions);
                return testcases[0].id;
            }
        }
        /// <summary>
        /// get the test case that has a number of steps in it
        /// </summary>
        protected int TestCaseIdWithSteps
        {
            get
            {
                List<TestCaseId> tcIdList = proxy.GetTestCaseIDByName(TestCaseWithStepsName);
                Assert.IsNotEmpty(tcIdList, "Setup: could not find testcase named {0}", TestCaseWithStepsName);
                return tcIdList[0].id;
            }
        }

        protected TestPlan PlanCalledAutomatedTesting
        {
            get
            {
                if (planCalledAutomatedTesting == null)
                    planCalledAutomatedTesting = getTestPlan(theTestPlanName);
                return planCalledAutomatedTesting;
            }
        }

        /// <summary>
        /// get a list of all projects;
        /// </summary>
        protected List<TestProject> AllProjects
        {
            get {
                if (allProjects == null)
                    allProjects = proxy.GetProjects();
                return allProjects;
            }

        }
        /// <summary>
        /// in case we want to force a retrieve of all projects
        /// </summary>
        protected void clearAllProjects()
        {
            allProjects = null;
        }

        protected void Setup()
        {
            proxy = new TestLink(apiKey, targetDBUrl, true);
        }
        /// <summary>
        /// load a list of all projects
        /// </summary>
        protected void loadProjectIds()
        {
            apiTestProjectId = -1;
            emptyProjectId = -1;

            foreach (TestProject project in AllProjects)
            {
                switch (project.name)
                {
                    case testProjectName: apiTestProjectId = project.id; break;
                    case emptyProjectName: emptyProjectId = project.id; break;
                }
            }
            Assert.AreNotEqual(-1, apiTestProjectId, "Could not find project id for project {0}", testProjectName);
            Assert.AreNotEqual(-1, emptyProjectId, "Could not find project id for project {0}", emptyProjectName);
        }

        #region test plan
        TestPlan plan;
        /// <summary>
        /// find a testplan within the automated test project sandbox
        /// </summary>
        /// <param name="testPlanName"></param>
        /// <returns></returns>
        protected TestPlan getTestPlan(string testPlanName)
        {
            List<TestPlan> plans = proxy.GetProjectTestPlans(ApiTestProjectId);
            
            //Assert.IsNotEmpty(plans, "Setup failed, couldn't find testplans for project {0}", testProjectName);
            plan = null;
            foreach (TestPlan candidate in plans)
                if (candidate.name == testPlanName)
                {
                    plan = candidate;
                    break;
                }
            if (plan == null)
                Assert.Fail("Setup failed, could not find test plan named '{0}' in project '{1}'", testPlanName, testProjectName);
            return plan;
        }

        protected TestPlan AutomatedTestingTestplan
        {
            get
            {
                return getTestPlan(theTestPlanName);
            }
        }
        #endregion
    }
}
