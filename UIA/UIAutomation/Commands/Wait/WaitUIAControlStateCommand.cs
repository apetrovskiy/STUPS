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

    /// <summary>
    /// Description of WaitUIAControlStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAControlState")]
    [OutputType(new[] { typeof(object) })]
    public class WaitUIAControlStateCommand : GetControlStateCmdletBase
    {
        public WaitUIAControlStateCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing() {
            WriteVerbose(this, "Timeout = " + Timeout.ToString());
            
            StartDate = System.DateTime.Now;
            // 20120208 if (Highlight) { Global.MinimizeRectangle(); }
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            bool result = false;
            do {
                result = 
                    TestControlByPropertiesFromHashtable(
                        // 20130315
                        this.InputObject,
                        this.SearchCriteria,
                        this.Timeout);
                if (result) {
                    WriteObject(this, true);
                    return;
                } else {
                    SleepAndRunScriptBlocks(this);
                    // wait until timeout expires or the state will be confirmed as valid
                    System.DateTime nowDate = 
                        System.DateTime.Now;
                    if ((nowDate - StartDate).TotalSeconds > this.Timeout / 1000) {
                        //WriteObject(this, false);
                        result = true;
                        //write
                        //return;
                    }
                }
            } while (!result);
            //WriteObject(this, false);

            // 20130316
            // graceful fail
            this.WriteObject(this, false);
            
//            this.WriteError(
//                this,
//                "Timeout expired",
//                "TimeoutExpired",
//                ErrorCategory.OperationTimeout,
//                true);
        }
    }
}
