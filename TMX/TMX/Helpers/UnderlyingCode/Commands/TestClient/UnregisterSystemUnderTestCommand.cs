/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 6:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using System.Management.Automation;
	using Tmx;
	using Tmx.Client;
	using Tmx.Commands;
	
    /// <summary>
    /// Description of UnregisterSystemUnderTestCommand.
    /// </summary>
    class UnregisterSystemUnderTestCommand : TmxCommand
    {
        internal UnregisterSystemUnderTestCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (UnregisterTmxSystemUnderTestCommand)Cmdlet;
            var registration = new Registration(new RestRequestCreator());
            registration.UnregisterClient();
        }
    }
}
