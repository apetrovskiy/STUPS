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
    using System;
    using System.Management.Automation;
    using EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Vm;
    
    /// <summary>
    /// Description of GetEsxiVmCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "EsxiVm")]
    public class GetEsxiVmCommand : CommonCmdletBase
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
            var command = new GetVmCommand(this);
            command.Execute();
        }
    }
}
