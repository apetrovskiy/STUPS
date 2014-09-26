/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2014
 * Time: 1:30 AM
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
    /// Description of AddTestTaskResultCommand.
    /// </summary>
    class AddTestTaskResultCommand : TmxCommand
    {
        internal AddTestTaskResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (AddTmxTestTaskResultCommand)Cmdlet;
            ClientSettings.Instance.CurrentTask.TaskResult.Add(cmdlet.Key, cmdlet.Value);
            cmdlet.WriteObject(cmdlet, true);
//            var keyValuePair = new CommonDataItem { Key = cmdlet.Key, Value = cmdlet.Value };
//            var commonDataSender = new CommonDataSender(new RestRequestCreator());
//            try {
//                commonDataSender.Send(keyValuePair);
//                cmdlet.WriteObject(true);
//            }
//            catch (Exception e) {
//                throw new Exception("Failed to send data with key '" + cmdlet.Key + "'. " + e.Message);
//            }
        }
    }
}
