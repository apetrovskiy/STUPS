/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2012
 * Time: 1:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExportTmxTestSummaryCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TmxTestSummary")]
    public class ExportTmxTestSummaryCommand : ImportExportCmdletBase //ExportCmdletBase //CmdletBase
    {
        public ExportTmxTestSummaryCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            this.WriteVerbose(this, "As = " + this.As);
            this.WriteVerbose(this, "Path = " + this.Path);
            
            string reportFormat = this.As.ToUpper();
            switch (reportFormat){
                case "NUNIT":
                    
                    break;
                case "HTML":
                    // 20130322
                    //this.ExportSummaryToHTML(this.Path);
                    this.ExportSummaryToHTML(this, this.Path);
                    break;
                case "CSV":
                    this.ExportSummaryToCSV(this.Path);
                    break;
                case "TEXT":
                    this.ExportSummaryToTEXT(this.Path);
                    break;
                case "ZIP":
                    this.ExportSummaryToZIP(this.Path); // ?
                    break;
                default:
                    
                    break;
            }
            
        }
    }
}
