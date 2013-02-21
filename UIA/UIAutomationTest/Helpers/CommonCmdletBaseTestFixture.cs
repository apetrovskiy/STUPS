/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 02.02.2012
 * Time: 1:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Select
{
    using System;
    using System.Diagnostics;
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    using System.Windows.Automation;
    using UIAutomation;
    
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    [TestFixture] // [TestFixture(Description="CommonCmdletBase test")]
    public class CommonCmdletBaseTestFixture
    {
        public CommonCmdletBaseTestFixture()
        {
        }
        
        // 20130221
        // UIAutomation.HasControlInputCmdletBase cmdlet = null;
        UIAutomation.GetControlCmdletBase cmdlet = null;
        UIAutomation.CommonCmdletBase cmdletBase = null;
        
        private void checkConditionsArray(
            string controlType,
            string controlTypeProperty,
            string controlTypeValue)
        {
            Condition[] conditions = null;
            cmdlet = 
                new UIAutomation.Commands.GetUIAControlCommand();
            cmdletBase = 
                // 20130221
                // new UIAutomation.CommonCmdletBase();
                new UIAutomation.GetControlCmdletBase();
            AndCondition condition =
                // 20130127
                //cmdlet.getControlConditions(cmdlet, controlType);
                // 20130128
                //cmdlet.getControlConditions(cmdlet, controlType, ((GetControlCmdletBase)cmdlet).CaseSensitive);
                //cmdlet.getControlConditions(cmdlet, controlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true);
                cmdlet.getControlConditions(cmdlet, controlType, ((GetControlCmdletBase)cmdlet).CaseSensitive, true) as AndCondition;
            conditions = condition.GetConditions();
            foreach (Condition cond in conditions) {
                if ((cond as PropertyCondition) != null) {
                    Assert.AreEqual(
                        controlTypeProperty, 
                        (cond as PropertyCondition).Property.ProgrammaticName);
                    Assert.AreEqual(
                        controlTypeValue, 
                        (cond as PropertyCondition).Value.ToString());
                } else {
                    Assert.AreEqual(cond, Condition.TrueCondition);
                }
            }
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
// MiddleLevelCode.PrepareRunspace();
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeButton()
        {
            checkConditionsArray(
                "Button",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50000");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeCalendar()
        {
            checkConditionsArray(
                "Calendar",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50001");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeCheckBox()
        {
            checkConditionsArray(
                "CheckBox",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50002");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeComboBox()
        {
            checkConditionsArray(
                "ComboBox",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50003");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeCustom()
        {
            checkConditionsArray(
                "Custom",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50025");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeDataGrid()
        {
            checkConditionsArray(
                "DataGrid",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50028");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeDataItem()
        {
            checkConditionsArray(
                "DataItem",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50029");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeDocument()
        {
            checkConditionsArray(
                "Document",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50030");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeEdit()
        {
            checkConditionsArray(
                "Edit",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50004");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeHyperlink()
        {
            checkConditionsArray(
                "Hyperlink",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50005");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeList()
        {
            checkConditionsArray(
                "List",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50008");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeRadioButton()
        {
            checkConditionsArray(
                "RadioButton",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50013");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeTable()
        {
            checkConditionsArray(
                "Table",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50036");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeText()
        {
            checkConditionsArray(
                "Text",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50020");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeTree()
        {
            checkConditionsArray(
                "Tree",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50023");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeTreeItem()
        {
            checkConditionsArray(
                "TreeItem",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50024");
        }
        
        [Test] //[Test(Description="TBD")]
        [Category("Slow")][Category("CSCode")]
        public void SelectParameterControlTypeWindow()
        {
            checkConditionsArray(
                "Window",
                "AutomationElementIdentifiers.ControlTypeProperty",
                "50032");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
// MiddleLevelCode.DisposeRunspace();
            cmdlet = null;
        }
    }
}
