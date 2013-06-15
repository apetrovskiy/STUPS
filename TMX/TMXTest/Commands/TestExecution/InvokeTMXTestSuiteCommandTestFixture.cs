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
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_NoParameters()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty( //.RunAndEvaluateAreEqual(
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
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '1' | Out-Host; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ",
                string.Empty);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '1' | Out-Host; },{ '2' | Out-Host; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ",
                string.Empty);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_AfterScenario()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '3' | Out-Host; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ",
                string.Empty);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -AfterScenario { '3' | Out-Host; },{ '4' | Out-Host; }; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ",
                string.Empty);
        }
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestSuite")]
        public void NewTestSuite_NoScenarios_BeforeScenarioX2_AfterScenarioX2()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite 'suite01' -Id 001 -BeforeScenario { '1' | Out-Host; },{ '2' | Out-Host; } " +
                @"-AfterScenario { '3' | Out-Host; },{ '4' | Out-Host; }; " +
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001; " +
                @"Invoke-TMXTestSuite -Id 001; ",
                string.Empty);
        }
    }
}

/*
$null = New-TMXTestSuite "suite01" -Id 001 -BeforeScenario { "1111"; },{ "before scenario script"; } -AfterScenario { "2222"; },{ "after scenario script"; }; # -Verbose;
$null = Add-TMXTestScenario "sc001" -Id 0001 -BeforeTest { "before test script"; } -AfterTest { "after test script"; } -Verbose;
Invoke-TMXTestSuite -Id 001; # -Verbose;
*/