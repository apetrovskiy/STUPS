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
using System.Linq;
using System.Net;
using CookComputing.XmlRpc;

namespace Meyn.TestLink
{
	/// <summary>
	/// represent the result of a test case execution
	/// </summary>
	public enum TestCaseResultStatus
	{
		Pass,
		Fail,
		Blocked,
		undefined
	}
	/// <summary>
	/// used for creating test cases to tell Testlink what to do if another test case is found with the same name
	/// </summary>
	public enum ActionOnDuplicatedName
	{
		Block,
		GenerateNew,
		CreateNewVersion
	}

	/// <summary>
	/// this is the proxy class to connect to TestLink.
	/// It provides a list of functions that map straight into the Tstlink API as it stands at V 1.9.2
	/// </summary>
	/// <remarks>This class makes use of XML-RPC.NET Copyright (c) 2006 Charles Cook</remarks>
	public class TestLink : ITestLinkExtra
	{
		private string devkey = "";
		private ITestLink proxy = null;


		#region constructors
		/// <summary>
		/// default constructor 
		/// </summary>
		/// <param name="apiKey">developer key as provided by testlink</param>
		/// <param name="url">url of testlink API. Something like http://localhost/testlink/lib/api/xmlrpc.php</param>
		public TestLink(string apiKey, string url) : this(apiKey, url, false)
		{
		}
		///// <summary>
		///// default constructor without URL. Uses default localhost url
		///// </summary>
		///// <param name="apiKey"></param>
		//public TestLink(string apiKey) : this(apiKey, "", false) { }

		///// <summary>
		///// constructor with debug key
		///// </summary>
		///// <param name="apiKey"></param>
		///// <param name="log">if true then keep last request and last response</param>
		//public TestLink(string apiKey, bool log): this(apiKey,"",log)
		//{
		//}
		/// <summary>
		/// constructor with URL and log flag
		/// </summary>
		/// <param name="apiKey">developer key as provided by testlink</param>
		/// <param name="url">url of testlink API. Something like http://localhost/testlink/lib/api/xmlrpc.php </param>
		/// <param name="log">enable capture of lastRequest and lastResponse for debugging</param>
		public TestLink(string apiKey, string url, bool log)
		{
			devkey = apiKey;
			proxy = XmlRpcProxyGen.Create<ITestLink>();
			if (log) {
				proxy.RequestEvent += new XmlRpcRequestEventHandler(myHandler);
				proxy.ResponseEvent += new XmlRpcResponseEventHandler(proxy_ResponseEvent);
			}
			if (!string.IsNullOrEmpty(url))
				proxy.Url = url;
		}
		#endregion

		#region logging
		private string lastRequest;
		/// <summary>
		/// last xmlrpc request sent to testlink. only works if constructor was called with argument log set to true
		/// </summary>
		public string LastRequest {
			get { return lastRequest; }
		}
		private string lastResponse;
		/// <summary>
		/// debug last response reseved from testlink xmlrpc call. Only works if constructor was called with argument log set to true
		/// </summary>
		public string LastResponse {
			get { return lastResponse; }
		}

		private void proxy_ResponseEvent(object sender, XmlRpcResponseEventArgs args)
		{
			args.ResponseStream.Seek(0, System.IO.SeekOrigin.Begin);
			System.IO.StreamReader sr = new System.IO.StreamReader(args.ResponseStream);
			lastResponse = sr.ReadToEnd();
		}

		private void myHandler(object sender, CookComputing.XmlRpc.XmlRpcRequestEventArgs args)
		{
			long l = args.RequestStream.Length;
			args.RequestStream.Seek(0, System.IO.SeekOrigin.Begin);
			System.IO.StreamReader sr = new System.IO.StreamReader(args.RequestStream);
			lastRequest = sr.ReadToEnd();
		}
		#endregion

		#region error handling
		/// <summary>
		///  process the response object returned by the Tstlink API for error messages. 
		///  if it finds one or more error messages it throws a TLINK Exception        ///  
		/// </summary>
		/// <param name="errorMessage">the actual message returned by testlink</param>
		/// <returns>true if it found an error message that matches an errorCodes list
		/// false if there were no errors</returns>returns>
		private bool handleErrorMessage(object errorMessage)
		{
			if (errorMessage is object[])
				return handleErrorMessage(errorMessage as object[], new int[0]);
			else
				return false;

		}
		/// <summary>
		///  process the response object returned by the Tstlink API for error messages. 
		///  if it finds one or more error messages it throws a TLINK Exception        ///  
		/// </summary>
		/// <param name="errorMessage">the actual message returned by testlink</param>
		/// <returns>true if it found an error message that matches an errorCodes list
		/// false if there were no errors</returns>returns>
		/// <param name="exceptedErrorCodes">a list of integers that should not result in an exception to be processed</param>
		private bool handleErrorMessage(object errorMessage, params int[] exceptedErrorCodes)
		{
			if (errorMessage is object[])
				return handleErrorMessage(errorMessage as object[], exceptedErrorCodes);
			else
				return false;
		}
		/// <summary>
		///  process the response object returned by the Tstlink API for error messages. 
		///  if it finds one or more error messages it throws a TLINK Exception        ///  
		/// </summary>
		/// <param name="errorMessage">the actual message returned by testlink</param>
		/// <returns>true if it found an error message that matches an errorCodes list
		/// false if there were no errors</returns>returns>
		/// <param name="exceptedErrorCodes">a list of integers that should not result in an exception to be processed</param>
		private bool handleErrorMessage(object[] errorMessage, int[] exceptedErrorCodes)
		{
			List<TLErrorMessage> errs = decodeErrors(errorMessage);
			if (errs.Count > 0) {
				foreach (TLErrorMessage foundError in errs) {
					bool matched = exceptedErrorCodes.Any(exceptedErrorCode => foundError.code == exceptedErrorCode);

                    /*
                    List<TLErrorMessage> errs = decodeErrors(errorMessage);
                    if (errs.Count > 0)
                    {
                        foreach (TLErrorMessage foundError in errs)
                        {
                            bool matched = false;
                            foreach (int exceptedErrorCode in exceptedErrorCodes)
                                if (foundError.code == exceptedErrorCode)
                                {
                                    matched = true;
                                    break;
                                }
                            // all must match or we throw an exception
                            if (!matched)
                            {
                                string msg = string.Format("{0}:{1}", errs[0].code, errs[0].message);
                                throw new TestLinkException(msg, errs);
                            }
                        }
                        return true;
                        // we have matched the errors to the exceptions
                    }
                    return false;
                        // there were no errors
                    */

				    // all must match or we throw an exception
					if (!matched) {
						string msg = string.Format("{0}:{1}", errs[0].code, errs[0].message);
						throw new TestLinkException(msg, errs);
					}
				}
				return true;
				// we have matched the errors to the exceptions
			}
			return false;
			// there were no errors
		}

