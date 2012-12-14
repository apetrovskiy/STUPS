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
    using System;
    using System.Management.Automation;
    using UIAutomation.Commands;
    
    
//    using System.Reflection;
//    using System.Reflection.Emit;
    
    
    //using System.Management.Automation.Internal;
    
//    /// <summary>
//    /// Description of GetUIAControlCommand.
//    /// </summary>
//    public class GetUIAControlCommand
//    {
//        public GetUIAControlCommand()
//        {
//        }
//    }
    
    
    
    /// <summary>
    /// Description of GetUIAButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Button", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetButtonCommand : GetUIAButtonCommand
    { public GetButtonCommand() {} }
    
    //===========================================================================
    /// <summary>
    /// Description of GetUIAButton.
    /// </summary>
    [Cmdlet(@"Взять", @"Кнопку", DefaultParameterSetName = "UIAuto")]
    //[Cmdlet(@"Взять", typeof(int), DefaultParameterSetName = "UIAuto")]
    //[Cmdlet(@"Взять", typeof(System.Type("aaa")), DefaultParameterSetName = "UIAuto")]
    //[Cmdlet(@"Взять", typeof(System.DateTime))]
    //[Cmdlet("aaa", Preferences.temp)]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetButtonCommand1 : GetUIAButtonCommand
    { public GetButtonCommand1() {} }
    
    
    
    //===========================================================================

    /// <summary>
    /// Description of GetUIACalendar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Calendar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetCalendarCommand : GetUIACalendarCommand
    { public GetCalendarCommand() {} }
    
    /// <summary>
    /// Description of GetUIACheckBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CheckBox", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetCheckBoxCommand : GetUIACheckBoxCommand
    { public GetCheckBoxCommand() {} }
    
    /// <summary>
    /// Description of GetUIAComboBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ComboBox", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetComboBoxCommand : GetUIAComboBoxCommand
    { public GetComboBoxCommand() {} }
    
    /// <summary>
    /// Description of GetUIACustom.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Custom", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetCustomCommand : GetUIACustomCommand
    { public GetCustomCommand() {} }
    
    /// <summary>
    /// Description of GetUIADataGrid.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "DataGrid", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetDataGridCommand : GetUIADataGridCommand
    { public GetDataGridCommand() {} }
    
    /// <summary>
    /// Description of GetUIADataItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "DataItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetDataItemCommand : GetUIADataItemCommand
    { public GetDataItemCommand() {} }
    
    /// <summary>
    /// Description of GetUIADocument.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Document", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetDocumentCommand : GetUIADocumentCommand
    { public GetDocumentCommand() {} }

    /// <summary>
    /// Description of GetUIAEdit.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Edit", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetEditCommand : GetUIAEditCommand
    { public GetEditCommand() {} }
    
    /// <summary>
    /// Description of GetUIATextBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TextBox", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetTextBoxCommand : GetUIATextBoxCommand
    { public GetTextBoxCommand() {} }
    
    /// <summary>
    /// Description of GetUIAGroup.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Group", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetGroupCommand : GetUIAGroupCommand
    { public GetGroupCommand() {} }
    
    /// <summary>
    /// Description of GetUIAGroupBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "GroupBox", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetGroupBoxCommand : GetUIAGroupBoxCommand
    { public GetGroupBoxCommand() {} }
    
    /// <summary>
    /// Description of GetUIAHeader.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Header", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetHeaderCommand : GetUIAHeaderCommand
    { public GetHeaderCommand() {} }
    
    /// <summary>
    /// Description of GetUIAHeaderItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "HeaderItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetHeaderItemCommand : GetUIAHeaderItemCommand
    { public GetHeaderItemCommand() {} }
    
    /// <summary>
    /// Description of GetUIAHyperlink.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Hyperlink", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetHyperlinkCommand : GetUIAHyperlinkCommand
    { public GetHyperlinkCommand() {} }
    
    /// <summary>
    /// Description of GetUIALinkLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "LinkLabel", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetLinkLabelCommand : GetUIALinkLabelCommand
    { public GetLinkLabelCommand() {} }

    /// <summary>
    /// Description of GetUIAImage.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Image", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetImageCommand : GetUIAImageCommand
    { public GetImageCommand() {} }
    
    /// <summary>
    /// Description of GetUIAList.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "List", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetListCommand : GetUIAListCommand
    { public GetListCommand() {} }
    
    /// <summary>
    /// Description of GetUIAListItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ListItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetListItemCommand : GetUIAListItemCommand
    { public GetListItemCommand() {} }
    
    /// <summary>
    /// Description of GetUIAMenu.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Menu", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetMenuCommand : GetUIAMenuCommand
    { public GetMenuCommand() {} }
    
    /// <summary>
    /// Description of GetUIAMenuBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "MenuBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetMenuBarCommand : GetUIAMenuBarCommand
    { public GetMenuBarCommand() {} }

    /// <summary>
    /// Description of GetUIAMenuItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "MenuItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetMenuItemCommand : GetUIAMenuItemCommand
    { public GetMenuItemCommand() {} }
    
    /// <summary>
    /// Description of GetUIAPane.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Pane", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetPaneCommand : GetUIAPaneCommand
    { public GetPaneCommand() {} }
    
    /// <summary>
    /// Description of GetUIAProgressBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ProgressBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetProgressBarCommand : GetUIAProgressBarCommand
    { public GetProgressBarCommand() {} }
    
    /// <summary>
    /// Description of GetUIARadioButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "RadioButton", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetRadioButtonCommand : GetUIARadioButtonCommand
    { public GetRadioButtonCommand() {} }
    
    /// <summary>
    /// Description of GetUIAScrollBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ScrollBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetScrollBarCommand : GetUIAScrollBarCommand
    { public GetScrollBarCommand() {} }

    /// <summary>
    /// Description of GetUIASeparator.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Separator", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetSeparatorCommand : GetUIASeparatorCommand
    { public GetSeparatorCommand() {} }
    
    /// <summary>
    /// Description of GetUIASlider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Slider", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetSliderCommand : GetUIASliderCommand
    { public GetSliderCommand() {} }
    
    /// <summary>
    /// Description of GetUIASpinner.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Spinner", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetSpinnerCommand : GetUIASpinnerCommand
    { public GetSpinnerCommand() {} }
    
    /// <summary>
    /// Description of GetUIASplitButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SplitButton", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetSplitButtonCommand : GetUIASplitButtonCommand
    { public GetSplitButtonCommand() {} }
    
    /// <summary>
    /// Description of GetUIAStatusBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "StatusBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetStatusBarCommand : GetUIAStatusBarCommand
    { public GetStatusBarCommand() {} }

    /// <summary>
    /// Description of GetUIATab.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Tab", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetTabCommand : GetUIATabCommand
    { public GetTabCommand() {} }
    
    /// <summary>
    /// Description of GetUIATabItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TabItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetTabItemCommand : GetUIATabItemCommand
    { public GetTabItemCommand() {} }
    
    /// <summary>
    /// Description of GetUIATable.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Table", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetTableCommand : GetUIATableCommand
    { public GetTableCommand() {} }
    
    /// <summary>
    /// Description of GetUIAText.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Text", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetTextCommand : GetUIATextCommand
    { public GetTextCommand() {} }
    
    /// <summary>
    /// Description of GetUIALabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Label", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetLabelCommand : GetUIALabelCommand
    { public GetLabelCommand() {} }
    
    /// <summary>
    /// Description of GetUIAThumb.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Thumb", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetThumbCommand : GetUIAThumbCommand
    { public GetThumbCommand() {} }

    /// <summary>
    /// Description of GetUIATitleBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TitleBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetTitleBarCommand : GetUIATitleBarCommand
    { public GetTitleBarCommand() {} }
    
    /// <summary>
    /// Description of GetUIAToolBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ToolBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetToolBarCommand : GetUIAToolBarCommand
    { public GetToolBarCommand() {} }
    
    /// <summary>
    /// Description of GetUIAToolTip.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ToolTip", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetToolTipCommand : GetUIAToolTipCommand
    { public GetToolTipCommand() {} }
    
    /// <summary>
    /// Description of GetUIATree.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Tree", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetTreeCommand : GetUIATreeCommand
    { public GetTreeCommand() {} }
    
    /// <summary>
    /// Description of GetUIATreeItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TreeItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetTreeItemCommand : GetUIATreeItemCommand
    { public GetTreeItemCommand() {} }
    
    /// <summary>
    /// Description of GetUIAChildWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ChildWindow", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetChildWindowCommand : GetUIAChildWindowCommand
    { public GetChildWindowCommand() {} }
    
}
