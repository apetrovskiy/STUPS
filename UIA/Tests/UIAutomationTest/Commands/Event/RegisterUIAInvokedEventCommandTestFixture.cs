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
    /// <summary>
    /// Description of RegisterUiaInvokedEventCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="1")]
    public class RegisterUiaInvokedEventCommandTestFixture
    {
        public RegisterUiaInvokedEventCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            //CmdletUnitTest.TestRunspace.RunPSCode(
            //    @"[void]([UIAutomation.CurrentData]::ResetData());");
        }
        
//        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Event")]
//        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Register_UiaInvokedEvent")]
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
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
