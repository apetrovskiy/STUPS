/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of NewTmxTestSuiteCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="New-TmxTestSuite test")]
    public class NewTmxTestSuiteCommandTestFixture
    {
        public NewTmxTestSuiteCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Simple()
        {
            string name = "suite1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name " + 
                name + 
                ").Name;",
                name);
        }
        
        [Test] //[Test(Description="The -Name parameter test: complex name")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Complex()
        {
            string name = @"suite%%`1  1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"(New-TmxTestSuite -Name '" + 
                name + 
                "').Name;",
                name);
        }
        
        [Test] //[Test(Description="The -Name parameter test: simple name, a series of suites")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Simple_In_Series()
        {
            string name = "suite3";
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
        
        [Test] //[Test(Description="The -Name parameter test: complex name, a series of suites")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Complex_In_Series()
        {
            string name = @"suite%%`3  3";
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
        
        [Test] //[Test(Description="The -Id parameter test: simple name and Id")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_Numeric()
        {
            string name = "suite1";
            string id = "3";
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
        
        [Test] //[Test(Description="The -Id parameter test: simple name and complex Id")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_Alphanumeric()
        {
            string name = "suite1";
            string id = @"a\ 3";
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
        
        [Test] //[Test(Description="The -Id parameter test: simple Id")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Id_Numeric()
        {
            string name = "suite3";
            string id = "3";
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
        
        [Test] //[Test(Description="The -Id parameter test: complex Id")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Id_Alphanumeric()
        {
            string name = "suite3";
            string id = @"a\ 3";
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
        
        [Test] //[Test(Description="The -Description parameter test: simple name and Id, and description")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_AndDescription()
        {
            string name = "suite1";
            string id = "3";
            string description = "descr";
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
        
        [Test] //[Test(Description="The -Description parameter test: name, Id, and description are all perverse")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_Description_Perverse1()
        {
            string name = @"  567   ";
            string id = @"   777   ";
            string description = @"   888   ";
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
        
        [Test] //[Test(Description="The all of parameters test: name, Id, and description are all perverse 2")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("New_TmxTestSuite")]
        public void TestPrm_Name_Id_Description_Perverse2()
        {
            string name = @"``//\\`""`''#$(1)567";
            string id = @"-5.5";
            string description = @"$($null)";
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

        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
