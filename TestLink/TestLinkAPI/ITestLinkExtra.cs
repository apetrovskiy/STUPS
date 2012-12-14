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
using System.Net;
using CookComputing.XmlRpc;

namespace Meyn.TestLink
{
	public interface ITestLinkExtra
	{
		List<Build> GetBuildsForTestPlan(int testplanid);
		GeneralResult CreateBuild(int testplanid, string buildname, string buildnotes);
		Build GetLatestBuildForTestPlan(int tplanid);
		GeneralResult ReportTCResult(int testcaseid, int testplanid, TestCaseResultStatus status, int platformId, string platformName, bool overwrite, bool guess, string notes, int buildid, int bugid);
		AttachmentRequestResponse UploadExecutionAttachment(int executionId, string filename, string fileType, byte[] content, string title, string description);
		ExecutionResult GetLastExecutionResult(int testplanid, int testcaseid);
		GeneralResult DeleteExecution(int executionid);
		TestCase GetTestCase(int testcaseid, int versionId);
		List<TestCaseFromTestSuite> GetTestCasesForTestSuite(int testSuiteid, bool deep);
		List<int> GetTestCaseIdsForTestSuite(int testSuiteid, bool deep);
		List<TestCaseId> GetTestCaseIDByName(string testcasename, string testsuitename);
		List<TestCaseId> GetTestCaseIDByName(string testcasename, int testSuiteId);
		List<TestCaseId> GetTestCaseIDByName(string testcasename);
		GeneralResult CreateTestCase(string authorLogin, int testsuiteid, string testcasename, int testprojectid, string summary, string keywords, int order, bool checkduplicatedname, ActionOnDuplicatedName actiononduplicatedname, int executiontype,
		int importance);
		GeneralResult CreateTestCase(string authorLogin, int testsuiteid, string testcasename, int testprojectid, string summary, TestStep[] steps, string keywords, int order, bool checkduplicatedname, ActionOnDuplicatedName actiononduplicatedname,
		int executiontype, int importance);
		int addTestCaseToTestPlan(int testprojectid, int testplanid, string testcaseexternalid, int version, int platformid);
		AttachmentRequestResponse UploadTestCaseAttachment(int testcaseid, string filename, string fileType, byte[] content, string title, string description);
		List<Attachment> GetTestCaseAttachments(int testCaseId);
		List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid, int keywordid, bool executed, int assignedTo, string executedstatus);
		List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid, int keywordid, bool executed, int assignedTo);
		List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid, int keywordid, bool executed);
		List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid, int keywordid);
		List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid);
		List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid);
		List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid);
		List<TestPlan> GetProjectTestPlans(int projectid);
		TestPlan getTestPlanByName(string projectname, string planName);
		List<TestPlanTotal> GetTotalsForTestPlan(int testplanid);
		List<TestPlatform> GetTestPlanPlatforms(int testplanid);
		GeneralResult CreateTestPlan(string testplanname, string testProjectName, string notes, bool active);
		List<TestProject> GetProjects();
		TestProject GetProject(string projectname);
		AttachmentRequestResponse UploadTestProjectAttachment(int executionId, string filename, string fileType, byte[] content, string title, string description);
		GeneralResult CreateProject(string projectname, string testcasePrefix, string notes);
		List<TestSuite> GetTestSuitesForTestPlan(int testplanid);
		List<TestSuite> GetFirstLevelTestSuitesForTestProject(int testprojectid);
		List<TestSuite> GetTestSuitesForTestSuite(int testsuiteid);
		TestSuite GetTestSuiteById(int id);
		GeneralResult CreateTestSuite(int testprojectid, string testsuitename, string details, int parentId, int order, bool checkduplicatedname);
		AttachmentRequestResponse UploadTestSuiteAttachment(int testsuiteid, string filename, string fileType, byte[] content, string title, string description);
		string SayHello();
		string about();
		bool checkDevKey(string devkey);
		bool DoesUserExist(string username);
		string LastRequest { get; }
		string LastResponse { get; }
	}
}
