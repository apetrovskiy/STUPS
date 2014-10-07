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
        RestTemplate _restTemplate;
        
        public virtual RestTemplate GetRestTemplate()
        {
            if (null == _restTemplate)
                _restTemplate = new RestTemplate(ClientSettings.Instance.ServerUrl);
            _restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            return _restTemplate;
        }
        
        public virtual void SetRestTemplate(RestTemplate restTemplate)
        {
            _restTemplate = restTemplate;
        }
    }
}
