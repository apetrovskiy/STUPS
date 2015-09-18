/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Threading;
    using Client;
    using Client.Library.Helpers;
    using Client.Library.ObjectModel;
    using Commands;
    
    /// <summary>
    /// Description of RegisterSystemUnderTestCommand.
    /// </summary>
    class RegisterSystemUnderTestCommand : TmxCommand
    {
        internal RegisterSystemUnderTestCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (RegisterTmxSystemUnderTestCommand)Cmdlet;
            var clientSettings = ClientSettings.Instance;
            clientSettings.ServerUrl = cmdlet.ServerUrl;
            clientSettings.StopImmediately = false;
            
            // 20150918
            // var registration = new Registration(new RestRequestCreator());
            var registration = new Registration();
            // temporarily
            // TODO: to a template method
            var startTime = DateTime.Now;
            while (!clientSettings.StopImmediately) {
                // TODO: move to aspect
                try {
                    clientSettings.ClientId = registration.SendRegistrationInfoAndGetClientId(cmdlet.CustomClientString);
                }
                catch (Exception e2) {
Console.WriteLine("registering " + e2.Message);
                    // cmdlet.WriteProgress(new System.Management.Automation.ProgressRecord(
                }
                
                if (Guid.Empty != clientSettings.ClientId)
                    break;
                
                if (!cmdlet.Continuous)
                    if ((DateTime.Now - startTime).TotalSeconds >= cmdlet.Seconds)
                        throw new Exception("Failed to register client in " + cmdlet.Seconds + " seconds");
                
                Thread.Sleep(Preferences.ClientRegistrationSleepIntervalMilliseconds);
            }
            
            clientSettings.StopImmediately = false;
        }
    }
}
