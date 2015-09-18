namespace EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Register
{
    using Cmdlets.Commands;
    using Core.ObjectModel;

    class UnregisterVmCommand : EsxiCommand
    {
        internal UnregisterVmCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            Cmdlet.WriteObject(UnregisterVirtualMachines());
        }
        
        bool UnregisterVirtualMachines()
        {
            var cmdlet = (UnregisterESXiVMCommand)Cmdlet;
            var virtualMachinesSelector = new VirtualMachinesSelector();
            var virtualMachines = virtualMachinesSelector.GetMachines(cmdlet.Server, cmdlet.Id, cmdlet.Name, cmdlet.Path);
            var virtualMachinesProcessor = new VirtualMachinesProcessor();
            return virtualMachinesProcessor.UnregisterMachines(virtualMachines);
        }
    }
}