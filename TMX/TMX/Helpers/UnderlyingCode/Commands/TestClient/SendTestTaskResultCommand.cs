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
	using Tmx.Core.Types.Remoting;
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
            var taskUpdater = new TaskUpdater(new RestRequestCreator());
            // 20140926
            // var testTask = new TestTask { TaskResult = new Dictionary<string, string>() };
            var testTask = new TestTask();
            foreach (var key in cmdlet.Result.Keys) {
                testTask.TaskResult.Add(key.ToString(), cmdlet.Result[key].ToString());
            }
            taskUpdater.SendTaskResult(testTask, ClientSettings.Instance.ClientId);
        }
    }
}
