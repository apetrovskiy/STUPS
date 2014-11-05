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
Console.WriteLine("execute 000001");
            var clientSettings = ClientSettings.Instance;
Console.WriteLine("execute 000002");
            clientSettings.StopImmediately = false;
            
Console.WriteLine("execute 000003");
            var taskLoader = new TaskLoader(new RestRequestCreator());
            // 20141020 sqeezing a task to its proxy
Console.WriteLine("execute 000004");
            ITestTask task = null;
            // ITestTaskProxy task = null;
            // ITestTaskCodeProxy task = null;
            
            // temporarily
            // TODO: to a template method
Console.WriteLine("execute 000005");
            var startTime = DateTime.Now;
Console.WriteLine("execute 000006");
            while (!clientSettings.StopImmediately) {
                
Console.WriteLine("execute 000007");
                // TODO: move to aspect
                try {
Console.WriteLine("execute 000008");
                    task = taskLoader.GetCurrentTask();
                }
                catch (ClientNotRegisteredException) {
Console.WriteLine("execute 000009");
                    // if (0 != ClientSettings.Instance.ClientId && string.Empty != ClientSettings.Instance.ServerUrl) {
                    if (Guid.Empty != ClientSettings.Instance.ClientId && string.Empty != ClientSettings.Instance.ServerUrl) {
Console.WriteLine("execute 000010");
                        var registration = new Registration(new RestRequestCreator());
Console.WriteLine("execute 000011");
                        ClientSettings.Instance.ClientId = registration.SendRegistrationInfoAndGetClientId(ClientSettings.Instance.CurrentClient.CustomString);
Console.WriteLine("execute 000012");
                    }
Console.WriteLine("execute 000013");
                    throw;
                }
                catch (Exception e) {
                    // NullreferenceException
// 20141101 temp
Console.WriteLine("receiving a task " + e.GetType().Name);
Console.WriteLine("receiving a task " + e.Message);
Console.WriteLine("receiving a task " + e.InnerException.Message);
//Console.WriteLine("receiving a task " + e.GetType().Name);
                }
                
Console.WriteLine("execute 000014");
				if (null != task)
                    break;
                
Console.WriteLine("execute 000015");
				if (!cmdlet.Continuous)
                    if ((DateTime.Now - startTime).TotalSeconds >= cmdlet.Seconds)
                        throw new Exception("Failed to receive a task in " + cmdlet.Seconds + " seconds");
                
Console.WriteLine("execute 000016");
                System.Threading.Thread.Sleep(Preferences.ReceivingTaskSleepIntervalMilliseconds);
            }
            
            clientSettings.StopImmediately = false;
            clientSettings.CurrentTask = task;
            
            cmdlet.WriteObject(task);
        }
    }
}
