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
    using PSTestLib;
    
    /// <summary>
    /// Description of UiaNewRemoteDesktopProtocolFileCommand.
    /// </summary>
    public class NewRemoteDesktopProtocolFileCommand : AbstractCommand	// : UiaCommand
    {
        public NewRemoteDesktopProtocolFileCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        public override void Execute()
        {
            var cmdlet =
                (NewUiaRemoteDesktopProtocolFileCommand)Cmdlet;

            RdpHelper.CreateRdpFile(cmdlet);
        }
    }
}
