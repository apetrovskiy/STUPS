/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/5/2012
 * Time: 12:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.Database
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of NewTMXTestDBCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class NewTMXTestDBCommandTestFixture
    {
        public NewTMXTestDBCommandTestFixture()
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
        public void CreateTestDB_Simple()
        {
            string answer = @"True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestDB -FileName '" + 
                Settings.FileName + 
                @"' -Name '" +
                Settings.DatabaseName +
                @"'; " +
                @"Test-Path -Path '" + 
                Settings.FileName + 
                @"'; ",
                answer);
            
            // additional checks here
            
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Close-TMXTestDB -Name '" +
                Settings.DatabaseName + 
                "';");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Remove-Item '" + 
                Settings.FileName +
                @"';");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
