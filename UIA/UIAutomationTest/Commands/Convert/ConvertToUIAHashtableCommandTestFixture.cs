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
    using System;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of ConvertToUIAHashtableCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="ConvertTo-UIAHashtable test")]
    public class ConvertToUIAHashtableCommandTestFixture
    {
        /// <summary>
        ///  /// </summary>
        public ConvertToUIAHashtableCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIAHashtable")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIAHashtable; " + 
                // 20120831 // ??
                "$hashtable['AutomationId'];",
                //"$hashtable[4].Value;",
                auId);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIAHashtable")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIAHashtable; " + 
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
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIAHashtable")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIAHashtable; " + 
                // 20120831 // ??
                "$hashtable['IsEnabled'];",
                //"$hashtable[6].Value;",
                isEnabled);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIAHashtable")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIAHashtable; " + 
                // 20120831 // ??
                "$hashtable['ControlType'];",
                //"$hashtable[1].Value;",
                controlType);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIAHashtable")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIAHashtable; " + 
                // 20120831 // ??
                "$hashtable['ProcessId'];",
                //"$hashtable[10].Value;",
                processId);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
    
    /// <summary>
    /// Description of ConvertToUIASearchCriteriaCommandTestFixture.
    /// </summary>
    [TestFixture] // [TestFixture(Description="ConvertTo-UIASearchCriteria test")]
    public class ConvertToUIASearchCriteriaCommandTestFixture
    {
        /// <summary>
        ///  /// </summary>
        public ConvertToUIASearchCriteriaCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIASearchCriteria")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIASearchCriteria; " + 
                @"$hashtable.Contains('AutomationId=""" + 
                auId +
                @"""');",
                result);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIASearchCriteria")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIASearchCriteria; " + 
                @"$hashtable.Contains('Name=""" +
                name +
                @"""');",
                result);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIASearchCriteria")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIASearchCriteria; " + 
                @"$hashtable.Contains('ControlType=""" +
                controlType +
                @"""');",
                result);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIASearchCriteria")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIASearchCriteria -Include IsEnabled; " + 
                @"$hashtable.Contains('IsEnabled=" +
                psTrue +
                @"');",
                result);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIASearchCriteria")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIASearchCriteria -Exclude ControlType; " + 
                @"$hashtable.Contains('ControlType=""" +
                controlType +
                @"""');",
                result);
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")]
        [Category("WinForms")]
        [Category("Control")]
        [Category("ConvertTo_UIASearchCriteria")]
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
                @"$hashtable = Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | ConvertTo-UIASearchCriteria -Full; " + 
                @"$hashtable.Contains('ProcessId=""" +
                processId +
                @"""');",
                result);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
