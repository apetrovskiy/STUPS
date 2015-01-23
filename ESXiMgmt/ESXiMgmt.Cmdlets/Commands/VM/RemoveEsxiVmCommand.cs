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
    using System;
    using System.Management.Automation;
    using EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Vm;
    
    /// <summary>
    /// Description of RemoveEsxiVmCommand.
    /// </summary>
    public class RemoveEsxiVmCommand : CommonCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "ById")]
        public int Id { get; set; }
        
        [Parameter(Mandatory = true, ParameterSetName = "ByName")]
        public string Name { get; set; }
        
        [Parameter(Mandatory = true, ParameterSetName = "ByPath")]
        public string Path { get; set; }
        
        [Parameter(Mandatory = false)]
        public string Hostname { get; set; }
        
        protected override void BeginProcessing()
        {
            var command = new RemoveVmCommand(this);
            command.Execute();
        }
    }
}
