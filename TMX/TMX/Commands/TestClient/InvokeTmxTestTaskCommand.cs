/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/28/2014
 * Time: 8:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
	using System;
	using System.Management.Automation;
	using Tmx;
	using Tmx.Interfaces.Remoting;
	
    /// <summary>
    /// Description of InvokeTmxTestTaskCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TmxTestTask")]
    public class InvokeTmxTestTaskCommand : ClientCmdletBase
    {
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipeline = true)]
        // public ITestTask[] InputObject { get; set; }
        public ITestTask InputObject { get; set; }
        
        protected override void ProcessRecord()
        {
            var command = new InvokeTestTaskCommand(this);
            command.Execute();
        }
    }
}
