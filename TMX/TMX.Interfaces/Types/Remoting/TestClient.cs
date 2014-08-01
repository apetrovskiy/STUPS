/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 8:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
	using System;
	using System.Collections.Generic;
	using Tmx.Interfaces.Remoting;
	
	/// <summary>
	/// Description of TestClient.
	/// </summary>
	public class TestClient : ITestClient
	{
		public int Id { get; set; }
		public string Hostname { get; set; } // Environment.MachineNam
		public string Fqdn { get; set; }
		public List<string> IpAddresses { get; set; }
		public List<string> MacAddresses { get; set; }
		public string UserDomainName { get; set; } // Environment.UserDomainName
		public string Username { get; set; } // Environment.UserName aka sAMAccountName
		public bool IsInteractive { get; set; } // Environment.UserInteractive
		public bool IsAdmin { get; set; }
		public string OsVersion { get; set; } // Environment.OSVersion like Microsoft Windows NT 6.2.9200.0
		public string EnvironmentVersion { get; set; } // Environment.Version like 2.0.50727.8000
		public int UptimeSeconds { get; set; } // Environment.TickCount / 1000
		public string CustomString { get; set; }
	}
}
