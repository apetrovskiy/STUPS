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
    /// Description of ExportTMXTestSummaryCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TMXTestSummary")]
    public class ExportTMXTestSummaryCommand : ImportExportCmdletBase //ExportCmdletBase //CmdletBase
    {
        public ExportTMXTestSummaryCommand()
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
                    this.ExportSummaryToHTML(this.Path);
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
