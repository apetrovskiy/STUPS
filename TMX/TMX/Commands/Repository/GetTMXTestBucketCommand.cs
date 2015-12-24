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
    using System.Management.Automation;
    using Interfaces;
    
    /// <summary>
    /// Description of GetTmxTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TmxTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class GetTmxTestBucketCommand : TestBucketCmdletBase
    {
        public GetTmxTestBucketCommand()
        {
            checkDatabaseInput(InputObject);
            
            SQLiteHelper.GetBucket(this, BucketName);
        }
    }
}
