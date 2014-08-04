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
            // var taskUpdater = new TaskUpdater(new RestRequestCreator());
            // taskUpdater.SendTaskResult(new TestTask { TaskResult = cmdlet.Result }, cmdlet.ClientId);
            // ClientSettings.TaskResult = cmdlet.Result;
            // ClientSettings.TaskResult. += cmdlet.Result;
            
if (null == cmdlet.Result)
    Console.WriteLine("send 0: null == cmdlet.Result");
else {
    Console.WriteLine("send 0: null != cmdlet.Result");
    foreach (var element in cmdlet.Result) {
        Console.WriteLine(element);
    }
}
            
if (null == ClientSettings.TaskResult)
    Console.WriteLine("send 1: null == ClientSettings.TaskResult");
else {
    Console.WriteLine("send 1: null != ClientSettings.TaskResult");
    foreach (var element in ClientSettings.TaskResult) {
        Console.WriteLine(element);
    }
}


            // ClientSettings.TaskResult = ClientSettings.TaskResult.Concat(cmdlet.Result);
            ClientSettings.TaskResult = null == ClientSettings.TaskResult ? new string[] {} : ClientSettings.TaskResult.Concat(cmdlet.Result);
            
            
if (null == ClientSettings.TaskResult)
    Console.WriteLine("send 2: null == ClientSettings.TaskResult");
else {
    Console.WriteLine("send 2: null != ClientSettings.TaskResult");
    foreach (var element in ClientSettings.TaskResult) {
        Console.WriteLine(element);
    }
}
        }
    }
}
