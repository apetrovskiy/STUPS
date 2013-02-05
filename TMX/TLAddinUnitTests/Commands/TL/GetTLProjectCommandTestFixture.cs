/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/1/2013
 * Time: 10:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.Commands.TL
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    using TMX;
    using Meyn.TestLink;
    using CookComputing.XmlRpc;

    /// <summary>
    /// Description of GetTLProjectCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetTLProjectCommandTestFixture
    {
        public GetTLProjectCommandTestFixture()
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
            string[] names,
            string[] ids,
            bool makeFail)
        {
            GetTLProjectCommand cmdlet = new GetTLProjectCommand();
            cmdlet.Name = names;
            cmdlet.Id = ids;
            
            TLAddinData.CurrentTestLinkConnection =
                FakeTestLinkFactory.GetTestLinkWithProjects(listOfProjects);
            
            if (makeFail) {
                TLAddinData.CurrentTestLinkConnection = null;
            }

            TLSrvGetProjectCommand command =
                new TLSrvGetProjectCommand(cmdlet);
            command.Execute();

            System.Collections.Generic.List<TestProject> resultList =
                new System.Collections.Generic.List<TestProject>();

            foreach (object tpr in PSTestLib.UnitTestOutput.LastOutput) {

                resultList.Add((TestProject)tpr);

            }

            return resultList;
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject")]
        [Category("Fast")]
        public void GetTLProject_NoParameters_NoConnection()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();

            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, null, null, true);
            
            Assert.AreEqual(
                0,
                PSTestLib.UnitTestOutput.LastOutput.Count);
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject")]
        [Category("Fast")]
        public void GetTLProject_NoParameters_NoProjects()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();

            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, null, null, false);
            
            Assert.AreEqual(
                0,
                PSTestLib.UnitTestOutput.LastOutput.Count);
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject")]
        [Category("Fast")]
        public void GetTLProject_NoParameters_OneProject()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project1",
                    "prj1",
                    string.Empty));

            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, null, null, false);
            
            Assert.AreEqual(
                list,
                PSTestLib.UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject")]
        [Category("Fast")]
        public void GetTLProject_NoParameters_ThreeProjects()
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
                getProjectCollection(list, null, null, false);
            
            Assert.AreEqual(
                list,
                PSTestLib.UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject -Name project1")]
        [Category("Fast")]
        public void GetTLProject_Name_OneProject()
        {
            string[] names = new string[]{ "project1" };
            
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project1",
                    "prj1",
                    string.Empty));

            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, names, null, false);
            
            Assert.AreEqual(
                list,
                PSTestLib.UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject -Name project1,project2,project3")]
        [Category("Fast")]
        public void GetTLProject_Name_ThreeProjects()
        {
            string[] names = new string[]{ "project1", "project2", "project3" };
            
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
                getProjectCollection(list, names, null, false);
            
            Assert.AreEqual(
                list,
                PSTestLib.UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Ignore("Impossibly to run owing to absence of such a GetProject method")]
        [Description("Get-TLProject -Id prj1")]
        [Category("Fast")]
        public void GetTLProject_Id_OneProject()
        {
            string[] ids = new string[]{ "prj1" };
            
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project1",
                    "prj1",
                    string.Empty));

            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, null, ids, false);
            
            Assert.AreEqual(
                list,
                PSTestLib.UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Ignore("Impossibly to run owing to absence of such a GetProject method")]
        [Description("Get-TLProject -Id prj1,prj2,prj3")]
        [Category("Fast")]
        public void GetTLProject_Id_ThreeProjects()
        {
            string[] ids = new string[]{ "prj1", "prj2", "prj3" };
            
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
                getProjectCollection(list, null, ids, false);
            
            Assert.AreEqual(
                list,
                PSTestLib.UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
    }
}
