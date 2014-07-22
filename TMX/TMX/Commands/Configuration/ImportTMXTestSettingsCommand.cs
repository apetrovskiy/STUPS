/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 10:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
	using Tmx.Helpers;
    
    /// <summary>
    /// Description of ImportTmxTestSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Import, "TmxTestSettings")]
    public class ImportTmxTestSettingsCommand : SettingsCmdletBase
    {
//        #region Parameters
//        [Parameter(Mandatory = false)]
//        public string[] AssignTo { get; set; }
//        #endregion Parameters
        
        protected override void BeginProcessing()
        {
			CheckCmdletParameters();
            
			CheckInputFile(Path);
            
            //TmxHelper.ImportTestSettings(this, this.Path, this.VariableName);
			ImportExportHelper.ImportTestSettings(
                new SettingsCmdletBaseDataObject {
                    Path = this.Path,
                    VariableName = this.VariableName,
                    SessionState = this.SessionState
                },
                Path,
                VariableName);
        }
    }
}
