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
	using Spring.Rest.Client;
    
    /// <summary>
    /// Description of RestRequestCreator.
    /// </summary>
    public class RestRequestCreator
    {
        public virtual RestTemplate GetRestTemplate()
        {
            var restTemplate = new RestTemplate(ClientSettings.Instance.ServerUrl);
            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            return restTemplate;
        }
    }
}
