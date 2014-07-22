/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
	using System;
	using System.Management.Automation;
	using Tmx;
	
	/// <summary>
	/// Description of ReceiveTmxTestTaskCommand.
	/// </summary>
	[Cmdlet(VerbsCommunications.Receive, "TmxTestTask")]
	public class ReceiveTmxTestTaskCommand : CommonCmdletBase
	{
		protected override void BeginProcessing()
		{
			var command = new ReceiveTestTaskCommand(this);
			command.Execute();
		}
	}
}
