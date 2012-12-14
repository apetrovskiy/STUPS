/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/2/2012
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIAControlFromHandleCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlFromHandle")]
    [OutputType(typeof(object))]
    public class GetUIAControlFromHandleCommand : DiscoveryCmdletBase
    {
        #region Constructor
        public GetUIAControlFromHandleCommand()
        {
            //this.InputObject = 0;
        }
        #endregion Constructor
        
        #region Parameters
//        [Parameter(Mandatory = true,
//                   ValueFromPipeline = true)]
//        [Alias("Handle")]
//        public new int InputObject { get; set; }
        [ValidateNotNullOrEmpty()]
        [Alias ("Handle")]
        [Parameter(Mandatory = false, 
            ValueFromPipeline = true, 
            Position = 0)] 
        // 20120824
        //public new int InputObject { get; set; }
        public new int[] InputObject { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            System.Windows.Automation.AutomationElement result = null;
            // 20120824
            //try{ WriteVerbose(this, "handle = " + this.InputObject.ToString()); } catch {}
            
            // 20120824
            foreach (int handle in this.InputObject) {
                result = 
                    UIAHelper.GetAutomationElementFromHandle(
                        this,
                        // 20120824
                        //this.InputObject);
                        handle);
                if (result != null) {
                    WriteVerbose(this, "got the control: " + result.Current.Name);
                }
                WriteObject(this, result);
            } // 20120824
        }
    }
    
    /// <summary>
    /// Description of GetUIAWindowFromHandleCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAWindowFromHandle")]
    [OutputType(typeof(object))]
    public class GetUIAWindowFromHandleCommand : GetUIAControlFromHandleCommand
    {
        #region Constructor
        public GetUIAWindowFromHandleCommand()
        {
            //this.InputObject = 0;
        }
        #endregion Constructor

        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            System.Windows.Automation.AutomationElement result = null;
            // 20120824
            //try{ WriteVerbose(this, "handle = " + this.InputObject.ToString()); } catch {}
            
            // 20120824
            foreach (int handle in this.InputObject) {
                result = 
                    UIAHelper.GetAutomationElementFromHandle(
                        this,
                        // 20120824
                        //this.InputObject);
                        handle);
                if (result != null) {
                    this.WriteVerbose(this, "got the window");
                }
                UIAutomation.CurrentData.CurrentWindow = result;  // ????? 20120728
                this.WriteObject(this, result);
            } // 20120824
        }
    }
}
