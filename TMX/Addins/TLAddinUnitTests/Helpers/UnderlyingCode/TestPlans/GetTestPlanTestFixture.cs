/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/18/2012
 * Time: 6:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.TestPlans
{
    using MbUnit.Framework;
    using Tmx;
    using Meyn.TestLink;

    /// <summary>
    /// Description of GetTestPlanTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class GetTestPlanTestFixture
    {
        public GetTestPlanTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        private System.Collections.Generic.List<TestPlan> getTestPlansFromProjectsInPipelineByName(
            System.Collections.Generic.List<TestProject> testProjects,
            System.Collections.Generic.List<TestPlan> testPlans,
            string[] testPlanNames,
            bool makeFail,
            bool inputNotSpecified)
        {
            
            GetTLTestPlanCommand cmdlet = new GetTLTestPlanCommand();

            if (inputNotSpecified) {
                cmdlet.InputObject = null;
            } else {
                TestProject[] projectsArray =
                    testProjects.ToArray();
                cmdlet.InputObject = projectsArray;
            }
            cmdlet.TestPlanName = testPlanNames;
            
            TLAddinData.CurrentTestLinkConnection =
                FakeTestLinkFactory.GetTestLinkWithTestPlans(testProjects, testPlans, null, null);
            
            if (inputNotSpecified) {
                TLAddinData.CurrentTestProject = testProjects[0];
            }
            
            if (makeFail) {
                TLAddinData.CurrentTestLinkConnection = null;
            }
            
            TLSrvGetTestPlanCommand command =
                new TLSrvGetTestPlanCommand(cmdlet);
            command.Execute();
            
            System.Collections.Generic.List<TestPlan> resultList =
                new System.Collections.Generic.List<TestPlan>();

            foreach (object tpl in PSTestLib.UnitTestOutput.LastOutput) {

                resultList.Add((TestPlan)tpl);
            }

            return resultList;
            
        }
        
        // project in the pipeline with broken connection
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void TestProject_from_pipeline_single_name_with_broken_connection()
        {
            System.Collections.Generic.List<TestProject> listOfProjects =
                new System.Collections.Generic.List<TestProject>();
            listOfProjects.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project",
                    "prj",
                    string.Empty));
            
            System.Collections.Generic.List<TestPlan> listOfTestPlans =
                new System.Collections.Generic.List<TestPlan>();
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 01",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 02",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 03",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            
            System.Collections.Generic.List<TestPlan> resultList =
                getTestPlansFromProjectsInPipelineByName(listOfProjects, listOfTestPlans, (new string[]{ "testplan 02" }), true, false);
            
            Assert.AreEqual<System.Collections.Generic.List<TestPlan>>(
                (new System.Collections.Generic.List<TestPlan>()),
                resultList);
        }
        
        // project in the pipeline
        [Test] //, Parallelizable]
        [Category("Fast")]
        [Ignore("too complicated for now")]
        public void TestProject_from_pipeline_single_name()
        {
            System.Collections.Generic.List<TestProject> listOfProjects =
                new System.Collections.Generic.List<TestProject>();
            listOfProjects.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project",
                    "prj",
                    string.Empty));
            
            System.Collections.Generic.List<TestPlan> listOfTestPlans =
                new System.Collections.Generic.List<TestPlan>();
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 01",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 02",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 03",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            
            System.Collections.Generic.List<TestPlan> resultList =
                getTestPlansFromProjectsInPipelineByName(listOfProjects, listOfTestPlans, (new string[]{ "testplan 02" }), false, false);

            listOfTestPlans.RemoveAt(2);
            listOfTestPlans.RemoveAt(0);
            
            Assert.AreElementsSameIgnoringOrder<TestPlan>(
                listOfTestPlans,
                resultList);
        }
        
        
        // projects in the pipeline
        [Test] //, Parallelizable]
        [Category("Fast")]
        [Ignore("too complicated for now")]
        public void TestProjects_from_pipeline_single_name()
        {
            System.Collections.Generic.List<TestProject> listOfProjects =
                new System.Collections.Generic.List<TestProject>();
            listOfProjects.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project01",
                    "prj1",
                    string.Empty));
            listOfProjects.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project02",
                    "prj2",
                    string.Empty));
            listOfProjects.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project03",
                    "prj3",
                    string.Empty));
            
            System.Collections.Generic.List<TestPlan> listOfTestPlans =
                new System.Collections.Generic.List<TestPlan>();
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 01",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 02",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 03",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 04",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[2].id));
            
            System.Collections.Generic.List<TestPlan> resultList =
                getTestPlansFromProjectsInPipelineByName(listOfProjects, listOfTestPlans, (new string[]{ "testplan 02" }), false, false);

            listOfTestPlans.RemoveAt(3);
            listOfTestPlans.RemoveAt(2);
            listOfTestPlans.RemoveAt(0);
            
            Assert.AreElementsSameIgnoringOrder<TestPlan>(
                listOfTestPlans,
                resultList);
        }
        
        // projects in the pipeline
        [Test] //, Parallelizable]
        [Category("Fast")]
        [Ignore("too complicated for now")]
        public void TestProjects_from_pipeline_two_names()
        {
            System.Collections.Generic.List<TestProject> listOfProjects =
                new System.Collections.Generic.List<TestProject>();
            listOfProjects.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project01",
                    "prj1",
                    string.Empty));
            listOfProjects.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project02",
                    "prj2",
                    string.Empty));
            listOfProjects.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project03",
                    "prj3",
                    string.Empty));
            
            System.Collections.Generic.List<TestPlan> listOfTestPlans =
                new System.Collections.Generic.List<TestPlan>();
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 01",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 02",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 03",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[0].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 04",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[2].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 02",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[2].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 02",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    listOfProjects[1].id));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 02",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    111));
            listOfTestPlans.Add(
                FakeTestLinkFactory.GetTestPlan(
                    "testplan 03",
                    "notes",
                    true, // active
                    true, // is_public
                    true, // open
                    222));
            
            System.Collections.Generic.List<TestPlan> resultList =
                getTestPlansFromProjectsInPipelineByName(listOfProjects, listOfTestPlans, (new string[]{ "testplan 02", "testplan 04" }), false, false);

            listOfTestPlans.RemoveAt(7);
            listOfTestPlans.RemoveAt(6);
            listOfTestPlans.RemoveAt(2);
            listOfTestPlans.RemoveAt(0);
            
            Assert.AreElementsSameIgnoringOrder<TestPlan>(
                listOfTestPlans,
                resultList);
        }
        
