/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/7/2014
 * Time: 8:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using Tmx.Client;
    using Tmx.Commands;
    
    /// <summary>
    /// Description of ConnectServerCommand.
    /// </summary>
    class SetServerSettingsCommand : TmxCommand
    {
        internal SetServerSettingsCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (SetTmxServerSettingsCommand)Cmdlet;
            var clientSettings = ClientSettings.Instance;
            clientSettings.ServerUrl = cmdlet.ServerUrl;
        }
    }
}
