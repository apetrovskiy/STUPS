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
using CookComputing.XmlRpc;
using System.Collections.Generic;

namespace Meyn.TestLink
{
    /// <summary>
    /// base class for all response classes from the TL Api
    /// </summary>
    public abstract class TL_Data
    {
        /// <summary>
        /// robust convert to int. can take int strings as well as ints 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal int toInt(XmlRpcStruct data, string name)
        {
            if (data.ContainsKey(name))
            {
                int n;
                object val = data[name];
                if (val is string)
                {
                    bool good = int.TryParse((string)val, out n);
                    if (good)
                        return n;
                }
                else if (val is int)
                    return (int)(val);
            }
            return 0;
        }
        /// <summary>
        /// robust convert a data bit to a bool 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal bool? toBool(XmlRpcStruct data, string name)
        {
            if (data.ContainsKey(name))
            {
                object val = data[name];
                if (val is string)
                {
                    bool result;
                    bool good = bool.TryParse(val as string, out result);
                    return result;
                }
                return data[name] as bool?;
            }
            return null;
        }
        /// <summary>
        /// parse an execution status 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal TestCaseResultStatus toExecStatus(XmlRpcStruct data, string name)
        {
            TestCaseResultStatus result = TestCaseResultStatus.undefined;
            if (data.ContainsKey(name))
            {
                char c = toChar(data, name);
                switch (c)
                {
                    case 'f':
                    case 'F': result = TestCaseResultStatus.Fail;
                        break;
                    case 'b':
                    case 'B': result = TestCaseResultStatus.Blocked;
                        break;
                    case 'p':
                    case 'P': result = TestCaseResultStatus.Pass;
                        break;
                }
            }
            return result;
        }
        /// <summary>
        ///  robust convert a date string
        /// </summary>
        /// <param name="data">key value dictionary</param>
        /// <param name="name">name of field to use</param>
        /// <returns></returns>
        internal DateTime toDate(XmlRpcStruct data, string name)
        {
            if (data.ContainsKey(name))
            {
                DateTime n;
                bool good = DateTime.TryParse((string)data[name], out n);
                if (good)
                    return n;
            }
            return DateTime.MinValue;
        }
        /// <summary>
        /// convert a data value to a single char
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal char toChar(XmlRpcStruct data, string name)
        {
            if (data.ContainsKey(name) && (data[name] is string))
            {
                string s = (string)(data[name]);
                return s[0];
            }
            return '\x00';
        }
    }

    /// <summary>
    /// package an the error message returned by the API
    /// </summary>
    public class TLErrorMessage : TL_Data
    {
        /// <summary>
        /// the testlink error code. See testlink API documentation.
        /// </summary>
        public readonly int code;
        /// <summary>
        /// the testlink error message returned
        /// </summary>
        public readonly string message;
        internal TLErrorMessage(XmlRpcStruct data)
        {
            code = toInt(data,"code");
            message = (string)data["message"];
        }
    }


    /// <summary>
    /// The object returned from Testlinkt when requesting an attachment
    /// </summary>
    public class Attachment: TL_Data
    {
        public readonly int id;
        public readonly string file_type;
        public readonly string name;
        public readonly string title;
        public readonly DateTime date_added;
        public readonly byte[] content;

        internal Attachment(XmlRpcStruct data)
        {
            id = toInt(data, "id");
            file_type = (string)data["file_type"];
            name = (string)data["name"];
            title = (string)data["title"];
            date_added = toDate(data, "date_added");
            string s = (string)data["content"];
            content = Convert.FromBase64String(s);
        }
    }
    /// <summary>
    /// Build information returned by Testlink
    /// </summary>
    public class Build : TL_Data
    {
        /// <summary>
        /// build ID
        /// </summary>
        public readonly int id;
        /// <summary>
        /// true if the build is active
        /// </summary>
        public readonly bool active;
        /// <summary>
        /// build name
        /// </summary>
        public readonly string name;
        /// <summary>
        /// any build notes
        /// </summary>
        public readonly string notes;
        /// <summary>
        /// the test plan the build is associated with
        /// </summary>
        public readonly int testplan_id;
        /// <summary>
        /// true if the build is currently open
        /// </summary>
        public readonly bool is_open;
        internal Build(XmlRpcStruct data)
        {
            id = toInt(data, "id");
            active = toInt(data, "active") == 1;
            name = (string)data["name"];
            notes = (string)data["notes"];
            testplan_id = toInt(data, "testplan_id");
            is_open = toInt(data, "is_open") == 1;
        }
    }

   

