/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/14/2012
 * Time: 2:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    /// <summary>
    /// Description of GetUiaGroupBoxCommandTextFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Get-UiaGroupBoxCommand test")]
    public class GetUiaGroupBoxCommandTextFixture
    {
        public GetUiaGroupBoxCommandTextFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByAutomationIDTimeoutDefault()
        {
            string auId = "GroupBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -AutomationId " + 
                auId + 
                " | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByAutomationIDTimeout2000()
        {
            string auId = "GroupBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByAutomationIDTimeout3000Delay500()
        {
            string auId = "GroupBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                "aaa",
                auId,
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -AutomationId " + 
                auId + 
                " -timeout 3000 | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByAutomationIDTimeout2000Delay4000()
        {
            string auId = "GroupBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                "aaa",
                auId,
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UiaControlAutomationId",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByTitleTimeoutDefault()
        {
            string name = "GroupBox222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -Name " + 
                name + " | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByTitleTimeout2000()
        {
            string name = "GroupBox222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -Name " + 
                name + " -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByTitleTimeout3000Delay500()
        {
            string name = "GroupBox222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -Name " + 
                name + " -timeout 3000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByTitleTimeout2000Delay4000()
        {
            string name = "GroupBox222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -Name " + 
                name + " -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByControlTypeTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox | Read-UiaControlType",
                "ControlType.Group");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByControlTypeTimeout2000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -timeout 2000 | Read-UiaControlType",
                "ControlType.Group");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByControlTypeTimeout3000Delay500()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -timeout 3000 | Read-UiaControlType",
                "ControlType.Group");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetGroupBoxByControlTypeTimeout2000Delay4000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Group,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaGroupBox -timeout 2000 | Read-UiaControlType",
                "ControlType.Group");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}