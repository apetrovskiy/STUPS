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

using System;
using System.Collections.Generic;
using MbUnit.Framework;
using Meyn.TestLink;
using Meyn.TestLink.GallioExporter;


namespace tlinkTest
{
    [TestFixture]
    [TestLinkFixture(
     Url = "http://localhost/testlink/lib/api/xmlrpc.php",
     ProjectName = "TestLinkApi",
     UserId = "admin",
     TestPlan = "Automatic Testing",
     TestSuite = "TestPlan Tests",
     PlatformName = "Testlink v1.9.3",
     DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class TestPlanTests : Testbase
    {
        [SetUp]
        public void setup()
        {
            base.Setup();
        }

        [Test]
        public void GetAllTestPlans()
        {
            Assert.AreNotEqual(-1, ApiTestProjectId);
            Console.WriteLine("Getting Testplans for TestProjectId = {0}", ApiTestProjectId);
            List < TestPlan> result =  proxy.GetProjectTestPlans(ApiTestProjectId);
            Assert.IsNotEmpty(result);
            foreach (TestPlan tp in result)
            {
                Console.WriteLine("{0}:{1}. Project Id: {2}", tp.id, tp.name, tp.testproject_id);
                Assert.AreNotEqual("", tp.name);
                Assert.AreEqual(ApiTestProjectId, tp.testproject_id);
            }

        }
        [Test]
        public void GetTestPlansWhereThereAreNone()
        {
            Assert.AreNotEqual(-1, EmptyProjectId, "Can't run test because there is no project named '{0}'", emptyProjectName);
            Console.WriteLine("TestProjectId = {0}", EmptyProjectId);
            List<TestPlan> result = proxy.GetProjectTestPlans(EmptyProjectId);
            foreach (TestPlan plan in result)
            {
                Console.WriteLine("Plan {0}: '{1}'", plan.id, plan.name);
            }

            Assert.IsEmpty(result);
        }

        [Test]
        public void CreatePlan()
        {
            string planName = string.Format("AutocreatedTestPlan at {0}", DateTime.Now.ToUniversalTime());
            Assert.AreNotEqual(-1, ApiTestProjectId);
            Console.WriteLine("Creating Testplan for TestProjectId = {0}", ApiTestProjectId);
            GeneralResult createResult = proxy.CreateTestPlan(planName, ApiTestProject.name, "These are some notes", true);
            Console.WriteLine("Result status:{0}, id:{1}, message:'{2}'", createResult.status, createResult.id, createResult.message);
            Assert.AreEqual(true, createResult.status, "Create did not return true");

            List<TestPlan> result = proxy.GetProjectTestPlans(ApiTestProjectId);
            bool found = false;
            foreach (TestPlan plan in result)
            {
                Console.Write ("Looking at plan id:{0} '{1}'", plan.id, plan.name);
                if (plan.id == createResult.id)
                {
                    found = true;
                    Console.WriteLine(" --- Found!");
                    Assert.AreEqual(true, plan.active, "Plan should be active");
                    Assert.AreEqual(planName, plan.name, "Plan name is wrong");
                    break;
                }
                else Console.WriteLine(" --- no match");
            }
            Assert.IsTrue(found, "No plan created");
        }
        [Test]
        [ExpectedException(typeof(Meyn.TestLink.TestLinkException))]
        public void GetTestPlansFromNonExistentProject()
        {                        
            List<TestPlan> result = proxy.GetProjectTestPlans(999999);
            foreach (TestPlan plan in result)
            {
                Console.WriteLine("Plan {0}: '{1}'", plan.id, plan.name);
            } 
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetTestPlanByName()
        {
            TestPlan plan = proxy.getTestPlanByName(testProjectName, theTestPlanName);
            Assert.IsNotNull(plan);
        }

        [Test]
        public void GetTestPlanPlatformShouldFind2()
        {
            TestPlan plan = proxy.getTestPlanByName(testProjectName, theTestPlanName);
            Assert.IsNotNull(plan);
            List<TestPlatform> platforms = proxy.GetTestPlanPlatforms(plan.id);
            Assert.IsNotEmpty(platforms,"Should have found two platforms");
            Assert.AreEqual(2, platforms.Count, "Expected two platforms in testplan '{0}'", theTestPlanName);
        }
        /// <summary>
        /// current implementation throws an exception if a testplan has no platforms linked
        /// </summary>
        [Test]        
        public void GetTestPlanPlatformShouldFindNone()
        {
            TestPlan plan = proxy.getTestPlanByName(testProjectName, emptyTestplanName);
            Assert.IsNotNull(plan);
            List<TestPlatform> platforms = proxy.GetTestPlanPlatforms(plan.id);
            Assert.IsEmpty(platforms, "Should have found no platforms in testplan '{0}'", theTestPlanName);
          
        }

        [Test]
        [ExpectedException(typeof(Meyn.TestLink.TestLinkException))]
        public void GetTestPlanByNameWrongPlanName()
        {
            TestPlan plan = proxy.getTestPlanByName(testProjectName, "No Such Plan");
            Assert.IsNotNull(plan);
        }

        [Test]
        [ExpectedException(typeof(Meyn.TestLink.TestLinkException))]
        public void GetTestPlanByNameWrongProjectName()
        {
            TestPlan plan = proxy.getTestPlanByName("No such project", theTestPlanName);
            Assert.IsNotNull(plan);
        }

        [Test]
        public void TestPlanTotalsReporting()
        {
            TestPlan plan = proxy.getTestPlanByName(testProjectName, theTestPlanName);
            Assert.IsNotNull(plan, "can't proceed. No plan found");
            Console.WriteLine("Getting totals for plan {0}:{1}", plan.id, plan.name);
            List<TestPlanTotal> list = proxy.GetTotalsForTestPlan(plan.id);
            Assert.IsNotEmpty(list, "Expected to get results");
            foreach (TestPlanTotal tpt in list)
            {
                Console.WriteLine("Name='{0}' Type='{1}'  Total:{2}", tpt.Name, tpt.Type, tpt.Total_tc);
                Dictionary<string, int> det = tpt.Details;
                foreach (string key in det.Keys)
                {
                    Console.WriteLine("  '{0}': '{1}'", key, det[key]);
                }
            }
        }
        [Test]
        public void TestPlanTotalsReportingShouldHaveNoResults()
        {
            TestPlan plan = proxy.getTestPlanByName(testProjectName, emptyTestplanName);
            Assert.IsNotNull(plan, "can't proceed. No plan found");
            List<TestPlanTotal> list = proxy.GetTotalsForTestPlan(plan.id);
            Assert.AreEqual(1, list.Count, "Expected to get 1 result which has all zeros");
            TestPlanTotal tpt = list[0];
            Assert.AreEqual(0, tpt.Total_tc);
            
        }
    }
}
