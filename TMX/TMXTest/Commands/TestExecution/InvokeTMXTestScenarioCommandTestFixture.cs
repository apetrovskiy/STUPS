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
        
        [Test]
        [Category("Slow")]
        [Category("SuiteLevel")]
        [Category("Invoke-TMXTestScenario")]
        public void AddTestScenario_1()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsEmpty( //.RunAndEvaluateAreEqual(
                @"$null = New-TMXTestSuite 'suite01' -Id 001; " + 
                @"$null = Add-TMXTestScenario 'sc001' -Id 0001 -BeforeTest { '1' | Out-Host; } -AfterTest { '2' | Out-Host; }; " +
                @"Invoke-TMXTestSuite -Id 001; ");
        }
    }
}
