/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2013
 * Time: 8:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils
{
    using System;
    using System.Management.Automation;
    using TestUtils.Commands;
    
    /// <summary>
    /// Description of Win32GrantLocalAccountPrivilegeCommand.
    /// </summary>
    internal class Win32GrantLocalAccountPrivilegeCommand : Win32Command
    {
        internal Win32GrantLocalAccountPrivilegeCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (GrantWin32LocalAccountPrivilegeCommand)Cmdlet;
            
            Win32Helper.GrantAccountPrivilege(cmdlet);
        }
    }
}
