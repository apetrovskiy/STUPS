/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/20/2012
 * Time: 1:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Wait
{
    /// <summary>
    /// Description of WaitUiaControlIsVisibleCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class WaitUiaControlIsVisibleCommandTestFixture
    {
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::Timeout = 10000);");
        }
        
        private void checkIsVisible(
            string name,
            string controlType,
            string  propertyName,
            string expectedResult)
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if (-not (Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Get-Uia" +
                controlType +
                " -" +  propertyName + " '" +
                name +
                @"').IsVisible) { " + 
                @"$null = Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Get-UiaButton -Name Button2 | Invoke-UiaButtonClick; " +
                @"(-not (Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Get-Uia" + 
                controlType +
                " -" + propertyName + " '" +
                name + 
                @"' | Wait-UIA" + 
                controlType +
                @"IsVisible | Read-UiaControlIsOffscreen)); } ",
                expectedResult);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Control")]
        public void WaitControlIsVisible_Text()
        {
            string name = "label2";
            string controlType = "Text";
            string propertyName = "Name";
            string expectedResult = "True";
            checkIsVisible(name, controlType, propertyName, expectedResult);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Control")]
        public void WaitControlIsVisible_RadioButton()
        {
            string name = "radioButton2";
            string controlType = "RadioButton";
            string propertyName = "Name";
            string expectedResult = "True";
            checkIsVisible(name, controlType, propertyName, expectedResult);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("Control")]
        public void WaitControlIsVisible_Spinner()
        {
            string name = "domainUpDown2";
            string controlType = "Spinner";
            string propertyName = "AutomationId";
            string expectedResult = "True";
            checkIsVisible(name, controlType, propertyName, expectedResult);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
