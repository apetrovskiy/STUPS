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
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUiaOnSleepActionSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaOnSleepActionSettings")]
    public class SetUiaOnSleepActionSettingsCommand : ModuleSettingsActionCmdletBase
    {
        public SetUiaOnSleepActionSettingsCommand()
        {
            Action = Preferences.OnSleepAction;
            Delay = Preferences.OnSleepDelay;
        }
        
        protected override void BeginProcessing()
        {
            Preferences.OnSleepAction = Action;
            Preferences.OnSleepDelay = Delay;
        }
    }
}
