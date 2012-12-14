/* 
TestLink API Unit Tests
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

using System.Collections.Generic;
using MbUnit.Framework;
using Meyn.TestLink;
using System;
using Meyn.TestLink.GallioExporter;

namespace tlinkTest
{
    /// <summary>
    /// tests the API for functions on storing test run results
    /// </summary>
    /// <remarks>
    /// See class TestBase for basic configuration.
    /// 
    /// This unit test has been marked up with a testlinkfixture attribute. 
    /// This fixture uses the Gallio Testlink Adapter to export results of this test 
    ///  fixture to Testlink. If you do not use the adapter, you can ignore this attribute.
    ///  if you DO use the adapter then you need to make sure that the parameters below are setup corectly
    ///  
    /// Please remember that this tests the API, not testlink.
    /// </remarks>
    [TestFixture]
    [TestLinkFixture(
       Url = "http://localhost/testlink/lib/api/xmlrpc.php",
       ProjectName = "TestLinkApi",
       UserId = "admin",
       TestPlan = "Automatic Testing",
       TestSuite = "TestResultReporting",
     PlatformName = "Testlink v1.9.3",
       DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class TestResultReporting : Testbase
    {

     //   TestLink proxy;
        int tcIdToHaveResults = 0;
        int tPlanId = 0;
        int platformId;

        protected int BuildIdUsedForTesting
        {
            get
            {
                List<Build> list = proxy.GetBuildsForTestPlan(tPlanId);
                Assert.AreNotEqual(0, list.Count, "Setup failed to find builds  for testproject '{1}", testProjectName);
                foreach (Build build in list)
                    if (build.name == buildUsedForTestingName)
                        return build.id;
                Assert.Fail("Setup failed to find build named {0} for testproject '{1}", buildUsedForTestingName, testProjectName);
                return 0;
            }
        }
        [SetUp]
        public void setup()
        {
            base.Setup();
            TestPlan plan = getTestPlan(theTestPlanName);
            tPlanId = plan.id;
            
            List<TestCaseId> list =  proxy.GetTestCaseIDByName(testCasetoHaveResults);
            Assert.IsNotEmpty(list, "Failure in Setup. Couldn't find test case");
            tcIdToHaveResults = list[0].id;
            platformId = Platforms[0].id;

        }


        [Test]
        [ExpectedException(typeof(TestLinkException))]
        public void ShouldFailWithInvalidTestCaseId()
        {
            proxy.ReportTCResult(1, tPlanId, TestCaseResultStatus.Blocked, platformId);
        }
        [Test]
        [Category("Changes Database")]
        public void ReportATestCaseExecution()
        {
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Blocked, platformId);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }

        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}", tcIdToHaveResults, tPlanId);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Pass, platformId);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }

        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionUsingPlatformName()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}", tcIdToHaveResults, tPlanId);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Pass, platformName:"OS/X");
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }

        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed_notes()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}", tcIdToHaveResults, tPlanId);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Pass, platformId, notes: "Test case named : ReportTestCaseExecutionAsPassed_notes");
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }


        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed_buildId_notes()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);

            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Pass, platformId,
            buildid: BuildIdUsedForTesting,
            notes: "Test case named : ReportTestCaseExecutionAsPassed_buildId_notes");
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }
        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed_buildId_notes_guessTrue()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Pass, platformId,
                buildid: BuildIdUsedForTesting,
                notes:"Test case named : ReportTestCaseExecutionAsPassed_buildId_notes_guessTrue", 
                guess: true);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }
        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Pass, platformId,
                buildid: BuildIdUsedForTesting,
                notes: "Test case named : ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse",
                guess:false);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }
        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Fail, platformId,
                buildid: BuildIdUsedForTesting,
                notes: "ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid. This one failed with bug id 237", 
                guess: false, 
                bugid: 237);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }
        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed_buildId_notes_guessTrue_bugid()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);
            TestPlatform platform = Platforms[0];
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Fail, platformId,
                buildid: BuildIdUsedForTesting,
                notes: "Test case named : ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid. This one failed with bug id 238" ,
                 guess: true,
                bugid: 238);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }
        [Test]
        [Category("Changes Database")]
        [ExpectedException(typeof(TestLinkException))]
        public void ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid_wrongplatformId()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Fail, 9999,
               buildid: BuildIdUsedForTesting,
               notes: "Test case named : ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid_wrongplatformId. This one failed with bug id 238 and build platform id 1",
               guess: false, 
               bugid: 238);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }
        [Test]
        [ExpectedException(typeof(TestLinkException))]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid_WrongplatformName()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Fail, 
            platformName: "hfshjdks", 
            buildid: BuildIdUsedForTesting,
            notes: "Test case named : ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid_platformName. This one failed with bug id 239 and build platform named 'platformX'",
            guess: false, 
            bugid: 239 );
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }
        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid_ExistingplatformName()
        {

            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);

            TestPlatform platform = Platforms[0];

            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Fail,
            buildid: BuildIdUsedForTesting,
            notes: "Test case named : ReportTestCaseExecutionAsPassed_buildId_notes_guessFalse_bugid_ExistingplatformName. This one failed with bug id 239 and build platform named 'platformX'",
            guess: false,
            bugid: 239,
            platformName: platform.name);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }
        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseExecutionAsFailed()
        {
            Console.WriteLine("tcId:{0}, tpId:{1}, buildId:{2}", tcIdToHaveResults, tPlanId, BuildIdUsedForTesting);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Fail, platformId);
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
        }

        [Test]
        [Category("Changes Database")]
        public void ReportTestCaseAgainstOlderBuild()
        {
            List<Build> builds = proxy.GetBuildsForTestPlan(PlanCalledAutomatedTesting.id);
            Assert.IsNotEmpty(builds, "Can't proceed. Got empty list of builds for plan");
            // remove inactive builds
            for (int i = builds.Count - 1; i >= 0; i--)
                if (builds[i].is_open == false)
                    builds.Remove(builds[i]);

            Assert.IsTrue(builds.Count>1, "Can't proceed. Need at least two active builds");
            // select oldest build (lowest id)
            Build target = builds[0];
            foreach (Build b in builds)
                if (target.id > b.id)
                    target = b;
            System.Console.WriteLine("Test case id:{0} against test build {1}:{2} recorded as failed",
                                tcIdToHaveResults, target.id, target.name);
            GeneralResult result = proxy.ReportTCResult(tcIdToHaveResults, tPlanId, TestCaseResultStatus.Fail, platformId, 
                                        buildid: target.id, 
                                        notes:"test case assigned to older build");
            Console.WriteLine("Status: '{0}', message: '{1}'", result.status, result.message);
            Assert.AreEqual(true, result.status);
            
        }

        [Test]
        [Category("Changes Database")]
        public void testAttachmentUploadToExecution()
        {
            int testPlanId = PlanCalledAutomatedTesting.id; ;
            int testCaseId = this.TestCaseToHaveResultsDeleted;

            List<TestPlatform> platforms = proxy.GetTestPlanPlatforms(testPlanId);

            GeneralResult gr = proxy.ReportTCResult(testCaseId, testPlanId, TestCaseResultStatus.Fail, platforms[0].id);

            byte[] content = new byte[4];
            content[0] = 48;
            content[1] = 49;
            content[2] = 50;
            content[3] = 51;

            AttachmentRequestResponse r = proxy.UploadExecutionAttachment(gr.id, "fileX.txt", "text/plain", content, "some result", "a description");
            Assert.AreEqual(r.foreignKeyId, gr.id);
            Console.WriteLine("Response id:{0}, table '{1}', title:'{2}' size:{3}", r.foreignKeyId, r.linkedTableName, r.title, r.size);
            proxy.DeleteExecution(gr.id);
        }

        [Test]
        [Category("Changes Database")]
        public void testDeleteExecutionExecution()
        {
            int testPlanId = PlanCalledAutomatedTesting.id; ;
            int testCaseId = this.TestCaseToHaveResultsDeleted;

            List<TestPlatform> platforms = proxy.GetTestPlanPlatforms(testPlanId);

            GeneralResult gr = proxy.ReportTCResult(testCaseId, testPlanId, TestCaseResultStatus.Fail, platforms[0].id);
            Assert.IsNotNull(gr, "did not get a return value from ReportTCResult");
            Assert.AreEqual(true, gr.status, "ReportTCResult did not return a true status");

            GeneralResult grdel = proxy.DeleteExecution(gr.id);
            Assert.IsNotNull(grdel, "did not get a return value from ReportTCResult");
            Assert.AreEqual(true, grdel.status, "ReportTCResult did not return a true status");
            Assert.AreEqual(grdel.id, gr.id, "did not get same id in return from delete execution as from reportTCResult");

        }

        [Test]        
        [ExpectedException(typeof(TestLinkException))]
        public void testAttachmentUploadToExecution_wrongTcId()
        {
            int testPlanId = PlanCalledAutomatedTesting.id; ;
            int testCaseId = this.TestCaseToHaveResultsDeleted;

            List<TestPlatform> platforms = proxy.GetTestPlanPlatforms(testPlanId);

 
            byte[] content = new byte[4];
            content[0] = 48;
            content[1] = 49;
            content[2] = 50;
            content[3] = 51;
            //this should throw an exception as id = 0 is not valid
            AttachmentRequestResponse r = proxy.UploadExecutionAttachment(0, "fileX.txt", "text/plain", content, "some result", "a description");
        }

    }
}
