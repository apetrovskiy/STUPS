/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
	using System;
	using System.Management.Automation;
	using Tmx;
	
	/// <summary>
	/// Description of RegisterTmxSystemUnderTestCommand.
	/// </summary>
	[Cmdlet(VerbsLifecycle.Register, "TmxSystemUnderTest")]
	public class RegisterTmxSystemUnderTestCommand : ClientCmdletBase
	{
	    public RegisterTmxSystemUnderTestCommand()
	    {
	        Seconds = Preferences.DefaultRegistrationTimeoutSeconds;
	    }
	    
	    [Parameter(Mandatory = true)]
	    public string ServerUrl { get; set; }
	    
	    [Parameter(Mandatory = false)]
	    public int Seconds { get; set; }
	    
		protected override void BeginProcessing()
		{
			var command = new RegisterSystemUnderTestCommand(this);
			command.Execute();
		}
	}
}
