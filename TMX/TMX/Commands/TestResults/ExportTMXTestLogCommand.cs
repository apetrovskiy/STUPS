/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/27/2012
 * Time: 3:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExportTmxTestLogCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TmxTestLog")]
    public class ExportTmxTestLogCommand : ImportExportCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            WriteVerbose(this, "As = " + As);
            WriteVerbose(this, "Path = " + Path);
            
            string reportFormat = As.ToUpper();
            switch (reportFormat){
                case "NUNIT":
                    
                    break;
                case "HTML":
                    ExportLogToHTML(Path);
                    break;
                case "CSV":
                    ExportLogToCSV(Path);
                    break;
                case "TEXT":
                    ExportLogToTEXT(Path);
                    break;
                case "ZIP":
                    ExportLogToZIP(Path);
                    break;
                default:
                    
                    break;
            }
            
        }
    }
}
