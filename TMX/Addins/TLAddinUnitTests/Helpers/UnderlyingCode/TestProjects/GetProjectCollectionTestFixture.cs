/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/16/2012
 * Time: 9:49 PM
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
    /// Description of GetProjectCollectionTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class GetProjectCollectionTestFixture
    {
        public GetProjectCollectionTestFixture()
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
        
        private System.Collections.Generic.List<TestProject> getProjectCollection(
            System.Collections.Generic.List<TestProject> listOfProjects,
            bool makeFail)
        {
            TLProjectCmdletBase cmdlet = new TLProjectCmdletBase();
            cmdlet.Name = null;
            
            TLAddinData.CurrentTestLinkConnection =
                FakeTestLinkFactory.GetTestLinkWithProjects(listOfProjects);
            
            if (makeFail) {
                TLAddinData.CurrentTestLinkConnection = null;
            }
//cmdlet.WriteTrace(cmdlet, "getProjectCollection: 003");
            TLSrvGetProjectCommand command =
                new TLSrvGetProjectCommand(cmdlet);
            command.Execute();
//cmdlet.WriteTrace(cmdlet, "getProjectCollection: 004");
            System.Collections.Generic.List<TestProject> resultList =
                new System.Collections.Generic.List<TestProject>();
//cmdlet.WriteTrace(cmdlet, "getProjectCollection: 005");
//cmdlet.WriteTrace(cmdlet, "IsInitialized: " + PSTestLib.UnitTestOutput.IsInitialized.ToString());
            foreach (object tpr in PSTestLib.UnitTestOutput.LastOutput) {
//cmdlet.WriteTrace(cmdlet, "getProjectCollection: 006");
                resultList.Add((TestProject)tpr);
//cmdlet.WriteTrace(cmdlet, "getProjectCollection: 007");
            }

            return resultList;
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_broken_connection()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project1",
                    "prj1",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project2",
                    "prj2",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project3",
                    "prj3",
                    string.Empty));
//cmdlet.WriteTrace(cmdlet, "GetTLProject_broken_connection: 001");
            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, true);
//cmdlet.WriteTrace(cmdlet, "GetTLProject_broken_connection: 002");
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                (new System.Collections.Generic.List<TestProject>()),
                resultList);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_no_projects()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            
            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, false);
            
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                list,
                resultList);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_one_project()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project",
                    "prj",
                    string.Empty));
            
            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, false);
            
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                list,
                resultList);
        }
        
        [Test] //, Parallelizable]
        [Category("Fast")]
        public void GetTLProject_three_projects()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project1",
                    "prj1",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project2",
                    "prj2",
                    string.Empty));
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project3",
                    "prj3",
                    string.Empty));
            
            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, false);
            
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                list,
                resultList);
        }
    }
}
