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
    /// Description of ImportTmxTestSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Import, "TmxTestSettings")]
    public class ImportTmxTestSettingsCommand : SettingsCmdletBase
    {
        public ImportTmxTestSettingsCommand()
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
            
            TmxHelper.ImportTestSettings(this, this.Path, this.VariableName);
        }
    }
}
