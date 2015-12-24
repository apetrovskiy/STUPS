/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 22/02/2012
 * Time: 05:28 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using Helpers.Commands;

    /// <summary>
    /// Description of WaitUiaControlStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UiaControlState")]
    [OutputType(new[] { typeof(object) })]
    public class WaitUiaControlStateCommand : GetControlStateCmdletBase
    {
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing() {
            WriteVerbose(this, "Timeout = " + Timeout.ToString());
            
            StartDate = DateTime.Now;
            // 20120208 if (Highlight) { Global.MinimizeRectangle(); }
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!CheckAndPrepareInput(this)) { return; }
            
            var command =
                AutomationFactory.GetCommand<WaitControlStateCommand>(this);
            command.Execute();
            
//            bool result = false;
//            do {
//                result = 
//                    TestControlByPropertiesFromHashtable(
//                        // 20130315
//                        InputObject,
//                        SearchCriteria,
//                        Timeout);
//                if (result) {
//                    WriteObject(this, true);
//                    return;
//                } else {
//                    SleepAndRunScriptBlocks(this);
//                    // wait until timeout expires or the state will be confirmed as valid
//                    DateTime nowDate = 
//                        DateTime.Now;
//                    if ((nowDate - StartDate).TotalSeconds > Timeout / 1000) {
//                        //WriteObject(this, false);
//                        result = true;
//                        //write
//                        //return;
//                    }
//                }
//            } while (!result);
//            //WriteObject(this, false);
//
//            // 20130316
//            // graceful fail
//            WriteObject(this, false);
//            
////            this.WriteError(
////                this,
////                "Timeout expired",
////                "TimeoutExpired",
////                ErrorCategory.OperationTimeout,
////                true);
        }
    }
}
