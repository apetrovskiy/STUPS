/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUIALoggingSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIALoggingSettings")]
    public class SetUIALoggingSettingsCommand : ModuleSettingsCmdletBase
    {
        public SetUIALoggingSettingsCommand()
        {
            this.Log = Preferences.Log;
            this.Path = Preferences.LogPath;
        }
        
        #region Parameters
        [Parameter(Mandatory=true)]
        public SwitchParameter Log { get; set; }
        [Parameter(Mandatory=false)]
        public string Path { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Preferences.Log = this.Log;
            Preferences.LogPath = this.Path;
        }
    }
}
