/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2012
 * Time: 5:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of GetTestResultsViaDataSetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TestResultsViaDataSet")]
    internal class GetTestResultsViaDataSetCommand : CommonCmdletBase
    {
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            var cmdlet = new SearchCmdletBase();
            cmdlet.FilterAll = true;
            
//            System.Data.DataSet dataSet = 
//                new System.Data.DataSet();
//            System.Data.DataTable tableSuites = 
//                new System.Data.DataTable("suites");
//            tableSuites.Columns.AddRange(
//                new DataColumn[] {
//                    new DataColumn("Id", typeof(System.String)),
//                    new DataColumn("Name", typeof(System.String)),
//                    new DataColumn("Status", typeof(System.String)),
//                    new DataColumn("TimeSpent", typeof(System.Int32)),
//                    new DataColumn("Passed", typeof(System.Int32)),
//                    new DataColumn("Failed", typeof(System.Int32)),
//                    new DataColumn("NotTested", typeof(System.Int32))
//                }
//               );
            
//            System.Data.IDataAdapter adapter =
//                new System.Data.data
            
//            OleDbDataAdapter da = 
//                new OleDbDataAdapter();
//            da.
            
//            IOrderedEnumerable<TestSuite> suitesCollection = 
//                TmxHelper.SearchForSuites(cmdlet);
//            foreach (TestSuite testSuite in suitesCollection) {
//                DataRow row = tableSuites.NewRow();
//                //row.
//            }
            
            // 20140720
            // var dataObject = new SearchCmdletBaseDataObject { FilterAll = true };
            // 20140721
			var dataObject = new SearchCmdletBaseDataObject {
                Descending = cmdlet.Descending,
                FilterAll = cmdlet.FilterAll,
                FilterDescriptionContains = cmdlet.FilterDescriptionContains,
                FilterFailed = cmdlet.FilterFailed,
                FilterIdContains = cmdlet.FilterIdContains,
                FilterNameContains = cmdlet.FilterNameContains,
                FilterNone = cmdlet.FilterNone,
                FilterNotTested = cmdlet.FilterNotTested,
                FilterOutAutomaticAndTechnicalResults = cmdlet.FilterOutAutomaticAndTechnicalResults,
                FilterOutAutomaticResults = cmdlet.FilterOutAutomaticResults,
                FilterPassed = cmdlet.FilterPassed,
                FilterPassedWithBadSmell = cmdlet.FilterPassedWithBadSmell,
                Id = cmdlet.Id,
                Name = cmdlet.Name,
                OrderByDateTime = cmdlet.OrderByDateTime,
                OrderByFailRate = cmdlet.OrderByFailRate,
                OrderById = cmdlet.OrderById,
                OrderByName = cmdlet.OrderByName,
                OrderByPassRate = cmdlet.OrderByPassRate,
                OrderByTimeSpent = cmdlet.OrderByTimeSpent
			};
//            TmxHelper.SearchForScenarios(cmdlet);
//            TmxHelper.SearchForTestResults(cmdlet);
            TmxHelper.SearchForScenarios(dataObject);
            TmxHelper.SearchForTestResults(dataObject);

        }
    }
}
