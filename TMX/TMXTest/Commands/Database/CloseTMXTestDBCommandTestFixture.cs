/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/8/2012
 * Time: 2:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.Database
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of CloseTmxTestDBCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class CloseTmxTestDBCommandTestFixture
    {
        public CloseTmxTestDBCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The New-TmxTestDB test")]
        [Category("Slow")]
        [Category("Close_TmxTestDB")]
        public void CloseTestDB_Simple()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"$null = New-TmxTestDB -FileName '" + 
                Settings.FileName + 
                @"' -Name '" + 
                Settings.DatabaseName +
                // 20130130
                //@"';");
                @"' -StructureDB -RepositoryDB -ResultsDB;");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Close-TmxTestDB -Name '" +
                Settings.DatabaseName +
                @"';");
            // 20130130
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"[TMX.TestData]::CurrentResultsDB;");
//            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
//                @"[TMX.TestData]::CurrentStructureDB;");
            // 20130130
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ($null -eq [TMX.TestData]::CurrentRepositoryDB) { ""1""; }");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ($null -eq [TMX.TestData]::CurrentResultsDB) { ""1""; }");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ($null -eq [TMX.TestData]::CurrentStructureDB) { ""1""; }");
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
