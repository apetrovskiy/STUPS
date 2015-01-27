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
    using System.Globalization;
    using System.Linq;
    using Renci.SshNet;
    using EsxiMgmt.Core.Data;
    using EsxiMgmt.Core.Interfaces;
    
    /// <summary>
    /// Description of VirtualMachinesSelector.
    /// </summary>
    public class VirtualMachinesSelector
    {
        public IEnumerable<IEsxiVirtualMachine> GetMachines(string[] hostnames, int id, string name, string path)
        {
            var connectionInfosApplicable = getConnectionInfosForSelectedServers(hostnames);
            
            // TODO: use wildcards
            var allVirtualMachinesFromHosts = getMachinesFromServer(connectionInfosApplicable);
            if ("*" == name || "*" == path) return allVirtualMachinesFromHosts;
            return 0 < id ? 
                allVirtualMachinesFromHosts.Where(virtualMachine => virtualMachine.Id == id) : 
                !string.IsNullOrEmpty(name) ? 
                    allVirtualMachinesFromHosts.Where(virtualMachine => virtualMachine.Name == name) : 
                    !string.IsNullOrEmpty(path) ? allVirtualMachinesFromHosts.Where(virtualMachine => virtualMachine.Path == path) : 
                allVirtualMachinesFromHosts;
        }
        
        List<ConnectionInfo> getConnectionInfosForSelectedServers(string[] hostnames)
        {
            // TODO: support for wildcards
            var connectionInfosApplicable = new List<ConnectionInfo>();
            if (hostnames.Any())
                connectionInfosApplicable.AddRange(hostnames.SelectMany(hostname => ConnectionData.Entries.Where(connData => 0 == string.Compare(connData.Host, hostname, StringComparison.OrdinalIgnoreCase))));
            else
                connectionInfosApplicable = ConnectionData.Entries;
            return connectionInfosApplicable;
        }
        
        IEnumerable<IEsxiVirtualMachine> getMachinesFromServer(List<ConnectionInfo> connectionInfos)
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
