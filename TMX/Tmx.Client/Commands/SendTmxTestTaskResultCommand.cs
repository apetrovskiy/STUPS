/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/17/2014
 * Time: 7:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Commands
{
	using System;
	using TMX;
	using Tmx.Client.Helpers.Commands;
	
	/// <summary>
	/// Description of SendTmxTestTaskResultCommand.
	/// </summary>
	public class SendTmxTestTaskResultCommand : CommonCmdletBase
	{
		protected override void BeginProcessing()
		{
			var command = new SendTestTaskResultCommand(this);
			command.Execute();
		}
	}
}
