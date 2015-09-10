/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/27/2014
 * Time: 3:24 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.Modules
{
    using System;
    using System.Dynamic;
    using System.Linq;
    using Core;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Logic.Internal;
    using Logic.ObjectModel;
    using Logic.ObjectModel.Objects;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Responses.Negotiation;

    /// <summary>
    /// Description of TestRunsModule.
    /// </summary>
    public class TestRunsModule : NancyModule
    {
        public TestRunsModule() : base(UrlList.TestRuns_Root)
        {
            Post[UrlList.TestRunsControlPoint_relPath] = _ => CreateNewTestRun(this.Bind<TestRunCommand>());
            Post[UrlList.TestRunsControlPoint_newDefaultTestRunWithParam] = parameters => CreateNewDefaultTestRun(parameters);
            Delete[UrlList.TestRuns_One_relPath] = parameters => DeleteTestRun(parameters.id);
            
            // http://blog.nancyfx.org/x-http-method-override-with-nancyfx/
            Put[UrlList.TestRuns_One_Cancel] = parameters => CancelTestRun(parameters.id);
            Get[UrlList.TestRuns_One_relPath] = parameters => GetTestRun(parameters.id);
            Get[UrlList.TestRunsControlPoint_relPath] = _ => GetAllTestRuns();
        }
        
        Negotiator CreateNewTestRun(ITestRunCommand testRunCommand)
        {
            var testRunCollectionMethods = ServerObjectFactory.Resolve<TestRunCollectionMethods>();
            return !testRunCollectionMethods.SetTestRunDataAndCreateTestRun(testRunCommand, Request.Form) ? 
                Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithReasonPhrase(ServerLibrary.ReasonPhrase_TestRunsModule_FailedToCreateTestRun) :
                // 20150825
                // GetTestRunCollectionExpandoObject();
                GetTestRunCollectionExpandoObject(testRunCollectionMethods.CurrentTestRunId);
        }
        
        protected Negotiator CreateNewDefaultTestRun(DynamicDictionary parameters)
        {
            var testRunCollectionMethods = ServerObjectFactory.Resolve<TestRunCollectionMethods>();
            
            if (string.IsNullOrEmpty(parameters[UrlList.TestRuns_DefaultParameterName]))
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithReasonPhrase(ServerLibrary.ReasonPhrase_TestRunsModule_ThereHasNotBeenSuppliedTheDefaultParameter);
            
            if (string.IsNullOrEmpty(Defaults.Workflow))
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithReasonPhrase(ServerLibrary.ReasonPhrase_TestRunsModule_ThereIsNoDefaultWorkflow);
            return !testRunCollectionMethods.SetTestRunDataAndCreateTestRun(new TestRunCommand {
                                                                                TestRunName = Defaults.Workflow,
                                                                                WorkflowName = Defaults.Workflow
                                                                            }, parameters) ? 
                Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithReasonPhrase(ServerLibrary.ReasonPhrase_TestRunsModule_FailedToCreateTestRun) :
                // 20150825
                // GetTestRunCollectionExpandoObject();
                GetTestRunCollectionExpandoObject(testRunCollectionMethods.CurrentTestRunId);
        }
        
        // Negotiator GetTestRunCollectionExpandoObject()
        Negotiator GetTestRunCollectionExpandoObject(Guid currentTestRunId)
        {
            var testRunCollectionMethods = ServerObjectFactory.Resolve<TestRunCollectionMethods>();
            dynamic data = testRunCollectionMethods.CreateTestRunExpandoObject();
            data.NewTestRunId = currentTestRunId;
            return Negotiate
                .WithStatusCode(HttpStatusCode.Created)
                .WithView(UrlList.ViewTestRuns_TestRunsPageName)
                .WithModel((ExpandoObject)data)
                .WithHeader(Tmx_Core_Resources.NewTestRun_lastTestRunId, currentTestRunId.ToString());
        }
        
        Negotiator DeleteTestRun(Guid testRunId)
        {
            ServerObjectFactory.Resolve<TestRunCollectionMethods>().DeleteTestRun(testRunId);
            return Negotiate.WithStatusCode(HttpStatusCode.OK);
        }
        
        Negotiator CancelTestRun(Guid testRunId)
        {
            var testRunCollectionMethods = ServerObjectFactory.Resolve<TestRunCollectionMethods>();
            testRunCollectionMethods.CancelTestRun(testRunId);
            var data = testRunCollectionMethods.CreateTestRunExpandoObject();
            // data.NewTestRunId = testRunId;
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
        }

        Negotiator GetTestRun(Guid testRunId)
        {
            var requestedTestRun = TestRunQueue.TestRuns.FirstOrDefault(testRun => testRun.Id == testRunId);
            return null == requestedTestRun || Guid.Empty == requestedTestRun.Id
                ? Negotiate.WithStatusCode(HttpStatusCode.NotFound).WithReasonPhrase(string.Format(ServerLibrary.ReasonPhrase_TestRunsModule_FailedToFindTestRunWithId, testRunId))
                : Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(requestedTestRun);
        }

        Negotiator GetAllTestRuns()
        {
            return null == TestRunQueue.TestRuns || !TestRunQueue.TestRuns.Any()
                ? Negotiate.WithStatusCode(HttpStatusCode.NotFound).WithReasonPhrase(ServerLibrary.ReasonPhrase_TestRunsModule_ThereAreNoTestRuns)
                : Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(TestRunQueue.TestRuns);
        }
    }
    
    public class DefaultTestRunParameters : DynamicDictionary
    {
        public string Default { get; set; }
    }
}
