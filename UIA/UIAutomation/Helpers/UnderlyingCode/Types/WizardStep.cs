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
    using System.Collections;
    using System.Management.Automation;

    /// <summary>
    /// Description of WizardStep.
    /// </summary>
    public class WizardStep
    {
        public WizardStep(string name, int order)
        {
            Name = name;
            Order = order;
        }
        
        public string Name { get; set; }
        public int Order { get; set; }
        public ScriptBlock[] StepForwardAction { get; set; }
        public ScriptBlock[] StepBackwardAction { get; set; }
        public ScriptBlock[] StepCancelAction { get; set; }
        public Hashtable[] SearchCriteria { get; set; }
        public Wizard Parent { get; set; }
        public string Description { get; set; }
        public object[] StepForwardActionParameters { get; set; }
        public object[] StepBackwardActionParameters { get; set; }
        public object[] StepCancelActionParameters { get; set; }
        public WizardStepActions ToDo { get; set; }
    }
}
