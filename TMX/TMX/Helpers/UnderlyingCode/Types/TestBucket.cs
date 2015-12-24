/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 1:40 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using Interfaces;
    
    /// <summary>
    /// Description of TestBucket.
    /// </summary>
    public class TestBucket : ITestBucket
    {
        public TestBucket(string name)
        {
            BucketName = name;
        }
        
        public TestBucket(string name, string tag)
        {
            BucketName = name;
            BucketTag = tag;
        }
        
//        public TestBucket(string name, string description)
//        {
//            this.Name = name;
//            this.Description = description;
//        }
        
        public TestBucket(string name, string tag, string description)
        {
            BucketName = name;
            BucketTag = tag;
            Description = description;
        }
        
        public int BucketId { get; set; }
        public string BucketName { get; set; }
        public string BucketTag { get; set; }
        public string Description { get; set; }
    }
}
