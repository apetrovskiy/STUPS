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
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.Generic;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of GetRegisteredEventCommand.
    /// </summary>
    public class GetRegisteredEventCommand : UiaCommand
    {
        public GetRegisteredEventCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
            
        }
        
        public override void Execute()
        {
            var cmdlet =
                (GetUiaRegisteredEventCommand)Cmdlet;
            
            
        }
        
//        protected override void BeginProcessing()
//        {
//            try {
//
//                foreach (object handler in CurrentData.Events) {
//
//                    WriteObject(
//                        this,
//                        handler);
//
//                }
//            }
//            catch (Exception eEnumEventhandlers) {
//                WriteError(
//                    this,
//                    "Unable to enumerate event handlers. " +
//                    eEnumEventhandlers.Message,
//                    "UnableEnumerateEventHandlers",
//                    ErrorCategory.InvalidOperation,
//                    true);
//            }
//        }
//        
//        /// <summary>
//        /// This is a placeholder to prevent its base counterpart from being run.
//        /// </summary>
//        protected override void ProcessRecord()
//        {
//        }
    }
}
