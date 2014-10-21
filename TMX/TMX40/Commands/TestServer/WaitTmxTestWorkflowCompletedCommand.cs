/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/10/2014
 * Time: 6:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    using Ninject.Parameters;
	using PSTestLib;
    
    /// <summary>
    /// Description of WaitTmxTestWorkflowCompletedCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "TmxTestWorkflowCompleted")]
    public class WaitTmxTestWorkflowCompletedCommand : ServerCmdletBase
    {
        [Parameter(Mandatory = false)]
        public string Name { get; set; }
        
		protected override void BeginProcessing()
		{
			var command = new WaitTestWorkflowCompletedCommand(this);
			command.Execute();
		}
    }
}
