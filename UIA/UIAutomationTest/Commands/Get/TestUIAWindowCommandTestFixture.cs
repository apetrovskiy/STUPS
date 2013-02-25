/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 1:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using System.Diagnostics;
    using MbUnit.Framework;

    /// <summary>
    /// Description of TestUIAWindowCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class TestUIAWindowCommandTestFixture
    {
        public TestUIAWindowCommandTestFixture()
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
        [Category("WinForms")]
        [Category("Test-UIAWindow")]
        public void TestWindow_ByProcessName_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Test-UIAWindow -pn '" + 
                MiddleLevelCode.TestFormProcess +
                "' -Seconds 2;",
                "True");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Test-UIAWindow")]
        public void TestWindow_ByProcessName_Wrong_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Test-UIAWindow -pn 'wrong process name' -Seconds 2;",
                "False");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Test-UIAWindow")]
        public void TestWindow_ByProcessId_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Test-UIAWindow -pid (Get-Process '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id -Seconds 2;",
                "True");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Test-UIAWindow")]
        public void TestWindow_ByProcessId_Wrong_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                //@"Test-UIAWindow -pid (Get-Process 'wrong process name').Id -Seconds 2;",
                @"Test-UIAWindow -pid 0 -Seconds 2;",
                "True");
        }
    }
}
