﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/14/2014
 * Time: 9:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.ObjectModel.ServerControl
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using Core;
    using Core.Types.Remoting;
    using DotLiquid;
    using Interfaces;
    using Library.Internal;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using Nancy.Diagnostics;
    using Nancy.Hosting.Self;
    using Nancy.Json;
    using Nancy.TinyIoc;
    using Nancy.ViewEngines.DotLiquid;
    using Objects;
    using PSTestLib.Helpers;
    using Tmx.Interfaces;
    using Tmx.Interfaces.Remoting;
    using Tmx.Interfaces.TestStructure;
// using System.Diagnostics;
    // using DotLiquid.NamingConventions;

    /// <summary>
    /// Description of Control.
    /// </summary>
    public class InternalServerControl : DefaultNancyBootstrapper
    {
        static NancyHost _nancyHost;
        // 20150316
        //static bool _tracingAlreadyInitialized;
        
        public static string Url { get; set; }
        
        public static void Start(string url)
        {
            // TODO: rewrite it
            // setTracing();
            var tracingControl = new TracingControl("TmxServer_");
            Url = url;
            PrepareComponents();
            LoadModules();
            _nancyHost = new NancyHost(new Uri(url));
            SetDotLiquidNamingConventions();
            RegisterTypes();
            LoadPlugins();
            LoadWorkflows();
            _nancyHost.Start();
        }
        
        public static void Stop()
        {
            Reset();
            _nancyHost.Stop();
        }
        
        public static void Reset()
        {
            ClientsCollection.Clients = new List<ITestClient>();
            TaskPool.TasksForClients = new List<ITestTask>();
            TaskPool.Tasks = new List<ITestTask>();
            TestRunQueue.TestRuns = new List<ITestRun>();
            WorkflowCollection.Workflows = new List<ITestWorkflow>();
            TestLabCollection.TestLabs = new List<ITestLab>();
        }
        
        protected override DiagnosticsConfiguration DiagnosticsConfiguration {
            get {
                return new DiagnosticsConfiguration { Password = @"Tmx=admin" };
            }
        }
        
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            // nancyConventions.StaticContentsConventions.Add(
            //     StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath(), "Root"));
            
            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"Views/results", "results"));
            
            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + "Views/Scripts", @"Scripts", ".js"));
                
            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + "Views/settings", @"settings"));
                
            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + "Views/status", @"status"));
            
            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + "Views/testRuns", @"testRuns"));
            
            nancyConventions.StaticContentsConventions.Add(
                StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + "Views/workflows", @"workflows"));
            
            base.ConfigureConventions(nancyConventions);
        }
        
        protected override IRootPathProvider RootPathProvider
        {
            get { return new TmxServerRootPathProvider(); }
        }
        
        static void PrepareComponents()
        {
            // 20150319
            // var testLabCollection = new TestLabCollection();
            new TestLabCollection();
        }
        
        static void LoadModules()
        {
            var modulesLoader = new ModulesLoader((new TmxServerRootPathProvider()).GetRootPath());
            modulesLoader.Load();
            
            // just for copying the Nancy.ViewEngines.DotLiquid assembly to dependant projects
            var drop = new DynamicDrop(new ExpandoObject());
        }
        
        static void SetDotLiquidNamingConventions()
        {
            // Template.NamingConvention = new CSharpNamingConvention();
        }
        
        static void RegisterTypes()
        {
            // specific types
            Template.RegisterSafeType(typeof(TestSuite), new[] { "Id", "Name", "Status", "Description", "TestScenarios", "PlatformId", "Statistics", "TimeSpent", "Timestamp", "Tags", "Statistics.All", "Statistics.Passed", "GetAll", "GetPassed", "GetFailed", "GetPassedButWithBadSmell", "GetNotTested" });
            Template.RegisterSafeType(typeof(TestScenario), new[] { "Id", "Name", "Status", "Description", "TestResults", "PlatformId", "Statistics", "TimeSpent", "Timestamp", "Tags", "TestCases", "Statistics.All", "Statistics.Passed", "GetAll", "GetPassed", "GetFailed", "GetPassedButWithBadSmell", "GetNotTested" });
            Template.RegisterSafeType(typeof(TestResult), new[] { "Id", "Name", "Status", "Description", "Origin", "PlatformId", "Timestamp", "Details", "ScriptName", "LineNumber", "Position", "Error", "Code", "Parameters", "TimeSpent", "Generated", "Screenshot", "ListDetailNames" });
            Template.RegisterSafeType(typeof(TestResultDetail), new[] { "Name", "Timestamp", "GetDetail", "DetailStatus", "DetailType", "TextDetail", "ErrorDetail", "ScreenshotDetail", "LogDetail", "ExternalData" });
            Template.RegisterSafeType(typeof(ITestSuite), new[] { "Id", "Name", "Status", "Description", "TestScenarios", "PlatformId", "Statistics", "TimeSpent", "Timestamp", "Tags", "Statistics.All", "Statistics.Passed", "GetAll", "GetPassed", "GetFailed", "GetPassedButWithBadSmell", "GetNotTested" });
            Template.RegisterSafeType(typeof(ITestScenario), new[] { "Id", "Name", "Status", "Description", "TestResults", "PlatformId", "Statistics", "TimeSpent", "Timestamp", "Tags", "TestCases", "Statistics.All", "Statistics.Passed", "GetAll", "GetPassed", "GetFailed", "GetPassedButWithBadSmell", "GetNotTested" });
            Template.RegisterSafeType(typeof(ITestResult), new[] { "Id", "Name", "Status", "Description", "Origin", "PlatformId", "Timestamp", "Details", "ScriptName", "LineNumber", "Position", "Error", "Code", "Parameters", "TimeSpent", "Generated", "Screenshot", "ListDetailNames" });
            Template.RegisterSafeType(typeof(ITestResultDetail), new[] { "Name", "Timestamp", "GetDetail", "DetailStatus", "DetailType", "TextDetail", "ErrorDetail", "ScreenshotDetail", "LogDetail", "ExternalData" });
            Template.RegisterSafeType(typeof(TestWorkflow), new[] { "Id", "Name", "TestLabId", "Description", "ParametersPageName" });
            // Template.RegisterSafeType(typeof(ITestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "TimeTaken", "GetTestLabName" });
            // Template.RegisterSafeType(typeof(TestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "TimeTaken", "GetTestLabName" });
            Template.RegisterSafeType(typeof(ITestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "GetTimeTaken", "GetTestLabName" });
            Template.RegisterSafeType(typeof(TestRun), new[] { "Id", "Name", "WorkflowId", "TestLabId", "Description", "Status", "StartType", "Data", "TestSuites", "StartTime", "GetTimeTaken", "GetTestLabName" });
            Template.RegisterSafeType(typeof(CommonData), new[] { "Data" });
            Template.RegisterSafeType(typeof(ICodeBlock), new[] { "Code" });
            Template.RegisterSafeType(typeof(CodeBlock), new[] { "Code" });
            Template.RegisterSafeType(typeof(TestLab), new[] { "Id", "Name", "Description", "Status" });
            Template.RegisterSafeType(typeof(TestTask), new[] { "Id", "Name", "StartTime", "TaskStatus", "TaskFinished", "TaskResult", "TimeTaken", "ClientId", "GetTimeTaken" });
            Template.RegisterSafeType(typeof(TestClient), new[] { "Id", "Hostname", "Fqdn", "Username", "CustomString", "Status", "TaskId", "TaskName", "DetailedStatus" });
            Template.RegisterSafeType(typeof(CommonDataItem), new[] { "Key", "Value" });
            Template.RegisterSafeType(typeof(TestStat), new[] { "All", "Passed", "Failed", "PassedButWithBadSmell", "NotTested", "TimeSpent" });
            Template.RegisterSafeType(typeof(TestStat), member => member.ToString());
            // .NET types
            Template.RegisterSafeType(typeof(Guid), member => member.ToString());
            Template.RegisterSafeType(typeof(Dictionary<string, string>), member => member.ToString());
            Template.RegisterSafeType(typeof(KeyValuePair<string, string>), new[] { "Key", "Value" });
            // enumerations
            Template.RegisterSafeType(typeof(TestResultOrigins), member => member.ToString());
            Template.RegisterSafeType(typeof(TestRunStatuses), member => member.ToString());
            Template.RegisterSafeType(typeof(TestRunStartTypes), member => member.ToString());
            Template.RegisterSafeType(typeof(TestTaskStatuses), member => member.ToString());
            Template.RegisterSafeType(typeof(TestTaskExecutionTypes), member => member.ToString());
            Template.RegisterSafeType(typeof(TestClientStatuses), member => member.ToString());
            Template.RegisterSafeType(typeof(ServerControlCommands), member => member.ToString());
            Template.RegisterSafeType(typeof(TestLabStatuses), member => member.ToString());
        }
        
        static void LoadPlugins()
        {
            var pluginsLoader = new PluginsLoader((new TmxServerRootPathProvider()).GetRootPath() + @"\Plugins");
            pluginsLoader.Load();
        }
        
        static void LoadWorkflows()
        {
            var workflowsDirectoryPath = (new TmxServerRootPathProvider()).GetRootPath() + @"\Workflows";
            if (!Directory.Exists(workflowsDirectoryPath)) return;
            var workflowLoader = ServerObjectFactory.Resolve<WorkflowLoader>();
            foreach (var fileName in Directory.GetFiles(workflowsDirectoryPath)) {
                try {
                    workflowLoader.Load(fileName);
                }
                catch {}
            }
        }
        
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.Caching.EnableRuntimeViewUpdates = true;
            StaticConfiguration.DisableErrorTraces = false;
            StaticConfiguration.EnableRequestTracing = true;
            JsonSettings.MaxJsonLength = int.MaxValue;
            // pipelines.BeforeRequest += ctx => { temporary_outputMethod(ctx, "BeforeRequest"); return null; };
            
            // pipelines.AfterRequest += ctx => { temporary_outputMethod(ctx, "AfterRequest"); return null; };

            // http://www.codeproject.com/Articles/694907/Lift-your-Petticoats-with-Nancy
            /*
            base.ApplicationStartup(container, pipelines);
            ConfigManager mgr;
            mgr = new ConfigManager();
            mgr.LoadConfig();
            container.Register<configmanager>(mgr);
            */
            // container.Register<
            container.Register<ITaskSelector, TaskSelector>();
        }
        
        void temporary_outputMethod(NancyContext ctx, string state)
        {
            try { Console.WriteLine(state + " ControlPanelEnabled = " + ctx.ControlPanelEnabled); } catch {}
            try { Console.WriteLine(state + " Culture.DisplayName = " + ctx.Culture.DisplayName); } catch {}
            try { Console.WriteLine(state + " CurrentUser.UserName = " + ctx.CurrentUser.UserName); } catch {}
            try { 
                if (null != ctx.Items) {
                    foreach (var item in ctx.Items) {
                        Console.WriteLine(state + " Items " + item.Key + ": " + item.Value);
                    }
                }
            } catch {}
            try { Console.WriteLine(state + " ModelValidationResult.IsValid = " + ctx.ModelValidationResult.IsValid); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.ViewName = " + ctx.NegotiationContext.ViewName); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.ModuleName = " + ctx.NegotiationContext.ModuleName); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.ModulePath = " + ctx.NegotiationContext.ModulePath); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.Headers = " + ctx.NegotiationContext.Headers.Select(hdr => hdr.Value)); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.StatusCode = " + ctx.NegotiationContext.StatusCode); } catch {}
            try { Console.WriteLine(state + " ResolvedRoute = " + ctx.ResolvedRoute); } catch {}
            try { Console.WriteLine(state + " Text = " + ctx.Text); } catch {}
            try { Console.WriteLine(state + " ViewBag = " + ctx.ViewBag); } catch {}
        }
        
//        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
//        {
//            base.ConfigureApplicationContainer(container);
//            
//            // container.Register<
//        }
        
//        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
//        {
//            // base.ConfigureRequestContainer(container, context);
//            // var session = container.Resolve<
//        }
    }
}