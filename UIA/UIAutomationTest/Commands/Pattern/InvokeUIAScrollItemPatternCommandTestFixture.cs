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
    /// Description of InvokeUiaScrollItemPatternCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="Invoke-UiaScrollItemPatternCommand test")]
    public class InvokeUiaScrollItemPatternCommandTestFixture
    {
        public InvokeUiaScrollItemPatternCommandTestFixture()
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
                @"if ((Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList -AutomationId '" + 
                auId1 + 
                "' | Get-UiaListItem -Name '" + 
                name2 +
                "' | Read-UiaControlIsOffscreen)) {" +
                "$null = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList -AutomationId '" + 
                auId1 + 
                "' | Get-UiaListItem -Name '" + 
                name2 +
                "' | Invoke-UiaListItemScrollItem; " +
                @"Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaList -AutomationId '" + 
                auId1 + 
                "' | Get-UiaListItem -Name '" + 
                name2 +
                "' | Read-UiaControlIsOffscreen;}",
                expectedResult);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
