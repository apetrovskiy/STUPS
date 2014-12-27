/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 1:41 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    using System.Collections.Generic;
    using System.Data;
    // blocked due to the need to remove dependency on SQLite
//    using System.Data.Common;
//    using System.Data.SQLite;
    using Tmx.Interfaces;
    
    /// <summary>
    /// Description of Database.
    /// </summary>
    public class Database : IDatabase
    {
        // blocked due to the need to remove dependency on SQLite
//        public Database(
//            string name, 
//            string path, 
//            SQLiteConnection connection)
//        {
//            this.Name = name;
//            this.Path = path;
//            this.Connection = connection;
//            this.ConnectionString = connection.ConnectionString;
//        }
        
        public string Name { get; set; }
        public string Path { get; set; }
        // public System.Data.SQLite.SQLiteConnection Connection { get; set; }
        public IDbConnection Connection { get; set; }
        public string ConnectionString { get; set; }
        public bool IsStructureDB { get; set; }
        public bool IsRepositoryDB { get; set; }
        public bool IsResultsDB { get; set; }
    }
}
