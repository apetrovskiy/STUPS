/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/1/2013
 * Time: 1:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of RMConnectServerCommand.
    /// </summary>
    internal class RMConnectServerCommand : RMSrvCommand
    {
        internal RMConnectServerCommand(RMCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            RMHelper.ConnectRMServer(
                (RMConnectCmdletBase)this.Cmdlet);
        }
    }
}
