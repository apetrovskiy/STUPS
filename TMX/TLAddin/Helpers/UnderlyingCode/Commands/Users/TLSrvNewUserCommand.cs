/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/9/2013
 * Time: 4:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of TLSrvNewUserCommand.
    /// </summary>
    internal class TLSrvNewUserCommand : TLSrvCommand
    {
        internal TLSrvNewUserCommand(TLSCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            NewTLUserCommand cmdlet = (NewTLUserCommand)this.Cmdlet;
            
            TLHelper.NewUser(
                cmdlet,
                cmdlet.Login,
                cmdlet.Password,
                cmdlet.FirstName,
                cmdlet.LastName,
                cmdlet.Email,
                cmdlet.Role,
                cmdlet.Locale,
                cmdlet.Active,
                cmdlet.Disabled);
        }
    }
}
