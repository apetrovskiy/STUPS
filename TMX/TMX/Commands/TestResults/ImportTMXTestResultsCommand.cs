/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/3/2013
 * Time: 1:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of ImportTmxTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Import, "TmxTestResults")]
    public class ImportTmxTestResultsCommand : ImportExportCmdletBase
    {
        protected override void BeginProcessing()
        {
			CheckCmdletParameters();
            
//            this.WriteVerbose(this, "As = " + this.As);
//            this.WriteVerbose(this, "Path = " + this.Path);
            
            // 20140720
            var dataObject = new ImportExportCmdletBaseDataObject {
//                Path = this.Path,
//                As = this.As,
//                ExcludeAutomatic = this.ExcludeAutomatic
                As = this.As,
                Descending = this.Descending,
                ExcludeAutomatic = this.ExcludeAutomatic,
                FilterAll = this.FilterAll,
                FilterDescriptionContains = this.FilterDescriptionContains,
                FilterFailed = this.FilterFailed,
                FilterIdContains = this.FilterIdContains,
                FilterNameContains = this.FilterNameContains,
                FilterNone = this.FilterNone,
                FilterNotTested = this.FilterNotTested,
                FilterOutAutomaticAndTechnicalResults = this.FilterOutAutomaticAndTechnicalResults,
                FilterOutAutomaticResults = this.FilterOutAutomaticResults,
                FilterPassed = this.FilterPassed,
                FilterPassedWithBadSmell = this.FilterPassedWithBadSmell,
                Id = this.Id,
                Name = this.Name,
                OrderByDateTime = this.OrderByDateTime,
                OrderByFailRate = this.OrderByFailRate,
                OrderById = this.OrderById,
                OrderByName = this.OrderByName,
                OrderByPassRate = this.OrderByPassRate,
                OrderByTimeSpent = this.OrderByTimeSpent,
                Path = this.Path
            };
            
            string reportFormat = this.As.ToUpper();
            switch (reportFormat){
                case "XML":
					// TmxHelper.ImportResultsFromXML(this, Path);
					TmxHelper.ImportResultsFromXML(dataObject, Path);
                    break;
                case "JUNIT":
                case "JUNITXML":
					// TmxHelper.ImportResultsFromJUnitXML(this, Path);
					TmxHelper.ImportResultsFromJUnitXML(dataObject, Path);
                    break;
                case "HTML":
                    
					ImportResultsFromHTML(this, Path);
                    break;
                case "CSV":
					ImportResultsFromCSV(Path);
                    break;
                case "TEXT":
					ImportResultsFromTEXT(Path);
                    break;
                case "ZIP":
					ImportResultsFromZIP(Path);
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
        
        void ImportResultsFromHTML(ImportTmxTestResultsCommand importTmxTestResultsCommand0, string path)
        {
            throw new NotImplementedException();
        }
    }
}
