/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 10:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExportTMXTestSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TMXTestSettings")]
    public class ExportTMXTestSettingsCommand : SettingsCmdletBase
    {
        public ExportTMXTestSettingsCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            TMXHelper.ExportTestSettings(this, this.Path, this.VariableName);
        }
    }
}
