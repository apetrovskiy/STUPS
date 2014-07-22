/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/9/2012
 * Time: 10:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
	using Tmx.Interfaces;
    
    /// <summary>
    /// Description of SetTmxTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TmxTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class SetTmxTestBucketCommand : TestBucketCmdletBase
    {
        public SetTmxTestBucketCommand()
        {
            this.checkDatabaseInput(this.InputObject);
            
            SQLiteHelper.ChangeBucket(this, this.BucketName);
        }
    }
}
