/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/18/2014
 * Time: 3:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using Client.Library.Helpers;
    using Client.Library.ObjectModel;
    using Tmx.Client;
    using Tmx.Core;
    using Tmx.Interfaces.Exceptions;
    using Tmx.Commands;
    
    /// <summary>
    /// Description of SendTestCommonDataCommand.
    /// </summary>
    class SendCommonDataItemCommand : TmxCommand
    {
        internal SendCommonDataItemCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (SendTmxCommonDataItemCommand)Cmdlet;
            var keyValuePair = new CommonDataItem { Key = cmdlet.Key, Value = cmdlet.Value };
            var commonDataSender = new CommonDataSender(new RestRequestCreator());
            try {
                commonDataSender.Send(keyValuePair);
                cmdlet.WriteObject(true);
            }
            catch (SendingCommonDataItemException e) {
                // throw new Exception("Failed to send data with key '" + cmdlet.Key + "'. " + e.Message);
                throw;
            }
        }
    }
}
