/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2014
 * Time: 9:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
	using System.Collections.Generic;
	using System.Net;
	using Spring.Rest.Client;
	using TMX.Interfaces.Server;
    
    /// <summary>
    /// Description of CommonDataLoader.
    /// </summary>
    public class CommonDataLoader
    {
        readonly RestTemplate _restTemplate;
        
        public CommonDataLoader(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate(string.Empty);
        }
        
        public Dictionary<string, object> Load()
        {
			var commonDataResponse = _restTemplate.GetForMessage<Dictionary<string, object>>(UrnList.CommonDataLoadingPoint);
			var commonData = commonDataResponse.Body;
			return HttpStatusCode.NotFound == commonDataResponse.StatusCode ? null : commonData;
        }
    }
}
