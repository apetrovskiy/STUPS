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
    using Tmx.Core;
	using Tmx.Interfaces;
    
    /// <summary>
    /// Description of ImportTmxTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Import, "TmxTestResults")]
    public class ImportTmxTestResultsCommand : ImportExportCmdletBase
    {
        protected override void BeginProcessing()
        {
			CheckCmdletParameters();
            
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
                    // 20141112
                    // still the old way
                    // 20141114
					// TmxHelper.ImportResultsFromXML(dataObject, Path);
					var testResultsImporter = new TestResultsImporter();
					// TestData.TestSuites.AddRange(testResultsImporter.ImportResultsFromXML(dataObject, Path));
					if (testResultsImporter.LoadDocument(dataObject, Path)) {
					    testResultsImporter.MergeTestPlatforms(TestData.TestPlatforms, testResultsImporter.ImportTestPlatformFromXdocument(testResultsImporter.ImportedDocument));
					    testResultsImporter.MergeTestSuites(TestData.TestSuites, testResultsImporter.ImportTestResultsFromXdocument(testResultsImporter.ImportedDocument));
					}
//					testResultsImporter.MergeTestPlatforms(TestData.TestPlatforms, testResultsImporter.ImportPlatformsFromXML(dataObject, Path));
//					testResultsImporter.MergeTestSuites(TestData.TestSuites, testResultsImporter.ImportResultsFromXML(dataObject, Path));
					
                    break;
                case "JUNIT":
                case "JUNITXML":
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
