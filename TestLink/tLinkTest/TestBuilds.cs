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
    /// <summary>
    /// Contains unit tests to test the API.
    /// </summary>
    /// <remarks>
    /// See class testbase for basic configuration.
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
     TestSuite = "TestBuilds",
     PlatformName = "Testlink v1.9.3",
     DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class TestBuilds : Testbase
    {

        [SetUp]
        public void setup()
        {
            base.Setup();
            base.loadProjectIds();
            Assert.IsNotNull(PlanCalledAutomatedTesting, "Setup failure - couldn't get test plan");
        }   
        
        [Test]
        [Category("Changes Database")]
        [MultipleAsserts]
        public void CreateABuild()
        {
            GeneralResult result = proxy.CreateBuild(PlanCalledAutomatedTesting.id,  string.Format("build {0}", DateTime.Now),
                        "an auto created build");
            Assert.IsNotNull(result, "Returned a null result");
            Assert.IsTrue(result.status == true, "CreateBuild returned failure: {0}", result.message);
        }
        [Test]
        public void ListBuilds()
        {
            List<Build> builds = proxy.GetBuildsForTestPlan(PlanCalledAutomatedTesting.id);
            Assert.IsNotEmpty(builds, "Got empty list of builds for plan");
            foreach (Build b in builds)
                    Console.WriteLine("  Build #{0}: {1}. IsOpen={2}", b.id, b.name, b.is_open);
        }
        [Test] void getLatestBuild()
        {
           Build latest = proxy.GetLatestBuildForTestPlan(PlanCalledAutomatedTesting.id);
           Assert.IsNotNull(latest, "couldn't find a latest build");
        }

        [Test]
        public void ShouldGetNoBuild()
        {
            // need a test project with no builds
            TestPlan tp = getTestPlan(emptyTestplanName);
            Assert.IsNotNull(tp, "Test can't proceed, testplan '{0}' couldn't be found");
            Build build = proxy.GetLatestBuildForTestPlan(tp.id);
            Assert.IsNull(build, "{0} should have no builds", emptyTestplanName);
        }

        [Test]
        public void ShouldGetEmptyList()
        {
            TestPlan tp = getTestPlan(emptyTestplanName);
            Assert.IsNotNull(tp, "Test can't proceed, testplan '{0}' couldn't be found");
            List<Build> builds = proxy.GetBuildsForTestPlan(tp.id);
            Assert.IsEmpty(builds);
        }
    }
}
