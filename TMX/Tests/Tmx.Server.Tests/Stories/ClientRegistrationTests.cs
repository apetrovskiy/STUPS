namespace Tmx.Server.Tests.Stories
{
    using System;
    using Client;
    using Client.Library.Helpers;
    using Client.Library.ObjectModel;
    using Core.Proxy;
    using Core.Types.Remoting;
    using Fakes;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Logic.ObjectModel;
    using Logic.ObjectModel.Objects;
    using NUnit.Framework;
    using Xunit;
    using Client.Library.Abstract;
    using Assert = Xunit.Assert;

    public class ClientRegistrationTests
    {
        RestTemplateWrapper _restTemplate;
        IRestRequestCreator _restRequestCreator;
        const string _baseUrl = "http://localhost:12340";
        const string _pathToWorkflows = @"../../Data/";
        const string _workflow01Name = "CRsuite";
        const string _workflow02Name = "NAC";
        const string _testRun01Name = "test run name";
        const string _testRun02Name = "test run name 02";
        const string _workflow01TestConsoleName = "testConsole";
        const string _workflowFileName = "Workflow1.xml";

        void PrepareMocks()
        {
            _restTemplate = new RestTemplateWrapper(_baseUrl);
            ClientSettings.Instance.ServerUrl = _baseUrl;
            _restRequestCreator = new RestRequestCreatorEmulator();
            _restRequestCreator.SetRestTemplate(_restTemplate);
            RestRequestFactory.RestRequestCreator = _restRequestCreator;
        }

        public ClientRegistrationTests()
        {
            PrepareMocks();
            CleanUp();
        }

        [SetUp]
        public void SetUp()
        {
            PrepareMocks();
            CleanUp();
        }

        [Test][Fact]
        public void RegisterFirstClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunning(_testRun01Name);

            WhenSendingRegistration(_workflow01TestConsoleName);

            ThenTheClientIsRegistered(0);
        }

        [Test][Fact]
        public void RegisterSecondClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunning(_testRun01Name);

            WhenSendingRegistration(_workflow01TestConsoleName);
            WhenSendingRegistration(_workflow01TestConsoleName);

            ThenTheClientIsRegistered(1);
        }

        [Test][Fact]
        public void RegisterThirdClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunning(_testRun01Name);

            WhenSendingRegistration(_workflow01TestConsoleName);
            WhenSendingRegistration(_workflow01TestConsoleName);
            WhenSendingRegistration(_workflow01TestConsoleName);

            ThenTheClientIsRegistered(2);
        }

        void CleanUp()
        {
            WorkflowCollection.Workflows.Clear();
            ClientsCollection.Clients.Clear();
            TestRunQueue.TestRuns.Clear();
            TaskPool.Tasks.Clear();
            TaskPool.TasksForClients.Clear();
        }

        void GivenFirstTestWorkflow()
        {
            var serverCommand = new ServerCommand
            {
                Command = ServerControlCommands.LoadConfiguraiton,
                Data = TestConstants.Workflow01
            };
            _restTemplate.Put(UrlList.ServerControlPoint_absPath, serverCommand);

            var workflowLoader = new WorkflowLoader();
            workflowLoader.Load(_pathToWorkflows + _workflowFileName);
        }

        void GivenNewTestRunWithStatusRunning(string name)
        {
            var testRunCreator = ProxyFactory.Get<TestRunCreator>();
            testRunCreator.CreateTestRun(_workflow01Name, TestRunStatuses.Running, name);
        }

        Guid WhenSendingRegistration(string customString)
        {
            var registration = ProxyFactory.Get<Registration>();
            return registration.SendRegistrationInfoAndGetClientId(customString);
        }

        void ThenTheClientIsRegistered(int clientNumber)
        {
            Assert.Equal(clientNumber + 1, ClientsCollection.Clients.Count);
            Assert.Equal(_workflow01TestConsoleName, ClientsCollection.Clients[clientNumber].CustomString);
        }
    }
}