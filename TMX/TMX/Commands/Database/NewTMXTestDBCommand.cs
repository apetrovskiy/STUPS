/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewTmxTestDBCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TmxTestDB")]
    [OutputType(typeof(IDatabase))]
    public class NewTmxTestDBCommand : DatabaseFileOpenCmdletBase //DatabaseFileCmdletBase
    {
        public NewTmxTestDBCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            // check input
            if (!this.StructureDB && !this.RepositoryDB && !this.ResultsDB) {
                this.StructureDB = true;
                this.RepositoryDB = true;
                this.ResultsDB = true;
            }
            
            SQLiteHelper.CreateDatabase(this, this.FileName, this.StructureDB, this.RepositoryDB, this.ResultsDB);
        }
    }
}
