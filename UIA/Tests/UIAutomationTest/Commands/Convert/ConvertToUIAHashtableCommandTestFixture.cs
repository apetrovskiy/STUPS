/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/26/2012
 * Time: 10:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Convert
{
    /// <summary>
    /// Description of ConvertToUiaHashtableCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="ConvertTo-UiaHashtable test")]
    public class ConvertToUiaHashtableCommandTestFixture
    {
        /// <summary>
        ///  /// </summary>
        public ConvertToUiaHashtableCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaHashtable")]
        public void ConvertToHashtable_AutomationId()
        {
            string auId = "Button111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaHashtable; " + 
                // 20120831 // ??
                "$hashtable['AutomationId'];",
                //"$hashtable[4].Value;",
                auId);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaHashtable")]
        public void ConvertToHashtable_Name()
        {
            string auId = "Button111";
            string name = "aaa";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaHashtable; " + 
                // 20120831 // ??
                "$hashtable['Name'];",
                //"$hashtable[2].Value;",
                name);
        }
        
//IsContentElement               True
//ControlType                    ControlType.But
//Name                           2
//IsRequiredForForm              False
//AutomationId                   132
//IsPassword                     False
//IsEnabled                      True
//BoundingRectangle              375,1025,34,27
//HelpText
//ItemStatus
//ProcessId                      7328
//AccessKey
//HasKeyboardFocus               False
//IsOffscreen                    False
//NativeWindowHandle             985968
//ItemType
//Class                          Button
//IsKeyboardFocusable            True
//LocalizedControlType           button
//AcceleratorKey
//FrameworkId                    Win32
//IsControlElement               True
//Orientation                    None
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaHashtable")]
        public void ConvertToHashtable_IsEnabled()
        {
            string auId = "Button111";
            string name = "aaa";
            string isEnabled = "True";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaHashtable; " + 
                // 20120831 // ??
                "$hashtable['IsEnabled'];",
                //"$hashtable[6].Value;",
                isEnabled);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaHashtable")]
        public void ConvertToHashtable_ControlType()
        {
            string auId = "Button111";
            string name = "aaa";
            string controlType = "ControlType.Button";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaHashtable; " + 
                // 20120831 // ??
                "$hashtable['ControlType'];",
                //"$hashtable[1].Value;",
                controlType);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaHashtable")]
        public void ConvertToHashtable_ProcessId()
        {
            string auId = "Button111";
            string name = "aaa";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            string processId = 
                System.Diagnostics.Process.GetProcessesByName(
                    MiddleLevelCode.TestFormProcess)[0].Id.ToString();
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaHashtable; " + 
                // 20120831 // ??
                "$hashtable['ProcessId'];",
                //"$hashtable[10].Value;",
                processId);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
    
    /// <summary>
    /// Description of ConvertToUiaSearchCriteriaCommandTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture] // [TestFixture(Description="ConvertTo-UiaSearchCriteria test")]
    public class ConvertToUiaSearchCriteriaCommandTestFixture
    {
        /// <summary>
        ///  /// </summary>
        public ConvertToUiaSearchCriteriaCommandTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaSearchCriteria")]
        public void ConvertToSearchCriteria_Default_AutomationId()
        {
            string auId = "Button111";
            string result = "True";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaSearchCriteria; " + 
                @"$hashtable.Contains('AutomationId=""" + 
                auId +
                @"""');",
                result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaSearchCriteria")]
        public void ConvertToSearchCriteria_Default_Name()
        {
            string auId = "Button111";
            string name = "aaa";
            string result = "True";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaSearchCriteria; " + 
                @"$hashtable.Contains('Name=""" +
                name +
                @"""');",
                result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaSearchCriteria")]
        public void ConvertToSearchCriteria_Default_ControlType()
        {
            string auId = "Button111";
            string name = "aaa";
            string controlType = "Button";
            string result = "True";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaSearchCriteria; " + 
                @"$hashtable.Contains('ControlType=""" +
                controlType +
                @"""');",
                result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test] //[Test(Description="TBD")]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaSearchCriteria")]
        public void ConvertToSearchCriteria_Include_IsEnabled()
        {
            string auId = "Button111";
            string name = "aaa";
            string result = "True";
            string psTrue = "$true";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaSearchCriteria -Include IsEnabled; " + 
                @"$hashtable.Contains('IsEnabled=" +
                psTrue +
                @"');",
                result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaSearchCriteria")]
        public void ConvertToSearchCriteria_Exclude_ControlType()
        {
            string auId = "Button111";
            string name = "aaa";
            string result = "False";
            string controlType = "Button";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaSearchCriteria -Exclude ControlType; " + 
                @"$hashtable.Contains('ControlType=""" +
                controlType +
                @"""');",
                result);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test]
        [MbUnit.Framework.Category("Slow")]
        [MbUnit.Framework.Category("WinForms")]
        [MbUnit.Framework.Category("Control")]
        [MbUnit.Framework.Category("ConvertTo_UiaSearchCriteria")]
        public void ConvertToSearchCriteria_ProcessId()
        {
            string auId = "Button111";
            string name = "aaa";
            string result = "True";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                auId,
                0);
            string processId = 
                System.Diagnostics.Process.GetProcessesByName(
                    MiddleLevelCode.TestFormProcess)[0].Id.ToString();
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"$hashtable = Get-UiaWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UiaControl -AutomationId " + 
                auId + 
                " | ConvertTo-UiaSearchCriteria -Full; " + 
                @"$hashtable.Contains('ProcessId=""" +
                processId +
                @"""');",
                result);
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
