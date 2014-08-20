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
            // ClientSettings.ServerUrl = cmdlet.ServerUrl;
            // ClientSettings.StopImmediately = false;
            var clientSettings = ClientSettings.Instance;
            clientSettings.ServerUrl = cmdlet.ServerUrl;
            clientSettings.StopImmediately = false;
            
            // 20140820
            // move from RestSharp to RestTemplate
            var registration = new Registration(new RestRequestCreator());
            // temporarily
            // TODO: to a template method
            var startTime = DateTime.Now;
            // while (!ClientSettings.StopImmediately) {
            while (!clientSettings.StopImmediately) {
                // TODO: move to aspect
                try {
                    // ClientSettings.ClientId = registration.SendRegistrationInfoAndGetClientId(cmdlet.CustomClientString);
                    clientSettings.ClientId = registration.SendRegistrationInfoAndGetClientId(cmdlet.CustomClientString);
                    
                }
                catch (Exception e2) {
Console.WriteLine("registering " + e2.Message);
                }
                
				// if (0 != ClientSettings.ClientId)
				if (0 != clientSettings.ClientId)
					break;
                
                if ((DateTime.Now - startTime).TotalSeconds >= cmdlet.Seconds)
                    throw new Exception("Failed to register client in " + cmdlet.Seconds + " seconds");
                
                System.Threading.Thread.Sleep(Preferences.ClientRegistrationSleepIntervalMilliseconds);
            }
            
            // ClientSettings.StopImmediately = false;
            clientSettings.StopImmediately = false;
        }
    }
}
