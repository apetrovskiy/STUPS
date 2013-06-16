/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 9:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestExecution
{
    using System;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of InvokeTMXTestScenarioCommandTestFixture.
    /// </summary>
    public class InvokeTMXTestScenarioCommandTestFixture
    {
        public InvokeTMXTestScenarioCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        // ====================================================================================================
        // ==================================== one scenario, no test cases ===================================
        // ====================================================================================================
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_NoTestCases_NoScriptblocks_1()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                "");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_NoTestCases_NoScriptblocks_2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                "");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_NoTestCases_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_NoTestCases_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_NoTestCases_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_NoTestCases_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_NoTestCases_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        // ====================================================================================================
        // =================================== one scenario, one test case ====================================
        // ====================================================================================================
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_OneTestCase_NoScriptblocks_1()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001; " +
                @"Invoke-TMXTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_OneTestCase_NoScriptblocks_2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "21");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_OneTestCase_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "0121");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_OneTestCase_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "010221");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_OneTestCase_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "2103");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_OneTestCase_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "210304");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_OneTestCase_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "0102210304");
        }
        
        [Test]
        [Category("Slow")]
        [Category("ScenarioLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_OneTestCase_BeforeScenarioX2_AfterScenarioX2_Param()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { param($a,$b,$c) $global:result += '11' + $a + $b + $c; },{ param($a,$b,$c) $global:result += '12' + $a + $b + $c; } " +
                @"-AfterTest { param($d,$e,$f) $global:result += '13' + $d + $e + $f; },{ param($d,$e,$f) $global:result += '14' + $d + $e + $f; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestScenario -Id 0001 -BeforeTestParameters @('a','b','c') -AfterTestParameters @('d','e','f'); " + 
                @"[string]$global:result; ",
                "010211abc12abc2113def14def0304");
        }
        
        // ====================================================================================================
        // ================================== one scenario, three test cases ==================================
        // ====================================================================================================
    }
}
