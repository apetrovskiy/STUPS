/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/26/2015
 * Time: 3:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Core.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Renci.SshNet;
    using Data;
    using Interfaces;
    
    /// <summary>
    /// Description of VirtualMachinesSelector.
    /// </summary>
    public class VirtualMachinesSelector
    {
        public virtual IEnumerable<IEsxiVirtualMachine> GetMachines(string[] hostnames, int id, string name, string path)
        {
            var connectionInfosApplicable = GetConnectionInfosForSelectedServers(hostnames);
            
            // TODO: use wildcards
            var allVirtualMachinesFromHosts = GetMachinesFromServer(connectionInfosApplicable);
            if ("*" == name || "*" == path)
                return allVirtualMachinesFromHosts;
            return 0 < id ? 
                allVirtualMachinesFromHosts.Where(virtualMachine => virtualMachine.Id == id) : 
                !string.IsNullOrEmpty(name) ? 
                allVirtualMachinesFromHosts.Where(virtualMachine => 0 == string.Compare(virtualMachine.Name, name, StringComparison.OrdinalIgnoreCase)) :
                !string.IsNullOrEmpty(path) ? allVirtualMachinesFromHosts.Where(virtualMachine => 0 == string.Compare(virtualMachine.Path, path, StringComparison.OrdinalIgnoreCase)) :
                allVirtualMachinesFromHosts;
        }
        
        List<ConnectionInfo> GetConnectionInfosForSelectedServers(string[] hostnames)
        {
            // TODO: support for wildcards
            var connectionInfosApplicable = new List<ConnectionInfo>();
            if (hostnames.Any())
                connectionInfosApplicable.AddRange(hostnames.SelectMany(hostname => ConnectionData.Entries.Where(connData => 0 == string.Compare(connData.Host, hostname, StringComparison.OrdinalIgnoreCase))));
            else
                connectionInfosApplicable = ConnectionData.Entries;
            return connectionInfosApplicable;
        }
        
        IEnumerable<IEsxiVirtualMachine> GetMachinesFromServer(IEnumerable<ConnectionInfo> connectionInfos)
        {
            var vms = new List<IEsxiVirtualMachine>();
            
            var codeRunner = new CrossHostCodeRunner();
            Func<PlainTextDataConverter, string, string, List<IEsxiVirtualMachine>> runnerFunc = (runner, textData, server) => runner.GetMachines(textData, server);
            foreach (var connInfo in connectionInfos)
                // TODO: error handling
                vms.AddRange(codeRunner.Run<PlainTextDataConverter, List<IEsxiVirtualMachine>>(connInfo, Commands.GetVirtualMachines, runnerFunc));
            return vms;
        }
    }
}
