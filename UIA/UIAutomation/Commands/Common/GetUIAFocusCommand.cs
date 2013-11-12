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
    // test it
    //using System;
    using System.Management.Automation;
    //using System.Runtime.InteropServices;
    using System.Windows.Automation;
    //using UIAutomationClient;
    
    using Ninject;
    using Ninject.Parameters;
    
    /// <summary>
    /// Description of GetUIAFocusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAFocus")]
    public class GetUIAFocusCommand : HasControlInputCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false)]
        // 20131109
        //internal new AutomationElement InputObject { get; set; }
        internal new IMySuperWrapper InputObject { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            // 20131109
            //this.WriteObject(this, AutomationElement.FocusedElement);
            // 20131111
            //this.WriteObject(this, new MySuperWrapper(AutomationElement.FocusedElement));
            // 20131112
            //this.WriteObject(this, ObjectsFactory.Kernel.Get<IMySuperWrapper>( new MySuperWrapper[] { MySuperWrapper.FocusedElement } ));
            this.WriteObject(this, MySuperWrapper.FocusedElement);
        }
    }
}
