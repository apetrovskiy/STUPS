/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Client.Helpers.Commands
{
	using System;
	using TMX;
	using Tmx.Client.Helpers;
	using TMX.Commands;
	
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
            ClientSettings.ServerUrl = cmdlet.ServerUrl;
        }
    }
}
