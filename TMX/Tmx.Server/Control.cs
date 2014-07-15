/*
 * Created by SharpDevelop.
 * User: Alexander
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
    
    /// <summary>
    /// Description of Control.
    /// </summary>
    public class Control : DefaultNancyBootstrapper
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
        
        protected override DiagnosticsConfiguration DiagnosticsConfiguration {
            get {
                return new DiagnosticsConfiguration { Password = @"=1qwerty" };
            }
        }
    }
}