    /// <summary>
    /// test cases as they are returned from a test plan
    /// </summary>
    /// <remarks>This is different from TestCase as it returns additional info from the testplan. 
    /// Maybe this should be refactored with a testplandetails subclass</remarks>
    public class TestCaseFromTestPlan : TL_Data
    {
        /// <summary>
        /// marks the test case as active
        /// </summary>
        public readonly  bool active;
        /// <summary>
        /// the build id the test case is assigned to
        /// </summary>
        public readonly int assigned_build_id;

        public readonly int assigner_id;
        /// <summary>
        /// 
        /// </summary>
        public readonly int executed;
        public readonly string execution_notes;
        public readonly int execution_order;
        /// <summary>
        /// timestamp when it was executed. blank if not yet executeed
        /// </summary>
        public readonly string execution_ts;
        /// <summary>
        /// actual execution type on last run 1=manual, 2 = automatic
        /// </summary>
        public string execution_run_type;
        /// <summary>
        /// the execution type set in the test case  1=manual, 2 = automatic
        /// </summary>
        public readonly int execution_type;
        public readonly int exec_id;
        /// <summary>
        /// build id where it was last executed on
        /// </summary>
        public readonly int exec_on_build;
        /// <summary>
        /// test plan id where it was last executed
        /// </summary>
        public readonly int exec_on_tplan;
        /// <summary>
        /// the last execution status
        /// </summary>
        public readonly TestCaseResultStatus exec_status;
        /// <summary>
        /// the id displayed on the UI, but without hte prefix
        /// </summary>
        public readonly string external_id;
        public readonly int importance;
        public readonly int feature_id;
        public readonly DateTime linked_ts;
        public readonly int linked_by;
        public readonly string name;
        public readonly int platform_id;
        public string platform_name;
        /// <summary>
        /// //the priority assigned in the test case(?)
        /// </summary>
        public int priority;
        /// <summary>
        /// not clear what this is. It is NOT the same as the status in the other test case classes
        /// </summary>
        public string status;
       
        public string summary;
        /// <summary>
        /// 
        /// </summary>
        public int tcversion_number;
        public int tcversion_id;
        public int tc_id;
        public int tester_id;
        public int testsuite_id;
        public string tsuite_name;
        public string type;
        public int user_id;
        /// <summary>
        /// urgency set in test plan
        /// </summary>
        public int urgency;
        public int version;
        public int z;

        internal TestCaseFromTestPlan(XmlRpcStruct data)
        {
            active = int.Parse((string)data["active"]) == 1;
            name = (string)data["name"];
            tsuite_name = (string)data["tsuite_name"];
            z = toInt(data, "z");
            type = (string)data["type"];
            execution_order = toInt(data, "execution_order");
            exec_id = toInt(data, "exec_id");
            tc_id = toInt(data, "tc_id");
            tcversion_number = toInt(data, "tcversion_number");
            status = (string)data["status"];
            external_id = (string)data["external_id"];
            exec_status = toExecStatus(data, "exec_status");
            exec_on_tplan = toInt(data, "exec_on_tplan");
            executed = toInt(data, "executed");
            feature_id = toInt(data, "feature_id");
            assigner_id = toInt(data, "assigner_id");
            user_id = toInt(data, "user_id");
            active = toInt(data, "active") == 1;
            version = toInt(data, "version");
            testsuite_id = toInt(data, "testsuite_id");
            tcversion_id = toInt(data, "tcversion_id");
            //steps = (string)data["steps"];
            //expected_results = (string)data["expected_results"];
            summary = (string)data["summary"];
            execution_type = toInt(data, "execution_type");
            platform_id = toInt(data, "platform_id");
            platform_name = (string)data["platform_name"];
            linked_ts = toDate(data, "linked_ts");
            linked_by = toInt(data, "linked_by");
            importance = toInt(data, "importance");
            execution_run_type = (string)data["execution_run_type"];
            execution_ts = (string)data["execution_ts"];
            tester_id = toInt(data, "tester_id");
            execution_notes = (string)data["execution_notes"];
            exec_on_build = toInt(data, "exec_on_build");
            assigned_build_id = toInt(data,"assigned_build_id");
            urgency = toInt(data, "urgency");
            priority = toInt(data, "priority");
        }
        /// <summary>
        /// This is used for the call GetTestCasesForTestPlan
        /// using the returned list from TestLink, generate a list of data
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<TestCaseFromTestPlan> GenerateFromResponse(XmlRpcStruct list)
        {
            List<TestCaseFromTestPlan> result = new List<TestCaseFromTestPlan>();
            if (list != null)
            {
                foreach (object o in list.Values)
                {
                     TestCaseFromTestPlan tc = null;
                     if (o is XmlRpcStruct)
                     {
                         XmlRpcStruct list2 = o as XmlRpcStruct;
                         foreach (object o2 in list2.Values)
                         {
                             tc = new TestCaseFromTestPlan(o2 as XmlRpcStruct);
                             result.Add(tc);
                         }
                     }
                     else
                     {
                         object[] olist = o as object[];
                         tc = new TestCaseFromTestPlan(olist[0] as XmlRpcStruct);
                         result.Add(tc);
                     }
                }
            }
            return result;
        }
    }

