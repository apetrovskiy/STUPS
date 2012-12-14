/* 
TestLink API library
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
//using log4net;

namespace Meyn.TestLink
{
    /// <summary>
    /// encapsulates the basic comms to the TestLink API 
    /// for the purpose of recording test results based upon the TestLinkFixtureAttribute 
    /// information.
    /// </summary>
    /// <remarks>This class is used by test exporters for automated testing frameworks such as Gallio or NUnit</remarks>
    public class TestLinkAdaptor
    {

        //private static readonly ILog log = LogManager.GetLogger(typeof(TestLinkAdaptor));

        private TestLinkFixtureAttribute connectionData;

        //private bool connectionValid = false;
        /// <summary>
        /// can we talk to testlink
        /// </summary>
        private bool basicConnectionValid = false;
        /// <summary>
        /// do we have project plan, project id and test suite correct?
        /// </summary>
        private bool projectDataValid = false;

        /// <summary>
        /// can we record test results
        /// </summary>
        public bool ConnectionValid
        {
            get { return (basicConnectionValid && projectDataValid); }
        }
       
        private TestLinkException lastException = null;

        public TestLinkException LastException
        {
            get { return lastException; }
        }
        /// <summary>
        /// the proxy to the current server
        /// </summary>
        Meyn.TestLink.TestLink proxy = null;
        List<TestProject> allProjects = new List<TestProject>();
        List<TestPlan> AllTestPlans = new List<TestPlan>();
        private TestProject currentProject;

        private int testSuiteId;
        private int testPlanId;
        private int testProjectId;
        private string platformName = string.Empty;

        /// <summary>
        /// sets up connection and retrieves basic data
        /// </summary>
        public TestLinkFixtureAttribute ConnectionData
        {
            get { return connectionData; }
            set { updateConnectionData(value);}
        }


        #region recording the result
        /// <summary>
        /// record a result with testlink;
        /// </summary>
        /// <param name="testCaseId"></param>
        /// <param name="status"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public GeneralResult RecordTheResult(int testCaseId, TestCaseResultStatus status, string notes)
        {
            GeneralResult result = null;
            if (ConnectionValid == true)
                result = proxy.ReportTCResult(testCaseId, testPlanId, status, platformName: platformName, notes: notes.ToString());
            else
                result = new GeneralResult("Invalid Connection", false);
            return result;
        }

        /// <summary>
        /// get a test case id. If the test case does not exist then create one
        /// </summary>
        /// <param name="testName"></param>       
        /// <returns>a valid test case id or 0 in case of failure</returns>
        public int GetTestCaseId(string testName) 
        {
            int TCaseId = getTestCaseByName(testName, testSuiteId);
            if (TCaseId == 0)
            {
                // need to create test case
                GeneralResult result = proxy.CreateTestCase(connectionData.UserId, testSuiteId, testName, testProjectId,
                    "Automated TestCase", new TestStep[0], "", 0,
                    true, ActionOnDuplicatedName.Block, 2, 2);
                TCaseId = result.additionalInfo.id;
                int tcExternalId = result.additionalInfo.external_id;
                if (result.status == false)
                {
                    Console.Error.WriteLine("Failed to create TestCase for {0}", testName);
                    Console.Error.WriteLine(" Reason {0}", result.message);
                    return 0;
                }
                string externalId = string.Format("{0}-{1}", currentProject.prefix, tcExternalId);
                int featureId = proxy.addTestCaseToTestPlan(currentProject.id, testPlanId, externalId, result.additionalInfo.version_number);
                if (featureId == 0)
                {
                    Console.Error.WriteLine("Failed to assign TestCase {0} to testplan", testName);
                    return 0;
                }
            }
            return TCaseId;
        }

        /// <summary>
        /// get the test case by this name in this particular test suite
        /// </summary>
        /// <param name="testCaseName"></param>
        /// <param name="testSuiteId">the test suite the test case has to be in</param>
        /// <returns>a valid test case id or 0 if no test case was found</returns>
        private int getTestCaseByName(string testCaseName, int testSuiteId)
        {
            List<TestCaseId> idList = proxy.GetTestCaseIDByName(testCaseName);
            if (idList.Count == 0)
                return 0;
            foreach (TestCaseId tc in idList)
                if (tc.parent_id == testSuiteId)
                    return tc.id;
            return 0;
        }
        #endregion

        #region updates after changes in the TestLinkFixture Data
        /// <summary>
        /// try to update the connection with a minimum of API calls to testlink
        /// </summary>
        /// <param name="newData"></param>
        private void updateConnectionData(TestLinkFixtureAttribute newData)
        {
            bool connectionDifferent = true;
            bool devKeyDifferent = true;
            bool projectDifferent = true;
            bool planDifferent = true;
            bool testSuiteDifferent = true;            

            if (newData == null)
            {
                //log.Error("No TestLinkFixture detected");
                basicConnectionValid = false;
                projectDataValid = false;
                connectionData = null;
                return;
            }


            if (connectionData != null)
            {
                if (newData.Url == connectionData.Url)
                {
                    connectionDifferent = false;
                    if (newData.DevKey == connectionData.DevKey)
                    {
                        devKeyDifferent = false;
                        if (connectionData.ProjectName == newData.ProjectName)
                        {
                            projectDifferent = false;
                            if (connectionData.TestPlan == newData.TestPlan)
                            {
                                planDifferent = false;
                                testSuiteDifferent = connectionData.TestSuite != newData.TestSuite;
                                
                            }
                        }
                    }
                }
            }
            connectionData = newData;
            platformName = connectionData.PlatformName;

            //attempt a new connection if url or devkey are different
            if (connectionDifferent || devKeyDifferent)
            {
                basicConnectionValid = basicConnection(newData.DevKey, newData.Url);
            }

            
            if (basicConnectionValid)
                projectDataValid = updateData(projectDifferent, planDifferent, testSuiteDifferent);
            
        }
        /// <summary>
        /// create the basic connection and test it out
        /// </summary>
        /// <param name="devKey"></param>
        /// <param name="url"></param>
        /// <returns>true if the connection is valid</returns>
        private bool basicConnection(string devKey, string url)
        {
            lastException = null;
            proxy = new TestLink(connectionData.DevKey, connectionData.Url);
            AllTestPlans = new List<TestPlan>();
            try
            {
                allProjects = proxy.GetProjects();
            }
            catch (TestLinkException tlex)
            {
                lastException = tlex;
                Console.WriteLine("Failed to connect to TestLink at {1}. Message was '{0}'", tlex.Message, url);
                return false;
            }
            return true;
        }

        /// <summary>
        /// update selected bits of the testlink fixture data
        /// </summary>
        /// <param name="newProject"></param>
        /// <param name="newTestPlan"></param>
        /// <param name="newTestSuite"></param>
        /// <returns>true if data have been set up successfully</returns>
        private bool updateData(bool newProject, bool newTestPlan, bool newTestSuite)
        {
            if (basicConnectionValid == false)
            {
                testProjectId = 0;
                testPlanId = 0;
                testSuiteId = 0;
                return false;
            }
            if (newProject)
            {
                testProjectId = 0;
                AllTestPlans = new List<TestPlan>();
                foreach (TestProject project in allProjects)
                    if (project.name == connectionData.ProjectName)
                    {
                        currentProject = project;
                        testProjectId = project.id;
                        AllTestPlans = proxy.GetProjectTestPlans(project.id);
                        break;
                    }
                if (testProjectId == 0)
                {
                    testPlanId = 0;
                    testSuiteId = 0;
                    Console.WriteLine("Test Project '{0}' was not found in TestLink", connectionData.ProjectName);
                    return false;
                }
            }
            else if (testProjectId == 0) // it was wrong and hasn't changed
                return false;

            if (newTestPlan)
            {
                testPlanId = 0;
                foreach (TestPlan tp in AllTestPlans)
                    if (tp.name == connectionData.TestPlan)
                    {
                        testPlanId = tp.id;
                        break;
                    }
                if (testPlanId == 0)
                {
                    testSuiteId = 0;
                    Console.WriteLine("Test plan '{0}' was not found in project '{1}'", connectionData.TestPlan, connectionData.ProjectName);
                    return false;
                }
            }
            else if (testPlanId == 0) // it was wrong and hasn't changed
                return false;

            if (newTestSuite)
            {
                testSuiteId = GetTestSuiteId(testProjectId, connectionData.TestSuite);
                if (testSuiteId == 0)
                {
                    Console.WriteLine("Test suite '{0}' was not found in project '{1}'", connectionData.TestSuite, connectionData.ProjectName);
                    return false;
                }
            }
            else if (testSuiteId == 0) // it was wrong and hasn't changed
                return false;

           
            return true;
        }

           
        
        /// <summary>
        /// retrieve the testsuite id 
        /// </summary>
        /// <returns>0 or a valid test suite Id</returns>
        private int GetTestSuiteId(int projectId, string testSuiteName)
        {
            int testSuiteId = 0;
            List<Meyn.TestLink.TestSuite> testSuites = proxy.GetFirstLevelTestSuitesForTestProject(projectId); //GetTestSuitesForTestPlan(testPlanId);
            // testsuite must exist. Currently no way of creating them
            foreach (Meyn.TestLink.TestSuite ts in testSuites)
                if (ts.name == testSuiteName)
                {
                    testSuiteId = ts.id;
                    break;
                }
            return testSuiteId;
        }
        #endregion
    }
}
