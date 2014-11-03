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
	using System.Text;
    using System.Linq;
	using System.Xml.Linq;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;
    using Tmx.Core;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Server;
	using Tmx;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestResultsModule.
    /// </summary>
    public class TestResultsModule : NancyModule
    {
        public TestResultsModule() : base(UrnList.TestResults_Root)
        {
            Post[UrnList.TestResultsPostingPoint_relPath] = parameters => importTestResultsToTestRun(parameters.id);
            
            Get[UrnList.TestResultsPostingPoint_relPath] = parameters => exportTestResultsFromTestRun(parameters.id);
        }

        HttpStatusCode importTestResultsToTestRun(Guid testRunId)
        {
            try {
                var actualBytes = new byte[Request.Body.Length];
                Request.Body.Read(actualBytes, 0, (int)Request.Body.Length);
                var actual = Encoding.UTF8.GetString(actualBytes);
Console.WriteLine(actual);
                var xDoc = XDocument.Parse(actual);
                var currentTestRun = TestRunQueue.TestRuns.First(testRun => testRun.Id == testRunId);
                var testResultsImporter = new TestResultsImportExport();
                currentTestRun.TestSuites.AddRange(testResultsImporter.ImportTestResultsFromXdocument(xDoc));
                // maybe, there's no such need? // TODO: set current test suite, test scenario, test result?
                return HttpStatusCode.Created;
            } catch (Exception eFailedToImportTestResults) {
Console.WriteLine(eFailedToImportTestResults.Message);
                return HttpStatusCode.ExpectationFailed;
            }
        }
        
        // Negotiator exportTestResultsFromTestRun(Guid testRunId)
        Response exportTestResultsFromTestRun(Guid testRunId)
        {
            var testResultsExporter = new TestResultsImportExport();
            var xDoc = testResultsExporter.GetTestResultsAsXdocument(
                           new SearchCmdletBaseDataObject {
                    Descending = false,
                    FilterAll = true,
                    FilterFailed = false,
                    OrderById = true
                },
                           TestRunQueue.TestRuns.FirstOrDefault(testRun => testRun.Id == testRunId).TestSuites);
// 20141101 temp
Console.WriteLine("0000000000000000000000000000003");
if (null == xDoc) {
    Console.WriteLine("null == xDoc");
} else {
    Console.WriteLine("null != xDoc");
}
Console.WriteLine("======================== EXPORTED ========================");
Console.WriteLine(xDoc);
Console.WriteLine(xDoc.Root);
xDoc.Save(@"c:\1\export20141102.xml");
            // return null == xDoc ? Negotiate.WithStatusCode(HttpStatusCode.NotFound) : Negotiate.WithModel(xDoc).WithStatusCode(HttpStatusCode.OK).WithFullNegotiation();
            return Response.AsJson(xDoc.Root);
        }
    }
}
