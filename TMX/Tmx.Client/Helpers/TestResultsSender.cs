/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/28/2014
 * Time: 4:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
	using System;
	using System.Net;
	using System.Xml.Linq;
	using Spring.Http;
	using Spring.Http.Converters.Xml;
	using Spring.Rest.Client;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Exceptions;
	using Tmx.Interfaces.Server;
	
    /// <summary>
    /// Description of TestResultsSender.
    /// </summary>
    public class TestResultsSender
    {
	    // volatile RestTemplate _restTemplate;
	    readonly RestTemplate _restTemplate;
	    
	    public TestResultsSender(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate();
	    }
	    
	    public virtual bool SendTestResults()
	    {
	        var element =
	            TmxHelper.GetTestResultsAsXelement(
	                new SearchCmdletBaseDataObject {
	                    FilterAll = true
	                });
	        
			try {
				_restTemplate.MessageConverters.Add(new XElementHttpMessageConverter());
				var sendingResultsResponse = _restTemplate.PostForMessage(UrnList.TestResultsPostingPoint, element);
				return HttpStatusCode.Created == sendingResultsResponse.StatusCode;
			}
            catch (Exception eSendingTestResults) {
			    throw new SendingTestResultsException("Failed to send test results. " + eSendingTestResults.Message);
			}
	    }
    }
}
