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
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Interfaces.Remoting;
    using Logic.Interfaces;
    using Logic.Internal;
    using Logic.ObjectModel;
    using Logic.ObjectModel.Objects;
    using Logic.ObjectModel.ServerControl;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Conventions;
    using Nancy.Diagnostics;
    using Nancy.Hosting.Self;
    using Nancy.Json;
    using Nancy.TinyIoc;
    using PSTestLib.Helpers;
    using Web.Helpers;

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
            LoadDefaults();
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
            ServerObjectFactory.Resolve<TestLabCollection>();
        }
        
        static void LoadModules()
        {
            // var modulesLoader = new ModulesLoader((new TmxServerRootPathProvider()).GetRootPath());
            var modulesLoader = new ModulesLoader((new TmxServerRootPathProvider()).GetRootPath(), @"Nancy.ViewEngines*.dll", false);
            modulesLoader.Load();
            
            //// just for copying the Nancy.ViewEngines.DotLiquid assembly to dependant projects
            //var drop = new DynamicDrop(new ExpandoObject());
        }
        
        static void SetDotLiquidNamingConventions()
        {
            ServerObjectFactory.Resolve<Initializer>().SetDotLiquidNamingConventions();
        }
        
        static void RegisterTypes()
        {
            ServerObjectFactory.Resolve<Initializer>().RegisterTypes();
        }
        
        static void LoadPlugins()
        {
            // 20150617
            // var pluginsLoader = new AssembliesLoader((new TmxServerRootPathProvider()).GetRootPath() + @"\Plugins");
            // var pluginsLoader = new ModulesLoader((new TmxServerRootPathProvider()).GetRootPath() + @"\Plugins", "*.dll", true);
            // 20150626
            var pluginsLoader = new AssembliesLoader((new TmxServerRootPathProvider()).GetRootPath() + @"\Plugins", "*.dll", true);
            // var pluginsLoader = new AssembliesLoader((new TmxServerRootPathProvider()).GetRootPath(), "*.dll", true);
            pluginsLoader.Load();
        }

        static void LoadDefaults()
        {
            var workflowsDirectoryPath = (new TmxServerRootPathProvider()).GetRootPath() + @"\Workflows";
            if (!Directory.Exists(workflowsDirectoryPath)) return;
            var fileWithDefaults = workflowsDirectoryPath + @"\" + "defaults.xml";

            Trace.TraceInformation("loading defaults...");

            if (File.Exists(fileWithDefaults))
                ServerObjectFactory.Resolve<DefaultsLoader>().Load(fileWithDefaults);

            Trace.TraceInformation("done");
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
            // try { Console.WriteLine(state + " NegotiationContext.Headers = " + Enumerable.Select<KeyValuePair<string, string>, string>(ctx.NegotiationContext.Headers, hdr => hdr.Value)); } catch {}
            try { Console.WriteLine(state + " NegotiationContext.Headers = " + ctx.NegotiationContext.Headers.Select(hdr => hdr.Value)); } catch { }
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