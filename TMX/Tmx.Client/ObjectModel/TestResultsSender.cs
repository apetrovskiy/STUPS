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
	using System.Xml.Linq;
	using Spring.Http;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.TestStructure;
//	using Spring.Http.Converters.Xml;
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
	    readonly IRestOperations _restTemplate; // chrome-extension://aejoelaoggembcahagimdiliamlcdmfm/dhc.html#void
	    
	    public TestResultsSender(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate();
	    }
	    
	    public virtual bool SendTestResults()
	    {
//	        var element =
//	            TmxHelper.GetTestResultsAsXelement(
//	                new SearchCmdletBaseDataObject {
//	                    FilterAll = true
//	                });
	        
	        var testResultsExporter = new TestResultsImportExport();
            // var xDoc = testResultsExporter.GetTestResultsAsXdocument(
            var xElt = testResultsExporter.GetTestResultsAsXelement(
                        new SearchCmdletBaseDataObject {
                            FilterAll = true
                        },
                        TestData.TestSuites);
	        var dataObject = new TestResultsDataObject {
	            // Data = xDoc.ToString()
	            Data = xElt.ToString()
//	            Doc = xDoc
	        };
	        
			try {
				// var sendingResultsResponse = _restTemplate.PostForMessage(UrnList.TestResultsPostingPoint_absPath, element);
				var urn = UrnList.TestResults_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrnList.TestResultsPostingPoint_forClient_relPath;
				// var sendingResultsResponse = _restTemplate.PostForMessage(urn, element);
				
				var sendingResultsResponse = _restTemplate.PostForMessage(urn, dataObject);
//				var sendingResultsResponse = _restTemplate.PostForMessage<List<ITestSuite>>(urn, TestData.TestSuites);
				return HttpStatusCode.Created == sendingResultsResponse.StatusCode;
			}
            catch (Exception eSendingTestResults) {
			    throw new SendingTestResultsException("Failed to send test results. " + eSendingTestResults.Message);
			}
	    }
    }
}
