/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/1/2013
 * Time: 10:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TlAddinUnitTests.Commands.TL
{
    using System;
    using System.Collections.Generic;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    using Tmx;
    using Meyn.TestLink;
    using CookComputing.XmlRpc;

    /// <summary>
    /// Description of GetTLProjectCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetTLProjectCommandTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        List<TestProject> getProjectCollection(
            List<TestProject> listOfProjects,
            string[] names,
            string[] ids,
            bool makeFail)
        {
            var cmdlet = new GetTLProjectCommand();
            cmdlet.Name = names;
            cmdlet.Id = ids;
            
            TLAddinData.CurrentTestLinkConnection =
                FakeTestLinkFactory.GetTestLinkWithProjects(listOfProjects);
            
            if (makeFail)
                TLAddinData.CurrentTestLinkConnection = null;
            
            var command = new TLSrvGetProjectCommand(cmdlet);
            command.Execute();

            var resultList = new List<TestProject>();

            foreach (object tpr in UnitTestOutput.LastOutput) {

                resultList.Add((TestProject)tpr);

            }

            return resultList;
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject")]
        [Category("Fast")]
        public void GetTLProject_NoParameters_NoConnection()
        {
            var list = new List<TestProject>();

            var resultList = getProjectCollection(list, null, null, true);
            
            Assert.AreEqual(
                0,
                UnitTestOutput.LastOutput.Count);
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject")]
        [Category("Fast")]
        public void GetTLProject_NoParameters_NoProjects()
        {
            var list = new List<TestProject>();

            var resultList = getProjectCollection(list, null, null, false);
            
            Assert.AreEqual(
                0,
                UnitTestOutput.LastOutput.Count);
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject")]
        [Category("Fast")]
        public void GetTLProject_NoParameters_OneProject()
        {
            var list = new List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project1",
                    "prj1",
                    string.Empty));

            var resultList = getProjectCollection(list, null, null, false);
            
            Assert.AreEqual(
                list,
                UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject")]
        [Category("Fast")]
        public void GetTLProject_NoParameters_ThreeProjects()
        {
            var list = new List<TestProject>();
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

            var resultList = getProjectCollection(list, null, null, false);
            
            Assert.AreEqual(
                list,
                UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject -Name project1")]
        [Category("Fast")]
        public void GetTLProject_Name_OneProject()
        {
            var names = new []{ "project1" };
            
            var list = new List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project1",
                    "prj1",
                    string.Empty));

            var resultList = getProjectCollection(list, names, null, false);
            
            Assert.AreEqual(
                list,
                UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Description("Get-TLProject -Name project1,project2,project3")]
        [Category("Fast")]
        public void GetTLProject_Name_ThreeProjects()
        {
            var names = new []{ "project1", "project2", "project3" };
            
            var list = new List<TestProject>();
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

            var resultList = getProjectCollection(list, names, null, false);
            
            Assert.AreEqual(
                list,
                UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Ignore("Impossibly to run owing to absence of such a GetProject method")]
        [Description("Get-TLProject -Id prj1")]
        [Category("Fast")]
        public void GetTLProject_Id_OneProject()
        {
            var ids = new []{ "prj1" };
            
            var list = new List<TestProject>();
            list.Add(
                FakeTestLinkFactory.GetTestProject(
                    "project1",
                    "prj1",
                    string.Empty));

            var resultList = getProjectCollection(list, null, ids, false);
            
            Assert.AreEqual(
                list,
                UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
        
        [Test] //, Parallelizable]
        [Ignore("Impossibly to run owing to absence of such a GetProject method")]
        [Description("Get-TLProject -Id prj1,prj2,prj3")]
        [Category("Fast")]
        public void GetTLProject_Id_ThreeProjects()
        {
            var ids = new []{ "prj1", "prj2", "prj3" };
            
            var list = new List<TestProject>();
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

            var resultList = getProjectCollection(list, null, ids, false);
            
            Assert.AreEqual(
                list,
                UnitTestOutput.LastOutput.AsList<Meyn.TestLink.TestProject>());
        }
    }
}
