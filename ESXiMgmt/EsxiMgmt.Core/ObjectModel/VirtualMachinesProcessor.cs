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
    using Data;
    using Interfaces;
    
    /// <summary>
    /// Description of VirtualMachinesProcessor.
    /// </summary>
    public class VirtualMachinesProcessor
    {
        public bool RemoveMachines(IEnumerable<IEsxiVirtualMachine> virtualMachines)
        {
            virtualMachines
                .GroupBy(vm => vm.Server)
                .ToList()
                .ForEach(machineGroup => RemoveMachinesOnServer(machineGroup.First().Server, machineGroup));

            // TODO: make choice on the result of the removal
            return true;
        }

        void RemoveMachinesOnServer(string serverName, IGrouping<string, IEsxiVirtualMachine> machineGroup)
        {
            var codeRunner = new CrossHostCodeRunner();
            // TODO: error handling
            foreach (var virtualMachine in machineGroup)
                codeRunner.Run(
                    ConnectionData.Entries
                        .First(info => 0 == string.Compare(info.Host, serverName, StringComparison.OrdinalIgnoreCase)),
                    string.Format(Commands.RemoveVirtualMachine, virtualMachine.Id)
                    );
        }

        public bool UnregisterMachines(IEnumerable<IEsxiVirtualMachine> virtualMachines)
        {
            virtualMachines
                .GroupBy(vm => vm.Server)
                .ToList()
                .ForEach(machineGroup => UnregisterMachinesOnServer(machineGroup.First().Server, machineGroup));

            // TODO: make choice on the result of the removal
            return true;
        }

        void UnregisterMachinesOnServer(string serverName, IGrouping<string, IEsxiVirtualMachine> machineGroup)
        {
            var codeRunner = new CrossHostCodeRunner();
            // TODO: error handling
            foreach (var virtualMachine in machineGroup)
                codeRunner.Run(
                    ConnectionData.Entries
                        .First(info => 0 == string.Compare(info.Host, serverName, StringComparison.OrdinalIgnoreCase)),
                    string.Format(Commands.UnregisterVirtualMachine, virtualMachine.Id)
                    );
        }
    }
}
