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
    
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of OpenProjectCollectionTestFixture.
    /// </summary>
    [TestFixture]
    //[Parallelizable]
    public class OpenProjectCollectionTestFixture
    {
        public OpenProjectCollectionTestFixture()
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
            cmdlet.UnitTest = true;
            
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

            foreach (object tpr in TMX.CommonCmdletBase.UnitTestOutput) {

                resultList.Add((TestProject)tpr);
            }

            return resultList;
        }
        
        [Test] //, Parallelizable]
        public void Broken_connection()
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
                getProjectCollection(list, true);
            
            Assert.AreEqual<System.Collections.Generic.List<TestProject>>(
                (new System.Collections.Generic.List<TestProject>()),
                resultList);
        }
        
#region to delete
//        [Test] //, Parallelizable]
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
        public void No_projects()
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
        public void One_project()
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
        public void Three_projects()
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
