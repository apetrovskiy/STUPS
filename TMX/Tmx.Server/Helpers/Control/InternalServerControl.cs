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
    using Tmx.Server.Helpers.Control;
    
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
            loadPlugins();
            _nancyHost = new NancyHost(new Uri(url));
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
        
    	protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    	{
    		
    	}
        
        protected override DiagnosticsConfiguration DiagnosticsConfiguration {
            get {
                return new DiagnosticsConfiguration { Password = @"Tmx=admin" };
            }
        }
    	
    	protected override void ConfigureConventions(NancyConventions nancyConventions)
    	{
    		nancyConventions.StaticContentsConventions.Add(
    		    StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath(), "Root"));
    	    
    	    // TODO: to a separate assembly
    	    nancyConventions.StaticContentsConventions.Add(
    	        StaticContentConventionBuilder.AddDirectory((new TmxServerRootPathProvider()).GetRootPath() + @"\Nwx", "Nwx"));
    	    
    		base.ConfigureConventions(nancyConventions);
    	}
    	
    	protected override IRootPathProvider RootPathProvider
    	{
    	    get { return new TmxServerRootPathProvider(); }
    	}

        static void loadPlugins()
        {
            // TODO: implement
            var pluginsLoader = new PluginsLoader((new TmxServerRootPathProvider()).GetRootPath() + @"\Plugins");
            pluginsLoader.Load();
        }
    }
}
