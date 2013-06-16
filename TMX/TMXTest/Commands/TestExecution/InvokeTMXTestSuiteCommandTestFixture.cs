/*
 * Created by SharpDevelop.
 * User: Alexander
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
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '01' | Out-Host; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '01' | Out-Host; },{ '02' | Out-Host; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '03' | Out-Host; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '03' | Out-Host; },{ '04' | Out-Host; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '01' | Out-Host; },{ '02' | Out-Host; } " +
                @"-AfterScenario { '03' | Out-Host; },{ '04' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        // ====================================================================================================
        // ==================================== one scenario, no test cases ===================================
        // ====================================================================================================
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_BeforeTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { '11' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_BeforeTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { '11' | Out-Host; },{ '12' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_AfterTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -AfterTest { '13' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -AfterTest { '13' | Out-Host; },{ '14' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_BeforeTestX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { '11' | Out-Host; },{ '12' | Out-Host; } " +
                @"-AfterTest { '13' | Out-Host; },{ '14' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
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
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '01' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenario_BeforeTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '01' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { '11' | Out-Host; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenarioX2_BeforeTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '01' | Out-Host; },{ '02' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { '11' | Out-Host; },{ '12' | Out-Host; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '03' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenario_AfterTest()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '03' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -AfterTest { '13' | Out-Host; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_AfterScenarioX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '03' | Out-Host; },{ '04' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -AfterTest { '13' | Out-Host; },{ '14' | Out-Host; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_OneScenario_OneTestCase_BeforeScenarioX2_BeforeTestX2_AfterScenarioX2_AfterTestX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '01' | Out-Host; },{ '02' | Out-Host; } " +
                @"-AfterScenario { '03' | Out-Host; },{ '04' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { '11' | Out-Host; },{ '12' | Out-Host; } " +
                @"-AfterTest { '13' | Out-Host; },{ '14' | Out-Host; }; " +
                @"$null = Add-TMXTestCase -TestCaseName 'tc01' -Id 00001 -TestCode { '21' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
        
        // ====================================================================================================
        // ==================================== two scenarios, test cases =====================================
        // ====================================================================================================
        
        
        
        // ====================================================================================================
        // ====================================================================================================
        // ====================================================================================================
    }
}
