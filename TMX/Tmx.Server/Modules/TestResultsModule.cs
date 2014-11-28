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
    using System.IO;
	using System.Text;
    using System.Linq;
	using System.Xml.Linq;
    using Nancy;
    using Nancy.Json;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
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
            Post[UrlList.TestResultsPostingPoint_relPath] = parameters => importTestResultsToTestRun(parameters.id);
            
            Get[UrlList.TestResultsPostingPoint_relPath] = parameters => exportTestResultsFromTestRun(parameters.id);
        }

//        HttpStatusCode importTestResultsToTestRun(Guid testRunId)
//        {
//            try {
//                var actualBytes = new byte[Request.Body.Length];
//                Request.Body.Read(actualBytes, 0, (int)Request.Body.Length);
//                var actual = Encoding.UTF8.GetString(actualBytes);
//                var xDoc = XDocument.Parse(actual);
//                var currentTestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId);
//                var testResultsImporter = new TestResultsImportExport();
//                currentTestRun.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(xDoc));
//                // maybe, there's no such need? // TODO: set current test suite, test scenario, test result?
//                return HttpStatusCode.Created;
//            } catch (Exception eFailedToImportTestResults) {
//                return HttpStatusCode.ExpectationFailed;
//            }
//        }
        
        HttpStatusCode importTestResultsToTestRun(Guid testRunId)
        {
            try {
                var dataObject = this.Bind<TestResultsDataObject>();
                // 20141109
                // experimental
                if (string.IsNullOrEmpty(dataObject.Data))
                    return HttpStatusCode.Created;
                var xDoc = XDocument.Parse(dataObject.Data);
                var currentTestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId);
                var testResultsImporter = new TestResultsImporter();
                // 20141113
                // currentTestRun.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(xDoc));
                testResultsImporter.MergeTestPlatforms(currentTestRun.TestPlatforms, testResultsImporter.ImportTestPlatformFromXdocument(xDoc));
                testResultsImporter.MergeTestSuites(currentTestRun.TestSuites, testResultsImporter.ImportTestResultsFromXdocument(xDoc));
                // maybe, there's no such need? // TODO: set current test suite, test scenario, test result?
                return HttpStatusCode.Created;
            } catch (Exception eFailedToImportTestResults) {
                return HttpStatusCode.ExpectationFailed;
            }
        }
        
        Negotiator exportTestResultsFromTestRun(Guid testRunId)
        {
            var testResultsExporter = new TestResultsExporter();
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
