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
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Server;
    using Tmx.Core;
	using System.Collections.Generic;
    
    /// <summary>
    /// Description of CommonDataSender.
    /// </summary>
    public class CommonDataSender
    {
        readonly IRestOperations _restTemplate;
        
        public CommonDataSender(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
        }
        
        public virtual void Send(ICommonDataItem item)
        {
            // TODO: add an error handler
			// var dataItemSendingResponse = _restTemplate.PostForMessage(UrnList.CommonDataLoadingPoint_absPath, item);
			var urn = UrnList.TestData_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrnList.TestData_CommonData_forClient_relPath;
			var dataItemSendingResponse = _restTemplate.PostForMessage(urn, item);
			if (HttpStatusCode.Created == dataItemSendingResponse.StatusCode)
				return;
			throw new SendingCommonDataItemException("Failed to send data item. "+ dataItemSendingResponse.StatusCode);
        }
    }
}
