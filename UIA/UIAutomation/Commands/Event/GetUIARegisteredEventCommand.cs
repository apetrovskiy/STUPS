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
    using System.Windows.Automation;

    /// <summary>
    /// Description of GetUIARegisteredEventCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIARegisteredEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIARegisteredEventCommand : CommonCmdletBase //EventCmdletBase
    {
        public GetUIARegisteredEventCommand()
        {
        }
        
        #region Parameters
//        [Parameter(Mandatory = false)] 
//        internal new System.Windows.Automation.AutomationElement[] InputObject { get; set; }
//        [Parameter(Mandatory = false)]
//        internal new SwitchParameter PassThru { get; set; }
//        [Parameter(Mandatory = false)]
//        internal new ScriptBlock[] EventAction { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            try {

                foreach (object handler in CurrentData.Events) {

                    this.WriteObject(
                        this,
                        handler);

                }
            }
            catch (Exception eEnumEventhandlers) {
                this.WriteError(
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
