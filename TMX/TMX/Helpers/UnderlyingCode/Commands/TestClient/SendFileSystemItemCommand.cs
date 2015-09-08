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
    using Client.Library.Helpers;
    using Client.Library.ObjectModel;
    using Commands;
    
    /// <summary>
    /// Description of SendFileSystemItemCommand.
    /// </summary>
    class SendFileSystemItemCommand : TmxCommand
    {
        internal SendFileSystemItemCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (SendTmxFileSystemItemCommand)Cmdlet;
            var itemSender = new ItemSender(new RestRequestCreator());
            cmdlet.WriteObject(itemSender.SendFileSystemHierarchy(cmdlet.Path, cmdlet.Destination, cmdlet.Recurse, cmdlet.Force));
        }
    }
}
