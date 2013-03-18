/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/15/2013
 * Time: 11:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;

    /// <summary>
    /// Description of WizardStep.
    /// </summary>
    public class WizardStep
    {
        public WizardStep(string name, int order)
        {
            this.Name = name;
            this.Order = order;
        }
        
        public string Name { get; set; }
        public int Order { get; set; }
        public ScriptBlock[] StepForwardAction { get; set; }
        public ScriptBlock[] StepBackwardAction { get; set; }
        // 20130317
        public ScriptBlock[] StepCancelAction { get; set; }
        // 20130317
        public ScriptBlock[] StepGetWindowAction { get; set; }
        public Hashtable[] SearchCriteria { get; set; }
        // 20130317
        public Wizard Parent { get; set; }
        // 20130318
        public string Description { get; set; }
    }
}
