/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/12/2013
 * Time: 8:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Win32Utils
{
    using System;
    using System.Management.Automation;
    using Win32Utils.Commands;
    
    /// <summary>
    /// Description of Win32SetLocalAccountPrivilegeCommand.
    /// </summary>
    internal class Win32SetLocalAccountPrivilegeCommand : Win32Command
    {
        internal Win32SetLocalAccountPrivilegeCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SetWin32LocalAccountPrivilegeCommand cmdlet =
                (SetWin32LocalAccountPrivilegeCommand)this.Cmdlet;
            
            
        }
    }
}
