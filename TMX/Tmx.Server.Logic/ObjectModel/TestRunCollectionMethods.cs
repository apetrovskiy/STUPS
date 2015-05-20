namespace Tmx.Server.Logic.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using Core.Types.Remoting;
    using Internal;
    using Nancy;
    using Objects;
    using Tmx.Interfaces.Remoting;
    using Core;

    public class TestRunCollectionMethods
    {
        public void SetTestRun(ITestRunCommand testRunCommand, DynamicDictionary formData)
        {
            if (null == testRunCommand)
                testRunCommand = new TestRunCommand { TestRunName = formData["test_run_name"] ?? string.Empty, WorkflowName = formData["workflow_name"] ?? string.Empty };
            if (string.IsNullOrEmpty(testRunCommand.WorkflowName))
                testRunCommand.WorkflowName = formData["workflow_name"] ?? string.Empty;
            if (string.IsNullOrEmpty(testRunCommand.TestRunName))
                testRunCommand.TestRunName = formData["test_run_name"] ?? string.Empty;

            PrepareTestRun(testRunCommand, formData);
        }

        void PrepareTestRun(ITestRunCommand testRunCommand, DynamicDictionary formData)
        {
            var testRunInitializer = ServerObjectFactory.Resolve<TestRunInitializer>();
            var testRun = testRunInitializer.CreateTestRun(testRunCommand, formData);
            if (Guid.Empty == testRun.WorkflowId) // ??
                return;
            TestRunQueue.TestRuns.Add(testRun);

            foreach (var testRunAction in testRun.BeforeActions)
            {
                testRunAction.Run();
            }
        }

        public dynamic CreateTestRunExpandoObject()
        {
            dynamic data = new ExpandoObject();
            data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            return data;
        }

        public void DeleteTestRun(Guid testRunId)
        {
            TestRunQueue.TestRuns.RemoveAll(tr => tr.Id == testRunId);
        }

        public bool CancelTestRun(Guid testRunId)
        {
            var testRun = TestRunQueue.TestRuns.First(tr => tr.Id == testRunId);
            if (null == testRun || testRun.IsCompleted())
                return false;
            var testRunSelector = ServerObjectFactory.Resolve<TestRunSelector>();
            testRunSelector.CancelTestRun(testRun);
            return true;
        }
    }
}