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
    /// <summary>
    /// Description of WaitUiaWindowCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class WaitUiaWindowCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Wait-UiaWindow")]
        public void WaitWindow_ByProcessName_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Wait-UiaWindow -pn '" + 
                MiddleLevelCode.TestFormProcess +
                "' -Seconds 2;",
                "True");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Wait-UiaWindow")]
        public void WaitWindow_ByProcessName_Wrong_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Wait-UiaWindow -pn 'wrong process name' -Seconds 2;",
                "False");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Wait-UiaWindow")]
        public void WaitWindow_ByProcessId_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Wait-UiaWindow -pid (Get-Process '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id -Seconds 2;",
                "True");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Wait-UiaWindow")]
        public void WaitWindow_ByProcessId_Wrong_Timeout2000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);

            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Wait-UiaWindow -pid 0 -Seconds 2;",
                "False");
        }
    }
}
