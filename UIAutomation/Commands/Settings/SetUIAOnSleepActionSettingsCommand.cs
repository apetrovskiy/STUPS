/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUIAOnSleepActionSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAOnSleepActionSettings")]
    public class SetUIAOnSleepActionSettingsCommand : ModuleSettingsActionCmdletBase
    {
        public SetUIAOnSleepActionSettingsCommand()
        {
            this.Action = Preferences.OnSleepAction;
            this.Delay = Preferences.OnSleepDelay;
        }
        
        protected override void BeginProcessing()
        {
            Preferences.OnSleepAction = this.Action;
            Preferences.OnSleepDelay = this.Delay;
        }
    }
}
