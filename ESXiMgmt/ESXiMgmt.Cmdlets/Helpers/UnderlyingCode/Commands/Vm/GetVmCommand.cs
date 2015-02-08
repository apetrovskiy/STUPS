/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 7:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using EsxiMgmt.Core.Data;
    using EsxiMgmt.Core.Interfaces;
    using EsxiMgmt.Core.ObjectModel;
    using EsxiMgmt.Cmdlets.Commands;
    
    /// <summary>
    /// Description of GetVmCommand.
    /// </summary>
    class GetVmCommand : EsxiCommand
    {
        internal GetVmCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            Cmdlet.WriteObject(GetVirtualMachines());
        }
        
        internal IEnumerable<IEsxiVirtualMachine> GetVirtualMachines()
        {
            var cmdlet = (GetEsxiVmCommand)Cmdlet;
            var virtualMachinesSelector = new VirtualMachinesSelector();
            return virtualMachinesSelector.GetMachines(cmdlet.Server, cmdlet.Id, cmdlet.Name, cmdlet.Path);
        }
    }
}
