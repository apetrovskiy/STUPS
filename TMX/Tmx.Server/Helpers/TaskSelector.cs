/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/22/2014
 * Time: 8:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text.RegularExpressions;
    using Nancy.TinyIoc;
    using Tmx.Core;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TaskSelector.
    /// </summary>
    public class TaskSelector
    {
        public virtual List<ITestTask> SelectTasksForClient(Guid clientId, List<ITestTask> tasks)
        {
            var resultTaskScope = new List<ITestTask>();
            
            var client = ClientsCollection.Clients.First(c => c.Id == clientId);
            // TODO: use IDisposable or DI
            // using (var client = ClientsCollection.Clients.First(c => c.Id == clientId)) {
            
            if (null == client) return resultTaskScope;
            
            // TODO: add IsAdmin and IsInteractive to the checking
            var workflowId = TestRunQueue.TestRuns.First(testRun => testRun.Id == client.TestRunId).WorkflowId;
            
            resultTaskScope =
                tasks.Where(task => task.WorkflowId == workflowId)
                .Where(task => // 0 == task.ClientId && 
                                       (Regex.IsMatch(client.CustomString ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.EnvironmentVersion ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.Fqdn ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.Hostname ?? string.Empty, task.Rule) ||
                                        // task.Rule == client.IsAdmin.ToString() ||
                                        // task.Rule == client.IsInteractive.ToString() ||
                                        // Regex.IsMatch(client.OsEdition ?? string.Empty, task.Rule) ||
                                        // Regex.IsMatch(client.OsName ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.OsVersion ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.UserDomainName ?? string.Empty, task.Rule) ||
                                        Regex.IsMatch(client.Username ?? string.Empty, task.Rule))
                            // 20141023
                                    // ).Select(t => { var newTask = t.CloneTaskForNewTestClient(); newTask.ClientId = clientId; return newTask; }).ToList<ITestTask>();
                                   // ).Select(t => { var newTask = t.CloneTaskForNewTestClient(); newTask.ClientId = clientId; newTask.WorkflowId = WorkflowCollection.ActiveWorkflow.Id; return newTask; }).ToList<ITestTask>();
            ).Select(t => {
                var newTask = t.CloneTaskForNewTestClient();
                newTask.ClientId = clientId;
                return newTask;
            }).ToList<ITestTask>();
            
            return resultTaskScope;
        }
        
        public virtual ITestTask GetFirstLegibleTask(Guid clientId)
        {
            var taskListForClient = getOnlyNewTestTasksForClient(clientId);
            if (null == taskListForClient || !taskListForClient.Any()) return null;
            var taskCandidate = taskListForClient.First(task => task.Id == taskListForClient.Min(tsk => tsk.Id));
            return isItTimeToPublishTask(taskCandidate) ? taskCandidate : null;
        }
        
        public virtual ITestTask GetNextLegibleTask(Guid clientId, int currentTaskId)
        {
            var taskListForClient = getOnlyNewTestTasksForClient(clientId);
            if (null == taskListForClient || !taskListForClient.Any()) return null;
            var tasksToBeNextOne = taskListForClient.Where(t => t.Id > currentTaskId);
            if (null == tasksToBeNextOne || !tasksToBeNextOne.Any()) return null;
            
            return taskListForClient.First(task => task.Id == tasksToBeNextOne.Min(tsk => tsk.Id));
        }
        
        public virtual void CancelFurtherTasksOfTestClient(Guid clientId)
        {
            TaskPool.TasksForClients
                .Where(task => task.ClientId == clientId && !task.IsFinished())
                .ToList()
                .ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
        }
        
        public virtual void CancelFurtherTasksOfTestRun(Guid testRunId)
        {
            TaskPool.TasksForClients
                .Where(task => task.TestRunId == testRunId && !task.IsFinished())
                    .ToList()
                    .ForEach(task => task.TaskStatus = TestTaskStatuses.Canceled);
        }
        
        internal virtual IEnumerable<ITestTask> getOnlyNewTestTasksForClient(Guid clientId)
        {
            return TaskPool.TasksForClients.Where(task => task.ClientId == clientId && task.IsActive && task.TaskStatus == TestTaskStatuses.New);
        }
        
        internal virtual bool isItTimeToPublishTask(ITestTask task)
        {
            var numberOfMustDoneBeforeTask = task.AfterTask;
            if (0 == numberOfMustDoneBeforeTask) return true;
            return TaskPool.TasksForClients.Any(t => t.Id == numberOfMustDoneBeforeTask) && !TaskPool.TasksForClients.Any(t => t.Id == numberOfMustDoneBeforeTask && !t.TaskFinished);
        }
        
        internal virtual void AddTasksForEveryClient(IEnumerable<ITestTask> activeWorkflowsTasks, Guid testRunId)
        {
            if (0 == ClientsCollection.Clients.Count) return;
            // var taskSorter = new TaskSelector();
            var taskSorter = TinyIoCContainer.Current.Resolve<TaskSelector>();
            foreach (var clientId in ClientsCollection.Clients.Where(client => client.IsInActiveTestRun()).Select(client => client.Id)) {
                var tasksForClient = taskSorter.SelectTasksForClient(clientId, activeWorkflowsTasks.ToList());
                tasksForClient.ForEach(task => task.TestRunId = testRunId);
                TaskPool.TasksForClients.AddRange(tasksForClient);
            }
        }
    }
}
