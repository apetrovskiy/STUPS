/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Wait
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of WaitUiaControlIsEnabledCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Wait-UiaControlIsEnabledCommand test")]
    public class WaitUiaControlIsEnabledCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::Timeout = 10000);");
        }
        
        private void checkIsEnabled(
            string name,
            string controlType,
            string propertyName,
            string expectedResult)
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            // 20130130
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"if (-not (Get-UiaWindow -pn " +
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UIA" +
//                controlType +
//                " -" + propertyName + " '" +
//                name +
//                @"').IsEnabled) { " + 
//                @"$null = Get-UiaWindow -pn " +
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UiaButton -Name Button2 | Invoke-UiaButtonClick; " +
//                @"Get-UiaWindow -pn " +
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UIA" + 
//                controlType +
//                " -" + propertyName + " '" +
//                name + 
//                @"' | Wait-UIA" + 
//                controlType +
//                @"IsEnabled | Read-UiaControlIsEnabled; } ",
//                expectedResult);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                "; " +
                @"if (Test-UiaControlState -searchCriteria @{" +
                propertyName +
                @"=""" +
                name +
                @""";IsEnabled=$false}){ $null = Get-UiaButton -Name Button2 | Invoke-UiaButtonClick; " +
                @"Get-UIA" +
                controlType +
                " -" + propertyName + " '" +
                name +
                @"' | Wait-UIA" + 
                controlType +
                @"IsEnabled | Read-UiaControlIsEnabled; }",
                expectedResult);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void WaitControlIsEnabled_Text()
        {
            string name = "label2";
            string controlType = "Text";
            string propertyName = "Name";
            string expectedResult = "True";
            checkIsEnabled(name, controlType, propertyName, expectedResult);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void WaitControlIsEnabled_RadioButton()
        {
            string name = "radioButton2";
            string controlType = "RadioButton";
            string propertyName = "Name";
            string expectedResult = "True";
            checkIsEnabled(name, controlType, propertyName, expectedResult);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void WaitControlIsEnabled_Spinner()
        {
            string name = "domainUpDown2";
            string controlType = "Spinner";
            string propertyName = "AutomationId";
            string expectedResult = "True";
            checkIsEnabled(name, controlType, propertyName, expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
