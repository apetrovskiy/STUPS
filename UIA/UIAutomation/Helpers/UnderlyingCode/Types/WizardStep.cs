/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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
        // 20130319
        //public ScriptBlock[] StepGetWindowAction { get; set; }
        
        public Hashtable[] SearchCriteria { get; set; }
        // 20130317
        public Wizard Parent { get; set; }
        // 20130318
        public string Description { get; set; }
        // 20130318
        public object[] StepForwardActionParameters { get; set; }
        public object[] StepBackwardActionParameters { get; set; }
        public object[] StepCancelActionParameters { get; set; }
        // 20130319
        //public object[] StepGetWindowActionParameters { get; set; }
        
        // 20130321
        public WizardStepActions ToDo { get; set; }
    }
}
