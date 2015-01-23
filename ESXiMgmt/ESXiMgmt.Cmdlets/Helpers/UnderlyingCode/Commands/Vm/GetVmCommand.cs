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
    using Renci.SshNet;
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
            var cmdlet = (GetEsxiVmCommand)Cmdlet;
            
            // TODO: support for wildcards
            var connectionInfosApplicable = ConnectionData.Entries.Where(connInfo => connInfo.Host == cmdlet.Hostname).ToList();
            
            var vms = new List<IEsxiVirtualMachine>();
            
            var codeRunner = new CrossHostCodeRunner();
            Func<PlainTextDataConverter, string, List<IEsxiVirtualMachine>> runnerFunc = (runner, textData) => runner.GetMachines(textData);
            foreach (var connInfo in connectionInfosApplicable)
                // TODO: error handling
                cmdlet.WriteObject(codeRunner.Run<PlainTextDataConverter, List<IEsxiVirtualMachine>>(connInfo, "vim-cmd vmsvc/getallvms", runnerFunc));
        }
    }
}
