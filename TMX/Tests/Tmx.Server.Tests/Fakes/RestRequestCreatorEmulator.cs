namespace Tmx.Server.Tests.Fakes
{
    using Client.Library.Abstract;
    using Spring.Rest.Client;

    public class RestRequestCreatorEmulator :IRestRequestCreator
    {
        IRestOperations _restTemplate;

        // public RestTemplate GetRestTemplate()
        public IRestOperations GetRestTemplate()
        {
            return _restTemplate;
        }

        public void SetRestTemplate(IRestOperations restTemplate)
        {
            _restTemplate = restTemplate;
        }
    }
}