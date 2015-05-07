namespace Tmx.Server.Logic.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            testClient.TestRunId = TestRunQueue.TestRuns.ActiveTestRunIds().First();
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