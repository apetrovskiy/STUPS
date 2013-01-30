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
    /// Description of RegisterUIAMenuOpenedEventCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="1")]
    public class RegisterUIAMenuOpenedEventCommandTestFixture
    {
        public RegisterUIAMenuOpenedEventCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::Timeout = 10000);");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Event")]
        [Category("Register_UIAMenuOpenedEvent")]
        public void RegisterMenuOpenedEvent()
        {
            string text = "File";
            string eventType = 
                "AutomationElementIdentifiers.MenuOpenedEvent";

            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Register-UIAMenuOpenedEvent " + 
                @"-EventAction {$i = 1;}; " + 
                @"$null = Get-UIAMenuItem -Name '" + 
                text +
                @"' | Invoke-UIAMenuItemClick -PassThru | Invoke-UIAMenuItemClick; " + 
                @"$null = Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Invoke-UIAControlClick; " +
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
