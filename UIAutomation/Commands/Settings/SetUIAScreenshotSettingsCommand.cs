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
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUIAScreenshotSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAScreenshotSettings")]
    public class SetUIAScreenshotSettingsCommand : ModuleSettingsCmdletBase
    {
        public SetUIAScreenshotSettingsCommand()
        {
            this.Screenshot = Preferences.OnErrorScreenShot;
            this.ScreenshotFolder = Preferences.ScreenShotFolder;
        }
            
        #region Parameters
        [Parameter(Mandatory=true)]
        public SwitchParameter Screenshot { get; set; }
        [Parameter(Mandatory=false)]
        public string ScreenshotFolder { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Preferences.OnErrorScreenShot = this.Screenshot;
            Preferences.ScreenShotFolder = this.ScreenshotFolder;
        }
    }
}
