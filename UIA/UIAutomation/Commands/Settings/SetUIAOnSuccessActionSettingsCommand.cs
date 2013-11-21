/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:17 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUiaOnSuccessActionSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaOnSuccessActionSettings")]
    public class SetUiaOnSuccessActionSettingsCommand : ModuleSettingsActionCmdletBase
    {
        public SetUiaOnSuccessActionSettingsCommand()
        {
            this.Action = Preferences.OnSuccessAction;
            this.Delay = Preferences.OnSuccessDelay;
        }
        
        protected override void BeginProcessing()
        {
            Preferences.OnSuccessAction = this.Action;
            Preferences.OnSuccessDelay = this.Delay;
        }
    }
}
