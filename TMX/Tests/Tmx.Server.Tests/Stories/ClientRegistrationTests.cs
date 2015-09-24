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
    using NUnit.Framework;
    using Spring.Http;
    using Spring.Rest.Client;
    using Xunit;

    public class ClientRegistrationTests
    {
        RestTemplateWrapper _restTemplate;
        RestRequestCreator _restRequestCreator;

        void PrepareMocks()
        {
            _restTemplate = new RestTemplateWrapper("http://localhost:12340");
            // _restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            //_mockRestServer = MockRestServiceServer.CreateServer(_restTemplate);
            //_responseHeaders = new HttpHeaders { ContentType = new MediaType("application", "json") };
            //ClientSettings.Instance.ServerUrl = BaseUrl;
            _restRequestCreator = new RestRequestCreator();
            _restRequestCreator.SetRestTemplate(_restTemplate);
            RestRequestFactory.RestRequestCreator = _restRequestCreator;
        }

        [Test][Fact]
        public void RegisterFirstClient()
        {
            GivenFirstTestWorkflow();
            GivenNewTestRunWithStatusRunning();

            WhenSendingRegistration("testConsole");

            ThenTheClientIsRegistered();
        }

        void GivenFirstTestWorkflow()
        {
            // 
            var serverCommand = new ServerCommand
            {
                Command = ServerControlCommands.LoadConfiguraiton,
                Data = TestConstants.Workflow01
            };
            /*
            _browser.Put(UrlList.ServerControlPoint_absPath, with =>
            {
                with.JsonBody(serverCommand);
                with.Accept("application/json");
            });
            */
            var restTemplateWrapper = new RestTemplateWrapper("http://localhost:12340");
            restTemplateWrapper.Put(UrlList.ServerControlPoint_absPath, serverCommand);
        }

        void GivenNewTestRunWithStatusRunning()
        {
            // TODO: create a workflow!
            // var testRunCreator = new TestRunCreator();
            var testRunCreator = ProxyFactory.Get<TestRunCreator>();
            testRunCreator.CreateTestRun("w", TestRunStatuses.Running, "t");
        }

        Guid WhenSendingRegistration(string customString)
        {
            // 
            // var registration = new Registration();
            var registration = ProxyFactory.Get<Registration>();
            return registration.SendRegistrationInfoAndGetClientId(customString);
        }

        void ThenTheClientIsRegistered()
        {
            
        }
    }
}