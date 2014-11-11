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
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text.RegularExpressions;
    using Nancy;
    using Nancy.ModelBinding;
    using Tmx.Interfaces.Server;
    using Tmx.Interfaces.Remoting;
    using Tmx.Server.Helpers.Control;
    using Nancy.ViewEngines;
    
    /// <summary>
    /// Description of TestStatusViewsModule.
    /// </summary>
    public class ViewsTestStatusModule : NancyModule
    {
        public ViewsTestStatusModule() : base(UrnList.ViewTestStatus_Root)
        {
            // Get[UrnList.ViewTestStatus_ClientsPage] = parameters => View[UrnList.ViewTestStatus_ClientsPageName, ClientsCollection.Clients];
            Get[UrnList.ViewTestStatus_ClientsPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.Clients = ClientsCollection.Clients ?? new List<ITestClient>();
                return View[UrnList.ViewTestStatus_ClientsPageName, data];
            };
            
            // Get[UrnList.ViewTestStatus_TasksPage] = parameters => View[UrnList.ViewTestStatus_TasksPageName, TaskPool.TasksForClients.ToArray()];
            Get[UrnList.ViewTestStatus_TasksPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TasksForClients = TaskPool.TasksForClients ?? new List<ITestTask>();
                return View[UrnList.ViewTestStatus_TasksPageName, data];
            };
            
            Get[UrnList.ViewTestStatus_TestRunsPage] = parameters => {
                dynamic data = new ExpandoObject();
                data.TestRuns = TestRunQueue.TestRuns ?? new List<ITestRun>();
                data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
                return View[UrnList.ViewTestStatus_TestRunsPageName, data];
            };
            
            Get[UrnList.ViewTestStatus_WorkflowsPage] = _ => {
                var data = WorkflowCollection.Workflows ?? new List<ITestWorkflow>();
                return View[UrnList.ViewTestStatus_WorkflowsPageName, data];
            };
            
            Get[UrnList.ViewTestStatus_TestLabsPage] = _ => {
                dynamic data = new ExpandoObject();
                data.TestLabs = TestLabCollection.TestLabs ?? new List<ITestLab>();
                return View[UrnList.ViewTestStatus_TestLabsPageName, data];
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
