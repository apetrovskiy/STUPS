/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces
{
    using System;
    
    /// <summary>
    /// Description of ITestBucket.
    /// </summary>
    public interface ITestBucket
    {
        int BucketId { get; set; }
        string BucketName { get; set; }
        string BucketTag { get; set; }
    }
}
