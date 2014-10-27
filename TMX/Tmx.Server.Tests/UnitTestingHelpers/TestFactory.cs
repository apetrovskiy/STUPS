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
	using Tmx.Server.Modules;
    
    /// <summary>
    /// Description of TestFactory.
    /// </summary>
    public class TestFactory
    {
        public static Browser GetBrowserForTestClientsModule()
        {
            return new Browser(with => with.Module(new TestClientsModule()));
        }
        
        public static Browser GetBrowserForTestTasksModule()
        {
            return new Browser(with => with.Modules(typeof(TestClientsModule), typeof(TestTasksModule)));
        }
        
        public static Browser GetBrowserForServerControlModule()
        {
            return new Browser(with => with.Modules(typeof(ServerControlModule)));
        }
        
        public static Browser GetBrowserForTestRunsModule()
        {
        	return new Browser(with => with.Modules(typeof(TestRunsModule), typeof(ServerControlModule)));
        }
        
        public static Browser GetBrowserForTestResultsModule()
        {
            return new Browser(with => with.Module(new TestResultsModule()));
        }
        
        public static Browser GetBrowserForTestDataModule()
        {
            return new Browser(with => with.Module(new TestDataModule()));
        }
        
        public static ITestClient GivenTestClient(string hostname, string username)
        {
            return new TestClient { Hostname = hostname, Username = username };
        }
    }
}
