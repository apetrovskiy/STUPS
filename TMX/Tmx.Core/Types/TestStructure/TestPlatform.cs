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
    using System.Xml;
    using System.Xml.Serialization;
	using Tmx.Interfaces.TestStructure;
    
    /// <summary>
    /// Description of TestPlatform.
    /// </summary>
    public class TestPlatform : ITestPlatform
    {
//        public TestPlatform(string name, string id) : this()
//        {
//            UniqueId = Guid.NewGuid();
//            this.Name = name;
//            this.Id = id;
//        }
        
//        public TestPlatform()
//        {
//            UniqueId = Guid.NewGuid();
//        }
        
        public TestPlatform()
        {
            UniqueId = Guid.NewGuid();
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
            Version = Environment.OSVersion.VersionString;
            Architecture = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
        }
        
        [XmlAttribute]
        public virtual Guid UniqueId { get; set; }
        
        [XmlAttribute]
        public virtual string Name { get; set; }
        [XmlAttribute]
        public virtual string Id { get; set; }
        [XmlAttribute]
        public virtual string Description { get; set; }
        
        [XmlAttribute]
        public virtual string OperatingSystem { get; set; }
        [XmlAttribute]
        public virtual string Version { get; set; }
        [XmlAttribute]
        public virtual string Architecture { get; set; }
        [XmlAttribute]
        public virtual string Language { get; set; }
        
        [XmlAttribute]
		public string Hostname { get; set; } // Environment.MachineNam
		[XmlAttribute]
		public string Fqdn { get; set; }
		[XmlIgnore]
		public List<string> IpAddresses { get; set; }
		[XmlIgnore]
		public List<string> MacAddresses { get; set; }
		[XmlAttribute]
		public string UserDomainName { get; set; } // Environment.UserDomainName
		[XmlAttribute]
		public string Username { get; set; } // Environment.UserName aka sAMAccountName
		[XmlAttribute]
		public bool IsInteractive { get; set; } // Environment.UserInteractive
		[XmlAttribute]
		public bool IsAdmin { get; set; }
		[XmlAttribute]
		public int OsBits { get; set; }
		// public string OsEdition { get; set; }
		// public string OsName { get; set; }
		[XmlAttribute]
		public string OsVersion { get; set; } // Environment.OSVersion like Microsoft Windows NT 6.2.9200.0
		[XmlAttribute]
		public int ProcessBits { get; set; }
//		public string Language { get; set; }
		[XmlAttribute]
		public string EnvironmentVersion { get; set; } // Environment.Version like 2.0.50727.8000
		[XmlAttribute]
		public int UptimeSeconds { get; set; } // Environment.TickCount / 1000
		[XmlAttribute]
		public string CustomString { get; set; }
		
        bool isAdministrator()
        {
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
