/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/20/2014
 * Time: 12:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Library.ObjectModel
{
    using System.Diagnostics;
    using System.Net;
    using Core.Types.Remoting;
    using Interfaces.Exceptions;
    using Interfaces.Server;
    using Helpers;
    using Spring.Rest.Client;

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
                
                var loadingReportResponse = _restTemplate.GetForMessage<TestResultsDataObject>(url);
                
                if (null == loadingReportResponse || null == loadingReportResponse.Body)
                    throw new LoadingTestReportException("Failed to receive test results.");
                if (HttpStatusCode.OK != loadingReportResponse.StatusCode)
                    throw new LoadingTestReportException("Failed to receive test results. " + loadingReportResponse.StatusCode);
                
                return loadingReportResponse.Body.Data;
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
