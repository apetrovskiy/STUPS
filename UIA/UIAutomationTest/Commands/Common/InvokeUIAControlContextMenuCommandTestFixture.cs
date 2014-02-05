/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/5/2014
 * Time: 1:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAControlContextMenuCommandTestFixture.
    /// </summary>
    public class InvokeUIAControlContextMenuCommandTestFixture
    {
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void Invoke_ControlContextMenu_from_window()
        {
            string expectedResult = "WindowMenuLevel1-2";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsWithMenus, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$menuItemName = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Invoke-UiaControlContextMenu | Get-UiaMenuItem -Name '" + 
                expectedResult + 
                "' | Invoke-UiaMenuItemClick | Read-UiaControlName; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList | Get-UiaListItem -Name '" +
                expectedResult +
                "' | Read-UiaControlName;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void Invoke_ControlContextMenu_from_window_coordinated()
        {
            string expectedResult = "WindowMenuLevel1-2";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsWithMenus, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$menuItemName = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Invoke-UiaControlContextMenu -X 50 -Y 50 | Get-UiaMenuItem -Name '" + 
                expectedResult + 
                "' | Invoke-UiaMenuItemClick | Read-UiaControlName; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList | Get-UiaListItem -Name '" +
                expectedResult +
                "' | Read-UiaControlName;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void Invoke_ControlContextMenu_from_control()
        {
            string expectedResult = "ControlMenuLevel1-2";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsWithMenus, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$menuItemName = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaPane " +
                " | Invoke-UiaControlContextMenu | Get-UiaMenuItem -Name '" + 
                expectedResult + 
                "' | Invoke-UiaMenuItemClick | Read-UiaControlName; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList | Get-UiaListItem -Name '" +
                expectedResult +
                "' | Read-UiaControlName;",
                expectedResult);
        }
        
        [Test]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        public void Invoke_ControlContextMenu_from_control_coordinated()
        {
            string expectedResult = "ControlMenuLevel1-2";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsWithMenus, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$menuItemName = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaPane " +
                " | Invoke-UiaControlContextMenu -X 20 -Y 20 | Get-UiaMenuItem -Name '" + 
                expectedResult + 
                "' | Invoke-UiaMenuItemClick | Read-UiaControlName; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList | Get-UiaListItem -Name '" +
                expectedResult +
                "' | Read-UiaControlName;",
                expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
