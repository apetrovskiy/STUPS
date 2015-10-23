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
    extern alias UIANET; extern alias UIACOM;// using System.Windows.Automation;
    using System.Management.Automation;
    using classic = UIANET::System.Windows.Automation; using viacom = UIACOM::System.Windows.Automation; // using System.Windows.Automation;

    /// <summary>
    /// Description of UnregisterUiaEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Unregister, "UiaEvent")]
    
    public class UnregisterUiaEventCommand : EventCmdletBase
    {
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "All")]
        public SwitchParameter All { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ParameterSetName = "Selected")]
        public classic.AutomationEventHandler EventHandler { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false,
                   ValueFromPipeline = true,
                   ParameterSetName = "Selected")]
        public new IUiElement[] InputObject { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            if (All) {
                try {
                    
                    UiaAutomation.RemoveAllEventHandlers();
                    
                    if (null != CurrentData.Events) {

                        CurrentData.Events.Clear();

                    }
                }
                catch {
                    
                    if (null != CurrentData.Events) {

                        CurrentData.Events.Clear();

                    }
                    
                    WriteError(
                        this,
                        "Unable to unregister all registered event handlers",
                        "UnableUnregisterEventhandlers",
                        ErrorCategory.InvalidOperation,
                        true);
                }
            } else {
                
                foreach (IUiElement inputObject in InputObject) {
                    
                    try {
                        
                        if (inputObject != null &&
                            // 20140312
                            // inputObject.Current.ProcessId > 0 &&
                            inputObject.GetCurrent().ProcessId > 0 &&
                            EventHandler != null) {
                            
                            UiaAutomation.RemoveAutomationEventHandler(
                                null,
                                inputObject,
                                EventHandler);
    
                        }
                    } 
                    catch {
    
                        try {
                            
                            WriteError(
                                this,
                                "Unable to remove the event handler " +
                                EventHandler.ToString(),
                                "UnableToUnregister",
                                ErrorCategory.InvalidArgument,
                                false);
    
                        } 
                        catch {}
                    }
                }
            }
        }
    }
}
