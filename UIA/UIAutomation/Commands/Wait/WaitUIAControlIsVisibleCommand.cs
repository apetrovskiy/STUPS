/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 6/20/2012
 * Time: 12:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of WaitUIAControlIsVisibleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAControlIsVisible")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAControlIsVisibleCommand : WaitCmdletBase
    {
//        public WaitUIAControlIsVisibleCommand()
//        {
//        }
        
        #region Constructor
        public WaitUIAControlIsVisibleCommand()
        {
            this.ControlType = null;
        }
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        protected ControlType ControlType { get; set; }
        
        // copy paste from the IsEnabled cmdlet
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
            
            // 20120823
            //if (this.ControlType != this.InputObject.Current.ControlType) {
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

            //this.WaitIfCondition(_control, false);
            // 20120823
            //this.WaitIfCondition(this.InputObject, false);
            this.WaitIfCondition(inputObject, false);
           
            //WriteObject(this, _control);
            // 20130105
            //WriteObject(this, this.InputObject);
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
    /// Description of WaitUIAButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAButtonIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAButtonIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAButtonIsVisibleCommand() { this.ControlType = ControlType.Button; } }

    /// <summary>
    /// Description of WaitUIACalendarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIACalendarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIACalendarIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIACalendarIsVisibleCommand() { this.ControlType = ControlType.Calendar; } }
    
    /// <summary>
    /// Description of WaitUIACheckBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIACheckBoxIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIACheckBoxIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIACheckBoxIsVisibleCommand() { this.ControlType = ControlType.CheckBox; } }
    
    /// <summary>
    /// Description of WaitUIAComboBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAComboBoxIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAComboBoxIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAComboBoxIsVisibleCommand() { this.ControlType = ControlType.ComboBox; } }
    
    /// <summary>
    /// Description of WaitUIACustomIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIACustomIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIACustomIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIACustomIsVisibleCommand() { this.ControlType = ControlType.Custom; } }
    
    /// <summary>
    /// Description of WaitUIADataGridIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIADataGridIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIADataGridIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIADataGridIsVisibleCommand() { this.ControlType = ControlType.DataGrid; } }
    
    /// <summary>
    /// Description of WaitUIADataItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIADataItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIADataItemIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIADataItemIsVisibleCommand() { this.ControlType = ControlType.DataItem; } }
    
    /// <summary>
    /// Description of WaitUIADocumentIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIADocumentIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIADocumentIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIADocumentIsVisibleCommand() { this.ControlType = ControlType.Document; } }

    /// <summary>
    /// Description of WaitUIAEditIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAEditIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAEditIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAEditIsVisibleCommand() { this.ControlType = ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUIATextBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATextBoxIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATextBoxIsVisibleCommand : WaitUIAEditIsVisibleCommand
    { public WaitUIATextBoxIsVisibleCommand() { this.ControlType = ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUIAGroupIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAGroupIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAGroupIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAGroupIsVisibleCommand() { this.ControlType = ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUIAGroupBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAGroupBoxIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAGroupBoxIsVisibleCommand : WaitUIAGroupIsVisibleCommand
    { public WaitUIAGroupBoxIsVisibleCommand() { this.ControlType = ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUIAHeaderIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAHeaderIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAHeaderIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAHeaderIsVisibleCommand() { this.ControlType = ControlType.Header; } }
    
    /// <summary>
    /// Description of WaitUIAHeaderItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAHeaderItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAHeaderItemIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAHeaderItemIsVisibleCommand() { this.ControlType = ControlType.HeaderItem; } }
    
    /// <summary>
    /// Description of WaitUIAHyperlinkIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAHyperlinkIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAHyperlinkIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAHyperlinkIsVisibleCommand() { this.ControlType = ControlType.Hyperlink; } }
    
    /// <summary>
    /// Description of WaitUIALinkLabelIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIALinkLabelIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIALinkLabelIsVisibleCommand : WaitUIAHyperlinkIsVisibleCommand
    { public WaitUIALinkLabelIsVisibleCommand() { this.ControlType = ControlType.Hyperlink; } }

    /// <summary>
    /// Description of WaitUIAImageIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAImageIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAImageIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAImageIsVisibleCommand() { this.ControlType = ControlType.Image; } }
    
    /// <summary>
    /// Description of WaitUIAListIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAListIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAListIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAListIsVisibleCommand() { this.ControlType = ControlType.List; } }
    
    /// <summary>
    /// Description of WaitUIAListItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAListItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAListItemIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAListItemIsVisibleCommand() { this.ControlType = ControlType.ListItem; } }
    
    /// <summary>
    /// Description of WaitUIAMenuIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAMenuIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAMenuIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAMenuIsVisibleCommand() { this.ControlType = ControlType.Menu; } }
    
    /// <summary>
    /// Description of WaitUIAMenuBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAMenuBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAMenuBarIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAMenuBarIsVisibleCommand() { this.ControlType = ControlType.MenuBar; } }

    /// <summary>
    /// Description of WaitUIAMenuItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAMenuItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAMenuItemIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAMenuItemIsVisibleCommand() { this.ControlType = ControlType.MenuItem; } }
    
    /// <summary>
    /// Description of WaitUIAPaneIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAPaneIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAPaneIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAPaneIsVisibleCommand() { this.ControlType = ControlType.Pane; } }
    
    /// <summary>
    /// Description of WaitUIAProgressBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAProgressBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAProgressBarIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAProgressBarIsVisibleCommand() { this.ControlType = ControlType.ProgressBar; } }
    
    /// <summary>
    /// Description of WaitUIARadioButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIARadioButtonIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIARadioButtonIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIARadioButtonIsVisibleCommand() { this.ControlType = ControlType.RadioButton; } }
    
    /// <summary>
    /// Description of WaitUIAScrollBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAScrollBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAScrollBarIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAScrollBarIsVisibleCommand() { this.ControlType = ControlType.ScrollBar; } }

    /// <summary>
    /// Description of WaitUIASeparatorIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIASeparatorIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIASeparatorIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIASeparatorIsVisibleCommand() { this.ControlType = ControlType.Separator; } }
    
    /// <summary>
    /// Description of WaitUIASliderIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIASliderIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIASliderIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIASliderIsVisibleCommand() { this.ControlType = ControlType.Slider; } }
    
    /// <summary>
    /// Description of WaitUIASpinnerIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIASpinnerIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIASpinnerIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIASpinnerIsVisibleCommand() { this.ControlType = ControlType.Spinner; } }
    
    /// <summary>
    /// Description of WaitUIASplitButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIASplitButtonIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIASplitButtonIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIASplitButtonIsVisibleCommand() { this.ControlType = ControlType.SplitButton; } }
    
    /// <summary>
    /// Description of WaitUIAStatusBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAStatusBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAStatusBarIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAStatusBarIsVisibleCommand() { this.ControlType = ControlType.StatusBar; } }

    /// <summary>
    /// Description of WaitUIATabIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATabIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATabIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIATabIsVisibleCommand() { this.ControlType = ControlType.Tab; } }
    
    /// <summary>
    /// Description of WaitUIATabItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATabItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATabItemIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIATabItemIsVisibleCommand() { this.ControlType = ControlType.TabItem; } }
    
    /// <summary>
    /// Description of WaitUIATableIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATableIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATableIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIATableIsVisibleCommand() { this.ControlType = ControlType.Table; } }
    
    /// <summary>
    /// Description of WaitUIATextIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATextIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATextIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIATextIsVisibleCommand() { this.ControlType = ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUIALabelIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIALabelIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIALabelIsVisibleCommand : WaitUIATextIsVisibleCommand
    { public WaitUIALabelIsVisibleCommand() { this.ControlType = ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUIAThumbIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAThumbIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAThumbIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAThumbIsVisibleCommand() { this.ControlType = ControlType.Thumb; } }

    /// <summary>
    /// Description of WaitUIATitleBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATitleBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATitleBarIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIATitleBarIsVisibleCommand() { this.ControlType = ControlType.TitleBar; } }
    
    /// <summary>
    /// Description of WaitUIAToolBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAToolBarIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAToolBarIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAToolBarIsVisibleCommand() { this.ControlType = ControlType.ToolBar; } }
    
    /// <summary>
    /// Description of WaitUIAToolTipIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAToolTipIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAToolTipIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAToolTipIsVisibleCommand() { this.ControlType = ControlType.ToolTip; } }
    
    /// <summary>
    /// Description of WaitUIATreeIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATreeIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATreeIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIATreeIsVisibleCommand() { this.ControlType = ControlType.Tree; } }
    
    /// <summary>
    /// Description of WaitUIATreeItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIATreeItemIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIATreeItemIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIATreeItemIsVisibleCommand() { this.ControlType = ControlType.TreeItem; } }
    
    /// <summary>
    /// Description of WaitUIAChildWindowIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAChildWindowIsVisible")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class WaitUIAChildWindowIsVisibleCommand : WaitUIAControlIsVisibleCommand
    { public WaitUIAChildWindowIsVisibleCommand() { this.ControlType = ControlType.Window; } }
}
