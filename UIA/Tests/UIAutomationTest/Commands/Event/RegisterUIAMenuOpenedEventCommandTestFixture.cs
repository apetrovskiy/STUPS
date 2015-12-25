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
    /// <summary>
    /// Description of RegisterUiaMenuOpenedEventCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="1")]
    public class RegisterUiaMenuOpenedEventCommandTestFixture
    {
        public RegisterUiaMenuOpenedEventCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.CurrentData]::ResetData());");
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::Timeout = 10000);");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("Event")]
        [MbUnit.Framework.Category("Register_UiaMenuOpenedEvent")]
        public void RegisterMenuOpenedEvent()
        {
            string text = "File";
            string eventType = 
                "AutomationElementIdentifiers.MenuOpenedEvent";

            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Register-UiaMenuOpenedEvent " + 
                @"-EventAction {$i = 1;}; " + 
                @"$null = Get-UiaMenuItem -Name '" + 
                text +
                @"' | Invoke-UiaMenuItemClick -PassThru | Invoke-UiaMenuItemClick; " + 
                @"$null = Get-UiaWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                @" | Invoke-UiaControlClick; " +
                @"[UIAutomation.CurrentData]::LastEventType",
                eventType);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
