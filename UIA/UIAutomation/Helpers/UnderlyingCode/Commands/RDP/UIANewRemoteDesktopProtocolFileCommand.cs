/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/26/2013
 * Time: 2:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using Commands;
    
    /// <summary>
    /// Description of UiaNewRemoteDesktopProtocolFileCommand.
    /// </summary>
    internal class UiaNewRemoteDesktopProtocolFileCommand : UiaCommand
    {
        internal UiaNewRemoteDesktopProtocolFileCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            NewUiaRemoteDesktopProtocolFileCommand cmdlet =
                (NewUiaRemoteDesktopProtocolFileCommand)Cmdlet;

            RdpHelper.CreateRdpFile(cmdlet);
        }
    }
}
