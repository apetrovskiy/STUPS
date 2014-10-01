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
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text.RegularExpressions;
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
            
            // TODO: to a separate module
            // Get["Nwx/sources.htm"] = parameters => View[@"Nwx/sources.htm", InternalServerControl.Url];
            Get["Nwx/sources.htm"] = parameters => {
                // return View[@"Nwx/sources.htm", "http://" + getHostname() + ":" + getPortFromUrl()];
                return View[@"Nwx/sources.htm", InternalServerControl.Url];
            };
        }
        
        // TODO: move to a separate class
        string getHostname()
        {
            var hostname = Dns.GetHostName();
            if (string.Empty != IPGlobalProperties.GetIPGlobalProperties().DomainName) {
                hostname += ".";
                hostname += IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
            return hostname;
        }
        
        string getPortFromUrl()
        {
            return Regex.Match(InternalServerControl.Url, @"(?<=https?\:\/\/[\w\-\.]+\:).*[^\/\r\n]").Value;
        }
    }
}
