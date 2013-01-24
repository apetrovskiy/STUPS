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
    /// Description of SetUIAOnErrorActionSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAOnErrorActionSettings")]
    public class SetUIAOnErrorActionSettingsCommand : ModuleSettingsActionCmdletBase
    {
        public SetUIAOnErrorActionSettingsCommand()
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
