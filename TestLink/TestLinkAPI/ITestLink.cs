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

using CookComputing.XmlRpc;


namespace Meyn.TestLink
{
 
    /// <summary>
    /// the interface mapping required for the XmlRpc api of testlink. 
    /// This interface is used by the TestLink class. 
    /// </summary>
    /// <remarks>This class makes use of XML-RPC.NET Copyright (c) 2006 Charles Cook</remarks>
    [XmlRpcUrl("")]
    public interface ITestLink : IXmlRpcProxy
    {

        #region Requirements
        //[XmlRpcMethod("tl.assignRequirements")]
        //string assignRequirements();
        #endregion

        #region Builds
        [XmlRpcMethod("tl.createBuild", StructParams=true)]
        object[] createBuild(string devKey, int testplanid, string buildname, string buildnotes);

        [XmlRpcMethod("tl.getBuildsForTestPlan", StructParams = true)]
        object getBuildsForTestPlan(string devKey, int testplanid);
        
        #endregion

        #region TestProject
        [XmlRpcMethod("tl.getProjects", StructParams = true)]
        object getProjects(string devKey);
       
        [XmlRpcMethod("tl.getTestProjectByName", StructParams = true)]
        object getTestProjectByName(string devKey, string testprojectname);

        [XmlRpcMethod("tl.createTestProject", StructParams = true)]
        object createTestProject(string devKey, string testprojectname, string testcaseprefix, string notes = "");
        
        [XmlRpcMethod("tl.uploadTestProjectAttachment", StructParams = true)]
        object uploadTestProjectAttachment(string devKey, int testprojectid, string filename, string fileType, string content, string title, string description);

        #endregion

        #region TestCase
        [XmlRpcMethod("tl.createTestCase", StructParams = true)]
        object createTestCase(string devKey, string authorlogin, int testsuiteid, string testcasename, int testprojectid,
            string summary, TestStep[] steps,  string keywords,
            int order, int checkduplicatedname, string actiononduplicatedname, int executiontype, int importance);

        [XmlRpcMethod("tl.addTestCaseToTestPlan", StructParams = true)]
        object addTestCaseToTestPlan(string devKey, int testprojectid, int testplanid, string testcaseexternalid, int version);
        [XmlRpcMethod("tl.addTestCaseToTestPlan", StructParams = true)]
        object addTestCaseToTestPlan(string devKey, int testprojectid, int testplanid, string testcaseexternalid, int version, int platformid);
        [XmlRpcMethod("tl.addTestCaseToTestPlan", StructParams = true)]
        object addTestCaseToTestPlan(string devKey, int testprojectid, int testplanid, string testcaseexternalid, int version, int platformid, int executionorder, int urgency);


        [XmlRpcMethod("tl.getTestCaseAttachments", StructParams = true)]
        object getTestCaseAttachments(string devKey, int testcaseid);

        //[XmlRpcMethod("tl.getTestCaseCustomFieldDesignValue", StructParams = true)]
        //object getTestCaseCustomFieldDesignValue(string devKey);

        [XmlRpcMethod("tl.getTestCaseIDByName", StructParams = true)]
        object getTestCaseIDByName(string devKey, string testcasename, string testsuitename);
        [XmlRpcMethod("tl.getTestCaseIDByName", StructParams = true)]
        object getTestCaseIDByName(string devKey, string testcasename);
       
