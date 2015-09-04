/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 11:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands.Vm
{
    using System.Management.Automation;
    using Helpers.UnderlyingCode.Commands.Vm;
    
    /// <summary>
    /// Description of RemoveEsxiVmCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "EsxiVm")]
    public class RemoveEsxiVmCommand : VmListCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new RemoveVmCommand(this);
            command.Execute();
        }
    }
}
