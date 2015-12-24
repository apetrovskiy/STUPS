/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 9:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestExecution
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of InvokeTmxTestScenarioCommandTestFixture.
    /// </summary>
    public class InvokeTmxTestScenarioCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        // ====================================================================================================
        // ==================================== one scenario, no test cases ===================================
        // ====================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_NoTestCases_NoScriptblocks_1()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_NoTestCases_NoScriptblocks_2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_NoTestCases_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_NoTestCases_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_NoTestCases_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_NoTestCases_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_NoTestCases_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestScenario -Id 0001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        // ====================================================================================================
        // =================================== one scenario, one test case ====================================
        // ====================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_OneTestCase_NoScriptblocks_1()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001; " +
                @"Invoke-TmxTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_OneTestCase_NoScriptblocks_2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "21");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_OneTestCase_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "0121");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_OneTestCase_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "010221");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_OneTestCase_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "2103");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_OneTestCase_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "210304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_OneTestCase_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestScenario -Id 0001; " +
                @"[string]$global:result; ",
                "0102210304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ScenarioLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestScenario")]
        public void AddTestScenario_OneTestCase_BeforeScenarioX2_AfterScenarioX2_Param()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { param($a,$b,$c) $global:result += '11' + $a + $b + $c; },{ param($a,$b,$c) $global:result += '12' + $a + $b + $c; } " +
                @"-AfterTest { param($d,$e,$f) $global:result += '13' + $d + $e + $f; },{ param($d,$e,$f) $global:result += '14' + $d + $e + $f; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestScenario -Id 0001 -BeforeTestParameters @('a','b','c') -AfterTestParameters @('d','e','f'); " + 
                @"[string]$global:result; ",
                "010211abc12abc2113def14def0304");
        }
        
        // ====================================================================================================
        // ================================== one scenario, three test cases ==================================
        // ====================================================================================================
    }
}
