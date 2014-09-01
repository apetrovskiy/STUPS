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
	using System.Collections.Generic;
	using System.Net;
	using System.Xml;
	using System.Xml.Linq;
	using Spring.Http;
	using Spring.Http.Converters;
	using Spring.Http.Converters.Xml;
	using Spring.Rest.Client;
	using TMX.Interfaces;
	using TMX.Interfaces.Exceptions;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces.TestStructure;
//	using Tmx.Interfaces.Remoting;
	
    /// <summary>
    /// Description of TestResultsSender.
    /// </summary>
    public class TestResultsSender
    {
	    volatile RestTemplate _restTemplate;
	    
	    public TestResultsSender(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate(string.Empty);
	    }
	    
	    public bool SendTestResults()
	    {
	        var document =
	            TmxHelper.GetTestResultsAsXdocument(
	                new SearchCmdletBaseDataObject {
	                    FilterAll = true
	                });
			try {
				var parts = new Dictionary<string, object>();
Console.WriteLine("sending 000001");
				var entity = new HttpEntity(document.Root.ToString());
Console.WriteLine(document.Root.ToString());
Console.WriteLine("sending 000002");
				entity.Headers["Content-Type"] = "text/plain";
Console.WriteLine("sending 000003");
				parts.Add("data", entity);
Console.WriteLine("sending 000004");
				_restTemplate.PostForLocation(UrnList.TestStructure_Root + UrnList.TestStructure_AllResults, parts);
Console.WriteLine("sending 000005");
				return true;
			}
            catch (Exception eSendingTestResults) {
			    throw new SendingTestResultsException("Failed to send test results. " + eSendingTestResults.Message);
			}
	    }
    }
}
