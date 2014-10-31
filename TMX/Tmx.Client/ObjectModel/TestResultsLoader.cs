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
	            var loadingResultsResponse = _restTemplate.GetForMessage<XDocument>(UrnList.TestResultsPostingPoint_absPath);
	            // 20141031
	            // TmxHelper.ImportTestResultsFromXdocumentAndStore(loadingResultsResponse.Body);
	            var testResultsImporter = new TestResultsImporter();
	            TestData.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(loadingResultsResponse.Body));
	            return HttpStatusCode.OK == loadingResultsResponse.StatusCode;
	        }
	        catch (Exception eLoadingTestResults) {
	            throw new LoadingTestResultsException("Failed to receive test results. " + eLoadingTestResults.Message);
	        }
	    }
    }
}
