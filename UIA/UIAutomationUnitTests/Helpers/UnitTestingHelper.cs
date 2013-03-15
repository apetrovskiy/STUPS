/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/25/2013
 * Time: 9:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests
{
    using System;
    using UIAutomation;
    using UIAutomation.Commands;
    using PSTestLib;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of UnitTestingHelper.
    /// </summary>
    public static class UnitTestingHelper
    {
        static UnitTestingHelper()
        {
        }
        
        public static void PrepareUnitTestDataStore()
        {
            PSCmdletBase.UnitTestMode = true;
            
            if (0 < PSTestLib.UnitTestOutput.Count) {

                PSTestLib.UnitTestOutput.Clear();
            }
            
            UIAutomation.CurrentData.ResetData();
            
        }
        
        public static void CreateWizard(string name, ScriptBlock[] sb)
        {
            UIAutomation.Commands.NewUIAWizardCommand cmdlet =
                new UIAutomation.Commands.NewUIAWizardCommand();
            cmdlet.Name = name;
            cmdlet.StartAction = sb;
            UIANewWizardCommand command =
                new UIANewWizardCommand(cmdlet);
            command.Execute();
        }
        
        public static void AddWizardStep(string name, ScriptBlock[] forwardAction, ScriptBlock[] backwardAction)
        {
            CreateWizard("wizard", null);
        	Wizard wizard =
        	    (Wizard)UnitTestOutput.LastOutput[0];
        	
        	UIAutomation.Commands.AddUIAWizardStepCommand cmdlet =
        	    new AddUIAWizardStepCommand();
        	cmdlet.InputObject = wizard;
        	cmdlet.Name = name;
        	cmdlet.StepForwardAction = forwardAction;
        	cmdlet.StepBackwardAction = backwardAction;
        	
        	UIAutomation.UIAAddWizardStepCommand command =
        	    new UIAutomation.UIAAddWizardStepCommand(cmdlet);
        	
        	command.Execute();
        }
    }
}
