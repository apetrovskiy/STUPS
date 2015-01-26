/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/24/2015
 * Time: 11:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands.Vm
{
    using System;
    using System.Management.Automation;
    using EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Vm;
    
    /// <summary>
    /// Description of StartEsxiVmCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "EsxiVm")]
    public class StartEsxiVmCommand : CommonCmdletBase
    {
        protected override void ProcessRecord()
        {
            var command = new StartVmCommand(this);
            command.Execute();
        }
    }
}
