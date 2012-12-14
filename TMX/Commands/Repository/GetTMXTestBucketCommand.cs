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
    /// Description of GetTMXTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TMXTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class GetTMXTestBucketCommand : TestBucketCmdletBase
    {
        public GetTMXTestBucketCommand()
        {
            this.checkDatabaseInput(this.InputObject);
            
            SQLiteHelper.GetBucket(this, this.BucketName);
        }
    }
}
