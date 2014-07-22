/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/8/2014
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
	using System.Collections.Generic;
	
	/// <summary>
	/// Description of IClientInformation.
	/// </summary>
	public interface IClientInformation
	{
		int Id { get; set; }
		string Hostname { get; set; } // Environment.MachineNam
		string Fqdn { get; set; }
		List<string> IpAddresses { get; set; }
		List<string> MacAddresses { get; set; }
		string UserDomainName { get; set; } // Environment.UserDomainName
		string Username { get; set; } // Environment.UserName aka sAMAccountName
		bool IsInteractive { get; set; } // Environment.UserInteractive
		bool IsAdmin { get; set; }
		string OsVersion { get; set; } // Environment.OSVersion like Microsoft Windows NT 6.2.9200.0
		string EnvironmentVersion { get; set; } // Environment.Version like 2.0.50727.8000
		int UptimeSeconds { get; set; } // Environment.TickCount / 1000
		string CustomString { get; set; }
	}
}
