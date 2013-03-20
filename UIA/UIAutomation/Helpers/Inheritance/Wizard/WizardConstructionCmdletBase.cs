/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 11:20 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    
    /// <summary>
    /// Description of WizardConstructionCmdletBase.
    /// </summary>
    public class WizardConstructionCmdletBase : WizardCmdletBase
    {
        public WizardConstructionCmdletBase()
        {
        }
        
        #region Parameters
//        [Parameter(Mandatory = false)]
//        //public System.Collections.Hashtable[] SearchCriteria { get; set; }
//        public Hashtable[] SearchCriteria { get; set; }
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] StepForwardAction { get; set; }
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] StepBackwardAction { get; set; }
//        // 20130317
//        [Parameter(Mandatory = false)]
//        public ScriptBlock[] StepCancelAction { get; set; }
//        // 20130317
//        // 20130319
//        //[Parameter(Mandatory = false)]
//        //public ScriptBlock[] StepGetWindowAction { get; set; }
//        
//        [Parameter(Mandatory = false)]
//        public int Order { get; set; }
        
        // 20130318
        [Parameter(Mandatory = false)]
        public string Description { get; set; }
        #endregion Parameters
    }
}
