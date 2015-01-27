/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/26/2015
 * Time: 8:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Core.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EsxiMgmt.Core.Data;
    using EsxiMgmt.Core.Interfaces;
    
    /// <summary>
    /// Description of VirtualMachinesProcessor.
    /// </summary>
    public class VirtualMachinesProcessor
    {
        public bool RemoveMachines(IEnumerable<IEsxiVirtualMachine> virtualMachines)
        {
            var groupedByServerVirtualMachines = virtualMachines.GroupBy(vm => vm.Server);
            foreach (var machineGroup in groupedByServerVirtualMachines) {
                removeMachinesOnServer(machineGroup.First().Server, machineGroup);
            }
            return true;
        }
        
        void removeMachinesOnServer(string serverName, IGrouping<string, IEsxiVirtualMachine> machineGroup)
        {
            var codeRunner = new CrossHostCodeRunner();
                // TODO: error handling
            foreach (var virtualMachine in machineGroup) {
                codeRunner.Run(
                    ConnectionData.Entries.First(info => info.Host == serverName),
                    string.Format(Commands.RemoveVirtualMachine, virtualMachine.Id)
                );
            }
        }
    }
}
