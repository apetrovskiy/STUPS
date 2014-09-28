/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
	using Tmx.Interfaces;
    
    /// <summary>
    /// Description of NewTmxTestDBCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TmxTestDB")]
    [OutputType(typeof(IDatabase))]
    public class NewTmxTestDBCommand : DatabaseFileOpenCmdletBase //DatabaseFileCmdletBase
    {
        protected override void BeginProcessing()
        {
			CheckCmdletParameters();
            
            // check input
            if (!StructureDB && !RepositoryDB && !ResultsDB) {
				StructureDB = true;
				RepositoryDB = true;
				ResultsDB = true;
            }
            
            // blocked due to the need to remove dependency on SQLite
//			SQLiteHelper.CreateDatabase(this, FileName, StructureDB, RepositoryDB, ResultsDB);
        }
    }
}
