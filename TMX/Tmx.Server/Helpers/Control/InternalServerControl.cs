/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/14/2014
 * Time: 9:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server
{
    using System;
    using System.IO;
    using System.Linq;
	using Nancy;
	using Nancy.Bootstrapper;
	using Nancy.Conventions;
    using Nancy.Hosting.Self;
    using Nancy.Diagnostics;
	using Nancy.TinyIoc;
	using Tmx.Core;
    using Tmx.Interfaces;
    using Tmx.Interfaces.TestStructure;
    using Tmx.Server.Helpers.Control;
    using DotLiquid;
    
    /// <summary>
    /// Description of Control.
    /// </summary>
    public class InternalServerControl : DefaultNancyBootstrapper
    {
        static NancyHost _nancyHost;
        
        public static string Url { get; set; }
        
        public static void Start(string url)
        {
            Url = url;
            // setConfiguration();
            // should work without explicit loading of modules
            loadModules();
            registerTypes();
            loadPlugins();
            // setConfiguration();
            
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                Console.WriteLine(assembly.FullName);
            }
            
            _nancyHost = new NancyHost(new Uri(url));
            
            
            
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                Console.WriteLine(assembly.FullName);
            }
            
			_nancyHost.Start();
        }
        
        public static void Stop()
        {
            _nancyHost.Stop();
        }
        
        public static void Reset()
        {
            ClientsCollection.Clients = new System.Collections.Generic.List<Tmx.Interfaces.Remoting.ITestClient>();
            TaskPool.TasksForClients = new System.Collections.Generic.List<Tmx.Interfaces.Remoting.ITestTask>();
            TaskPool.Tasks = new System.Collections.Generic.List<Tmx.Interfaces.Remoting.ITestTask>();
            CommonData.Data = new System.Collections.Generic.Dictionary<string, string>();
        }
        
//    	protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
//    	{
//    		
//    	}
        
        protected override DiagnosticsConfiguration DiagnosticsConfiguration {
            get {
                return new DiagnosticsConfiguration { Password = @"Tmx=admin" };
            }
        }
    	
    	protected override void ConfigureConventions(NancyConventions nancyConventions)
    	{
Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
Console.WriteLine((new TmxServerRootPathProvider()).GetRootPath());
    		nancyConventions.StaticContentsConventions.Add(
    		    StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath(), "Root"));
    	    
    	    // TODO: to a separate assembly
    	    nancyConventions.StaticContentsConventions.Add(
    	        // StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"\Nwx", "Nwx"));
    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"/Nwx", "Nwx"));
    	    
    	    nancyConventions.StaticContentsConventions.Add(
    	        // StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"\results", "results"));
    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"/results", "results"));
    	    
//    	    nancyConventions.StaticContentsConventions.Add(
//    	        // StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"\results", "results"));
//    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"/Views/results", "results2"));
    	    
    		base.ConfigureConventions(nancyConventions);
    	}
    	
    	protected override IRootPathProvider RootPathProvider
    	{
    	    get { return new TmxServerRootPathProvider(); }
    	}
    	
//        static void setConfiguration()
//        {
//            // StaticConfiguration.Caching.EnableRuntimeViewUpdates = true;
//            StaticConfiguration.DisableErrorTraces = false;
//            // StaticConfiguration.EnableRequestTracing = true;
//        }
    	
        static void loadModules()
        {
            var modulesLoader = new ModulesLoader((new TmxServerRootPathProvider()).GetRootPath());
            modulesLoader.Load();
        }
        
        static void registerTypes()
        {
            // Template.RegisterSafeType(typeof(FakeType), new string[] {});
//			Template.RegisterSafeType(typeof(TestSuite), new[] { "Id", "Name", "TestScenarios" });
//			Template.RegisterSafeType(typeof(TestScenario), new[] { "Id", "Name", "Status", "TestResults" });
//			Template.RegisterSafeType(typeof(TestResult), new[] { "Id", "Name", "Status" });
			Template.RegisterSafeType(typeof(ITestSuite), new[] { "Id", "Name", "TestScenarios" });
			Template.RegisterSafeType(typeof(ITestScenario), new[] { "Id", "Name", "Status", "TestResults" });
			Template.RegisterSafeType(typeof(ITestResult), new[] { "Id", "Name", "Status" });
			// Template.RegisterSafeType(typeof(ITestResultDetail), new[] { "Name" });
        }
        
        static void loadPlugins()
        {
            var pluginsLoader = new PluginsLoader((new TmxServerRootPathProvider()).GetRootPath() + @"\Plugins");
            pluginsLoader.Load();
        }
        
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.Caching.EnableRuntimeViewUpdates = true;
            StaticConfiguration.DisableErrorTraces = false;
            StaticConfiguration.EnableRequestTracing = true;
        }
    }
}
