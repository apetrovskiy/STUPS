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
    using EsxiMgmt.Core.ObjectModel;
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
        
        internal bool NewVirtualMachine()
        {
            var cmdlet = (NewEsxiVmCommand)Cmdlet;
            var codeRunner = new CrossHostCodeRunner();
            return codeRunner.Run(
                ConnectionData.Entries.First(cInfo => cInfo.Host == cmdlet.Server),
                string.Format(Commands.CreateVirtualMachine, cmdlet.Name, cmdlet.Path)
            );
        }
    }
}
