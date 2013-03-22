/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    using System.Data.SQLite;
    
    /// <summary>
    /// Description of BackupTMXTestResultsCommand.
    /// </summary>
    [Cmdlet(VerbsData.Backup, "TMXTestResults")]
    [OutputType(typeof(bool))]
    public class BackupTMXTestResultsCommand : TestResultsCmdletBase //DatabaseCmdletBase
    {
        public BackupTMXTestResultsCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            this.WriteVerbose(this, "creating a new connection object");
            SQLiteConnection connection = new SQLiteConnection();
            this.WriteVerbose(this, "setting the connection string");
            this.WriteVerbose(this, TestData.CurrentResultsDB.ConnectionString);
            connection.ConnectionString = TestData.CurrentResultsDB.ConnectionString;
            this.WriteVerbose(this, "opening the connection");
            connection.Open();
            this.WriteVerbose(this, "the connection has been opened");
            SQLiteHelper.BackupTestResults(this, TMX.TestData.CurrentResultsDB.Name); //connection);
        }
    }
}
