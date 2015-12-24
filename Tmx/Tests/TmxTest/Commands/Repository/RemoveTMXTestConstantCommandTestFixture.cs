/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/5/2012
 * Time: 12:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.Repository
{
    using System;
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of RemoveTmxTestConstantCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description=" test")]
    public class RemoveTmxTestConstantCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The New-TmxTestDB test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("New_TmxTestDB")]
        [MbUnit.Framework.Ignore("Not implemented yet")]
        [NUnit.Framework.Ignore("Not implemented yet")]
        public void CreateTestDB_Simple()
        {
            const string fileName = @".\test.db3";
            const string answer = @"True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestDB -FileName '" + 
                fileName + 
                @"'; " +
                @"Test-File '" + 
                fileName + 
                @"'; ",
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
