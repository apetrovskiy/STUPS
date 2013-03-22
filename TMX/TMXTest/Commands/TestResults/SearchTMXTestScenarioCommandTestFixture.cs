/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestResults
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of SearchTMXTestScenarioCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Search-TMXTestScenario test")]
    public class SearchTMXTestScenarioCommandTestFixture
    {
        public SearchTMXTestScenarioCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario3; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario5; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"Search-TMXTestScenario -OrderById | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name 'suite%%`1  1'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 1'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`2  2'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 3'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`3  3'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`4  4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 4'; " + 
                @"$null = Add-TMXTestScenario -Name 'scenario`r`n%% 2'; " + 
                @"$null = New-TMXTestSuite -Name 'suite%%`5  5'; " + 
                @"Search-TMXTestScenario -OrderById | %{$_.Name;}",
                coll);
        }
        
        
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name abc1 -Id 1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 5; " + 
                @"Search-TMXTestScenario -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById parameter test, general testing")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name abc1 -Id 'a\ 1'; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 'a\ 1'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 'a\ 2'; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 'a\ 2'; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 'a\ 3'; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 'a\ 3'; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 'a\ 4'; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 'a\ 4'; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 'a\ 2'; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 'a\ 5'; " + 
                @"Search-TMXTestScenario -OrderById | %{$_.Id;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -OrderById parameter test")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 5; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 1; " + 
                @"Search-TMXTestScenario -OrderById | %{$_.Id;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderById and -Descending parameters test")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 5; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 1; " + 
                @"Search-TMXTestScenario -OrderById -Descending | %{$_.Id;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -OrderByName parameter test")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 5; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 1; " + 
                @"Search-TMXTestScenario -OrderByName | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByName and -Descending parameters test")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 5; " + 
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"$null = New-TMXTestSuite -Name abc5 -Id 1; " + 
                @"Search-TMXTestScenario -OrderByName -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -OrderByTimeSpent parameter test")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
        public void TestPrm_OrderByTimeSpent()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario3"));
            coll.Add(new System.Management.Automation.PSObject("scenario4"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 5; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"sleep -Milliseconds 2300; " +
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"sleep -Milliseconds 200; " +
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 600; " +
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"sleep -Milliseconds 10; " +
                @"$null = New-TMXTestSuite -Name abc5 -Id 1; " + 
                @"Search-TMXTestScenario -OrderByTimeSpent | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -OrderByTimeSpent and -Descending parameters test")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
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
                @"$null = New-TMXTestSuite -Name abc1 -Id 5; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 5; " + 
                @"$null = Close-TMXTestResult -TestPassed -Name t1; " +
                @"sleep -Milliseconds 2300; " +
                @"$null = New-TMXTestSuite -Name abc2 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"sleep -Milliseconds 200; " +
                @"$null = Add-TMXTestScenario -Name scenario3 -Id 3; " + 
                @"sleep -Milliseconds 600; " +
                @"$null = New-TMXTestSuite -Name abc3 -Id 3; " + 
                @"$null = New-TMXTestSuite -Name abc4 -Id 4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 4; " + 
                @"sleep -Milliseconds 1200; " +
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 2; " + 
                @"sleep -Milliseconds 10; " +
                @"$null = New-TMXTestSuite -Name abc5 -Id 1; " + 
                @"Search-TMXTestScenario -OrderByTimeSpent -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterNameContains parameter test")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
        public void TestPrm_FilterNameContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario02"));
            coll.Add(new System.Management.Automation.PSObject("scenario02"));
            coll.Add(new System.Management.Automation.PSObject("scenario05"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario02; " + 
                @"$null = Add-TMXTestScenario -Name scenario3; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4; " + 
                @"$null = Add-TMXTestScenario -Name scenario02; " + 
                @"$null = Add-TMXTestScenario -Name scenario05; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"Search-TMXTestScenario -FilterNameContains '0' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterNameContains and -Descending parameters test")]
        [Category("Slow")][Category("ScenarioLevel")]
        [Category("Slow")][Category("Search_TMXTestScenario")]
        public void TestPrm_FilterNameContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario05"));
            coll.Add(new System.Management.Automation.PSObject("scenario02"));
            coll.Add(new System.Management.Automation.PSObject("scenario02"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario02; " + 
                @"$null = Add-TMXTestScenario -Name scenario3; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4; " + 
                @"$null = Add-TMXTestScenario -Name scenario02; " + 
                @"$null = Add-TMXTestScenario -Name scenario05; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"Search-TMXTestScenario -FilterNameContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterIdContains parameter test")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Search_TMXTestScenario")]
        public void TestPrm_FilterIdContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 01; " + 
                @"$null = Add-TMXTestScenario -Name scenario3; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario5 -Id 01; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 3; " + 
                @"Search-TMXTestScenario -FilterIdContains '0' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterIdContains and -Descending parameters test")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Search_TMXTestScenario")]
        public void TestPrm_FilterIdContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Id 1; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 01; " + 
                @"$null = Add-TMXTestScenario -Name scenario3; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4 -Id 2; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario5 -Id 01; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Id 3; " + 
                @"Search-TMXTestScenario -FilterIdContains '0' -Descending | %{$_.Name;}",
                coll);
        }
        
        
        [Test] //[Test(Description="The work with the -FilterDescriptionContains parameter test")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Search_TMXTestScenario")]
        public void TestPrm_FilterDescriptionContains()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Description 'abc'; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Description 'bac'; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Description 'cab'; " + 
                @"$null = Add-TMXTestScenario -Name scenario5 -Description 'abab'; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Description ''; " + 
                @"Search-TMXTestScenario -FilterDescriptionContains 'ab' | %{$_.Name;}",
                coll);
        }
        
        [Test] //[Test(Description="The work with the -FilterDescriptionContains and -Descending parameters test")]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Search_TMXTestScenario")]
        public void TestPrm_FilterDescriptionContains_Descending()
        {
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> coll = 
                new System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>();
            coll.Add(new System.Management.Automation.PSObject("scenario5"));
            coll.Add(new System.Management.Automation.PSObject("scenario2"));
            coll.Add(new System.Management.Automation.PSObject("scenario1"));
            
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite -Name suite1; " + 
                @"$null = Add-TMXTestScenario -Name scenario1 -Description 'abc'; " + 
                @"$null = New-TMXTestSuite -Name suite2; " + 
                @"$null = New-TMXTestSuite -Name suite3; " + 
                @"$null = Add-TMXTestScenario -Name scenario2; " + 
                @"$null = Add-TMXTestScenario -Name scenario3 -Description 'bac'; " + 
                @"$null = New-TMXTestSuite -Name suite4; " + 
                @"$null = Add-TMXTestScenario -Name scenario4; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Description 'cab'; " + 
                @"$null = Add-TMXTestScenario -Name scenario5 -Description 'abab'; " + 
                @"$null = New-TMXTestSuite -Name suite5; " + 
                @"$null = Add-TMXTestScenario -Name scenario2 -Description ''; " + 
                @"Search-TMXTestScenario -FilterDescriptionContains 'ab' -Descending | %{$_.Name;}",
                coll);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
