/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/4/2012
 * Time: 7:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.TestData
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of TMXEventsTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="123")]
    public class TMXEventsTestFixture
    {
        public TMXEventsTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        
//        public static event EventHandler TMXNewTestSuiteCreated;
//        public static event EventHandler TMXTestSuiteOpened;


        [Test] //[Test(Description="The TMXNewTestSuiteCreated event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TMXEvents_TMXNewTestSuiteCreated()
        {
            string name = "suite1";
            string eventName = @"""TMXNewTestSuiteCreated""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TMXTestSuite -Name '" + 
                name + 
                "'; " + 
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }
        
        [Test] //[Test(Description="The TMXTestSuiteOpened event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TMXEvents_TMXTestSuiteOpened()
        {
            string name = "suite1";
            string eventName = @"""TMXTestSuiteOpened""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TMXTestSuite -Name '" + 
                name + 
                "'; " + 
                @"$null = New-TMXTestSuite -Name 'aaa'; " + 
                @"$null = Open-TMXTestSuite -Name '" + 
                name +
                "'; " + 
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }
        
//        public static event EventHandler TMXNewTestScenarioAdded;
//        public static event EventHandler TMXTestScenarioOpened;

        [Test] //[Test(Description="The TMXNewTestScenarioAdded event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TMXEvents_TMXNewTestScenarioAdded()
        {
            string name = "scenario1";
            string eventName = @"""TMXNewTestScenarioAdded""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TMXTestSuite -Name 'aaaa'; " + 
                @"$null = Add-TMXTestScenario -Name '" +
                name + 
                @"'; " +
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }
        
        [Test] //[Test(Description="The TMXTestScenarioOpened event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TMXEvents_TMXTestScenarioOpened()
        {
            string name = "scenario1";
            string eventName = @"""TMXTestScenarioOpened""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TMXTestSuite -Name 'aaaa'; " + 
                @"$null = Add-TMXTestScenario -Name '" +
                name + 
                @"'; " +
                @"$null = Add-TMXTestScenario -Name 'aaaaa'; " +
                @"$null = Open-TMXTestScenario -Name '" + 
                name + 
                @"'; " +
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }

//        public static event EventHandler TMXNewTestResultClosed;
//        public static event EventHandler TMXNewTestResultDetailAdded;


        [Test] //[Test(Description="The TMXNewTestResultDetailAdded event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TMXEvents_TMXNewTestResultDetailAdded()
        {
            string name = "res1";
            string eventName = @"""TMXNewTestResultDetailAdded""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TMXTestSuite -Name 'aaaa'; " + 
                @"$null = Add-TMXTestScenario -Name 'bbbb'; " +
                @"$null = Add-TMXTestResultDetail -TestResultDetail '" + 
                name +
                @"'; " +
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }
        
        [Test] //[Test(Description="The TMXNewTestResultClosed event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TMXEvents_TMXNewTestResultClosed()
        {
            string name = "res1";
            string eventName = @"""TMXNewTestResultClosed""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TMXTestSuite -Name 'aaaa'; " + 
                @"$null = Add-TMXTestScenario -Name 'bbbb'; " +
                @"$null = Add-TMXTestResultDetail -TestResultDetail 'cccc'; " +
                @"$null = Close-TMXTestResult -Name '" +
                name +
                @"' -TestPassed; " +
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }

        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
