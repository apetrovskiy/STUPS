/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/18/2014
 * Time: 9:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using Tmx.Client;
    using Tmx.Core;
    using Tmx.Commands;
    
    /// <summary>
    /// Description of SendItemCommand.
    /// </summary>
    class SendItemCommand : TmxCommand
    {
        internal SendItemCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (SendTmxItemCommand)Cmdlet;
            var itemSender = new ItemSender(new RestRequestCreator());
            cmdlet.WriteObject(itemSender.SendFileSystemHierarchy(cmdlet.Path, cmdlet.Destination, cmdlet.Recurse));
        }
    }
}
