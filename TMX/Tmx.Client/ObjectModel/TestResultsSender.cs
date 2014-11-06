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
            var xDoc = testResultsExporter.GetTestResultsAsXdocument(
                        new SearchCmdletBaseDataObject {
                            FilterAll = true
                        },
                        TestData.TestSuites);

//if (null == TestData.TestSuites)
//    Console.WriteLine("null == TestData.TestSuites");
//else
//    Console.WriteLine("null != TestData.TestSuites");

	        var dataObject = new TestResultsDataObject {
	            Data = xDoc.ToString()
	            // Data = xElt.ToString()
//	            Doc = xDoc
	            // Data = (TestData.TestSuites ?? new List<ITestSuite>()).SerializeToString<List<ITestSuite>>()
	            // Data = 
	            // Data = xDoc.SerializeToString()
	        };
	        
//Console.WriteLine(dataObject.Data);
	        
			try {
				// var sendingResultsResponse = _restTemplate.PostForMessage(UrnList.TestResultsPostingPoint_absPath, element);
				var urn = UrnList.TestResults_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrnList.TestResultsPostingPoint_forClient_relPath;
				// var sendingResultsResponse = _restTemplate.PostForMessage(urn, element);
				
				/*
				// example
                var fileContentAndPaths = new Dictionary<string, object> {
                    { "file", new HttpEntity(new FileInfo(sourceFilePath)) },
                    { "relativePath", new HttpEntity(sourceFilePath.Substring(sourceFolderPath.Length)) },
                    { "destinationPath", new HttpEntity(destinationPath) }
                };
                var fileUploadResponse = _restTemplate.PostForMessage(UrnList.ExternalFiles_Root + UrnList.ExternalFilesUploadPoint_relPath, fileContentAndPaths);
    				// example
                HttpHeaders headers = new HttpHeaders();
                headers.setContentType(MediaType.APPLICATION_JSON);
                HttpEntity<String> entity = new HttpEntity<String>(requestJson,headers);
                restTemplate.put(uRL, entity);
                */
                var headers = new HttpHeaders();
                headers.ContentType = MediaType.APPLICATION_JSON;
                headers.Accept = new[]{ MediaType.APPLICATION_JSON };
                var entity = new HttpEntity(dataObject, headers);
				// var sendingResultsResponse = _restTemplate.PostForMessage<TestResultsDataObject>(urn, dataObject, entity);
				// var sendingResultsResponse = _restTemplate.PostForMessage<TestResultsDataObject>(urn, entity);
				// var sendingResultsResponse = _restTemplate.PostForMessage<TestResultsDataObject>(urn, dataObject);
				var sendingResultsResponse = _restTemplate.PostForMessage(urn, dataObject);
//				var sendingResultsResponse = _restTemplate.PostForMessage<List<ITestSuite>>(urn, TestData.TestSuites);
				return HttpStatusCode.Created == sendingResultsResponse.StatusCode;
			}
            // catch (Exception eSendingTestResults) {
            catch (RestClientException eSendingTestResults) {
//Console.WriteLine(eSendingTestResults.GetType().Name);
//Console.WriteLine(eSendingTestResults.Message);
			    throw new SendingTestResultsException("Failed to send test results. " + eSendingTestResults.Message);
			}
	    }
    }
}
