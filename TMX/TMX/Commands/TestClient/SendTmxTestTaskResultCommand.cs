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
	using System.Collections.Generic;
	using System.Management.Automation;
	using Tmx;
	
	/// <summary>
	/// Description of SendTmxTestTaskResultCommand.
	/// </summary>
	[Cmdlet(VerbsCommunications.Send, "TmxTestTaskResult")]
	public class SendTmxTestTaskResultCommand : ClientCmdletBase
	{
		[Parameter(Mandatory = true,
		           Position = 0,
		           ValueFromPipeline = true)]
		[ValidateNotNull]
		public string[] Result { get; set; }
//		
//		[Parameter(Mandatory = true,
//		           Position = 1)]
//		public int ClientId { get; set; }
		
		protected override void ProcessRecord()
		{
			var command = new SendTestTaskResultCommand(this);
			command.Execute();
		}
	}
}
