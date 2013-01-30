/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/20/2012
 * Time: 11:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Event
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of RegisterUIAMenuClosedEventCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="1")]
    public class RegisterUIAMenuClosedEventCommandTestFixture
    {
        public RegisterUIAMenuClosedEventCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::Timeout = 15000);");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Event")]
        [Category("Register_UIAMenuClosedEvent")]
        public void RegisterMenuClosedEvent()
        {
            //string name = "FileDropDown";
            string text = "File";
            string eventType = 
                "AutomationElementIdentifiers.MenuClosedEvent";

            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Register-UIAMenuClosedEvent " + 
                @"-EventAction {$i = 1;}; " + 
                @"$null = Get-UIAMenuItem -Name '" + 
                text +
                @"' | Invoke-UIAMenuItemClick -PassThru | Invoke-UIAMenuItemClick; " + 
                @"$null = Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Invoke-UIAControlClick; " +
                @"$null = Get-UIAWindow -n " +
                MiddleLevelCode.TestFormNameFull +
                @" | Get-UIAButton -Name b*; " +
                @"[UIAutomation.CurrentData]::LastEventType",
                eventType);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