		private List<TLErrorMessage> decodeErrors(object messageList)
		{
			return decodeErrors(messageList as object[]);
		}
		/// <summary>
		/// internal. try to conver the struct to an error message. Return null if it wasn't one
		/// </summary>
		/// <param name="messageList"></param>
		/// <returns>a TLErrorMessage or null</returns>
		private List<TLErrorMessage> decodeErrors(IEnumerable<object> messageList)
		{
			List<TLErrorMessage> result = new List<TLErrorMessage>();
			if (messageList == null)
				return result;
		    result.AddRange(from XmlRpcStruct message in messageList where message.ContainsKey("code") && message.ContainsKey("message") select new TLErrorMessage(message));
            /*
            List<TLErrorMessage> result = new List<TLErrorMessage>();
            if (messageList == null)
                return result;
            foreach (XmlRpcStruct message in messageList)
            {
                if (message.ContainsKey("code") && message.ContainsKey("message"))
                    result.Add(new TLErrorMessage(message));
            }
            return result;
            */

		    return result;
		}
		private TLErrorMessage decodeSingleError(XmlRpcStruct message)
		{
			if (message.ContainsKey("code") && message.ContainsKey("message"))
				return new TLErrorMessage(message);
			else
				return null;
		}
		/// <summary>
		/// check that the state of the interface 
		/// </summary>
		private void stateIsValid()
		{
			if (devkey == null)
				throw new TestLinkException("Devkey is null. You must supply a development key");
			if (devkey == string.Empty)
				throw new TestLinkException("Devkey is empty. You must supply a development key");
		}
		#endregion

		#region Builds
		/// <summary>
		/// get a list of all builds for a testplan
		/// </summary>
		/// <param name="testplanid">the id of the testplan</param>
		/// <returns>a list (may be empty)</returns>
		public List<Build> GetBuildsForTestPlan(int testplanid)
		{

			stateIsValid();
			object response = proxy.getBuildsForTestPlan(devkey, testplanid);
			handleErrorMessage(response);
			List<Build> retval = new List<Build>();
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return retval;
			object[] oList = response as object[];

		    retval.AddRange(from XmlRpcStruct data in oList select new Build(data));
            /*
            foreach (XmlRpcStruct data in oList)
            {

                Build b = new Build(data);
                retval.Add(b);
            }
            */

		    return retval;
		}

		/// <summary>
		/// create a build for a testplan
		/// </summary>
		/// <param name="testplanid">id of the test plan</param>
		/// <param name="buildname">name of the build</param>
		/// <param name="buildnotes">notes</param>
		/// <returns>General Result object</returns>
		public GeneralResult CreateBuild(int testplanid, string buildname, string buildnotes)
		{
			stateIsValid();
			object[] o = proxy.createBuild(devkey, testplanid, buildname, buildnotes);
			handleErrorMessage(o);
			foreach (XmlRpcStruct data in o)
				return new GeneralResult(data);
			return null;
		}

		/// <summary>
		/// get the newest build for a test plan
		/// </summary>
		/// <param name="tplanid">id of testplan</param>
		/// <returns>a build object</returns>
		public Build GetLatestBuildForTestPlan(int tplanid)
		{
			stateIsValid();
			object response = proxy.getLatestBuildForTestPlan(devkey, tplanid);

			object[] objectList = response as object[];
			XmlRpcStruct data = response as XmlRpcStruct;
			if (handleErrorMessage(objectList, 3031))
				return null;
			// no build existing    
			if (data != null)
				return new Build(data);

			return null;
		}
		#endregion

		#region Execution


		#region reportTCResult

		private GeneralResult handleReportTCResult(object response)
		{
			if (response is object[]) {
				object[] responseList = response as object[];
				if (responseList.Length > 0) {
					XmlRpcStruct msg = (XmlRpcStruct)responseList[0];
					GeneralResult result = new GeneralResult(msg);
					return result;
				}
			}
			GeneralResult noResult = new GeneralResult();

			return noResult;
		}



