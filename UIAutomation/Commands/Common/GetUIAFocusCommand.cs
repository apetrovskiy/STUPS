/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/16/2012
 * Time: 11:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    //using System.Runtime.InteropServices;
    using System.Windows.Automation;
    //using UIAutomationClient;
    
    /// <summary>
    /// Description of GetUIAFocusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAFocus")]
    public class GetUIAFocusCommand : HasControlInputCmdletBase
    {
        #region Constructor
        public GetUIAFocusCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new AutomationElement InputObject { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            this.WriteObject(this, AutomationElement.FocusedElement);
        }
    }
}
