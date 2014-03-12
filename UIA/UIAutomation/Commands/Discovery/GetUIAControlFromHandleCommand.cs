/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/2/2012
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Linq;

namespace UIAutomation.Commands
{
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUiaControlFromHandleCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaControlFromHandle")]
    [OutputType(typeof(object))]
    public class GetUiaControlFromHandleCommand : DiscoveryCmdletBase
    {
        #region Parameters
//        [UiaParameterNotUsed][Parameter(Mandatory = true,
//                   ValueFromPipeline = true)]
//        [Alias("Handle")]
//        public new int InputObject { get; set; }
        [ValidateNotNullOrEmpty]
        [Alias ("Handle")]
        [UiaParameter][Parameter(Mandatory = false, 
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
            // 20131109
            //System.Windows.Automation.AutomationElement result = null;
            /*
            IUiElement result = null;
            */

            foreach (IUiElement result in InputObject.Select(handle => UiaHelper.GetAutomationElementFromHandle(
                // this,
                handle)))
            {
                if (result != null) {
                    // 20140312
                    // WriteVerbose(this, "got the control: " + result.Current.Name);
                }
                WriteObject(this, result);
            }
            /*
            foreach (int handle in InputObject) {
                IUiElement result = UiaHelper.GetAutomationElementFromHandle(
                    this,
                    handle);
                if (result != null) {
                    WriteVerbose(this, "got the control: " + result.Current.Name);
                }
                WriteObject(this, result);
            }
            */
        }
    }
    
    /// <summary>
    /// Description of GetUiaWindowFromHandleCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UiaWindowFromHandle")]
    [OutputType(typeof(object))]
    public class GetUiaWindowFromHandleCommand : GetUiaControlFromHandleCommand
    {
        #region Constructor
        // 20131105
        // refactoring
        /*
        public GetUiaWindowFromHandleCommand()
        {
        }
        */
        #endregion Constructor

        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // 20131109
            //System.Windows.Automation.AutomationElement result = null;
            // 20131113
            foreach (IUiElement result in InputObject.Select(handle => UiaHelper.GetAutomationElementFromHandle(
                // this,
                handle)))
            {
                if (result != null) {
                    WriteVerbose(this, "got the window");
                }
                CurrentData.CurrentWindow = result;
                WriteObject(this, result);
            }

            /*
            foreach (int handle in this.InputObject) {
                
                // 20131109
                //result = 
                //    UiaHelper.GetAutomationElementFromHandle(
                //        this,
                //        handle);
                IUiElement result =
                    UiaHelper.GetAutomationElementFromHandle(
                        this,
                        handle);
                
                if (result != null) {
                    this.WriteVerbose(this, "got the window");
                }
                UIAutomation.CurrentData.CurrentWindow = result;
                this.WriteObject(this, result);
            }
            */
        }
    }
}
