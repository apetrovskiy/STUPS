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
        public void Invoke_ControlContextMenu()
        {
            string expectedResult = "MenuLevel1-2";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsWithMenus, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[string]$menuItemName = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Invoke-UiaControlContextMenu -X 50 -Y 50 | Get-UiaMenuItem -Name '" + 
                expectedResult + 
                "' | Invoke-UiaMenuItemClick | Read-UiaControlName; " +
                @"$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                // " | Get-UiaList | Get-UiaListItem -Name $menuItemName | Read-UiaControlName;",
                " | Get-UiaList | Get-UiaListItem | Read-UiaControlName;",
                expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
