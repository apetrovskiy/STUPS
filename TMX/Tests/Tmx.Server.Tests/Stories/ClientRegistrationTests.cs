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
    using Tmx.Client;

    public class ClientRegistrationTests
    {
        RestTemplateWrapper _restTemplate;
        IRestRequestCreator _restRequestCreator;
        const string _baseUrl = "http://localhost:12340";
        const string _pathToWorkflows = @"../../Data/";
        const string _workflow01Name = "CRsuite";
        const string _workflow02Name = "NAC";
        const string _workflow04Name = "fourth";
        const string _testRun01Name = "test run name";
        const string _testRun02Name = "test run name 02";
        const string _workflow01TestConsoleName = "testConsole";
        const string _workflow04TestConsoleName = "testConsole2";
        const string _workflow01FileName = "Workflow1.xml";
        const string _workflow02FileName = "Workflow2.xml";
        const string _workflow04FileName = "Workflow4.xml";

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
            GivenNewTestRunWithStatusRunningFirstWorkflow(_testRun01Name);

            WhenSendingRegistration(_workflow01TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(1);
            ThenTheClientIsRegistered(0, _workflow01TestConsoleName);
        }

        [Test][Fact]
        public void RegisterSecondClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(_testRun01Name);

            WhenSendingRegistration(_workflow01TestConsoleName);
            WhenSendingRegistration(_workflow01TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(2);
            ThenTheClientIsRegistered(1, _workflow01TestConsoleName);
        }

        [Test][Fact]
        public void RegisterThirdClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(_testRun01Name);

            WhenSendingRegistration(_workflow01TestConsoleName);
            WhenSendingRegistration(_workflow01TestConsoleName);
            WhenSendingRegistration(_workflow01TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(3);
            ThenTheClientIsRegistered(2, _workflow01TestConsoleName);
        }

        [Test][Fact]
        public void RegisterClientsInTheFirstOfTwoTestRuns()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(_testRun01Name);
            GivenSecondTestWorkflow();
            GivenNewTestRunWithStatusRunningSecondWorkflow(_testRun02Name);

            WhenSendingRegistration(_workflow01TestConsoleName);
            WhenSendingRegistration(_workflow01TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(2);
            ThenTheClientIsRegistered(0, _workflow01TestConsoleName);
            ThenTheClientIsRegistered(1, _workflow01TestConsoleName);
        }

        [Test][Fact]
        public void RegisterClientsInTwoTestRuns()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(_testRun01Name);
            GivenFourthTestWorkflow();
            GivenNewTestRunWithStatusRunningFourthWorkflow(_testRun02Name);

            WhenSendingRegistration(_workflow01TestConsoleName);
            WhenSendingRegistration(_workflow04TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(2);
            ThenTheClientIsRegistered(0, _workflow01TestConsoleName);
            ThenTheClientIsRegistered(1, _workflow04TestConsoleName);
        }

        [Test][Fact]
        public void UnregisterClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(_testRun01Name);
            GivenSecondTestWorkflow();
            GivenNewTestRunWithStatusRunningSecondWorkflow(_testRun02Name);
            GivenSendingRegistration(_workflow01TestConsoleName);
            GivenSendingRegistration(_workflow01TestConsoleName);

            ClientSettings.Instance.ClientId = ClientsCollection.Clients[1].Id;
            WhenSendingDeregistration();

            ThenThereAreTheNumberOfClientsRegistered(1);
            ThenTheClientIsRegistered(0, _workflow01TestConsoleName);
        }

        [Test][Fact]
        public void UnregisterAllClients()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(_testRun01Name);
            GivenSecondTestWorkflow();
            GivenNewTestRunWithStatusRunningSecondWorkflow(_testRun02Name);
            GivenSendingRegistration(_workflow01TestConsoleName);
            GivenSendingRegistration(_workflow01TestConsoleName);

            ClientSettings.Instance.ClientId = ClientsCollection.Clients[1].Id;
            WhenSendingDeregistration();
            ClientSettings.Instance.ClientId = ClientsCollection.Clients[0].Id;
            WhenSendingDeregistration();

            ThenThereAreTheNumberOfClientsRegistered(0);
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
            CreateTestWorkflow(TestConstants.Workflow01, _workflow01FileName);
        }

        void GivenSecondTestWorkflow()
        {
            CreateTestWorkflow(TestConstants.Workflow02, _workflow02FileName);
        }

        void GivenFourthTestWorkflow()
        {
            CreateTestWorkflow(TestConstants.Workflow04, _workflow04FileName);
        }

        void CreateTestWorkflow(string testWorkflowName, string testWorkflowFileName)
        {
            var serverCommand = new ServerCommand
            {
                Command = ServerControlCommands.LoadConfiguraiton,
                Data = testWorkflowName
            };
            _restTemplate.Put(UrlList.ServerControlPoint_absPath, serverCommand);

            var workflowLoader = new WorkflowLoader();
            workflowLoader.Load(_pathToWorkflows + testWorkflowFileName);
        }

        void GivenNewTestRunWithStatusRunningFirstWorkflow(string name)
        {
            NewTestRun(_workflow01Name, name);
        }

        void GivenNewTestRunWithStatusRunningSecondWorkflow(string name)
        {
            NewTestRun(_workflow02Name, name);
        }

        void GivenNewTestRunWithStatusRunningFourthWorkflow(string name)
        {
            NewTestRun(_workflow04Name, name);
        }

        void NewTestRun(string workflowName, string testRunName)
        {
            var testRunCreator = ProxyFactory.Get<TestRunCreator>();
            testRunCreator.CreateTestRun(workflowName, TestRunStatuses.Running, testRunName);
        }

        Guid GivenSendingRegistration(string customString)
        {
            return SendingRegistration(customString);
        }

        Guid WhenSendingRegistration(string customString)
        {
            return SendingRegistration(customString);
        }

        Guid SendingRegistration(string customString)
        {
            var registration = ProxyFactory.Get<Registration>();
            return registration.SendRegistrationInfoAndGetClientId(customString);
        }

        void WhenSendingDeregistration()
        {
            var registration = ProxyFactory.Get<Registration>();
            registration.UnregisterClient();
        }

        void ThenThereAreTheNumberOfClientsRegistered(int number)
        {
            Assert.Equal(number, ClientsCollection.Clients.Count);
        }

        void ThenTheClientIsRegistered(int clientNumber, string customString)
        {
            Assert.Equal(customString, ClientsCollection.Clients[clientNumber].CustomString);
        }
    }
}