    /// <summary>
    /// test case as it is retrieved from testsuite
    /// </summary>
    public class TestCaseFromTestSuite : TL_Data
    {
        /// <summary>
        /// test case id
        /// </summary>
        public readonly int id;

        public readonly int parent_id;
        public readonly int node_type_id;
        public readonly int node_order;
        public readonly string node_table;
        public readonly string name;
        public readonly bool active; 
        /// <summary>
        /// the version of the test case, starts with 1
        /// </summary>
        public readonly int version;        
        /// <summary>
        /// the internal id of this testcase version
        /// </summary>
        public readonly int tcversion_id;
        /// <summary>
        /// not clear what this represents
        /// </summary>
        public readonly string layout;
        /// <summary>
        /// not clear in its meaning
        /// </summary>
        public readonly int status;
        public readonly string summary;
        public readonly string preconditions;
       
        /// <summary>
        /// the id that is displayed on the UI, sans the prefix
        /// </summary>
        public readonly string external_id; 
        /// <summary>
        /// the id of the owning testsuite
        /// </summary>
        public readonly int testSuite_id;
        /// <summary>
        /// unknown purpose
        /// </summary>
        public readonly bool is_open;
        /// <summary>
        /// 
        /// </summary>
        public readonly DateTime modification_ts;
        /// <summary>
        /// 
        /// </summary>
        public readonly int updater_id;
        /// <summary>
        /// manual or automatic
        /// </summary>
        public readonly  int execution_type;
        public readonly string details;  
        public readonly int author_id;
        public readonly DateTime creation_ts;
        public readonly int importance;
        internal TestCaseFromTestSuite(XmlRpcStruct data)
        {
            active = int.Parse((string)data["active"]) == 1;
            id = toInt(data, "id");
            name = (string)data["name"];
            version = toInt(data, "version");
            tcversion_id = toInt(data, "tcversion_id");
            //steps = (string)data["steps"];
            //expected_results = (string)data["expected_results"];
            external_id = (string)data["tc_external_id"];
            testSuite_id = toInt(data, "parent_id");
            is_open = int.Parse((string)data["is_open"]) == 1;
            modification_ts = toDate(data, "modification_ts");
            updater_id = toInt(data, "updater_id");
            execution_type = toInt(data, "execution_type");
            summary = (string)data["summary"];
            if (data.ContainsKey("details"))
                details = (string)data["details"];
            else
                details = "";
            author_id = toInt(data, "author_id");
            creation_ts = toDate(data, "creation_ts");
            importance = toInt(data, "importance");
            parent_id = toInt(data, "parent_id");
            node_type_id = toInt(data, "node_type_id");
            node_order = toInt(data, "node_order");
            node_table = (string)data["node_table"];
            layout = (string)data["layout"];
            status = toInt(data, "status");
            preconditions = (string)data["preconditions"];
        }
    }


