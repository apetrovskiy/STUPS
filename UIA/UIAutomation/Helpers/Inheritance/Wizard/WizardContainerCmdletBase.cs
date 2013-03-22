/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 12:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of WizardContainerCmdletBase.
    /// </summary>
    public class WizardContainerCmdletBase : WizardConstructionCmdletBase
    {
        public WizardContainerCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        // 20130322
        //internal new Wizard InputObject { get; set; }
        public new Wizard InputObject { get; set; }
        
        
        
        
//        [Parameter(Mandatory = true)]
//        [ValidateNotNullOrEmpty]
//        public ScriptBlock[] StartAction { get; set; }
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] StopAction { get; set; }
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] DefaultStepForwardAction { get; set; }
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] DefaultStepBackwardAction { get; set; }
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] DefaultStepCancelAction { get; set; }
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] DefaultStepGetWindowAction { get; set; }
//        [Parameter(Mandatory = false)]
//        internal int Order { get; set; }
        #endregion Parameters
    }
}
