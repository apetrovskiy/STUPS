/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2014
 * Time: 2:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    using Nancy.Testing;
    using Core.Types.Remoting;
    using Interfaces.Server;
    using Interfaces.Remoting;
    using Logic.ObjectModel.Objects;
    using UnitTestingHelpers;
    using Xunit;
    
    /// <summary>
    /// Description of ServerControlModuleTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ServerControlModuleTestFixture
    {
        // BrowserResponse _response;
        Browser _browser;
        
        public ServerControlModuleTestFixture()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForServerControlModule();
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            TestSettings.PrepareModuleTests();
            _browser = TestFactory.GetBrowserForServerControlModule();
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateFirstWorkflowObjectAsJson()
        {
            var serverCommand = GivenServerCommand(ServerControlCommands.LoadConfiguraiton, TestConstants.Workflow01);
            WhenSendingServerCommandAsJson(serverCommand);
            ThenThereShouldBeTheFollowingNumberOfWorkflowObjects(1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateFirstWorkflowObjectAsXml()
        {
            var serverCommand = GivenServerCommand(ServerControlCommands.LoadConfiguraiton, TestConstants.Workflow01);
            WhenSendingServerCommandAsXml(serverCommand);
            ThenThereShouldBeTheFollowingNumberOfWorkflowObjects(1);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateSecondWorkflowObjectAsJson()
        {
            var serverCommand01 = GivenServerCommand(ServerControlCommands.LoadConfiguraiton, TestConstants.Workflow01);
            GivenSendingServerCommand(serverCommand01);
            var serverCommand02 = GivenServerCommand(ServerControlCommands.LoadConfiguraiton, TestConstants.Workflow02);
            WhenSendingServerCommandAsJson(serverCommand02);
            ThenThereShouldBeTheFollowingNumberOfWorkflowObjects(2);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void ShouldCreateSecondWorkflowObjectAsXml()
        {
            var serverCommand01 = GivenServerCommand(ServerControlCommands.LoadConfiguraiton, TestConstants.Workflow01);
            GivenSendingServerCommand(serverCommand01);
            var serverCommand02 = GivenServerCommand(ServerControlCommands.LoadConfiguraiton, TestConstants.Workflow02);
            WhenSendingServerCommandAsXml(serverCommand02);
            ThenThereShouldBeTheFollowingNumberOfWorkflowObjects(2);
        }
        
        ServerCommand GivenServerCommand(ServerControlCommands commandType, string data)
        {
            return new ServerCommand {
                Command = commandType,
                Data = data
            };
        }
        
        void GivenSendingServerCommand(ServerCommand serverCommand)
        {
            WhenSendingServerCommandAsXml(serverCommand);
        }
        
        void WhenSendingServerCommandAsJson(ServerCommand serverCommand)
        {
            _browser.Put(UrlList.ServerControlPoint_absPath, with => {
                with.JsonBody(serverCommand);
                with.Accept("application/json");
            });
        }
        
        void WhenSendingServerCommandAsXml(ServerCommand serverCommand)
        {
            _browser.Put(UrlList.ServerControlPoint_absPath, with => {
                with.JsonBody(serverCommand);
                with.Accept("application/xml");
            });
        }
        
        void ThenThereShouldBeTheFollowingNumberOfWorkflowObjects(int number)
        {
            Assert.Equal(number, WorkflowCollection.Workflows.Count);
        }
    }
}
