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
    using System.Diagnostics;
    using System.Dynamic;
    using Core.Types.Remoting;
    using Interfaces.Remoting;
    using Interfaces.Server;
    using Logic.Internal;
    using Logic.ObjectModel;
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
            Post[UrlList.TestRunsControlPoint_newDefaultTestRun] = parameters => CreateNewDefaultTestRun(parameters);
            // Post[UrlList.TestRunsControlPoint_newDefaultTestRun] = _ => CreateNewDefaultTestRun();
            Delete[UrlList.TestRuns_One_relPath] = parameters => DeleteTestRun(parameters.id);
            
            // http://blog.nancyfx.org/x-http-method-override-with-nancyfx/
            Put[UrlList.TestRuns_One_Cancel] = parameters => CancelTestRun(parameters.id);
        }
        
        Negotiator CreateNewTestRun(ITestRunCommand testRunCommand)
        {
            var testRunCollectionMethods = ServerObjectFactory.Resolve<TestRunCollectionMethods>();
            testRunCollectionMethods.SetTestRun(testRunCommand, Request.Form);
            var data = testRunCollectionMethods.CreateTestRunExpandoObject();
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
        }

        Negotiator CreateNewDefaultTestRun(DynamicDictionary parameters)
        {
//Trace.TraceInformation("parameters:");
//if (null == parameters)
//    Trace.TraceInformation("null!!!!!!!!!!!!!!!!!");
//else
//    if (0 == parameters.Count)
//        Trace.TraceInformation("000000000000");

            var testRunCollectionMethods = ServerObjectFactory.Resolve<TestRunCollectionMethods>();
            // testRunCollectionMethods.SetTestRun(parameters);
            testRunCollectionMethods.SetTestRun(new TestRunCommand { TestRunName = Defaults.Workflow, WorkflowName = Defaults.Workflow }, parameters);
            var data = testRunCollectionMethods.CreateTestRunExpandoObject();
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
        }
        
//        Negotiator CreateNewDefaultTestRun()
//        {
//            var testRunParameters = this.Bind<DefaultTestRunParameters>();
//            var testRunCollectionMethods = ServerObjectFactory.Resolve<TestRunCollectionMethods>();
//            // testRunCollectionMethods.SetTestRun(parameters);
//            var dictionary = new DynamicDictionary();
//            dictionary.Add("Default", testRunParameters.Default);
//            testRunCollectionMethods.SetTestRun(new TestRunCommand { TestRunName = Defaults.Workflow, WorkflowName = Defaults.Workflow }, dictionary);
//            var data = testRunCollectionMethods.CreateTestRunExpandoObject();
//            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
//        }
        
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
            return Negotiate.WithStatusCode(HttpStatusCode.OK).WithView(UrlList.ViewTestRuns_TestRunsPageName).WithModel((ExpandoObject)data);
        }
    }
    
    public class DefaultTestRunParameters : DynamicDictionary
    {
        public string Default { get; set; }
    }
}
