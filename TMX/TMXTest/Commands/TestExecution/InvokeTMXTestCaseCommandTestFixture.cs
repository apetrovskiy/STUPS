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
    /// Description of InvokeTmxTestCaseCommandTestFixture.
    /// </summary>
    public class InvokeTmxTestCaseCommandTestFixture
    {
        public InvokeTmxTestCaseCommandTestFixture()
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
        // =========================================== one test case =========================================
        // ====================================================================================================
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestCaseLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestCase")]
        public void AddTestCase_NoScriptblocks_1()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc0001' -Id 00001; " +
                @"Invoke-TmxTestCase -Id 00001; " +
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestCaseLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestCase")]
        public void AddTestCase_NoScriptblocks_2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc0001' -Id 00001; " +
                @"Invoke-TmxTestCase -Id 00001; " +
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestCaseLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestCase")]
        public void AddTestCase_NoScriptblocks_3()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = Add-TmxTestCase 'tc0001' -Id 00001; " +
                @"Invoke-TmxTestCase -Id 00001; " +
                @"[string]$global:result; ",
                "");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestCaseLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestCase")]
        public void AddTestCase_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc0001' -Id 00001; " +
                @"Invoke-TmxTestCase -Id 00001; " +
                @"[string]$global:result; ",
                "01");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestCaseLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestCase")]
        public void AddTestCase_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc0001' -Id 00001; " +
                @"Invoke-TmxTestCase -Id 00001; " +
                @"[string]$global:result; ",
                "0102");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestCaseLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestCase")]
        public void AddTestCase_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc0001' -Id 00001; " +
                @"Invoke-TmxTestCase -Id 00001; " +
                @"[string]$global:result; ",
                "03");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestCaseLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestCase")]
        public void AddTestCase_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc0001' -Id 00001; " +
                @"Invoke-TmxTestCase -Id 00001; " +
                @"[string]$global:result; ",
                "0304");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestCaseLevel")]
        [MbUnit.Framework.Category("Invoke-TmxTestCase")]
        public void AddTestCase_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:result = ''; " +
                // 20130912
                //@"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; }; " +
                @"$null = New-TmxTestSuite 'suite01' -Id 001 -BeforeScenario { $global:result += '01'; },{ $global:result += '02'; } " +
                @"-AfterScenario { $global:result += '03'; },{ $global:result += '04'; }; " +
                @"$null = Add-TmxTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TmxTestCase 'tc0001' -Id 00001; " +
                @"Invoke-TmxTestCase -Id 00001; " +
                @"[string]$global:result; ",
                "01020304");
        }
    }
}
