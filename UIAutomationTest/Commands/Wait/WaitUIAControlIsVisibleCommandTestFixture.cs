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
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of WaitUIAControlIsVisibleCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Wait-UIAControlIsVisibleCommand test")]
    public class WaitUIAControlIsVisibleCommandTestFixture
    {
        public WaitUIAControlIsVisibleCommandTestFixture()
        {
        }
        
        [SetUp]
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
                @"if (-not (Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIA" +
                controlType +
                " -" +  propertyName + " '" +
                name +
                @"').IsVisible) { " + 
                @"$null = Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIAButton -Name Button2 | Invoke-UIAButtonClick; " +
                @"(-not (Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Get-UIA" + 
                controlType +
                " -" + propertyName + " '" +
                name + 
                @"' | Wait-UIA" + 
                controlType +
                @"IsVisible | Read-UIAControlIsOffscreen)); } ",
                expectedResult);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void WaitControlIsVisible_Text()
        {
            string name = "label2";
            string controlType = "Text";
            string propertyName = "Name";
            string expectedResult = "True";
            checkIsVisible(name, controlType, propertyName, expectedResult);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void WaitControlIsVisible_RadioButton()
        {
            string name = "radioButton2";
            string controlType = "RadioButton";
            string propertyName = "Name";
            string expectedResult = "True";
            checkIsVisible(name, controlType, propertyName, expectedResult);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void WaitControlIsVisible_Spinner()
        {
            string name = "domainUpDown2";
            string controlType = "Spinner";
            string propertyName = "AutomationId";
            string expectedResult = "True";
            checkIsVisible(name, controlType, propertyName, expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
