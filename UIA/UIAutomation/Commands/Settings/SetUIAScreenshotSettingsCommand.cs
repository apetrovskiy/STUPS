/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUiaScreenshotSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UiaScreenshotSettings")]
    public class SetUiaScreenshotSettingsCommand : ModuleSettingsCmdletBase
    {
        public SetUiaScreenshotSettingsCommand()
        {
            Screenshot = Preferences.OnErrorScreenShot;
            ScreenshotFolder = Preferences.ScreenShotFolder;
        }
            
        #region Parameters
        [UiaParameter][Parameter(Mandatory=true)]
        public SwitchParameter Screenshot { get; set; }
        [UiaParameter][Parameter(Mandatory=false)]
        public string ScreenshotFolder { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Preferences.OnErrorScreenShot = Screenshot;
            Preferences.ScreenShotFolder = ScreenshotFolder;
        }
    }
}
