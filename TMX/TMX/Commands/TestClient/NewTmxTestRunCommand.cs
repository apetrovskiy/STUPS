/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/29/2014
 * Time: 8:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of NewTmxTestRunCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TmxTestRun")]
    public class NewTmxTestRunCommand : ClientCmdletBase
    {
        [Parameter(Mandatory = true,
                   Position = 0)]
        [ValidateNotNullOrEmpty]
        public new string Name { get; set; }
        
        [Parameter(Mandatory = true,
                   Position = 1)]
        [ValidateNotNullOrEmpty]
        public string WorkflowName { get; set; }
        
        // TODO: restrict using Completed
        [Parameter(Mandatory = true,
                   Position = 2)]
        [ValidateSet("Running", "Scheduled")]
        public TestRunStatuses Status { get; set; }
        
		protected override void BeginProcessing()
		{
			var command = new NewTestRunCommand(this);
			command.Execute();
		}
    }
}
