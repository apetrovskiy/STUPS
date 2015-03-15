/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/16/2012
 * Time: 9:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    using Autofac;
    using Autofac.Builder;
    using Tmx;
    using Meyn.TestLink;
    using CookComputing.XmlRpc;
    
    /// <summary>
    /// Description of FakeTestLinkFactory.
    /// </summary>
    public static class FakeTestLinkFactory
    {
        internal static string TestLinkApiKeyRight = "56238b86d143acaef5b2175ce840e132"; //"aaa"; // "56238b86d143acaef5b2175ce840e132";
        internal static string TestLinkApiKeyWrong = "wrong api key";
        internal static string TestLinkUrlRight = "http://1.2.3.4/testlink/lib/api/xmlrpc.php";
        internal static string TestLinkUrlWrong = "wrong url";
        
        static System.Random generator = new Random();
        
        static Mock<ITestLinkExtra> _getTestLinkMock(string apiKey, string url)
        {
            var testLinkMock = new Mock<TestLink>(apiKey, url).As<ITestLinkExtra>();
            
            // checking the api key via TestLink.checkDevKey(string)
            testLinkMock.Setup(t => t.checkDevKey(TestLinkApiKeyRight)).Returns(true);
            testLinkMock.Setup(t => t.checkDevKey(TestLinkApiKeyWrong))
                .Throws(new TestLinkException("2000:(checkDevKey) - Can not authenticate client: invalid developer key"));
            testLinkMock.Setup(t => t.checkDevKey(string.Empty))
                .Throws(new TestLinkException("Devkey is empty. You must supply a development key"));
            
            // checking the url via TestLink.SayHello()
            if (TestLinkUrlRight == url) {
                testLinkMock.Setup(t => t.SayHello()).Returns(() => string.Empty);
            } else if (TestLinkUrlWrong == url) {
                testLinkMock.Setup(t => t.SayHello())
                    .Throws(new UriFormatException("Invalid URI: The format of the URI could not be determined."));
            } else if (string.Empty == url) {
                testLinkMock.Setup(t => t.SayHello())
                    .Throws(new XmlRpcMissingUrl("Proxy XmlRpcUrl attribute or Url property not set."));
            }
            
            
            
//            var builder = new ContainerBuilder();
//            builder.RegisterType<ITestLinkExtra>();
//            var container = builder.Build(ContainerBuildOptions.Default);
//            TestLink testLink = container.Resolve<TestLink>();
//            //testLink.checkDevKey().
            
            
            return testLinkMock;
            
        }
        
        static Mock<ITestLinkExtra> _getTestLinkMock()
        {
            var testLinkMock =
                _getTestLinkMock(
                    TestLinkApiKeyRight,
                    TestLinkUrlRight);
            
            return testLinkMock;
        }
        
        public static ITestLinkExtra GetTestLink(string apiKey, string url)
        {
            // constructor
            var testLinkMock = _getTestLinkMock(apiKey, url);
            
#region the list
            // methods
            
            // about();
            // addTestCaseToTestPlan()
            
            // CreateBuild()
            //testLinkMock.Setup(t => 
            
            // CreateProject()
            //testLinkMock.Setup(t => 
            
            // CreateTestCase()
            //testLinkMock.Setup(t => 
            
            // CreateTestPlan()
            //testLinkMock.Setup(t => 
            
            // CreateTestSuite()
            //testLinkMock.Setup(t => 
            
            // DeleteExecution()
            // DoesUserExist()
            // GetBuildsForTestPlan()
            // GetFirstLevelTestSuitesForTestProject()
            // GetLastExecutionResult()
            
            // GetLatestBuildForTestPlan()
            //testLinkMock.Setup(t => 
            
            // GetProject()
            //testLinkMock.Setup(t => 
            
            // GetProjects()
            //testLinkMock.Setup(t => t.GetProjects()).Returns
            
            
            // GetProjectTestPlans()
            //testLinkMock.Setup(t => 
            
            // GetTestCase()
            //testLinkMock.Setup(t => 
            
            // GetTestCaseAttachments()
            //testLinkMock.Setup(t => 
            
            // GetTestCaseIDByName()
            // GetTestCaseIdsForTestSuite()
            
            // GetTestCasesForTestPlan()
            //testLinkMock.Setup(t => 
            
            // GetTestCasesForTestSuite()
            //testLinkMock.Setup(t => 
            
            // getTestPlanByName()
            //testLinkMock.Setup(t => 
            
            // GetTestPlanPlatforms()
            // GetTestSuiteById()
            
            // GetTestSuitesForTestPlan()
            //testLinkMock.Setup(t => 
            
            // GetTestSuitesForTestSuite()
            //testLinkMock.Setup(t => 
            
            // GetTotalsForTestPlan()
            //testLinkMock.Setup(t => 
            
            // ReportTCResult()
            //testLinkMock.Setup(t => 
            
            // UploadExecutionAttachment()
            
            // UploadTestCaseAttachment()
            //testLinkMock.Setup(t => 
            
            // UploadTestProjectAttachment()
            // UploadTestSuiteAttachment()
            
            // properties
            // LastRequest
            // LastResponse
#endregion the list

            return testLinkMock.Object;
        }
        
        public static ITestLinkExtra GetTestLink()
        {
            ITestLinkExtra result =
                GetTestLink(TestLinkApiKeyRight, TestLinkUrlRight);
            return result;
        }
        
        public static Mock<ITestLinkExtra> _getTestLinkMockWithProjects(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects)
        {
            var testLinkMock = _getTestLinkMock();
            
            testLinkMock.Setup(t => t.GetProjects()).Returns(listOfProjects);
            testLinkMock.Setup(t => t.GetProject(It.IsAny<string>())).Returns((string s) => listOfProjects.Find(item => item.name == s));
            // 20130202
            // testLinkMock.Setup(t => t.GetProjects()).Returns((string id) => listOfProjects);
            
            return testLinkMock;
        }
        
        public static ITestLinkExtra GetTestLinkWithProjects(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects)
        {
            var testLinkMock = _getTestLinkMockWithProjects(listOfProjects);
            
            return testLinkMock.Object;
        }
        
        
        public static Mock<ITestLinkExtra> _getTestLinkMockWithTestPlans(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects,
           System.Collections.Generic.List<Meyn.TestLink.TestPlan> listOfTestPlans,
           System.Collections.Generic.List<Meyn.TestLink.TestPlatform> listOfTestPlatforms,
           System.Collections.Generic.List<Meyn.TestLink.TestPlanTotal> listOfTestPlanTotals)
        {
            var testLinkMock = _getTestLinkMockWithProjects(listOfProjects);
            
            testLinkMock.Setup(t => t.GetProjectTestPlans(It.IsAny<int>()))
                .Returns((int prjId) => listOfTestPlans.FindAll(tPlan => tPlan.testproject_id == prjId));
            
            testLinkMock.Setup(t => t.getTestPlanByName(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string prjName, string planName) => listOfTestPlans
                         .FindAll(plan => plan.name == planName && 
                                  plan.testproject_id == (listOfProjects.Find(prj => prj.name == prjName)).id)[0]);
            
            if (null != listOfTestPlatforms) {
                //testLinkMock.Setup(t => t.GetTestPlanPlatforms(It.IsAny<int>())).Returns((int tpId) => listOfTestPlatforms.FindAll(platform => platform.id > 0)); // all
                testLinkMock.Setup(t => t.GetTestPlanPlatforms(It.IsAny<int>())).Returns(() => listOfTestPlatforms); // all
            }
            
            if (null != listOfTestPlanTotals) {
                testLinkMock.Setup(t => t.GetTotalsForTestPlan(It.IsAny<int>())).Returns(() => listOfTestPlanTotals); // all
            }
            
            return testLinkMock;
        }
        
        public static ITestLinkExtra GetTestLinkWithTestPlans(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects,
           System.Collections.Generic.List<Meyn.TestLink.TestPlan> listOfTestPlans,
           System.Collections.Generic.List<Meyn.TestLink.TestPlatform> listOfTestPlatforms,
           System.Collections.Generic.List<Meyn.TestLink.TestPlanTotal> listOfTestPlanTotals)
        {
            var testLinkMock = _getTestLinkMockWithTestPlans(listOfProjects, listOfTestPlans, listOfTestPlatforms, listOfTestPlanTotals);
            
            return testLinkMock.Object;
        }
        
        public static Mock<ITestLinkExtra> _getTestLinkMockWithBuilds(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects,
           System.Collections.Generic.List<Meyn.TestLink.TestPlan> listOfTestPlans,
           System.Collections.Generic.List<Meyn.TestLink.TestPlatform> listOfTestPlatforms,
           System.Collections.Generic.List<Meyn.TestLink.TestPlanTotal> listOfTestPlanTotals,
           System.Collections.Generic.List<Meyn.TestLink.Build> listOfBuilds)
        {
        
            var testLinkMock = _getTestLinkMockWithTestPlans(listOfProjects, listOfTestPlans, listOfTestPlatforms, listOfTestPlanTotals);

            testLinkMock.Setup(t => t.GetBuildsForTestPlan(It.IsAny<int>()))
                .Returns((int tPlanId) => listOfBuilds.FindAll(build => build.testplan_id == tPlanId));
            
            testLinkMock.Setup(t => t.GetLatestBuildForTestPlan(It.IsAny<int>()))
                .Returns((int tplanid) => listOfBuilds.Find(build => build.testplan_id == tplanid)); //there's no date for a build
                                                            
            
            return testLinkMock;
        }
        
        public static ITestLinkExtra GetTestLinkWithTestBuilds(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects,
           System.Collections.Generic.List<Meyn.TestLink.TestPlan> listOfTestPlans,
           System.Collections.Generic.List<Meyn.TestLink.TestPlatform> listOfTestPlatforms,
           System.Collections.Generic.List<Meyn.TestLink.TestPlanTotal> listOfTestPlanTotals,
           System.Collections.Generic.List<Meyn.TestLink.Build> listOfBuilds)
        {
            var testLinkMock = _getTestLinkMockWithBuilds(listOfProjects, listOfTestPlans, listOfTestPlatforms, listOfTestPlanTotals, listOfBuilds);
            
            return testLinkMock.Object;
        }
        
        public static Mock<ITestLinkExtra> _getTestLinkMockWithTestSuites(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects,
           System.Collections.Generic.List<Meyn.TestLink.TestPlan> listOfTestPlans,
           System.Collections.Generic.List<Meyn.TestLink.TestPlatform> listOfTestPlatforms,
           System.Collections.Generic.List<Meyn.TestLink.TestPlanTotal> listOfTestPlanTotals,
           System.Collections.Generic.List<Meyn.TestLink.Build> listOfBuilds,
           System.Collections.Generic.List<Meyn.TestLink.TestSuite> listOfTestSuites)
        {
            var testLinkMock = _getTestLinkMockWithBuilds(listOfProjects, listOfTestPlans, listOfTestPlatforms, listOfTestPlanTotals, listOfBuilds);
            
            testLinkMock.Setup(t => t.GetTestSuitesForTestPlan(It.IsAny<int>())).Returns(() => listOfTestSuites);
            
            //testLinkMock.Setup(t => t.CreateTestSuite
            
            testLinkMock.Setup(t => t.GetFirstLevelTestSuitesForTestProject(It.IsAny<int>())).Returns(() => listOfTestSuites);
            
            //testLinkMock.Setup(t => t.GetTestCasesForTestSuite
            
            testLinkMock.Setup(t => t.GetTestSuiteById(It.IsAny<int>())).Returns((int id) => listOfTestSuites.Find(ts => ts.id == id));
            
            testLinkMock.Setup(t => t.GetTestSuitesForTestSuite(It.IsAny<int>())).Returns((int id) => listOfTestSuites.FindAll(ts => ts.parentId == id));
            
            //testLinkMock.Setup(t => t.UploadTestSuiteAttachment
            
            return testLinkMock;
        }
        
        public static ITestLinkExtra GetTestLinkWithTestSuites(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects,
           System.Collections.Generic.List<Meyn.TestLink.TestPlan> listOfTestPlans,
           System.Collections.Generic.List<Meyn.TestLink.TestPlatform> listOfTestPlatforms,
           System.Collections.Generic.List<Meyn.TestLink.TestPlanTotal> listOfTestPlanTotals,
           System.Collections.Generic.List<Meyn.TestLink.Build> listOfBuilds,
           System.Collections.Generic.List<Meyn.TestLink.TestSuite> listOfTestSuites)
        {
            var testLinkMock = _getTestLinkMockWithTestSuites(listOfProjects, listOfTestPlans, listOfTestPlatforms, listOfTestPlanTotals, listOfBuilds, listOfTestSuites);
            
            return testLinkMock.Object;
        }
        
        
        public static Mock<ITestLinkExtra> _getTestLinkMockWithTestCases(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects,
           System.Collections.Generic.List<Meyn.TestLink.TestPlan> listOfTestPlans,
           System.Collections.Generic.List<Meyn.TestLink.TestPlatform> listOfTestPlatforms,
           System.Collections.Generic.List<Meyn.TestLink.TestPlanTotal> listOfTestPlanTotals,
           System.Collections.Generic.List<Meyn.TestLink.Build> listOfBuilds,
           System.Collections.Generic.List<Meyn.TestLink.TestSuite> listOfTestSuites,
           System.Collections.Generic.List<Meyn.TestLink.TestCase> listOfTestCases)
        {
            var testLinkMock = _getTestLinkMockWithTestSuites(listOfProjects, listOfTestPlans, listOfTestPlatforms, listOfTestPlanTotals, listOfBuilds, listOfTestSuites);
            
            //testLinkMock.Setup(t => t.CreateTestCase
            
            testLinkMock.Setup(t => t.GetTestCase(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int tcId, int verId) => listOfTestCases.Find(testCase => testCase.id == tcId && testCase.version == verId));

            //testLinkMock.Setup(t => t.GetTestCaseAttachments
            
            //testLinkMock.Setup(t => t.GetTestCaseIDByName
            
            //testLinkMock.Setup(t => t.GetTestCaseIdsForTestSuite
            
//            System.Collections.Generic.List<Meyn.TestLink.TestCaseFromTestPlan> listOfTestCasesFromTestPlan =
//                new System.Collections.Generic.List<Meyn.TestLink.TestCaseFromTestPlan>();
//            foreach (Meyn.TestLink.TestCase testCase in listOfTestCases) {
//                listOfTestCasesFromTestPlan.Add(testCase);
//            }
//            testLinkMock.Setup(t => t.GetTestCasesForTestPlan(It.IsAny<int>()))
//                //.Returns((int tPlanId) => listOfTestCases.FindAll(testCase => testCase.
//                .Returns(() => listOfTestCasesFromTestPlan); // there is no relation between test case and test plan id
//            
//            System.Collections.Generic.List<Meyn.TestLink.TestCaseFromTestSuite> listOfTestCasesFromTestSuite =
//                new System.Collections.Generic.List<Meyn.TestLink.TestCaseFromTestSuite>();
//            foreach (Meyn.TestLink.TestCase testCase in listOfTestCases) {
//                listOfTestCasesFromTestSuite.Add((Meyn.TestLink.TestCaseFromTestSuite)testCase);
//            }
//            testLinkMock.Setup(t => t.GetTestCasesForTestSuite(It.IsAny<int>(), It.IsAny<bool>()))
//                .Returns((int tsId, bool deep) => listOfTestCasesFromTestSuite.FindAll(testCase => testCase.testsuite_id == tsId)); // deep is ignored
            
            //testLinkMock.Setup(t => t.UploadTestCaseAttachment
            
            return testLinkMock;
        }
        
        public static ITestLinkExtra GetTestLinkWithTestCases(
           System.Collections.Generic.List<Meyn.TestLink.TestProject> listOfProjects,
           System.Collections.Generic.List<Meyn.TestLink.TestPlan> listOfTestPlans,
           System.Collections.Generic.List<Meyn.TestLink.TestPlatform> listOfTestPlatforms,
           System.Collections.Generic.List<Meyn.TestLink.TestPlanTotal> listOfTestPlanTotals,
           System.Collections.Generic.List<Meyn.TestLink.Build> listOfBuilds,
           System.Collections.Generic.List<Meyn.TestLink.TestSuite> listOfTestSuites,
           System.Collections.Generic.List<Meyn.TestLink.TestCase> listOfTestCases)
        {
            var testLinkMock = _getTestLinkMockWithTestCases(listOfProjects, listOfTestPlans, listOfTestPlatforms, listOfTestPlanTotals, listOfBuilds, listOfTestSuites, listOfTestCases);
            
            return testLinkMock.Object;
        }
        
        public static TestProject GetTestProject(
            string name,
            string prefix,
            string notes,
            string color,
            int tc_counter,
            bool active,
            bool option_automation,
            bool option_inventory,
            bool option_priority,
            bool option_reqs)
        {
            int id = generator.Next(1000000);
            
            var data = new XmlRpcStruct {
                { "id", id.ToString() },
                { "name", name },
                { "prefix", prefix },
                { "notes", notes },
                { "color", color },
                { "active", 1 },
                { "tc_counter", tc_counter }
            };
            var optStruct = new XmlRpcStruct {
                { "requirementsEnabled", 1 },
                { "testPriorityEnabled", 1 },
                { "automationEnabled", 1 },
                { "inventoryEnabled", 1 }
                // { "opt", optStruct }
            };
            data.Add("opt", optStruct);
            
            /*
            var data = new XmlRpcStruct();
            data.Add("id", id.ToString());
            data.Add("name", name);
            data.Add("prefix", prefix);
            data.Add("notes", notes);
            data.Add("color", color);
            data.Add("active", 1);
            data.Add("tc_counter", tc_counter);
            
            var optStruct = new XmlRpcStruct();
            optStruct.Add("requirementsEnabled", 1);
            optStruct.Add("testPriorityEnabled", 1);
            optStruct.Add("automationEnabled", 1);
            optStruct.Add("inventoryEnabled", 1);
            data.Add("opt", optStruct);
            */
            
            var testProject = new Mock<Meyn.TestLink.TestProject>(data);
            return testProject.Object;
            
        }
        
        public static TestProject GetTestProject(
            string name,
            string prefix,
            string notes)
        {
            TestProject testProject =
                GetTestProject(
                    name,
                    prefix,
                    notes,
                    "color",
                    100,
                    true,
                    true,
                    true,
                    true,
                    true);
            
            return testProject;
        }
        
        public static TestPlan GetTestPlan(
            string name,
            string notes,
            bool active,
            bool is_public,
            bool open,
            int testproject_id)
        {
            int id = generator.Next(1000000);
            
            var data = new XmlRpcStruct() {
                { "active", active },
                { "id", id },
                { "name", name },
                { "notes", notes },
                { "testproject_id", testproject_id },
                { "is_open", open },
                { "is_public", is_public }
            };
            /*
            var data = new XmlRpcStruct();
            data.Add("active", active);
            data.Add("id", id);
            data.Add("name", name);
            data.Add("notes", notes);
            data.Add("testproject_id", testproject_id);
            data.Add("is_open", open);
            data.Add("is_public", is_public);
            */
            
            var testPlan = new Mock<TestPlan>(data);
            return testPlan.Object;
        }
        
        public static Meyn.TestLink.TestSuite GetTestSuite(
            string name,
            int nodeOrder,
            int nodeTypeId,
            int parentId)
        {
            int id = generator.Next(1000000);
            
            var data = new XmlRpcStruct {
                { "name", name },
                { "id", id },
                { "parent_id", parentId },
                { "node_type_id", nodeTypeId },
                { "node_order", nodeOrder }
            };
            /*
            var data = new XmlRpcStruct();
            data.Add("name", name);
            data.Add("id", id);
            data.Add("parent_id", parentId);
            data.Add("node_type_id", nodeTypeId);
            data.Add("node_order", nodeOrder);
            */
            
            var testSuite = new Mock<Meyn.TestLink.TestSuite>(data);
            return testSuite.Object;
        }
        
//    /// <summary>
//    /// test cases as they are returned from a test plan
//    /// </summary>
//    /// <remarks>This is different from TestCase as it returns additional info from the testplan. 
//    /// Maybe this should be refactored with a testplandetails subclass</remarks>
//    public class TestCaseFromTestPlan : TL_Data
//    {
//        /// <summary>
//        /// marks the test case as active
//        /// </summary>
//        public readonly  bool active;
//        /// <summary>
//        /// the build id the test case is assigned to
//        /// </summary>
//        public readonly int assigned_build_id;
//
//        public readonly int assigner_id;
//        /// <summary>
//        /// 
//        /// </summary>
//        public readonly int executed;
//        public readonly string execution_notes;
//        public readonly int execution_order;
//        /// <summary>
//        /// timestamp when it was executed. blank if not yet executeed
//        /// </summary>
//        public readonly string execution_ts;
//        /// <summary>
//        /// actual execution type on last run 1=manual, 2 = automatic
//        /// </summary>
//        public string execution_run_type;
//        /// <summary>
//        /// the execution type set in the test case  1=manual, 2 = automatic
//        /// </summary>
//        public readonly int execution_type;
//        public readonly int exec_id;
//        /// <summary>
//        /// build id where it was last executed on
//        /// </summary>
//        public readonly int exec_on_build;
//        /// <summary>
//        /// test plan id where it was last executed
//        /// </summary>
//        public readonly int exec_on_tplan;
//        /// <summary>
//        /// the last execution status
//        /// </summary>
//        public readonly TestCaseResultStatus exec_status;
//        /// <summary>
//        /// the id displayed on the UI, but without hte prefix
//        /// </summary>
//        public readonly string external_id;
//        public readonly int importance;
//        public readonly int feature_id;
//        public readonly DateTime linked_ts;
//        public readonly int linked_by;
//        public readonly string name;
//        public readonly int platform_id;
//        public string platform_name;
//        /// <summary>
//        /// //the priority assigned in the test case(?)
//        /// </summary>
//        public int priority;
//        /// <summary>
//        /// not clear what this is. It is NOT the same as the status in the other test case classes
//        /// </summary>
//        public string status;
//       
//        public string summary;
//        /// <summary>
//        /// 
//        /// </summary>
//        public int tcversion_number;
//        public int tcversion_id;
//        public int tc_id;
//        public int tester_id;
//        public int testsuite_id;
//        public string tsuite_name;
//        public string type;
//        public int user_id;
//        /// <summary>
//        /// urgency set in test plan
//        /// </summary>
//        public int urgency;
//        public int version;
//        public int z;
//
//        internal TestCaseFromTestPlan(XmlRpcStruct data)
//        {
//            active = int.Parse((string)data["active"]) == 1;
//            name = (string)data["name"];
//            tsuite_name = (string)data["tsuite_name"];
//            z = toInt(data, "z");
//            type = (string)data["type"];
//            execution_order = toInt(data, "execution_order");
//            exec_id = toInt(data, "exec_id");
//            tc_id = toInt(data, "tc_id");
//            tcversion_number = toInt(data, "tcversion_number");
//            status = (string)data["status"];
//            external_id = (string)data["external_id"];
//            exec_status = toExecStatus(data, "exec_status");
//            exec_on_tplan = toInt(data, "exec_on_tplan");
//            executed = toInt(data, "executed");
//            feature_id = toInt(data, "feature_id");
//            assigner_id = toInt(data, "assigner_id");
//            user_id = toInt(data, "user_id");
//            active = toInt(data, "active") == 1;
//            version = toInt(data, "version");
//            testsuite_id = toInt(data, "testsuite_id");
//            tcversion_id = toInt(data, "tcversion_id");
//            //steps = (string)data["steps"];
//            //expected_results = (string)data["expected_results"];
//            summary = (string)data["summary"];
//            execution_type = toInt(data, "execution_type");
//            platform_id = toInt(data, "platform_id");
//            platform_name = (string)data["platform_name"];
//            linked_ts = toDate(data, "linked_ts");
//            linked_by = toInt(data, "linked_by");
//            importance = toInt(data, "importance");
//            execution_run_type = (string)data["execution_run_type"];
//            execution_ts = (string)data["execution_ts"];
//            tester_id = toInt(data, "tester_id");
//            execution_notes = (string)data["execution_notes"];
//            exec_on_build = toInt(data, "exec_on_build");
//            assigned_build_id = toInt(data,"assigned_build_id");
//            urgency = toInt(data, "urgency");
//            priority = toInt(data, "priority");
//        }
//        /// <summary>
//        /// This is used for the call GetTestCasesForTestPlan
//        /// using the returned list from TestLink, generate a list of data
//        /// </summary>
//        /// <param name="list"></param>
//        /// <returns></returns>
//        public static List<TestCaseFromTestPlan> GenerateFromResponse(XmlRpcStruct list)
//        {
//            List<TestCaseFromTestPlan> result = new List<TestCaseFromTestPlan>();
//            if (list != null)
//            {
//                foreach (object o in list.Values)
//                {
//                     TestCaseFromTestPlan tc = null;
//                     if (o is XmlRpcStruct)
//                     {
//                         XmlRpcStruct list2 = o as XmlRpcStruct;
//                         foreach (object o2 in list2.Values)
//                         {
//                             tc = new TestCaseFromTestPlan(o2 as XmlRpcStruct);
//                             result.Add(tc);
//                         }
//                     }
//                     else
//                     {
//                         object[] olist = o as object[];
//                         tc = new TestCaseFromTestPlan(olist[0] as XmlRpcStruct);
//                         result.Add(tc);
//                     }
//                }
//            }
//            return result;
//        }
//    }

//    /// <summary>
//    /// test case as it is retrieved from testsuite
//    /// </summary>
//    public class TestCaseFromTestSuite : TL_Data
//    {
//        /// <summary>
//        /// test case id
//        /// </summary>
//        public readonly int id;
//
//        public readonly int parent_id;
//        public readonly int node_type_id;
//        public readonly int node_order;
//        public readonly string node_table;
//        public readonly string name;
//        public readonly bool active; 
//        /// <summary>
//        /// the version of the test case, starts with 1
//        /// </summary>
//        public readonly int version;        
//        /// <summary>
//        /// the internal id of this testcase version
//        /// </summary>
//        public readonly int tcversion_id;
//        /// <summary>
//        /// not clear what this represents
//        /// </summary>
//        public readonly string layout;
//        /// <summary>
//        /// not clear in its meaning
//        /// </summary>
//        public readonly int status;
//        public readonly string summary;
//        public readonly string preconditions;
//       
//        /// <summary>
//        /// the id that is displayed on the UI, sans the prefix
//        /// </summary>
//        public readonly string external_id; 
//        /// <summary>
//        /// the id of the owning testsuite
//        /// </summary>
//        public readonly int testSuite_id;
//        /// <summary>
//        /// unknown purpose
//        /// </summary>
//        public readonly bool is_open;
//        /// <summary>
//        /// 
//        /// </summary>
//        public readonly DateTime modification_ts;
//        /// <summary>
//        /// 
//        /// </summary>
//        public readonly int updater_id;
//        /// <summary>
//        /// manual or automatic
//        /// </summary>
//        public readonly  int execution_type;
//        public readonly string details;  
//        public readonly int author_id;
//        public readonly DateTime creation_ts;
//        public readonly int importance;
//        internal TestCaseFromTestSuite(XmlRpcStruct data)
//        {
//            active = int.Parse((string)data["active"]) == 1;
//            id = toInt(data, "id");
//            name = (string)data["name"];
//            version = toInt(data, "version");
//            tcversion_id = toInt(data, "tcversion_id");
//            //steps = (string)data["steps"];
//            //expected_results = (string)data["expected_results"];
//            external_id = (string)data["tc_external_id"];
//            testSuite_id = toInt(data, "parent_id");
//            is_open = int.Parse((string)data["is_open"]) == 1;
//            modification_ts = base.toDate(data, "modification_ts");
//            updater_id = toInt(data, "updater_id");
//            execution_type = toInt(data, "execution_type");
//            summary = (string)data["summary"];
//            if (data.ContainsKey("details"))
//                details = (string)data["details"];
//            else
//                details = "";
//            author_id = toInt(data, "author_id");
//            creation_ts = base.toDate(data, "creation_ts");
//            importance = toInt(data, "importance");
//            parent_id = toInt(data, "parent_id");
//            node_type_id = toInt(data, "node_type_id");
//            node_order = toInt(data, "node_order");
//            node_table = (string)data["node_table"];
//            layout = (string)data["layout"];
//            status = toInt(data, "status");
//            preconditions = (string)data["preconditions"];
//        }
//    }
        
        public static Meyn.TestLink.TestCase GetTestCase(
            //int id,
            string externalid,
            string updater_login,
            string author_login,
            string name,
            int node_order,
            int testsuite_id,
            int testcase_id,
            int version,
            string layout,
            int status,
            string summary,
            string preconditions,
            int importance,
            int author_id,
            int updater_id,
            DateTime creation_ts,
            DateTime modification_ts,
            bool active,
            bool is_open,
            int execution_type,
            string author_first_name,
            string author_last_name,
            string updater_first_name,
            string updater_last_name,
            System.Collections.Generic.List<TestStep> steps)
        {
            int id = generator.Next(1000000);
            
            XmlRpcStruct data = new XmlRpcStruct();
            data.Add("id", id);
            data.Add("active", 1);
            data.Add("tc_external_id", externalid);
            data.Add("updater_login", updater_login);
            data.Add("author_login", author_login);
            data.Add("name", name);
            data.Add("node_order", node_order);
            data.Add("testsuite_id", testsuite_id);
            data.Add("testcase_id", testcase_id);
            data.Add("version", version);
            data.Add("layout", layout);
            data.Add("status", status);
            data.Add("summary", summary);
            data.Add("preconditions", preconditions);
            data.Add("importance", importance);
            data.Add("author_id", author_id);
            data.Add("updater_id", updater_id);
            data.Add("modification_ts", modification_ts);
            data.Add("creation_ts", creation_ts);
            data.Add("is_open", is_open);
            data.Add("execution_type", execution_type);
            data.Add("author_first_name", author_first_name);
            data.Add("author_last_name", author_last_name);
            data.Add("updater_first_name", updater_first_name);
            data.Add("updater_last_name", updater_last_name);
            
            XmlRpcStruct[] structs = new XmlRpcStruct[]{};
            //add steps
            
            data.Add("steps", structs);
            
            var testCase = new Mock<Meyn.TestLink.TestCase>(data);
            return testCase.Object;

#region commented
//            active = int.Parse((string)data["active"]) == 1;
//            externalid = (string)data["tc_external_id"];
//            id = toInt(data, "id");
//            updater_login = (string)data["updater_login"];
//            author_login = (string)data["author_login"];
//            name = (string)data["name"];
//            node_order = toInt(data, "node_order");
//            testsuite_id = toInt(data, "testsuite_id");
//            testcase_id = toInt(data, "testcase_id");
//            version = toInt(data, "version");
//            layout = (string)data["layout"];
//            status = toInt(data, "status");
//            summary = (string)data["summary"];
//            preconditions = (string)data["preconditions"];
//            importance = toInt(data, "importance");
//            author_id = toInt(data, "author_id");
//            updater_id = toInt(data, "updater_id");
//            modification_ts = base.toDate(data, "modification_ts");
//            creation_ts = base.toDate(data, "creation_ts");
//            is_open = int.Parse((string)data["is_open"]) == 1;
//            execution_type = toInt(data, "execution_type");
//            author_first_name = (string)data["author_first_name"];
//            author_last_name = (string)data["author_last_name"];
//            updater_first_name = (string)data["updater_first_name"];
//            updater_last_name = (string)data["updater_last_name"];
//            steps = new List<TestStep>();
//            XmlRpcStruct[] stepData = data["steps"] as XmlRpcStruct[];
//            if (stepData != null)
//                foreach (XmlRpcStruct aStepDatum in stepData)
//                    steps.Add(new TestStep(aStepDatum));
#endregion commented
        }
        
        public static Meyn.TestLink.TestPlatform GetTestPlatform(
           string name,
           string notes)
        {
            int id = generator.Next(1000000);
            
            XmlRpcStruct data = new XmlRpcStruct();
            data.Add("name", name);
            data.Add("id", id);
            data.Add("notes", notes);
            
            var testPlatform = new Mock<Meyn.TestLink.TestPlatform>(data);
            return testPlatform.Object;
        }
        
        public static Meyn.TestLink.TestPlanTotal GetTestPlanTotal(
           string name,
           string type,
           int total_tc)
        {
            
//        /// <summary>
//        /// category name
//        /// </summary>
//        public readonly string Type = "";
//        /// <summary>
//        /// category value
//        /// </summary>
//        public readonly string Name = "";
//        /// <summary>
//        /// total test cases that are covered in this test plan
//        /// </summary>
//        public readonly int Total_tc;
//        /// <summary>
//        /// Dictionary with execution totals
//        /// </summary>
//        public readonly Dictionary<string, int> Details = new Dictionary<string, int>();
//
////        internal TestPlanTotal(XmlRpcStruct data)
////        {
//            Total_tc = toInt(data, "total_tc");
//            if (data.ContainsKey("type"))
//                Type = (string)data["type"];    
//            if (data.ContainsKey("name"))
//                Name = (string)data["name"];
//          
//            XmlRpcStruct xdetails = data["details"] as XmlRpcStruct;
//
//            foreach (string key in xdetails.Keys)
//            {
//                XmlRpcStruct val = xdetails[key] as XmlRpcStruct;
//                int qty = toInt(val,"qty");
//                Details.Add(key, qty);
//            }
////        }
           
           
            int id = generator.Next(1000000);
            
            XmlRpcStruct data = new XmlRpcStruct();
            data.Add("name", name);
            data.Add("type", type);
            data.Add("total_tc", total_tc);
            
            XmlRpcStruct details = new XmlRpcStruct();
            
            data.Add("details", details);
            
            var testPlanTotal = new Mock<Meyn.TestLink.TestPlanTotal>(data);
            return testPlanTotal.Object;
           
        }
    }
}
