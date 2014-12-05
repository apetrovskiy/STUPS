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
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text.RegularExpressions;
    using Nancy;
    using Nancy.ModelBinding;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.Remoting;
    using Nancy.ViewEngines;
    
    /// <summary>
    /// Description of ViewsTestStatusModule.
    /// </summary>
    public class ViewsTestStatusModule : NancyModule
    {
        public ViewsTestStatusModule() : base(UrlList.ViewTestStatus_Root)
        {
            Get[UrlList.ViewTestStatus_All_ClientsPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.Clients = ClientsCollection.Clients ?? new List<ITestClient>();
                return View[UrlList.ViewTestStatus_All_ClientsPageName, data];
            };
            
            Get[UrlList.ViewTestStatus_All_TasksPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TasksForClients = TaskPool.TasksForClients ?? new List<ITestTask>();
                return View[UrlList.ViewTestStatus_All_TasksPageName, data];
            };
            
            Get[UrlList.ViewTestStatus_WorkflowsPage] = _ => {
                var data = WorkflowCollection.Workflows ?? new List<ITestWorkflow>();
                return View[UrlList.ViewTestStatus_WorkflowsPageName, data];
            };
            
            Get[UrlList.ViewTestStatus_TestLabsPage] = _ => {
                dynamic data = new ExpandoObject();
                data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
                return View[UrlList.ViewTestStatus_TestLabsPageName, data];
            };
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
