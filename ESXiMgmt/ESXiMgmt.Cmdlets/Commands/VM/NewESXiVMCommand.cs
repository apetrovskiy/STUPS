/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 10:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Commands
{
    using System;
    using System.Management.Automation;
    using EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Vm;
        
    /// <summary>
    /// Description of NewEsxiVmCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "EsxiVm")]
    public class NewEsxiVmCommand : CommonCmdletBase
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Path { get; set; }
        
        [Parameter(Mandatory = true)]
        public string Server { get; set; }
        
        protected override void BeginProcessing()
        {
            var command = new NewVmCommand(this);
            command.Execute();
        }
    }
}
