/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 12:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SQLite;
    using System.Management.Automation;
    
    using PSTestLib;
    
    using System.IO;
    
    /// <summary>
    /// Description of SQLiteHelper.
    /// </summary>
    public static class SQLiteHelper
    {
        static SQLiteHelper()
        {
        }
        
        //internal static IDatabase CurrentDatabase = null;
        
        #region Database
        public static void CreateDatabase(
            //PSCmdletBase cmdlet, 
            //CommonCmdletBase cmdlet,
            DatabaseFileCmdletBase cmdlet,
            string fileName,
            bool structureDB,
            bool repositoryDB,
            bool resultsDB)
        {
            // check input
            
            try {
                
                string absolutePath = 
                    System.IO.Path.GetFullPath(fileName);

                cmdlet.WriteVerbose(cmdlet, absolutePath);

                SQLiteConnection.CreateFile(absolutePath);

                if (System.IO.File.Exists(absolutePath)) {
                    string connectionString =
                        "Data Source='" + 
                        absolutePath + 
                        "';Version=3;Max Pool Size=100;UseUTF16Encoding=True;";
                    cmdlet.WriteVerbose(cmdlet, connectionString);

                    using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {

                        conn.Open();

                        // 20120918
                        if (null == cmdlet.Name ||
                            0 == cmdlet.Name.Length) {
                            cmdlet.Name = fileName;
                        }

                        IDatabase database = 
                            new Database(
                                ((DatabaseFileCmdletBase)cmdlet).Name,
                                absolutePath,
                                conn);

                        // create tables
                        if (repositoryDB) {
                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE TABLE TestBuckets (BucketName TEXT, Id INTEGER PRIMARY KEY, BucketTag TEXT, Description TEXT);");

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE TABLE TestConstants (Id INTEGER PRIMARY KEY, ConstantName TEXT, ConstantType TEXT, ConstantValue BLOB, ConstantTag TEXT, Description TEXT, BucketId NUMERIC);");
                        }
                        
                        if (structureDB) {

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE TABLE TestCases (AfterCode TEXT, BeforeCode TEXT, MainCode TEXT, Id INTEGER PRIMARY KEY, TestCaseName TEXT, TestCaseNumber TEXT, TestCaseTag TEXT, Description TEXT);");
                        }
                        
                        if (resultsDB || structureDB) {

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE TABLE TestSuites (Id INTEGER PRIMARY KEY, SuiteId TEXT, SuiteName TEXT, StatusId NUMERIC, Description TEXT);");

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE TABLE TestScenarios (Id INTEGER PRIMARY KEY, SuiteId TEXT, ScenarioId TEXT, ScenarioName TEXT, StatusId NUMERIC, Description TEXT);");
                        }
                        
                        if (resultsDB) {

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE TABLE TestResults (Id INTEGER PRIMARY KEY, TestResultId TEXT, TestResultName TEXT, " +
                                "StatusId NUMERIC, ScriptName TEXT, LineNumber NUMERIC, " +
                                //"Position NUMERIC, Error BLOB, Code TEXT, Description TEXT, Parameters BLOB, " +
                                "Position NUMERIC, Error TEXT, Code TEXT, Description TEXT, Parameters BLOB, " +
                                //"SuiteId TEXT, ScenarioId TEXT, Timestamp TEXT, TimeSpent NUMERIC, Generated NUMERIC, Screenshot TEXT);");
                                "SuiteId TEXT, ScenarioId TEXT, Timestamp TEXT, TimeSpent NUMERIC, Generated NUMERIC, Screenshot BLOB);");

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE TABLE TestResultDetails (Id INTEGER PRIMARY KEY, TestResultId TEXT, TestResultDetailName TEXT, " +
                                //"TestResultDetail BLOB, Timestamp TEXT);");
                                "TestResultDetail TEXT, Timestamp TEXT);");
                        }
                        
                        if (structureDB) {
                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE INDEX TestCaseName ON TestCases(TestCaseName ASC);");
                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE INDEX TestCaseNumber ON TestCases(TestCaseNumber ASC);");
                        }
                        
                        if (repositoryDB) {
                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE INDEX TestConstantName ON TestConstants(ConstantName ASC);");
                        }
                        
                        if (resultsDB) {

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE INDEX TestResultId ON TestResults(TestResultId ASC);");

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE INDEX TestResultName ON TestResults(TestResultName ASC);");

                            runSQLCommand(
                                cmdlet,
                                database,
                                "CREATE INDEX TestResultDetailName ON TestResultDetails(TestResultDetailName ASC);");
                        }

                        cmdlet.WriteVerbose(cmdlet, "closing the connection");

                        conn.Close();

                        if (structureDB) {
                            cmdlet.WriteVerbose(cmdlet, "setting the current structure DB");
                            database.IsStructureDB = true;
                            TestData.CurrentStructureDB = database;
                        }
                        if (repositoryDB) {
                            cmdlet.WriteVerbose(cmdlet, "setting the current repository DB");
                            database.IsRepositoryDB = true;
                            TestData.CurrentRepositoryDB = database;
                        }
                        if (resultsDB) {

                            cmdlet.WriteVerbose(cmdlet, "setting the current results DB");

                            database.IsResultsDB = true;

                            TestData.CurrentResultsDB = database;

                        }
                        cmdlet.WriteVerbose(cmdlet, "adding the database to the colleciton");

                        SQLiteData.Databases.Add(database);

                        cmdlet.WriteVerbose(cmdlet, "outputting the database");

                        cmdlet.WriteObject(cmdlet, database);

                    }
                }
            }
            catch (Exception eCreateDB) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to create a database with structure. " +
                    eCreateDB.Message,
                    "CreateDBFailed",
                    ErrorCategory.InvalidOperation,
                    true);
            }
            
            // create structure
            
            // http://sqlite.phxsoftware.com/forums/p/134/465.aspx#465
            // http://sqlite.phxsoftware.com/forums/t/76.aspx
        }
        
        internal static IDatabase GetDatabase(
            PSCmdletBase cmdlet, 
            string databaseName)
        {
            IDatabase database = null;
            
            if (null != TMX.SQLiteData.Databases &&
                0 < TMX.SQLiteData.Databases.Count) {
                foreach (IDatabase db in TMX.SQLiteData.Databases) {
                    if (db.Name == databaseName) {
                        //return db;
                        database = db;
                        break;
                    }
                }
            }
            
            return database;
        }
        
        public static void OpenDatabase(
            PSCmdletBase cmdlet, 
            string fileName,
            bool structureDB,
            bool repositoryDB,
            bool resultsDB)
        {
            // check input
            
            try {
                string absolutePath = 
                    System.IO.Path.GetFullPath(fileName);
                cmdlet.WriteVerbose(cmdlet, absolutePath);
                
                if (System.IO.File.Exists(absolutePath)) {
                    string connectionString =
                        "Data Source='" + 
                        absolutePath + 
                        "';Version=3;Max Pool Size=100;UseUTF16Encoding=True;";
                    cmdlet.WriteVerbose(cmdlet, connectionString);
                    
                    using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                        
                        conn.Open();
                        
                        IDatabase database = 
                            new Database(
                                ((DatabaseFileCmdletBase)cmdlet).Name,
                                fileName,
                                conn);
                        
                        
                        // check structure DB
                        
                        
                        // check repository DB
                        
                        // check data DB
                        
                        
                        conn.Close();
                        
                        if (structureDB) {
                            TestData.CurrentStructureDB = database;
                        }
                        if (repositoryDB) {
                            TestData.CurrentRepositoryDB = database;
                        }
                        if (resultsDB) {
                            TestData.CurrentResultsDB = database;
                        }
                        
                        SQLiteData.Databases.Add(database);
                        
                        cmdlet.WriteObject(cmdlet, database);
                    }
                }
            }
            catch (Exception eOpenDB) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to open the database. " +
                    eOpenDB.Message,
                    "OpenDBFailed",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        
        public static void CloseDatabase(
            PSCmdletBase cmdlet, 
            string databaseName)
        {
            // check input
            
            try {
                
                cmdlet.WriteVerbose(cmdlet, "enumerating registered databases");
                
                for (int i = 0; i < SQLiteData.Databases.Count; i++) {
                    
                    cmdlet.WriteVerbose(cmdlet, "check the database name");
                    
                    if (databaseName == SQLiteData.Databases[i].Name) {
                        
                        cmdlet.WriteVerbose(cmdlet, "close the database");
                        
                        try {
                            if (null != SQLiteData.Databases[i].Connection &&
                                SQLiteData.Databases[i].Connection.State == ConnectionState.Open) {
                                SQLiteData.Databases[i].Connection.Close();
                            }
                        }
                        catch {}
                        
                        if (SQLiteData.Databases[i].IsResultsDB) {
                            TestData.CurrentResultsDB = null;
                        }
                        if (SQLiteData.Databases[i].IsRepositoryDB) {
                            TestData.CurrentRepositoryDB = null;
                        }
                        if (SQLiteData.Databases[i].IsStructureDB) {
                            TestData.CurrentStructureDB = null;
                        }
                        //SQLiteData.Databases[i].Connection.Close();
                        
                        SQLiteData.Databases.RemoveAt(i);
                        
                        break;
                    }
                }

            }
            catch (Exception eOpenDB) {
                cmdlet.WriteError(
                    cmdlet,
                    "Unable to open the database. " +
                    eOpenDB.Message,
                    "OpenDBFailed",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        
        private static void runSQLCommand(PSCmdletBase cmdlet, IDatabase database, string SQLCode)
        {
            if (null == database) {
                cmdlet.WriteError(
                    cmdlet,
                    "Could not find the database with name '" +
                    database.Name +
                    "' among registered databases",
                    "CouldNotFindDB",
                    ErrorCategory.InvalidArgument,
                    true);
            }

            if (null == database.Connection) {

                database.Connection = 
                    new SQLiteConnection(database.ConnectionString);

            }
            if (database.Connection.State == ConnectionState.Closed) {
                database.Connection.Open();
            }

            using (SQLiteCommand cmd = 
                   new SQLiteCommand(SQLCode)) {

                cmd.Connection = database.Connection;
                //cmdlet.WriteVerbose(cmdlet, cmd.ExecuteNonQuery().ToString());

                int result = cmd.ExecuteNonQuery();

                cmdlet.WriteVerbose(
                    cmdlet,
                    SQLCode +
                    ": " + 
                    result.ToString());
            }
        }
        
        //private static void runSQLCommand(PSCmdletBase cmdlet, SQLiteConnection connection, string SQLCode)
        private static void runSQLCommand(PSCmdletBase cmdlet, string databaseName, string SQLCode)
        {
            IDatabase db = 
                TMX.SQLiteHelper.GetDatabase(
                    cmdlet,
                    databaseName);
            runSQLCommand(cmdlet, db, SQLCode);
        }
        
        private static void checkConnection(SQLiteConnection connection)
        {
            if (connection.State == ConnectionState.Closed) {
                connection.Open();
            }
        }
        
            #region doubts
//        public static void CompressDatabase(PSCmdletBase cmdlet, string fileName)
//        {
//            // check input
//            
//            //SQLiteConnection.
//        }
//        
//        public static void DecompressDatabase(PSCmdletBase cmdlet, string fileName)
//        {
//            
//        }
            #endregion doubts
            
            #region connection
        internal static SQLiteConnection ConnectionMakeAlive(PSCmdletBase cmdlet, string databaseName)
        {
            SQLiteConnection connection = null;
            
            IDatabase database = GetDatabase(cmdlet, databaseName);
            if (null == database) {
                cmdlet.WriteError(
                    cmdlet,
                    "Could not find the database with name '" +
                    database.Name +
                    "' among registered databases.",
                    "CouldNotFindDB",
                    ErrorCategory.InvalidArgument,
                    true);
                return connection;
            }
            
            if (null == database.ConnectionString ||
                string.Empty == database.ConnectionString) {

                cmdlet.WriteError(
                    cmdlet,
                    "Could not find the connectionString to the database with name '" +
                    database.Name +
                    "'.",
                    "CouldNotFindConnString",
                    ErrorCategory.InvalidArgument,
                    true);
                return connection;
            }

            try {
                if (null == database.Connection) {

                    database.Connection = 
                        new SQLiteConnection(database.ConnectionString);

                    database.Connection.Open();

                }

                try {
                if (database.Connection.State != ConnectionState.Open) {

                    database.Connection.ConnectionString = database.ConnectionString;

                    database.Connection.Open();
                }
                }
                catch {
                    database.Connection = 
                        new SQLiteConnection(database.ConnectionString);
                    database.Connection.Open();
                }

                connection = database.Connection;
            }
            catch (Exception eCheckConnection) {

                cmdlet.WriteError(
                    cmdlet,
                    "Could not open a connection to the database with name '" +
                    database.Name +
                    "'. " +
                    eCheckConnection.Message,
                    "CouldNotCheckConnection",
                    ErrorCategory.InvalidOperation,
                    true);
            }
            //SQLiteConnection connection = ConnectionMakeAlive(

            return connection;
        }
            #endregion connection
        #endregion Database
  
        #region Test Result
        //public static void BackupTestResults(PSCmdletBase cmdlet, SQLiteConnection connection)
        public static void BackupTestResults(PSCmdletBase cmdlet, string databaseName)
        {
            // 20120920
            SQLiteConnection connection = ConnectionMakeAlive(cmdlet, databaseName);

            DbProviderFactory factory = new SQLiteFactory();

            cmdlet.WriteVerbose(cmdlet, "begin transaction");
            using (DbTransaction dbTrans = connection.BeginTransaction()) {

                cmdlet.WriteVerbose(cmdlet, "creating a data adapter");
                using (DbDataAdapter adp1 = factory.CreateDataAdapter()) {

                    cmdlet.WriteVerbose(cmdlet, "creating a command");
                    using (DbCommand cmd1 = connection.CreateCommand()) {

                        cmdlet.WriteVerbose(cmdlet, "1");
                        cmd1.Transaction = dbTrans;

                        cmdlet.WriteVerbose(cmdlet, "2");
                        cmd1.CommandText = "SELECT * FROM TestSuites WHERE 1 = 2";
                        cmdlet.WriteVerbose(cmdlet, "3");
                        adp1.SelectCommand = cmd1;
                        
                        cmdlet.WriteVerbose(cmdlet, "4");
                        using (DbCommandBuilder bld1 = factory.CreateCommandBuilder()) {
                            
                            cmdlet.WriteVerbose(cmdlet, "5");
                            bld1.DataAdapter = adp1;
                            
                            cmdlet.WriteVerbose(cmdlet, "6");
                            using (DataTable tbl1 = new DataTable()) {
                                
                                cmdlet.WriteVerbose(cmdlet, "7");
                                adp1.Fill(tbl1);
                                //for (int n = 0; n < 10000; n++) {
                                cmdlet.WriteVerbose(cmdlet, "8");
                                for (int suiteCounter = 0; suiteCounter < TestData.TestSuites.Count; suiteCounter++) {
                                    cmdlet.WriteVerbose(cmdlet, "9");
                                    DataRow row1 = tbl1.NewRow();
                                    //row[1] = n;
                                    //(Id INTEGER PRIMARY KEY, SuiteId TEXT, SuiteName TEXT, StatusId NUMERIC, Description TEXT);");
                                    row1["SuiteId"] = SQLiteHelper.PrepareEscapedString(TestData.TestSuites[suiteCounter].Id);
                                    row1["SuiteName"] = SQLiteHelper.PrepareEscapedString(TestData.TestSuites[suiteCounter].Name);
                                    row1["StatusId"] = (int)TestData.TestSuites[suiteCounter].enStatus;
                                    row1["Description"] = SQLiteHelper.PrepareEscapedString(TestData.TestSuites[suiteCounter].Description);
                                    tbl1.Rows.Add(row1);
                                }
                                cmdlet.WriteVerbose(cmdlet, "12");
                                cmdlet.WriteVerbose(cmdlet, tbl1.Rows.Count.ToString() + " rows");
                                adp1.Update(tbl1);
                                cmdlet.WriteVerbose(cmdlet, tbl1.Rows.Count.ToString() + " rows");
                                cmdlet.WriteVerbose(cmdlet, "14");
                                //dbTrans.Commit();
                            }
                        }
                    }
                }
                
                cmdlet.WriteVerbose(cmdlet, "15");
                using (DbDataAdapter adp2 = factory.CreateDataAdapter()) {
                    
                    cmdlet.WriteVerbose(cmdlet, "16");
                    using (DbCommand cmd2 = connection.CreateCommand()) {
                        
                        cmdlet.WriteVerbose(cmdlet, "17");
                        cmd2.Transaction = dbTrans;
                        cmd2.CommandText = "SELECT * FROM TestScenarios WHERE 1 = 2";
                        cmdlet.WriteVerbose(cmdlet, "19");
                        adp2.SelectCommand = cmd2;
                        cmdlet.WriteVerbose(cmdlet, "20");
                        using (DbCommandBuilder bld2 = factory.CreateCommandBuilder()) {
                            
                            cmdlet.WriteVerbose(cmdlet, "21");
                            bld2.DataAdapter = adp2;
                            cmdlet.WriteVerbose(cmdlet, "22");
                            using (DataTable tbl2 = new DataTable()) {
                                
                                cmdlet.WriteVerbose(cmdlet, "23");
                                adp2.Fill(tbl2);
                                //for (int n = 0; n < 10000; n++) {
                                foreach (TestSuite testSuite in TestData.TestSuites) {
                                    for (int scenarioCounter = 0; scenarioCounter < testSuite.TestScenarios.Count; scenarioCounter++) {
                                        DataRow row2 = tbl2.NewRow();
                                        //row[1] = n;
                                        //Id INTEGER PRIMARY KEY, SuiteId TEXT, ScenarioId TEXT, ScenarioName TEXT, StatusId NUMERIC, Description TEXT);");
                                        row2["SuiteId"] = SQLiteHelper.PrepareEscapedString(testSuite.TestScenarios[scenarioCounter].SuiteId);
                                        row2["ScenarioId"] = SQLiteHelper.PrepareEscapedString(testSuite.TestScenarios[scenarioCounter].Id);
                                        row2["ScenarioName"] = SQLiteHelper.PrepareEscapedString(testSuite.TestScenarios[scenarioCounter].Name);
                                        //row["StatusId"] = (int)testSuite.TestScenarios[scenarioCounter].
                                        row2["Description"] = SQLiteHelper.PrepareEscapedString(testSuite.TestScenarios[scenarioCounter].Description);
                                        tbl2.Rows.Add(row2);
                                    }
                                }
                                cmdlet.WriteVerbose(cmdlet, "27");
                                adp2.Update(tbl2);
                                cmdlet.WriteVerbose(cmdlet, "28");
                                //dbTrans.Commit();
                            }
                        }
                    }
                }
                
                cmdlet.WriteVerbose(cmdlet, "29");
                using (DbDataAdapter adp3 = factory.CreateDataAdapter()) {
                    
                    cmdlet.WriteVerbose(cmdlet, "30");
                    using (DbCommand cmd3 = connection.CreateCommand()) {
                        
                        cmdlet.WriteVerbose(cmdlet, "31");
                        cmd3.Transaction = dbTrans;
                        cmd3.CommandText = "SELECT * FROM TestResults WHERE 1 = 2";
                        adp3.SelectCommand = cmd3;
                        
                        cmdlet.WriteVerbose(cmdlet, "34");
                        using (DbCommandBuilder bld3 = factory.CreateCommandBuilder()) {
                            
                            cmdlet.WriteVerbose(cmdlet, "35");
                            bld3.DataAdapter = adp3;
                            
                            cmdlet.WriteVerbose(cmdlet, "36");
                            using (DataTable tbl3 = new DataTable()) {
                                
                                cmdlet.WriteVerbose(cmdlet, "37");
                                adp3.Fill(tbl3);
                                //for (int n = 0; n < 10000; n++) {
                                foreach (TestSuite testSuite in TestData.TestSuites) {
                                    foreach (TestScenario testScenario in testSuite.TestScenarios) {
                                        for (int trCounter = 0; trCounter < testScenario.TestResults.Count; trCounter++) {
                                            DataRow row3= tbl3.NewRow();
                                            //row[1] = n;
                                            //Id INTEGER PRIMARY KEY, TestResultId TEXT, TestResultName TEXT, " +
                            //"StatusId NUMERIC, Description TEXT, ScriptName TEXT, LineNumber NUMERIC, " +
                            //"Position NUMERIC, Error BLOB, Code TEXT, Description TEXT, Parameters BLOB, " +
                            //"SuiteId TEXT, ScenarioId TEXT, Timestamp TEXT, TimeSpent NUMERIC, Generated NUMERIC, Screenshot TEXT);");
                                            row3["SuiteId"] = SQLiteHelper.PrepareEscapedString(testScenario.TestResults[trCounter].SuiteId);
                                            row3["ScenarioId"] = SQLiteHelper.PrepareEscapedString(testScenario.TestResults[trCounter].ScenarioId);
                                            
                                            row3["TestResultId"] = SQLiteHelper.PrepareEscapedString(testScenario.TestResults[trCounter].Id);
                                            row3["TestResultName"] = SQLiteHelper.PrepareEscapedString(SQLiteHelper.PrepareEscapedString(testScenario.TestResults[trCounter].Name));
                                            row3["ScriptName"] = SQLiteHelper.PrepareEscapedString(testScenario.TestResults[trCounter].ScriptName);
                                            row3["LineNumber"] = testScenario.TestResults[trCounter].LineNumber.ToString();
                                            row3["Position"] = testScenario.TestResults[trCounter].Position.ToString();
                                            if (null != testScenario.TestResults[trCounter].Error) {
                                                row3["Error"] = testScenario.TestResults[trCounter].Error;
                                            }
                                            row3["Code"] = SQLiteHelper.PrepareEscapedString(testScenario.TestResults[trCounter].Code);
                                            row3["Parameters"] = testScenario.TestResults[trCounter].Parameters;
                                            row3["Timestamp"] = testScenario.TestResults[trCounter].Timestamp;
                                            row3["TimeSpent"] = testScenario.TestResults[trCounter].TimeSpent;
                                            row3["Generated"] = Convert.ToInt32(testScenario.TestResults[trCounter].Generated);
                                            //row3["Screenshot"] = testScenario.TestResults[trCounter].Screenshot;
                                            if (null != testScenario.TestResults[trCounter].Screenshot) {
                                                byte[] screenshot = 
                                                    GetScreenshotFromFileSystem(
                                                        testScenario.TestResults[trCounter].Screenshot);
                                                row3["Screenshot"] = screenshot;
                                            }
                                            row3["StatusId"] = (int)testScenario.TestResults[trCounter].enStatus;
                                            
                                            row3["Description"] = SQLiteHelper.PrepareEscapedString(testScenario.TestResults[trCounter].Description);
                                            
                                            tbl3.Rows.Add(row3);
                                        }
                                    }
                                }
                                cmdlet.WriteVerbose(cmdlet, "38");
                                adp3.Update(tbl3);
                                cmdlet.WriteVerbose(cmdlet, "39");
                                //dbTrans.Commit();
                                cmdlet.WriteVerbose(cmdlet, "40");
                            }
                        }
                    }
                }
                
                
                cmdlet.WriteVerbose(cmdlet, "41");
                using (DbDataAdapter adp4 = factory.CreateDataAdapter()) {
                    
                    cmdlet.WriteVerbose(cmdlet, "42");
                    using (DbCommand cmd4 = connection.CreateCommand()) {
                        
                        cmdlet.WriteVerbose(cmdlet, "43");
                        cmd4.Transaction = dbTrans;
                        cmd4.CommandText = "SELECT * FROM TestResultDetails WHERE 1 = 2";
                        cmdlet.WriteVerbose(cmdlet, "45");
                        adp4.SelectCommand = cmd4;
                        
                        cmdlet.WriteVerbose(cmdlet, "46");
                        using (DbCommandBuilder bld4 = factory.CreateCommandBuilder()) {
                            
                            bld4.DataAdapter = adp4;
                            
                            cmdlet.WriteVerbose(cmdlet, "48");
                            using (DataTable tbl4 = new DataTable()) {
                                
                                cmdlet.WriteVerbose(cmdlet, "49");
                                adp4.Fill(tbl4);
                                //for (int n = 0; n < 10000; n++) {
                                foreach (TestSuite testSuite in TestData.TestSuites) {
                                    foreach (TestScenario testScenario in testSuite.TestScenarios) {
                                        foreach (TestResult testResult in testScenario.TestResults) {
                                            for (int trdCounter = 0; trdCounter < testResult.Details.Count; trdCounter++) {
                                                DataRow row4 = tbl4.NewRow();
                                                //Id INTEGER PRIMARY KEY, TestResultId TEXT, TestResultDetailName TEXT, " +
                                                //"TestResultDetail BLOB);"
                                                row4["TestResultId"] = SQLiteHelper.PrepareEscapedString(testResult.Id);
                                                row4["TestResultDetailName"] = SQLiteHelper.PrepareEscapedString(testResult.Details[trdCounter].Name);
                                                row4["Timestamp"] = testResult.Details[trdCounter].Timestamp;
                                                row4["TestResultDetail"] = SQLiteHelper.PrepareEscapedString(testResult.Details[trdCounter].GetDetail().ToString());
                                                tbl4.Rows.Add(row4);
                                            }
                                        }
                                    }
                                }
                                adp4.Update(tbl4);
                                dbTrans.Commit();
                            }
                        }
                    }
                }
            }
        }
        
        internal static string PrepareEscapedString(string inputString)
        {
            string result = inputString;
            
            if (string.Empty == result) {
                return result;
            }
            
            try {
                result = result.Replace(@"""", @"'""");
                result = result.Replace(@"'", @"''");
            } catch {
                return result;
            }
            
            return result;
        }
        
        public static void RestoreTestResults(PSCmdletBase cmdlet, string[] bucketNames)
        {
            
        }
        
        public static byte[] GetScreenshotFromFileSystem(string filePath)
        {
            byte[] screenshot = null;
            try {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                
                byte[] arr = br.ReadBytes((int)fs.Length);
                
                br.Close();
                fs.Close();
                //screenshot = arr;
                return arr;
            }
            catch {
                //
            }
            return screenshot;
        }
        
        public static void SetScreenshotToFileSystem(
            string testResultName, 
            string testResultId,
            string filePath)
        {
//            byte[] screenshot = null;
//            try {
//                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
//                BinaryReader br = new BinaryReader(fs);
//                
//                byte[] arr = br.ReadBytes((int)fs.Length);
//                
//                br.Close();
//                fs.Close();
//                //screenshot = arr;
//                return arr;
//            }
//            catch {
//                //
//            }
//            return screenshot;
        }
        
        
//        // **** Read BLOB from the Database and save it on the Filesystem
//        public void GetEmployee(string plastName,string pfirstName)
//        {
//            SqlCommand getEmp = new SqlCommand(
//                "SELECT EmployeeID, Photo "+
//                "FROM Employees "+
//                "WHERE LastName = @lastName "+
//                "AND FirstName = @firstName", _conn);
//
//            getEmp.Parameters.Add("@LastName",  SqlDbType.NVarChar, 20).Value = plastName;
//            getEmp.Parameters.Add("@FirstName", SqlDbType.NVarChar, 10).Value = pfirstName;
//
//            FileStream fs;                          // Writes the BLOB to a file (*.bmp).
//            BinaryWriter bw;                        // Streams the BLOB to the FileStream object.
//            int bufferSize = 100;                   // Size of the BLOB buffer.
//            byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
//            long retval;                            // The bytes returned from GetBytes.
//            long startIndex = 0;                    // The starting position in the BLOB output.
//            string emp_id = "";                     // The employee id to use in the file name.
//
//            // Open the connection and read data into the DataReader.
//            _conn.Open();
//            SqlDataReader myReader = getEmp.ExecuteReader(CommandBehavior.SequentialAccess);
//
//            while (myReader.Read())
//            {
//                // Get the employee id, which must occur before getting the employee.
//                emp_id = myReader.GetInt32(0).ToString();
//
//                // Create a file to hold the output.
//                fs = new FileStream("employee" + emp_id + ".bmp",
//                                    FileMode.OpenOrCreate, FileAccess.Write);
//                bw = new BinaryWriter(fs);
//
//                // Reset the starting byte for the new BLOB.
//                startIndex = 0;
//
//                // Read the bytes into outbyte[] and retain the number of bytes returned.
//                retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
//
//                // Continue reading and writing while there are bytes beyond the size of the buffer.
//                while (retval == bufferSize)
//                {
//                    bw.Write(outbyte);
//                    bw.Flush();
//
//                    // Reposition the start index to the end of the last buffer and fill the buffer.
//                    startIndex += bufferSize;
//                    retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
//                }
//
//                // Write the remaining buffer.
//                bw.Write(outbyte, 0, (int)retval);
//                bw.Flush();
//
//                // Close the output file.
//                bw.Close();
//                fs.Close();
//            }
//
//            // Close the reader and the connection.
//            myReader.Close();
//            _conn.Close();
//        }
        #endregion Test Result
        
        #region Bucket
        public static void CreateBucket(
            PSCmdletBase cmdlet, 
            string[] bucketNames,
            string[] bucketTags,
            string[] bucketDescriptions)
        {
            
            try {
                checkConnection(TestData.CurrentStructureDB.Connection);
                
                DbProviderFactory factory = new SQLiteFactory();
            
                cmdlet.WriteVerbose(cmdlet, "begin transaction");
                using (DbTransaction dbTrans = 
                       TestData.CurrentStructureDB.Connection.BeginTransaction()) {
                    
                    cmdlet.WriteVerbose(cmdlet, "creating a data adapter");
                    using (DbDataAdapter adpBucket = factory.CreateDataAdapter()) {
                        
                        cmdlet.WriteVerbose(cmdlet, "creating a command");
                        using (DbCommand cmd1 = TestData.CurrentStructureDB.Connection.CreateCommand()) {
                            
                            cmd1.Transaction = dbTrans;
                            cmd1.CommandText = "SELECT * FROM TestBuckets WHERE 1 = 2";
                            adpBucket.SelectCommand = cmd1;
                            
                            using (DbCommandBuilder bldBucket = factory.CreateCommandBuilder()) {
                                
                                bldBucket.DataAdapter = adpBucket;
                                
                                using (DataTable tblBucket = new DataTable()) {
                                    
                                    adpBucket.Fill(tblBucket);

                                    for (int i = 0; i < bucketNames.Length; i++) {
                                        DataRow rowBucket = tblBucket.NewRow();
                                        rowBucket["BucketName"] = bucketNames[i];
                                        rowBucket["BucketTag"] = bucketTags[i];
                                        rowBucket["Description"] = bucketDescriptions[i];
                                        tblBucket.Rows.Add(rowBucket);
                                        
                                        ITestBucket bucket =
                                            new TestBucket(
                                                bucketNames[i],
                                                bucketTags[i],
                                                bucketDescriptions[i]);
                                        bucket.BucketId = (int)rowBucket["BucketId"];
                                    }
                                    cmdlet.WriteVerbose(cmdlet, "12");
                                    cmdlet.WriteVerbose(cmdlet, tblBucket.Rows.Count.ToString() + " rows");
                                    adpBucket.Update(tblBucket);
                                    cmdlet.WriteVerbose(cmdlet, tblBucket.Rows.Count.ToString() + " rows");
                                    cmdlet.WriteVerbose(cmdlet, "14");
                                }
                            }
                        }
                    }
                    dbTrans.Commit();
                }
            }
            catch (Exception eCreateBucket) {
                cmdlet.WriteError(cmdlet,
                                  "Failed to create test bucket(s). " +
                                  eCreateBucket.Message,
                                  "CreateBucketFailed",
                                  ErrorCategory.InvalidOperation,
                                  true);
            }
        }
        
        public static void DeleteBucket(PSCmdletBase cmdlet, string[] bucketNames)
        {
            foreach (string bucketName in bucketNames) {
                
            }
        }
        
        public static void GetBucket(PSCmdletBase cmdlet, string[] bucketNames)
        {
            foreach (string bucketName in bucketNames) {
                
            }
        }
        
        public static void ChangeBucket(PSCmdletBase cmdlet, string[] bucketNames)
        {
            foreach (string bucketName in bucketNames) {
                
            }
        }
        #endregion Bucket
        
        #region Constant
        public static void CreateConstant(
            PSCmdletBase cmdlet,
            //int testBucketId,
            ITestBucket bucket,
            string[] constantNames, 
            object[] constantValues,
            System.Type[] constantTypes)
        {
            try {
                checkConnection(TestData.CurrentStructureDB.Connection);
                
                DbProviderFactory factory = new SQLiteFactory();
            
                cmdlet.WriteVerbose(cmdlet, "begin transaction");
                using (DbTransaction dbTrans = 
                       TestData.CurrentStructureDB.Connection.BeginTransaction()) {
                    
                    cmdlet.WriteVerbose(cmdlet, "creating a data adapter");
                    using (DbDataAdapter adpConstant = factory.CreateDataAdapter()) {
                        
                        cmdlet.WriteVerbose(cmdlet, "creating a command");
                        using (DbCommand cmd1 = TestData.CurrentStructureDB.Connection.CreateCommand()) {
                            
                            cmd1.Transaction = dbTrans;
                            cmd1.CommandText = "SELECT * FROM TestConstants WHERE 1 = 2";
                            adpConstant.SelectCommand = cmd1;
                            
                            using (DbCommandBuilder bldConstant = factory.CreateCommandBuilder()) {
                                
                                bldConstant.DataAdapter = adpConstant;
                                
                                using (DataTable tblConstant = new DataTable()) {
                                    
                                    adpConstant.Fill(tblConstant);

                                    for (int i = 0; i < constantNames.Length; i++) {
                                        DataRow rowConstant = tblConstant.NewRow();
                                        rowConstant["ConstantName"] = constantNames[i];
                                        //rowConstant["ConstantTag"] = constantTags[i];
                                        //rowConstant["Description"] = constantDescriptions[i];
                                        rowConstant["ConstantValue"] = constantValues[i];
                                        rowConstant["ConstantType"] = constantTypes[i];
                                        rowConstant["BucketId"] = bucket.BucketId;
                                        tblConstant.Rows.Add(rowConstant);
                                        
                                        ITestConstant constant =
                                            new TestConstant(
                                                constantNames[i],
                                                constantValues[i],
                                                constantTypes[i]);
                                        constant.BucketId = bucket.BucketId;
                                    }
                                    cmdlet.WriteVerbose(cmdlet, "12");
                                    cmdlet.WriteVerbose(cmdlet, tblConstant.Rows.Count.ToString() + " rows");
                                    adpConstant.Update(tblConstant);
                                    cmdlet.WriteVerbose(cmdlet, tblConstant.Rows.Count.ToString() + " rows");
                                    cmdlet.WriteVerbose(cmdlet, "14");
                                }
                            }
                        }
                    }
                    dbTrans.Commit();
                }
            }
            catch (Exception eCreateConstant) {
                cmdlet.WriteError(cmdlet,
                                  "Failed to create test constant(s). " +
                                  eCreateConstant.Message,
                                  "CreateConstantFailed",
                                  ErrorCategory.InvalidOperation,
                                  true);
            }
        }
        
        public static void DeleteConstant(PSCmdletBase cmdlet, string[] constantNames)
        {
            foreach (string constantName in constantNames) {
                
            }
        }
        
        public static void GetConstant(PSCmdletBase cmdlet, string[] constantNames)
        {
            foreach (string constantName in constantNames) {
                
            }
        }
        
        public static void ChangeConstant(PSCmdletBase cmdlet, string[] constantNames, object[] constantValues)
        {
            foreach (string constantName in constantNames) {
                
            }
        }
        #endregion Constant
        
        #region Test Case
        public static void CreateTestCase(PSCmdletBase cmdlet, string testCaseName, ScriptBlock beforeCode, ScriptBlock mainCode, ScriptBlock afterCode)
        {
            
        }
        
        public static void DeleteTestCase(PSCmdletBase cmdlet, string[] testCaseNames)
        {
            foreach (string testCaseName in testCaseNames) {
                
            }
        }
        
        public static void GetTestCase(PSCmdletBase cmdlet, string[] testCaseNames)
        {
            foreach (string testCaseName in testCaseNames) {
                
            }
        }
        
        public static void ChangeTestCase(PSCmdletBase cmdlet, string[] testCaseNames)
        {
            foreach (string testCaseName in testCaseNames) {
                
            }
        }
        #endregion Test Case
    }
}
