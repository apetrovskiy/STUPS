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
    /// Description of WaitUIAControlIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAControlIsEnabled")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAControlIsEnabledCommand : WaitCmdletBase
    {
        #region Constructor
        public WaitUIAControlIsEnabledCommand()
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
            if (!this.CheckControl(this)) { return; }
            
            // 20120823
            foreach (AutomationElement inputObject in this.InputObject) {
            
            //System.Windows.Automation.AutomationElement _control = null;
            
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
    /// Description of WaitUIAButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAButtonIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAButtonIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAButtonIsEnabledCommand() { this.ControlType = ControlType.Button; } }

    /// <summary>
    /// Description of WaitUIACalendarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIACalendarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIACalendarIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIACalendarIsEnabledCommand() { this.ControlType = ControlType.Calendar; } }
    
    /// <summary>
    /// Description of WaitUIACheckBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIACheckBoxIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIACheckBoxIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIACheckBoxIsEnabledCommand() { this.ControlType = ControlType.CheckBox; } }
    
    /// <summary>
    /// Description of WaitUIAComboBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAComboBoxIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAComboBoxIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAComboBoxIsEnabledCommand() { this.ControlType = ControlType.ComboBox; } }
    
    /// <summary>
    /// Description of WaitUIACustomIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIACustomIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIACustomIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIACustomIsEnabledCommand() { this.ControlType = ControlType.Custom; } }
    
    /// <summary>
    /// Description of WaitUIADataGridIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIADataGridIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIADataGridIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIADataGridIsEnabledCommand() { this.ControlType = ControlType.DataGrid; } }
    
    /// <summary>
    /// Description of WaitUIADataItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIADataItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIADataItemIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIADataItemIsEnabledCommand() { this.ControlType = ControlType.DataItem; } }
    
    /// <summary>
    /// Description of WaitUIADocumentIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIADocumentIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIADocumentIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIADocumentIsEnabledCommand() { this.ControlType = ControlType.Document; } }

    /// <summary>
    /// Description of WaitUIAEditIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAEditIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAEditIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAEditIsEnabledCommand() { this.ControlType = ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUIATextBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATextBoxIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATextBoxIsEnabledCommand : WaitUIAEditIsEnabledCommand
    { public WaitUIATextBoxIsEnabledCommand() { this.ControlType = ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUIAGroupIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAGroupIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAGroupIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAGroupIsEnabledCommand() { this.ControlType = ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUIAGroupBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAGroupBoxIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAGroupBoxIsEnabledCommand : WaitUIAGroupIsEnabledCommand
    { public WaitUIAGroupBoxIsEnabledCommand() { this.ControlType = ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUIAHeaderIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAHeaderIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAHeaderIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAHeaderIsEnabledCommand() { this.ControlType = ControlType.Header; } }
    
    /// <summary>
    /// Description of WaitUIAHeaderItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAHeaderItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAHeaderItemIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAHeaderItemIsEnabledCommand() { this.ControlType = ControlType.HeaderItem; } }
    
    /// <summary>
    /// Description of WaitUIAHyperlinkIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAHyperlinkIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAHyperlinkIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAHyperlinkIsEnabledCommand() { this.ControlType = ControlType.Hyperlink; } }
    
    /// <summary>
    /// Description of WaitUIALinkLabelIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIALinkLabelIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIALinkLabelIsEnabledCommand : WaitUIAHyperlinkIsEnabledCommand
    { public WaitUIALinkLabelIsEnabledCommand() { this.ControlType = ControlType.Hyperlink; } }

    /// <summary>
    /// Description of WaitUIAImageIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAImageIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAImageIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAImageIsEnabledCommand() { this.ControlType = ControlType.Image; } }
    
    /// <summary>
    /// Description of WaitUIAListIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAListIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAListIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAListIsEnabledCommand() { this.ControlType = ControlType.List; } }
    
    /// <summary>
    /// Description of WaitUIAListItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAListItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAListItemIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAListItemIsEnabledCommand() { this.ControlType = ControlType.ListItem; } }
    
    /// <summary>
    /// Description of WaitUIAMenuIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAMenuIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAMenuIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAMenuIsEnabledCommand() { this.ControlType = ControlType.Menu; } }
    
    /// <summary>
    /// Description of WaitUIAMenuBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAMenuBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAMenuBarIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAMenuBarIsEnabledCommand() { this.ControlType = ControlType.MenuBar; } }

    /// <summary>
    /// Description of WaitUIAMenuItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAMenuItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAMenuItemIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAMenuItemIsEnabledCommand() { this.ControlType = ControlType.MenuItem; } }
    
    /// <summary>
    /// Description of WaitUIAPaneIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAPaneIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAPaneIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAPaneIsEnabledCommand() { this.ControlType = ControlType.Pane; } }
    
    /// <summary>
    /// Description of WaitUIAProgressBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAProgressBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAProgressBarIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAProgressBarIsEnabledCommand() { this.ControlType = ControlType.ProgressBar; } }
    
    /// <summary>
    /// Description of WaitUIARadioButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIARadioButtonIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIARadioButtonIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIARadioButtonIsEnabledCommand() { this.ControlType = ControlType.RadioButton; } }
    
    /// <summary>
    /// Description of WaitUIAScrollBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAScrollBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAScrollBarIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAScrollBarIsEnabledCommand() { this.ControlType = ControlType.ScrollBar; } }

    /// <summary>
    /// Description of WaitUIASeparatorIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIASeparatorIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIASeparatorIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIASeparatorIsEnabledCommand() { this.ControlType = ControlType.Separator; } }
    
    /// <summary>
    /// Description of WaitUIASliderIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIASliderIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIASliderIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIASliderIsEnabledCommand() { this.ControlType = ControlType.Slider; } }
    
    /// <summary>
    /// Description of WaitUIASpinnerIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIASpinnerIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIASpinnerIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIASpinnerIsEnabledCommand() { this.ControlType = ControlType.Spinner; } }
    
    /// <summary>
    /// Description of WaitUIASplitButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIASplitButtonIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIASplitButtonIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIASplitButtonIsEnabledCommand() { this.ControlType = ControlType.SplitButton; } }
    
    /// <summary>
    /// Description of WaitUIAStatusBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAStatusBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAStatusBarIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAStatusBarIsEnabledCommand() { this.ControlType = ControlType.StatusBar; } }

    /// <summary>
    /// Description of WaitUIATabIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATabIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATabIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIATabIsEnabledCommand() { this.ControlType = ControlType.Tab; } }
    
    /// <summary>
    /// Description of WaitUIATabItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATabItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATabItemIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIATabItemIsEnabledCommand() { this.ControlType = ControlType.TabItem; } }
    
    /// <summary>
    /// Description of WaitUIATableIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATableIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATableIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIATableIsEnabledCommand() { this.ControlType = ControlType.Table; } }
    
    /// <summary>
    /// Description of WaitUIATextIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATextIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATextIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIATextIsEnabledCommand() { this.ControlType = ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUIALabelIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIALabelIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIALabelIsEnabledCommand : WaitUIATextIsEnabledCommand
    { public WaitUIALabelIsEnabledCommand() { this.ControlType = ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUIAThumbIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAThumbIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAThumbIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAThumbIsEnabledCommand() { this.ControlType = ControlType.Thumb; } }

    /// <summary>
    /// Description of WaitUIATitleBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATitleBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATitleBarIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIATitleBarIsEnabledCommand() { this.ControlType = ControlType.TitleBar; } }
    
    /// <summary>
    /// Description of WaitUIAToolBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAToolBarIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAToolBarIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAToolBarIsEnabledCommand() { this.ControlType = ControlType.ToolBar; } }
    
    /// <summary>
    /// Description of WaitUIAToolTipIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAToolTipIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAToolTipIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAToolTipIsEnabledCommand() { this.ControlType = ControlType.ToolTip; } }
    
    /// <summary>
    /// Description of WaitUIATreeIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATreeIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATreeIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIATreeIsEnabledCommand() { this.ControlType = ControlType.Tree; } }
    
    /// <summary>
    /// Description of WaitUIATreeItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATreeItemIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATreeItemIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIATreeItemIsEnabledCommand() { this.ControlType = ControlType.TreeItem; } }
    
    /// <summary>
    /// Description of WaitUIAChildWindowIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAChildWindowIsEnabled")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAChildWindowIsEnabledCommand : WaitUIAControlIsEnabledCommand
    { public WaitUIAChildWindowIsEnabledCommand() { this.ControlType = ControlType.Window; } }
    
}
