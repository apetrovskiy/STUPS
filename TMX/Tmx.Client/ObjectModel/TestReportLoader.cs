/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2014
 * Time: 12:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using Spring.Rest.Client;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of TestReportLoader.
    /// </summary>
    public class TestReportLoader
    {
        readonly IRestOperations _restTemplate;
        
        public TestReportLoader(RestRequestCreator requestCreator)
        {
            _restTemplate = requestCreator.GetRestTemplate();
        }
        
        public virtual string LoadTestReport()
        {
            try {
                var url = UrlList.TestReports_Root + "/" + ClientSettings.Instance.CurrentClient.TestRunId + UrlList.TestReports_LoadingPoint_relPath;
                
                // 20141211
                // TODO: AOP
                Trace.TraceInformation("LoadTestReport().1: testRun id = {0}, url = {1}", ClientSettings.Instance.CurrentClient.TestRunId, url);
                
                
                var loadingReportResponse = _restTemplate.GetForMessage<string>(url);
                
                Trace.TraceInformation("LoadTestReport).2: loadingResultsResponse is null?{0}", null == loadingReportResponse);
                
                if (null == loadingReportResponse || null == loadingReportResponse.Body || HttpStatusCode.OK != loadingReportResponse.StatusCode)
                    throw new LoadingTestReportException("Failed to receive test results. " + loadingReportResponse.StatusCode);
                
                // return HttpStatusCode.OK == loadingReportResponse.StatusCode;
                return loadingReportResponse.Body;
	        }
	        catch (RestClientException eLoadingTestResults) {
                // TODO: AOP
                Trace.TraceError("LoadTestReport()");
                Trace.TraceError(eLoadingTestResults.Message);
                throw new LoadingTestReportException("Failed to receive test results. " + eLoadingTestResults.Message);
            }
        }
    }
}
