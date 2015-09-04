/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 6:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands
{
    using System.Management.Automation;
    using Helpers.UnderlyingCode.Commands.Vm;
    
    /// <summary>
    /// Description of GetEsxiVmCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "EsxiVm")]
    public class GetEsxiVmCommand : VmListCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new GetVmCommand(this);
            command.Execute();
        }
    }
}
