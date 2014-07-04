/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 9:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestExecution
{
    using System;
    using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of InvokeTmxTestSuiteCommandTestFixture.
    /// </summary>
    public class InvokeTmxTestSuiteCommandTestFixture
    {
        public InvokeTmxTestSuiteCommandTestFixture()
        {
        }
        
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
        // ==================================== no scenarios , no test cases ==================================
        // ====================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_NoScenarios_NoScriptblocks()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "0102");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_NoScenarios_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "03");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_NoScenarios_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " + 
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "0304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01020304");
        }
        
        // ====================================================================================================
        // ==================================== one scenario, no test cases ===================================
        // ====================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_NoScriptblocks()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "0102");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "03");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " + 
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "0304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "01020304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_BeforeTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "11");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_BeforeTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; },{ $global:result += '12'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "1112");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_AfterTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -AfterTest { $global:result += '13'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "13");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "1314");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_BeforeTestX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; },{ $global:result += '12'; } " +
                @"-AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "11121314");
        }
        
        // ====================================================================================================
        // =================================== one scenario, one test case ====================================
        // ====================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_NoScriptblocks_1()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_NoScriptblocks_2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "21");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "0121");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenario_BeforeTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "011121");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenarioX2_BeforeTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; },{ $global:result += '12'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "0102111221");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "2103");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenario_AfterTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -AfterTest { $global:result += '13'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "211303");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenarioX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "2113140304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenarioX2_BeforeTestX2_AfterScenarioX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; },{ $global:result += '12'; } " +
                @"-AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "010211122113140304");
        }
        
        // ====================================================================================================
        // ================================== one scenario, three test cases ==================================
        // ====================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_ThreeTestCases_BeforeScenarioX2_BeforeTestX2_AfterScenarioX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '_11'; },{ $global:result += '12'; } " +
                @"-AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"$null = Add-TmxTestCase 'tc02' -Id 00002 -TestCode { $global:result += '22'; }; " +
                @"$null = Add-TmxTestCase 'tc03' -Id 00003 -TestCode { $global:result += '23'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "0102_1112211314_1112221314_11122313140304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_OneScenario_ThreeTestCases_BeforeScenarioX2_BeforeTestX2_AfterScenarioX2_AfterTestX2_Param()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { param($a,$b,$c) $global:result += '01' + $a + $b + $c; },{ param($a,$b,$c) $global:result += '02' + $a + $b + $c; } " +
                @"-AfterScenario { param($d,$e,$f) $global:result += '03' + $d + $e + $f; },{ param($d,$e,$f) $global:result += '04' + $d + $e + $f; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '_11'; },{ $global:result += '12'; } " +
                @"-AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"$null = Add-TmxTestCase 'tc02' -Id 00002 -TestCode { $global:result += '22'; }; " +
                @"$null = Add-TmxTestCase 'tc03' -Id 00003 -TestCode { $global:result += '23'; }; " +
                @"Invoke-TmxTestSuite -Id 001 -BeforeScenarioParameters @('a','b','c') -AfterScenarioParameters @('d','e','f'); " + 
                @"[string]$global:result; ",
                "01abc02abc_1112211314_1112221314_111223131403def04def");
        }
        
        // ====================================================================================================
        // ================================== two scenarios, six test cases ===================================
        // ====================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_TwoScenarios_SixTestCases_BeforeScenarioX2_BeforeTestX2_AfterScenarioX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '__01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '_03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '_11'; },{ $global:result += '12'; } " +
                @"-AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"$null = Add-TmxTestCase 'tc02' -Id 00002 -TestCode { $global:result += '22'; }; " +
                @"$null = Add-TmxTestCase 'tc03' -Id 00003 -TestCode { $global:result += '23'; }; " +
                //
                @"$null = Add-TmxTestScenario 'sc002' -Id 0002 -BeforeTest { $global:result += '_31'; },{ $global:result += '32'; } " +
                @"-AfterTest { $global:result += '33'; },{ $global:result += '34'; }; " +
                @"$null = Add-TmxTestCase 'tc04' -Id 00004 -TestCode { $global:result += '41'; }; " +
                @"$null = Add-TmxTestCase 'tc05' -Id 00005 -TestCode { $global:result += '42'; }; " +
                @"$null = Add-TmxTestCase 'tc06' -Id 00006 -TestCode { $global:result += '43'; }; " +
                @"Invoke-TmxTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "__0102_1112211314_1112221314_1112231314_0304__0102_3132413334_3132423334_3132433334_0304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("SuiteLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestSuite")]
        public void NewTestSuite_TwoScenarios_SixTestCases_BeforeScenarioX2_BeforeTestX2_AfterScenarioX2_AfterTestX2_Param()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { param($a,$b,$c) $global:result += '__01' + $a + $b + $c; },{ param($a,$b,$c) $global:result += '02' + $a + $b + $c; } " +
                @"-AfterScenario { param($d,$e,$f) $global:result += '_03' + $d + $e + $f; },{ param($d,$e,$f) $global:result += '04' + $d + $e + $f; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '_11'; },{ $global:result += '12'; } " +
                @"-AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"$null = Add-TmxTestCase 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"$null = Add-TmxTestCase 'tc02' -Id 00002 -TestCode { $global:result += '22'; }; " +
                @"$null = Add-TmxTestCase 'tc03' -Id 00003 -TestCode { $global:result += '23'; }; " +
                //
                @"$null = Add-TmxTestScenario 'sc002' -Id 0002 -BeforeTest { $global:result += '_31'; },{ $global:result += '32'; } " +
                @"-AfterTest { $global:result += '33'; },{ $global:result += '34'; }; " +
                @"$null = Add-TmxTestCase 'tc04' -Id 00004 -TestCode { $global:result += '41'; }; " +
                @"$null = Add-TmxTestCase 'tc05' -Id 00005 -TestCode { $global:result += '42'; }; " +
                @"$null = Add-TmxTestCase 'tc06' -Id 00006 -TestCode { $global:result += '43'; }; " +
                @"Invoke-TmxTestSuite -Id 001 -BeforeScenarioParameters @('a','b','c') -AfterScenarioParameters @('d','e','f'); " + 
                @"[string]$global:result; ",
                "__01abc02abc_1112211314_1112221314_1112231314_03def04def__01abc02abc_3132413334_3132423334_3132433334_03def04def");
        }
        
        // ====================================================================================================
        // ====================================================================================================
        // ====================================================================================================
    }
}
