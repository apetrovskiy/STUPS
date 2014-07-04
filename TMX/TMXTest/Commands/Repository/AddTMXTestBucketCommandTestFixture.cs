/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/4/2012
 * Time: 2:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.Repository
{
    using System;
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of AddTmxTestBucketCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description=" test")]
    public class AddTmxTestBucketCommandTestFixture
    {
        public AddTmxTestBucketCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The Add-TmxTestBucket test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Add_TmxTestBucket")]
        [MbUnit.Framework.Ignore("Not implemented yet")]
        [NUnit.Framework.Ignore("Not implemented yet")]
        public void AddTestBucket_Simple()
        {
            string fileName = @".\test.db3";
            string bucketName = @"testbucket";
            string answer = @"testbucket";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestDB -FileName '" + 
                fileName + 
                @"' | Add-TmxTestBucket -Name '" +
                bucketName +
                @"').Name; ",
                answer);
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Remove-Item '" + 
                fileName +
                @"';");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
