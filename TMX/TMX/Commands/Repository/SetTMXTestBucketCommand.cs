/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/9/2012
 * Time: 10:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of SetTMXTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TMXTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class SetTMXTestBucketCommand : TestBucketCmdletBase
    {
        public SetTMXTestBucketCommand()
        {
            this.checkDatabaseInput(this.InputObject);
            
            SQLiteHelper.ChangeBucket(this, this.BucketName);
        }
    }
}
