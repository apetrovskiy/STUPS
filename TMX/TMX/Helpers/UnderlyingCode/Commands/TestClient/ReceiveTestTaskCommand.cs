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
        
        internal override void Execute()
        {
            var cmdlet = (ReceiveTmxTestTaskCommand)Cmdlet;
            // ClientSettings.StopImmediately = false;
            var clientSettings = ClientSettings.Instance;
            clientSettings.StopImmediately = false;
            
            var taskLoader = new TaskLoader(new RestRequestCreator());
            ITestTask task = null;
            
            // temporarily
            // TODO: to a template method
            var startTime = DateTime.Now;
            // while (!ClientSettings.StopImmediately) {
            while (!clientSettings.StopImmediately) {
                
                // TODO: move to aspect
                try {
                    // ClientSettings.CurrentTask = taskLoader.GetCurrentTask();
                    
// Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
                    
                    task = taskLoader.GetCurrentTask();
                }
                catch (Exception e) {
Console.WriteLine("receiving a task " + e.Message);
                }
                
				if (null != task)
                    break;
                
                if ((DateTime.Now - startTime).TotalSeconds >= cmdlet.Seconds)
                    throw new Exception("Failed to receive a task in " + cmdlet.Seconds + " seconds");
                
                System.Threading.Thread.Sleep(Preferences.ReceivingTaskSleepIntervalMilliseconds);
            }
            
            // ClientSettings.StopImmediately = false;
            clientSettings.StopImmediately = false;
            
            cmdlet.WriteObject(task);
        }
    }
}
