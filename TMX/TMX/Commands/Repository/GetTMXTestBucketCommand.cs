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
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of GetTmxTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class GetTmxTestBucketCommand : TestBucketCmdletBase
    {
        public GetTmxTestBucketCommand()
        {
            this.checkDatabaseInput(this.InputObject);
            
            SQLiteHelper.GetBucket(this, this.BucketName);
        }
    }
}
