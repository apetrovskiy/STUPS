/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tmx;
	using Tmx.Client;
	using Tmx.Commands;
	
	/// <summary>
	/// Description of SendTestTaskResultCommand.
	/// </summary>
    class SendTestTaskResultCommand : TmxCommand
    {
        internal SendTestTaskResultCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (SendTmxTestTaskResultCommand)Cmdlet;
            if (null == ClientSettings.CurrentTask) throw new Exception("Failed to send data to the task.");
            ClientSettings.CurrentTask.TaskResult = cmdlet.Result;
            // var taskUpdater = new TaskUpdater();
            var taskUpdater = new TaskUpdater(new RestRequestCreator());
            // cmdlet.WriteObject(taskUpdater.UpdateTask());
            cmdlet.WriteObject(taskUpdater.UpdateTask(ClientSettings.CurrentTask));
        }
    }
}
