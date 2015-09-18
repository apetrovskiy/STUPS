/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 11:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Vm
{
    using Core.ObjectModel;
    using Cmdlets.Commands.Vm;
    
    /// <summary>
    /// Description of RemoveVmCommand.
    /// </summary>
    class RemoveVmCommand : EsxiCommand
    {
        internal RemoveVmCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            Cmdlet.WriteObject(RemoveVirtualMachines());
        }
        
        bool RemoveVirtualMachines()
        {
            var cmdlet = (RemoveEsxiVmCommand)Cmdlet;
            var virtualMachinesSelector = new VirtualMachinesSelector();
            var virtualMachines = virtualMachinesSelector.GetMachines(cmdlet.Server, cmdlet.Id, cmdlet.Name, cmdlet.Path);
            var virtualMachinesProcessor = new VirtualMachinesProcessor();
            return virtualMachinesProcessor.RemoveMachines(virtualMachines);
        }
    }
}
