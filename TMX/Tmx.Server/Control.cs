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
    using Nancy.Hosting.Self;
    
    /// <summary>
    /// Description of Control.
    /// </summary>
    public static class Control
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
    }
}
