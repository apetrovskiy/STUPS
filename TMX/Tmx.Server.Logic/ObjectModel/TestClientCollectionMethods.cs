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
        public virtual bool CreateNewClient(ITestClient testClient)
        {
            if (!TestRunQueue.TestRuns.HasActiveTestRuns())
                return false;
            // TODO: improve the selection of a test run by matching test client to task rules
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
                           /*
                           Regex.IsMatch(task.Rule, testClient.CustomString ?? string.Empty) ||
                           Regex.IsMatch(task.Rule, testClient.EnvironmentVersion ?? string.Empty) ||
                           Regex.IsMatch(task.Rule, testClient.Fqdn ?? string.Empty) ||
                           Regex.IsMatch(task.Rule, testClient.Hostname ?? string.Empty) ||
                           Regex.IsMatch(task.Rule, testClient.OsVersion ?? string.Empty) ||
                           Regex.IsMatch(task.Rule, testClient.UserDomainName ?? string.Empty) ||
                           Regex.IsMatch(task.Rule, testClient.Username ?? string.Empty)
                           */
                       ))
                .Select(task => task.WorkflowId);
            
            var workflowIds = legitimateWorkflowIds as Guid[] ?? legitimateWorkflowIds.ToArray();
            if (!workflowIds.Any())
                return false;
            
            testClient.TestRunId = TestRunQueue.TestRuns.First(testRun => testRun.IsActive() && workflowIds.Contains(testRun.WorkflowId)).Id;
            
            ClientsCollection.Clients.Add(testClient);
            var taskSelector = ServerObjectFactory.Resolve<TaskSelector>();
            var tasksForClient = taskSelector.SelectTasksForClient(testClient.Id, TaskPool.Tasks);
            tasksForClient.ForEach(task => task.TestRunId = testClient.TestRunId);
            TaskPool.TasksForClients.AddRange(tasksForClient);
            return true;
        }

        public virtual void DeleteClientById(Guid clientId)
        {
            var testRunId = ClientsCollection.Clients.First(client => client.Id == clientId).TestRunId;
            ClientsCollection.Clients.RemoveAll(client => client.Id == clientId);
            // 20150909
            // TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.TestRunId == testRunId && task.TaskStatus == TestTaskStatuses.New)
            TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.TestRunId == testRunId && task.TaskStatus == TestTaskStatuses.New && !task.IsCancel)
                .ToList()
                .ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
        }

        public virtual bool UpdateStatus(Guid clientId, DetailedStatus detailedStatus)
        {
            if (ClientsCollection.Clients.All(client => client.Id != clientId))
                return false;
            ClientsCollection.Clients.First(client => client.Id == clientId).DetailedStatus = detailedStatus.Status;
            return true;
        }

        public virtual List<ITestClient> ReturnAllClients()
        {
            return ClientsCollection.Clients;
        }

        public virtual ITestClient ReturnClientById(Guid clientId)
        {
            return ClientsCollection.Clients.FirstOrDefault(client => client.Id == clientId);
        }
    }
}