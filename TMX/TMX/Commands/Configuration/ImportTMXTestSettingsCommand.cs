/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/18/2012
 * Time: 10:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Management.Automation;
using Tmx.Helpers;
using Tmx.Interfaces;

namespace Tmx.Commands
{
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
                    Path = Path,
                    // 20160116
                    VariableName = VariableName //,
                    // SessionState = this.SessionState
                },
                Path,
                VariableName);
        }
    }
}
