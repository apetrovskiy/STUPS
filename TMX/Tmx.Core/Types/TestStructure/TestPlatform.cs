/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/25/2013
 * Time: 11:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Net;
	using System.Net.NetworkInformation;
	using System.Security.Principal;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestPlatform.
    /// </summary>
    public class TestPlatform : ITestPlatform
    {
        public TestPlatform(string name, string id) : this()
        {
            this.Name = name;
            this.Id = id;
        }
        
        public TestPlatform()
        {
	        Fqdn = Dns.GetHostName() + "." + IPGlobalProperties.GetIPGlobalProperties().DomainName;
	        Hostname = Environment.MachineName;
	        IsInteractive = Environment.UserInteractive;
	        IsAdmin = isAdministrator();
            // EnvironmentVersion = Environment.Version.Major + "." + Environment.Version.MajorRevision + "." + Environment.Version.Minor + "." + Environment.Version.MinorRevision + "." + Environment.Version.Build;
            Language = CultureInfo.CurrentCulture.EnglishName;
            // OsBits
            // OsEdition = "";
            // OsName = "";
            OsVersion = Environment.OSVersion.VersionString;
            ProcessBits = IntPtr.Size * 8;
            UptimeSeconds = Environment.TickCount / 1000;
            Username = Environment.UserName;
            UserDomainName = Environment.UserDomainName;
        }
        
        public virtual int DbId { get; set; }
        
        public virtual string Name { get; set; }
        public virtual string Id { get; set; }
        public virtual string Description { get; set; }

        public virtual string OperatingSystem { get; set; }
        public virtual string Version { get; set; }
        public virtual string Architecture { get; set; }
        public virtual string Language { get; set; }
        
//		public int Id { get; set; }
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
//		public string Language { get; set; }
		public string EnvironmentVersion { get; set; } // Environment.Version like 2.0.50727.8000
		public int UptimeSeconds { get; set; } // Environment.TickCount / 1000
		public string CustomString { get; set; }
		
        bool isAdministrator()
        {
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
