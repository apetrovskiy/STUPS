/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
	using System;
	using System.Management.Automation;
	using Tmx;
	
	/// <summary>
	/// Description of SendTmxTestTaskResultCommand.
	/// </summary>
	[Cmdlet(VerbsCommunications.Send, "TmxTestTaskResult")]
	public class SendTmxTestTaskResultCommand : CommonCmdletBase
	{
		protected override void BeginProcessing()
		{
			var command = new SendTestTaskResultCommand(this);
			command.Execute();
		}
	}
}
