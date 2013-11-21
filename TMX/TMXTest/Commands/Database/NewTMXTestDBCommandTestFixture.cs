/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/5/2012
 * Time: 12:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.Database
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of NewTmxTestDBCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class NewTmxTestDBCommandTestFixture
    {
        public NewTmxTestDBCommandTestFixture()
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
        public void CreateTestDB_Simple()
        {
            string answer = @"True";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestDB -FileName '" + 
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
                @"Close-TmxTestDB -Name '" +
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
