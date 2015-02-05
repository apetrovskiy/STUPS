/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/1/2013
 * Time: 12:52 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ConnectRMServerCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "RMServer", DefaultParameterSetName = "ConnectRedMine")]
    public class ConnectRMServerCommand : RMConnectCmdletBase
    {
        protected override void BeginProcessing()
        {
			CheckCmdletParameters();
            var command = new RMConnectServerCommand(this);
            command.Execute();
        }
    }
}
