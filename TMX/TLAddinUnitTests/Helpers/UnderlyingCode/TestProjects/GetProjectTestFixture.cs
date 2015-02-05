/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/18/2012
 * Time: 12:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.TestProjects
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    using Tmx;
    using Meyn.TestLink;
    using CookComputing.XmlRpc;
    
    /// <summary>
    /// Description of GetProjectTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class GetProjectTestFixture
    {
        public GetProjectTestFixture()
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
        
        private System.Collections.Generic.List<TestProject> getProject(
            System.Collections.Generic.List<TestProject> listOfProjects,
            string[] names,
            bool makeFail)
        {
            TLProjectCmdletBase cmdlet = new TLProjectCmdletBase();
            cmdlet.Name = names;
            
            TLAddinData.CurrentTestLinkConnection =
                FakeTestLinkFactory.GetTestLinkWithProjects(listOfProjects);

            if (makeFail) {
                TLAddinData.CurrentTestLinkConnection = null;
            }
//cmdlet.WriteTrace(cmdlet, "getProject 00001");
            TLSrvGetProjectCommand command =
                new TLSrvGetProjectCommand(cmdlet);
            command.Execute();
//cmdlet.WriteTrace(cmdlet, "getProject 00002");
            System.Collections.Generic.List<TestProject> resultList =
                new System.Collections.Generic.List<TestProject>();
//cmdlet.WriteTrace(cmdlet, "getProject 00003");
            foreach (object tpr in PSTestLib.UnitTestOutput.LastOutput) {
//cmdlet.WriteTrace(cmdlet, "getProject 00004_1");
                resultList.Add((Meyn.TestLink.TestProject)tpr);
//cmdlet.WriteTrace(cmdlet, "getProject 00004_2");
            }

            return resultList;
        }
        
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_with_params_broken_connection()
        {
            string projectName = "project";

            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectName,
                    "prj",
                    string.Empty));
            
            System.Collections.Generic.List<TestProject> resultList =
                getProject(list, (new string[]{ projectName }), true);
            
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                (new System.Collections.Generic.List<TestProject>()),
                resultList);
        }

        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_with_params_no_projects()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            
            System.Collections.Generic.List<TestProject> resultList =
                getProject(list, null, false);
            
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                list,
                resultList);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_with_params_one_project_by_name()
        {
            string projectName = "project01";
            
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project00",
                    "prj0",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectName,
                    "prj1",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project02",
                    "prj2",
                    string.Empty));
            
            System.Collections.Generic.List<TestProject> resultList =
                getProject(list, (new string[]{ projectName }), false);
            
            list.RemoveAt(2);
            list.RemoveAt(0);
            
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                list,
                resultList);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_with_params_three_projects_by_name()
        {

            string[] projectNames = { "project01", "project02", "project03" };

            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectNames[0],
                    "prj1",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project04",
                    "prj4",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectNames[1],
                    "prj2",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectNames[2],
                    "prj3",
                    string.Empty));
            
            System.Collections.Generic.List<TestProject> resultList =
                getProject(list, projectNames, false);
            
            list.RemoveAt(1);
            
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                list,
                resultList);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_with_params_one_project_by_id()
        {
            string projectName = "project01";
            
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project00",
                    "prj0",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectName,
                    "prj1",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project02",
                    "prj2",
                    string.Empty));
            
            System.Collections.Generic.List<int> projectIds =
                new System.Collections.Generic.List<int>();
            projectIds.Add(list[1].id);
            
            System.Collections.Generic.List<TestProject> resultList =
                getProject(list, (new string[]{ projectName }), false);
            
            list.RemoveAt(2);
            list.RemoveAt(0);
            
            Assert.AreEqual<int>(
                projectIds[0],
                resultList[0].id);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_with_params_three_projects_by_id()
        {

            string[] projectNames = { "project01", "project02", "project03" };

            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectNames[0],
                    "prj1",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project04",
                    "prj4",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectNames[1],
                    "prj2",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    projectNames[2],
                    "prj3",
                    string.Empty));
            
            int[] projectIds =
                { list[0].id, list[2].id, list[3].id };
            
            System.Collections.Generic.List<TestProject> resultList =
                getProject(list, projectNames, false);
            
            list.RemoveAt(1);
            
            Assert.AreEqual<int>(
                projectIds[0],
                resultList[0].id);
            
            Assert.AreEqual<int>(
                projectIds[1],
                resultList[1].id);
            
            Assert.AreEqual<int>(
                projectIds[2],
                resultList[2].id);
        }
    }
}
