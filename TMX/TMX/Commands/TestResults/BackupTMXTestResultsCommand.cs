/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    // blocked due to the need to remove dependency on SQLite
//    using System.Data.SQLite;
	using Tmx;
    
    /// <summary>
    /// Description of BackupTmxTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Backup, "TmxTestResults")]
    [OutputType(typeof(bool))]
    public class BackupTmxTestResultsCommand : TestResultCmdletBase
    {
        protected override void BeginProcessing()
        {
			CheckCmdletParameters();
            
			// blocked due to the need to remove dependency on SQLite
////            this.WriteVerbose(this, "creating a new connection object");
//            var connection = new SQLiteConnection();
////            this.WriteVerbose(this, "setting the connection string");
////            this.WriteVerbose(this, TestData.CurrentResultsDB.ConnectionString);
//            connection.ConnectionString = TestData.CurrentResultsDB.ConnectionString;
////            this.WriteVerbose(this, "opening the connection");
//            connection.Open();
////            this.WriteVerbose(this, "the connection has been opened");
//            SQLiteHelper.BackupTestResults(this, TestData.CurrentResultsDB.Name); //connection);
        }
    }
}
