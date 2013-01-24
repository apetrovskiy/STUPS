/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 2:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.Repository
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of AddTMXTestBucketCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class AddTMXTestBucketCommandTestFixture
    {
        public AddTMXTestBucketCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The Add-TMXTestBucket test")]
        [Category("Slow")]
        [Category("Add_TMXTestBucket")]
        [Ignore("Not implemented yet")]
        public void AddTestBucket_Simple()
        {
            string fileName = @".\test.db3";
            string bucketName = @"testbucket";
            string answer = @"testbucket";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TMXTestDB -FileName '" + 
                fileName + 
                @"' | Add-TMXTestBucket -Name '" +
                bucketName +
                @"').Name; ",
                answer);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Remove-Item '" + 
                fileName +
                @"';");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
