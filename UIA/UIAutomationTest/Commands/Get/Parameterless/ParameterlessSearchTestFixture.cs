/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 2/10/2013
 * Time: 12:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of ParameterlessSearchTestFixture.
    /// </summary>
    public class ParameterlessSearchTestFixture
    {
        public ParameterlessSearchTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByValueX2_WildCard_TimeoutDefault()
        {
            string auId1 = "Edit1";
            string auId2 = "Edit2";
            string expectedValue = "my text";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "e1",
                    auId1, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "e2",
                    auId2, 
                    0);
            arrList.Add(ctf2);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl -AutomationId Edit* | Set-UIAEditText -Text '" + 
                expectedValue +
                "'; Get-UIAEdit -Value '" +
                expectedValue +
                "' | Get-UIAEditText;",
                expectedValue);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByValueX2_WildCard_TimeoutDefault()
        {
            string auId1 = "Edit1";
            string auId2 = "Edit2";
            string expectedValue = "my text";
            System.Collections.ArrayList arrList = 
                new System.Collections.ArrayList();
            ControlToForm ctf1 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "e1",
                    auId1, 
                    0);
            arrList.Add(ctf1);
            ControlToForm ctf2 = 
                new ControlToForm(
                    System.Windows.Automation.ControlType.Edit,
                    "e2",
                    auId2, 
                    0);
            arrList.Add(ctf2);
            
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                (ControlToForm[])arrList.ToArray(typeof(ControlToForm)));
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAControl -AutomationId Edit* | Set-UIAEditText -Text '" + 
                expectedValue +
                "'; Get-UIAEdit -Value '" +
                expectedValue +
                "' | Get-UIAEditText;",
                expectedValue);
        }
    }
}
