/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestResults
{
    using System;
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of SearchTmxTestScenarioCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Search-TmxTestScenario test")]
    public class SearchTmxTestScenarioCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_Name_Simple_In_Series()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario4"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario3"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario3; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario5; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"Search-TmxTestScenario -OrderById | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_Name_Complex_In_Series()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario`r`n%% 1"));
            coll.Add(new System.Management.Automation.PSObject("scenario`r`n%% 2"));
            coll.Add(new System.Management.Automation.PSObject("scenario`r`n%% 4"));
            coll.Add(new System.Management.Automation.PSObject("scenario`r`n%% 3"));
            coll.Add(new System.Management.Automation.PSObject("scenario`r`n%% 2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TmxTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TmxTestSuite -Name 'suite%%`5  5'; " + 
                @"Search-TmxTestScenario -OrderById | %{$_.Name;}",
                coll);
        }
        
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_Id_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("1"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 5; " + 
                @"Search-TmxTestScenario -OrderById | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_Id_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject(@"a\ 1"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 2"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 2"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 3"));
            coll.Add(new System.Management.Automation.PSObject(@"a\ 4"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 'a\ 1'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 'a\ 2'; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 'a\ 3'; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 'a\ 3'; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 'a\ 4'; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 'a\ 2'; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 'a\ 5'; " + 
                @"Search-TmxTestScenario -OrderById | %{$_.Id;}",
                coll);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById parameter test")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_OrderById_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("5"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 5; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 1; " + 
                @"Search-TmxTestScenario -OrderById | %{$_.Id;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderById and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_OrderById_Descending_Numeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("5"));
            coll.Add(new System.Management.Automation.PSObject("4"));
            coll.Add(new System.Management.Automation.PSObject("3"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            coll.Add(new System.Management.Automation.PSObject("2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 5; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 1; " + 
                @"Search-TmxTestScenario -OrderById -Descending | %{$_.Id;}",
                coll);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByName parameter test")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_OrderByName_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario3"));
            coll.Add(new System.Management.Automation.PSObject("scenario4"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 5; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 1; " + 
                @"Search-TmxTestScenario -OrderByName | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByName and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_OrderByName_Descending_Alphanumeric()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario4"));
            coll.Add(new System.Management.Automation.PSObject("scenario3"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 5; " + 
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TmxTestSuite -Name abc5 -Id 1; " + 
                @"Search-TmxTestScenario -OrderByName -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByTimeSpent parameter test")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_OrderByTimeSpent()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            // 20130918
            // changes after spring-summer 2013
            // Expected Value : [{scenario2}, {scenario3}, {scenario4}, {scenario2}, {scenario1}]
            // Actual Value   : [{scenario1}, {scenario2}, {scenario3}, {scenario4}, {scenario2}]
            // coll.Add(new System.Management.Automation.PSObject("scenario2"));
            // coll.Add(new System.Management.Automation.PSObject("scenario3"));
            // coll.Add(new System.Management.Automation.PSObject("scenario4"));
            // coll.Add(new System.Management.Automation.PSObject("scenario2"));
            // coll.Add(new System.Management.Automation.PSObject("scenario1"));
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario3"));
            coll.Add(new System.Management.Automation.PSObject("scenario4"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            // 
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 5; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"sleep -Milliseconds 2300; " +
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"sleep -Milliseconds 200; " +
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 600; " +
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"sleep -Milliseconds 10; " +
                @"$null = New-TmxTestSuite -Name abc5 -Id 1; " + 
                @"Search-TmxTestScenario -OrderByTimeSpent | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -OrderByTimeSpent and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_OrderByTimeSpent_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario3"));
            coll.Add(new System.Management.Automation.PSObject("scenario4"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 5; " + 
                @"$null = Close-TmxTestResult -TestPassed -Name t1; " +
                @"sleep -Milliseconds 2300; " +
                @"$null = New-TmxTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"sleep -Milliseconds 200; " +
                @"$null = Add-TmxTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 600; " +
                @"$null = New-TmxTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TmxTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 2; " + 
                @"sleep -Milliseconds 10; " +
                @"$null = New-TmxTestSuite -Name abc5 -Id 1; " + 
                @"Search-TmxTestScenario -OrderByTimeSpent -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterNameContains parameter test")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_FilterNameContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario02"));
            coll.Add(new System.Management.Automation.PSObject("scenario02"));
            coll.Add(new System.Management.Automation.PSObject("scenario05"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario02; " + 
                @"$null = Add-TmxTestScenario -Name scenario3; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4; " + 
                @"$null = Add-TmxTestScenario -Name scenario02; " + 
                @"$null = Add-TmxTestScenario -Name scenario05; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"Search-TmxTestScenario -FilterNameContains '0' | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterNameContains and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_FilterNameContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario05"));
            coll.Add(new System.Management.Automation.PSObject("scenario02"));
            coll.Add(new System.Management.Automation.PSObject("scenario02"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario02; " + 
                @"$null = Add-TmxTestScenario -Name scenario3; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4; " + 
                @"$null = Add-TmxTestScenario -Name scenario02; " + 
                @"$null = Add-TmxTestScenario -Name scenario05; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"Search-TmxTestScenario -FilterNameContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterIdContains parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_FilterIdContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 01; " + 
                @"$null = Add-TmxTestScenario -Name scenario3; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario5 -Id 01; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 3; " + 
                @"Search-TmxTestScenario -FilterIdContains '0' | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterIdContains and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_FilterIdContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Id 1; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 01; " + 
                @"$null = Add-TmxTestScenario -Name scenario3; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4 -Id 2; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario5 -Id 01; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Id 3; " + 
                @"Search-TmxTestScenario -FilterIdContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterDescriptionContains parameter test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_FilterDescriptionContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Description 'abc'; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Description 'bac'; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Description 'cab'; " + 
                @"$null = Add-TmxTestScenario -Name scenario5 -Description 'abab'; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Description ''; " + 
                @"Search-TmxTestScenario -FilterDescriptionContains 'ab' | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The work with the -FilterDescriptionContains and -Descending parameters test")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Search_TmxTestScenario")]
        public void TestPrm_FilterDescriptionContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TmxTestSuite -Name suite1; " + 
                @"$null = Add-TmxTestScenario -Name scenario1 -Description 'abc'; " + 
                @"$null = New-TmxTestSuite -Name suite2; " + 
                @"$null = New-TmxTestSuite -Name suite3; " + 
                @"$null = Add-TmxTestScenario -Name scenario2; " + 
                @"$null = Add-TmxTestScenario -Name scenario3 -Description 'bac'; " + 
                @"$null = New-TmxTestSuite -Name suite4; " + 
                @"$null = Add-TmxTestScenario -Name scenario4; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Description 'cab'; " + 
                @"$null = Add-TmxTestScenario -Name scenario5 -Description 'abab'; " + 
                @"$null = New-TmxTestSuite -Name suite5; " + 
                @"$null = Add-TmxTestScenario -Name scenario2 -Description ''; " + 
                @"Search-TmxTestScenario -FilterDescriptionContains 'ab' -Descending | %{$_.Name;}",
                coll);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
