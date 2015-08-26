/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 26/06/2015
 * Time: 07:52 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    using System.Linq;
    using MbUnit.Framework;
    using Nancy;
    using Nancy.Testing;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    using Tmx.Server.Library.Modules;
    using Tmx.Server.Logic.ObjectModel;
    using Tmx.Server.Logic.ObjectModel.Objects;
    using Tmx.Server.SamplePlugin;
    using Xunit;

    /// <summary>
    /// Description of ShortcutModuleTestFixture.
    /// </summary>
    [TestFixture][NUnit.Framework.TestFixture]
    public class ShortcutModuleTestFixture
    {
        BrowserResponse _response;
        Browser _browser;
        
        public ShortcutModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
            // _browser = TestFactory.GetBrowserForTestRunsModule();
            
            _browser = new Browser(with => with.Modules(typeof(ShortcutModule), typeof(ServerControlModule)));
        }
        
        [SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            TestSettings.PrepareModuleTests();
            // _browser = TestFactory.GetBrowserForTestRunsModule();
            
            _browser = new Browser(with => with.Modules(typeof(ShortcutModule), typeof(ServerControlModule)));
        }
        
        [Test][NUnit.Framework.Test][Fact]
        public void Should_create_first_testRun_of_default_workflow_Running_as_json()
        {
            GIVEN_first_testWorkflow(TestConstants.Workflow03);
            WorkflowCollection.Workflows[0].IsDefault = true;
            Defaults.Workflow = WorkflowCollection.Workflows[0].Name;
            
            WHEN_sending_testRun_as_json("def", TestRunStatuses.Running, "/start/" + "paramValue", null);
            
            THEN_there_should_be_the_following_number_of_testRun_objects(1);
            THEN_testRun_is_running(TestRunQueue.TestRuns[0]);
            
            var w1 = WorkflowCollection.Workflows[0];
            var t1 = TestRunQueue.TestRuns[0];
        }
        
        void GIVEN_first_testWorkflow(string alternativeName)
        {
            var serverCommand = new ServerCommand {
                Command = ServerControlCommands.LoadConfiguraiton,
                Data = alternativeName
            };
            _browser.Put(UrlList.ServerControlPoint_absPath, with => {
                with.JsonBody(serverCommand);
                with.Accept("application/json");
            });
        }
        
        TestRunCommand WHEN_sending_testRun_as_json(string testWorkflowName, TestRunStatuses status, string alternativeUrl, ITestRunCommand testRunCommand)
        {
            var testRun = new TestRun();
            (testRun as TestRun).SetWorkflow(WorkflowCollection.Workflows.First(wfl => wfl.Name == testWorkflowName));
            if (null == testRunCommand)
                _response = _browser.Get(alternativeUrl, with => {
                    // with.JsonBody(testRunCommand);
                    with.Accept("application/json");
                });
            else
                _response = _browser.Get(alternativeUrl, with => {
                    with.JsonBody(testRunCommand);
                    with.Accept("application/json");
                });
            
            Xunit.Assert.Equal(HttpStatusCode.Created, _response.StatusCode);
            
            return _response.Body.DeserializeJson<TestRunCommand>();
        }
        
        void THEN_there_should_be_the_following_number_of_testRun_objects(int number)
        {
            Xunit.Assert.Equal(number, TestRunQueue.TestRuns.Count);
        }
        
        void THEN_testRun_is_running(ITestRun testRun)
        {
            Xunit.Assert.Equal(true, testRun.IsActive());
        }
    }
}
