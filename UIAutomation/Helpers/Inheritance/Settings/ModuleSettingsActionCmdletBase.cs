/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ModuleSettingsActionCmdletBase.
    /// </summary>
    public class ModuleSettingsActionCmdletBase : ModuleSettingsCmdletBase
    {
        public ModuleSettingsActionCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory=false)]
        public ScriptBlock[] Action { get; set; }
        [Parameter(Mandatory=false)]
        public int Delay { get; set; }
        #endregion Parameters
    }
}
