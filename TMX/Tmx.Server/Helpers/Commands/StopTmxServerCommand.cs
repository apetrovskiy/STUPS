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
	
	/// <summary>
	/// Description of StopTmxServerCommand.
	/// </summary>
    class StopServerCommand : TmxCommand
    {
        internal StopServerCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            // var cmdlet = (StopTmxServerCommand)Cmdlet;
            
            Control.Stop();
        }
    }
}
