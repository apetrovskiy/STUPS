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
    using System;
    using System.Management.Automation;
    using System.Collections.Generic;
    using Tmx.Interfaces;
    
    /// <summary>
    /// Description of TestBucket.
    /// </summary>
    public class TestBucket : ITestBucket
    {
        public TestBucket(string name)
        {
            this.BucketName = name;
        }
        
        public TestBucket(string name, string tag)
        {
            this.BucketName = name;
            this.BucketTag = tag;
        }
        
//        public TestBucket(string name, string description)
//        {
//            this.Name = name;
//            this.Description = description;
//        }
        
        public TestBucket(string name, string tag, string description)
        {
            this.BucketName = name;
            this.BucketTag = tag;
            this.Description = description;
        }
        
        public int BucketId { get; set; }
        public string BucketName { get; set; }
        public string BucketTag { get; set; }
        public string Description { get; set; }
    }
}
