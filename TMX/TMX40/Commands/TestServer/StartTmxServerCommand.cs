/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/14/2014
 * Time: 9:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands.TestServer
{
    using System;
    using System.Management.Automation;
    using System.Net;
    using System.Net.NetworkInformation;
    using Helpers.UnderlyingCode.Commands.TestServer;

    /// <summary>
    /// Description of StartTmxServerCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "TmxServer")]
    public class StartTmxServerCommand : ServerCmdletBase
    {
        public StartTmxServerCommand()
        {
            Hostname = Dns.GetHostName();
            if (string.Empty != IPGlobalProperties.GetIPGlobalProperties().DomainName) {
                Hostname += ".";
                Hostname += IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
            Port = 12340;
        }
        
        [Parameter(Mandatory = false,
                   Position = 0)]
        public int Port { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Hostname { get; set; }
        
        protected override void BeginProcessing()
        {
            var basedirPath = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(basedirPath);


            var command = new StartServerCommand(this);
            command.Execute();
        }
    }
}
