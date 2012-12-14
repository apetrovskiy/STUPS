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
    
    /// <summary>
    /// Description of AddTMXTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "TMXTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class AddTMXTestBucketCommand : TestBucketCmdletBase
    {
        public AddTMXTestBucketCommand()
        {
        }
        
        protected override void ProcessRecord()
        {
            this.checkDatabaseInput(this.InputObject);
            
            SQLiteHelper.CreateBucket(this, this.BucketName, this.Tag, this.Description);
        }
    }
}
