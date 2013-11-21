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
    /// Description of SetUiaOnErrorActionSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaOnErrorActionSettings")]
    public class SetUiaOnErrorActionSettingsCommand : ModuleSettingsActionCmdletBase
    {
        public SetUiaOnErrorActionSettingsCommand()
        {
            this.Action = Preferences.OnErrorAction;
            this.Delay = Preferences.OnErrorDelay;
        }
        
        protected override void BeginProcessing()
        {
            Preferences.OnErrorAction = this.Action;
            Preferences.OnErrorDelay = this.Delay;
        }
    }
}
