/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2014
 * Time: 8:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using Spring.Http;
    using Spring.Rest.Client;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    using Tmx.Core;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of StatusSender.
    /// </summary>
    public class StatusSender
    {
        readonly IRestOperations _restTemplate;
        
        public StatusSender(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
        }
        
        public virtual void Send(string status)
        {
            // TODO: add an error handler (??)
            try {
                
                Trace.TraceInformation("Send(string status).1");
                
                // 20141215
                // _restTemplate.Put(UrlList.TestClients_Root + "/" + ClientSettings.Instance.ClientId + "/status", new DetailedStatus(status));
                var detailedStatusSendingResponse = _restTemplate.Exchange(UrlList.TestClients_Root + "/" + ClientSettings.Instance.ClientId + "/status", HttpMethod.PUT, new HttpEntity(new DetailedStatus(status)));
                
                if (HttpStatusCode.OK == detailedStatusSendingResponse.StatusCode)
                    return;
                
                Trace.TraceInformation("Send(string status).2 HttpStatusCode.Created != detailedStatusSendingResponse.StatusCode");
                
                throw new SendingDetailedStatusException("Failed to send detailed status. " + detailedStatusSendingResponse.StatusCode);
                
            }
            catch (RestClientException eSendingDetialedStatus) {
                // TODO: AOP
                Trace.TraceError("Send(string status)");
                Trace.TraceError(eSendingDetialedStatus.Message);
                throw new SendingDetailedStatusException("Failed to send detailed status. " + eSendingDetialedStatus.Message);
            }
        }
    }
}
