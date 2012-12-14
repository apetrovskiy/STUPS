/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/14/2012
 * Time: 8:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Event
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of RegisterUIAInvokedEventCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="1")]
    public class RegisterUIAInvokedEventCommandTestFixture
    {
        public RegisterUIAInvokedEventCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            //CmdletUnitTest.TestRunspace.RunPSCode(
            //    @"[void]([UIAutomation.CurrentData]::ResetData());");
        }
        
//        [Test] //[Test(Description="TBD")]
//        [Category("Slow")][Category("WinForms")]
//        [Category("Slow")][Category("Control")]
//        [Category("Slow")][Category("Event")]
//        [Category("Slow")][Category("Register_UIAInvokedEvent")]
//        public void RegisterInvokedEvent_Button()
//        {
//            string name = "Button1";
//            string auId = "btn1";
//            ControlToForm ctf = 
//                new ControlToForm(
//                    System.Windows.Automation.ControlType.Button,
//                    name,
//                    auId, 
//                    TimeoutsAndDelays.Control_Delay0);
//            System.Collections.ArrayList arrList = 
//                new System.Collections.ArrayList();
//            arrList.Add(ctf);
//            MiddleLevelCode.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"$null = Get-UIAWindow -n " +
//                MiddleLevelCode.TestFormNameEmpty +
//                @" | Get-UIAButton -Name '" + 
//                name +
//                @"' | Register-UIAInvokedEvent " + 
//                @"-EventAction {$i = 1;}; " + 
//                @"$null = Get-UIAButton -Name '" + 
//                name +
//                @"' | Invoke-UIAButtonClick; " + 
//                @"(Wait-UIAEventRaised -Name '" + 
//                name +
//                @"').Cached.Name;",
//                name);
//        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
