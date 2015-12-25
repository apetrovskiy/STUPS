/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/14/2012
 * Time: 10:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    /// <summary>
    /// Description of GetUiaTableCommandTextFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="Get-UiaTableCommand test")]
    public class GetUiaTableCommandTextFixture
    {
        public GetUiaTableCommandTextFixture()
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
        public void GetTableByAutomationIDTimeoutDefault()
        {
            string auId = "Table111";
            string name = "Properties Window";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaPane -AutomationId " + 
                auId + 
                " | Get-UiaTable -Name '" + 
                name + "' | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByAutomationIDTimeout2000()
        {
            string auId = "Table111";
            string name = "Properties Window";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaPane -AutomationId " + 
                auId + 
                " -timeout 2000 | Get-UiaTable -Name '" + 
                name + "' | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByAutomationIDTimeout3000Delay500()
        {
            string auId = "Table111";
            string name = "Properties Window";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "aaa",
                auId,
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaPane -AutomationId " + 
                auId + 
                " -timeout 3000 | Get-UiaTable -Name '" + 
                name + 
                "' | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByAutomationIDTimeout2000Delay4000()
        {
            string auId = "Table111";
            string name = "Properties Window";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "aaa",
                auId,
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaPane -AutomationId " + 
                auId + 
                " -timeout 2000 | Get-UiaTable -Name '" + 
                name + 
                "' | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByTitleTimeoutDefault()
        {
            //string name = "Table222";
            string name = "Properties Window";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "\"" + name + "\"",
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -Name '" + 
                name + "' | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByTitleTimeout2000()
        {
            //string name = "Table222";
            string name = "Properties Window";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "\"" + name + "\"",
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -Name '" + 
                name + "' -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByTitleTimeout3000Delay500()
        {
            //string name = "Table222";
            string name = "Properties Window";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "\"" + name + "\"",
                "btn",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -Name '" + 
                name + "' -timeout 3000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByTitleTimeout2000Delay4000()
        {
            //string name = "Table222";
            string name = "Properties Window";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "\"" + name + "\"",
                "btn",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -Name '" + 
                name + "' -timeout 2000 | " +
                "Read-UiaControlName",
                name);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByControlTypeTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable | Read-UiaControlType",
                "ControlType.Table");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByControlTypeTimeout2000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -timeout 2000 | Read-UiaControlType",
                "ControlType.Table");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByControlTypeTimeout3000Delay500()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -timeout 3000 | Read-UiaControlType",
                "ControlType.Table");
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Slow")][MbUnit.Framework.Category("Control")]
        public void GetTableByControlTypeTimeout2000Delay4000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Table,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaTable -timeout 2000 | Read-UiaControlType",
                "ControlType.Table");
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}