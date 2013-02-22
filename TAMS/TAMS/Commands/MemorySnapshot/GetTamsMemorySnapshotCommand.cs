/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 2/22/2013
 * Time: 9:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TAMS.Commands
{
    using System;
    using System.Management.Automation;
    using System.Diagnostics;
    
    /// <summary>
    /// Description of GetTamsMemorySnapshotCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TamsMemorySnapshot")]
    public class GetTamsMemorySnapshotCommand : MemorySnapshotCmdletBase
    {
        public GetTamsMemorySnapshotCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false,
                   Position = 0,
                   ParameterSetName = "ProcessName",
                   HelpMessage="Accepts the name of a process")]
        [Alias("pn")]
        public string[] ProcessName { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "ProcessId",
                   HelpMessage="Accepts the Id of a process (PID)")]
        [Alias("pid")]
        public int[] ProcessId { get; set; }
        
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "Process",
                   HelpMessage="Accepts a process")]
        [Alias("Process", "p")]
        public Process[] InputObject { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            this.CheckCmdletParameters();
            
            TamsGetMemorySnapshotCommand command =
                new TamsGetMemorySnapshotCommand(this);
            command.Execute();
        }
    }
}
