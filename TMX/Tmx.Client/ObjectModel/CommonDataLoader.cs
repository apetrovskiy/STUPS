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
    using System.Diagnostics;
    using System.Net;
    using Spring.Rest.Client;
    using Interfaces.Server;
    
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
            var url = UrlList.TestData_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrlList.TestData_CommonData_forClient_relPath;
            
            // 20141211
            // TODO: AOP
            Trace.TraceInformation("Load(): testRun id = {0}, url = {1}", ClientSettings.Instance.CurrentClient.TestRunId, url);
            
            var commonDataResponse = _restTemplate.GetForMessage<Dictionary<string, string>>(url);
            
            Trace.TraceInformation("commonDataResponse is null? {0}", null == commonDataResponse);
            // 20150316
            if (null == commonDataResponse)
                throw new Exception("Failed to load data item");
            
            var commonData = commonDataResponse.Body;
            
            Trace.TraceInformation("commonData is null? {0}", null == commonData);
            
            return HttpStatusCode.NotFound == commonDataResponse.StatusCode ? new Dictionary<string, string>() : commonData;
        }
    }
}
