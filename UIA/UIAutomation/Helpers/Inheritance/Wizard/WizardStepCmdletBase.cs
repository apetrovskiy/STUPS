/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/20/2013
 * Time: 4:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Description of WizardStepCmdletBase.
    /// </summary>
    public class WizardStepCmdletBase : WizardConstructionCmdletBase
    {
        public WizardStepCmdletBase()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        //public System.Collections.Hashtable[] SearchCriteria { get; set; }
        public Hashtable[] SearchCriteria { get; set; }
        [Parameter(Mandatory = false)]
        public ScriptBlock[] StepForwardAction { get; set; }
        [Parameter(Mandatory = false)]
        public ScriptBlock[] StepBackwardAction { get; set; }
        // 20130317
        [Parameter(Mandatory = false)]
        public ScriptBlock[] StepCancelAction { get; set; }
        // 20130317
        // 20130319
        //[Parameter(Mandatory = false)]
        //public ScriptBlock[] StepGetWindowAction { get; set; }
        
        [Parameter(Mandatory = false)]
        public int Order { get; set; }
        
//        // 20130318
//        [Parameter(Mandatory = false)]
//        public string Description { get; set; }
        #endregion Parameters
    }
}
