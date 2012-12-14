/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2012
 * Time: 5:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    using System.Data;
    using System.Data.OleDb;
    using System.Linq;
    
    /// <summary>
    /// Description of GetTestResultsViaDataSetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TestResultsViaDataSet")]
    internal class GetTestResultsViaDataSetCommand : CommonCmdletBase
    {
        public GetTestResultsViaDataSetCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckParameters();
            
            SearchCmdletBase cmdlet = 
                new SearchCmdletBase();
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
//                TMXHelper.SearchForSuites(cmdlet);
//            foreach (TestSuite testSuite in suitesCollection) {
//                DataRow row = tableSuites.NewRow();
//                //row.
//            }
            
            
            TMXHelper.SearchForScenarios(cmdlet);
            TMXHelper.SearchForTestResults(cmdlet);

        }
    }
}
