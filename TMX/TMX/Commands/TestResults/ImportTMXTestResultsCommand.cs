/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/3/2013
 * Time: 1:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ImportTMXTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Import, "TMXTestResults")]
    public class ImportTMXTestResultsCommand : ImportExportCmdletBase
    {
        public ImportTMXTestResultsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            this.WriteVerbose(this, "As = " + this.As);
            this.WriteVerbose(this, "Path = " + this.Path);
            
            string reportFormat = this.As.ToUpper();
            switch (reportFormat){
                case "XML":
                    TMXHelper.ImportResultsFromXML(this, this.Path);
                    break;
                case "JUNIT":
                case "JUNITXML":
                    TMXHelper.ImportResultsFromJUnitXML(this, this.Path);
                    break;
                case "HTML":
                    
                    this.ImportResultsFromHTML(this, this.Path);
                    break;
                case "CSV":
                    this.ImportResultsFromCSV(this.Path);
                    break;
                case "TEXT":
                    this.ImportResultsFromTEXT(this.Path);
                    break;
                case "ZIP":
                    this.ImportResultsFromZIP(this.Path);
                    break;
                default:
                    
                    break;
            }
            
        }
        
        // temporary
        void ImportResultsFromZIP(string path)
        {
            throw new NotImplementedException();
        }
        
        void ImportResultsFromTEXT(string path)
        {
            throw new NotImplementedException();
        }
        
        void ImportResultsFromCSV(string path)
        {
            throw new NotImplementedException();
        }
        
        void ImportResultsFromHTML(ImportTMXTestResultsCommand importTMXTestResultsCommand0, string path)
        {
            throw new NotImplementedException();
        }
    }
}
