/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/26/2015
 * Time: 9:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Vm
{
    using System;
    using System.Linq;
    using EsxiMgmt.Core.Data;
    using EsxiMgmt.Core.Interfaces;
    using EsxiMgmt.Core.ObjectModel;
    using EsxiMgmt.Core.Types;
    using EsxiMgmt.Cmdlets.Commands;
    
    /// <summary>
    /// Description of NewVmCommand.
    /// </summary>
    class NewVmCommand : EsxiCommand
    {
        internal NewVmCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            Cmdlet.WriteObject(NewVirtualMachine());
        }
        
        internal IEsxiVirtualMachine NewVirtualMachine()
        {
            var cmdlet = (NewEsxiVmCommand)Cmdlet;
//            var virtualMachinesSelector = new VirtualMachinesSelector();
//            var virtualMachines = virtualMachinesSelector.GetMachines(cmdlet.Server, cmdlet.Id, cmdlet.Name, cmdlet.Path);
//            var virtualMachinesProcessor = new VirtualMachinesProcessor();
//            return virtualMachinesProcessor.RemoveMachines(virtualMachines);
            
            // var vms = new List<IEsxiVirtualMachine>();
            
            var codeRunner = new CrossHostCodeRunner();
            Func<VirtualMachineCreator, string, string, VirtualMachine> runnerFunc = (runner, textData, server) => runner.Create(cmdlet.Name, cmdlet.Path);
            return codeRunner.Run<VirtualMachineCreator, VirtualMachine>(
                ConnectionData.Entries.First(cInfo => cInfo.Host == cmdlet.Server),
                // Commands.CreateVirtualMachine,
                string.Format(Commands.CreateVirtualMachine, cmdlet.Name, cmdlet.Path),
                runnerFunc);
            // foreach (var connInfo in connectionInfos)
                // TODO: error handling
                // vms.AddRange(codeRunner.Run<PlainTextDataConverter, List<IEsxiVirtualMachine>>(connInfo, Commands.GetVirtualMachines, runnerFunc));
            // return vms;
        }
    }
}
