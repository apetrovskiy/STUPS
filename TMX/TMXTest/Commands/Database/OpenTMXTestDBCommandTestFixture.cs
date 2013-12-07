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
    /// Description of OpenTmxTestDBCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description=" test")]
    public class OpenTmxTestDBCommandTestFixture
    {
        public OpenTmxTestDBCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The New-TmxTestDB test")]
        [Category("Slow")]
        //[Category("New_TmxTestDB")]
        public void OpenTestDB_Simple()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"$null = New-TmxTestDB -FileName '" + 
                Settings.FileName + 
                @"' -Name " + 
                Settings.DatabaseName +
                @"-StructureDB -RepositoryDB -ResultsDB;");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Close-TmxTestDB -Name " +
                Settings.DatabaseName +
                @";");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestDB -FileName '" +
                Settings.FileName +
                @"' -Name " + 
                Settings.DatabaseName +
                @").Path;",
                Settings.FileName);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ($null -ne [TMX.TestData]::CurrentRepositoryDB) { ""1""; }");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ($null -ne [TMX.TestData]::CurrentResultsDB) { ""1""; }");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ($null -ne [TMX.TestData]::CurrentStructureDB) { ""1""; }");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Close-TmxTestDB -Name " +
                Settings.DatabaseName +
                @";");
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
