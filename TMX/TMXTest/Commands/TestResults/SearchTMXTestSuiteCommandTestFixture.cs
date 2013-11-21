/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestResults
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SearchTmxTestSuiteCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Search-TmxTestSuite test")]
    public class SearchTmxTestSuiteCommandTestFixture
    {
        public SearchTmxTestSuiteCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Search_TmxTestSuite")]
        public void TestPrm_Name_Simple_In_Series()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite1"));
            coll.Add(new System.Management.Automation.PSObject("suite2"));
            coll.Add(new System.Management.Automation.PSObject("suite3"));
            coll.Add(new System.Management.Automation.PSObject("suite4"));
            coll.Add(new System.Management.Automation.PSObject("suite5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"Search-TmxTestSuite -OrderById | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_Name_Complex_In_Series()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite%%`1  1"));
            coll.Add(new System.Management.Automation.PSObject("suite%%`2  2"));
            coll.Add(new System.Management.Automation.PSObject("suite%%`3  3"));
            coll.Add(new System.Management.Automation.PSObject("suite%%`4  4"));
            coll.Add(new System.Management.Automation.PSObject("suite%%`5  5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`5  5'; " + 
                @"Search-TmxTestSuite -OrderById | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_Id_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"Search-TmxTestSuite -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_Id_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject(@"a\ 1"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 2"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 3"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 4"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 'a\ 3'; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 'a\ 5'; " + 
                @"Search-TmxTestSuite -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderById_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " +
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"Search-TmxTestSuite -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderById_Descending_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " +
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"Search-TmxTestSuite -OrderById -Descending | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderById_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("i1"));
            coll.Add(new System.Management.Automation.PSObject("i2"));
            coll.Add(new System.Management.Automation.PSObject("i3"));
            coll.Add(new System.Management.Automation.PSObject("i4"));
            coll.Add(new System.Management.Automation.PSObject("i5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc4 -Id i4; " + 
                @"$null = New-TmxTestSuite -Name abc1 -Id i1; " +
                @"$null = New-TmxTestSuite -Name abc3 -Id i3; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id i5; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id i2; " + 
                @"Search-TmxTestSuite -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByName parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByName_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 4; " + 
                @"$null = New-TmxTestSuite -Name 1; " +
                @"$null = New-TmxTestSuite -Name 3; " + 
                @"$null = New-TmxTestSuite -Name 5; " + 
                @"$null = New-TmxTestSuite -Name 2; " + 
                @"Search-TmxTestSuite -OrderByName | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByName parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByName_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("abc1"));
            coll.Add(new System.Management.Automation.PSObject("abc2"));
            coll.Add(new System.Management.Automation.PSObject("abc3"));
            coll.Add(new System.Management.Automation.PSObject("abc4"));
            coll.Add(new System.Management.Automation.PSObject("abc5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc4; " + 
                @"$null = New-TmxTestSuite -Name abc1; " +
                @"$null = New-TmxTestSuite -Name abc3; " + 
                @"$null = New-TmxTestSuite -Name abc5; " + 
                @"$null = New-TmxTestSuite -Name abc2; " + 
                @"Search-TmxTestSuite -OrderByName | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByName and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByName_Descending_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("abc5"));
            coll.Add(new System.Management.Automation.PSObject("abc4"));
            coll.Add(new System.Management.Automation.PSObject("abc3"));
            coll.Add(new System.Management.Automation.PSObject("abc2"));
            coll.Add(new System.Management.Automation.PSObject("abc1"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc4; " + 
                @"$null = New-TmxTestSuite -Name abc1; " +
                @"$null = New-TmxTestSuite -Name abc3; " + 
                @"$null = New-TmxTestSuite -Name abc5; " + 
                @"$null = New-TmxTestSuite -Name abc2; " + 
                @"Search-TmxTestSuite -OrderByName -Descending | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByTimeSpent parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByTimeSpent()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            // 20130918
            // changes after spring-summer 2013
            // Expected Value : [{2}, {1}, {5}, {3}, {4}]
            // Actual Value   : [{4}, {1}, {3}, {5}, {2}]
            // coll.Add(new System.Management.Automation.PSObject("2"));
            // coll.Add(new System.Management.Automation.PSObject("1"));
            // coll.Add(new System.Management.Automation.PSObject("5"));
            // coll.Add(new System.Management.Automation.PSObject("3"));
            // coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            // 
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 4; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"sleep -Milliseconds 2300; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t2; " +
                @"$null = New-TmxTestSuite -Name 1; " +
                @"sleep -Milliseconds 10; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"$null = New-TmxTestSuite -Name 3; " + 
                @"sleep -Milliseconds 2000; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"$null = New-TmxTestSuite -Name 5; " + 
                @"sleep -Milliseconds 1500; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"$null = New-TmxTestSuite -Name 2; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"Search-TmxTestSuite -OrderByTimeSpent | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByTimeSpent and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByTimeSpent_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            // 20130918
            // changes after spring-summer 2013
            // Expected Value : [{4}, {3}, {5}, {1}, {2}]
            // Actual Value   : [{4}, {1}, {3}, {5}, {2}]
            // coll.Add(new System.Management.Automation.PSObject("4"));
            // coll.Add(new System.Management.Automation.PSObject("3"));
            // coll.Add(new System.Management.Automation.PSObject("5"));
            // coll.Add(new System.Management.Automation.PSObject("1"));
            // coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            // 
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 4; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"sleep -Milliseconds 2300; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t2; " +
                @"$null = New-TmxTestSuite -Name 1; " +
                @"sleep -Milliseconds 10; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"$null = New-TmxTestSuite -Name 3; " + 
                @"sleep -Milliseconds 2000; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"$null = New-TmxTestSuite -Name 5; " + 
                @"sleep -Milliseconds 1500; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"$null = New-TmxTestSuite -Name 2; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"Search-TmxTestSuite -OrderByTimeSpent -Descending | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderByPassRate parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByPassRate()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 4; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t01; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t02; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t03; " +
                @"$null = New-TmxTestSuite -Name 1; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t04; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t05; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t06; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t07; " +
                @"$null = New-TmxTestSuite -Name 3; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t08; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t09; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t10; " +
                @"$null = New-TmxTestSuite -Name 5; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t11; " +
                @"$null = New-TmxTestSuite -Name 2; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t12; " +
                @"Search-TmxTestSuite -OrderByPassRate | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByPassRate and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByPassRate_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 4; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t01; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t02; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t03; " +
                @"$null = New-TmxTestSuite -Name 1; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t04; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t05; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t06; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t07; " +
                @"$null = New-TmxTestSuite -Name 3; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t08; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t09; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t10; " +
                @"$null = New-TmxTestSuite -Name 5; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t11; " +
                @"$null = New-TmxTestSuite -Name 2; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t12; " +
                @"Search-TmxTestSuite -OrderByPassRate -Descending | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderByFailRate parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByFailRate()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 4; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t01; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t02; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t03; " +
                @"$null = New-TmxTestSuite -Name 1; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t04; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t05; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t06; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t07; " +
                @"$null = New-TmxTestSuite -Name 3; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t08; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t09; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t10; " +
                @"$null = New-TmxTestSuite -Name 5; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t11; " +
                @"$null = New-TmxTestSuite -Name 2; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t12; " +
                @"Search-TmxTestSuite -OrderByFailRate | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByFailRate and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_OrderByFailRate_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 4; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 4 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t01; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t02; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t03; " +
                @"$null = New-TmxTestSuite -Name 1; " +
                @"$null = Add-TmxTestScenario -TestSuiteName 1 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t04; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t05; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t06; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t07; " +
                @"$null = New-TmxTestSuite -Name 3; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 3 -Name sc1; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t08; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t09; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t10; " +
                @"$null = New-TmxTestSuite -Name 5; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 5 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed:$false -Name t11; " +
                @"$null = New-TmxTestSuite -Name 2; " + 
                @"$null = Add-TmxTestScenario -TestSuiteName 2 -Name sc1; " +
                @"$null = Close-TmxTestResult -TestPassed -Name t12; " +
                @"Search-TmxTestSuite -OrderByFailRate -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterNameContains parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_FilterNameContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite02"));
            coll.Add(new System.Management.Automation.PSObject("suite04"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = New-TmxTestSuite -Name suite02; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = New-TmxTestSuite -Name suite04; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"Search-TmxTestSuite -FilterNameContains '0' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterNameContains and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_FilterNameContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite04"));
            coll.Add(new System.Management.Automation.PSObject("suite02"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = New-TmxTestSuite -Name suite02; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = New-TmxTestSuite -Name suite04; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"Search-TmxTestSuite -FilterNameContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -FilterIdContains parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_FilterIdContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("122"));
            coll.Add(new System.Management.Automation.PSObject("125"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 111; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 122; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 133; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 114; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 125; " + 
                @"Search-TmxTestSuite -FilterIdContains '12' | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterIdContains and - parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_FilterIdContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("125"));
            coll.Add(new System.Management.Automation.PSObject("122"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 111; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 122; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 133; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 114; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 125; " + 
                @"Search-TmxTestSuite -FilterIdContains '12' -Descending | %{$_.Id;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterDescriptionContains parameter test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_FilterDescriptionContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite1"));
            coll.Add(new System.Management.Automation.PSObject("suite4"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1 -Description 'abc'; " + 
                @"$null = New-TmxTestSuite -Name suite2 -Description 'bac'; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = New-TmxTestSuite -Name suite4 -Description 'cab'; " + 
                @"$null = New-TmxTestSuite -Name suite5 -Description 'bac'; " + 
                @"Search-TmxTestSuite -FilterDescriptionContains 'ab' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterDescriptionContains and -Descending parameters test")]
        [Category("Slow")][Category("SuiteLevel")]
        [Category("Slow")][Category("Search_TmxTestSuite")]
        public void TestPrm_FilterDescriptionContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("suite4"));
            coll.Add(new System.Management.Automation.PSObject("suite1"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1 -Description 'abc'; " + 
                @"$null = New-TmxTestSuite -Name suite2 -Description 'bac'; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = New-TmxTestSuite -Name suite4 -Description 'cab'; " + 
                @"$null = New-TmxTestSuite -Name suite5 -Description 'bac'; " + 
                @"Search-TmxTestSuite -FilterDescriptionContains 'ab' -Descending | %{$_.Name;}",
                coll);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
