/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/19/2012
 * Time: 8:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAControlClickCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="1")]
    public class InvokeUIAControlClickCommandTestFixture
    {
        public InvokeUIAControlClickCommandTestFixture()
        {
        }
        
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        // Button
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void Invoke_Control_Click_Button()
        {
            string expectedResult = "Invoked";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAButton -Name button1 | Invoke-UIAControlClick;" + 
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAList -AutomationId listBox1 | " + 
                "Get-UIAListItem -Name " + 
                expectedResult +
                " | Read-UIAControlName;",
                expectedResult);
        }
        
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
        
    }
}
