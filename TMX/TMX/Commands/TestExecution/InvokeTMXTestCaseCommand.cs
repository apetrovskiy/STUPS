/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 4:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
	/// <summary>
	/// Description of InvokeTmxTestCaseCommand.
	/// </summary>
	[Cmdlet(VerbsLifecycle.Invoke, "TmxTestCase")]
	public class InvokeTmxTestCaseCommand : TestCaseExecCmdletBase
	{
		public InvokeTmxTestCaseCommand()
		{
		}
		
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            TmxInvokeTestCaseCommand command =
                new TmxInvokeTestCaseCommand(this);
                // new TmxInvokeTestCaseCommand() { Cmdlet = this };
            command.Execute();
        }
	}
}
