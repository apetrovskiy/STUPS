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
    /// Description of WaitUiaWindowCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class WaitUiaWindowCommandTestFixture
    {
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
        [Category("Wait-UiaWindow")]
        public void WaitWindow_ByProcessName_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Wait-UiaWindow -pn '" + 
                MiddleLevelCode.TestFormProcess +
                "' -Seconds 2;",
                "True");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Wait-UiaWindow")]
        public void WaitWindow_ByProcessName_Wrong_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Wait-UiaWindow -pn 'wrong process name' -Seconds 2;",
                "False");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Wait-UiaWindow")]
        public void WaitWindow_ByProcessId_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Wait-UiaWindow -pid (Get-Process '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id -Seconds 2;",
                "True");
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Wait-UiaWindow")]
        public void WaitWindow_ByProcessId_Wrong_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Wait-UiaWindow -pid 0 -Seconds 2;",
                "False");
        }
    }
}
