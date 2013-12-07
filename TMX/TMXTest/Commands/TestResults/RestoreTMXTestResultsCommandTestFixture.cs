/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 3:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestResults
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of RestoreTmxTestResultsCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class RestoreTmxTestResultsCommandTestFixture
    {
        public RestoreTmxTestResultsCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The New-TmxTestDB test")]
        [Category("Slow")]
        [Category("New_TmxTestDB")]
        [Ignore("Not implemented yet")]
        public void CreateTestDB_Simple()
        {
            string fileName = @".\test.db3";
            string answer = @"True";
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
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
