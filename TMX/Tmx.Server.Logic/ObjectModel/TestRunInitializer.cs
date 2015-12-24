/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/22/2014
 * Time: 2:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Logic.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Types.Remoting;
    using Nancy;
    using Objects;
    using Tmx.Interfaces.Remoting;

    /// <summary>
    /// Description of TestRunInitializer.
    /// </summary>
    public class TestRunInitializer
    {
        public virtual ITestRun CreateTestRun(ITestRunCommand testRunCommand, DynamicDictionary formData)
        {
            if (string.IsNullOrEmpty(testRunCommand.TestRunName))
                testRunCommand.TestRunName = testRunCommand.WorkflowName + " " + DateTime.Now;
            var testRun = new TestRun { Name = testRunCommand.TestRunName, Status = testRunCommand.Status };
            
            var currentWorkflow = WorkflowCollection.Workflows.FirstOrDefault(wfl => testRunCommand.WorkflowName == wfl.Name);
            SetCommonData(testRun, currentWorkflow.DefaultData.Data);
            
            SetWorkflow(testRunCommand, testRun);
            SetStartUpParameters(testRun);
            SetCommonData(testRun, formData);
            SetCreatedTime(testRun);
            return testRun;
        }
        
        void SetWorkflow(ITestRunCommand testRunCommand, TestRun testRun)
        {
            testRun.SetWorkflow(WorkflowCollection.Workflows.First(wfl => wfl.Name == testRunCommand.WorkflowName));
            TestLabCollection.TestLabs.First(testLab => testLab.Id == testRun.TestLabId).Status = TestLabStatuses.Busy;
        }
        
        void SetStartUpParameters(ITestRun testRun)
        {
            if (TestRunStartTypes.Immediately == testRun.StartType)
                testRun.Status = TestRunQueue.TestRuns.Any(tr => tr.TestLabId == testRun.TestLabId && tr.IsQueued()) ? TestRunStatuses.Pending : TestRunStatuses.Running;
            if (testRun.IsAcceptingNewClients())
                testRun.SetStartTime();
        }
        
        void SetCommonData(ITestRun testRun, IDictionary<string, object> formData)
        {
            if (null == formData || 0 >= formData.Count)
                return;
            foreach (var pair in formData)
                AddOrUpdateDataItem(testRun, formData, pair.Key);
        }
        
        void SetCreatedTime(ITestRun testRun)
        {
            testRun.CreatedTime = DateTime.Now;
        }
        
        void AddOrUpdateDataItem(ITestRun testRun, IDictionary<string, object> formData, string key)
        {
            testRun.Data.AddOrUpdateDataItem(
                new CommonDataItem {
                    Key = key,
                    Value = (formData[key] ?? string.Empty).ToString()
                });
        }
    }
}
