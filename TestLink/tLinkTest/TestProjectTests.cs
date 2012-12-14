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
     TestSuite = "TestProject Tests",
     PlatformName = "Testlink v1.9.3",
     DevKey = "fb37eb345a5b4f05659d5c35bb3465fd")]
    public class TestProjectTests:Testbase
    {
        [SetUp]
        public void setup()
        {
            base.Setup();
        }

        [Test]
        public void GetAllTestProjects()
        {
            List<TestProject> result = proxy.GetProjects();
            Assert.IsNotEmpty(result);
            foreach (TestProject tp in result)
            {
                Console.WriteLine("{0}:{1}", tp.id, tp.name);
                Console.WriteLine(" Automation={0}, Priority={1}, Requirements={2}, Prefix='{3}', TcCounter={4}", tp.option_automation, tp.option_priority, tp.option_reqs, tp.prefix, tp.tc_counter);
            }

        }
        [Test]
        [MultipleAsserts]
        public void GetTestProjectByName()
        {
            TestProject tp = proxy.GetProject(this.ApiTestProject.name);
            Assert.IsNotNull(tp, "Test Project {0}:{1} wasn't found", this.ApiTestProject.id, 
                this.ApiTestProject.name);
            Assert.AreEqual(this.ApiTestProject.name, tp.name);
            Assert.AreEqual(this.ApiTestProject.id, tp.id);
            Assert.IsTrue(tp.option_automation, "Automation should be yes");
            Assert.IsTrue(tp.option_priority, "Priority should be yes"); 
            Assert.IsTrue(tp.option_reqs, "Requirements should be yes");
            Assert.IsFalse(tp.option_inventory, "Inventory should be no");
            Assert.AreEqual(tp.prefix, "api", "PRefix should be 'api'");
        }
        [Test]
        [ExpectedException(typeof(TestLinkException))]
        public void GetTestProjectByName_WrongName()
        {
            TestProject tp = proxy.GetProject("project that does not exist");
            Assert.IsNull(tp);
        }
        [Test]
        public void CreateTestProject()
        {

            string projectname = string.Format("Project autocreated at {0}", DateTime.Now);
            string prefix = string.Format("p{0}", DateTime.Now.Ticks);
            GeneralResult tp = proxy.CreateProject(projectname, prefix, "some notes");
            Assert.IsTrue(tp.status, "Status should be true");
            TestProject tp1 = proxy.GetProject(projectname);
            Assert.AreEqual(tp.id, tp1.id, "Project Ids are not the same");          
        }

        [Test]
        public void UploadTestProjectAttachment()
        {
            int testProjectId = this.ApiTestProjectId;
           

            byte[] content = new byte[4];
            content[0] = 48;
            content[1] = 49;
            content[2] = 50;
            content[3] = 51;

            AttachmentRequestResponse r = proxy.UploadTestProjectAttachment(testProjectId, "fileX.txt", "text/plain", content, "some result", "a description");
            Assert.AreEqual(r.foreignKeyId, testProjectId);
            Console.WriteLine("Response id:{0}, table '{1}', title:'{2}' size:{3}", r.foreignKeyId, r.linkedTableName, r.title, r.size);
        }

    }
}
