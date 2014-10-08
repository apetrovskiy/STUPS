/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2014
 * Time: 4:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core
{
    using System;
	using System.Collections.Generic;
//	using System.Globalization;
//	using System.Net;
//	using System.Net.NetworkInformation;
//	using System.Security.Principal;
	using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestClient.
    /// </summary>
	public class TestClient : ITestClient
	{
	    public TestClient()
	    {
	        var testPlatform = new TestPlatform();
	        Fqdn = testPlatform.Fqdn;
	        Hostname = testPlatform.Hostname;
	        IsInteractive = testPlatform.IsInteractive;
	        IsAdmin = testPlatform.IsAdmin;
            // EnvironmentVersion = Environment.Version.Major + "." + Environment.Version.MajorRevision + "." + Environment.Version.Minor + "." + Environment.Version.MinorRevision + "." + Environment.Version.Build;
            Language = testPlatform.Language;
            OsBits = testPlatform.OsBits;
            // OsEdition = "";
            // OsName = "";
            OsVersion = testPlatform.OsVersion;
            ProcessBits = testPlatform.ProcessBits;
            UptimeSeconds = testPlatform.UptimeSeconds;
            Username = testPlatform.Username;
            UserDomainName = testPlatform.UserDomainName;
            Status = TestClientStatuses.NoTasks;
	    }
	    
		public int Id { get; set; }
		public string Hostname { get; set; } // Environment.MachineNam
		public string Fqdn { get; set; }
		public List<string> IpAddresses { get; set; }
		public List<string> MacAddresses { get; set; }
		public string UserDomainName { get; set; } // Environment.UserDomainName
		public string Username { get; set; } // Environment.UserName aka sAMAccountName
		public bool IsInteractive { get; set; } // Environment.UserInteractive
		public bool IsAdmin { get; set; }
		public int OsBits { get; set; }
		// public string OsEdition { get; set; }
		// public string OsName { get; set; }
		public string OsVersion { get; set; } // Environment.OSVersion like Microsoft Windows NT 6.2.9200.0
		public int ProcessBits { get; set; }
		public string Language { get; set; }
		public string EnvironmentVersion { get; set; } // Environment.Version like 2.0.50727.8000
		public int UptimeSeconds { get; set; } // Environment.TickCount / 1000
		public string CustomString { get; set; }
		public TestClientStatuses Status { get; set; }
		// 20141003
		public int TaskId { get; set; }
		public string TaskName { get; set; }
		public string DetailedStatus { get; set; }
		public int WorkflowId { get; set; }
	}
}
