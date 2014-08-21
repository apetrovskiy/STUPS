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
	// using System.Collections.Generic;
	using System.Linq;
	using Tmx;
	using Tmx.Client;
	// using Tmx.Interfaces;
	using Tmx.Interfaces.Types.Remoting;
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
            taskUpdater.SendTaskResult(new TestTask { TaskResult = cmdlet.Result }, ClientSettings.Instance.ClientId);
        }
    }
}
