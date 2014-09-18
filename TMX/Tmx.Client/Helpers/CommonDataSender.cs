/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/18/2014
 * Time: 4:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using System.Net;
	using Spring.Rest.Client;
    using TMX.Interfaces.Remoting;
	using TMX.Interfaces.Server;
    using Tmx.Core;
    using System;
	using System.Collections.Generic;
    
    /// <summary>
    /// Description of CommonDataSender.
    /// </summary>
    public class CommonDataSender
    {
        readonly RestTemplate _restTemplate;
        
        public CommonDataSender(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
        }
        
        public virtual void Send(ICommonDataItem item)
        {
            // TODO: add an error handler
			var dataItemSendingResponse = _restTemplate.PostForMessage(UrnList.CommonDataLoadingPoint, item);
			if (HttpStatusCode.Created == dataItemSendingResponse.StatusCode)
				return;
			throw new Exception("Failed to send data item. "+ dataItemSendingResponse.StatusCode); // TODO: new type!
        }
    }
}
