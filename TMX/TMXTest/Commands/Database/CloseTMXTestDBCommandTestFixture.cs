/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.Database
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of CloseTMXTestDBCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class CloseTMXTestDBCommandTestFixture
    {
        public CloseTMXTestDBCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The New-TMXTestDB test")]
        [Category("Slow")][Category("New_TMXTestDB")]
        public void CloseTestDB_Simple()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"$null = New-TMXTestDB -FileName '" + 
                Settings.FileName + 
                @"' -Name '" + 
                Settings.DatabaseName +
                @"';");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Close-TMXTestDB -Name '" +
                Settings.DatabaseName +
                @"';");
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"[TMX.TestData]::CurrentResultsDB;");
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"[TMX.TestData]::CurrentStructureDB;");
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
