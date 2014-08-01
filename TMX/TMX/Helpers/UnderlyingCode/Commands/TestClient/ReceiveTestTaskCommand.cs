/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
	using System;
	using Tmx;
	using Tmx.Client;
	using Tmx.Interfaces.Remoting;
	using Tmx.Commands;
	
	/// <summary>
	/// Description of ReceiveTestTaskCommand.
	/// </summary>
    class ReceiveTestTaskCommand : TmxCommand
    {
        internal ReceiveTestTaskCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        // static TaskLoader taskLoader = new TaskLoader(new RestRequestCreator());
        
        internal override void Execute()
        {
            var cmdlet = (ReceiveTmxTestTaskCommand)Cmdlet;
            ClientSettings.StopImmediately = false;
            // ClientSettings.CurrentTask = null;
            // var taskLoader = new TaskLoader();
            var taskLoader = new TaskLoader(new RestRequestCreator());
            ITestTask task = null;
            
            // temporarily
            // TODO: to a template method
            var startTime = DateTime.Now;
            while (!ClientSettings.StopImmediately) {
                
                // var taskLoader = new TaskLoader(new RestRequestCreator());
                
                // TODO: move to aspect
                try {
                    // ClientSettings.CurrentTask = taskLoader.GetCurrentTask();
                    task = taskLoader.GetCurrentTask();
                }
                catch (Exception e) {
Console.WriteLine("receiving a task " + e.Message);
                }
                
                System.Threading.Thread.Sleep(Preferences.ReceivingTaskSleepIntervalMilliseconds);
                
                // if (null != ClientSettings.CurrentTask)
				if (null != task)
                    break;
                
                if ((DateTime.Now - startTime).TotalSeconds >= cmdlet.Seconds)
                    throw new Exception("Failed to receive a task in " + cmdlet.Seconds + " seconds");
            }
            
            ClientSettings.StopImmediately = false;
            // cmdlet.WriteObject(ClientSettings.CurrentTask);
            cmdlet.WriteObject(task);
        }
    }
}
