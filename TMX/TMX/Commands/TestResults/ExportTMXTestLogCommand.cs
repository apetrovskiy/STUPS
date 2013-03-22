/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/27/2012
 * Time: 3:00 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ExportTMXTestLogCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TMXTestLog")]
    public class ExportTMXTestLogCommand : ImportExportCmdletBase
    {
        public ExportTMXTestLogCommand()
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
                    this.ExportLogToHTML(this.Path);
                    break;
                case "CSV":
                    this.ExportLogToCSV(this.Path);
                    break;
                case "TEXT":
                    this.ExportLogToTEXT(this.Path);
                    break;
                case "ZIP":
                    this.ExportLogToZIP(this.Path);
                    break;
                default:
                    
                    break;
            }
            
        }
    }
}
