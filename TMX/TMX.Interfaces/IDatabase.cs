/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/6/2012
 * Time: 1:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    using System.Data;
    
    /// <summary>
    /// Description of IDatabase.
    /// </summary>
    public interface IDatabase
    {
        string Name { get; set; }
        string Path { get; set; }
        // System.Data.SQLite.SQLiteConnection Connection { get; set; }
        IDbConnection Connection { get; set; }
        string ConnectionString { get; set; }
        bool IsStructureDB { get; set; }
        bool IsRepositoryDB { get; set; }
        bool IsResultsDB { get; set; }
    }
}
