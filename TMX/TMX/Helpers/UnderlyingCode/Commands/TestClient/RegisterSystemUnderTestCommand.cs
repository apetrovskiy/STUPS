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
	using Tmx;
	using Tmx.Client;
	using Tmx.Commands;
	
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
            
            var registration = new Registration(new RestRequestCreator());
            // temporarily
            // TODO: to a template method
            var startTime = DateTime.Now;
            while (!clientSettings.StopImmediately) {
                // TODO: move to aspect
                try {
                    clientSettings.ClientId = registration.SendRegistrationInfoAndGetClientId(cmdlet.CustomClientString);
                }
                catch (Exception e2) {
// Console.WriteLine("registering " + e2.Message);
                    // cmdlet.WriteProgress(new System.Management.Automation.ProgressRecord(
                }
                
				// if (0 != clientSettings.ClientId)
				if (Guid.Empty != clientSettings.ClientId)
					break;
                
				if (!cmdlet.Continuous)
                    if ((DateTime.Now - startTime).TotalSeconds >= cmdlet.Seconds)
                        throw new Exception("Failed to register client in " + cmdlet.Seconds + " seconds");
                
                System.Threading.Thread.Sleep(Preferences.ClientRegistrationSleepIntervalMilliseconds);
            }
            
            clientSettings.StopImmediately = false;
        }
    }
}
