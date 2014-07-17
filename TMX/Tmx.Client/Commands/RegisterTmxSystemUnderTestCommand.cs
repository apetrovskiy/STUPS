/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/17/2014
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Commands
{
	using System;
	using System.Management.Automation;
	using TMX;
	using Tmx.Client.Helpers.Commands;
	
	/// <summary>
	/// Description of RegisterTmxSystemUnderTestCommand.
	/// </summary>
	[Cmdlet(VerbsLifecycle.Register, "TmxSystemUnderTest")]
	public class RegisterTmxSystemUnderTestCommand : CommonCmdletBase
	{
		protected override void BeginProcessing()
		{
			var command = new RegisterSystemUnderTestCommand(this);
			command.Execute();
		}
	}
}
