/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 4:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Xml.Serialization.Configuration;
    
    using System.Collections;

    /// <summary>
    /// Description of GetUIAControl.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControl", DefaultParameterSetName = "UIAWildCard")]
    // 20120828
    //[OutputType(typeof(object))]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlCommand : GetControlCmdletBase
    {
        #region Constructor
        public GetUIAControlCommand()
        {
        }
        #endregion Constructor

        #region Parameters
        #endregion Parameters

        protected override void BeginProcessing() {
            
            // set the start time to calculate the timeout expiration
            StartDate = System.DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord() 
        {
            this.CheckCmdletParameters();
            
            if (!this.CheckControl(this)) { return; }

            this.WriteVerbose(this, "getting the control");
            
            // 20120830
            ArrayList returnCollection = 
                GetControl(this);
            
            if (null == returnCollection || 0 == returnCollection.Count) {
                
                this.WriteError(
                    this,
                    CmdletSignature(this) + "timeout expired for control with class: + '" +
                    this.Class + 
                    "', control type: '" + 
                    this.ControlType + 
                    "', title: '" +
                    this.Name +
                    "', automationId: '" +
                    this.AutomationId +
                    "', value: '" +
                    this.Value +
                    "'",
                    "ControlIsNull",
                    ErrorCategory.OperationTimeout,
                    true);

                return; // ?

            }

            if (null != returnCollection && 0 < returnCollection.Count) {

                this.WriteObject(this, returnCollection);
                
            } else {
                // 20120830
                //WriteObject(this, (object)null);
                
            }
        }
    }
    
    /// <summary>
    /// Description of GetUIAButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAButton", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAButtonCommand : GetUIAControlCommand
    { public GetUIAButtonCommand() { ControlType = "Button"; } }

    /// <summary>
    /// Description of GetUIACalendar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACalendar", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACalendarCommand : GetUIAControlCommand
    { public GetUIACalendarCommand() { ControlType = "Calendar"; } }
    
    /// <summary>
    /// Description of GetUIACheckBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACheckBox", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACheckBoxCommand : GetUIAControlCommand
    { public GetUIACheckBoxCommand() { ControlType = "CheckBox"; } }
    
    /// <summary>
    /// Description of GetUIAComboBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAComboBox", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAComboBoxCommand : GetUIAControlCommand
    { public GetUIAComboBoxCommand() { ControlType = "ComboBox"; } }
    
    /// <summary>
    /// Description of GetUIACustom.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACustom", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACustomCommand : GetUIAControlCommand
    { public GetUIACustomCommand() { ControlType = "Custom"; } }
    
    /// <summary>
    /// Description of GetUIADataGrid.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADataGrid", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADataGridCommand : GetUIAControlCommand
    { public GetUIADataGridCommand() { ControlType = "DataGrid"; } }
    
    /// <summary>
    /// Description of GetUIADataItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADataItem", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADataItemCommand : GetUIAControlCommand
    { public GetUIADataItemCommand() { ControlType = "DataItem"; } }
    
    /// <summary>
    /// Description of GetUIADocument.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADocument", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADocumentCommand : GetUIAControlCommand
    { public GetUIADocumentCommand() { ControlType = "Document"; } }

    /// <summary>
    /// Description of GetUIAEdit.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAEdit", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAEditCommand : GetUIAControlCommand
    { public GetUIAEditCommand() { ControlType = "Edit"; } }
    
    /// <summary>
    /// Description of GetUIATextBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextBox", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextBoxCommand : GetUIAEditCommand
    { public GetUIATextBoxCommand() { ControlType = "Edit"; } }
    
    /// <summary>
    /// Description of GetUIAGroup.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAGroup", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAGroupCommand : GetUIAControlCommand
    { public GetUIAGroupCommand() { ControlType = "Group"; } }
    
    /// <summary>
    /// Description of GetUIAGroupBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAGroupBox", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAGroupBoxCommand : GetUIAGroupCommand
    { public GetUIAGroupBoxCommand() { ControlType = "Group"; } }
    
    /// <summary>
    /// Description of GetUIAHeader.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAHeader", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAHeaderCommand : GetUIAControlCommand
    { public GetUIAHeaderCommand() { ControlType = "Header"; } }
    
    /// <summary>
    /// Description of GetUIAHeaderItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAHeaderItem", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAHeaderItemCommand : GetUIAControlCommand
    { public GetUIAHeaderItemCommand() { ControlType = "HeaderItem"; } }
    
    /// <summary>
    /// Description of GetUIAHyperlink.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAHyperlink", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAHyperlinkCommand : GetUIAControlCommand
    { public GetUIAHyperlinkCommand() { ControlType = "Hyperlink"; } }
    
    /// <summary>
    /// Description of GetUIALinkLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIALinkLabel", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIALinkLabelCommand : GetUIAHyperlinkCommand
    { public GetUIALinkLabelCommand() { ControlType = "Hyperlink"; } }

    /// <summary>
    /// Description of GetUIAImage.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAImage", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAImageCommand : GetUIAControlCommand
    { public GetUIAImageCommand() { ControlType = "Image"; } }
    
    /// <summary>
    /// Description of GetUIAList.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAList", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAListCommand : GetUIAControlCommand
    { public GetUIAListCommand() { ControlType = "List"; } }
    
    /// <summary>
    /// Description of GetUIAListItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAListItem", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAListItemCommand : GetUIAControlCommand
    { public GetUIAListItemCommand() { ControlType = "ListItem"; } }
    
    /// <summary>
    /// Description of GetUIAMenu.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenu", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAMenuCommand : GetUIAControlCommand
    { public GetUIAMenuCommand() { ControlType = "Menu"; } }
    
    /// <summary>
    /// Description of GetUIAMenuBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenuBar", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAMenuBarCommand : GetUIAControlCommand
    { public GetUIAMenuBarCommand() { ControlType = "MenuBar"; } }

    /// <summary>
    /// Description of GetUIAMenuItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenuItem", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAMenuItemCommand : GetUIAControlCommand
    { public GetUIAMenuItemCommand() { ControlType = "MenuItem"; } }
    
    /// <summary>
    /// Description of GetUIAPane.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAPane", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAPaneCommand : GetUIAControlCommand
    { public GetUIAPaneCommand() { ControlType = "Pane"; } }
    
    /// <summary>
    /// Description of GetUIAProgressBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAProgressBar", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAProgressBarCommand : GetUIAControlCommand
    { public GetUIAProgressBarCommand() { ControlType = "ProgressBar"; } }
    
    /// <summary>
    /// Description of GetUIARadioButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIARadioButton", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIARadioButtonCommand : GetUIAControlCommand
    { public GetUIARadioButtonCommand() { ControlType = "RadioButton"; } }
    
    /// <summary>
    /// Description of GetUIAScrollBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAScrollBar", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAScrollBarCommand : GetUIAControlCommand
    { public GetUIAScrollBarCommand() { ControlType = "ScrollBar"; } }

    /// <summary>
    /// Description of GetUIASeparator.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASeparator", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASeparatorCommand : GetUIAControlCommand
    { public GetUIASeparatorCommand() { ControlType = "Separator"; } }
    
    /// <summary>
    /// Description of GetUIASlider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASlider", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASliderCommand : GetUIAControlCommand
    { public GetUIASliderCommand() { ControlType = "Slider"; } }
    
    /// <summary>
    /// Description of GetUIASpinner.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASpinner", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASpinnerCommand : GetUIAControlCommand
    { public GetUIASpinnerCommand() { ControlType = "Spinner"; } }
    
    /// <summary>
    /// Description of GetUIASplitButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASplitButton", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASplitButtonCommand : GetUIAControlCommand
    { public GetUIASplitButtonCommand() { ControlType = "SplitButton"; } }
    
    /// <summary>
    /// Description of GetUIAStatusBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAStatusBar", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAStatusBarCommand : GetUIAControlCommand
    { public GetUIAStatusBarCommand() { ControlType = "StatusBar"; } }

    /// <summary>
    /// Description of GetUIATab.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATab", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATabCommand : GetUIAControlCommand
    { public GetUIATabCommand() { ControlType = "Tab"; } }
    
    /// <summary>
    /// Description of GetUIATabItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATabItem", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATabItemCommand : GetUIAControlCommand
    { public GetUIATabItemCommand() { ControlType = "TabItem"; } }
    
    /// <summary>
    /// Description of GetUIATable.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATable", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATableCommand : GetUIAControlCommand
    { public GetUIATableCommand() { ControlType = "Table"; } }
    
    /// <summary>
    /// Description of GetUIAText.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAText", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextCommand : GetUIAControlCommand
    { public GetUIATextCommand() { ControlType = "Text"; } }
    
    /// <summary>
    /// Description of GetUIALabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIALabel", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIALabelCommand : GetUIATextCommand
    { public GetUIALabelCommand() { ControlType = "Text"; } }
    
    /// <summary>
    /// Description of GetUIAThumb.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAThumb", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAThumbCommand : GetUIAControlCommand
    { public GetUIAThumbCommand() { ControlType = "Thumb"; } }

    /// <summary>
    /// Description of GetUIATitleBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATitleBar", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATitleBarCommand : GetUIAControlCommand
    { public GetUIATitleBarCommand() { ControlType = "TitleBar"; } }
    
    /// <summary>
    /// Description of GetUIAToolBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAToolBar", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAToolBarCommand : GetUIAControlCommand
    { public GetUIAToolBarCommand() { ControlType = "ToolBar"; } }
    
    /// <summary>
    /// Description of GetUIAToolTip.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAToolTip", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAToolTipCommand : GetUIAControlCommand
    { public GetUIAToolTipCommand() { ControlType = "ToolTip"; } }
    
    /// <summary>
    /// Description of GetUIATree.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATree", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATreeCommand : GetUIAControlCommand
    { public GetUIATreeCommand() { ControlType = "Tree"; } }
    
    /// <summary>
    /// Description of GetUIATreeItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATreeItem", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATreeItemCommand : GetUIAControlCommand
    { public GetUIATreeItemCommand() { ControlType = "TreeItem"; } }
    
    /// <summary>
    /// Description of GetUIAChildWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAChildWindow", DefaultParameterSetName = "UIAWildCard")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAChildWindowCommand : GetUIAControlCommand
    { public GetUIAChildWindowCommand() { ControlType = "Window"; } }
    
}
