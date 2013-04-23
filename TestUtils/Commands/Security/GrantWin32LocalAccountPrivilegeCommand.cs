/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/12/2013
 * Time: 8:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TestUtils.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of GrantWin32LocalAccountPrivilegeCommand.
    /// </summary>
    public class GrantWin32LocalAccountPrivilegeCommand : PrivilegeCmdletBase
    {
        public GrantWin32LocalAccountPrivilegeCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            Win32GrantLocalAccountPrivilegeCommand command =
                new Win32GrantLocalAccountPrivilegeCommand(this);
            command.Execute();
        }
    }
}
