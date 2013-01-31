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
    /// Description of WaitUIAControlIsEnabledCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Wait-UIAControlIsEnabledCommand test")]
    public class WaitUIAControlIsEnabledCommandTestFixture
    {
        public WaitUIAControlIsEnabledCommandTestFixture()
        {
        }
        
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
//                @"if (-not (Get-UIAWindow -pn " +
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UIA" +
//                controlType +
//                " -" + propertyName + " '" +
//                name +
//                @"').IsEnabled) { " + 
//                @"$null = Get-UIAWindow -pn " +
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UIAButton -Name Button2 | Invoke-UIAButtonClick; " +
//                @"Get-UIAWindow -pn " +
//                MiddleLevelCode.TestFormProcess +
//                @" | Get-UIA" + 
//                controlType +
//                " -" + propertyName + " '" +
//                name + 
//                @"' | Wait-UIA" + 
//                controlType +
//                @"IsEnabled | Read-UIAControlIsEnabled; } ",
//                expectedResult);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                "; " +
                @"if (Test-UIAControlState -searchCriteria @{" +
                propertyName +
                @"=""" +
                name +
                @""";IsEnabled=$false}){ $null = Get-UIAButton -Name Button2 | Invoke-UIAButtonClick; " +
                @"Get-UIA" +
                controlType +
                " -" + propertyName + " '" +
                name +
                @"' | Wait-UIA" + 
                controlType +
                @"IsEnabled | Read-UIAControlIsEnabled; }",
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
