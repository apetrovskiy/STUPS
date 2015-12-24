/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/19/2013
 * Time: 10:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ConnectUiaRemoteDesktopSessionCommand.
    /// </summary>
    [Cmdlet(VerbsCommunications.Connect, "UiaRemoteDesktopSession")]
    public class ConnectUiaRemoteDesktopSessionCommand : RdpCmdletBase
    {
        public ConnectUiaRemoteDesktopSessionCommand()
        {
        }
    }
}
