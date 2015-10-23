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
//    using System.Collections;
//    using System.Collections.Generic;
    using Helpers.Commands;

    /// <summary>
    /// Description of GetUiaControl.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControl", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
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
            
            var command =
                AutomationFactory.GetCommand<GetControlCommand>(this);
            command.Execute();
        }
    }
    
    /// <summary>
    /// Description of GetUiaButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaButton", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaButtonCommand : GetUiaControlCommand
    { public GetUiaButtonCommand() { ControlType = new string[] { "Button" }; } }

    /// <summary>
    /// Description of GetUiaCalendar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCalendar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaCalendarCommand : GetUiaControlCommand
    { public GetUiaCalendarCommand() { ControlType = new string[] { "Calendar" }; } }
    
    /// <summary>
    /// Description of GetUiaCheckBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCheckBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaCheckBoxCommand : GetUiaControlCommand
    { public GetUiaCheckBoxCommand() { ControlType = new string[] { "CheckBox" }; } }
    
    /// <summary>
    /// Description of GetUiaComboBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaComboBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaComboBoxCommand : GetUiaControlCommand
    { public GetUiaComboBoxCommand() { ControlType = new string[] { "ComboBox" }; } }
    
    /// <summary>
    /// Description of GetUiaCustom.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaCustom", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaCustomCommand : GetUiaControlCommand
    { public GetUiaCustomCommand() { ControlType = new string[] { "Custom" }; } }
    
    /// <summary>
    /// Description of GetUiaDataGrid.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDataGrid", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaDataGridCommand : GetUiaControlCommand
    { public GetUiaDataGridCommand() { ControlType = new string[] { "DataGrid" }; } }
    
    /// <summary>
    /// Description of GetUiaDataItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDataItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaDataItemCommand : GetUiaControlCommand
    { public GetUiaDataItemCommand() { ControlType = new string[] { "DataItem" }; } }
    
    /// <summary>
    /// Description of GetUiaDocument.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaDocument", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaDocumentCommand : GetUiaControlCommand
    { public GetUiaDocumentCommand() { ControlType = new string[] { "Document" }; } }

    /// <summary>
    /// Description of GetUiaEdit.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaEdit", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaEditCommand : GetUiaControlCommand
    { public GetUiaEditCommand() { ControlType = new string[] { "Edit" }; } }
    
    /// <summary>
    /// Description of GetUiaTextBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTextBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaTextBoxCommand : GetUiaEditCommand
    { public GetUiaTextBoxCommand() { ControlType = new string[] { "Edit" }; } }
    
    /// <summary>
    /// Description of GetUiaGroup.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaGroup", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaGroupCommand : GetUiaControlCommand
    { public GetUiaGroupCommand() { ControlType = new string[] { "Group" }; } }
    
    /// <summary>
    /// Description of GetUiaGroupBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaGroupBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaGroupBoxCommand : GetUiaGroupCommand
    { public GetUiaGroupBoxCommand() { ControlType = new string[] { "Group" }; } }
    
    /// <summary>
    /// Description of GetUiaHeader.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaHeader", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    
    public class GetUiaHeaderCommand : GetUiaControlCommand
    { public GetUiaHeaderCommand() { ControlType = new string[] { "Header" }; } }
    
    /// <summary>
    /// Description of GetUiaHeaderItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaHeaderItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaHeaderItemCommand : GetUiaControlCommand
    { public GetUiaHeaderItemCommand() { ControlType = new string[] { "HeaderItem" }; } }
    
    /// <summary>
    /// Description of GetUiaHyperlink.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaHyperlink", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaHyperlinkCommand : GetUiaControlCommand
    { public GetUiaHyperlinkCommand() { ControlType = new string[] { "Hyperlink" }; } }
    
    /// <summary>
    /// Description of GetUiaLinkLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaLinkLabel", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaLinkLabelCommand : GetUiaHyperlinkCommand
    { public GetUiaLinkLabelCommand() { ControlType = new string[] { "Hyperlink" }; } }

    /// <summary>
    /// Description of GetUiaImage.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaImage", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaImageCommand : GetUiaControlCommand
    { public GetUiaImageCommand() { ControlType = new string[] { "Image" }; } }
    
    /// <summary>
    /// Description of GetUiaList.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaList", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaListCommand : GetUiaControlCommand
    { public GetUiaListCommand() { ControlType = new string[] { "List" }; } }
    
    /// <summary>
    /// Description of GetUiaListItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaListItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaListItemCommand : GetUiaControlCommand
    { public GetUiaListItemCommand() { ControlType = new string[] { "ListItem" }; } }
    
    /// <summary>
    /// Description of GetUiaMenu.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenu", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaMenuCommand : GetUiaControlCommand
    { public GetUiaMenuCommand() { ControlType = new string[] { "Menu" }; } }
    
    /// <summary>
    /// Description of GetUiaMenuBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenuBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaMenuBarCommand : GetUiaControlCommand
    { public GetUiaMenuBarCommand() { ControlType = new string[] { "MenuBar" }; } }

    /// <summary>
    /// Description of GetUiaMenuItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaMenuItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaMenuItemCommand : GetUiaControlCommand
    { public GetUiaMenuItemCommand() { ControlType = new string[] { "MenuItem" }; } }
    
    /// <summary>
    /// Description of GetUiaPane.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaPane", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaPaneCommand : GetUiaControlCommand
    { public GetUiaPaneCommand() { ControlType = new string[] { "Pane" }; } }
    
    /// <summary>
    /// Description of GetUiaProgressBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaProgressBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaProgressBarCommand : GetUiaControlCommand
    { public GetUiaProgressBarCommand() { ControlType = new string[] { "ProgressBar" }; } }
    
    /// <summary>
    /// Description of GetUiaRadioButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaRadioButton", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaRadioButtonCommand : GetUiaControlCommand
    { public GetUiaRadioButtonCommand() { ControlType = new string[] { "RadioButton" }; } }
    
    /// <summary>
    /// Description of GetUiaScrollBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaScrollBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaScrollBarCommand : GetUiaControlCommand
    { public GetUiaScrollBarCommand() { ControlType = new string[] { "ScrollBar" }; } }

    /// <summary>
    /// Description of GetUiaSeparator.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSeparator", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaSeparatorCommand : GetUiaControlCommand
    { public GetUiaSeparatorCommand() { ControlType = new string[] { "Separator" }; } }
    
    /// <summary>
    /// Description of GetUiaSlider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSlider", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaSliderCommand : GetUiaControlCommand
    { public GetUiaSliderCommand() { ControlType = new string[] { "Slider" }; } }
    
    /// <summary>
    /// Description of GetUiaSpinner.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSpinner", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaSpinnerCommand : GetUiaControlCommand
    { public GetUiaSpinnerCommand() { ControlType = new string[] { "Spinner" }; } }
    
    /// <summary>
    /// Description of GetUiaSplitButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaSplitButton", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaSplitButtonCommand : GetUiaControlCommand
    { public GetUiaSplitButtonCommand() { ControlType = new string[] { "SplitButton" }; } }
    
    /// <summary>
    /// Description of GetUiaStatusBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaStatusBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaStatusBarCommand : GetUiaControlCommand
    { public GetUiaStatusBarCommand() { ControlType = new string[] { "StatusBar" }; } }

    /// <summary>
    /// Description of GetUiaTab.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTab", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaTabCommand : GetUiaControlCommand
    { public GetUiaTabCommand() { ControlType = new string[] { "Tab" }; } }
    
    /// <summary>
    /// Description of GetUiaTabItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTabItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaTabItemCommand : GetUiaControlCommand
    { public GetUiaTabItemCommand() { ControlType = new string[] { "TabItem" }; } }
    
    /// <summary>
    /// Description of GetUiaTable.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTable", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaTableCommand : GetUiaControlCommand
    { public GetUiaTableCommand() { ControlType = new string[] { "Table" }; } }
    
    /// <summary>
    /// Description of GetUiaText.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaText", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaTextCommand : GetUiaControlCommand
    { public GetUiaTextCommand() { ControlType = new string[] { "Text" }; } }
    
    /// <summary>
    /// Description of GetUiaLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaLabel", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaLabelCommand : GetUiaTextCommand
    { public GetUiaLabelCommand() { ControlType = new string[] { "Text" }; } }
    
    /// <summary>
    /// Description of GetUiaThumb.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaThumb", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaThumbCommand : GetUiaControlCommand
    { public GetUiaThumbCommand() { ControlType = new string[] { "Thumb" }; } }

    /// <summary>
    /// Description of GetUiaTitleBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTitleBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaTitleBarCommand : GetUiaControlCommand
    { public GetUiaTitleBarCommand() { ControlType = new string[] { "TitleBar" }; } }
    
    /// <summary>
    /// Description of GetUiaToolBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaToolBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaToolBarCommand : GetUiaControlCommand
    { public GetUiaToolBarCommand() { ControlType = new string[] { "ToolBar" }; } }
    
    /// <summary>
    /// Description of GetUiaToolTip.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaToolTip", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaToolTipCommand : GetUiaControlCommand
    { public GetUiaToolTipCommand() { ControlType = new string[] { "ToolTip" }; } }
    
    /// <summary>
    /// Description of GetUiaTree.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTree", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaTreeCommand : GetUiaControlCommand
    { public GetUiaTreeCommand() { ControlType = new string[] { "Tree" }; } }
    
    /// <summary>
    /// Description of GetUiaTreeItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaTreeItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaTreeItemCommand : GetUiaControlCommand
    { public GetUiaTreeItemCommand() { ControlType = new string[] { "TreeItem" }; } }
    
    /// <summary>
    /// Description of GetUiaChildWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaChildWindow", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(IUiElement[]))]
    public class GetUiaChildWindowCommand : GetUiaControlCommand
    { public GetUiaChildWindowCommand() { ControlType = new string[] { "Window" }; } }
    
}
