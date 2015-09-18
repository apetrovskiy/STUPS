/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Library.Helpers
{
    using Abstract;
    using Spring.Http.Client;
    using Spring.Http.Converters;
    using Spring.Http.Converters.Json;
    using Spring.Http.Converters.Xml;
    using Spring.Rest.Client;

    /// <summary>
    /// Description of RestRequestCreator.
    /// </summary>
    public class RestRequestCreator : IRestRequestCreator
    {
        RestTemplate _restTemplate;
        //static RestRequestCreator _restRequestCreator;

        //private RestRequestCreator()
        //{
        //    _restRequestCreator = this;
        //}

        //public static RestRequestCreator GetInstance()
        //{
        //    return _restRequestCreator;
        //}
        
        public virtual RestTemplate GetRestTemplate()
        {
            if (null != _restTemplate) return _restTemplate;
            _restTemplate = new RestTemplate(ClientSettings.Instance.ServerUrl);
            _restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            _restTemplate.MessageConverters.Add(new XElementHttpMessageConverter());
            _restTemplate.MessageConverters.Add(new XmlSerializableHttpMessageConverter());
            _restTemplate.MessageConverters.Add(new ResourceHttpMessageConverter());
            _restTemplate.MessageConverters.Add(new StringHttpMessageConverter());
            var requestFactory = new WebClientHttpRequestFactory {Timeout = 600000};
            _restTemplate.RequestFactory = requestFactory;
            return _restTemplate;
        }
        
        public virtual void SetRestTemplate(RestTemplate restTemplate)
        {
            _restTemplate = restTemplate;
        }
    }
}