        /// <summary>
        /// get test case specification using external or internal id. returns last version
        /// </summary>
        /// <param name="devKey"></param>
        /// <param name="testcaseid"></param>
        /// <returns></returns>
        [XmlRpcMethod("tl.getTestCase", StructParams = true)]
        object getTestCase(string devKey, int testcaseid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="devKey"></param>
        /// <param name="testcaseid"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [XmlRpcMethod("tl.getTestCase", StructParams = true)]
        object getTestCase(string devKey, int testcaseid, int version);


        [XmlRpcMethod("tl.getTestCasesForTestPlan", StructParams = true)]
        object getTestCasesForTestPlan(string devKey, int testplanid);
        [XmlRpcMethod("tl.getTestCasesForTestPlan", StructParams = true)]
        object getTestCasesForTestPlan(string devKey, int testplanid, int testcaseid);
        [XmlRpcMethod("tl.getTestCasesForTestPlan", StructParams = true)]
        object getTestCasesForTestPlan(string devKey, int testplanid, int testcaseid, int buildid);
        [XmlRpcMethod("tl.getTestCasesForTestPlan", StructParams = true)]
        object getTestCasesForTestPlan(string devKey, int testplanid, int testcaseid, int buildid, int keywordid);
        [XmlRpcMethod("tl.getTestCasesForTestPlan", StructParams = true)]
        object getTestCasesForTestPlan(string devKey, int testplanid, int testcaseid, int buildid, int keywordid, bool executed);
        [XmlRpcMethod("tl.getTestCasesForTestPlan", StructParams = true)]
        object getTestCasesForTestPlan(string devKey, int testplanid, int testcaseid, int buildid, int keywordid, bool executed, int assignedTo);
        [XmlRpcMethod("tl.getTestCasesForTestPlan", StructParams = true)]
        object getTestCasesForTestPlan(string devKey, int testplanid, int testcaseid, int buildid, int keywordid, bool executed, int assignedTo, string executedstatus);

        [XmlRpcMethod("tl.getTestCasesForTestSuite", StructParams = true)]
        object getTestCasesForTestSuite(string devKey, int testsuiteid);
        
        [XmlRpcMethod("tl.getTestCasesForTestSuite", StructParams = true)]
        object getTestCasesForTestSuite(string devKey, int testsuiteid, bool deep);
        [XmlRpcMethod("tl.getTestCasesForTestSuite", StructParams = true)]
        object getTestCasesForTestSuite(string devKey, int testsuiteid, bool deep, string details);
        [XmlRpcMethod("tl.uploadTestCaseAttachment", StructParams = true)]
        object uploadTestCaseAttachment(string devKey, int testcaseid, string filename, string filetype, string content, string title, string description);



        #endregion

        #region TestSuite
        [XmlRpcMethod("tl.getTestSuiteByID", StructParams = true)]
        object getTestSuiteByID(string devKey, int testsuiteid);

        [XmlRpcMethod("tl.getTestSuitesForTestPlan", StructParams = true)]
        object getTestSuitesForTestPlan(string devKey, int testplanid);

        [XmlRpcMethod("tl.getFirstLevelTestSuitesForTestProject", StructParams = true)]
        object[] getFirstLevelTestSuitesForTestProject(string devKey, int testprojectid);

        [XmlRpcMethod("tl.getTestSuitesForTestSuite", StructParams = true)]
        object getTestSuitesForTestSuite(string devKey, int testsuiteid);

        [XmlRpcMethod("tl.createTestSuite", StructParams = true)]
        object[] createTestSuite(string devKey, int testprojectid, string testsuitename, string details, int parentid, int order, bool checkduplicatedname);
        [XmlRpcMethod("tl.createTestSuite", StructParams = true)]
        object[] createTestSuite(string devKey, int testprojectid, string testsuitename, string details, int order, bool checkduplicatedname);

        [XmlRpcMethod("tl.uploadTestSuiteAttachment", StructParams = true)]
        object uploadTestSuiteAttachment(string devKey, int testsuiteid, string filename, string fileType, string content, string title, string description);


        #endregion

        #region execution
        [XmlRpcMethod("tl.getLastExecutionResult", StructParams = true)]
        object[] getLastExecutionResult(string devKey, int testplanid, int testcaseid);
        [XmlRpcMethod("tl.reportTCResult", StructParams = true)]
        object reportTCResult(string devKey, int testcaseid, int testplanid, string status, int platformid, bool overwrite, string notes, bool guess, int bugid, int buildid);
        [XmlRpcMethod("tl.reportTCResult", StructParams = true)]
        object reportTCResult(string devKey, int testcaseid, int testplanid, string status, string platformname, bool overwrite, string notes, bool guess, int bugid, int buildid);
        [XmlRpcMethod("tl.reportTCResult", StructParams = true)]
        object reportTCResult(string devKey, int testcaseid, int testplanid, string status, int platformid, bool overwrite, string notes, bool guess, int bugid);
        [XmlRpcMethod("tl.reportTCResult", StructParams = true)]
        object reportTCResult(string devKey, int testcaseid, int testplanid, string status, string platformname, bool overwrite, string notes, bool guess, int bugid);
        [XmlRpcMethod("tl.reportTCResult", StructParams = true)]
        object reportTCResult(string devKey, int testcaseid, int testplanid, string status, int platformid, bool overwrite, string notes, bool guess);
        [XmlRpcMethod("tl.reportTCResult", StructParams = true)]
        object reportTCResult(string devKey, int testcaseid, int testplanid, string status, string platformname, bool overwrite, string notes, bool guess);


        /// <summary>
        /// delete an execution
        /// </summary>
        /// <param name="devKey"></param>
        /// <param name="executionid"></param>
        /// <returns> mixed $resultInfo 
	    /// 				[status]	=> true/false of success
	    /// 				[id]		  => result id or error code
	    /// 				[message]	=> optional message for error message string</returns>
        [XmlRpcMethod("tl.deleteExecution", StructParams = true)]
        object deleteExecution(string devKey, int executionid);

  

        [XmlRpcMethod("tl.uploadExecutionAttachment", StructParams = true)]
        object uploadExecutionAttachment(string devKey, int  executionid, string filename, string fileType, string content, string title, string description);

        #endregion

        #region Testplan
        /// <summary>
        /// 
        /// </summary>
        /// <param name="devKey"></param>
        /// <param name="testplanid"></param>
        /// <returns></returns>
        [XmlRpcMethod("tl.getTestPlanPlatforms", StructParams = true)]
        object getTestPlanPlatforms(string devKey, int testplanid);
        [XmlRpcMethod("tl.createTestPlan", StructParams = true)]
        object[] createTestPlan(string devKey, string testplanname, string testprojectname, string notes, string active);// can't do parameter called 'public' as it collides with .net
        [XmlRpcMethod("tl.getProjectTestPlans", StructParams = true)]
        object[] getProjectTestPlans(string devKey, int testprojectid);
        [XmlRpcMethod("tl.getLatestBuildForTestPlan", StructParams = true)]
        object getLatestBuildForTestPlan(string devKey, int testplanid);

        [XmlRpcMethod("tl.getTestPlanByName", StructParams = true)]
        object[] getTestPlanByName(string devKey, string testprojectname, string testplanname);
        /// <summary>
        /// Gets the summarized results grouped by platform
        /// </summary>
        /// <param name="devKey"></param>
        /// <param name="testplanid"></param>
        /// <returns>map where every element has:
        /// 	 *
        /// 	 *	'type' => 'platform'
        /// 	 *	'total_tc => ZZ
        /// 	 *	'details' => array ( 'passed' => array( 'qty' => X)
        /// 	 *	                     'failed' => array( 'qty' => Y)
        /// 	 *	                     'blocked' => array( 'qty' => U)
        /// 	 *                       ....)</returns>
        [XmlRpcMethod("tl.getTotalsForTestPlan", StructParams = true)]
        object getTotalsForTestPlan(string devKey, int testplanid);


        #endregion
 
        #region other
        /// <summary>
        /// simple Ping.
        /// </summary>
        /// <returns></returns>
        [XmlRpcMethod("tl.sayHello")]
        string sayHello();

        /// <summary>
        /// checks user exists
        /// </summary>
        /// <param name="devKey"></param>
        /// <param name="user"></param>
        /// <returns>true if everything OK, otherwise error structure</returns>
        [XmlRpcMethod("tl.doesUserExist", StructParams = true)]
        object doesUserExist(string devKey, string user);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="devKey"></param>
        /// <returns>true if everything OK, otherwise error structure</returns>
        [XmlRpcMethod("tl.checkDevKey", StructParams = true)]
        object checkDevKey(string devKey);


        [XmlRpcMethod("tl.about")]
        string about();

        /// <summary>
        /// Gets full path from the given node till the top using nodes_hierarchy_table
        /// </summary>
        /// <param name="devKey"></param>
        /// <param name="nodeID"></param>
        /// <returns></returns>
        [XmlRpcMethod("tl.getFullPath", StructParams = true)]
        object getFullPath(string devKey, int nodeID);

        //[XmlRpcMethod("tl.repeat")]
        //string repeat();

        #endregion

    }
}
