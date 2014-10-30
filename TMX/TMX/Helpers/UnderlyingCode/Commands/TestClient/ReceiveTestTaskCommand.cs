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
    using Tmx.Interfaces.Exceptions;
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
            var clientSettings = ClientSettings.Instance;
            clientSettings.StopImmediately = false;
            
            var taskLoader = new TaskLoader(new RestRequestCreator());
            // 20141020 sqeezing a task to its proxy
            ITestTask task = null;
            // ITestTaskProxy task = null;
            // ITestTaskCodeProxy task = null;
            
            // temporarily
            // TODO: to a template method
            var startTime = DateTime.Now;
            while (!clientSettings.StopImmediately) {
                
                // TODO: move to aspect
                try {
                    task = taskLoader.GetCurrentTask();
                }
                catch (ClientNotRegisteredException) {
                    // if (0 != ClientSettings.Instance.ClientId && string.Empty != ClientSettings.Instance.ServerUrl) {
                    if (Guid.Empty != ClientSettings.Instance.ClientId && string.Empty != ClientSettings.Instance.ServerUrl) {
                        var registration = new Registration(new RestRequestCreator());
                        ClientSettings.Instance.ClientId = registration.SendRegistrationInfoAndGetClientId(ClientSettings.Instance.CurrentClient.CustomString);
                    }
                    throw;
                }
                catch (Exception e) {
//Console.WriteLine("receiving a task " + e.Message);
//Console.WriteLine("receiving a task " + e.GetType().Name);
                }
                
				if (null != task)
                    break;
                
				if (!cmdlet.Continuous)
                    if ((DateTime.Now - startTime).TotalSeconds >= cmdlet.Seconds)
                        throw new Exception("Failed to receive a task in " + cmdlet.Seconds + " seconds");
                
                System.Threading.Thread.Sleep(Preferences.ReceivingTaskSleepIntervalMilliseconds);
            }
            
            clientSettings.StopImmediately = false;
            clientSettings.CurrentTask = task;
            
            cmdlet.WriteObject(task);
        }
    }
}
