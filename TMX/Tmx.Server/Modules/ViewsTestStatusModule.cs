/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/30/2014
 * Time: 8:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Modules
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text.RegularExpressions;
    using Nancy;
    using Nancy.ModelBinding;
    using Tmx.Interfaces.Server;
    using Tmx.Server.Helpers.Control;
    
    using Nancy.ViewEngines;
    
    /// <summary>
    /// Description of TestStatusViewsModule.
    /// </summary>
    public class ViewsTestStatusModule : NancyModule
    {
        public ViewsTestStatusModule() : base(UrnList.TestStatusViews_Root)
        {
            Get[UrnList.TestStatusViews_ClientsPage] = parameters => View[UrnList.TestStatusViews_ClientsPageName, ClientsCollection.Clients];
            
            Get[UrnList.TestStatusViews_TasksPage] = parameters => View[UrnList.TestStatusViews_TasksPageName, TaskPool.TasksForClients.ToArray()];
        }
        
        // TODO: move to a separate class
        string getHostname()
        {
            var hostname = Dns.GetHostName();
            if (!string.IsNullOrEmpty(IPGlobalProperties.GetIPGlobalProperties().DomainName)) {
                hostname += ".";
                hostname += IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
            return hostname;
        }
        
//        string getPortFromUrl()
//        {
//            return Regex.Match(InternalServerControl.Url, @"(?<=https?\:\/\/[\w\-\.]+\:).*[^\/\r\n]").Value;
//        }
    }
}
