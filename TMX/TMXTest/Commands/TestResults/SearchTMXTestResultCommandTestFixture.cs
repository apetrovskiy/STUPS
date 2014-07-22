/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestResults
{
    using System;
    using System.Collections.ObjectModel;
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of SearchTmxTestResultCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Search-TmxTestTestResult test")]
    public class SearchTmxTestResultCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_Name_Simple_In_Series()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				null,
				new System.Management.Automation.PSObject("autoclosed"),
				new System.Management.Automation.PSObject("tr 1"),
				new System.Management.Automation.PSObject("tr 1"),
				new System.Management.Automation.PSObject("tr 1"),
				new System.Management.Automation.PSObject("tr 2"),
				new System.Management.Automation.PSObject("tr 2"),
				new System.Management.Automation.PSObject("tr 2")
			};
            
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 2' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 2' -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 2' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario5; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"Search-TmxTestResult -OrderById | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_Name_Complex_In_Series()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				null,
				new System.Management.Automation.PSObject("autoclosed"),
				new System.Management.Automation.PSObject("test result`r`n%% 1"),
				new System.Management.Automation.PSObject("test result`r`n%% 2"),
				new System.Management.Automation.PSObject("test result`r`n%% 3"),
				new System.Management.Automation.PSObject("autoclosed")
			};
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 1' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 2' -TestPassed; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 3' -TestPassed; " + 
                @"Search-TmxTestResult -OrderById | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_Id_Numeric()
        {
        	// after autogenerated test results were added
        	/*
			var coll = new Collection<System.Management.Automation.PSObject>() {
				null,
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("100"),
				new System.Management.Automation.PSObject("2")
			};
        	*/
			var coll = new Collection<System.Management.Automation.PSObject>() {
				null,
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("100"),
				new System.Management.Automation.PSObject("2")
			};
 // autoclosed
            //coll.Add(new System.Management.Automation.PSObject("1")); // ???? // autoclosed
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderById | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_Id_Alphanumeric()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				null,
				new System.Management.Automation.PSObject(@"1"),
				new System.Management.Automation.PSObject(@"1"),
				new System.Management.Automation.PSObject(@"a\ 1"),
				new System.Management.Automation.PSObject(@"a\ 1"),
				new System.Management.Automation.PSObject(@"a\ 2")
			};
 // autoclosed
 // ? // autoclosed
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 'a\ 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 'a\ 2'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 'a\ 1' -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 'a\ 2' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 'a\ 3'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 'a\ 3'; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 'a\ 4'; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 'a\ 2'; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 'a\ 5'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 'a\ 1' -TestPassed; " + 
                @"Search-TmxTestResult -OrderById | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_OrderById_Numeric()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				null,
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("100"),
				new System.Management.Automation.PSObject("2")
			};
 // autoclosed
            //coll.Add(new System.Management.Automation.PSObject("1")); // ???? // autoclosed
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderById | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_OrderById_Descending_Numeric()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("2"),
				new System.Management.Automation.PSObject("100"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				null
			};
 // // autoclosed
            //coll.Add(new System.Management.Automation.PSObject("1")); // ? // ???? // autoclosed
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderById -Descending | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByName parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_OrderByName_Alphanumeric()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				null,
				new System.Management.Automation.PSObject("autoclosed"),
				new System.Management.Automation.PSObject("tr1"),
				new System.Management.Automation.PSObject("tr2"),
				new System.Management.Automation.PSObject("tr3"),
				new System.Management.Automation.PSObject("tr4")
			};
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 100'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 2'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 3'; " + // ????
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 5'; " + 
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderByName | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByName and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_OrderByName_Descending_Alphanumeric()        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("tr4"),
				new System.Management.Automation.PSObject("tr3"),
				new System.Management.Automation.PSObject("tr2"),
				new System.Management.Automation.PSObject("tr1"),
				new System.Management.Automation.PSObject("autoclosed"),
				null
			};
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderByName -Descending | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByDateTime parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_OrderByDateTime_Numeric()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("2"),
				new System.Management.Automation.PSObject("100"),
				null
			};
            // 20130918
            // changes after spring-summer 2013
            // Expected Value : [null, {1}, {1}, {1}, {2}, {100}]
            // Actual Value   : [{1}, {1}, {1}, {2}, {100}, null]
            // coll.Add(null);
            // coll.Add(new System.Management.Automation.PSObject("1"));
            // coll.Add(new System.Management.Automation.PSObject("1"));
            // coll.Add(new System.Management.Automation.PSObject("1"));
            // coll.Add(new System.Management.Automation.PSObject("2"));
            // coll.Add(new System.Management.Automation.PSObject("100"));
            //
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 300; " +
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 500; " +
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 100; " +
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"sleep -Milliseconds 50; " +
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"sleep -Milliseconds 700; " +
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1000; " +
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"sleep -Milliseconds 200; " +
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderByDateTime | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByDateTime and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_OrderByDateTime_Descending_Numeric()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("100"),
				null,
				new System.Management.Automation.PSObject("2"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1")
			};
            // 20130918
            // changes after spring-summer 2013
            // Expected Value : [{100}, {2}, {1}, {1}, {1}, null]
            // Actual Value   : [{100}, null, {2}, {1}, {1}, {1}]
            // coll.Add(new System.Management.Automation.PSObject("100"));
            // coll.Add(new System.Management.Automation.PSObject("2"));
            // coll.Add(new System.Management.Automation.PSObject("1"));
            // coll.Add(new System.Management.Automation.PSObject("1"));
            // coll.Add(new System.Management.Automation.PSObject("1"));
            // coll.Add(null);
            // 
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 300; " +
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 500; " +
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 100; " +
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"sleep -Milliseconds 50; " +
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"sleep -Milliseconds 700; " +
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1000; " +
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"sleep -Milliseconds 200; " +
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderByDateTime -Descending | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByTimeSpent parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_OrderByTimeSpent_Numeric()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				null,
				new System.Management.Automation.PSObject("2"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("100")
			};
            //
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 300; " +
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 500; " +
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 100; " +
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"sleep -Milliseconds 50; " +
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"sleep -Milliseconds 700; " +
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1000; " +
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"sleep -Milliseconds 200; " +
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderByTimeSpent | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByTimeSpent and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_OrderByTimeSpent_Descending_Numeric()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("100"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("1"),
				new System.Management.Automation.PSObject("2"),
				null
			};
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 300; " +
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 500; " +
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr1' -Id 1 -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 100; " +
                @"$null = Close-TmxTestResult -Name 'tr2' -Id 1 -TestPassed; " + 
                @"sleep -Milliseconds 50; " +
                @"$null = Close-TmxTestResult -Name 'tr3' -Id 2 -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"sleep -Milliseconds 700; " +
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1000; " +
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + // ????
                @"sleep -Milliseconds 200; " +
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Close-TmxTestResult -Name 'tr4' -Id 100 -TestPassed; " + 
                @"Search-TmxTestResult -OrderByTimeSpent -Descending | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterNameContains parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_FilterNameContains()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("tr 01"),
				new System.Management.Automation.PSObject("tr 02"),
				new System.Management.Automation.PSObject("tr 02"),
				new System.Management.Automation.PSObject("tr 02")
			};
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 01' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario5; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"Search-TmxTestResult -FilterNameContains '0' | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterNameContains and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_FilterNameContains_Descending()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("tr 02"),
				new System.Management.Automation.PSObject("tr 02"),
				new System.Management.Automation.PSObject("tr 02"),
				new System.Management.Automation.PSObject("tr 01")
			};
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario3; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 01' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = Close-TmxTestResult -Name 'tr 1' -KnownIssue; " + 
                @"$null = Close-TmxTestResult -Name 'tr 02' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario5; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"Search-TmxTestResult -FilterNameContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterIdContains parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_FilterIdContains()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("a"),
				new System.Management.Automation.PSObject("test result`r`n%% 2")
			};
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 1' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 2' -Id 01 -TestPassed; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 3' -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'a' -Id '003' -TestPassed; " + 
                @"Search-TmxTestResult -FilterIdContains '0' | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterIdContains and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_FilterIdContains_Descending()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("test result`r`n%% 2"),
				new System.Management.Automation.PSObject("a")
			};
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 1' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 2' -Id 01 -TestPassed; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 3' -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'a' -Id '003' -TestPassed; " + 
                @"Search-TmxTestResult -FilterIdContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterDescriptionContains parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_FilterDescriptionContains()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("test result`r`n%% 1"),
				new System.Management.Automation.PSObject("test result`r`n%% 3")
			};
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 1' -Description 'abc' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 2' -Id 01 -TestPassed; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 3' -Description 'cab' -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'a' -Id '003' -Description 'ccc' -TestPassed; " + 
                @"Search-TmxTestResult -FilterDescriptionContains 'ab' | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterDescriptionContains and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultLevel")]
        [MbUnit.Framework.Category("Search_TmxTestResult")]
        public void TestPrm_FilterDescriptionContains_Descending()
        {
			var coll = new Collection<System.Management.Automation.PSObject>() {
				new System.Management.Automation.PSObject("test result`r`n%% 1"),
				new System.Management.Automation.PSObject("test result`r`n%% 3")
			};
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 1' -Description 'abc' -TestPassed; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 2' -Id 01 -TestPassed; " + 
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'detail 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`5  5'; " + 
                @"$null = Close-TmxTestResult -Name 'test result`r`n%% 3' -Description 'cab' -TestPassed; " + 
                @"$null = Close-TmxTestResult -Name 'a' -Id '003' -Description 'ccc' -TestPassed; " + 
                @"Search-TmxTestResult -FilterDescriptionContains 'ab' -Descending | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
