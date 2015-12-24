/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/9/2013
 * Time: 12:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUiaRegisteredEventCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaRegisteredEvent")]
    
    public class GetUiaRegisteredEventCommand : CommonCmdletBase //EventCmdletBase
    {
        #region Parameters
//        [UiaParameterNotUsed][Parameter(Mandatory = false)] 
//        internal new System.Windows.Automation.AutomationElement[] InputObject { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        internal new SwitchParameter PassThru { get; set; }
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        internal new ScriptBlock[] EventAction { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            try {

                foreach (object handler in CurrentData.Events) {

                    WriteObject(
                        this,
                        handler);

                }
            }
            catch (Exception eEnumEventhandlers) {
                WriteError(
                    this,
                    "Unable to enumerate event handlers. " +
                    eEnumEventhandlers.Message,
                    "UnableEnumerateEventHandlers",
                    ErrorCategory.InvalidOperation,
                    true);
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
