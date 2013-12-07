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
    /// Description of RegisterUiaInvokedEventCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="1")]
    public class RegisterUiaInvokedEventCommandTestFixture
    {
        public RegisterUiaInvokedEventCommandTestFixture()
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
//        [Category("Slow")][Category("Register_UiaInvokedEvent")]
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
//                @"$null = Get-UiaWindow -n " +
//                MiddleLevelCode.TestFormNameEmpty +
//                @" | Get-UiaButton -Name '" + 
//                name +
//                @"' | Register-UiaInvokedEvent " + 
//                @"-EventAction {$i = 1;}; " + 
//                @"$null = Get-UiaButton -Name '" + 
//                name +
//                @"' | Invoke-UiaButtonClick; " + 
//                @"(Wait-UiaEventRaised -Name '" + 
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
