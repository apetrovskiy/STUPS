/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/9/2013
 * Time: 4:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewTLUserCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TLUser")]
    internal class NewTLUserCommand : TLUserCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new TLSrvNewUserCommand(this);
            command.Execute();
        }
    }
}
