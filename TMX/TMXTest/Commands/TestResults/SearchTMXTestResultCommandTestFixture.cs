/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestResults
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SearchTMXTestResultCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Search-TMXTestTestResult test")]
    public class SearchTMXTestResultCommandTestFixture
    {
        public SearchTMXTestResultCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_Name_Simple_In_Series()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(null);
            coll.Add(new System.Management.Automation.PSObject("autoclosed"));
            coll.Add(new System.Management.Automation.PSObject("tr 1"));
            coll.Add(new System.Management.Automation.PSObject("tr 1"));
            coll.Add(new System.Management.Automation.PSObject("tr 1"));
            coll.Add(new System.Management.Automation.PSObject("tr 2"));
            coll.Add(new System.Management.Automation.PSObject("tr 2"));
            
            coll.Add(new System.Management.Automation.PSObject("tr 2"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 2' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 2' -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 2' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario5; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"Search-TMXTestResult -OrderById | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_Name_Complex_In_Series()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(null);
            coll.Add(new System.Management.Automation.PSObject("autoclosed"));
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 1"));
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 2"));
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 3"));
            coll.Add(new System.Management.Automation.PSObject("autoclosed"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 1' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 2' -TestPassed; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 3' -TestPassed; " + 
                @"Search-TMXTestResult -OrderById | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_Id_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(null);
            coll.Add(new System.Management.Automation.PSObject("1")); // autoclosed
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("100"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            //coll.Add(new System.Management.Automation.PSObject("1")); // ???? // autoclosed
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_Id_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(null);
            coll.Add(new System.Management.Automation.PSObject(@"1")); // autoclosed
            coll.Add(new System.Management.Automation.PSObject(@"1")); // ? // autoclosed
            coll.Add(new System.Management.Automation.PSObject(@"a\ 1"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 1"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 'a\ 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 'a\ 2'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 'a\ 1' -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 'a\ 2' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 'a\ 3'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 'a\ 3'; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 'a\ 4'; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 'a\ 2'; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 'a\ 5'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 'a\ 1' -TestPassed; " + 
                @"Search-TMXTestResult -OrderById | %{$_.Id;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderById parameter test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_OrderById_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(null);
            coll.Add(new System.Management.Automation.PSObject("1")); // autoclosed
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            //coll.Add(new System.Management.Automation.PSObject("1")); // ???? // autoclosed
            coll.Add(new System.Management.Automation.PSObject("100"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById and -Descending parameters test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_OrderById_Descending_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("100")); // // autoclosed
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            //coll.Add(new System.Management.Automation.PSObject("1")); // ? // ???? // autoclosed
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(null);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderById -Descending | %{$_.Id;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderByName parameter test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_OrderByName_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(null);
            coll.Add(new System.Management.Automation.PSObject("autoclosed"));
            coll.Add(new System.Management.Automation.PSObject("tr1"));
            coll.Add(new System.Management.Automation.PSObject("tr2"));
            coll.Add(new System.Management.Automation.PSObject("tr3"));
            coll.Add(new System.Management.Automation.PSObject("tr4"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 100'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 2'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 3'; " + // ????
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 5'; " + 
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderByName | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByName and -Descending parameters test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_OrderByName_Descending_Alphanumeric()        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("tr4"));
            coll.Add(new System.Management.Automation.PSObject("tr3"));
            coll.Add(new System.Management.Automation.PSObject("tr2"));
            coll.Add(new System.Management.Automation.PSObject("tr1"));
            coll.Add(new System.Management.Automation.PSObject("autoclosed"));
            coll.Add(null);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderByName -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -OrderByDateTime parameter test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_OrderByDateTime_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(null);
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("100"));
            //
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 300; " +
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 500; " +
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 100; " +
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"sleep -Milliseconds 50; " +
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"sleep -Milliseconds 700; " +
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1000; " +
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"sleep -Milliseconds 200; " +
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderByDateTime | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByDateTime and -Descending parameters test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_OrderByDateTime_Descending_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("100"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(null);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 300; " +
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 500; " +
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 100; " +
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"sleep -Milliseconds 50; " +
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"sleep -Milliseconds 700; " +
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1000; " +
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"sleep -Milliseconds 200; " +
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderByDateTime -Descending | %{$_.Id;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderByTimeSpent parameter test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_OrderByTimeSpent_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(null);
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("100"));
            //
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 300; " +
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 500; " +
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 100; " +
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"sleep -Milliseconds 50; " +
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"sleep -Milliseconds 700; " +
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1000; " +
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"sleep -Milliseconds 200; " +
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderByTimeSpent | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByTimeSpent and -Descending parameters test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_OrderByTimeSpent_Descending_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("100"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(null);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 300; " +
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 500; " +
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 100; " +
                @"$null = Close-TMXTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"sleep -Milliseconds 50; " +
                @"$null = Close-TMXTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"sleep -Milliseconds 700; " +
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1000; " +
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"sleep -Milliseconds 200; " +
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Close-TMXTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TMXTestResult -OrderByTimeSpent -Descending | %{$_.Id;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterNameContains parameter test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_FilterNameContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("tr 01"));
            coll.Add(new System.Management.Automation.PSObject("tr 02"));
            coll.Add(new System.Management.Automation.PSObject("tr 02"));
            coll.Add(new System.Management.Automation.PSObject("tr 02"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 01' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario5; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"Search-TMXTestResult -FilterNameContains '0' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterNameContains and -Descending parameters test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_FilterNameContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("tr 02"));
            coll.Add(new System.Management.Automation.PSObject("tr 02"));
            coll.Add(new System.Management.Automation.PSObject("tr 02"));
            coll.Add(new System.Management.Automation.PSObject("tr 01"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario3; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 01' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TMXTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TMXTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario5; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"Search-TMXTestResult -FilterNameContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterIdContains parameter test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_FilterIdContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("a"));
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 2"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 1' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 2' -Id 01 -TestPassed; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 3' -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'a' -Id '003' -TestPassed; " + 
                @"Search-TMXTestResult -FilterIdContains '0' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterIdContains and -Descending parameters test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_FilterIdContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 2"));
            coll.Add(new System.Management.Automation.PSObject("a"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 1' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 2' -Id 01 -TestPassed; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 3' -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'a' -Id '003' -TestPassed; " + 
                @"Search-TMXTestResult -FilterIdContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterDescriptionContains parameter test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_FilterDescriptionContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 1"));
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 3"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 1' -Description 'abc' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 2' -Id 01 -TestPassed; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 3' -Description 'cab' -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'a' -Id '003' -Description 'ccc' -TestPassed; " + 
                @"Search-TMXTestResult -FilterDescriptionContains 'ab' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterDescriptionContains and -Descending parameters test")]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Search_TMXTestResult")]
        public void TestPrm_FilterDescriptionContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 1"));
            coll.Add(new System.Management.Automation.PSObject("test result`r`n%% 3"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 1' -Description 'abc' -TestPassed; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 2' -Id 01 -TestPassed; " + 
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TMXTestResult -Name 'test result`r`n%% 3' -Description 'cab' -TestPassed; " + 
                @"$null = Close-TMXTestResult -Name 'a' -Id '003' -Description 'ccc' -TestPassed; " + 
                @"Search-TMXTestResult -FilterDescriptionContains 'ab' -Descending | %{$_.Name;}",
                coll);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
