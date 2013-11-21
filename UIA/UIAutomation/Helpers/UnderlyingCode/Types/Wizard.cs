/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2013
 * Time: 11:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Linq;

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
            return this.Steps.FirstOrDefault(step => String.Equals(name, step.Name, StringComparison.CurrentCultureIgnoreCase));
            // return this.Steps.FirstOrDefault(step => name.ToUpper() == step.Name.ToUpper());
            /*
            foreach (WizardStep step in this.Steps)
            {

                if (name.ToUpper() == step.Name.ToUpper())
                {

                    resultStep = step;
                    break;
                }
            }
            */
        }

        public WizardStep GetActiveStep()
        {
            this.StopImmediately = false;
            
        	WizardStep resultStep = null;
        	
        	//GetControlCmdletBase cmdletCtrl =
        	//	new GetControlCmdletBase();
        	UIAutomation.Commands.GetUiaControlCommand cmdletCtrl =
        	    new UIAutomation.Commands.GetUiaControlCommand
        	    {
        	        InputObject = new MySuperWrapper[] {(MySuperWrapper) CurrentData.CurrentWindow},
        	        Timeout = 0
        	    };

            /*
        	UIAutomation.Commands.GetUiaControlCommand cmdletCtrl =
        	    new UIAutomation.Commands.GetUiaControlCommand();

        	cmdletCtrl.InputObject =
        	    // 20131109
        		//new AutomationElement[]{ CurrentData.CurrentWindow };
        	    new MySuperWrapper[]{ (MySuperWrapper)CurrentData.CurrentWindow };

        	cmdletCtrl.Timeout = 0;
            */

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

        	    if (null == controlsList || 0 >= controlsList.Count) continue;
        	    if (step == this.ActiveStep) {
	        	        
        	        // 20130423
        	        if (Preferences.HighlightCheckedControl) {
        	            
        	            // 20131109
        	            //foreach (AutomationElement elementChecked in controlsList) {
        	            foreach (IMySuperWrapper elementChecked in controlsList) {
        	                UiaHelper.HighlightCheckedControl(elementChecked);
        	            }
        	        }
	        	        
        	        continue;
        	    }
	        	    
        	    resultStep = step;
        	    this.ActiveStep = step;
        	    break;

        	    /*
	        	if (null != controlsList && 0 < controlsList.Count) {

	        	    if (step == this.ActiveStep) {
	        	        
	        	        // 20130423
	        	        if (Preferences.HighlightCheckedControl) {
	        	            foreach (AutomationElement elementChecked in controlsList) {
	        	                UiaHelper.HighlightCheckedControl(elementChecked);
	        	            }
	        	        }
	        	        
	        	        continue;
	        	    }
	        	    
	        		resultStep = step;
	        		this.ActiveStep = step;
	        		break;
	        	}
                */
            }
        	
        	// 20130515
        	// moving the current step to the end of the step collection
        	try {
        	   int currentIndex = this.Steps.IndexOf(resultStep);
        	   try {
        	       cmdletCtrl.WriteInfo(cmdletCtrl, "current index = " + currentIndex.ToString());
        	   }
        	   catch {
        	       cmdletCtrl.WriteInfo(cmdletCtrl, "failed to show the current index");
        	   }
        	   // 20130712
        	   if (0 <= currentIndex && (this.Steps.Count - 1) != currentIndex) {
            	   this.Steps.Insert(this.Steps.Count, resultStep);
            	   cmdletCtrl.WriteInfo(cmdletCtrl, "inserted after the last step");
            	   this.Steps.RemoveAt(currentIndex);
            	   cmdletCtrl.WriteInfo(cmdletCtrl, "deleted from the previous position");
        	   } else {
        	       cmdletCtrl.WriteInfo(cmdletCtrl, "there was no manipulation with wizard steps' order");
        	   }
        	}
        	catch (Exception eMovingToTheEnd) {
        	    cmdletCtrl.WriteInfo(cmdletCtrl, eMovingToTheEnd.Message);
        	}
        	
        	return resultStep;
        }
        
        public void Stop()
        {
            this.StopImmediately = true;
        }
    }
}
