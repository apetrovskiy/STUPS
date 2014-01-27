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
    extern alias UIANET;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Windows.Automation;
    using System.Linq;
    using System.Threading;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of Wizard.
    /// </summary>
    public class Wizard
    {
        public Wizard(string name)
        {
            Name = name;
            Steps = new List<WizardStep>();
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
            Steps = new List<WizardStep>();
        }
        
        public void ClearStepsData()
        {
            foreach (WizardStep step in Steps) {
                
                step.StepForwardAction = null;
                step.StepBackwardAction = null;
            }
        }
        
        public void ClearStepsData(bool forward, bool backward)
        {
            foreach (WizardStep step in Steps) {
                
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
            return Steps.FirstOrDefault(step => String.Equals(name, step.Name, StringComparison.CurrentCultureIgnoreCase));
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
            StopImmediately = false;
            
        	WizardStep resultStep = null;
        	
        	// load controls from the wizard's window
        	var allWizardControls =
        	    (CurrentData.CurrentWindow as ISupportsExtendedModel).Descendants.PerformFindAll();
        	
        	//GetControlCmdletBase cmdletCtrl =
        	//	new GetControlCmdletBase();
        	// 20140127
        	// GetUiaControlCommand cmdletCtrl =
        	//     new GetUiaControlCommand
        	//     {
        	//         InputObject = new UiElement[] {(UiElement) CurrentData.CurrentWindow},
        	//         Timeout = 0
        	//     };
        	
        	// 20140127
        	// var controlSearchData =
        	//     new ControlSearchData {
        	//     InputObject = new IUiElement[] { CurrentData.CurrentWindow }
        	// };
            
            foreach (WizardStep step in Steps) {

        	    if (StopImmediately) {
        	        resultStep = step;
        	        break;
        	    }
        	    
        	    // 20130320
			    // sleep interval
			    
			    // 20140127
			    // Thread.Sleep(Preferences.OnSelectWizardStepDelay);
        	    
			    // 20140127
        		// cmdletCtrl.SearchCriteria = step.SearchCriteria;
        		// controlSearchData.SearchCriteria = step.SearchCriteria;
        		
//        		if (step.SearchCriteria.All(x => {
//        		                                  foreach (IUiElement element in allWizardControls) {
//        		                                      return ControlSearch.TestControlWithAllSearchCriteria(step.SearchCriteria, element); 
//        		                                  }
//        		                                return false;
//        		                            })) {
//                    
//        		    
//        		    Console.WriteLine("there is global match");
//                    
//        		    
//            	    resultStep = step;
//            	    ActiveStep = step;
//            	    break;
//                    
//                }
        		
        		if (IsStepActive(step, allWizardControls)) {
        		    resultStep = step;
        		    ActiveStep = step;
        		    break;
        		}
        		
//	        	List<IUiElement> controlsList = new List<IUiElement>();
//	        	
//
//        	    if (null == controlsList || 0 >= controlsList.Count) continue;
//        	    if (step == ActiveStep) {
//	        	        
//        	        // 20130423
//        	        if (Preferences.HighlightCheckedControl) {
//        	            
//        	            foreach (IUiElement elementChecked in controlsList) {
//        	                UiaHelper.HighlightCheckedControl(elementChecked);
//        	            }
//        	        }
//	        	        
//        	        continue;
//        	    }
//        	    
//        	    // 20140121
//        	    if (null != controlsList) {
//        	        controlsList.Clear();
//        	        controlsList = null;
//        	    }
//	        	    
//        	    resultStep = step;
//        	    ActiveStep = step;
//        	    break;
            }
        	
        	// 20130515
        	// moving the current step to the end of the step collection
        	try {
        	   int currentIndex = Steps.IndexOf(resultStep);
        	   // 20140127
        	   // try {
        	   //     cmdletCtrl.WriteInfo(cmdletCtrl, "current index = " + currentIndex.ToString());
        	   // }
        	   // catch {
        	   //     cmdletCtrl.WriteInfo(cmdletCtrl, "failed to show the current index");
        	   // }
        	   // 20130712
        	   if (0 <= currentIndex && (Steps.Count - 1) != currentIndex) {
            	   Steps.Insert(Steps.Count, resultStep);
            	   // cmdletCtrl.WriteInfo(cmdletCtrl, "inserted after the last step");
            	   Steps.RemoveAt(currentIndex);
            	   // cmdletCtrl.WriteInfo(cmdletCtrl, "deleted from the previous position");
        	   } else {
        	       // cmdletCtrl.WriteInfo(cmdletCtrl, "there was no manipulation with wizard steps' order");
        	   }
        	}
        	catch (Exception eMovingToTheEnd) {
        	    // cmdletCtrl.WriteInfo(cmdletCtrl, eMovingToTheEnd.Message);
        	}
        	
        	return resultStep;
        }
        
        internal bool IsStepActive(WizardStep step, IUiEltCollection elements)
        {
            bool result = false;
            
Console.WriteLine("testing step '" + step.Name + "'");
Console.WriteLine("there are {0} elements", elements.Count);
            
            if (step.SearchCriteria.All(criterion => {
                                            foreach (IUiElement element in elements) {
                                                return ControlSearch.TestControlWithAllSearchCriteria(step.SearchCriteria, element);
                                            }
                                            return false;
                                        })) {
                result = true;
Console.WriteLine("step active? " + result.ToString());
            }
            
            return result;
        }
        
        // 20140127
        /*
        public WizardStep GetActiveStep()
        {
            StopImmediately = false;
            
        	WizardStep resultStep = null;
        	
        	//GetControlCmdletBase cmdletCtrl =
        	//	new GetControlCmdletBase();
        	// 20140127
        	// GetUiaControlCommand cmdletCtrl =
        	//     new GetUiaControlCommand
        	//     {
        	//         InputObject = new UiElement[] {(UiElement) CurrentData.CurrentWindow},
        	//         Timeout = 0
        	//     };
        	var controlSearchData =
        	    new ControlSearchData {
        	    InputObject = new IUiElement[] { CurrentData.CurrentWindow }
        	};
            
            foreach (WizardStep step in Steps) {

        	    if (StopImmediately) {
        	        resultStep = step;
        	        break;
        	    }
        	    
        	    // 20130320
			    // sleep interval
			    Thread.Sleep(Preferences.OnSelectWizardStepDelay);
        	    
			    // 20140127
        		// cmdletCtrl.SearchCriteria = step.SearchCriteria;
        		controlSearchData.SearchCriteria = step.SearchCriteria;
                
	        	List<IUiElement> controlsList = new List<IUiElement>();
	        	
	        	try {
                    // 20140116
	        		// controlsList =
	        		// 	cmdletCtrl.GetControl(cmdletCtrl);
	        		
	        		var controlSearch =
	        		    AutomationFactory.GetSearchImpl<ControlSearch>() as ControlSearch;
	        		
	        		controlsList =
	        		    controlSearch.GetElements(
//	        		        new ControlSearchData {
//	        		            InputObject = cmdletCtrl.InputObject,
//	        		            ContainsText = cmdletCtrl.ContainsText,
//	        		            Name = cmdletCtrl.Name,
//	        		            AutomationId = cmdletCtrl.AutomationId,
//	        		            Class = cmdletCtrl.Class,
//	        		            Value = cmdletCtrl.Value,
//	        		            ControlType = cmdletCtrl.ControlType,
//	        		            SearchCriteria = cmdletCtrl.SearchCriteria,
//	        		            Win32 = cmdletCtrl.Win32
//	        		        },
	        		        // 20140127
	        		        // controlSearch.ConvertCmdletToControlSearchData(cmdletCtrl),
	        		        controlSearchData,
	        		        // 20140127
	        		        // cmdletCtrl.Timeout);
	        		        0);
	        		
	        	}
	        	catch {}

        	    if (null == controlsList || 0 >= controlsList.Count) continue;
        	    if (step == ActiveStep) {
	        	        
        	        // 20130423
        	        if (Preferences.HighlightCheckedControl) {
        	            
        	            foreach (IUiElement elementChecked in controlsList) {
        	                UiaHelper.HighlightCheckedControl(elementChecked);
        	            }
        	        }
	        	        
        	        continue;
        	    }
        	    
        	    // 20140121
        	    if (null != controlsList) {
        	        controlsList.Clear();
        	        controlsList = null;
        	    }
	        	    
        	    resultStep = step;
        	    ActiveStep = step;
        	    break;
            }
        	
        	// 20130515
        	// moving the current step to the end of the step collection
        	try {
        	   int currentIndex = Steps.IndexOf(resultStep);
        	   // 20140127
        	   // try {
        	   //     cmdletCtrl.WriteInfo(cmdletCtrl, "current index = " + currentIndex.ToString());
        	   // }
        	   // catch {
        	   //     cmdletCtrl.WriteInfo(cmdletCtrl, "failed to show the current index");
        	   // }
        	   // 20130712
        	   if (0 <= currentIndex && (Steps.Count - 1) != currentIndex) {
            	   Steps.Insert(Steps.Count, resultStep);
            	   // cmdletCtrl.WriteInfo(cmdletCtrl, "inserted after the last step");
            	   Steps.RemoveAt(currentIndex);
            	   // cmdletCtrl.WriteInfo(cmdletCtrl, "deleted from the previous position");
        	   } else {
        	       // cmdletCtrl.WriteInfo(cmdletCtrl, "there was no manipulation with wizard steps' order");
        	   }
        	}
        	catch (Exception eMovingToTheEnd) {
        	    // cmdletCtrl.WriteInfo(cmdletCtrl, eMovingToTheEnd.Message);
        	}
        	
        	return resultStep;
        }
        */
        
        public void Stop()
        {
            StopImmediately = true;
        }
    }
}
