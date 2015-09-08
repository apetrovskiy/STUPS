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
    using System.Management.Automation;
    using Core;
    using Interfaces;
    
    /// <summary>
    /// Description of ExportTmxTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Export, "TmxTestResults")]
    public class ExportTmxTestResultsCommand : ImportExportCmdletBase
    {
        protected override void BeginProcessing()
        {
            CheckCmdletParameters();
            
            var dataObject = new ImportExportCmdletBaseDataObject {
                As = As,
                Descending = Descending,
                ExcludeAutomatic = ExcludeAutomatic,
                FilterAll = FilterAll,
                FilterDescriptionContains = FilterDescriptionContains,
                FilterFailed = FilterFailed,
                FilterIdContains = FilterIdContains,
                FilterNameContains = FilterNameContains,
                FilterNone = FilterNone,
                FilterNotTested = FilterNotTested,
                FilterOutAutomaticAndTechnicalResults = FilterOutAutomaticAndTechnicalResults,
                FilterOutAutomaticResults = FilterOutAutomaticResults,
                FilterPassed = FilterPassed,
                FilterPassedWithBadSmell = FilterPassedWithBadSmell,
                Id = Id,
                Name = Name,
                OrderByDateTime = OrderByDateTime,
                OrderByFailRate = OrderByFailRate,
                OrderById = OrderById,
                OrderByName = OrderByName,
                OrderByPassRate = OrderByPassRate,
                OrderByTimeSpent = OrderByTimeSpent,
                Path = Path
            };
            
            string reportFormat = As.ToUpper();
            switch (reportFormat){
                case "XML":
                    // 20141114
                    // TmxHelper.ExportResultsToXML(dataObject, Path);
                    var testResultsExporter = new TestResultsExporter();
                    testResultsExporter.ExportResultsToXml(dataObject, Path, TestData.TestSuites, TestData.TestPlatforms);
                    break;
                case "JUNIT":
                case "JUNITXML":
                    TmxHelper.ExportResultsToJUnitXML(dataObject, Path);
                    break;
                case "HTML":
                    ExportResultsToHTML(this, Path);
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