      /// <summary>
    /// test cases as they are returned from the getTestCase API call
    /// </summary>
    /// <remarks>This is different from other calls that return TestCases </remarks>

    public class TestCase : TL_Data
    {
        public readonly int id;
        public readonly string externalid;
        public readonly string updater_login;
        public readonly string author_login;
        public readonly string name;
        public readonly int node_order;
        public readonly int testsuite_id;
        public readonly int testcase_id;
        public readonly int version;
        public readonly string layout;
        public readonly int status;
        public readonly string summary;
        public readonly string preconditions;
        public readonly int importance;
        public readonly int author_id;
        public readonly int updater_id;
        public readonly DateTime creation_ts;
        public readonly DateTime modification_ts;
        public readonly bool active;
        public readonly bool is_open;
        public readonly int execution_type;
        public readonly string author_first_name;
        public readonly string author_last_name;
        public readonly string updater_first_name;
        public readonly string updater_last_name;
        public readonly List<TestStep> steps;


        internal TestCase(XmlRpcStruct data)
        {
            active = int.Parse((string)data["active"]) == 1;
            externalid = (string)data["tc_external_id"];
            id = toInt(data, "id");
            updater_login = (string)data["updater_login"];
            author_login = (string)data["author_login"];
            name = (string)data["name"];
            node_order = toInt(data, "node_order");
            testsuite_id = toInt(data, "testsuite_id");
            testcase_id = toInt(data, "testcase_id");
            version = toInt(data, "version");
            layout = (string)data["layout"];
            status = toInt(data, "status");
            summary = (string)data["summary"];
            preconditions = (string)data["preconditions"];
            importance = toInt(data, "importance");
            author_id = toInt(data, "author_id");
            updater_id = toInt(data, "updater_id");
            modification_ts = toDate(data, "modification_ts");
            creation_ts = toDate(data, "creation_ts");
            is_open = int.Parse((string)data["is_open"]) == 1;
            execution_type = toInt(data, "execution_type");
            author_first_name = (string)data["author_first_name"];
            author_last_name = (string)data["author_last_name"];
            updater_first_name = (string)data["updater_first_name"];
            updater_last_name = (string)data["updater_last_name"];
            steps = new List<TestStep>();
            XmlRpcStruct[] stepData = data["steps"] as XmlRpcStruct[];
            if (stepData != null)
                foreach (XmlRpcStruct aStepDatum in stepData)
                    steps.Add(new TestStep(aStepDatum));
            
        }
    }

    /// <summary>
    /// represent a single test step in a test case
    /// 
    /// </summary>
    public class TestStep : TL_Data
    {
        /// <summary>
        /// interenal primary key. 
        /// </summary>
        public readonly int id;
        /// <summary>
        /// step number. Starts at 1
        /// </summary>
        public readonly int step_number;
        /// <summary>
        /// string describing the actions
        /// </summary>
        public readonly string actions;
        /// <summary>
        ///  string desribing the expected result in this step
        /// </summary>
        public readonly string expected_results;
        /// <summary>
        /// flag whether this step is active
        /// </summary>
        public readonly bool active;
        /// <summary>
        /// 1=manual or 2=automated
        /// </summary>
        public readonly int execution_type;
        /// <summary>
        /// constructor used by the XML Rpc return
        /// </summary>
        /// <param name="data"></param>
        internal TestStep(XmlRpcStruct data)
        {
            id = toInt(data, "id");
            step_number = toInt(data, "step_number");
            actions = (string)data["actions"];
            expected_results = (string)data["expected_results"];
            active = toInt(data, "active") == 1;
            execution_type = toInt(data, "execution_type");
        }
        /// <summary>
        /// constructor used when defining new steps when creating testcases
        /// </summary>
        /// <param name="stepNr">sequential id, start with 1</param>
        /// <param name="actions">formatted text, use html style text format tags</param>
        /// <param name="expectedResult">formatted text, use html style text format tags</param>
        /// <param name="isActive">set to true</param>
        /// <param name="executionType">1=manual, 2=automatic</param>
        public TestStep(int stepNr, string actions, string expectedResult, bool isActive, int executionType)
        {
            step_number = stepNr;
            this.actions = actions;
            expected_results = expectedResult;
            active = isActive;
            execution_type = executionType;
        }
    }

