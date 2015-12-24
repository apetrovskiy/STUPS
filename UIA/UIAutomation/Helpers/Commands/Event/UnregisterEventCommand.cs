/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 3:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Helpers.Commands
{
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of UnregisterEventCommand.
    /// </summary>
    public class UnregisterEventCommand : UiaCommand
    {
        public UnregisterEventCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
            
        }
        
        public override void Execute()
        {
            var cmdlet =
                (UnregisterUiaEventCommand)Cmdlet;
            
            
        }
        
//        // protected override void BeginProcessing()
//        protected override void ProcessRecord()
//        {
//            if (All) {
//                try {
//                    
//                    // 20140130
//                    // Automation.RemoveAllEventHandlers();
//                    MyAutomation.RemoveAllEventHandlers();
//
//                    // 20130109
//                    if (null != CurrentData.Events) {
//
//                        CurrentData.Events.Clear();
//
//                    }
//                }
//                catch {
//
//                    // 20130109
//                    if (null != CurrentData.Events) {
//
//                        CurrentData.Events.Clear();
//
//                    }
//                    
//                    WriteError(
//                        this,
//                        "Unable to unregister all registered event handlers",
//                        "UnableUnregisterEventhandlers",
//                        ErrorCategory.InvalidOperation,
//                        true);
//                }
//            } else {
//                
//                // 20140130
//                foreach (IUiElement inputObject in InputObject) {
//                    
//                    try {
//                        
//                        // 20140130
//                        // if (InputObject != null &&
//                        if (inputObject != null &&
//                            // 20140130                            
//                            // InputObject.Current.ProcessId > 0 &&
//                            inputObject.Current.ProcessId > 0 &&
//                            // (int)this.InputObject.Current.ProcessId > 0 &&
//                            EventHandler != null) {
//                            
//                            // 20140130
//                            // Automation.RemoveAutomationEventHandler(
//                            MyAutomation.RemoveAutomationEventHandler(
//                                null,
//                                // 20131109
//                                //this.InputObject,
//                                // 20131118
//                                // property to method
//                                //this.InputObject.SourceElement,
//                                // 20140102
//                                // InputObject.GetSourceElement(),
//                                // 20140130
//                                // InputObject.GetSourceElement() as AutomationElement,
//                                // 20140130
//                                // inputObject.GetSourceElement() as AutomationElement,
//                                inputObject,
//                                EventHandler);
//    
//                        }
//                    } 
//                    catch {
//    
//                        try {
//    
//                            // 20130109
//    //                        ErrorRecord err = 
//    //                            new ErrorRecord(
//    //                                new Exception("Unable to remove an event handler " + 
//    //                                              this.EventHandler.ToString()),
//    //                                              "unableToUnregister",
//    //                                              ErrorCategory.InvalidArgument,
//    //                                              this.EventHandler);
//    //                        err.ErrorDetails = 
//    //                            new ErrorDetails("Unable to unregister the event handler: " +
//    //                                             this.EventHandler.Target.ToString());
//    //                        WriteError(this, err, true);
//                            
//                            WriteError(
//                                this,
//                                "Unable to remove the event handler " +
//                                EventHandler.ToString(),
//                                "UnableToUnregister",
//                                ErrorCategory.InvalidArgument,
//                                // 20140130
//                                // true);
//                                false);
//    
//                        } 
//                        catch {}
//                    }
//                } // 20140130
//            }
//        }
//        
////        /// <summary>
////        /// This is a placeholder to prevent its base counterpart from being run.
////        /// </summary>
////        protected override void ProcessRecord()
////        {
////        }
    }
}
