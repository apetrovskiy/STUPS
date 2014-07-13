/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of OpenTmxTestDBCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, "TmxTestDB")]
    [OutputType(typeof(IDatabase))]
    public class OpenTmxTestDBCommand : DatabaseFileOpenCmdletBase
    {
        protected override void BeginProcessing()
        {
            this.CheckCmdletParameters();
            
            // check input
            if (!this.StructureDB && !this.RepositoryDB && !this.ResultsDB) {
                this.StructureDB = true;
                this.RepositoryDB = true;
                this.ResultsDB = true;
            }

            SQLiteHelper.OpenDatabase(this, this.FileName, this.StructureDB, this.RepositoryDB, this.ResultsDB);
        }
    }
}
