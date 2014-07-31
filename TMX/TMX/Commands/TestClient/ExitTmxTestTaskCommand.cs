/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 8:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
	using System;
	using System.Management.Automation;
	using Tmx;
	
    /// <summary>
    /// Description of ExitTmxTestTaskCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Exit, "TmxTestTask")]
    public class ExitTmxTestTaskCommand : ClientCmdletBase
    {
		protected override void BeginProcessing()
		{
			var command = new ExitTestTaskCommand(this);
			command.Execute();
		}
    }
}
