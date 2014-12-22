/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2014
 * Time: 4:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using Nancy;
    using Nancy.Responses.Negotiation;
    using Nancy.TinyIoc;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of TestReportsModule.
    /// </summary>
    public class TestReportsModule : NancyModule
    {
        public TestReportsModule()
        {
            Get[UrlList.TestReports_LoadingPoint] = parameters => exportTestResultsFromTestRunAsHtmlPage(parameters.id);
        }
        
        Negotiator exportTestResultsFromTestRunAsHtmlPage(Guid testRunId)
        {
            var basePath = (new TmxServerRootPathProvider()).GetRootPath() + @"/Views/testRuns/";
            var testReportsExporter = TinyIoCContainer.Current.Resolve<TestReportsExporter>(new NamedParameterOverloads { { "basePath", basePath } });
            var reportPage = testReportsExporter.GetReportPage(testRunId, UrlList.ViewTestRuns_ResultsPageName);
            // var dataObject = new TestResultsDataObject { Data = reportPage };
            // return null == dataObject ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(dataObject).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
            return null == reportPage ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(reportPage).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
        }
    }
}
