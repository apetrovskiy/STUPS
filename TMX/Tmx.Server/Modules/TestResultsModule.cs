/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/13/2014
 * Time: 2:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Xml.Linq;
    using Internal;
    using Nancy;
    using Nancy.Json;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using Nancy.TinyIoc;
    using Newtonsoft.Json;
    using Tmx.Core;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces;
    using Tmx.Interfaces.Server;
    using Tmx;
    using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsModule.
    /// </summary>
    public class TestResultsModule : NancyModule
    {
        public TestResultsModule() : base(UrlList.TestResults_Root)
        {
            Post[UrlList.TestResultsPostingPoint_relPath] = parameters => ImportTestResultsToTestRun(parameters.id);
            
            Get[UrlList.TestResultsPostingPoint_relPath] = parameters => ExportTestResultsFromTestRun(parameters.id);
        }
        
        HttpStatusCode ImportTestResultsToTestRun(Guid testRunId)
        {
            try {
                var dataObject = this.Bind<TestResultsDataObject>();
                if (string.IsNullOrEmpty(dataObject.Data))
                    return HttpStatusCode.Created;
                var xDoc = XDocument.Parse(dataObject.Data);
                var currentTestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId);
                // 20150317
                // var testResultsImporter = TinyIoCContainer.Current.Resolve<TestResultsImporter>();
                var testResultsImporter = ServerObjectFactory.Resolve<TestResultsImporter>();
                testResultsImporter.MergeTestPlatforms(currentTestRun.TestPlatforms, testResultsImporter.ImportTestPlatformFromXdocument(xDoc));
                testResultsImporter.MergeTestSuites(currentTestRun.TestSuites, testResultsImporter.ImportTestResultsFromXdocument(xDoc));
                // maybe, there's no such need? // TODO: set current test suite, test scenario, test result?
                return HttpStatusCode.Created;
            } catch (Exception eFailedToImportTestResults) {
                // TODO: AOP
                Trace.TraceError("importTestResultsToTestRun(Guid testRunId)");
                Trace.TraceError(eFailedToImportTestResults.Message);
                return HttpStatusCode.ExpectationFailed;
            }
        }
        
        Negotiator ExportTestResultsFromTestRun(Guid testRunId)
        {
            // 20150317
            // var testResultsExporter = TinyIoCContainer.Current.Resolve<TestResultsExporter>();
            var testResultsExporter = ServerObjectFactory.Resolve<TestResultsExporter>();
            var xDoc = testResultsExporter.GetTestResultsAsXdocument(
                           new SearchCmdletBaseDataObject {
                                Descending = false,
                                FilterAll = true,
                                FilterFailed = false,
                                OrderById = true
                            },
                           TestRunQueue.TestRuns.FirstOrDefault(testRun => testRun.Id == testRunId).TestSuites,
                           TestRunQueue.TestRuns.FirstOrDefault(testRun => testRun.Id == testRunId).TestPlatforms);
            
            var dataObject = new TestResultsDataObject { Data = xDoc.ToString() };
            return null == dataObject ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(dataObject).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
        }
    }
}
