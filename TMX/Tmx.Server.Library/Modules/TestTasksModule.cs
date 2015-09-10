/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 10:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.Modules
{
    using System;
    using System.Diagnostics;
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
    /// Description of TestTasksModule.
    /// </summary>
    public class TestTasksModule : NancyModule
    {
        public TestTasksModule() : base(UrlList.TestTasks_Root)
        {
            Get[UrlList.TestTasks_CurrentTaskForClientById_relPath] = parameters => ReturnTaskByClientId(parameters.id);
            
            Put[UrlList.TestTasks_Task] = parameters => {
                // 20141020 squeezing a task to its proxy
                ITestTask loadedTask = this.Bind<TestTask>();
                // ITestTaskProxy loadedTask = this.Bind<TestTaskProxy>();
                // ITestTaskResultProxy loadedTask = this.Bind<TestTaskResultProxy>();
                return UpdateTask(loadedTask, parameters.id);
            };
            
            Delete[UrlList.TestTasks_Task] = parameters => DeleteAllocatedTaskById(parameters.id);
            
            Delete[UrlList.TestTasks_AllLoaded_relPath + UrlList.TestTasks_Task] = parameters => DeleteLoadedTaskById(parameters).id;
        }
        
        Negotiator ReturnTaskByClientId(Guid clientId)
        {
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).1");
            
            if (ClientsCollection.Clients.All(client => client.Id != clientId))
                // return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed);
                // return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithReasonPhrase("There's no test client with id = " + clientId);
                return Negotiate.WithStatusCode(HttpStatusCode.ExpectationFailed).WithReasonPhrase(string.Format(ServerLibrary.ReasonPhrase_ThereIsNOTestClientWithId, clientId));
            
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).2");

            var taskSelector = ServerObjectFactory.Resolve<TaskSelector>();
            
//try {
//    var taskSel = TinyIoCContainer.Current.Resolve<ITaskSelector>();
//    if (null == taskSel)
//        Console.WriteLine("null == taskSel");
//    else
//        Console.WriteLine("type is {0}", taskSel.GetType().Name);
//}
//catch (Exception ee) {
//    Console.WriteLine(ee.Message);
//}
            
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).3");
            
            // 20150908
            // ITestTask actualTask = taskSelector.GetFirstLegitimateTask(clientId);
            var actualTask = taskSelector.GetFirstLegitimateTask(clientId);
            
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).4 actualTask is null? {0}", null == actualTask);
            
            var clientInQuestion = ClientsCollection.Clients.First(client => client.Id == clientId);
            
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).5 clientInQuestion is null? {0}", null == clientInQuestion);
            Trace.TraceInformation("returnTaskByClientId(Guid clientId).6 clientInQuestion.Id = {0}, hostname = {1}", clientInQuestion.Id, clientInQuestion.Hostname);
            
            return null == actualTask ? returnNoTask_StatusNotFound(clientInQuestion) : returnTaskToClient_StatusOk(clientInQuestion, actualTask);
        }
        
        Negotiator returnNoTask_StatusNotFound(ITestClient testClient)
        {
            Trace.TraceInformation("returnNoTask_StatusNotFound(ITestClient testClient).1");
            
            testClient.SetNoTasksStatus();
            
            Trace.TraceInformation("returnNoTask_StatusNotFound(ITestClient testClient).2");
            
            return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
        }
        
        Negotiator returnTaskToClient_StatusOk(ITestClient testClient, ITestTask actualTask)
        {
            ServerObjectFactory.Resolve<TestTaskCollectionMethods>().UpdateTestClientWithActiveTask(testClient, actualTask);

            // 20141020 squeezing a task to its proxy
            return Negotiate.WithModel(actualTask).WithStatusCode(HttpStatusCode.OK);
            // return Negotiate.WithModel(actualTask.SqueezeTaskToTaskResultProxy()).WithStatusCode(HttpStatusCode.OK);
            // return Negotiate.WithModel(actualTask.SqueezeTaskToTaskCodeProxy()).WithStatusCode(HttpStatusCode.OK);
        }
        
        // 20141020 squeezing a task to its proxy
        HttpStatusCode UpdateTask(ITestTask loadedTask, int taskId)
        // HttpStatusCode updateTask(ITestTaskResultProxy loadedTask, int taskId)
        {
            ServerObjectFactory.Resolve<TestTaskCollectionMethods>().UpdateTask(loadedTask, taskId);
            return HttpStatusCode.OK;
        }
        
        HttpStatusCode DeleteAllocatedTaskById(int taskId)
        {
            TaskPool.TasksForClients.RemoveAll(task => task.Id == taskId);
            return HttpStatusCode.NoContent;
        }

        HttpStatusCode DeleteLoadedTaskById(int taskId)
        {
            TaskPool.Tasks.RemoveAll(task => task.Id == taskId);
            return HttpStatusCode.NoContent;
        }
    }
}
