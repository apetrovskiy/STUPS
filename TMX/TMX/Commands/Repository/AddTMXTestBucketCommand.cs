/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of AddTmxTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TmxTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class AddTmxTestBucketCommand : TestBucketCmdletBase
    {
        protected override void ProcessRecord()
        {
            this.checkDatabaseInput(this.InputObject);
            
            SQLiteHelper.CreateBucket(this, this.BucketName, this.Tag, this.Description);
        }
    }
}
