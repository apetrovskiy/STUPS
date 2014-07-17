/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/17/2014
 * Time: 7:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.Helpers.Commands
{
	using System;
	using TMX;
	using Tmx.Client.Commands;
	
	/// <summary>
	/// Description of RegisterSystemUnderTestCommand.
	/// </summary>
    class RegisterSystemUnderTestCommand : TmxCommand
    {
        internal RegisterSystemUnderTestCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (RegisterTmxSystemUnderTestCommand)Cmdlet;
            // cmdlet.Execute();
        }
    }
}
