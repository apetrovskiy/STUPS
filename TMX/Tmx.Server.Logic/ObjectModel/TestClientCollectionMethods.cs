namespace Tmx.Server.Logic.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Core;
    using Core.Types.Remoting;
    using ExtensionMethods;
    using Internal;
    //using Nancy;
    using Objects;
    using Tmx.Interfaces.Remoting;

    public class TestClientCollectionMethods
    {
        public bool CreateNewClient(ITestClient testClient)
        {
            if (!TestRunQueue.TestRuns.HasActiveTestRuns())
                return false;
            // TODO: bug is here
            // TODO: improve the seleciton of a test run by matching test client to task rules
            // testClient.TestRunId = TestRunQueue.TestRuns.ActiveTestRunIds().First();
            
            
            // var activeWorkflowIds = WorkflowCollection.Workflows.Where(wfl => TestRunQueue.TestRuns.Where(tr => tr.Status == TestRunStatuses.Running).Select(tr => tr.WorkflowId).Contains(wfl.Id)).Select(wfl => wfl.Id);
            var activeWorkflowIds = WorkflowCollection.Workflows.ActiveWorkflows().Select(wfl => wfl.Id);
            var legitimateWorkflowIds = TaskPool.Tasks
                .Where(task => activeWorkflowIds.Contains(task.WorkflowId) && 
                       (
                           Regex.IsMatch(testClient.CustomString ?? string.Empty, task.Rule) ||
                           Regex.IsMatch(testClient.EnvironmentVersion ?? string.Empty, task.Rule) ||
                           Regex.IsMatch(testClient.Fqdn ?? string.Empty, task.Rule) ||
                           Regex.IsMatch(testClient.Hostname ?? string.Empty, task.Rule) ||
                           Regex.IsMatch(testClient.OsVersion ?? string.Empty, task.Rule) ||
                           Regex.IsMatch(testClient.UserDomainName ?? string.Empty, task.Rule) ||
                           Regex.IsMatch(testClient.Username ?? string.Empty, task.Rule)
                       ))
                .Select(task => task.WorkflowId);
            //if (!legitimateWorkflowIds.Any())
            //    return false;
            var workflowIds = legitimateWorkflowIds as Guid[] ?? legitimateWorkflowIds.ToArray();
            if (!workflowIds.Any())
                return false;
            // testClient.TestRunId = TestRunQueue.TestRuns.First(testRun => workflowIds.Contains(testRun.WorkflowId)).Id;
            testClient.TestRunId = TestRunQueue.TestRuns.First(testRun => testRun.IsActive() && workflowIds.Contains(testRun.WorkflowId)).Id;
            
            ClientsCollection.Clients.Add(testClient);
            var taskSelector = ServerObjectFactory.Resolve<TaskSelector>();
            var tasksForClient = taskSelector.SelectTasksForClient(testClient.Id, TaskPool.Tasks);
            tasksForClient.ForEach(task => task.TestRunId = testClient.TestRunId);
            TaskPool.TasksForClients.AddRange(tasksForClient);
            return true;
        }

        public void DeleteClientById(Guid clientId)
        {
            var testRunId = ClientsCollection.Clients.First(client => client.Id == clientId).TestRunId;
            ClientsCollection.Clients.RemoveAll(client => client.Id == clientId);
            TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.TestRunId == testRunId && task.TaskStatus == TestTaskStatuses.New)
                .ToList()
                .ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
        }

        public bool UpdateStatus(Guid clientId, DetailedStatus detailedStatus)
        {
            if (ClientsCollection.Clients.All(client => client.Id != clientId))
                return false;
            ClientsCollection.Clients.First(client => client.Id == clientId).DetailedStatus = detailedStatus.Status;
            return true;
        }

        public List<ITestClient> ReturnAllClients()
        {
            return ClientsCollection.Clients;
        }

        public ITestClient ReturnClientById(Guid clientId)
        {
            return ClientsCollection.Clients.FirstOrDefault(client => client.Id == clientId);
        }
    }
}