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
    using System.Windows.Automation;

    /// <summary>
    /// Description of Wizard.
    /// </summary>
    public class Wizard
    {
        public Wizard(string name)
        {
            this.Name = name;
            this.Steps = new List<WizardStep>();
            WizardCollection.Wizards.Add(this);
        }
        
        public string Name { get; set; }
        public List<WizardStep> Steps { get; set; }
        public ScriptBlock[] StartAction { get; set; }
        //public ScriptBlock[] StopAction { get; set; }
        // 20130317
        public ScriptBlock[] StopAction { get; set; }
        // 20130317
        public ScriptBlock[] DefaultStepForwardAction { get; set; }
        // 20130317
        public ScriptBlock[] DefaultStepBackwardAction { get; set; }
        // 20130317
        public ScriptBlock[] DefaultStepCancelAction { get; set; }
        // 20130317
        // 20130319
        //public ScriptBlock[] DefaultStepGetWindowAction { get; set; }
        public ScriptBlock[] GetWindowAction { get; set; }
        // 20130322
        // // 20130317
        //public bool Automatic { get; set; }
        // 20130322
        // // 20130317
        //public bool ForwardDirection { get; set; }
        // 20130318
        public WizardStep ActiveStep { get; set; }
        // 20130318
        internal bool StopImmediately { get; set; }
        // 20130325
        public object[] StartActionParameters { get; set; }
        public object[] StopActionParameters { get; set; }
        
        public void ClearSteps()
        {
            this.Steps = new List<WizardStep>();
        }
        
        public void ClearStepsData()
        {
            foreach (WizardStep step in this.Steps) {
                
                step.StepForwardAction = null;
                step.StepBackwardAction = null;
            }
        }
        
        public void ClearStepsData(bool forward, bool backward)
        {
            foreach (WizardStep step in this.Steps) {
                
                if (forward) {
                    step.StepForwardAction = null;
                }
                if (backward) {
                    step.StepBackwardAction = null;
                }
            }
        }
        
        public WizardStep GetStep(string name)
        {
            WizardStep resultStep = null;
            
            foreach (WizardStep step in this.Steps) {
                
                if (name.ToUpper() == step.Name.ToUpper()) {
                    
                    resultStep = step;
                    break;
                }
            }
            
            return resultStep;
        }
        
        public WizardStep GetActiveStep()
        {
            this.StopImmediately = false;
            
        	WizardStep resultStep = null;
        	
        	//GetControlCmdletBase cmdletCtrl =
        	//	new GetControlCmdletBase();
        	UIAutomation.Commands.GetUIAControlCommand cmdletCtrl =
        	    new UIAutomation.Commands.GetUIAControlCommand();

        	cmdletCtrl.InputObject =
        		new AutomationElement[]{ CurrentData.CurrentWindow };

        	cmdletCtrl.Timeout = 0;
        	
        	foreach (WizardStep step in this.Steps) {

        	    if (this.StopImmediately) {
        	        resultStep = step;
        	        break;
        	    }
        	    
        	    // 20130320
			    // sleep interval
			    System.Threading.Thread.Sleep(Preferences.OnSelectWizardStepDelay);
        	    
        		cmdletCtrl.SearchCriteria = step.SearchCriteria;

	        	ArrayList controlsList = null;
	        	
	        	try {

	        		controlsList =
	        			cmdletCtrl.GetControl(cmdletCtrl);

	        	}
	        	catch {}
        		
	        	if (null != controlsList && 0 < controlsList.Count) {

	        	    if (step == this.ActiveStep) {
	        	        
	        	        // 20130423
	        	        if (Preferences.HighlightCheckedControl) {
	        	            foreach (AutomationElement elementChecked in controlsList) {
	        	                UIAHelper.HighlightCheckedControl(elementChecked);
	        	            }
	        	        }
	        	        
	        	        continue;
	        	    }
	        	    
	        		resultStep = step;
	        		this.ActiveStep = step;
	        		break;
	        	}
        	}
        	
        	// 20130515
        	// moving the current step to the end of the step collection
        	int currentIndex = this.Steps.IndexOf(resultStep);
        	this.Steps.Insert(this.Steps.Count, resultStep);
        	this.Steps.RemoveAt(currentIndex);
        	
        	return resultStep;
        }
        
        public void Stop()
        {
            this.StopImmediately = true;
        }
    }
}
