/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/16/2012
 * Time: 9:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TLAddinUnitTests.TestProjects
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    using Moq;
    //using Autofac;
    //using Autofac.Builder;
    using TMX;
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
            //cmdlet.UnitTestMode = true;
            
            TLAddinData.CurrentTestLinkConnection =
                FakeTestLinkFactory.GetTestLinkWithProjects(listOfProjects);
            
            if (makeFail) {
                TLAddinData.CurrentTestLinkConnection = null;
            }
//Console.WriteLine("getProjectCollection: 003");
            TLSrvGetProjectCommand command =
                new TLSrvGetProjectCommand(cmdlet);
            command.Execute();
//Console.WriteLine("getProjectCollection: 004");
            System.Collections.Generic.List<TestProject> resultList =
                new System.Collections.Generic.List<TestProject>();
//Console.WriteLine("getProjectCollection: 005");
//Console.WriteLine("IsInitialized: " + PSTestLib.UnitTestOutput.IsInitialized.ToString());
//if (null == PSTestLib.UnitTestOutput.Pipelines) {
//    Console.WriteLine("null == PSTestLib.UnitTestOutput.Pipelines");
//} else {
//    Console.WriteLine("null != PSTestLib.UnitTestOutput.Pipelines");
//}
            //foreach (object tpr in TMX.CommonCmdletBase.UnitTestOutput) {
            foreach (object tpr in PSTestLib.UnitTestOutput.LastOutput) {
//Console.WriteLine("getProjectCollection: 006");
                resultList.Add((TestProject)tpr);
//Console.WriteLine("getProjectCollection: 007");
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
//Console.WriteLine("GetTLProject_broken_connection: 001");
            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, true);
//Console.WriteLine("GetTLProject_broken_connection: 002");
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                (new System.Collections.Generic.List<TestProject>()),
                resultList);
        }
        
#region to delete
//        [Test] //, Parallelizable]
//        [Category("Fast")]
//        public void No_projects_Null()
//        {
//            System.Collections.Generic.List<TestProject> list = null;
//            
//            System.Collections.Generic.List<TestProject> resultList =
//                getProjectCollection(list);
//            
//            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
//                list,
//                resultList);
//        }
#endregion to delete

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