//        private System.Collections.Generic.List<TestPlan> getTestPlansByProjectNameAndByTestPlanName(
//            //System.Collections.Generic.List<TestProject> testProjects,
//            string[] testProjectNames,
//            System.Collections.Generic.List<TestPlan> testPlans,
//            string[] testPlanNames,
//            bool makeFail,
//            bool inputNotSpecified)
//        {
//            
//            TLTestPlanCmdletBase cmdlet = new TLTestPlanCmdletBase();
//            cmdlet.UnitTest = true;
//            if (inputNotSpecified) {
//                cmdlet.InputObject = null;
//            } else {
//                TestProject[] projectsArray =
//                    testProjects.ToArray();
//                cmdlet.InputObject = projectsArray;
//            }
//            cmdlet.TestPlanName = testPlanNames;
//            
//            TLAddinData.CurrentTestLinkConnection =
//                FakeTestLinkFactory.GetTestLinkWithTestPlans(testProjects, testPlans, null, null);
//            
//            if (inputNotSpecified) {
//                TLAddinData.CurrentTestProject = testProjects[0];
//            }
//            
//            if (makeFail) {
//                TLAddinData.CurrentTestLinkConnection = null;
//            }
//            
//            TLSrvGetTestPlanCommand command =
//                new TLSrvGetTestPlanCommand();
//            command.Cmdlet = cmdlet;
//            command.Execute();
//            
//            System.Collections.Generic.List<TestPlan> resultList =
//                new System.Collections.Generic.List<TestPlan>();
//
//            foreach (object tpl in Tmx.CommonCmdletBase.UnitTestOutput) {
//
//                resultList.Add((TestPlan)tpl);
//            }
//
//            return resultList;
//            
//        }
    }
}
