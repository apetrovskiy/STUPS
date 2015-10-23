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
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUiaLoggingSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaLoggingSettings")]
    public class SetUiaLoggingSettingsCommand : ModuleSettingsCmdletBase
    {
        public SetUiaLoggingSettingsCommand()
        {
            Log = Preferences.Log;
            Path = Preferences.LogPath;
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory=true)]
        public SwitchParameter Log { get; set; }
        [UiaParameter][Parameter(Mandatory=false)]
        public string Path { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Preferences.Log = Log;
            Preferences.LogPath = Path;
        }
    }
}
