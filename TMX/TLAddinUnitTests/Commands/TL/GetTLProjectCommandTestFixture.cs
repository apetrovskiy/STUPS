/*
 * Created by SharpDevelop.
 * User: shuran
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
            bool makeFail)
        {
            GetTLProjectCommand cmdlet = new GetTLProjectCommand();
            cmdlet.Name = null;
            
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
        public void GetTLProject_NoParameters_NoProjects()
        {
            System.Collections.Generic.List<TestProject> list =
                new System.Collections.Generic.List<TestProject>();

            System.Collections.Generic.List<TestProject> resultList =
                getProjectCollection(list, true);
            
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
                getProjectCollection(list, true);
            
            Assert.AreEqual(
                list[0],
                (Meyn.TestLink.TestProject)PSTestLib.UnitTestOutput.LastOutput[0]);
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
                getProjectCollection(list, true);

            Assert.AreEqual(
                list[0],
                (Meyn.TestLink.TestProject)PSTestLib.UnitTestOutput.LastOutput[0]);
                
            Assert.AreEqual(
                list[1],
                (Meyn.TestLink.TestProject)PSTestLib.UnitTestOutput.LastOutput[1]);
                
            Assert.AreEqual(
                list[2],
                (Meyn.TestLink.TestProject)PSTestLib.UnitTestOutput.LastOutput[2]);
        }
        
//        [Test]
//        [Description("Get-TLProject")]
//        [Category("Fast")]
//        public void GetTLProject_NoParameters()
//        {
//            //string expectedResultName = "suite name";
//            UnitTestingHelper.GetNewTestSuite(expectedResultName, string.Empty, string.Empty);
//            Assert.AreEqual(
//                expectedResultName,
//                ((ITestSuite)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Name);
//        }
    }
}
