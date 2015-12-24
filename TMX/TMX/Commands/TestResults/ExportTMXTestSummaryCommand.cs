/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2012
 * Time: 1:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExportTmxTestSummaryCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TmxTestSummary")]
    public class ExportTmxTestSummaryCommand : ImportExportCmdletBase
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
                    // 20130322
                    //this.ExportSummaryToHTML(this.Path);
                    ExportSummaryToHTML(this, Path);
                    break;
                case "CSV":
                    ExportSummaryToCSV(Path);
                    break;
                case "TEXT":
                    ExportSummaryToTEXT(Path);
                    break;
                case "ZIP":
                    ExportSummaryToZIP(Path); // ?
                    break;
                default:
                    
                    break;
            }
            
        }
    }
}
