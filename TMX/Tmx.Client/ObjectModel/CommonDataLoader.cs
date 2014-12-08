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
	using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of CommonDataLoader.
    /// </summary>
    public class CommonDataLoader
    {
        readonly IRestOperations _restTemplate;
        
        public CommonDataLoader(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
        }
        
        public virtual Dictionary<string, string> Load()
        {
            var urn = UrlList.TestData_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrlList.TestData_CommonData_forClient_relPath;
            var commonDataResponse = _restTemplate.GetForMessage<Dictionary<string, string>>(urn);
            var commonData = commonDataResponse.Body;
            return HttpStatusCode.NotFound == commonDataResponse.StatusCode ? new Dictionary<string, string>() : commonData;
        }
    }
}
