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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using Helpers.Commands;
    
    /// <summary>
    /// Description of WaitUiaControlIsVisibleCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaControlIsVisible")]
    
    public class WaitUiaControlIsVisibleCommand : WaitCmdletBase
    {
//        public WaitUiaControlIsVisibleCommand()
//        {
//        }
        
        #region Constructor
        public WaitUiaControlIsVisibleCommand()
        {
            ControlType = null;
        }
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        protected internal classic.ControlType ControlType { get; set; }
        
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
            StartDate = DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord() {
            if (!CheckAndPrepareInput(this)) { return; }
            
//            foreach (IUiElement inputObject in InputObject) {
//            
//            //System.Windows.Automation.AutomationElement _control = null;
//            
//            if (!Equals(ControlType, inputObject.Current.ControlType)) {
//                
//                WriteError(
//                    this,
//                    "Control is not of " +
//                    ControlType.ProgrammaticName +
//                    " type",
//                    "WrongControlType",
//                    ErrorCategory.InvalidArgument,
//                    true);
//            }
//
//            /*
//            if (this.ControlType != inputObject.Current.ControlType) {
//                
//                this.WriteError(
//                    this,
//                    "Control is not of " +
//                    this.ControlType.ProgrammaticName +
//                    " type",
//                    "WrongControlType",
//                    ErrorCategory.InvalidArgument,
//                    true);
//            }
//            */
//
//            //this.WaitIfCondition(_control, false);
//            // 20120823
//            //this.WaitIfCondition(this.InputObject, false);
//            WaitIfCondition(inputObject, false);
//           
//            //WriteObject(this, _control);
//            // 20130105
//            //WriteObject(this, this.InputObject);
//            WriteObject(this, inputObject);
//            
//            } // 20120823
            
            var command =
                AutomationFactory.GetCommand<WaitControlIsVisibleCommand>(this);
            command.Execute();
        }
        
//        protected override void StopProcessing()
//        {
//            // 20120620
//            WriteVerbose(this, "User interrupted");
//            this.Wait = false;
//        }
    }
    
    
    /// <summary>
    /// Description of WaitUiaButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaButtonIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaButtonIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaButtonIsVisibleCommand() { ControlType = classic.ControlType.Button; } }

    /// <summary>
    /// Description of WaitUiaCalendarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCalendarIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaCalendarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaCalendarIsVisibleCommand() { ControlType = classic.ControlType.Calendar; } }
    
    /// <summary>
    /// Description of WaitUiaCheckBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCheckBoxIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaCheckBoxIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaCheckBoxIsVisibleCommand() { ControlType = classic.ControlType.CheckBox; } }
    
    /// <summary>
    /// Description of WaitUiaComboBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaComboBoxIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaComboBoxIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaComboBoxIsVisibleCommand() { ControlType = classic.ControlType.ComboBox; } }
    
    /// <summary>
    /// Description of WaitUiaCustomIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCustomIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaCustomIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaCustomIsVisibleCommand() { ControlType = classic.ControlType.Custom; } }
    
    /// <summary>
    /// Description of WaitUiaDataGridIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDataGridIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaDataGridIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaDataGridIsVisibleCommand() { ControlType = classic.ControlType.DataGrid; } }
    
    /// <summary>
    /// Description of WaitUiaDataItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDataItemIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaDataItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaDataItemIsVisibleCommand() { ControlType = classic.ControlType.DataItem; } }
    
    /// <summary>
    /// Description of WaitUiaDocumentIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDocumentIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaDocumentIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaDocumentIsVisibleCommand() { ControlType = classic.ControlType.Document; } }

    /// <summary>
    /// Description of WaitUiaEditIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaEditIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaEditIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaEditIsVisibleCommand() { ControlType = classic.ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUiaTextBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTextBoxIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTextBoxIsVisibleCommand : WaitUiaEditIsVisibleCommand
    { public WaitUiaTextBoxIsVisibleCommand() { ControlType = classic.ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUiaGroupIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaGroupIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaGroupIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaGroupIsVisibleCommand() { ControlType = classic.ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUiaGroupBoxIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaGroupBoxIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaGroupBoxIsVisibleCommand : WaitUiaGroupIsVisibleCommand
    { public WaitUiaGroupBoxIsVisibleCommand() { ControlType = classic.ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUiaHeaderIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHeaderIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaHeaderIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaHeaderIsVisibleCommand() { ControlType = classic.ControlType.Header; } }
    
    /// <summary>
    /// Description of WaitUiaHeaderItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHeaderItemIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaHeaderItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaHeaderItemIsVisibleCommand() { ControlType = classic.ControlType.HeaderItem; } }
    
    /// <summary>
    /// Description of WaitUiaHyperlinkIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHyperlinkIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaHyperlinkIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaHyperlinkIsVisibleCommand() { ControlType = classic.ControlType.Hyperlink; } }
    
    /// <summary>
    /// Description of WaitUiaLinkLabelIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaLinkLabelIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaLinkLabelIsVisibleCommand : WaitUiaHyperlinkIsVisibleCommand
    { public WaitUiaLinkLabelIsVisibleCommand() { ControlType = classic.ControlType.Hyperlink; } }

    /// <summary>
    /// Description of WaitUiaImageIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaImageIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaImageIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaImageIsVisibleCommand() { ControlType = classic.ControlType.Image; } }
    
    /// <summary>
    /// Description of WaitUiaListIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaListIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaListIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaListIsVisibleCommand() { ControlType = classic.ControlType.List; } }
    
    /// <summary>
    /// Description of WaitUiaListItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaListItemIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaListItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaListItemIsVisibleCommand() { ControlType = classic.ControlType.ListItem; } }
    
    /// <summary>
    /// Description of WaitUiaMenuIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaMenuIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaMenuIsVisibleCommand() { ControlType = classic.ControlType.Menu; } }
    
    /// <summary>
    /// Description of WaitUiaMenuBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuBarIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaMenuBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaMenuBarIsVisibleCommand() { ControlType = classic.ControlType.MenuBar; } }

    /// <summary>
    /// Description of WaitUiaMenuItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuItemIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaMenuItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaMenuItemIsVisibleCommand() { ControlType = classic.ControlType.MenuItem; } }
    
    /// <summary>
    /// Description of WaitUiaPaneIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaPaneIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaPaneIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaPaneIsVisibleCommand() { ControlType = classic.ControlType.Pane; } }
    
    /// <summary>
    /// Description of WaitUiaProgressBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaProgressBarIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaProgressBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaProgressBarIsVisibleCommand() { ControlType = classic.ControlType.ProgressBar; } }
    
    /// <summary>
    /// Description of WaitUiaRadioButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaRadioButtonIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaRadioButtonIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaRadioButtonIsVisibleCommand() { ControlType = classic.ControlType.RadioButton; } }
    
    /// <summary>
    /// Description of WaitUiaScrollBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaScrollBarIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaScrollBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaScrollBarIsVisibleCommand() { ControlType = classic.ControlType.ScrollBar; } }

    /// <summary>
    /// Description of WaitUiaSeparatorIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSeparatorIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaSeparatorIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaSeparatorIsVisibleCommand() { ControlType = classic.ControlType.Separator; } }
    
    /// <summary>
    /// Description of WaitUiaSliderIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSliderIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaSliderIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaSliderIsVisibleCommand() { ControlType = classic.ControlType.Slider; } }
    
    /// <summary>
    /// Description of WaitUiaSpinnerIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSpinnerIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaSpinnerIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaSpinnerIsVisibleCommand() { ControlType = classic.ControlType.Spinner; } }
    
    /// <summary>
    /// Description of WaitUiaSplitButtonIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSplitButtonIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaSplitButtonIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaSplitButtonIsVisibleCommand() { ControlType = classic.ControlType.SplitButton; } }
    
    /// <summary>
    /// Description of WaitUiaStatusBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaStatusBarIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaStatusBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaStatusBarIsVisibleCommand() { ControlType = classic.ControlType.StatusBar; } }

    /// <summary>
    /// Description of WaitUiaTabIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTabIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTabIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTabIsVisibleCommand() { ControlType = classic.ControlType.Tab; } }
    
    /// <summary>
    /// Description of WaitUiaTabItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTabItemIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTabItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTabItemIsVisibleCommand() { ControlType = classic.ControlType.TabItem; } }
    
    /// <summary>
    /// Description of WaitUiaTableIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTableIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTableIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTableIsVisibleCommand() { ControlType = classic.ControlType.Table; } }
    
    /// <summary>
    /// Description of WaitUiaTextIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTextIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTextIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTextIsVisibleCommand() { ControlType = classic.ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUiaLabelIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaLabelIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaLabelIsVisibleCommand : WaitUiaTextIsVisibleCommand
    { public WaitUiaLabelIsVisibleCommand() { ControlType = classic.ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUiaThumbIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaThumbIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaThumbIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaThumbIsVisibleCommand() { ControlType = classic.ControlType.Thumb; } }

    /// <summary>
    /// Description of WaitUiaTitleBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTitleBarIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTitleBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTitleBarIsVisibleCommand() { ControlType = classic.ControlType.TitleBar; } }
    
    /// <summary>
    /// Description of WaitUiaToolBarIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaToolBarIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaToolBarIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaToolBarIsVisibleCommand() { ControlType = classic.ControlType.ToolBar; } }
    
    /// <summary>
    /// Description of WaitUiaToolTipIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaToolTipIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaToolTipIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaToolTipIsVisibleCommand() { ControlType = classic.ControlType.ToolTip; } }
    
    /// <summary>
    /// Description of WaitUiaTreeIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTreeIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTreeIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTreeIsVisibleCommand() { ControlType = classic.ControlType.Tree; } }
    
    /// <summary>
    /// Description of WaitUiaTreeItemIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTreeItemIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTreeItemIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaTreeItemIsVisibleCommand() { ControlType = classic.ControlType.TreeItem; } }
    
    /// <summary>
    /// Description of WaitUiaChildWindowIsVisible.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaChildWindowIsVisible")]
    [OutputType(typeof(object))]
    
    public class WaitUiaChildWindowIsVisibleCommand : WaitUiaControlIsVisibleCommand
    { public WaitUiaChildWindowIsVisibleCommand() { ControlType = classic.ControlType.Window; } }
}