    /// <summary>
    /// returned when creating new TestProjects, TestCases, projects etc
    /// </summary>
    public class GeneralResult : TL_Data
    {
        /// <summary>
        /// the name of the operation carried out
        /// </summary>
        public string operation;
        /// <summary>
        /// a status. True means good
        /// </summary>
           public bool status;
        /// <summary>
        /// id of an object involved in the operation. e.g. test case id
        /// </summary>
        public int id;
        /// <summary>
        /// Any potential additional information
        /// </summary>
        public AdditionalInfo additionalInfo;
        /// <summary>
        /// the message returned by Testlink
        /// </summary>
        public string message;
        /// <summary>
        /// used by the Exporter class
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        public GeneralResult(string message, bool status)
        {
            this.message = message;
            this.status = status;
        }
        internal GeneralResult(XmlRpcStruct data)
        {
            operation = (string)data["operation"];
            status = (bool)(data["status"]);
            id = toInt(data, "id");
            message = (string)data["message"];
            if ((data.ContainsKey("additionalInfo") &&
              (data["additionalInfo"] is XmlRpcStruct)))
                additionalInfo = new AdditionalInfo(data["additionalInfo"] as XmlRpcStruct);
            else
                additionalInfo = null;         
        }
        /// <summary>
        /// conbstructor used to represent an empty response
        /// </summary>
        public GeneralResult()
        {
            status = false;
            message = "no response from server";
        }
    }
    /// <summary>
    /// Additional Info is provided in some cases when objects are created.
    /// <see cref="GeneralResult"/>
    /// </summary>
    public class AdditionalInfo : TL_Data
    {
        /// <summary>
        /// new namee given
        /// </summary>
        public readonly string new_name; 
        /// <summary>
        /// true means good
        /// </summary>
        public readonly bool status_ok; 
        /// <summary>
        /// extra message, e.g."Created new version 2"    
        /// </summary>
        public readonly string msg; 
        /// <summary>
        /// external id if used
        /// </summary>
        public readonly int external_id; //    "5"    
        /// <summary>
        /// internal id
        /// </summary>
        public readonly int id; //    1313    
        /// <summary>
        /// version number in test cases
        /// </summary>
        public readonly int version_number; //    
        /// <summary>
        /// true if a duplicate exists
        /// </summary>
        public readonly bool? has_duplicate; 
        /// <summary>
        /// constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal AdditionalInfo(XmlRpcStruct data)
        {
            new_name = (string)data["new_name"];
            status_ok = toInt(data, "status_ok") == 1;
            msg = (string)data["msg"];
            id = toInt(data, "id");
            external_id = toInt(data, "external_id");
            version_number = toInt(data, "version_number");
            has_duplicate = toBool(data, "has_duplicate");
        }
    }
    /// <summary>
    /// represent a folder in the test specification tree
    /// 
    /// </summary>
    public class TestSuite : TL_Data
    {
        /// <summary>
        /// internal primary key
        /// </summary>
        public readonly int id;
        /// <summary>
        /// name of test suite
        /// </summary>
        public readonly string name;
        /// <summary>
        /// foreign key to parent
        /// </summary>
        public readonly int parentId;
        /// <summary>
        /// internal value 
        /// </summary>
        public readonly int nodeTypeId;
        /// <summary>
        /// sequence id for ordering folders in tree
        /// </summary>
        public readonly int nodeOrder;


        /// <summary>
        /// constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal TestSuite(XmlRpcStruct data)
        {
            name = (string)data["name"];
            id = toInt(data, "id");
            parentId = toInt(data, "parent_id");
            nodeTypeId = toInt(data, "node_type_id");
            nodeOrder = toInt(data, "node_order");
        }
    }

