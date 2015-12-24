namespace Tmx.Server.SamplePlugin
{
    using Core.Types.Remoting;
    using Interfaces.Server;
    using Logic.Internal;
    using Logic.ObjectModel;
    using Nancy;

    public class ShortcutModule : NancyModule
    {
        public ShortcutModule() : base("/")
        {
            Get["start/{" + UrlList.TestRuns_DefaultParameterName + "}"] = parameters => CreateNewDefaultTestRun(parameters);
        }

        public HttpStatusCode CreateNewDefaultTestRun(DynamicDictionary parameters)
        {
            var testRunCollectionMethods = ServerObjectFactory.Resolve<TestRunCollectionMethods>();
            if (string.IsNullOrEmpty(parameters[UrlList.TestRuns_DefaultParameterName]))
                return HttpStatusCode.ExpectationFailed;
            if (string.IsNullOrEmpty(Defaults.Workflow))
                return HttpStatusCode.ExpectationFailed;
            return !testRunCollectionMethods.SetTestRunDataAndCreateTestRun(new TestRunCommand
            {
                TestRunName = Defaults.Workflow,
                WorkflowName = Defaults.Workflow
            }, parameters)
                ? HttpStatusCode.ExpectationFailed
                : HttpStatusCode.Created;
        }
    }
}