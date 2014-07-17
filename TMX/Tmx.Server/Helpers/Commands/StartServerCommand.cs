/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/17/2014
 * Time: 7:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Helpers.Commands
{
	using System;
	using TMX;
	using Tmx.Server.Commands;
	
	/// <summary>
	/// Description of StartServerCommand.
	/// </summary>
    class StartServerCommand : TmxCommand
    {
        internal StartServerCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (StartTmxServerCommand)Cmdlet;
            Control.Start(@"http://localhost:" + cmdlet.Port);
        }
    }
}
