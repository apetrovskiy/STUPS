/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2014
 * Time: 4:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using DotLiquid.Util;

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
            Get[UrlList.TestReports_LoadingPoint] = parameters => ExportTestResultsFromTestRunAsHtmlPage(parameters.id);
        }
        
        Negotiator ExportTestResultsFromTestRunAsHtmlPage(Guid testRunId)
        {
            var basePath = (new TmxServerRootPathProvider()).GetRootPath() + @"/Views/testRuns/";
            // 20150317
            // TODO: proxify
            var testReportsExporter = TinyIoCContainer.Current.Resolve<TestReportsExporter>(new NamedParameterOverloads { { "basePath", basePath } });
            var reportPage = testReportsExporter.GetReportPage(testRunId, UrlList.ViewTestRuns_ResultsPageName);
            var dataObject = new TestResultsDataObject { Data = reportPage };
            // 20150322
            // return null == dataObject ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(dataObject).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
            return null == dataObject.Data ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(dataObject).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
        }
    } 
}
