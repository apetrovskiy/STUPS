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
    [Cmdlet(VerbsCommon.Get, "UIAControl", DefaultParameterSetName = "UIAuto")]
    // 20120828
    //[OutputType(typeof(object))]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlCommand : GetControlCmdletBase
    {
        #region Constructor
        public GetUIAControlCommand()
        {
            //WriteVerbose(this, "constructor");
        }
        #endregion Constructor

        #region Parameters
//        [Parameter (Mandatory = false)]
//        public SwitchParameter FromCache { get; set; }
        #endregion Parameters

        protected override void BeginProcessing() {
            //WriteVerbose(this, "BeginProcessing()");
            startDate = System.DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord() 
        {
            if (!this.CheckControl(this)) { return; }

            this.WriteVerbose(this, "getting the control");
            
            // 20120830
            ArrayList returnCollection = 
                getControl(this);
            
            if (null == returnCollection || 0 == returnCollection.Count) {
                
                // 20120927
//                ErrorRecord err = 
//                    new ErrorRecord(
//                        new Exception(),
//                        "ControlIsNull",
//                        ErrorCategory.OperationTimeout,
//                        aeCtrl);
//                
//                err.ErrorDetails =
//                    new ErrorDetails(
//                        CmdletSignature(this) + "timeout expired for class: ' + " +
//                        this.Class + 
//                        ", control type: " + 
//                        this.ControlType + 
//                        ", title: " +
//                        this.Name);
//                        // cmdlet.Title);
//
//                // 20120921
//                //UIAHelper.GetDesktopScreenshot(this, "Get-UIAControl_ControlEqNull", true, 0, 0, 0, 0, Preferences.ScreenShotFolder); //string.Empty);
//                UIAHelper.GetScreenshotOfAutomationElement(this, "Get-UIAControl_ControlEqNull", true, 0, 0, 0, 0, string.Empty, System.Drawing.Imaging.ImageFormat.Jpeg);
//
//                this.WriteError(this, err, true);
                
                this.WriteError(
                    this,
                    CmdletSignature(this) + "timeout expired for class: ' + " +
                    this.Class + 
                    ", control type: " + 
                    this.ControlType + 
                    ", title: " +
                    this.Name,
                    "ControlIsNull",
                    ErrorCategory.OperationTimeout,
                    true);

                return; // ?

            }
            // 20120824
            //if (returnValue != null) {
            // 20120830
            //if (returnCollection != null) {
            if (null != returnCollection && 0 < returnCollection.Count) {
                // 20120824
                //WriteObject(this, returnValue);
                
                // 20120917
                this.WriteObject(this, returnCollection);
                
#region commented
                // 20120828
//                ArrayList filteredElements = 
//                    new ArrayList();
//                if (null != this.SearchCriteria && this.SearchCriteria.Length > 0) {
//                    filteredElements = 
//                        getFiltredElementsCollection(this, returnCollection);
//                    this.WriteObject(this, filteredElements);
//                } else {
//                    this.WriteObject(this, returnCollection);
//                }
#endregion commented
            } else {
                // 20120830
                //WriteObject(this, (object)null);
                
            }
        }
        
#region commented
//        protected override void EndProcessing()
//        {
//            aeCtrl = null;
//            //_window = null;
//            rootElement = null;
//        }
        
//        protected override void StopProcessing()
//        {
//            // 20120620
//            WriteVerbose(this, "User interrupted");
//            this.Wait = false;
//        }
#endregion commented
    }
    
#region commented
//    /// <summary>
//    /// Description of GetUIAButton.
//    /// </summary>
//    //[Cmdlet(VerbsCommon.Get, "UIAControlFilter")]
//    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
//    public class GetUIAControlFilterCommand : GetUIAControlCommand
//    { public GetUIAControlFilterCommand() {} // ControlType = "Button"; }
////        [Parameter(Mandatory = false,
////                   ParameterSetName = "UIAuto")]
////        internal string ControlType { get; set; }
//    }
#endregion commented

    /// <summary>
    /// Description of GetUIAButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAButton", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAButtonCommand : GetUIAControlCommand
    { public GetUIAButtonCommand() { ControlType = "Button"; } }

    /// <summary>
    /// Description of GetUIACalendar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACalendar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACalendarCommand : GetUIAControlCommand
    { public GetUIACalendarCommand() { ControlType = "Calendar"; } }
    
    /// <summary>
    /// Description of GetUIACheckBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACheckBox", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACheckBoxCommand : GetUIAControlCommand
    { public GetUIACheckBoxCommand() { ControlType = "CheckBox"; } }
    
    /// <summary>
    /// Description of GetUIAComboBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAComboBox", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAComboBoxCommand : GetUIAControlCommand
    { public GetUIAComboBoxCommand() { ControlType = "ComboBox"; } }
    
    /// <summary>
    /// Description of GetUIACustom.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIACustom", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIACustomCommand : GetUIAControlCommand
    { public GetUIACustomCommand() { ControlType = "Custom"; } }
    
    /// <summary>
    /// Description of GetUIADataGrid.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADataGrid", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADataGridCommand : GetUIAControlCommand
    { public GetUIADataGridCommand() { ControlType = "DataGrid"; } }
    
    /// <summary>
    /// Description of GetUIADataItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADataItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADataItemCommand : GetUIAControlCommand
    { public GetUIADataItemCommand() { ControlType = "DataItem"; } }
    
    /// <summary>
    /// Description of GetUIADocument.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADocument", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADocumentCommand : GetUIAControlCommand
    { public GetUIADocumentCommand() { ControlType = "Document"; } }

    /// <summary>
    /// Description of GetUIAEdit.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAEdit", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAEditCommand : GetUIAControlCommand
    { public GetUIAEditCommand() { ControlType = "Edit"; } }
    
    /// <summary>
    /// Description of GetUIATextBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextBox", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextBoxCommand : GetUIAEditCommand
    { public GetUIATextBoxCommand() { ControlType = "Edit"; } }
    
    /// <summary>
    /// Description of GetUIAGroup.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAGroup", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAGroupCommand : GetUIAControlCommand
    { public GetUIAGroupCommand() { ControlType = "Group"; } }
    
    /// <summary>
    /// Description of GetUIAGroupBox.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAGroupBox", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAGroupBoxCommand : GetUIAGroupCommand
    { public GetUIAGroupBoxCommand() { ControlType = "Group"; } }
    
    /// <summary>
    /// Description of GetUIAHeader.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAHeader", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAHeaderCommand : GetUIAControlCommand
    { public GetUIAHeaderCommand() { ControlType = "Header"; } }
    
    /// <summary>
    /// Description of GetUIAHeaderItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAHeaderItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAHeaderItemCommand : GetUIAControlCommand
    { public GetUIAHeaderItemCommand() { ControlType = "HeaderItem"; } }
    
    /// <summary>
    /// Description of GetUIAHyperlink.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAHyperlink", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAHyperlinkCommand : GetUIAControlCommand
    { public GetUIAHyperlinkCommand() { ControlType = "Hyperlink"; } }
    
    /// <summary>
    /// Description of GetUIALinkLabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIALinkLabel", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIALinkLabelCommand : GetUIAHyperlinkCommand
    { public GetUIALinkLabelCommand() { ControlType = "Hyperlink"; } }

    /// <summary>
    /// Description of GetUIAImage.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAImage", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAImageCommand : GetUIAControlCommand
    { public GetUIAImageCommand() { ControlType = "Image"; } }
    
    /// <summary>
    /// Description of GetUIAList.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAList", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAListCommand : GetUIAControlCommand
    { public GetUIAListCommand() { ControlType = "List"; } }
    
    /// <summary>
    /// Description of GetUIAListItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAListItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAListItemCommand : GetUIAControlCommand
    { public GetUIAListItemCommand() { ControlType = "ListItem"; } }
    
    /// <summary>
    /// Description of GetUIAMenu.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenu", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAMenuCommand : GetUIAControlCommand
    { public GetUIAMenuCommand() { ControlType = "Menu"; } }
    
    /// <summary>
    /// Description of GetUIAMenuBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenuBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAMenuBarCommand : GetUIAControlCommand
    { public GetUIAMenuBarCommand() { ControlType = "MenuBar"; } }

    /// <summary>
    /// Description of GetUIAMenuItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAMenuItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAMenuItemCommand : GetUIAControlCommand
    { public GetUIAMenuItemCommand() { ControlType = "MenuItem"; } }
    
    /// <summary>
    /// Description of GetUIAPane.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAPane", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAPaneCommand : GetUIAControlCommand
    { public GetUIAPaneCommand() { ControlType = "Pane"; } }
    
    /// <summary>
    /// Description of GetUIAProgressBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAProgressBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAProgressBarCommand : GetUIAControlCommand
    { public GetUIAProgressBarCommand() { ControlType = "ProgressBar"; } }
    
    /// <summary>
    /// Description of GetUIARadioButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIARadioButton", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIARadioButtonCommand : GetUIAControlCommand
    { public GetUIARadioButtonCommand() { ControlType = "RadioButton"; } }
    
    /// <summary>
    /// Description of GetUIAScrollBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAScrollBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAScrollBarCommand : GetUIAControlCommand
    { public GetUIAScrollBarCommand() { ControlType = "ScrollBar"; } }

    /// <summary>
    /// Description of GetUIASeparator.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASeparator", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASeparatorCommand : GetUIAControlCommand
    { public GetUIASeparatorCommand() { ControlType = "Separator"; } }
    
    /// <summary>
    /// Description of GetUIASlider.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASlider", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASliderCommand : GetUIAControlCommand
    { public GetUIASliderCommand() { ControlType = "Slider"; } }
    
    /// <summary>
    /// Description of GetUIASpinner.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASpinner", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASpinnerCommand : GetUIAControlCommand
    { public GetUIASpinnerCommand() { ControlType = "Spinner"; } }
    
    /// <summary>
    /// Description of GetUIASplitButton.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIASplitButton", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIASplitButtonCommand : GetUIAControlCommand
    { public GetUIASplitButtonCommand() { ControlType = "SplitButton"; } }
    
    /// <summary>
    /// Description of GetUIAStatusBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAStatusBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAStatusBarCommand : GetUIAControlCommand
    { public GetUIAStatusBarCommand() { ControlType = "StatusBar"; } }

    /// <summary>
    /// Description of GetUIATab.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATab", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATabCommand : GetUIAControlCommand
    { public GetUIATabCommand() { ControlType = "Tab"; } }
    
    /// <summary>
    /// Description of GetUIATabItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATabItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATabItemCommand : GetUIAControlCommand
    { public GetUIATabItemCommand() { ControlType = "TabItem"; } }
    
    /// <summary>
    /// Description of GetUIATable.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATable", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATableCommand : GetUIAControlCommand
    { public GetUIATableCommand() { ControlType = "Table"; } }
    
    /// <summary>
    /// Description of GetUIAText.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAText", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextCommand : GetUIAControlCommand
    { public GetUIATextCommand() { ControlType = "Text"; } }
    
    /// <summary>
    /// Description of GetUIALabel.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIALabel", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIALabelCommand : GetUIATextCommand
    { public GetUIALabelCommand() { ControlType = "Text"; } }
    
    /// <summary>
    /// Description of GetUIAThumb.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAThumb", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAThumbCommand : GetUIAControlCommand
    { public GetUIAThumbCommand() { ControlType = "Thumb"; } }

    /// <summary>
    /// Description of GetUIATitleBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATitleBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATitleBarCommand : GetUIAControlCommand
    { public GetUIATitleBarCommand() { ControlType = "TitleBar"; } }
    
    /// <summary>
    /// Description of GetUIAToolBar.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAToolBar", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAToolBarCommand : GetUIAControlCommand
    { public GetUIAToolBarCommand() { ControlType = "ToolBar"; } }
    
    /// <summary>
    /// Description of GetUIAToolTip.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAToolTip", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAToolTipCommand : GetUIAControlCommand
    { public GetUIAToolTipCommand() { ControlType = "ToolTip"; } }
    
    /// <summary>
    /// Description of GetUIATree.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATree", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATreeCommand : GetUIAControlCommand
    { public GetUIATreeCommand() { ControlType = "Tree"; } }
    
    /// <summary>
    /// Description of GetUIATreeItem.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATreeItem", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATreeItemCommand : GetUIAControlCommand
    { public GetUIATreeItemCommand() { ControlType = "TreeItem"; } }
    
    /// <summary>
    /// Description of GetUIAChildWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAChildWindow", DefaultParameterSetName = "UIAuto")]
    [OutputType(typeof(System.Windows.Automation.AutomationElement[]))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAChildWindowCommand : GetUIAControlCommand
    { public GetUIAChildWindowCommand() { ControlType = "Window"; } }
    
}
