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
	using Nancy;
    using Nancy.Hosting.Self;
    using Nancy.Diagnostics;
	using Tmx.Core;
    
    /// <summary>
    /// Description of Control.
    /// </summary>
    public class InternalServerControl : DefaultNancyBootstrapper
    {
        static NancyHost _nancyHost;
        
        public static void Start(string url)
        {
            _nancyHost = new NancyHost(new Uri(url));
			_nancyHost.Start();
        }
        
        public static void Stop()
        {
            _nancyHost.Stop();
        }
        
        public static void Reset()
        {
            /*
            ClientsCollection.Clients.Clear();
            TaskPool.TasksForClients.Clear();
            TaskPool.Tasks.Clear();
            CommonData.Data.Clear();
            */
            ClientsCollection.Clients = new System.Collections.Generic.List<Tmx.Interfaces.Remoting.ITestClient>();
            TaskPool.TasksForClients = new System.Collections.Generic.List<Tmx.Interfaces.Remoting.ITestTask>();
            TaskPool.Tasks = new System.Collections.Generic.List<Tmx.Interfaces.Remoting.ITestTask>();
            CommonData.Data = new System.Collections.Generic.Dictionary<string, string>();
        }
        
        protected override DiagnosticsConfiguration DiagnosticsConfiguration {
            get {
                return new DiagnosticsConfiguration { Password = @"=1qwerty" };
            }
        }
    }
}
