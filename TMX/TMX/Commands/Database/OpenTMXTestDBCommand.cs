/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System.Management.Automation;
    using Interfaces;
    
    /// <summary>
    /// Description of OpenTmxTestDBCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TmxTestDB")]
    [OutputType(typeof(IDatabase))]
    public class OpenTmxTestDBCommand : DatabaseFileOpenCmdletBase
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
//            SQLiteHelper.OpenDatabase(this, FileName, StructureDB, RepositoryDB, ResultsDB);
        }
    }
}
