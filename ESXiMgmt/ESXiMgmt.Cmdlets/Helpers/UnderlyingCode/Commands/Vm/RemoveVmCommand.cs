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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EsxiMgmt.Core.Data;
    using EsxiMgmt.Core.Interfaces;
    using EsxiMgmt.Core.ObjectModel;
    using EsxiMgmt.Cmdlets.Commands.Vm;
    
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
            var cmdlet = (RemoveEsxiVmCommand)Cmdlet;
            
            // TODO: support for wildcards
            var connectionInfosApplicable = ConnectionData.Entries.Where(connInfo => connInfo.Host == cmdlet.Hostname).ToList();
            
            var vms = new List<IEsxiVirtualMachine>();
            
            var codeRunner = new CrossHostCodeRunner();
            Func<PlainTextDataConverter, string, bool> runnerFunc = (runner, textData) => runner.RemoveMachine(textData);
            foreach (var connInfo in connectionInfosApplicable)
                // TODO: error handling
                cmdlet.WriteObject(codeRunner.Run<PlainTextDataConverter, bool>(connInfo, "vim-cmd vmsvc/destroy " + cmdlet.Id, runnerFunc));
        }
    }
}
