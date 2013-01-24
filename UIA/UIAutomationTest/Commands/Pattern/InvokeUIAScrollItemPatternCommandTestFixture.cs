/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/20/2012
 * Time: 12:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Pattern
{
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIAScrollItemPatternCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UIAScrollItemPatternCommand test")]
    public class InvokeUIAScrollItemPatternCommandTestFixture
    {
        public InvokeUIAScrollItemPatternCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[void]([UIAutomation.Preferences]::Timeout = 10000);");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("WinForms")]
        [Category("Slow")][Category("Control")]
        public void InvokeScrollItem_ListBox()
        {
            //string name1 = "listBox1";
            string auId1 = "listBox1";
            string name2 = "h8";
            //string auId2 = "rb222";
            string expectedResult = "False";
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsFull, 
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAList -AutomationId '" + 
                auId1 + 
                "' | Get-UIAListItem -Name '" + 
                name2 +
                "' | Read-UIAControlIsOffscreen)) {" +
                "$null = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAList -AutomationId '" + 
                auId1 + 
                "' | Get-UIAListItem -Name '" + 
                name2 +
                "' | Invoke-UIAListItemScrollItem; " +
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAList -AutomationId '" + 
                auId1 + 
                "' | Get-UIAListItem -Name '" + 
                name2 +
                "' | Read-UIAControlIsOffscreen;}",
                expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
