/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2014
 * Time: 9:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests
{
    using System;
    using Nancy;
    using Nancy.Testing;
	using Tmx.Core;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestFactory.
    /// </summary>
    public class TestFactory
    {
        public static Browser GetBrowser()
        {
            return new Browser(new DefaultNancyBootstrapper());
        }
        
        public static ITestClient GivenTestClient(string hostname, string username)
        {
            return new TestClient { Hostname = hostname, Username = username };
        }
    }
}
