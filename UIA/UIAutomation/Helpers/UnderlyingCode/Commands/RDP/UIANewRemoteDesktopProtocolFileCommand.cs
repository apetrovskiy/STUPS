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
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of UIANewRemoteDesktopProtocolFileCommand.
    /// </summary>
    internal class UIANewRemoteDesktopProtocolFileCommand : UIACommand
    {
        internal UIANewRemoteDesktopProtocolFileCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            NewUIARemoteDesktopProtocolFileCommand cmdlet =
                (NewUIARemoteDesktopProtocolFileCommand)this.Cmdlet;

            RDPHelper.CreateRDPFile(cmdlet);
        }
    }
}
