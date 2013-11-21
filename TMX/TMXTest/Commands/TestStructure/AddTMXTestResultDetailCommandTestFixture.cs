/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.02.2012
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TmxTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework; // using MbUnit.Framework;
    
    /// <summary>
    /// Description of AddTmxTestResultDetailCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Add-TmxTestResultDetail test")]
    public class AddTmxTestResultDetailCommandTestFixture
    {
        public AddTmxTestResultDetailCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="The -TestResultDetail parameter test: simple string")]
        [Category("Slow")]
        [Category("TestResultDetailLevel")]
        [Category("Add_TmxTestResultDetail")]
        public void TestPrm_TestResultDetail_Simple()
        {
            string testResultDetail = "detail";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail " + 
                testResultDetail + 
                ";" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Details[0].Name;",
                testResultDetail);
        }
        
        [Test] //[Test(Description="The -TestResultDetail parameter test: complex string")]
        [Category("Slow")]
        [Category("TestResultDetailLevel")]
        [Category("Add_TmxTestResultDetail")]
        public void TestPrm_TestResultDetail_Complex()
        {
            string testResultDetail = @"""\\d//e::t`'`'a`""i`""l`<`<`>`>""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail (" + 
                testResultDetail + 
                @");" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Details[0].Name;",
                @"\\d//e::t''a""i""l<<>>");
        }
        
        [Test] //[Test(Description="The -Echo parameter test: simple string")]
        [Category("Slow")]
        [Category("TestResultDetailLevel")]
        [Category("Add_TmxTestResultDetail")]
        public void TestPrm_Echo_Simple()
        {
            string testResultDetail = "detail";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail " + 
                testResultDetail + 
                " -Echo;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Details[0].Name;",
                testResultDetail);
        }
        
        [Test] //[Test(Description="The -Echo parameter test: complex string")]
        [Category("Slow")]
        [Category("TestResultDetailLevel")]
        [Category("Add_TmxTestResultDetail")]
        public void TestPrm_Echo_Complex()
        {
            string testResultDetail = @"""\\d//e::t`'`'a`""i`""l`<`<`>`>""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail (" + 
                testResultDetail + 
                @") -Echo;" + 
                "[TMX.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Details[0].Name;",
                @"\\d//e::t''a""i""l<<>>");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
