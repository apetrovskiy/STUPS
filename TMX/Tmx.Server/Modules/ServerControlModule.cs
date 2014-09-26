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
    using Nancy;
    using Nancy.ModelBinding;
    using Tmx.Core.Types.Remoting;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.Server;
    
    /// <summary>
    /// Description of ServerControlModule.
    /// </summary>
    public class ServerControlModule : NancyModule
    {
        public ServerControlModule() : base(UrnList.ServerControl_Root)
        {
            Put[UrnList.ServerControlPoint] = parameters => {
                IServerCommand serverCommand = this.Bind<ServerCommand>();
                processServerCommand(serverCommand);
                return HttpStatusCode.OK;
            };
        }
        
        void processServerCommand(IServerCommand serverCommand)
        {
            switch (serverCommand.Command) {
                case ServerControlCommands.LoadConfiguraiton:
                    var workflowLoader = new WorkflowLoader();
                    workflowLoader.LoadWorkflow(serverCommand.Data);
                    break;
                case ServerControlCommands.Reset:
                    ServerControl.Reset();
                    break;
                case ServerControlCommands.Stop:
                    ServerControl.Stop();
                    break;
            }
        }
    }
}
