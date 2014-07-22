/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of ExportTmxTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TmxTestResults")]
    public class ExportTmxTestResultsCommand : ImportExportCmdletBase
    {
        protected override void BeginProcessing()
        {
			CheckCmdletParameters();
            
//            this.WriteVerbose(this, "As = " + this.As);
//            this.WriteVerbose(this, "Path = " + this.Path);
            
            // 20140721
            var dataObject = new ImportExportCmdletBaseDataObject {
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
            
            string reportFormat = As.ToUpper();
            switch (reportFormat){
                case "XML":
                    // 20140721
					// TmxHelper.ExportResultsToXML(this, Path);
					TmxHelper.ExportResultsToXML(dataObject, Path);
                    break;
                case "JUNIT":
                case "JUNITXML":
                    // 20140721
					// TmxHelper.ExportResultsToJUnitXML(this, Path);
					TmxHelper.ExportResultsToJUnitXML(dataObject, Path);
                    break;
                case "HTML":
                    // 20130322
                    //this.ExportResultsToHTML(this.Path);
                    this.ExportResultsToHTML(this, this.Path);
                    break;
                case "CSV":
					ExportResultsToCSV(Path);
                    break;
                case "TEXT":
					ExportResultsToTEXT(Path);
                    break;
                case "ZIP":
					ExportResultsToZIP(Path);
                    break;
                default:
                    
                    break;
            }
            
        }
    }
}
