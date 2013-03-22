/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestResults
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of BackupTMXTestResultsCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class BackupTMXTestResultsCommandTestFixture
    {
        public BackupTMXTestResultsCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The New-TMXTestDB test")]
        [Category("Slow")]
        [Category("New_TMXTestDB")]
        [Ignore("Not implemented yet")]
        public void CreateTestDB_Simple()
        {
            string fileName = @".\test.db3";
            string answer = @"True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestDB -FileName '" + 
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