		/// <summary>
		/// Record the outcome of a test case execution
		/// </summary>
		/// <param name="testcaseid">Id of test case</param>
		/// <param name="testplanid">Id of test plan</param>
		/// <param name="status">The result of the test (pass, fail or blocked)</param>
		/// <param name="platformId">Id of the platform. Optional if platform name is given</param>
		/// <param name="platformName">name of the platform. Optional if the platform id is given</param>
		/// <param name="overwrite">if true, then last execution for (testcase,testplan,build,platform) will be overwritten.</param>
		/// <param name="guess"> (assumed to be true) defining whether to guess optinal params or require them explicitly default is true</param>
		/// <param name="notes">any notes or info to be added to the description field</param>
		/// <param name="buildid">If not given, then highest build id willl be used</param>
		/// <param name="bugid">Id for a bug if used in conjunction with a defect tracker</param>
		/// <returns></returns>
		public GeneralResult ReportTCResult(int testcaseid, int testplanid, TestCaseResultStatus status, int platformId = 0, string platformName = null, bool overwrite = false, bool guess = true, string notes = "", int buildid = 0, int bugid = 0)
		{
			stateIsValid();

			string statusChar = "";
			switch (status) {
				case TestCaseResultStatus.Blocked:
					statusChar = "b";
					break;
				case TestCaseResultStatus.Pass:
					statusChar = "p";
					break;
				case TestCaseResultStatus.Fail:
					statusChar = "f";
					break;
			}
			object response = null;
			if (platformName != null) {
				if (bugid == 0) {
					if (buildid == 0)
						response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformName, overwrite, notes, guess);
					else
						response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformName, overwrite, notes, guess, 0, buildid);
				} else {
					if (buildid == 0)
						response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformName, overwrite, notes, guess, bugid);
					else
						response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformName, overwrite, notes, guess, bugid, buildid);
				}
			} else {
				if (platformId == 0)
					throw new TestLinkException("must supply either a platform id or a platform name");
				if (bugid == 0) {
					if (buildid == 0)
						response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformId, overwrite, notes, guess);
					else
						response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformId, overwrite, notes, guess, 0, buildid);
				} else {
					if (buildid == 0)
						response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformId, overwrite, notes, guess, bugid);
					else
						response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformId, overwrite, notes, guess, bugid, buildid);
				}
			}
			handleErrorMessage(response);

			//object response = proxy.reportTCResult(devkey, testcaseid, testplanid, statusChar, platformId, overwrite, notes, guess, buildid, bugid);
			//handleErrorMessage(response);
			return handleReportTCResult(response);
		}

		/// <summary>
		/// Uploads an attachment for an execution. 
		/// </summary>
		/// <remarks>The attachment content must be Base64 encoded by the client before sending it.</remarks>
		/// <param name="executionId"></param>
		/// <param name="title">The title of the Attachment </param>
		/// <param name="description">The description of the Attachment</param>
		/// <param name="filename">The file name of the Attachment (e.g.:notes.txt)</param>
		/// <param name="fileType">The file type of the Attachment (e.g.: text/plain)</param>
		/// <param name="content">The content (Base64 encoded) of the Attachment</param>
		/// <returns>An AttachmentRequestResponse</returns>
		public AttachmentRequestResponse UploadExecutionAttachment(int executionId, string filename, string fileType, byte[] content, string title = "", string description = "")
		{
			stateIsValid();
			string base64String;
			try {
				base64String = System.Convert.ToBase64String(content, 0, content.Length);
			} catch (System.ArgumentNullException) {
				// System.Console.WriteLine("Binary data array is null.");
				base64String = "";
			}
			object response = proxy.uploadExecutionAttachment(devkey, executionId, filename, fileType, base64String, title, description);
			handleErrorMessage(response);
			AttachmentRequestResponse r = new AttachmentRequestResponse(response as XmlRpcStruct);
			return r;
		}



		/// <summary>
		/// get the last execution result
		/// </summary>
		/// <param name="testplanid">id of the test plan</param>
		/// <param name="testcaseid">id of test case</param>
		/// <returns>a ExecutionResult or null</returns>
		public ExecutionResult GetLastExecutionResult(int testplanid, int testcaseid)
		{
			stateIsValid();
			object[] response = proxy.getLastExecutionResult(devkey, testplanid, testcaseid);

			List<ExecutionResult> result = new List<ExecutionResult>();
			if ((response.Length == 0) || (response[0] is int))
				// that signifies no execution results
				return null;

			handleErrorMessage(response);
			if (response != null) {
				// check if it is a no result indicator

				foreach (XmlRpcStruct data in response) {
					object id = data["id"];
					if ((id is int) && ((int)id == -1))
						return null;
					// -1 means no result
					return new ExecutionResult(data);
				}
			}
			return null;
		}

		#endregion


		/// <summary>
		/// delete an execution. Current status this API is not fully functioning as it is not clear how to configure testlink to allow this to happen
		/// </summary>
		/// <param name="executionid">the id of the test case execution</param>
		/// <returns>a GeneralResult</returns>
		public GeneralResult DeleteExecution(int executionid)
		{
			stateIsValid();
			object o = proxy.deleteExecution(devkey, executionid);
			handleErrorMessage(o);
			object[] list = o as object[];
			return new GeneralResult(list[0] as XmlRpcStruct);

		}
		#endregion

		#region TestCase
		/// <summary>
		/// get a test case by its id
		/// </summary>
		/// <param name="testcaseid">Id of the test case</param>
		/// <param name="versionId">(optional) the version id. If not given the latest version is returned</param>
		/// <returns></returns>
		public TestCase GetTestCase(int testcaseid, int versionId = 0)
		{
			stateIsValid();
			object o = null;
			if (versionId == 0)
				o = proxy.getTestCase(devkey, testcaseid);
			else
				o = proxy.getTestCase(devkey, testcaseid, versionId);
			handleErrorMessage(o);
			XmlRpcStruct[] rList = o as XmlRpcStruct[];
			return new TestCase(rList[0]);
		}


		/// <summary>
		/// get test cases contained in a test suite
		/// </summary>
		/// <param name="testSuiteid">id of the test suite</param>
		/// <param name="deep">Set the deep flag to false if you only want test cases in the test suite provided and no child test cases.</param>
		/// <returns>A list of Test Cases</returns>
		public List<TestCaseFromTestSuite> GetTestCasesForTestSuite(int testSuiteid, bool deep)
		{

			stateIsValid();
			List<TestCaseFromTestSuite> result = new List<TestCaseFromTestSuite>();
			object response = proxy.getTestCasesForTestSuite(devkey, testSuiteid, deep, "full");
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return result;
			handleErrorMessage(response);
			object[] list = response as object[];
			if (list != null) {
				foreach (XmlRpcStruct data in list) {
					TestCaseFromTestSuite tc = new TestCaseFromTestSuite(data);
					result.Add(tc);
				}
			}
			return result;
		}
		/// <summary>
		/// get a list of testcase ids of test cases contained in a test suite
		/// </summary>
		/// <param name="testSuiteid">id of the test suite</param>
		/// <param name="deep">Set the deep flag to false if you only want test cases in the test suite provided and no child test cases.</param>
		/// <returns></returns>
		public List<int> GetTestCaseIdsForTestSuite(int testSuiteid, bool deep)
		{
			stateIsValid();
			object o = proxy.getTestCasesForTestSuite(devkey, testSuiteid, deep, "simple");
			List<int> result = new List<int>();

			handleErrorMessage(o);

			XmlRpcStruct[] list = o as XmlRpcStruct[];
			foreach (XmlRpcStruct item in list) {
				string val = (string)item["id"];
				//string val = "2";// (string)item.Keys[0];//["id"];
				result.Add(int.Parse(val));
			}
			return result;
		}


		/// <summary>
		/// ask for a test case by name. 
		/// </summary>
		/// <param name="testcasename">the name of the test case</param>
		/// <param name="testsuitename">the name of the test suite</param>
		/// <remarks>Searching is case sensitive.</remarks>
		/// <returns>a list of test cases found</returns>
		public List<TestCaseId> GetTestCaseIDByName(string testcasename, string testsuitename)
		{
			stateIsValid();
			object response = proxy.getTestCaseIDByName(devkey, testcasename, testsuitename);
			List<TLErrorMessage> errs = decodeErrors(response);
			if ((errs.Count > 0) && (errs[0].code == 5030))
				// 5030 is no id found
				return new List<TestCaseId>();

			handleErrorMessage(response);
			return processTestCaseId(response);
		}
		/// <summary>
		/// get a test cases by this name
		/// </summary>
		/// <param name="testcasename">name of the test case (case sensitive)</param>
		/// <param name="testSuiteId">name of test suite</param>
		/// <returns>a list containing zero to many test cases with that name that occur in the specific test suite</returns>
		public List<TestCaseId> GetTestCaseIDByName(string testcasename, int testSuiteId)
		{
			List<TestCaseId> idList = GetTestCaseIDByName(testcasename);
			if (idList.Count == 0)
				return idList;
			List<TestCaseId> result = new List<TestCaseId>();
			foreach (TestCaseId tc in idList)
				if (tc.parent_id == testSuiteId)
					result.Add(tc);
			return result;
		}
		/// <summary>
		/// get a list of test case ids with this name. 
		/// </summary>
		/// <param name="testcasename">name of the test case (case sensitive)</param>
		/// <returns>a list containing zero to many test case id objects with that name</returns>
		public List<TestCaseId> GetTestCaseIDByName(string testcasename)
		{
			stateIsValid();
			object response = proxy.getTestCaseIDByName(devkey, testcasename);
			List<TLErrorMessage> errs = decodeErrors(response);
			if ((errs.Count > 0) && (errs[0].code == 5030))
				// 5030 is no id found
				return new List<TestCaseId>();

			handleErrorMessage(response);
			return processTestCaseId(response);
		}

		private List<TestCaseId> processTestCaseId(object response)
		{
			List<TestCaseId> result = new List<TestCaseId>();
			if (response is object[]) {
				object[] responseList = response as object[];
				foreach (XmlRpcStruct item in responseList) {
					TestCaseId id = new TestCaseId(item);
					result.Add(id);
				}
			}
			return result;
		}

		/// <summary>
		/// create a new Testcase without having to specify test steps
		/// </summary>
		/// <summary>
		/// Create a new Test Case
		/// </summary>
		/// <param name="authorLogin">login id of test case author</param>
		/// <param name="testsuiteid">Id of test suite</param>
		/// <param name="testcasename">name of test case</param>
		/// <param name="testprojectid">id of test project</param>
		/// <param name="summary">summary of result</param>
		/// <param name="keywords"></param>
		/// <param name="order">defaultOrder = 0, otherwise location in sequence to other testcases</param>
		/// <param name="checkduplicatedname">1=yes, 0=no</param>
		/// <param name="actiononduplicatedname">one of block, generate_new, create_new_version</param>
		/// <param name="executiontype">manual:1, automated: 2, </param>
		/// <param name="importance">Importance of test case</param>
		public GeneralResult CreateTestCase(string authorLogin, int testsuiteid, string testcasename, int testprojectid, string summary, string keywords, int order, bool checkduplicatedname, ActionOnDuplicatedName actiononduplicatedname, int executiontype,
		int importance)
		{
			return CreateTestCase(authorLogin, testsuiteid, testcasename, testprojectid, summary, new TestStep[0], keywords, order, checkduplicatedname, actiononduplicatedname,
			executiontype, importance);
		}


		/// <summary>
		/// Create a new Test Case
		/// </summary>
		/// <param name="authorLogin">login id of test case author</param>
		/// <param name="testsuiteid">Id of test suite</param>
		/// <param name="testcasename">name of test case</param>
		/// <param name="testprojectid">id of test project</param>
		/// <param name="summary">summary of result</param>
		/// <param name="steps">Array of test steps</param>
		/// <param name="keywords"></param>
		/// <param name="order">defaultOrder = 0, otherwise location in sequence to other testcases</param>
		/// <param name="checkduplicatedname">1=yes, 0=no</param>
		/// <param name="actiononduplicatedname">one of block, generate_new, create_new_version</param>
		/// <param name="executiontype">manual:1, automated: 2, </param>
		/// <param name="importance">Importance of test case</param>

		public GeneralResult CreateTestCase(string authorLogin, int testsuiteid, string testcasename, int testprojectid, string summary, TestStep[] steps, string keywords, int order, bool checkduplicatedname, ActionOnDuplicatedName actiononduplicatedname,
		int executiontype, int importance)
		{

			string actionFlag = "block";
			switch (actiononduplicatedname) {
				case ActionOnDuplicatedName.Block:
					actionFlag = "block";
					break;
				case ActionOnDuplicatedName.CreateNewVersion:
					actionFlag = "create_new_version";
					break;
				case ActionOnDuplicatedName.GenerateNew:
					actionFlag = "generate_new";
					break;
			}



			stateIsValid();
			object response = proxy.createTestCase(devkey, authorLogin, testsuiteid, testcasename, testprojectid, summary, steps, keywords, order, checkduplicatedname ? 1 : 0,
			actionFlag, executiontype, importance);

			handleErrorMessage(response);

			if (response is object[]) {
				object[] list = response as object[];
				foreach (XmlRpcStruct data in list)
					return new GeneralResult(data);
			}
			return null;
		}

		/// <summary>
		/// add a test case to a test plan (no way of removing one)
		/// </summary>
		/// <param name="testprojectid"></param>
		/// <param name="testplanid"></param>
		/// <param name="testcaseexternalid">the id that is displayed on the GUI</param>
		/// <param name="version"></param>
		/// <param name="platformid"></param>
		/// <returns></returns>
		/// <remarks>this testExternalid is a string and a concatenation of the 
		/// test project prefix and the externalid that is reported in the test case creation.
		/// </remarks>
		public int addTestCaseToTestPlan(int testprojectid, int testplanid, string testcaseexternalid, int version, int platformid = 0)
		{
			object o = null;
			stateIsValid();
			if (platformid == 0)
				o = proxy.addTestCaseToTestPlan(devkey, testprojectid, testplanid, testcaseexternalid, version);
			else
				o = proxy.addTestCaseToTestPlan(devkey, testprojectid, testplanid, testcaseexternalid, version, platformid);

			handleErrorMessage(o);
			if (o is XmlRpcStruct) {
				XmlRpcStruct data = o as XmlRpcStruct;
				if ((data != null) && (data.ContainsKey("feature_id"))) {
					string val = (string)data["feature_id"];
					int result;
					bool good = int.TryParse(val, out result);
					if (good)
						return result;

				}
			}
			return 0;
		}
		/// <summary>
		/// upload an attachment for a test case
		/// </summary>
		/// <param name="testcaseid"></param>
		/// <param name="filename"></param>
		/// <param name="fileType"></param>
		/// <param name="content"></param>
		/// <param name="title"></param>
		/// <param name="description"></param>
		/// <returns></returns>
		public AttachmentRequestResponse UploadTestCaseAttachment(int testcaseid, string filename, string fileType, byte[] content, string title, string description)
		{
			string base64String;
			try {
				base64String = System.Convert.ToBase64String(content, 0, content.Length);
			} catch (System.ArgumentNullException) {
				// System.Console.WriteLine("Binary data array is null.");
				base64String = "";
			}
			stateIsValid();
			object response = proxy.uploadTestCaseAttachment(devkey, testcaseid, filename, fileType, base64String, title, description);
			handleErrorMessage(response);
			AttachmentRequestResponse r = new AttachmentRequestResponse(response as XmlRpcStruct);
			return r;
		}
		/// <summary>
		/// retrieve the attachments for a test case
		/// </summary>
		/// <param name="testCaseId"></param>
		/// <returns></returns>
		public List<Attachment> GetTestCaseAttachments(int testCaseId)
		{
			stateIsValid();
			object o = proxy.getTestCaseAttachments(devkey, testCaseId);
			handleErrorMessage(o);
			List<Attachment> result = new List<Attachment>();
			XmlRpcStruct olist = o as XmlRpcStruct;
			if (olist != null) {
				foreach (XmlRpcStruct item in olist.Values) {
					Attachment a = new Attachment(item);
					result.Add(a);
				}
			}
			return result;
		}


		#region getTestCasesForTestPlan
		/// <summary>
		/// get all test cases for a test plan .
		/// </summary>
		/// <remarks> The same test case id can show up multiple times, once per platform.</remarks>
		/// <param name="testplanid"></param>
		/// <param name="testcaseid"></param>
		/// <param name="buildid"></param>
		/// <param name="keywordid"></param>
		/// <param name="executed"></param>
		/// <param name="assignedTo"></param>
		/// <param name="executedstatus"></param>
		/// <returns></returns>
		public List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid, int keywordid, bool executed, int assignedTo, string executedstatus)
		{
			stateIsValid();
			object response = proxy.getTestCasesForTestPlan(devkey, testplanid, testcaseid, buildid, keywordid, executed, assignedTo, executedstatus);
			List<TestCaseFromTestPlan> result = new List<TestCaseFromTestPlan>();
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return result;
			handleErrorMessage(response);
			XmlRpcStruct list = response as XmlRpcStruct;
			return TestCaseFromTestPlan.GenerateFromResponse(list);
		}
		/// <summary>
		/// get all test cases for a test plan .
		/// </summary>
		/// <remarks> The same test case id can show up multiple times, once per platform.</remarks>
		/// <param name="testplanid"></param>
		/// <param name="testcaseid"></param>
		/// <param name="buildid"></param>
		/// <param name="keywordid"></param>
		/// <param name="executed"></param>
		/// <param name="assignedTo"></param>
		/// <returns></returns>
		public List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid, int keywordid, bool executed, int assignedTo)
		{
			stateIsValid();
			object response = proxy.getTestCasesForTestPlan(devkey, testplanid, testcaseid, buildid, keywordid, executed, assignedTo);
			List<TestCaseFromTestPlan> result = new List<TestCaseFromTestPlan>();
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return result;
			handleErrorMessage(response);
			XmlRpcStruct list = response as XmlRpcStruct;
			return TestCaseFromTestPlan.GenerateFromResponse(list);
		}
		/// <summary>
		/// get all test cases for a test plan .
		/// </summary>
		/// <remarks> The same test case id can show up multiple times, once per platform.</remarks>
		/// <param name="testplanid"></param>
		/// <param name="testcaseid"></param>
		/// <param name="buildid"></param>
		/// <param name="keywordid"></param>
		/// <param name="executed"></param>
		/// <returns></returns>
		public List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid, int keywordid, bool executed)
		{
			stateIsValid();
			object response = proxy.getTestCasesForTestPlan(devkey, testplanid, testcaseid, buildid, keywordid, executed);
			List<TestCaseFromTestPlan> result = new List<TestCaseFromTestPlan>();
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return result;
			handleErrorMessage(response);
			XmlRpcStruct list = response as XmlRpcStruct;
			return TestCaseFromTestPlan.GenerateFromResponse(list);
		}
		/// <summary>
		/// get all test cases for a test plan .
		/// </summary>
		/// <remarks> The same test case id can show up multiple times, once per platform.</remarks>
		/// <param name="testplanid"></param>
		/// <param name="testcaseid"></param>
		/// <param name="buildid"></param>
		/// <param name="keywordid"></param>
		/// <returns></returns>
		public List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid, int keywordid)
		{
			stateIsValid();
			object response = proxy.getTestCasesForTestPlan(devkey, testplanid, testcaseid, buildid, keywordid);
			List<TestCaseFromTestPlan> result = new List<TestCaseFromTestPlan>();
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return result;
			handleErrorMessage(response);
			XmlRpcStruct list = response as XmlRpcStruct;
			return TestCaseFromTestPlan.GenerateFromResponse(list);
		}
		/// <summary>
		/// get all test cases for a test plan .
		/// </summary>
		/// <remarks> The same test case id can show up multiple times, once per platform.</remarks>
		/// <param name="testplanid"></param>
		/// <param name="testcaseid"></param>
		/// <param name="buildid"></param>
		/// <returns></returns>
		public List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid, int buildid)
		{
			stateIsValid();
			object response = proxy.getTestCasesForTestPlan(devkey, testplanid, testcaseid, buildid);
			List<TestCaseFromTestPlan> result = new List<TestCaseFromTestPlan>();
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return result;
			handleErrorMessage(response);
			XmlRpcStruct list = response as XmlRpcStruct;
			return TestCaseFromTestPlan.GenerateFromResponse(list);
		}
		/// <summary>
		/// get all test cases for a test plan .
		/// </summary>
		/// <remarks> The same test case id can show up multiple times, once per platform.</remarks>
		/// <param name="testplanid"></param>
		/// <param name="testcaseid"></param>
		/// <returns></returns>
		public List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid, int testcaseid)
		{
			stateIsValid();
			object response = proxy.getTestCasesForTestPlan(devkey, testplanid, testcaseid);
			List<TestCaseFromTestPlan> result = new List<TestCaseFromTestPlan>();
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return result;
			handleErrorMessage(response);
			XmlRpcStruct list = response as XmlRpcStruct;
			return TestCaseFromTestPlan.GenerateFromResponse(list);
		}
		/// <summary>
		/// get all test cases for a test plan
		/// </summary>
		/// <param name="testplanid"></param>
		/// <returns>List of test cases with test plan data added</returns>
		public List<TestCaseFromTestPlan> GetTestCasesForTestPlan(int testplanid)
		{
			stateIsValid();
			object response = proxy.getTestCasesForTestPlan(devkey, testplanid);

			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return new List<TestCaseFromTestPlan>();

			handleErrorMessage(response);
			XmlRpcStruct list = response as XmlRpcStruct;
			return TestCaseFromTestPlan.GenerateFromResponse(list);
		}
		#endregion
		#endregion

		#region TestPlan

		/// <summary>
		/// get a list of all testplans for a project
		/// </summary>
		/// <param name="projectid"></param>
		/// <returns></returns>
		public List<TestPlan> GetProjectTestPlans(int projectid)
		{
			List<TestPlan> retval = new List<TestPlan>();
			object response = null;
			stateIsValid();
			// Checked Testlink V 1.9.2 Still behaves this way
			try {
				response = proxy.getProjectTestPlans(devkey, projectid);
			// if a project has no test plans this exception is thrown
			} catch (CookComputing.XmlRpc.XmlRpcTypeMismatchException) {
				return retval;
				// empty list
			// happens when no plans exist. Empty response is sent back
			} catch (InvalidCastException) {
				return retval;
				// empty list
			}

			handleErrorMessage(response);
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return retval;
			XmlRpcStruct[] results = response as XmlRpcStruct[];
			object[] oList = response as object[];
			if ((oList.Length == 0) || (oList[0] is string))
				return retval;

			foreach (XmlRpcStruct result in oList) {
				TestPlan tp = new TestPlan(result);
				retval.Add(tp);
			}
			return retval;
		}
		/// <summary>
		/// get a test plan for a project
		/// </summary>
		/// <param name="projectname">the name of the owning project</param>
		/// <param name="planName"></param>
		/// <returns>a TestPlan or Null</returns>
		public TestPlan getTestPlanByName(string projectname, string planName)
		{
			stateIsValid();
			object response = proxy.getTestPlanByName(devkey, projectname, planName);
			handleErrorMessage(response);
			object[] oList = response as object[];
			if (oList.Length == 1) {
				XmlRpcStruct data = (XmlRpcStruct)oList[0];
				if (data.ContainsKey("code")) {
					throw new TestLinkException("Testlink returned an error (code={0}, msg= {1})", data["code"], data["message"]);
				}
				TestPlan result = new TestPlan(data);
				return result;
			}
			return null;
		}


		/// <summary>
		/// get totals for a testplan
		/// </summary>
		/// <param name="testplanid"></param>
		/// <remarks>If a test plan has no executions to it you will still get a list iwth a single item. That item will have zeros in its totals</remarks>
		/// <returns></returns>
		public List<TestPlanTotal> GetTotalsForTestPlan(int testplanid)
		{
			stateIsValid();
			object o = proxy.getTotalsForTestPlan(devkey, testplanid);
			handleErrorMessage(o);
			List<TestPlanTotal> list = new List<TestPlanTotal>();

			XmlRpcStruct[] resultList;
			if (o is XmlRpcStruct[]) {
				resultList = o as XmlRpcStruct[];
				list.Add(new TestPlanTotal(resultList[0]));
			} else {
				XmlRpcStruct or = o as XmlRpcStruct;
				foreach (XmlRpcStruct result in or.Values)
					list.Add(new TestPlanTotal(result));
			}
			return list;
		}

		/// <summary>
		/// get a list of all platforms for a test plan.
		///
		/// </summary>
		/// <remarks>Throws an exception of type Testlink Exception</remarks>
		/// <param name="testplanid"></param>
		/// <returns>a list of testplan platforms</returns>
		public List<TestPlatform> GetTestPlanPlatforms(int testplanid)
		{
			List<TestPlatform> result = new List<TestPlatform>();

			stateIsValid();
			object o = proxy.getTestPlanPlatforms(devkey, testplanid);

			if (handleErrorMessage(o, 3041))
				// 3041 means no platforms are assigned for this testplan
				return result;
			// return an empty list 
			if (o is object[]) {
				object[] responseList = o as object[];
				foreach (XmlRpcStruct item in responseList) {
					TestPlatform id = new TestPlatform(item);
					result.Add(id);
				}
			}
			return result;
		}

		/// <summary>
		/// create a new Testplan 
		/// </summary>
		/// <param name="testplanname">the name of the plan</param>
		/// <param name="testProjectName">the name of the test project that contains the test plan</param>
		/// <param name="notes"></param>
		/// <param name="active">whether this plan is currently active</param>
		/// <returns></returns>
		public GeneralResult CreateTestPlan(string testplanname, string testProjectName, string notes = "", bool active = true)
		{
			stateIsValid();
			object[] o = proxy.createTestPlan(devkey, testplanname, testProjectName, notes, active ? "1" : "0");
			handleErrorMessage(o);
			foreach (XmlRpcStruct data in o)
				return new GeneralResult(data);
			return null;
		}
		#endregion

		#region test project
		/// <summary>
		/// get a list of all projects
		/// </summary>
		/// <returns></returns>
		public List<TestProject> GetProjects()
		{
			stateIsValid();
			object response = null;
			response = proxy.getProjects(devkey);

			List<TestProject> retval = new List<TestProject>();
			if ((response is string) && ((string)response == string.Empty))
				// equals null return
				return retval;
			object[] list = response as object[];
			handleErrorMessage(list);
			foreach (XmlRpcStruct entry in list) {
				TestProject tp = new TestProject(entry);
				retval.Add(tp);
			}
			return retval;
		}

		/// <summary>
		/// get a single Project
		/// </summary>
		/// <param name="projectname"></param>
		/// <returns>a Project or Null</returns>
		public TestProject GetProject(string projectname)
		{
			TestProject result = null;
			stateIsValid();
			object o = proxy.getTestProjectByName(devkey, projectname);
			handleErrorMessage(o);
			if (o is object[]) {
				object[] olist = o as object[];
				result = new TestProject(olist[0] as XmlRpcStruct);
			} else
				result = new TestProject(o as XmlRpcStruct);
			return result;
		}

		/// <summary>
		/// upload an attachment to a test project
		/// </summary>
		/// <param name="executionId"></param>
		/// <param name="filename"></param>
		/// <param name="fileType"></param>
		/// <param name="content"></param>
		/// <param name="title"></param>
		/// <param name="description"></param>
		/// <returns></returns>
		public AttachmentRequestResponse UploadTestProjectAttachment(int executionId, string filename, string fileType, byte[] content, string title = "", string description = "")
		{
			string base64String;
			try {
				base64String = System.Convert.ToBase64String(content, 0, content.Length);
			} catch (System.ArgumentNullException) {
				// System.Console.WriteLine("Binary data array is null.");
				base64String = "";
			}
			stateIsValid();
			object response = proxy.uploadTestProjectAttachment(devkey, executionId, filename, fileType, base64String, title, description);
			handleErrorMessage(response);
			AttachmentRequestResponse r = new AttachmentRequestResponse(response as XmlRpcStruct);
			return r;
		}

		/// <summary>
		/// create a new project
		/// </summary>
		/// <param name="projectname"></param>
		/// <param name="testcasePrefix">prefix for test case ids</param>
		/// <param name="notes"></param>
		/// <returns>a general result</returns>
		public GeneralResult CreateProject(string projectname, string testcasePrefix, string notes = "")
		{
			GeneralResult result = null;
			stateIsValid();
			object o = proxy.createTestProject(devkey, projectname, testcasePrefix, notes);
			handleErrorMessage(o);
			object[] olist = o as object[];
			if (olist != null) {
				result = new GeneralResult(olist[0] as XmlRpcStruct);
			}
			return result;
		}

		#endregion

		#region Test Suite
		/// <summary>
		/// get test suites for a test plan
		/// </summary>
		/// <param name="testplanid"></param>
		/// <returns></returns>
		public List<TestSuite> GetTestSuitesForTestPlan(int testplanid)
		{
			List<TestSuite> result = new List<TestSuite>();
			// empty string means none, otherwise it is name, id combo
			stateIsValid();
			object o = proxy.getTestSuitesForTestPlan(devkey, testplanid);

			handleErrorMessage(o);

			if (o is string)
				return result;
			object[] oList = o as object[];

			if (oList != null) {
				foreach (XmlRpcStruct data in oList)
					result.Add(new TestSuite(data));
			}
			return result;
		}

		/// <summary>
		/// get all top level test suites for a test project
		/// </summary>
		/// <param name="testprojectid"></param>
		/// <returns></returns>
		public List<TestSuite> GetFirstLevelTestSuitesForTestProject(int testprojectid)
		{
			stateIsValid();
			object[] response = proxy.getFirstLevelTestSuitesForTestProject(devkey, testprojectid);
			List<TLErrorMessage> errors = decodeErrors(response);
			List<TestSuite> result = new List<TestSuite>();
			if (errors.Count > 0) {
				if (errors[0].code != 7008)
					// project has no test suites, we return an emptu result
					handleErrorMessage(response);
			} else
				foreach (XmlRpcStruct data in response) {
					result.Add(new TestSuite(data));
				}
			return result;
		}

		public List<TestSuite> GetTestSuitesForTestSuite(int testsuiteid)
		{
			List<TestSuite> Result = new List<TestSuite>();
			stateIsValid();
			object o = proxy.getTestSuitesForTestSuite(devkey, testsuiteid);
			// Testlink returns an empty string if a test suite has no child test suites
			if (o is string)
				return Result;

			// just in case this gets fixed, then this should work.
			if (handleErrorMessage(o, 7008))
				return Result;
			// empty list
			XmlRpcStruct response = o as XmlRpcStruct;
			foreach (XmlRpcStruct data in response.Values) {
				Result.Add(new TestSuite(data));
			}
			return Result;
		}
		/// <summary>
		/// get a test suite by its id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public TestSuite GetTestSuiteById(int id)
		{
			stateIsValid();
			object o = proxy.getTestSuiteByID(devkey, id);
			if (handleErrorMessage(o, 8000))
				return null;
			TestSuite ts = new TestSuite(o as XmlRpcStruct);
			return ts;
		}

		/// <summary>
		/// create a new test suite
		/// </summary>
		/// <param name="testprojectid">id of test project</param>
		/// <param name="testsuitename">Name of this test suite</param>
		/// <param name="details"></param>
		/// <param name="parentId">parent test suite id. Optional</param>
		/// <param name="order">display order with sibling test suites. Optional</param>
		/// <param name="checkduplicatedname">if true, throw an error of a duplicate name exists. Optional, default=true</param>
		/// <returns></returns>
		public GeneralResult CreateTestSuite(int testprojectid, string testsuitename, string details, int parentId = 0, int order = 0, bool checkduplicatedname = true)
		{
			object[] o = null;
			stateIsValid();
			if (parentId == 0)
				o = proxy.createTestSuite(devkey, testprojectid, testsuitename, details, order, checkduplicatedname);
			else
				o = proxy.createTestSuite(devkey, testprojectid, testsuitename, details, parentId, order, checkduplicatedname);
			handleErrorMessage(o);
			foreach (XmlRpcStruct data in o)
				return new GeneralResult(data);
			return null;
		}

		/// <summary>
		/// upload an attachment for a test case
		/// </summary>
		/// <param name="testsuiteid"></param>
		/// <param name="filename"></param>
		/// <param name="fileType"></param>
		/// <param name="content"></param>
		/// <param name="title"></param>
		/// <param name="description"></param>
		/// <returns></returns>
		public AttachmentRequestResponse UploadTestSuiteAttachment(int testsuiteid, string filename, string fileType, byte[] content, string title, string description)
		{
			string base64String;
			try {
				base64String = System.Convert.ToBase64String(content, 0, content.Length);
			} catch (System.ArgumentNullException) {
				// System.Console.WriteLine("Binary data array is null.");
				base64String = "";
			}
			stateIsValid();
			object response = proxy.uploadTestSuiteAttachment(devkey, testsuiteid, filename, fileType, base64String, title, description);
			handleErrorMessage(response);
			AttachmentRequestResponse r = new AttachmentRequestResponse(response as XmlRpcStruct);
			return r;
		}
		#endregion

		#region other
		/// <summary>
		/// basic Ping
		/// </summary>
		/// <returns></returns>
		public string SayHello()
		{
			string hello = proxy.sayHello();
			return hello;
		}

		/// <summary>
		/// Gets info about the API
		/// </summary>
		/// <returns></returns>
		public string about()
		{
			string result = proxy.about();
			return result;
		}
		/// <summary>
		/// check if Developer Key exists
		/// </summary>
		/// <param name="devkey"></param>
		/// <returns>true if key exists</returns>
		public bool checkDevKey(string devkey)
		{
			stateIsValid();
			object o = proxy.checkDevKey(devkey);
			handleErrorMessage(o);

			return (bool)o;
		}
		/// <summary>
		/// check for user id to see whether it exists
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		public bool DoesUserExist(string username)
		{
			stateIsValid();
			object o = proxy.doesUserExist(devkey, username);
			if (handleErrorMessage(o, 10000))
				//10000 means no such user login
				return false;

			return (bool)o;
		}
		#endregion
	}
}
