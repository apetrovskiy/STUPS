namespace Tmx.Server.Logic.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using Core;
    using Core.Types.Remoting;
    using Internal;
    using Nancy;
    using Objects;
    using Tmx.Interfaces.Remoting;

    public class TestRunCollectionMethods
    {
        // 20150825
        public Guid CurrentTestRunId { get; private set; }

        public virtual bool SetTestRunDataAndCreateTestRun(ITestRunCommand testRunCommand, DynamicDictionary formData)
        {
            CurrentTestRunId = Guid.Empty;
            if (null == testRunCommand)
                testRunCommand = new TestRunCommand { TestRunName = formData[Tmx_Core_Resources.TestRunCommand_testRunName_param] ?? string.Empty, WorkflowName = formData[Tmx_Core_Resources.TestRunCommand_workflowName_param] ?? string.Empty };
            if (string.IsNullOrEmpty(testRunCommand.WorkflowName))
                testRunCommand.WorkflowName = formData[Tmx_Core_Resources.TestRunCommand_workflowName_param] ?? string.Empty;
            if (string.IsNullOrEmpty(testRunCommand.TestRunName))
                testRunCommand.TestRunName = formData[Tmx_Core_Resources.TestRunCommand_testRunName_param] ?? string.Empty;
            
            return PrepareTestRun(testRunCommand, formData);
        }
        
        bool PrepareTestRun(ITestRunCommand testRunCommand, DynamicDictionary formData)
        {
            var testRunInitializer = ServerObjectFactory.Resolve<TestRunInitializer>();
            var testRun = testRunInitializer.CreateTestRun(testRunCommand, formData);

            // 20150825
            // testRunCommand.NewTestRunId = testRun.Id;
            CurrentTestRunId = testRun.Id;
            
            // 20150918
            // this was always false
            // if (null == testRun)
            //     return false;
            if (Guid.Empty == testRun.WorkflowId) // ??
                return false;
            TestRunQueue.TestRuns.Add(testRun);
            
            foreach (var testRunAction in testRun.BeforeActions)
            {
                testRunAction.Run();
            }
            return true;
        }
        
        public virtual dynamic CreateTestRunExpandoObject()
        {
            dynamic data = new ExpandoObject();
            data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
            data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
            return data;
        }
        
        public virtual void DeleteTestRun(Guid testRunId)
        {
            TestRunQueue.TestRuns.RemoveAll(tr => tr.Id == testRunId);
        }
        
        public virtual bool CancelTestRun(Guid testRunId)
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