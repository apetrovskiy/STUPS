/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 10:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands
{
    using System.Management.Automation;
    using Helpers.UnderlyingCode.Commands.Register;

    /// <summary>
    /// Description of UnregisterESXiVMCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "ESXiVM")]
    public class UnregisterESXiVMCommand : VmListCmdletBase
    {
        public UnregisterESXiVMCommand()
        {
            var command = new UnregisterVmCommand(this);
            command.Execute();
        }
    }
}
