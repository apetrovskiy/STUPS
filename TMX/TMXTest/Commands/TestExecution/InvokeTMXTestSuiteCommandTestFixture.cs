/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/15/2013
 * Time: 9:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestExecution
{
    using System;
    using MbUnit.Framework;
    
    /// <summary>
    /// Description of InvokeTMXTestSuiteCommandTestFixture.
    /// </summary>
    public class InvokeTMXTestSuiteCommandTestFixture
    {
        public InvokeTMXTestSuiteCommandTestFixture()
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
        // ==================================== no scenarios , no test cases ==================================
        // ====================================================================================================
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "01");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "0102");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "03");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "0304");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "01020304");
        }
        
        // ====================================================================================================
        // ==================================== one scenario, no test cases ===================================
        // ====================================================================================================
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_BeforeTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "11");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_BeforeTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; },{ $global:result += '12'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "1112");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_AfterTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -AfterTest { $global:result += '13'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "13");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "1314");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_NoTestCases_BeforeTestX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; },{ $global:result += '12'; } " +
                @"-AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                ""); // as there are no test cases "11121314");
        }
        
        
        // ====================================================================================================
        // ===================================== one scenario, test cases =====================================
        // ====================================================================================================
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "21");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "0121");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenario_BeforeTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "011121");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenarioX2_BeforeTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; },{ $global:result += '12'; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "0102111221");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "2103");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenario_AfterTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -AfterTest { $global:result += '13'; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "211303");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenarioX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "2113140304");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenarioX2_BeforeTestX2_AfterScenarioX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { $global:result += '11'; },{ $global:result += '12'; } " +
                @"-AfterTest { $global:result += '13'; },{ $global:result += '14'; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { $global:result += '21'; }; " +
                @"Invoke-TMXTestSuite -Id 001; " + 
                @"[string]$global:result; ",
                "010211122113140304");
        }
        
        // ====================================================================================================
        // ==================================== two scenarios, test cases =====================================
        // ====================================================================================================
        
        
        
        // ====================================================================================================
        // ====================================================================================================
        // ====================================================================================================
    }
}
