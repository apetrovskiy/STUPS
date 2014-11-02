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
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using Spring.Rest.Client;
    using Tmx.Core;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Server;
    
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
// 20141101 temp
Console.WriteLine("0000000000000000000000000000001");
				var urn = UrnList.TestResults_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrnList.TestResultsPostingPoint_forClient_relPath;
// 20141101 temp
Console.WriteLine("0000000000000000000000000000002");
Console.WriteLine("client id = " + ClientSettings.Instance.ClientId);
Console.WriteLine("test runid = " + ClientSettings.Instance.CurrentClient.TestRunId);
Console.WriteLine("urn = " + urn);
Console.WriteLine("0000000000000000000000000000002.1");
	            // var loadingResultsResponse = _restTemplate.GetForMessage<XDocument>(UrnList.TestResultsPostingPoint_absPath);
	            var loadingResultsResponse = _restTemplate.GetForMessage<XDocument>(urn);
// 20141101 temp
Console.WriteLine("0000000000000000000000000000003");
if (null == loadingResultsResponse) {
    Console.WriteLine("null == loadingResultsResponse");
} else {
    Console.WriteLine("null != loadingResultsResponse");
}
Console.WriteLine(loadingResultsResponse);
Console.WriteLine(loadingResultsResponse.Body);
Console.WriteLine(loadingResultsResponse.Body.Root);
	            // 20141031
	            // TmxHelper.ImportTestResultsFromXdocumentAndStore(loadingResultsResponse.Body);
	            var testResultsImporter = new TestResultsImportExport();
// 20141101 temp
Console.WriteLine("0000000000000000000000000000004");
if (null == TestData.TestSuites) {
    Console.WriteLine("null == TestData.TestSuites");
} else {
    Console.WriteLine("null != TestData.TestSuites");
}
if (null == testResultsImporter.ImportTestResultsFromXdocument(loadingResultsResponse.Body)) {
    Console.WriteLine("null == testResultsImporter.ImportTestResultsFromXdocument(loadingResultsResponse.Body)");
} else {
    Console.WriteLine("null != testResultsImporter.ImportTestResultsFromXdocument(loadingResultsResponse.Body)");
}
	            TestData.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(loadingResultsResponse.Body));
// 20141101 temp
Console.WriteLine("0000000000000000000000000000005");
	            return HttpStatusCode.OK == loadingResultsResponse.StatusCode;
	        }
	        catch (Exception eLoadingTestResults) {
	            throw new LoadingTestResultsException("Failed to receive test results. " + eLoadingTestResults.Message);
	        }
	    }
    }
}
