namespace Tmx.Client.Library.Abstract
{
    using Spring.Rest.Client;

    public interface IRestRequestCreator
    {
        RestTemplate GetRestTemplate();
        // void SetRestTemplate(RestTemplate restTemplate);
        void SetRestTemplate(IRestOperations restTemplate);
    }
}