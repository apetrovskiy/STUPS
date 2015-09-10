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
    using Core;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Library.Modules;
    using Logic.ObjectModel;
    using Logic.ObjectModel.Objects;
    using SamplePlugin;
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
        public void ShouldCreateFirstTestRunOfDefaultWorkflowRunningAsJson()
        {
            GivenFirstTestWorkflow(TestConstants.Workflow03);
            WorkflowCollection.Workflows[0].IsDefault = true;
            Defaults.Workflow = WorkflowCollection.Workflows[0].Name;
            
            WhenSendingTestRunAsJson("def", TestRunStatuses.Running, "/start/" + "paramValue", null);
            
            ThenThereShouldBeTheFollowingNumberOfTestRunObjects(1);
            ThenTestRunIsRunning(TestRunQueue.TestRuns[0]);
            
            // 20150909
            // what was this supposed to be?
            //var w1 = WorkflowCollection.Workflows[0];
            //var t1 = TestRunQueue.TestRuns[0];
        }
        
        void GivenFirstTestWorkflow(string alternativeName)
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
        
        TestRunCommand WhenSendingTestRunAsJson(string testWorkflowName, TestRunStatuses status, string alternativeUrl, ITestRunCommand testRunCommand)
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
        
        void ThenThereShouldBeTheFollowingNumberOfTestRunObjects(int number)
        {
            Xunit.Assert.Equal(number, TestRunQueue.TestRuns.Count);
        }
        
        void ThenTestRunIsRunning(ITestRun testRun)
        {
            Xunit.Assert.Equal(true, testRun.IsActive());
        }
    }
}