    /// <summary>
    /// Represent the recorded outcome of a test case execution.
    /// </summary>
    public class ExecutionResult : TL_Data
    {
        /// <summary>
        /// internal id
        /// </summary>
        public readonly int id;
        /// <summary>
        /// timestamp of execution
        /// </summary>
        public readonly DateTime execution_ts;  
        /// <summary>
        /// execution type, 1=manual, 2=automatic
        /// </summary>
        public readonly int execution_type;      
        /// <summary>
        /// id of the build this was run against
        /// </summary>
        public readonly int build_id;        
        /// <summary>
        /// id of testplan
        /// </summary>
        public readonly int testplan_id;       
        /// <summary>
        /// version id of test case
        /// </summary>
        public readonly int tcversion_id;      
        /// <summary>
        /// notes provided 
        /// </summary>
        public readonly string notes;           
        /// <summary>
        /// id of tester
        /// </summary>
        public readonly int tester_id;           
        /// <summary>
        /// external version number
        /// </summary>
        public readonly int tcversion_number;  
        /// <summary>
        /// status, p=pass, f=fail, b=blocked
        /// </summary>
        public readonly TestCaseResultStatus status;         
        /// <summary>
        /// constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal ExecutionResult(XmlRpcStruct data)
        {
            id = toInt(data, "id");
            notes = (string)data["notes"];
            execution_ts = toDate(data, "execution_ts");
            execution_type = toInt(data, "execution_type");
            build_id = toInt(data, "build_id");
            tcversion_id = toInt(data, "tcversion_id");
            tcversion_number = toInt(data, "tcversion_number");
            status = toExecStatus(data, "status");
        }

 
    }
    /// <summary>
    /// this is returned as a response to an attachment request
    /// </summary>
    public class AttachmentRequestResponse : TL_Data
    {
        /// <summary>
        /// the name of the table containing hte event this is attached to (an execution for instance)
        /// </summary>
        public readonly string linkedTableName;
        /// <summary>
        /// the foreign key
        /// </summary>
        public readonly int foreignKeyId = 0;
        /// <summary>
        /// title of the attachment
        /// </summary>
        public readonly string title;
        /// <summary>
        /// description 
        /// </summary>
        public readonly string description;
        /// <summary>
        /// filename 
        /// </summary>
        public readonly string file_name;
        /// <summary>
        /// size in bytes
        /// </summary>
        public readonly int size;
        /// <summary>
        /// mime type
        /// </summary>
        public readonly string file_type;
        /// <summary>
        /// constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal AttachmentRequestResponse(XmlRpcStruct data)
        {
            foreignKeyId = toInt(data, "fk_id");
            linkedTableName = (string)data["fk_table"];
            title = (string)data[ "title"];
            description = (string)data["description"];
            file_name = (string)data["file_name"];
            file_type = (string)data["file_type"];
            size = toInt(data, "file_size");
            
        }
    }
    /// <summary>
    /// represent a test project object in testlink
    /// </summary>
    public class TestProject : TL_Data
    {
        /// <summary>
        /// internal id
        /// </summary>
        public readonly int id;
        /// <summary>
        /// notes
        /// </summary>
        public readonly string notes;
        /// <summary>
        /// 
        /// </summary>
        public readonly string color;
        /// <summary>
        /// 
        /// </summary>
        public readonly bool active;
        /// <summary>
        /// true of requirements feature is enabled
        /// </summary>
        public readonly bool option_reqs;
        /// <summary>
        /// true if priority feature is enabled
        /// </summary>
        public readonly bool option_priority;
        /// <summary>
        /// string prefix for test cases
        /// </summary>
        public readonly string prefix;
        /// <summary>
        /// 
        /// </summary>
        public readonly  int tc_counter;
        /// <summary>
        /// true if automation is enabled
        /// </summary>
        public readonly bool option_automation;
        /// <summary>
        /// true of inventory is enabled
        /// </summary>
        public readonly bool option_inventory;
        /// <summary>
        /// project name
        /// </summary>
        public readonly string name;
        /// <summary>
        /// constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal TestProject(XmlRpcStruct data)
        {
            id = toInt(data, "id");
            notes = (string)data["notes"];
            color = (string)data["color"];
            active = toInt(data, "active") == 1;
            //changed option encoding sinc V 1.9
            XmlRpcStruct opt = data["opt"] as XmlRpcStruct;
            option_reqs = (int)opt["requirementsEnabled"] == 1;
            option_priority = (int)opt["testPriorityEnabled"] == 1;
            option_automation = (int)opt["automationEnabled"] == 1;
            option_inventory = (int)opt["inventoryEnabled"] == 1;
            prefix = (string)data["prefix"];
            tc_counter = toInt(data, "tc_counter");
            name = (string)data["name"];
        }
    }

