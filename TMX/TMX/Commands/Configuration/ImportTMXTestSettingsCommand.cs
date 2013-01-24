/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 10:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ImportTMXTestSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Import, "TMXTestSettings")]
    public class ImportTMXTestSettingsCommand : SettingsCmdletBase
    {
        public ImportTMXTestSettingsCommand()
        {
        }
        
//        #region Parameters
//        [Parameter(Mandatory = false)]
//        public string[] AssignTo { get; set; }
//        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            this.CheckInputFile(this.Path);
            
            TMXHelper.ImportTestSettings(this, this.Path, this.VariableName);
        }
    }
}
