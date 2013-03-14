/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 3:02 AM
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
    /// Description of WizardCollection.
    /// </summary>
    //internal static class WizardCollection
    public static class WizardCollection
    {
        static WizardCollection()
        {
            Wizards = new List<Wizard>();
        }
        
        public static List<Wizard> Wizards { get; set; }
        
        public static void ResetData()
        {
            Wizards = new List<Wizard>();
        }
        
    }
    
    public class Wizard
    {
        public Wizard(string name)
        {
            this.Name = name;
            Steps = new List<WizardStep>();
            WizardCollection.Wizards.Add(this);
        }
        
        public string Name { get; set; }
        public List<WizardStep> Steps { get; set; }
        public ScriptBlock[] StartAction { get; set; }
        //public ScriptBlock[] StopAction { get; set; }
    }
    
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
        public Hashtable[] SearchCriteria { get; set; }
        
        
    }
}