    /// <summary>
    /// represent a test plan
    /// </summary>
    public class TestPlan : TL_Data
    {
        /// <summary>
        /// True if thest plan is currently active
        /// </summary>
        public readonly bool active;
        /// <summary>
        /// 
        /// </summary>
        public readonly bool open;
        /// <summary>
        /// 
        /// </summary>
        public readonly bool is_public;
        /// <summary>
        /// 
        /// </summary>
        public readonly string name;
        /// <summary>
        /// foreign key to test project
        /// </summary>
        public readonly int testproject_id;
        /// <summary>
        /// 
        /// </summary>
        public readonly string notes;
        /// <summary>
        /// primary key
        /// </summary>
        public readonly int id;
        /// <summary>
        /// constructor used by XMLRPC interface on decoding the function return
        /// </summary>
        /// <param name="data">data returned by Testlink</param>
        internal TestPlan(XmlRpcStruct data)
        {
             active = toInt(data, "active") == 1;
            id = toInt(data, "id");
            name = (string)data["name"];
            notes = (string)data["notes"];
            testproject_id = toInt(data, "testproject_id");
            open = toInt(data, "is_open") == 1;
            is_public = toInt(data, "is_public") == 1;
        }
    }
    /// <summary>
    /// view of test case identifiers returned by the api call GetTestCaseIdByName
    /// </summary>
    public class TestCaseId : TL_Data
    {
        /// <summary>
        /// the externally visible id without the prefix
        /// </summary>
        public readonly int tc_external_id;
        /// <summary>
        /// 
        /// </summary>
        public readonly string name;
        /// <summary>
        /// that would be the id of the owning item in the nodes hierarchy table (i.e. the folder id)
        /// </summary>
        public readonly int parent_id;
        /// <summary>
        /// test case internal id
        /// </summary>
        public readonly int id;
        /// <summary>
        /// name of the test suite that contains the test case
        /// </summary>
        public readonly string tsuite_name;
        internal TestCaseId(XmlRpcStruct data)
        {
            parent_id = toInt(data, "parent_id");
            tc_external_id = toInt(data, "tc_external_id");
            id = toInt(data, "id");
            name = (string)data["name"];
            tsuite_name = (string)data["tsuite_name"];
        }
    }
    /// <summary>
    /// Represents a platform against which a test result can be recorded
    /// </summary>
    public class TestPlatform : TL_Data
    {
        /// <summary>
        /// primary key
        /// </summary>
        public readonly int id;
        /// <summary>
        /// 
        /// </summary>
        public readonly string name;
        /// <summary>
        /// 
        /// </summary>
        public readonly string notes;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        internal TestPlatform(XmlRpcStruct data)
        {
            id = toInt(data, "id");
            name = (string)data["name"];
            notes = (string)data["notes"];
        }        
    }
    /// <summary>
    /// summary results for the execution of a testplan.
    /// 
    /// </summary>
    public class TestPlanTotal : TL_Data
    {
        /// <summary>
        /// category name
        /// </summary>
        public readonly string Type = "";
        /// <summary>
        /// category value
        /// </summary>
        public readonly string Name = "";
        /// <summary>
        /// total test cases that are covered in this test plan
        /// </summary>
        public readonly int Total_tc;
        /// <summary>
        /// Dictionary with execution totals
        /// </summary>
        public readonly Dictionary<string, int> Details = new Dictionary<string, int>();

        internal TestPlanTotal(XmlRpcStruct data)
        {
            Total_tc = toInt(data, "total_tc");
            if (data.ContainsKey("type"))
                Type = (string)data["type"];    
            if (data.ContainsKey("name"))
                Name = (string)data["name"];
          
            XmlRpcStruct xdetails = data["details"] as XmlRpcStruct;

            foreach (string key in xdetails.Keys)
            {
                XmlRpcStruct val = xdetails[key] as XmlRpcStruct;
                int qty = toInt(val,"qty");
                Details.Add(key, qty);
            }
        }        

    }
}
