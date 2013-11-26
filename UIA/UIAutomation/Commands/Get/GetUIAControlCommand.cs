/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 4:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace UIAutomation.Commands
{
    // 20131107
    // refactoring
    //using System;
    using System.Management.Automation;
    //using System.Windows.Automation;
    //using System.Xml.Serialization.Configuration;
    
    using System.Collections;

    /// <summary>
    /// Description of GetUiaControl.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControl", DefaultParameterSetName = "UiaWildCard")]
    //[OutputType(typeof(object))]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaControlCommand : GetControlCmdletBase
    {
        #region Parameters
        #endregion Parameters

        protected override void BeginProcessing() {
            
            // set the start time to calculate the timeout expiration
            StartDate = DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord() 
        {
            CheckCmdletParameters();
            
            if (!CheckAndPrepareInput(this)) { return; }

            WriteVerbose(this, "getting the control");
            
            ArrayList returnCollection = 
                GetControl(this);
            
//            if (null == returnCollection || 0 == returnCollection.Count) {
//                
//                this.WriteError(
//                    this,
//                    CmdletSignature(this) + "timeout expired for control with class: + '" +
//                    this.Class + 
//                    "', control type: '" + 
//                    this.ControlType + 
//                    "', title: '" +
//                    this.Name +
//                    "', automationId: '" +
//                    this.AutomationId +
//                    "', value: '" +
//                    this.Value +
//                    "'",
//                    "ControlIsNull",
//                    ErrorCategory.OperationTimeout,
//                    true);
//
//                return; // ?
//
//            }

            if (null != returnCollection && 0 < returnCollection.Count) {

                WriteObject(this, returnCollection);
                
            } else {
                // 20120830
                //WriteObject(this, (object)null);
                
                // 20131108
                WriteError(
                    this,
                    CmdletSignature(this) + "timeout expired for control with class: + '" +
                    Class + 
                    "', control type: '" + 
                    ControlType + 
                    "', title: '" +
                    Name +
                    "', automationId: '" +
                    AutomationId +
                    "', value: '" +
                    Value +
                    "'",
                    "ControlIsNull",
                    ErrorCategory.OperationTimeout,
                    true);
            }
        }
    }
    
    /// <summary>
    /// Description of GetUiaButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaButton", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaButtonCommand : GetUiaControlCommand
    { public GetUiaButtonCommand() { ControlType = "Button"; } }

    /// <summary>
    /// Description of GetUiaCalendar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCalendar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaCalendarCommand : GetUiaControlCommand
    { public GetUiaCalendarCommand() { ControlType = "Calendar"; } }
    
    /// <summary>
    /// Description of GetUiaCheckBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCheckBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaCheckBoxCommand : GetUiaControlCommand
    { public GetUiaCheckBoxCommand() { ControlType = "CheckBox"; } }
    
    /// <summary>
    /// Description of GetUiaComboBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaComboBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaComboBoxCommand : GetUiaControlCommand
    { public GetUiaComboBoxCommand() { ControlType = "ComboBox"; } }
    
    /// <summary>
    /// Description of GetUiaCustom.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCustom", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaCustomCommand : GetUiaControlCommand
    { public GetUiaCustomCommand() { ControlType = "Custom"; } }
    
    /// <summary>
    /// Description of GetUiaDataGrid.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDataGrid", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaDataGridCommand : GetUiaControlCommand
    { public GetUiaDataGridCommand() { ControlType = "DataGrid"; } }
    
    /// <summary>
    /// Description of GetUiaDataItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDataItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaDataItemCommand : GetUiaControlCommand
    { public GetUiaDataItemCommand() { ControlType = "DataItem"; } }
    
    /// <summary>
    /// Description of GetUiaDocument.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDocument", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaDocumentCommand : GetUiaControlCommand
    { public GetUiaDocumentCommand() { ControlType = "Document"; } }

    /// <summary>
    /// Description of GetUiaEdit.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaEdit", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaEditCommand : GetUiaControlCommand
    { public GetUiaEditCommand() { ControlType = "Edit"; } }
    
    /// <summary>
    /// Description of GetUiaTextBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTextBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaTextBoxCommand : GetUiaEditCommand
    { public GetUiaTextBoxCommand() { ControlType = "Edit"; } }
    
    /// <summary>
    /// Description of GetUiaGroup.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaGroup", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaGroupCommand : GetUiaControlCommand
    { public GetUiaGroupCommand() { ControlType = "Group"; } }
    
    /// <summary>
    /// Description of GetUiaGroupBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaGroupBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaGroupBoxCommand : GetUiaGroupCommand
    { public GetUiaGroupBoxCommand() { ControlType = "Group"; } }
    
    /// <summary>
    /// Description of GetUiaHeader.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaHeader", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaHeaderCommand : GetUiaControlCommand
    { public GetUiaHeaderCommand() { ControlType = "Header"; } }
    
    /// <summary>
    /// Description of GetUiaHeaderItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaHeaderItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaHeaderItemCommand : GetUiaControlCommand
    { public GetUiaHeaderItemCommand() { ControlType = "HeaderItem"; } }
    
    /// <summary>
    /// Description of GetUiaHyperlink.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaHyperlink", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaHyperlinkCommand : GetUiaControlCommand
    { public GetUiaHyperlinkCommand() { ControlType = "Hyperlink"; } }
    
    /// <summary>
    /// Description of GetUiaLinkLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaLinkLabel", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaLinkLabelCommand : GetUiaHyperlinkCommand
    { public GetUiaLinkLabelCommand() { ControlType = "Hyperlink"; } }

    /// <summary>
    /// Description of GetUiaImage.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaImage", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaImageCommand : GetUiaControlCommand
    { public GetUiaImageCommand() { ControlType = "Image"; } }
    
    /// <summary>
    /// Description of GetUiaList.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaList", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaListCommand : GetUiaControlCommand
    { public GetUiaListCommand() { ControlType = "List"; } }
    
    /// <summary>
    /// Description of GetUiaListItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaListItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaListItemCommand : GetUiaControlCommand
    { public GetUiaListItemCommand() { ControlType = "ListItem"; } }
    
    /// <summary>
    /// Description of GetUiaMenu.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenu", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaMenuCommand : GetUiaControlCommand
    { public GetUiaMenuCommand() { ControlType = "Menu"; } }
    
    /// <summary>
    /// Description of GetUiaMenuBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenuBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaMenuBarCommand : GetUiaControlCommand
    { public GetUiaMenuBarCommand() { ControlType = "MenuBar"; } }

    /// <summary>
    /// Description of GetUiaMenuItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenuItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaMenuItemCommand : GetUiaControlCommand
    { public GetUiaMenuItemCommand() { ControlType = "MenuItem"; } }
    
    /// <summary>
    /// Description of GetUiaPane.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaPane", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaPaneCommand : GetUiaControlCommand
    { public GetUiaPaneCommand() { ControlType = "Pane"; } }
    
    /// <summary>
    /// Description of GetUiaProgressBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaProgressBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaProgressBarCommand : GetUiaControlCommand
    { public GetUiaProgressBarCommand() { ControlType = "ProgressBar"; } }
    
    /// <summary>
    /// Description of GetUiaRadioButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaRadioButton", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaRadioButtonCommand : GetUiaControlCommand
    { public GetUiaRadioButtonCommand() { ControlType = "RadioButton"; } }
    
    /// <summary>
    /// Description of GetUiaScrollBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaScrollBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaScrollBarCommand : GetUiaControlCommand
    { public GetUiaScrollBarCommand() { ControlType = "ScrollBar"; } }

    /// <summary>
    /// Description of GetUiaSeparator.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSeparator", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaSeparatorCommand : GetUiaControlCommand
    { public GetUiaSeparatorCommand() { ControlType = "Separator"; } }
    
    /// <summary>
    /// Description of GetUiaSlider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSlider", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaSliderCommand : GetUiaControlCommand
    { public GetUiaSliderCommand() { ControlType = "Slider"; } }
    
    /// <summary>
    /// Description of GetUiaSpinner.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSpinner", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaSpinnerCommand : GetUiaControlCommand
    { public GetUiaSpinnerCommand() { ControlType = "Spinner"; } }
    
    /// <summary>
    /// Description of GetUiaSplitButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSplitButton", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaSplitButtonCommand : GetUiaControlCommand
    { public GetUiaSplitButtonCommand() { ControlType = "SplitButton"; } }
    
    /// <summary>
    /// Description of GetUiaStatusBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaStatusBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaStatusBarCommand : GetUiaControlCommand
    { public GetUiaStatusBarCommand() { ControlType = "StatusBar"; } }

    /// <summary>
    /// Description of GetUiaTab.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTab", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaTabCommand : GetUiaControlCommand
    { public GetUiaTabCommand() { ControlType = "Tab"; } }
    
    /// <summary>
    /// Description of GetUiaTabItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTabItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaTabItemCommand : GetUiaControlCommand
    { public GetUiaTabItemCommand() { ControlType = "TabItem"; } }
    
    /// <summary>
    /// Description of GetUiaTable.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTable", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaTableCommand : GetUiaControlCommand
    { public GetUiaTableCommand() { ControlType = "Table"; } }
    
    /// <summary>
    /// Description of GetUiaText.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaText", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaTextCommand : GetUiaControlCommand
    { public GetUiaTextCommand() { ControlType = "Text"; } }
    
    /// <summary>
    /// Description of GetUiaLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaLabel", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaLabelCommand : GetUiaTextCommand
    { public GetUiaLabelCommand() { ControlType = "Text"; } }
    
    /// <summary>
    /// Description of GetUiaThumb.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaThumb", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaThumbCommand : GetUiaControlCommand
    { public GetUiaThumbCommand() { ControlType = "Thumb"; } }

    /// <summary>
    /// Description of GetUiaTitleBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTitleBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaTitleBarCommand : GetUiaControlCommand
    { public GetUiaTitleBarCommand() { ControlType = "TitleBar"; } }
    
    /// <summary>
    /// Description of GetUiaToolBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaToolBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaToolBarCommand : GetUiaControlCommand
    { public GetUiaToolBarCommand() { ControlType = "ToolBar"; } }
    
    /// <summary>
    /// Description of GetUiaToolTip.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaToolTip", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaToolTipCommand : GetUiaControlCommand
    { public GetUiaToolTipCommand() { ControlType = "ToolTip"; } }
    
    /// <summary>
    /// Description of GetUiaTree.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTree", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaTreeCommand : GetUiaControlCommand
    { public GetUiaTreeCommand() { ControlType = "Tree"; } }
    
    /// <summary>
    /// Description of GetUiaTreeItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTreeItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaTreeItemCommand : GetUiaControlCommand
    { public GetUiaTreeItemCommand() { ControlType = "TreeItem"; } }
    
    /// <summary>
    /// Description of GetUiaChildWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaChildWindow", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IMySuperWrapper[]))] //[OutputType(typeof(UIAutomation.MySuperWrapper[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetUiaChildWindowCommand : GetUiaControlCommand
    { public GetUiaChildWindowCommand() { ControlType = "Window"; } }
    
}
