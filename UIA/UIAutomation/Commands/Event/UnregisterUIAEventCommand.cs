/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of UnregisterUIAEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "UIAEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class UnregisterUIAEventCommand : EventCmdletBase
    {
        #region Constructor
        public UnregisterUIAEventCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter All { get; set; }
        [Parameter(Mandatory = false)]
        public AutomationEventHandler EventHandler { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        [Parameter(Mandatory = false)]
        internal new System.Windows.Automation.AutomationElement InputObject { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            if (this.All) {
                try {

                    Automation.RemoveAllEventHandlers();

                    // 20130109
                    if (null != CurrentData.Events) {

                        CurrentData.Events.Clear();

                    }
                }
                catch {

                    // 20130109
                    if (null != CurrentData.Events) {

                        CurrentData.Events.Clear();

                    }
                    // 20130109
//                    ErrorRecord err = 
//                        new ErrorRecord(new Exception("Unable to unregister all registered handlers"),
//                                        "UnableUnregisterEventhandlers",
//                                        ErrorCategory.InvalidOperation,
//                                        null);
//                    err.ErrorDetails = 
//                        new ErrorDetails("Unable to unregister all registerd event handlers");
//                    WriteError(this, err, true);
                    
                    this.WriteError(
                        this,
                        "Unable to unregister all registered event handlers",
                        "UnableUnregisterEventhandlers",
                        ErrorCategory.InvalidOperation,
                        true);
                }
            } else {
                try {

                    if (this.InputObject != null && 
                        (int)this.InputObject.Current.ProcessId > 0 &&
                        this.EventHandler != null) {

                        Automation.RemoveAutomationEventHandler(
                            null,
                            this.InputObject,
                            this.EventHandler);

                    }
                } 
                catch {

                    try {

                        // 20130109
//                        ErrorRecord err = 
//                            new ErrorRecord(
//                                new Exception("Unable to remove an event handler " + 
//                                              this.EventHandler.ToString()),
//                                              "unableToUnregister",
//                                              ErrorCategory.InvalidArgument,
//                                              this.EventHandler);
//                        err.ErrorDetails = 
//                            new ErrorDetails("Unable to unregister the event handler: " +
//                                             this.EventHandler.Target.ToString());
//                        WriteError(this, err, true);
                        
                        this.WriteError(
                            this,
                            "Unable to remove the event handler " +
                            this.EventHandler.ToString(),
                            "UnableToUnregister",
                            ErrorCategory.InvalidArgument,
                            true);

                    } 
                    catch {}
                }
            }
        }
        
        /// <summary>
        /// This is a placeholder to prevent its base counterpart from being run.
        /// </summary>
        protected override void ProcessRecord()
        {
        }
    }
}
