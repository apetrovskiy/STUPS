/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 9:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
	using Spring.Http.Converters.Json;
    // using RestSharp;
	using Spring.Rest.Client;
    
    /// <summary>
    /// Description of RestRequestCreator.
    /// </summary>
    public class RestRequestCreator
    {
        // 20140820
        // move from RestSharp to RestTemplate
        // public virtual RestClient RestClient { get; set; }
        
        // 20140820
        // move from RestSharp to RestTemplate
        // public virtual RestRequest GetRestRequest(string url, Method method)
        public virtual RestTemplate GetRestTemplate(string url)
        {
            // RestClient = new RestClient(ClientSettings.ServerUrl);
//            var clientSettings = ClientSettings.Instance;
            // 20140820
            // move from RestSharp to RestTemplate
//            RestClient = new RestClient(clientSettings.ServerUrl);
//            
//            return new RestRequest(url, method);
            // return new RestTemplate(ClientSettings.Instance.ServerUrl);
            var restTemplate = new RestTemplate(ClientSettings.Instance.ServerUrl);
            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            return restTemplate;
        }
    }
}
