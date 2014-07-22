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
    using MbUnit.Framework;using NUnit.Framework; // using MbUnit.Framework;using NUnit.Framework;
    
    /// <summary>
    /// Description of AddTmxTestResultDetailCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Add-TmxTestResultDetail test")]
    public class AddTmxTestResultDetailCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestResultDetail parameter test: simple string")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultDetailLevel")]
        [MbUnit.Framework.Category("Add_TmxTestResultDetail")]
        public void TestPrm_TestResultDetail_Simple()
        {
            const string testResultDetail = "detail";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail " + 
                testResultDetail + 
                ";" + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Details[0].Name;",
                testResultDetail);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -TestResultDetail parameter test: complex string")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultDetailLevel")]
        [MbUnit.Framework.Category("Add_TmxTestResultDetail")]
        public void TestPrm_TestResultDetail_Complex()
        {
            const string testResultDetail = @"""\\d//e::t`'`'a`""i`""l`<`<`>`>""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail (" + 
                testResultDetail + 
                @");" + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Details[0].Name;",
                @"\\d//e::t''a""i""l<<>>");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Echo parameter test: simple string")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultDetailLevel")]
        [MbUnit.Framework.Category("Add_TmxTestResultDetail")]
        public void TestPrm_Echo_Simple()
        {
            const string testResultDetail = "detail";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail " + 
                testResultDetail + 
                " -Echo;" + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Details[0].Name;",
                testResultDetail);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="The -Echo parameter test: complex string")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("TestResultDetailLevel")]
        [MbUnit.Framework.Category("Add_TmxTestResultDetail")]
        public void TestPrm_Echo_Complex()
        {
            const string testResultDetail = @"""\\d//e::t`'`'a`""i`""l`<`<`>`>""";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Add-TmxTestResultDetail -TestResultDetail (" + 
                testResultDetail + 
                @") -Echo;" + 
                "[Tmx.Core.TestData]::TestSuites[0].TestScenarios[0].TestResults[0].Details[0].Name;",
                @"\\d//e::t''a""i""l<<>>");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
