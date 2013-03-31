/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/25/2013
 * Time: 1:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXTest.Commands.TestStructure
{
    using System;
    using MbUnit.Framework;
    using TMX;
    
    /// <summary>
    /// Description of SetTMXCurrentTestResultCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class SetTMXCurrentTestResultCommandTestFixture
    {
        public SetTMXCurrentTestResultCommandTestFixture()
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
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_Name()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.Name;",
                testResultName);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_Id()
        {
            string testResultId = "1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Id " + 
                testResultId + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_NameId_1()
        {
            string testResultName = "result1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name " + 
                testResultName + 
                " -Id 1;" + 
                "[TMX.TestData]::CurrentTestResult.Name;",
                testResultName);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_NameId_2()
        {
            string testResultName = "result1";
            string testResultId = "1";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name " + 
                testResultName + 
                " -Id '" +
                testResultId +
                "';" +
                "[TMX.TestData]::CurrentTestResult.Id;",
                testResultId);
        }
        
        [Test]
        [Category("Slow")]
        [Category("TestResultLevel")]
        [Category("Set-TMXCurrentTestResult")]
        public void SetTMXCurrentTestResult_TestResultStatus()
        {
            string testResultName = "result1";
            TestResultStatuses testResultStatus = TestResultStatuses.NotTested;
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Set-TMXCurrentTestResult -Name " + 
                testResultName + 
                ";" + 
                "[TMX.TestData]::CurrentTestResult.enStatus;",
                testResultStatus.ToString());
        }
    }
}
