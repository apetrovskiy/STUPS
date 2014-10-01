/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 9/30/2014
 * Time: 8:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using Nancy;
    using Nancy.ModelBinding;
    
    /// <summary>
    /// Description of RootModule.
    /// </summary>
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = parameters => View["index.htm"];
            
            Get["/clients.htm"] = parameters => View["clients.htm", ClientsCollection.Clients];
            
            Get["/tasks.htm"] = parameters => View["tasks.htm", TaskPool.TasksForClients.ToArray()];
        }
    }
}
