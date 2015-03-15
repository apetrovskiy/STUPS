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
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of OpenTmxTestDBCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description=" test")]
    public class OpenTmxTestDBCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The New-TmxTestDB test")]
        [MbUnit.Framework.Category("Slow")]
        //[MbUnit.Framework.Category("New_TmxTestDB")]
        [MbUnit.Framework.Ignore("temporary, ofr greening, 20140715")]
        [NUnit.Framework.Ignore("temporary, ofr greening, 20140715")]
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
                @"if ($null -ne [Tmx.TestData]::CurrentRepositoryDB) { ""1""; }");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ($null -ne [Tmx.TestData]::CurrentResultsDB) { ""1""; }");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ($null -ne [Tmx.TestData]::CurrentStructureDB) { ""1""; }");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Close-TmxTestDB -Name " +
                Settings.DatabaseName +
                @";");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"Remove-Item '" + 
                Settings.FileName +
                @"';");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
