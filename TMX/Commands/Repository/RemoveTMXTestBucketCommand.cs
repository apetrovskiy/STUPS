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
    /// Description of RemoveTMXTestBucketCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "TMXTestBucket")]
    [OutputType(typeof(ITestBucket))]
    public class RemoveTMXTestBucketCommand: TestBucketCmdletBase
    {
        public RemoveTMXTestBucketCommand()
        {
        }
    }
}
