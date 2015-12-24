/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/24/2015
 * Time: 11:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Vm
{
    using Cmdlets.Commands.Vm;
    
    /// <summary>
    /// Description of StartVmCommand.
    /// </summary>
    class StartVmCommand : EsxiCommand
    {
        internal StartVmCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (StartEsxiVmCommand)Cmdlet;
            
//            // TODO: support for wildcards
//            var connectionInfosApplicable = ConnectionData.Entries.Where(connInfo => connInfo.Host == cmdlet.Hostname).ToList();
//            
//            var vms = new List<IEsxiVirtualMachine>();
//            
//            var codeRunner = new CrossHostCodeRunner();
//            Func<PlainTextDataConverter, string, bool> runnerFunc = (runner, textData) => runner.RemoveMachine(textData);
//            foreach (var connInfo in connectionInfosApplicable)
//                // TODO: error handling
//                cmdlet.WriteObject(codeRunner.Run<PlainTextDataConverter, bool>(connInfo, "vim-cmd vmsvc/power.on " + cmdlet.Id, runnerFunc));
        }
    }
}
