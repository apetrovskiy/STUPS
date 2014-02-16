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
    using System.Management.Automation;
    using System.Collections;

    /// <summary>
    /// Description of WizardStepCmdletBase.
    /// </summary>
    public class WizardStepCmdletBase : WizardConstructionCmdletBase
    {
        public WizardStepCmdletBase()
        {
        }
        
        #region Parameters
        [UiaParameter][Parameter(Mandatory = false)]
        //public System.Collections.Hashtable[] SearchCriteria { get; set; }
        public Hashtable[] SearchCriteria { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] StepForwardAction { get; set; }
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] StepBackwardAction { get; set; }
        // 20130317
        [UiaParameter][Parameter(Mandatory = false)]
        public ScriptBlock[] StepCancelAction { get; set; }
        // 20130317
        // 20130319
        //[UiaParameterNotUsed][Parameter(Mandatory = false)]
        //public ScriptBlock[] StepGetWindowAction { get; set; }
        
        [UiaParameter][Parameter(Mandatory = false)]
        public int Order { get; set; }
        
//        // 20130318
//        [UiaParameterNotUsed][Parameter(Mandatory = false)]
//        public string Description { get; set; }
        #endregion Parameters
    }
}
