/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/17/2012
 * Time: 10:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationAliases.Commands.Get
{
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    
//    using System.Reflection;
//    using System.Reflection.Emit;
    
    
    //using System.Management.Automation.Internal;
    
//    /// <summary>
//    /// Description of GetUiaControlCommand.
//    /// </summary>
//    public class GetUiaControlCommand
//    {
//        public GetUiaControlCommand()
//        {
//        }
//    }
    
    
    
    /// <summary>
    /// Description of GetUiaButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Button", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetButtonCommand : GetUiaButtonCommand
    { public GetButtonCommand() {} }
    
    //===========================================================================
    /// <summary>
    /// Description of GetUiaButton.
    /// </summary>
    [Cmdlet(@"Взять", @"Кнопку", DefaultParameterSetName = "UiaWildCard")]
    //[Cmdlet(@"Взять", typeof(int), DefaultParameterSetName = "UiaWildCard")]
    //[Cmdlet(@"Взять", typeof(System.Type("aaa")), DefaultParameterSetName = "UiaWildCard")]
    //[Cmdlet(@"Взять", typeof(System.DateTime))]
    //[Cmdlet("aaa", Preferences.temp)]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetButtonCommand1 : GetUiaButtonCommand
    { public GetButtonCommand1() {} }
    
    
    
    //===========================================================================

    /// <summary>
    /// Description of GetUiaCalendar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Calendar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetCalendarCommand : GetUiaCalendarCommand
    { public GetCalendarCommand() {} }
    
    /// <summary>
    /// Description of GetUiaCheckBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CheckBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetCheckBoxCommand : GetUiaCheckBoxCommand
    { public GetCheckBoxCommand() {} }
    
    /// <summary>
    /// Description of GetUiaComboBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ComboBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetComboBoxCommand : GetUiaComboBoxCommand
    { public GetComboBoxCommand() {} }
    
    /// <summary>
    /// Description of GetUiaCustom.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Custom", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetCustomCommand : GetUiaCustomCommand
    { public GetCustomCommand() {} }
    
    /// <summary>
    /// Description of GetUiaDataGrid.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "DataGrid", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetDataGridCommand : GetUiaDataGridCommand
    { public GetDataGridCommand() {} }
    
    /// <summary>
    /// Description of GetUiaDataItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "DataItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetDataItemCommand : GetUiaDataItemCommand
    { public GetDataItemCommand() {} }
    
    /// <summary>
    /// Description of GetUiaDocument.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Document", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetDocumentCommand : GetUiaDocumentCommand
    { public GetDocumentCommand() {} }

    /// <summary>
    /// Description of GetUiaEdit.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Edit", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetEditCommand : GetUiaEditCommand
    { public GetEditCommand() {} }
    
    /// <summary>
    /// Description of GetUiaTextBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TextBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetTextBoxCommand : GetUiaTextBoxCommand
    { public GetTextBoxCommand() {} }
    
    /// <summary>
    /// Description of GetUiaGroup.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Group", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetGroupCommand : GetUiaGroupCommand
    { public GetGroupCommand() {} }
    
    /// <summary>
    /// Description of GetUiaGroupBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GroupBox", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetGroupBoxCommand : GetUiaGroupBoxCommand
    { public GetGroupBoxCommand() {} }
    
    /// <summary>
    /// Description of GetUiaHeader.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Header", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetHeaderCommand : GetUiaHeaderCommand
    { public GetHeaderCommand() {} }
    
    /// <summary>
    /// Description of GetUiaHeaderItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "HeaderItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetHeaderItemCommand : GetUiaHeaderItemCommand
    { public GetHeaderItemCommand() {} }
    
    /// <summary>
    /// Description of GetUiaHyperlink.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Hyperlink", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetHyperlinkCommand : GetUiaHyperlinkCommand
    { public GetHyperlinkCommand() {} }
    
    /// <summary>
    /// Description of GetUiaLinkLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "LinkLabel", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetLinkLabelCommand : GetUiaLinkLabelCommand
    { public GetLinkLabelCommand() {} }

    /// <summary>
    /// Description of GetUiaImage.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Image", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetImageCommand : GetUiaImageCommand
    { public GetImageCommand() {} }
    
    /// <summary>
    /// Description of GetUiaList.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "List", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetListCommand : GetUiaListCommand
    { public GetListCommand() {} }
    
    /// <summary>
    /// Description of GetUiaListItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ListItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetListItemCommand : GetUiaListItemCommand
    { public GetListItemCommand() {} }
    
    /// <summary>
    /// Description of GetUiaMenu.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Menu", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetMenuCommand : GetUiaMenuCommand
    { public GetMenuCommand() {} }
    
    /// <summary>
    /// Description of GetUiaMenuBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "MenuBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetMenuBarCommand : GetUiaMenuBarCommand
    { public GetMenuBarCommand() {} }

    /// <summary>
    /// Description of GetUiaMenuItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "MenuItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetMenuItemCommand : GetUiaMenuItemCommand
    { public GetMenuItemCommand() {} }
    
    /// <summary>
    /// Description of GetUiaPane.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Pane", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetPaneCommand : GetUiaPaneCommand
    { public GetPaneCommand() {} }
    
    /// <summary>
    /// Description of GetUiaProgressBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ProgressBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetProgressBarCommand : GetUiaProgressBarCommand
    { public GetProgressBarCommand() {} }
    
    /// <summary>
    /// Description of GetUiaRadioButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "RadioButton", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetRadioButtonCommand : GetUiaRadioButtonCommand
    { public GetRadioButtonCommand() {} }
    
    /// <summary>
    /// Description of GetUiaScrollBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ScrollBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetScrollBarCommand : GetUiaScrollBarCommand
    { public GetScrollBarCommand() {} }

    /// <summary>
    /// Description of GetUiaSeparator.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Separator", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetSeparatorCommand : GetUiaSeparatorCommand
    { public GetSeparatorCommand() {} }
    
    /// <summary>
    /// Description of GetUiaSlider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Slider", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetSliderCommand : GetUiaSliderCommand
    { public GetSliderCommand() {} }
    
    /// <summary>
    /// Description of GetUiaSpinner.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Spinner", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetSpinnerCommand : GetUiaSpinnerCommand
    { public GetSpinnerCommand() {} }
    
    /// <summary>
    /// Description of GetUiaSplitButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SplitButton", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetSplitButtonCommand : GetUiaSplitButtonCommand
    { public GetSplitButtonCommand() {} }
    
    /// <summary>
    /// Description of GetUiaStatusBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "StatusBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetStatusBarCommand : GetUiaStatusBarCommand
    { public GetStatusBarCommand() {} }

    /// <summary>
    /// Description of GetUiaTab.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Tab", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetTabCommand : GetUiaTabCommand
    { public GetTabCommand() {} }
    
    /// <summary>
    /// Description of GetUiaTabItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TabItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetTabItemCommand : GetUiaTabItemCommand
    { public GetTabItemCommand() {} }
    
    /// <summary>
    /// Description of GetUiaTable.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Table", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetTableCommand : GetUiaTableCommand
    { public GetTableCommand() {} }
    
    /// <summary>
    /// Description of GetUiaText.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Text", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetTextCommand : GetUiaTextCommand
    { public GetTextCommand() {} }
    
    /// <summary>
    /// Description of GetUiaLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Label", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetLabelCommand : GetUiaLabelCommand
    { public GetLabelCommand() {} }
    
    /// <summary>
    /// Description of GetUiaThumb.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Thumb", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetThumbCommand : GetUiaThumbCommand
    { public GetThumbCommand() {} }

    /// <summary>
    /// Description of GetUiaTitleBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TitleBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetTitleBarCommand : GetUiaTitleBarCommand
    { public GetTitleBarCommand() {} }
    
    /// <summary>
    /// Description of GetUiaToolBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ToolBar", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetToolBarCommand : GetUiaToolBarCommand
    { public GetToolBarCommand() {} }
    
    /// <summary>
    /// Description of GetUiaToolTip.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ToolTip", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetToolTipCommand : GetUiaToolTipCommand
    { public GetToolTipCommand() {} }
    
    /// <summary>
    /// Description of GetUiaTree.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Tree", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetTreeCommand : GetUiaTreeCommand
    { public GetTreeCommand() {} }
    
    /// <summary>
    /// Description of GetUiaTreeItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TreeItem", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetTreeItemCommand : GetUiaTreeItemCommand
    { public GetTreeItemCommand() {} }
    
    /// <summary>
    /// Description of GetUiaChildWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ChildWindow", DefaultParameterSetName = "UiaWildCard")]
    [OutputType(typeof(UIAutomation.UiElement[]))] // [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    
    public class GetChildWindowCommand : GetUiaChildWindowCommand
    { public GetChildWindowCommand() {} }
    
}
