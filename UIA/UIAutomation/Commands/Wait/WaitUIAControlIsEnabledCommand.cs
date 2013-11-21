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

    /// <summary>
    /// Description of WaitUiaControlIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaControlIsEnabled")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaControlIsEnabledCommand : WaitCmdletBase
    {
        #region Constructor
        public WaitUiaControlIsEnabledCommand()
        {
            this.ControlType = null;
        }
        #endregion Constructor

        #region Parameters
        #endregion Parameters

        // 20120206 private System.DateTime startDate;
        protected ControlType ControlType { get; set; }

        protected override void BeginProcessing() {
//            WriteVerbose(this, "Timeout " + Timeout.ToString());
//            try {
//                this.ControlType =
//                    this.InputObject.Current.ControlType;
//            } catch { }
//            
//            if (this.InputObject != null && 
//                (int)this.InputObject.Current.ProcessId > 0 &&
//                this.InputObject.Current.ControlType != null) {
//                WriteVerbose(this, "ControlType " + 
//                             this.ControlType.ProgrammaticName);
//            }
            StartDate = System.DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord() {
            if (!this.CheckAndPrepareInput(this)) { return; }
            
            // 20120823
            // 20131109
            //foreach (AutomationElement inputObject in this.InputObject) {
            foreach (IMySuperWrapper inputObject in this.InputObject) {
            
            //System.Windows.Automation.AutomationElement _control = null;
            
            if (!Equals(this.ControlType, inputObject.Current.ControlType)) {
                
                this.WriteError(
                    this,
                    "Control is not of " +
                     this.ControlType.ProgrammaticName +
                     " type",
                    "WrongControlType",
                    ErrorCategory.InvalidArgument,
                    true);
                
            }

            /*
            if (this.ControlType != inputObject.Current.ControlType) {
                
                this.WriteError(
                    this,
                    "Control is not of " +
                     this.ControlType.ProgrammaticName +
                     " type",
                    "WrongControlType",
                    ErrorCategory.InvalidArgument,
                    true);
                
            }
            */

            // moved 20120620
            //this.WaitIfCondition(_control, true);
            // 20120823
            //this.WaitIfCondition(this.InputObject, true);
            // 20130128
            //this.WaitIfCondition(inputObject, true);
            try {
                this.WaitIfCondition(inputObject, true);
            }
            catch (Exception eWaitIfCondition) {
                this.WriteError(
                    this,
                    "Failed to get enabled control. " +
                    eWaitIfCondition.Message,
                    "FailedToGetEnabledControl",
                    ErrorCategory.InvalidOperation,
                    true);
            }

            WriteObject(this, inputObject);
            
            } // 20120823
            
        }
        
//        protected override void StopProcessing()
//        {
//            // 20120620
//            WriteVerbose(this, "User interrupted");
//            this.Wait = false;
//        }
    }
    
    /// <summary>
    /// Description of WaitUiaButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaButtonIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaButtonIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaButtonIsEnabledCommand() { this.ControlType = ControlType.Button; } }

    /// <summary>
    /// Description of WaitUiaCalendarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCalendarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaCalendarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaCalendarIsEnabledCommand() { this.ControlType = ControlType.Calendar; } }
    
    /// <summary>
    /// Description of WaitUiaCheckBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCheckBoxIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaCheckBoxIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaCheckBoxIsEnabledCommand() { this.ControlType = ControlType.CheckBox; } }
    
    /// <summary>
    /// Description of WaitUiaComboBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaComboBoxIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaComboBoxIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaComboBoxIsEnabledCommand() { this.ControlType = ControlType.ComboBox; } }
    
    /// <summary>
    /// Description of WaitUiaCustomIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCustomIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaCustomIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaCustomIsEnabledCommand() { this.ControlType = ControlType.Custom; } }
    
    /// <summary>
    /// Description of WaitUiaDataGridIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDataGridIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaDataGridIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaDataGridIsEnabledCommand() { this.ControlType = ControlType.DataGrid; } }
    
    /// <summary>
    /// Description of WaitUiaDataItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDataItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaDataItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaDataItemIsEnabledCommand() { this.ControlType = ControlType.DataItem; } }
    
    /// <summary>
    /// Description of WaitUiaDocumentIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDocumentIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaDocumentIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaDocumentIsEnabledCommand() { this.ControlType = ControlType.Document; } }

    /// <summary>
    /// Description of WaitUiaEditIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaEditIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaEditIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaEditIsEnabledCommand() { this.ControlType = ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUiaTextBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTextBoxIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTextBoxIsEnabledCommand : WaitUiaEditIsEnabledCommand
    { public WaitUiaTextBoxIsEnabledCommand() { this.ControlType = ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUiaGroupIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaGroupIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaGroupIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaGroupIsEnabledCommand() { this.ControlType = ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUiaGroupBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaGroupBoxIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaGroupBoxIsEnabledCommand : WaitUiaGroupIsEnabledCommand
    { public WaitUiaGroupBoxIsEnabledCommand() { this.ControlType = ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUiaHeaderIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHeaderIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaHeaderIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaHeaderIsEnabledCommand() { this.ControlType = ControlType.Header; } }
    
    /// <summary>
    /// Description of WaitUiaHeaderItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHeaderItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaHeaderItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaHeaderItemIsEnabledCommand() { this.ControlType = ControlType.HeaderItem; } }
    
    /// <summary>
    /// Description of WaitUiaHyperlinkIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHyperlinkIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaHyperlinkIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaHyperlinkIsEnabledCommand() { this.ControlType = ControlType.Hyperlink; } }
    
    /// <summary>
    /// Description of WaitUiaLinkLabelIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaLinkLabelIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaLinkLabelIsEnabledCommand : WaitUiaHyperlinkIsEnabledCommand
    { public WaitUiaLinkLabelIsEnabledCommand() { this.ControlType = ControlType.Hyperlink; } }

    /// <summary>
    /// Description of WaitUiaImageIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaImageIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaImageIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaImageIsEnabledCommand() { this.ControlType = ControlType.Image; } }
    
    /// <summary>
    /// Description of WaitUiaListIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaListIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaListIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaListIsEnabledCommand() { this.ControlType = ControlType.List; } }
    
    /// <summary>
    /// Description of WaitUiaListItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaListItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaListItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaListItemIsEnabledCommand() { this.ControlType = ControlType.ListItem; } }
    
    /// <summary>
    /// Description of WaitUiaMenuIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaMenuIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaMenuIsEnabledCommand() { this.ControlType = ControlType.Menu; } }
    
    /// <summary>
    /// Description of WaitUiaMenuBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaMenuBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaMenuBarIsEnabledCommand() { this.ControlType = ControlType.MenuBar; } }

    /// <summary>
    /// Description of WaitUiaMenuItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaMenuItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaMenuItemIsEnabledCommand() { this.ControlType = ControlType.MenuItem; } }
    
    /// <summary>
    /// Description of WaitUiaPaneIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaPaneIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaPaneIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaPaneIsEnabledCommand() { this.ControlType = ControlType.Pane; } }
    
    /// <summary>
    /// Description of WaitUiaProgressBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaProgressBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaProgressBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaProgressBarIsEnabledCommand() { this.ControlType = ControlType.ProgressBar; } }
    
    /// <summary>
    /// Description of WaitUiaRadioButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaRadioButtonIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaRadioButtonIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaRadioButtonIsEnabledCommand() { this.ControlType = ControlType.RadioButton; } }
    
    /// <summary>
    /// Description of WaitUiaScrollBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaScrollBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaScrollBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaScrollBarIsEnabledCommand() { this.ControlType = ControlType.ScrollBar; } }

    /// <summary>
    /// Description of WaitUiaSeparatorIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSeparatorIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaSeparatorIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaSeparatorIsEnabledCommand() { this.ControlType = ControlType.Separator; } }
    
    /// <summary>
    /// Description of WaitUiaSliderIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSliderIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaSliderIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaSliderIsEnabledCommand() { this.ControlType = ControlType.Slider; } }
    
    /// <summary>
    /// Description of WaitUiaSpinnerIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSpinnerIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaSpinnerIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaSpinnerIsEnabledCommand() { this.ControlType = ControlType.Spinner; } }
    
    /// <summary>
    /// Description of WaitUiaSplitButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSplitButtonIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaSplitButtonIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaSplitButtonIsEnabledCommand() { this.ControlType = ControlType.SplitButton; } }
    
    /// <summary>
    /// Description of WaitUiaStatusBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaStatusBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaStatusBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaStatusBarIsEnabledCommand() { this.ControlType = ControlType.StatusBar; } }

    /// <summary>
    /// Description of WaitUiaTabIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTabIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTabIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTabIsEnabledCommand() { this.ControlType = ControlType.Tab; } }
    
    /// <summary>
    /// Description of WaitUiaTabItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTabItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTabItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTabItemIsEnabledCommand() { this.ControlType = ControlType.TabItem; } }
    
    /// <summary>
    /// Description of WaitUiaTableIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTableIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTableIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTableIsEnabledCommand() { this.ControlType = ControlType.Table; } }
    
    /// <summary>
    /// Description of WaitUiaTextIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTextIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTextIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTextIsEnabledCommand() { this.ControlType = ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUiaLabelIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaLabelIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaLabelIsEnabledCommand : WaitUiaTextIsEnabledCommand
    { public WaitUiaLabelIsEnabledCommand() { this.ControlType = ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUiaThumbIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaThumbIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaThumbIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaThumbIsEnabledCommand() { this.ControlType = ControlType.Thumb; } }

    /// <summary>
    /// Description of WaitUiaTitleBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTitleBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTitleBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTitleBarIsEnabledCommand() { this.ControlType = ControlType.TitleBar; } }
    
    /// <summary>
    /// Description of WaitUiaToolBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaToolBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaToolBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaToolBarIsEnabledCommand() { this.ControlType = ControlType.ToolBar; } }
    
    /// <summary>
    /// Description of WaitUiaToolTipIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaToolTipIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaToolTipIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaToolTipIsEnabledCommand() { this.ControlType = ControlType.ToolTip; } }
    
    /// <summary>
    /// Description of WaitUiaTreeIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTreeIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTreeIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTreeIsEnabledCommand() { this.ControlType = ControlType.Tree; } }
    
    /// <summary>
    /// Description of WaitUiaTreeItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTreeItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaTreeItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTreeItemIsEnabledCommand() { this.ControlType = ControlType.TreeItem; } }
    
    /// <summary>
    /// Description of WaitUiaChildWindowIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaChildWindowIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUiaChildWindowIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaChildWindowIsEnabledCommand() { this.ControlType = ControlType.Window; } }
    
}
