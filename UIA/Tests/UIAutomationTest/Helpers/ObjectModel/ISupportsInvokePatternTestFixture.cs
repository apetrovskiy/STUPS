/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/7/2014
 * Time: 5:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers.ObjectModel
{
    /// <summary>
    /// Description of ISupportsInvokePatternTestFixture.
    /// </summary>
    // [MbUnit.Framework.Ignore][NUnit.Framework.Ignore]
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class ISupportsInvokePatternTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("ISupportsInvoke")]
        public void Button_Invoked()
        {
            const string expectedResult = "Invoked";
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
    }
}
