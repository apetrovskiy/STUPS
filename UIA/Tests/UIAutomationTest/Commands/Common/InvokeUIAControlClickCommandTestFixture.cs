/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/19/2012
 * Time: 8:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    /// <summary>
    /// Description of InvokeUiaControlClickCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="1")]
    public class InvokeUiaControlClickCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        // Button
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        public void Invoke_Control_Click_Button()
        {
            string expectedResult = "Invoked";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaButton -Name button1 | Invoke-UiaControlClick;" + 
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList -AutomationId listBox1 | " + 
                "Get-UiaListItem -Name " + 
                expectedResult +
                " | Read-UiaControlName;",
                expectedResult);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        
    }
}
