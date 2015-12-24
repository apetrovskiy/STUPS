/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    using Tmx;
    using Client;
    
    /// <summary>
    /// Description of RegisterTmxSystemUnderTestCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "TmxSystemUnderTest", DefaultParameterSetName = "LimitedTime")]
    public class RegisterTmxSystemUnderTestCommand : ClientCmdletBase
    {
        public RegisterTmxSystemUnderTestCommand()
        {
            Seconds = Preferences.ClientRegistrationTimeoutSeconds;
        }
        
        [Parameter(Mandatory = true)]
        public string ServerUrl { get; set; }
        
        [Parameter(Mandatory = false)]
        public string CustomClientString { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "LimitedTime")]
        public int Seconds { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "UnlimitedTime")]
        public SwitchParameter Continuous { get; set; }
        
        protected override void BeginProcessing()
        {
            var command = new RegisterSystemUnderTestCommand(this);
            command.Execute();
        }
        
        protected override void StopProcessing()
        {
            ClientSettings.Instance.StopImmediately = true;
        }
    }
}
