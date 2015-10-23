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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;
    using Helpers.Commands;

    /// <summary>
    /// Description of WaitUiaControlIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaControlIsEnabled")]
    
    public class WaitUiaControlIsEnabledCommand : WaitCmdletBase
    {
        #region Constructor
        public WaitUiaControlIsEnabledCommand()
        {
            ControlType = null;
        }
        #endregion Constructor

        #region Parameters
        #endregion Parameters

        // 20120206 private System.DateTime startDate;
        protected internal classic.ControlType ControlType { get; set; }

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
            
            var command =
                AutomationFactory.GetCommand<WaitControlIsEnabledCommand>(this);
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
    /// Description of WaitUiaButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaButtonIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaButtonIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaButtonIsEnabledCommand() { ControlType = classic.ControlType.Button; } }

    /// <summary>
    /// Description of WaitUiaCalendarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCalendarIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaCalendarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaCalendarIsEnabledCommand() { ControlType = classic.ControlType.Calendar; } }
    
    /// <summary>
    /// Description of WaitUiaCheckBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCheckBoxIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaCheckBoxIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaCheckBoxIsEnabledCommand() { ControlType = classic.ControlType.CheckBox; } }
    
    /// <summary>
    /// Description of WaitUiaComboBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaComboBoxIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaComboBoxIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaComboBoxIsEnabledCommand() { ControlType = classic.ControlType.ComboBox; } }
    
    /// <summary>
    /// Description of WaitUiaCustomIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaCustomIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaCustomIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaCustomIsEnabledCommand() { ControlType = classic.ControlType.Custom; } }
    
    /// <summary>
    /// Description of WaitUiaDataGridIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDataGridIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaDataGridIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaDataGridIsEnabledCommand() { ControlType = classic.ControlType.DataGrid; } }
    
    /// <summary>
    /// Description of WaitUiaDataItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDataItemIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaDataItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaDataItemIsEnabledCommand() { ControlType = classic.ControlType.DataItem; } }
    
    /// <summary>
    /// Description of WaitUiaDocumentIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaDocumentIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaDocumentIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaDocumentIsEnabledCommand() { ControlType = classic.ControlType.Document; } }

    /// <summary>
    /// Description of WaitUiaEditIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaEditIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaEditIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaEditIsEnabledCommand() { ControlType = classic.ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUiaTextBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTextBoxIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTextBoxIsEnabledCommand : WaitUiaEditIsEnabledCommand
    { public WaitUiaTextBoxIsEnabledCommand() { ControlType = classic.ControlType.Edit; } }
    
    /// <summary>
    /// Description of WaitUiaGroupIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaGroupIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaGroupIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaGroupIsEnabledCommand() { ControlType = classic.ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUiaGroupBoxIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaGroupBoxIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaGroupBoxIsEnabledCommand : WaitUiaGroupIsEnabledCommand
    { public WaitUiaGroupBoxIsEnabledCommand() { ControlType = classic.ControlType.Group; } }
    
    /// <summary>
    /// Description of WaitUiaHeaderIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHeaderIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaHeaderIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaHeaderIsEnabledCommand() { ControlType = classic.ControlType.Header; } }
    
    /// <summary>
    /// Description of WaitUiaHeaderItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHeaderItemIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaHeaderItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaHeaderItemIsEnabledCommand() { ControlType = classic.ControlType.HeaderItem; } }
    
    /// <summary>
    /// Description of WaitUiaHyperlinkIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaHyperlinkIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaHyperlinkIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaHyperlinkIsEnabledCommand() { ControlType = classic.ControlType.Hyperlink; } }
    
    /// <summary>
    /// Description of WaitUiaLinkLabelIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaLinkLabelIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaLinkLabelIsEnabledCommand : WaitUiaHyperlinkIsEnabledCommand
    { public WaitUiaLinkLabelIsEnabledCommand() { ControlType = classic.ControlType.Hyperlink; } }

    /// <summary>
    /// Description of WaitUiaImageIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaImageIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaImageIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaImageIsEnabledCommand() { ControlType = classic.ControlType.Image; } }
    
    /// <summary>
    /// Description of WaitUiaListIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaListIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaListIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaListIsEnabledCommand() { ControlType = classic.ControlType.List; } }
    
    /// <summary>
    /// Description of WaitUiaListItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaListItemIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaListItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaListItemIsEnabledCommand() { ControlType = classic.ControlType.ListItem; } }
    
    /// <summary>
    /// Description of WaitUiaMenuIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaMenuIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaMenuIsEnabledCommand() { ControlType = classic.ControlType.Menu; } }
    
    /// <summary>
    /// Description of WaitUiaMenuBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuBarIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaMenuBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaMenuBarIsEnabledCommand() { ControlType = classic.ControlType.MenuBar; } }

    /// <summary>
    /// Description of WaitUiaMenuItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaMenuItemIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaMenuItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaMenuItemIsEnabledCommand() { ControlType = classic.ControlType.MenuItem; } }
    
    /// <summary>
    /// Description of WaitUiaPaneIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaPaneIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaPaneIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaPaneIsEnabledCommand() { ControlType = classic.ControlType.Pane; } }
    
    /// <summary>
    /// Description of WaitUiaProgressBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaProgressBarIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaProgressBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaProgressBarIsEnabledCommand() { ControlType = classic.ControlType.ProgressBar; } }
    
    /// <summary>
    /// Description of WaitUiaRadioButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaRadioButtonIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaRadioButtonIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaRadioButtonIsEnabledCommand() { ControlType = classic.ControlType.RadioButton; } }
    
    /// <summary>
    /// Description of WaitUiaScrollBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaScrollBarIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaScrollBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaScrollBarIsEnabledCommand() { ControlType = classic.ControlType.ScrollBar; } }

    /// <summary>
    /// Description of WaitUiaSeparatorIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSeparatorIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaSeparatorIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaSeparatorIsEnabledCommand() { ControlType = classic.ControlType.Separator; } }
    
    /// <summary>
    /// Description of WaitUiaSliderIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSliderIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaSliderIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaSliderIsEnabledCommand() { ControlType = classic.ControlType.Slider; } }
    
    /// <summary>
    /// Description of WaitUiaSpinnerIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSpinnerIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaSpinnerIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaSpinnerIsEnabledCommand() { ControlType = classic.ControlType.Spinner; } }
    
    /// <summary>
    /// Description of WaitUiaSplitButtonIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaSplitButtonIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaSplitButtonIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaSplitButtonIsEnabledCommand() { ControlType = classic.ControlType.SplitButton; } }
    
    /// <summary>
    /// Description of WaitUiaStatusBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaStatusBarIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaStatusBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaStatusBarIsEnabledCommand() { ControlType = classic.ControlType.StatusBar; } }

    /// <summary>
    /// Description of WaitUiaTabIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTabIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTabIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTabIsEnabledCommand() { ControlType = classic.ControlType.Tab; } }
    
    /// <summary>
    /// Description of WaitUiaTabItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTabItemIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTabItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTabItemIsEnabledCommand() { ControlType = classic.ControlType.TabItem; } }
    
    /// <summary>
    /// Description of WaitUiaTableIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTableIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTableIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTableIsEnabledCommand() { ControlType = classic.ControlType.Table; } }
    
    /// <summary>
    /// Description of WaitUiaTextIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTextIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTextIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTextIsEnabledCommand() { ControlType = classic.ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUiaLabelIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaLabelIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaLabelIsEnabledCommand : WaitUiaTextIsEnabledCommand
    { public WaitUiaLabelIsEnabledCommand() { ControlType = classic.ControlType.Text; } }
    
    /// <summary>
    /// Description of WaitUiaThumbIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaThumbIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaThumbIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaThumbIsEnabledCommand() { ControlType = classic.ControlType.Thumb; } }

    /// <summary>
    /// Description of WaitUiaTitleBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTitleBarIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTitleBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTitleBarIsEnabledCommand() { ControlType = classic.ControlType.TitleBar; } }
    
    /// <summary>
    /// Description of WaitUiaToolBarIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaToolBarIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaToolBarIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaToolBarIsEnabledCommand() { ControlType = classic.ControlType.ToolBar; } }
    
    /// <summary>
    /// Description of WaitUiaToolTipIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaToolTipIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaToolTipIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaToolTipIsEnabledCommand() { ControlType = classic.ControlType.ToolTip; } }
    
    /// <summary>
    /// Description of WaitUiaTreeIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTreeIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTreeIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTreeIsEnabledCommand() { ControlType = classic.ControlType.Tree; } }
    
    /// <summary>
    /// Description of WaitUiaTreeItemIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaTreeItemIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaTreeItemIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaTreeItemIsEnabledCommand() { ControlType = classic.ControlType.TreeItem; } }
    
    /// <summary>
    /// Description of WaitUiaChildWindowIsEnabled.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaChildWindowIsEnabled")]
    [OutputType(typeof(object))]
    
    public class WaitUiaChildWindowIsEnabledCommand : WaitUiaControlIsEnabledCommand
    { public WaitUiaChildWindowIsEnabledCommand() { ControlType = classic.ControlType.Window; } }
    
}
