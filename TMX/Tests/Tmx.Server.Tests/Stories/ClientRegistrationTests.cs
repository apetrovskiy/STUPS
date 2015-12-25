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
        const string BaseUrl = "http://localhost:12340";
        // TODO: set a universal path
        // const string PathToWorkflows = @"../../Data/";
        const string PathToWorkflows = @"C:/Projects/PS/STUPS/TMX/Tests/Tmx.Server.Tests/Data/";
        const string Workflow01Name = "CRsuite";
        const string Workflow02Name = "NAC";
        const string Workflow04Name = "fourth";
        const string TestRun01Name = "test run name";
        const string TestRun02Name = "test run name 02";
        const string Workflow01TestConsoleName = "testConsole";
        const string Workflow04TestConsoleName = "testConsole2";
        const string Workflow01FileName = "Workflow1.xml";
        const string Workflow02FileName = "Workflow2.xml";
        const string Workflow04FileName = "Workflow4.xml";

        void PrepareMocks()
        {
            _restTemplate = new RestTemplateWrapper(BaseUrl);
            ClientSettings.Instance.ServerUrl = BaseUrl;
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
            GivenNewTestRunWithStatusRunningFirstWorkflow(TestRun01Name);

            WhenSendingRegistration(Workflow01TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(1);
            ThenTheClientIsRegistered(0, Workflow01TestConsoleName);
        }

        [Test][Fact]
        public void RegisterSecondClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(TestRun01Name);

            WhenSendingRegistration(Workflow01TestConsoleName);
            WhenSendingRegistration(Workflow01TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(2);
            ThenTheClientIsRegistered(1, Workflow01TestConsoleName);
        }

        [Test][Fact]
        public void RegisterThirdClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(TestRun01Name);

            WhenSendingRegistration(Workflow01TestConsoleName);
            WhenSendingRegistration(Workflow01TestConsoleName);
            WhenSendingRegistration(Workflow01TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(3);
            ThenTheClientIsRegistered(2, Workflow01TestConsoleName);
        }

        [Test][Fact]
        public void RegisterClientsInTheFirstOfTwoTestRuns()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(TestRun01Name);
            GivenSecondTestWorkflow();
            GivenNewTestRunWithStatusRunningSecondWorkflow(TestRun02Name);

            WhenSendingRegistration(Workflow01TestConsoleName);
            WhenSendingRegistration(Workflow01TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(2);
            ThenTheClientIsRegistered(0, Workflow01TestConsoleName);
            ThenTheClientIsRegistered(1, Workflow01TestConsoleName);
        }

        [Test][Fact]
        public void RegisterClientsInTwoTestRuns()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(TestRun01Name);
            GivenFourthTestWorkflow();
            GivenNewTestRunWithStatusRunningFourthWorkflow(TestRun02Name);

            WhenSendingRegistration(Workflow01TestConsoleName);
            WhenSendingRegistration(Workflow04TestConsoleName);

            ThenThereAreTheNumberOfClientsRegistered(2);
            ThenTheClientIsRegistered(0, Workflow01TestConsoleName);
            ThenTheClientIsRegistered(1, Workflow04TestConsoleName);
        }

        [Test][Fact]
        public void UnregisterClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(TestRun01Name);
            GivenSecondTestWorkflow();
            GivenNewTestRunWithStatusRunningSecondWorkflow(TestRun02Name);
            GivenSendingRegistration(Workflow01TestConsoleName);
            GivenSendingRegistration(Workflow01TestConsoleName);

            ClientSettings.Instance.ClientId = ClientsCollection.Clients[1].Id;
            WhenSendingDeregistration();

            ThenThereAreTheNumberOfClientsRegistered(1);
            ThenTheClientIsRegistered(0, Workflow01TestConsoleName);
        }

        [Test][Fact]
        public void UnregisterAllClients()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunningFirstWorkflow(TestRun01Name);
            GivenSecondTestWorkflow();
            GivenNewTestRunWithStatusRunningSecondWorkflow(TestRun02Name);
            GivenSendingRegistration(Workflow01TestConsoleName);
            GivenSendingRegistration(Workflow01TestConsoleName);

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
            CreateTestWorkflow(TestConstants.Workflow01, Workflow01FileName);
        }

        void GivenSecondTestWorkflow()
        {
            CreateTestWorkflow(TestConstants.Workflow02, Workflow02FileName);
        }

        void GivenFourthTestWorkflow()
        {
            CreateTestWorkflow(TestConstants.Workflow04, Workflow04FileName);
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
            workflowLoader.Load(PathToWorkflows + testWorkflowFileName);
        }

        void GivenNewTestRunWithStatusRunningFirstWorkflow(string name)
        {
            NewTestRun(Workflow01Name, name);
        }

        void GivenNewTestRunWithStatusRunningSecondWorkflow(string name)
        {
            NewTestRun(Workflow02Name, name);
        }

        void GivenNewTestRunWithStatusRunningFourthWorkflow(string name)
        {
            NewTestRun(Workflow04Name, name);
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