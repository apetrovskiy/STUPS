/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 8:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Connect
{
    using System;
    using EsxiMgmt.Core.Data;
    using Renci.SshNet;
    using EsxiMgmt.Cmdlets.Commands.Connect;
    
    /// <summary>
    /// Description of NewHostConnectionDataCommand.
    /// </summary>
    class NewHostConnectionDataCommand : EsxiCommand
    {
        internal NewHostConnectionDataCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (NewEsxiHostConnectionDataCommand)Cmdlet;
            
            var connInfo = new ConnectionInfo(
                               cmdlet.Hostname,
                               cmdlet.Username,
                               new AuthenticationMethod[] {
                    new PasswordAuthenticationMethod(cmdlet.Username, cmdlet.Password),
                    new PrivateKeyAuthenticationMethod(
                        cmdlet.Username,
                        new [] { new PrivateKeyFile(cmdlet.KeyFilePath, cmdlet.Password) }),
                });
            
            ConnectionData.Entries.Add(connInfo);
            
            cmdlet.WriteObject(true);
        }
    }
}
