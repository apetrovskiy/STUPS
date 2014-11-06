/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/22/2014
 * Time: 8:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using Spring.Rest.Client;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsLoader.
    /// </summary>
    public class TestResultsLoader
    {
        readonly IRestOperations _restTemplate;
	    
	    public TestResultsLoader(RestRequestCreator requestCreator)
	    {
	    	_restTemplate = requestCreator.GetRestTemplate();
	    }
	    
	    public virtual bool LoadTestResults()
	    {
	        try {
				var urn = UrnList.TestResults_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrnList.TestResultsPostingPoint_forClient_relPath;
//	            var loadingResultsResponse = _restTemplate.GetForMessage<XDocument>(urn);
//	            var testResultsImporter = new TestResultsImportExport();
//	            TestData.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(loadingResultsResponse.Body));
	            
//	            var loadingResultsResponse = _restTemplate.GetForMessage<List<ITestSuite>>(urn);
//	            TestData.TestSuites.AddRange(loadingResultsResponse.Body);
	            
				var loadingResultsResponse = _restTemplate.GetForMessage<TestResultsDataObject>(urn);
				var testResultsImporter = new TestResultsImportExport();
				var xDoc = XDocument.Parse(loadingResultsResponse.Body.Data);
				TestData.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(xDoc));
	            
//				var loadingResultsResponse = _restTemplate.GetForMessage<TestResultsDataObject>(urn);
//				var testResultsImporter = new TestResultsImportExport();
//				var xElt = XElement.Parse(loadingResultsResponse.Body.Data);
//				var xDoc = new XDocument(xElt);
//				TestData.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(xDoc));
				
//				var loadingResultsResponse = _restTemplate.GetForMessage<TestResultsDataObject>(urn);
//				TestData.TestSuites.AddRange(loadingResultsResponse.Body.Data);
				
//				var loadingResultsResponse = _restTemplate.GetForMessage<TestResultsDataObject>(urn);
//				var stringData = loadingResultsResponse.Body.Data;
//				var suites = stringData.DeserializeFromString<List<ITestSuite>>();
//				TestData.TestSuites.AddRange(suites);
				
//				var loadingResultsResponse = _restTemplate.GetForMessage<TestResultsDataObject>(urn);
//				var stringData = loadingResultsResponse.Body.Data;
//				var xDoc = stringData.DeserializeFromString();
//				var testResultsImporter = new TestResultsImportExport();
//				// TestData.TestSuites.AddRange(suites);
//				TestData.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(xDoc));
				
//				var loadingResultsResponse = _restTemplate.GetForMessage<TestResultsDataObject>(urn);
//				var testResultsImporter = new TestResultsImportExport();
//				TestData.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(loadingResultsResponse.Body.Doc));
				
//				var loadingResultsResponse = _restTemplate.GetForMessage<List<ITestSuite>>(urn);
//				var testResultsImporter = new TestResultsImportExport();
//				var list = loadingResultsResponse.Body;
////				var newList = new List<ITestSuite>();
////				foreach (var suite in list) {
////				    newList.Add(suite);
////				}
////				TestData.TestSuites.AddRange(newList);
//				TestData.TestSuites.AddRange(list);
				
	            return HttpStatusCode.OK == loadingResultsResponse.StatusCode;
	        }
	        // catch (Exception eLoadingTestResults) {
	        catch (RestClientException eLoadingTestResults) {
	            throw new LoadingTestResultsException("Failed to receive test results. " + eLoadingTestResults.Message);
	        }
	    }
    }
}
