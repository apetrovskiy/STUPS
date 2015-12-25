/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestStructure
{ // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of NewTmxTestSuiteCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="New-TmxTestSuite test")]
    public class NewTmxTestSuiteCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Simple()
        {
            const string name = "suite1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name " + 
                name + 
                ").Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Complex()
        {
            const string name = @"suite%%`1  1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: simple name, a series of suites")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Simple_In_Series()
        {
            const string name = "suite3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                "; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"(Open-TmxTestSuite -Name " + 
                name + 
                ").Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Name parameter test: complex name, a series of suites")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Complex_In_Series()
        {
            const string name = @"suite%%`3  3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = New-TmxTestSuite -Name '" + 
                name + 
                "'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`5  5'; " + 
                @"(Open-TmxTestSuite -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Id parameter test: simple name and Id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_Numeric()
        {
            const string name = "suite1";
            const string id = "3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name " + 
                name + 
                " -Id " + 
                id + 
                ").Name;",
                name);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestSuite -Name " + 
                name + 
                " -Id " + 
                id + 
                ").Id;",
                id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Id parameter test: simple name and complex Id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_Alphanumeric()
        {
            const string name = "suite1";
            const string id = @"a\ 3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name " + 
                name + 
                " -Id '" + 
                id + 
                "').Name;",
                name);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestSuite -Name " + 
                name + 
                " -Id '" + 
                id + 
                "').Id;",
                id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Id parameter test: simple Id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Id_Numeric()
        {
            const string name = "suite3";
            const string id = "3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                " -Id " +
                id + 
                "; " +
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                "(Open-TmxTestSuite -Id " + 
                id + 
                ").Id;",
                id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Id parameter test: complex Id")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Id_Alphanumeric()
        {
            const string name = "suite3";
            const string id = @"a\ 3";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = New-TmxTestSuite -Name " + 
                name + 
                " -Id '" +
                id + 
                "'; " +
                @"$null = New-TmxTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 'a\ 5'; " + 
                "(Open-TmxTestSuite -Id '" + 
                id + 
                "').Id;",
                id);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test: simple name and Id, and description")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_AndDescription()
        {
            const string name = "suite1";
            const string id = "3";
            const string description = "descr";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name " + 
                name + 
                " -Id " + 
                id + 
                " -description " +
                description + 
                ").Name;",
                name);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestSuite -Name " + 
                name + 
                " -Id " + 
                id + 
                ").Id;",
                id);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestSuite -Name " + 
                name + 
                " -Id " + 
                id + 
                ").Description;",
                description);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Description parameter test: name, Id, and description are all perverse")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_Description_Perverse1()
        {
            const string name = @"  567   ";
            const string id = @"   777   ";
            const string description = @"   888   ";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name '" + 
                name + 
                "' -Id '" + 
                id + 
                "' -description '" +
                description + 
                "').Name;",
                name);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestSuite -Name '" + 
                name + 
                "' -Id '" + 
                id + 
                "').Id;",
                id);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestSuite -Name '" + 
                name + 
                "' -Id '" + 
                id + 
                "').Description;",
                description);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The all of parameters test: name, Id, and description are all perverse 2")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_Description_Perverse2()
        {
            const string name = @"``//\\`""`''#$(1)567";
            const string id = @"-5.5";
            const string description = @"$($null)";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name '" + 
                name + 
                "' -Id '" + 
                id + 
                "' -description '" +
                description + 
                "').Name;",
                @"``//\\`""`'#$(1)567");
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestSuite -Name '" + 
                name + 
                "' -Id '" + 
                id + 
                "').Id;",
                id);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(Open-TmxTestSuite -Name '" + 
                name + 
                "' -Id '" + 
                id + 
                "').Description;",
                description);
        }

        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
