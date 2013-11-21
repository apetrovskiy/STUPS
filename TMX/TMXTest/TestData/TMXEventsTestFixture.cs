/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/4/2012
 * Time: 7:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.TestData
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of TmxEventsTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="123")]
    public class TmxEventsTestFixture
    {
        public TmxEventsTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        
//        public static event EventHandler TmxNewTestSuiteCreated;
//        public static event EventHandler TmxTestSuiteOpened;


        [Test] //[Test(Description="The TmxNewTestSuiteCreated event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TmxEvents_TmxNewTestSuiteCreated()
        {
            string name = "suite1";
            string eventName = @"""TmxNewTestSuiteCreated""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TmxTestSuite -Name '" + 
                name + 
                "'; " + 
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }
        
        [Test] //[Test(Description="The TmxTestSuiteOpened event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TmxEvents_TmxTestSuiteOpened()
        {
            string name = "suite1";
            string eventName = @"""TmxTestSuiteOpened""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TmxTestSuite -Name '" + 
                name + 
                "'; " + 
                @"$null = New-TmxTestSuite -Name 'aaa'; " + 
                @"$null = Open-TmxTestSuite -Name '" + 
                name +
                "'; " + 
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }
        
//        public static event EventHandler TmxNewTestScenarioAdded;
//        public static event EventHandler TmxTestScenarioOpened;

        [Test] //[Test(Description="The TmxNewTestScenarioAdded event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TmxEvents_TmxNewTestScenarioAdded()
        {
            string name = "scenario1";
            string eventName = @"""TmxNewTestScenarioAdded""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TmxTestSuite -Name 'aaaa'; " + 
                @"$null = Add-TmxTestScenario -Name '" +
                name + 
                @"'; " +
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }
        
        [Test] //[Test(Description="The TmxTestScenarioOpened event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TmxEvents_TmxTestScenarioOpened()
        {
            string name = "scenario1";
            string eventName = @"""TmxTestScenarioOpened""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TmxTestSuite -Name 'aaaa'; " + 
                @"$null = Add-TmxTestScenario -Name '" +
                name + 
                @"'; " +
                @"$null = Add-TmxTestScenario -Name 'aaaaa'; " +
                @"$null = Open-TmxTestScenario -Name '" + 
                name + 
                @"'; " +
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }

//        public static event EventHandler TmxNewTestResultClosed;
//        public static event EventHandler TmxNewTestResultDetailAdded;


        [Test] //[Test(Description="The TmxNewTestResultDetailAdded event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TmxEvents_TmxNewTestResultDetailAdded()
        {
            string name = "res1";
            string eventName = @"""TmxNewTestResultDetailAdded""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TmxTestSuite -Name 'aaaa'; " + 
                @"$null = Add-TmxTestScenario -Name 'bbbb'; " +
                @"$null = Add-TmxTestResultDetail -TestResultDetail '" + 
                name +
                @"'; " +
                @"sleep -Seconds 2; " + 
                @"$global:name;",
                name);
        }
        
        [Test] //[Test(Description="The TmxNewTestResultClosed event")]
        [Category("Slow")]
        [Category("TMX_Events")]
        public void TmxEvents_TmxNewTestResultClosed()
        {
            string name = "res1";
            string eventName = @"""TmxNewTestResultClosed""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$global:name = ''; " +
                @"$null = Register-ObjectEvent -InputObject $([TMX.TestData]) " + 
                @"-EventName " + 
                eventName +
                @" -Action {param($src, $e) $global:name = $src.Name;}; " +
                @"$null = New-TmxTestSuite -Name 'aaaa'; " + 
                @"$null = Add-TmxTestScenario -Name 'bbbb'; " +
                @"$null = Add-TmxTestResultDetail -TestResultDetail 'cccc'; " +
                @"$null = Close-TmxTestResult -Name '" +
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
