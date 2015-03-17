/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2014
 * Time: 6:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.Collections.Generic;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.TinyIoc;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of ServerControlModule.
    /// </summary>
    public class ServerControlModule : NancyModule
    {
        public ServerControlModule() : base(UrlList.ServerControl_Root)
        {
            Put[UrlList.ServerControlPoint_relPath] = parameters => {
                IServerCommand serverCommand = this.Bind<ServerCommand>();
                ProcessServerCommand(serverCommand);
                return HttpStatusCode.OK;
            };
        }
        
        void ProcessServerCommand(IServerCommand serverCommand)
        {
            switch (serverCommand.Command) {
                case ServerControlCommands.LoadConfiguraiton:
                    var workflowLoader = TinyIoCContainer.Current.Resolve<WorkflowLoader>();
                    workflowLoader.Load(serverCommand.Data);
                    break;
                case ServerControlCommands.ResetFull:
                    ServerControl.Reset();
                    break;
                case ServerControlCommands.Stop:
                    ServerControl.Stop();
                    break;
                case ServerControlCommands.ResetClients:
                    ClientsCollection.Clients = new List<ITestClient>();
                    break;
                case ServerControlCommands.ResetAllocatedTasks:
                    TaskPool.TasksForClients = new List<ITestTask>();
                    break;
                case ServerControlCommands.ResetLoadedTasks:
                    TaskPool.Tasks = new List<ITestTask>();
                    break;
                case ServerControlCommands.ResetWorkflows:
                    WorkflowCollection.Workflows = new List<ITestWorkflow>();
                    break;
//                case ServerControlCommands.ExportTestResults:
//                    TmxHelper.ExportResultsToXML(new SearchCmdletBaseDataObject { FilterAll = true }, serverCommand.Data);
//                    break;
            }
        }
    }
}
